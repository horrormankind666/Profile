﻿/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๙/๐๙/๒๕๕๗>
Modify date : <๐๙/๐๓/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผลในส่วนของการจัดการข้อมูลระเบียนประวัตินักศึกษา>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;
using NStudentService;

public class ePFStudentRecordsUI
{
    private static string _idSectionMain      = ePFUtil.ID_SECTION_STUDENTRECORDS_MAIN.ToLower();
    private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDS_ADDUPDATE.ToLower();
        
    public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
    {
        StringBuilder _html = new StringBuilder();

        switch (_section)
        {
            case "MAIN": 
                _html = SectionMainUI.GetMain(_id);
                break;
            case "ADDUPDATE":
                _html = SectionAddUpdateUI.GetMain(_id);
                break;
        }

        return _html;
    }    
    
    public class SectionMainUI
    {
        public static StringBuilder GetMain(string _id)
        {
            Dictionary<string, object> _infoData = new Dictionary<string, object>();
            Dictionary<string, object> _infoDataResult = ePFUtil.GetInfoData(ePFUtil.PAGE_STUDENTRECORDS_MAIN, _infoData);
            StringBuilder _html = new StringBuilder();
            
            _html.AppendLine(ePFUI.GetInfoBar(_infoDataResult, true).ToString());
            _html.AppendLine("<div class='after-sticky'>");
            _html.AppendFormat("<div class='form' id='{0}-form'>", _idSectionMain);
            _html.AppendLine("      <div class='form-layout'>");
            _html.AppendFormat("        <div class='form-content'>{0}</div>", SectionAddUpdateUI.StudentRecordsUI.GetMain(_id).ToString());
            _html.AppendLine("      </div>");
            _html.AppendLine("  </div>");
            _html.AppendLine("</div>");

            return _html;
        }
    }

    public class SectionAddUpdateUI
    {
        public static StringBuilder GetMain(string _id)
        {
            StringBuilder _html = new StringBuilder();
            Dictionary<string, object> _infoData = new Dictionary<string, object>();
            Dictionary<string, object> _infoDataResult = ePFUtil.GetInfoData(ePFUtil.PAGE_STUDENTRECORDS_ADDUPDATE, _infoData);
            int _i = 0;

            _html.AppendLine(ePFUI.GetInfoBar(_infoDataResult, true).ToString());
            _html.AppendLine("<div class='after-sticky'>");
            _html.AppendLine("  <div>");
            _html.AppendFormat("    <div class='sticky-left menulist' id='{0}-menu'>", _idSectionAddUpdate);
            _html.AppendLine("          <div class='menulist-layout'>");
            _html.AppendFormat("            <div class='menulist-content' id='{0}-menu-content'>", _idSectionAddUpdate);
            _html.AppendLine("                  <ul>");

            for (_i = 0; _i < 7; _i++)
            {
                _html.AppendFormat("                <li class='have-link'><a class='link-click link-msg{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='menu-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                    (ePFStudentRecordsUtil._menuRecords[_i, 2].Equals("active") ? " menu-active" : String.Empty),
                    ePFStudentRecordsUtil._menuRecords[_i, 3].ToLower(),
                    ePFStudentRecordsUtil._menuRecords[_i, 0],
                    ePFStudentRecordsUtil._menuRecords[_i, 1]
                );
            }

            _html.AppendLine("                  </ul>");
            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendFormat("    <div id='{0}'>", _idSectionAddUpdate);
            _html.AppendFormat("        <div id='{0}-layout'>", _idSectionAddUpdate);
            _html.AppendFormat("            <div id='{0}-content'>", _idSectionAddUpdate);
            _html.AppendFormat("                <div class='menu-active' id='{0}' alt='{1}'>{2}</div>",   ePFUtil.ID_SECTION_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE.ToLower(), ePFUtil.PAGE_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE, StudentRecordsUI.GetMain(_id));

            for (_i = 0; _i < 7; _i++)
            {
                _html.AppendFormat("            <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>", ePFStudentRecordsUtil._menuRecords[_i, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[_i, 4], String.Empty);
            }

            _html.AppendLine("              </div>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendLine("  </div");
            _html.AppendLine("</div");

            return _html;
        }

        public class StudentRecordsUI
        {
            private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSSTUDENTRECORDS] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-personid-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PersonId", _dataRecorded["PersonId"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentcode-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentCode", _dataRecorded["StudentCode"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-isprogramcontract' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IsProgramContract", _dataRecorded["IsProgramContract"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gender-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Gender", _dataRecorded["Gender"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentpicture-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentPicture", _dataRecorded["StudentPicture"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-entrancetype-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EntranceType", _dataRecorded["EntranceType"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordspersonalstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsPersonalStatus", _dataRecorded["StudentRecordsPersonalStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsaddresspermanentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsAddressPermanentStatus", _dataRecorded["StudentRecordsAddressPermanentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsaddresscurrentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsAddressCurrentStatus", _dataRecorded["StudentRecordsAddressCurrentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordseducationprimaryschoolstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsEducationPrimarySchoolStatus", _dataRecorded["StudentRecordsEducationPrimarySchoolStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordseducationjuniorhighschoolstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsEducationJuniorHighSchoolStatus", _dataRecorded["StudentRecordsEducationJuniorHighSchoolStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordseducationhighschoolstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsEducationHighSchoolStatus", _dataRecorded["StudentRecordsEducationHighSchoolStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordseducationuniversitystatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsEducationUniversityStatus", _dataRecorded["StudentRecordsEducationUniversityStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordseducationadmissionscoresstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsEducationAdmissionScoresStatus", _dataRecorded["StudentRecordsEducationAdmissionScoresStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordstalentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsTalentStatus", _dataRecorded["StudentRecordsTalentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordshealthystatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsHealthyStatus", _dataRecorded["StudentRecordsHealthyStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsworkstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsWorkStatus", _dataRecorded["StudentRecordsWorkStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfinancialstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFinancialStatus", _dataRecorded["StudentRecordsFinancialStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilyfatherpersonalstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyFatherPersonalStatus", _dataRecorded["StudentRecordsFamilyFatherPersonalStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilymotherpersonalstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyMotherPersonalStatus", _dataRecorded["StudentRecordsFamilyMotherPersonalStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilyparentpersonalstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyParentPersonalStatus", _dataRecorded["StudentRecordsFamilyParentPersonalStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilyfatheraddresspermanentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyFatherAddressPermanentStatus", _dataRecorded["StudentRecordsFamilyFatherAddressPermanentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilymotheraddresspermanentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyMotherAddressPermanentStatus", _dataRecorded["StudentRecordsFamilyMotherAddressPermanentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilyparentaddresspermanentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyParentAddressPermanentStatus", _dataRecorded["StudentRecordsFamilyParentAddressPermanentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilyfatheraddresscurrentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyFatherAddressCurrentStatus", _dataRecorded["StudentRecordsFamilyFatherAddressCurrentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilymotheraddresscurrentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyMotherAddressCurrentStatus", _dataRecorded["StudentRecordsFamilyMotherAddressCurrentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilyparentaddresscurrentstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyParentAddressCurrentStatus", _dataRecorded["StudentRecordsFamilyParentAddressCurrentStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilyfatherworkstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyFatherWorkStatus", _dataRecorded["StudentRecordsFamilyFatherWorkStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilymotherworkstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyMotherWorkStatus", _dataRecorded["StudentRecordsFamilyMotherWorkStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsfamilyparentworkstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentRecordsFamilyParentWorkStatus", _dataRecorded["StudentRecordsFamilyParentWorkStatus"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[12];
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSSTUDENTRECORDS_ADDUPDATE, _id);
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSSTUDENTRECORDS];
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
                _contentTemp.AppendFormat("<div class='th-label'>{0}</div>", _dataRecorded["AdmissionDate"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-admissiondate"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "วันที่เข้าศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Admission Date");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("AdmissionDate", _contentFrmColumnDetail[_i]);
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
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["StudentPicture"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["StudentID"]).ToString());                
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["FullName"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["DegreeLevel"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Faculty"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Program"]).ToString());                
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["YearEntry"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Class"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["StudentStatus"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["AdmissionDate"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["GraduationDate"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class PersonalUI
        {
            private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSPERSONAL_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {                    
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSPERSONAL] : null);

                _html.AppendFormat("<input type='hidden' id='{0}-idcard-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IdCard", _dataRecorded["IdCard"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-idcardissuedate-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IdCardIssueDateEN", _dataRecorded["IdCardIssueDateEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-idcardexpirydate-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IdCardExpiryDateEN", _dataRecorded["IdCardExpiryDateEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-titleprefix-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "TitlePrefix", _dataRecorded["TitlePrefix"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gendertitleprefix-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GenderTitlePrefix", _dataRecorded["GenderTitlePrefix"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-firstname-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "FirstName", _dataRecorded["FirstName"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-middlename-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "MiddleName", _dataRecorded["MiddleName"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-lastname-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "LastName", _dataRecorded["LastName"], Util._valueTextDefault) :  Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-firstnameen-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "FirstNameEN", _dataRecorded["FirstNameEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-middlenameen-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "MiddleNameEN", _dataRecorded["MiddleNameEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-lastnameen-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "LastNameEN", _dataRecorded["LastNameEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gender-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Gender", _dataRecorded["Gender"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-birthdate-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "BirthDateEN", _dataRecorded["BirthDateEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-age-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Age", _dataRecorded["Age"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-birthplace-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Country", _dataRecorded["Country"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-nationality-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Nationality", _dataRecorded["Nationality"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-race-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Race", _dataRecorded["Race"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-religion-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Religion", _dataRecorded["Religion"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-bloodgroup-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "BloodGroup", _dataRecorded["BloodGroup"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-maritalstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "MaritalStatus", _dataRecorded["MaritalStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-educationalbackgroundperson-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EducationalBackgroundPerson", _dataRecorded["EducationalBackgroundPerson"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-email-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EmailAddress", _dataRecorded["EmailAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-brotherhood-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Brotherhood", _dataRecorded["Brotherhood"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-childhood-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Childhood", _dataRecorded["Childhood"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studyhood-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Studyhood", _dataRecorded["Studyhood"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }
           
            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[22];
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE, _id);
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                int _i = 0;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>เลขประจำตัวประชาชนหรือเลขหนังสือเดินทาง</div><div class='en-label'>Identification Number or Passport No.</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendLine("   <div class='form-inputcol'>");
                _contentTemp.AppendFormat("     <input class='inputbox' type='text' id='{0}-idcard' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <div class='form-input-discription'>");
                _contentTemp.AppendLine("           <div class='th-label'>เฉพาะตัวอักษรภาษาอังกฤษหรือตัวเลขเท่านั้น</div><div class='en-label'>English only or numbers</div>");      
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                _contentTemp.AppendLine("<div class='form-subcontent form-inputlist'>");
                _contentTemp.AppendLine("   <div class='form-inputlist-input'>");
                _contentTemp.AppendLine("       <div class='contentbody-left'>");
                _contentTemp.AppendLine("           <div class='form-labelcol'><div class='th-label'>วันออกบัตร</div><div class='en-label'>Date of Issue</div></div>");
                _contentTemp.AppendFormat("         <div class='form-inputcol'><input class='inputcalendar' type='text' id='{0}-idcardissuedate' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='contentbody-left'>");
                _contentTemp.AppendLine("           <div class='form-labelcol'><div class='th-label'>วันหมดอายุ</div><div class='en-label'>Date of Expiry</div></div>");
                _contentTemp.AppendFormat("         <div class='form-inputcol'><input class='inputcalendar' type='text' id='{0}-idcardexpirydate' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-idcard"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "บัตรประจำตัวประชาชนหรือหนังสือเดินทาง");
                _contentFrmColumnDetail[_i].Add("TitleEN", "ID Card or Passport");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("IDCard", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-titleprefix"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "คำนำหน้า");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Title");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-titleprefix-combobox'>" + ePFUI.GetComboboxTitlePrefix(_idSectionAddUpdate + "-titleprefix", "") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("TitlePrefix", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-firstname"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "First Name");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-firstname' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("FirstName", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-middlename"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อกลาง");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Middle Name");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-middlename' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("MiddleName", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-lastname"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "นามสกุล");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Last Name");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-lastname' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("LastName", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-firstnameen"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อ ( ภาษาอังกฤษเท่านั้น )");
                _contentFrmColumnDetail[_i].Add("TitleEN", "First Name ( English Only )");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-firstnameen' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("FirstNameEN", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-middlenameen"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อกลาง ( ภาษาอังกฤษเท่านั้น )");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Middle Name ( English Only )");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-middlenameen' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("MiddleNameEN", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-lastnameen"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "นามสกุล ( ภาษาอังกฤษเท่านั้น )");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Last Name ( English Only )");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-lastnameen' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("LastNameEN", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                _paramSearch.Clear();
                _paramSearch.Add("CancelledStatus", "N");

                _ds = Util.DBUtil.GetListGender(_paramSearch);

                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-gender' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["genderFullNameTH"].ToString(), _dr["genderFullNameEN"].ToString());
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _ds.Dispose();

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-gender"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เพศ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Gender");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Gender", _contentFrmColumnDetail[_i]);
                _i++;               
                   
                _contentTemp.Clear();
                _contentTemp.AppendFormat(" <input class='inputcalendar' type='text' id='{0}-birthdate' readonly value='' />", _idSectionAddUpdate);
                _contentTemp.AppendLine("   <span class='th-label'> อายุ</span>");
                _contentTemp.AppendLine("   <span class='en-label'> : Age</span>");
                _contentTemp.AppendFormat(" <span class='th-label age' id='{0}-age'></span>", _idSectionAddUpdate);
                _contentTemp.AppendLine("   <span class='th-label'>ปี</span>");
                _contentTemp.AppendLine("   <span class='en-label'> : yr</span>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-birthdate"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "วันเดือนปีเกิด");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Date of Birth");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Birthdate", _contentFrmColumnDetail[_i]);
                _i++;                
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-birthplace"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศบ้านเกิด");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Country of Birthplace");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-birthplace-combobox'>" + ePFUI.GetComboboxCountry(_idSectionAddUpdate + "-birthplace") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Birthplace", _contentFrmColumnDetail[_i]);
                _i++;
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-nationality"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "สัญชาติ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Nationality");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-nationality-combobox'>" + ePFUI.GetComboboxNationality(_idSectionAddUpdate + "-nationality") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Nationality", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-race"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เชื้อชาติ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Race");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-race-combobox'>" + ePFUI.GetComboboxNationality(_idSectionAddUpdate + "-race") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Race", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-religion"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ศาสนา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Religion");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-religion-combobox'>" + ePFUI.GetComboboxReligion(_idSectionAddUpdate + "-religion") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Religion", _contentFrmColumnDetail[_i]);
                _i++;                

                _contentTemp.Clear();

                _paramSearch.Clear();
                _paramSearch.Add("CancelledStatus", "N");

                _ds = Util.DBUtil.GetListBloodGroup(_paramSearch);

                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-bloodgroup' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["bloodTypeNameTH"].ToString(), _dr["bloodTypeNameEN"].ToString());
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _ds.Dispose();

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-bloodgroup"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "กรุ๊ปเลือด");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Blood Group");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("BloodGroup", _contentFrmColumnDetail[_i]);
                _i++;                

                _contentTemp.Clear();

                _paramSearch.Clear();
                _paramSearch.Add("CancelledStatus", "N");

                _ds = Util.DBUtil.GetListMaritalStatus(_paramSearch);

                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-maritalstatus' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["maritalStatusNameTH"].ToString(), _dr["maritalStatusNameEN"].ToString());
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _ds.Dispose();                
              
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-maritalstatus"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "สถานภาพทางการสมรส");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Marital Status");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("MaritalStatus", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                _paramSearch.Clear();
                _paramSearch.Add("CancelledStatus", "N");

                _ds = Util.DBUtil.GetListEducationalBackground(_paramSearch);

                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-educationalbackgroundperson' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["educationalBackgroundNameTH"].ToString(), _dr["educationalBackgroundNameEN"].ToString());
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _ds.Dispose();

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-educationalbackgroundperson"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "วุฒิการศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Educational Background");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("EducationalBackgroundPerson", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-email"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "อีเมล์");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Email Address");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-email' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("EmailAddress", _contentFrmColumnDetail[_i]);
                _i++;                
                          
                _contentTemp.Clear();
                //_contentTemp.AppendFormat(" <input class='inputbox textbox-numeric' type='text' id='{0}-brotherhood' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendFormat(" <div id='{0}-brotherhood-combobox'>{1}</div>", _idSectionAddUpdate, ePFUI.GetComboboxOrder((_idSectionAddUpdate + "-brotherhood"), ePFUtil._ranking));
                _contentTemp.AppendLine("   <span class='th-label'> คน</span>");
                _contentTemp.AppendLine("   <span class='en-label'> : people</span>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-brotherhood"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "จำนวนพี่น้องทั้งหมด ( รวมตัวเอง )");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Number of Siblings ( including myself )");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Brotherhood", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                //_contentTemp.AppendFormat(" <input class='inputbox textbox-numeric' type='text' id='{0}-childhood' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendFormat("<div id='{0}-childhood-combobox'>{1}</div>", _idSectionAddUpdate, ePFUI.GetComboboxOrder((_idSectionAddUpdate + "-childhood"), ePFUtil._ranking));

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-childhood"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "นักศึกษาเป็นบุตรคนที่");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Sequence Child");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", "ต้องไม่เกินจำนวนพี่น้องทั้งหมด ( รวมตัวเอง )");
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", "Must not exceed the number of siblings ( including myself )");
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Childhood", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                //_contentTemp.AppendFormat(" <input class='inputbox textbox-numeric' type='text' id='{0}-studyhood' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendFormat(" <div id='{0}-studyhood-combobox'>{1}</div>", _idSectionAddUpdate, ePFUI.GetComboboxOrder((_idSectionAddUpdate + "-studyhood"), ePFUtil._ranking));
                _contentTemp.AppendLine("   <span class='th-label'> คน</span>");
                _contentTemp.AppendLine("   <span class='en-label'> : people</span>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-studyhood"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "จำนวนพี่น้องที่กำลังศึกษาอยู่ ( รวมตัวเอง )");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Number of Siblings Still Studying ( including myself )");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", "ต้องไม่เกินจำนวนพี่น้องทั้งหมด ( รวมตัวเอง )");
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", "Must not exceed the number of siblings ( including myself )");
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Studyhood", _contentFrmColumnDetail[_i]);
                _i++;
               
                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["IDCard"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["TitlePrefix"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["FirstName"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["MiddleName"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["LastName"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["FirstNameEN"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["MiddleNameEN"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["LastNameEN"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Gender"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Birthdate"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Birthplace"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Nationality"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Race"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Religion"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["BloodGroup"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["MaritalStatus"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["EducationalBackgroundPerson"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["EmailAddress"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Brotherhood"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Childhood"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Studyhood"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class AddressUI
        {
            private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSADDRESS_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (_valueDataRecorded != null ? (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSADDRESS] : null);
                string _idSection = String.Empty;

                _idSection = PermanentAddressUI._idSectionAddUpdate;

                _html.AppendFormat("<input type='hidden' id='{0}-country-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "CountryPermanentAddress", _dataRecorded["CountryPermanentAddress"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-province-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ProvincePermanentAddress", _dataRecorded["ProvincePermanentAddress"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-district-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "DistrictPermanentAddress", _dataRecorded["DistrictPermanentAddress"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-postalcodedistrict-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PostalCodeDistrictPermanentAddress", _dataRecorded["PostalCodeDistrictPermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-subdistrict-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SubDistrictPermanentAddress", _dataRecorded["SubDistrictPermanentAddress"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-postalcode-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PostalCodePermanentAddress", _dataRecorded["PostalCodePermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-village-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "VillagePermanentAddress", _dataRecorded["VillagePermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-addressnumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "AddressNumberPermanentAddress", _dataRecorded["AddressNumberPermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-villageno-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "VillageNoPermanentAddress", _dataRecorded["VillageNoPermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-lanealley-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "LaneAlleyPermanentAddress", _dataRecorded["LaneAlleyPermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-road-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "RoadPermanentAddress", _dataRecorded["RoadPermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-phonenumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PhoneNumberPermanentAddress", _dataRecorded["PhoneNumberPermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-mobilenumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "MobileNumberPermanentAddress", _dataRecorded["MobileNumberPermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-faxnumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "FaxNumberPermanentAddress", _dataRecorded["FaxNumberPermanentAddress"], Util._valueTextDefault) : Util._valueTextDefault));

                _idSection = CurrentAddressUI._idSectionAddUpdate;

                _html.AppendFormat("<input type='hidden' id='{0}-country-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "CountryCurrentAddress", _dataRecorded["CountryCurrentAddress"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-province-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ProvinceCurrentAddress", _dataRecorded["ProvinceCurrentAddress"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-district-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "DistrictCurrentAddress", _dataRecorded["DistrictCurrentAddress"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-postalcodedistrict-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PostalCodeDistrictCurrentAddress", _dataRecorded["PostalCodeDistrictCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-subdistrict-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SubDistrictCurrentAddress", _dataRecorded["SubDistrictCurrentAddress"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-postalcode-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PostalCodeCurrentAddress", _dataRecorded["PostalCodeCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-village-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "VillageCurrentAddress", _dataRecorded["VillageCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-addressnumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "AddressNumberCurrentAddress", _dataRecorded["AddressNumberCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-villageno-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "VillageNoCurrentAddress", _dataRecorded["VillageNoCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-lanealley-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "LaneAlleyCurrentAddress", _dataRecorded["LaneAlleyCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-road-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "RoadCurrentAddress", _dataRecorded["RoadCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-phonenumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "PhoneNumberCurrentAddress", _dataRecorded["PhoneNumberCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-mobilenumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "MobileNumberCurrentAddress", _dataRecorded["MobileNumberCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-faxnumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "FaxNumberCurrentAddress", _dataRecorded["FaxNumberCurrentAddress"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSADDRESS_ADDUPDATE, _id);
                int _i = 0;

                _html.AppendFormat("<div class='sticky tabbar' id='{0}-menu'>", _idSectionAddUpdate);
                _html.AppendFormat("    <div class='tabbar-layout'>", _idSectionAddUpdate);
                _html.AppendFormat("        <div class='tabbar-content' id='{0}-menu-content'>", _idSectionAddUpdate);
                _html.AppendLine("              <ul>");

                for (_i = 7; _i <= 8; _i++)
                {
                    _html.AppendFormat("            <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (ePFStudentRecordsUtil._menuRecords[_i, 2].Equals("active") ? "tab-active" : String.Empty),
                        ePFStudentRecordsUtil._menuRecords[_i, 3].ToLower(),
                        ePFStudentRecordsUtil._menuRecords[_i, 0],
                        ePFStudentRecordsUtil._menuRecords[_i, 1]
                    );
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine(   GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div id='{0}'>", _idSectionAddUpdate);
                _html.AppendFormat("    <div id='{0}-layout'>", _idSectionAddUpdate);
                _html.AppendFormat("        <div id='{0}-content'>", _idSectionAddUpdate);            
                _html.AppendFormat("            <div class='tab-active' id='{0}' alt='{1}'>{2}</div>",    ePFStudentRecordsUtil._menuRecords[7, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[7, 4], PermanentAddressUI.GetMain());
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>",  ePFStudentRecordsUtil._menuRecords[8, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[8, 4], String.Empty);
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }

            public class PermanentAddressUI
            {
                public static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE.ToLower();
                            
                public static StringBuilder GetMain()
                {
                    return GetFrmAddress(ePFUtil.PAGE_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE);
                }
            }

            public class CurrentAddressUI
            {
                public static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE.ToLower();

                public static StringBuilder GetMain()
                {
                    return GetFrmAddress(ePFUtil.PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE);
                }
            }

            public static StringBuilder GetFrmAddress(string _page)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[15];
                string _idSection = String.Empty;
                int _i = 0;

                if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE))
                    _idSection = PermanentAddressUI._idSectionAddUpdate;

                if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE))
                    _idSection = CurrentAddressUI._idSectionAddUpdate;

                if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE))
                {
                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-copy'>COPY</div></li>");
                    _contentTemp.AppendLine("           </ul>");
                    _contentTemp.AppendLine("       </div>");
                    _contentTemp.AppendLine("   </div>");
                    _contentTemp.AppendLine("</div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-copyaddress"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ใช้ที่อยู่เดียวกับที่อยู่ตามทะเบียนบ้าน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Same As the Permanent Address");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("SameAsPermanentAddress", _contentFrmColumnDetail[_i]);
                    _i++;
                }
                
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-country"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Country");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-country-combobox'>" + ePFUI.GetComboboxCountry(_idSection + "-country") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Country", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-province"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "จังหวัด");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Province");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-province-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Province", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-district"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "อำเภอ / เขต");
                _contentFrmColumnDetail[_i].Add("TitleEN", "District / Area");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-district-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("District", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-subdistrict"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ตำบล / แขวง");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Sub-district / Sub-area");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-subdistrict-combobox'></div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("SubDistrict", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-postalcode"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "รหัสไปรษณีย์");
                _contentFrmColumnDetail[_i].Add("TitleEN", "ZIP / Postal Code");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-postalcode' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("PostalCode", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-village"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "หมู่บ้าน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Village");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-village' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Village", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-addressnumber"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "บ้านเลขที่");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Address Number");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-addressnumber' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("AddressNumber", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-villageno"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "หมู่ที่");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Village No.");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-villageno' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("VillageNo", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-lanealley"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ตรอก / ซอย");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Lane / Alley");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-lanealley' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("LaneAlley", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-road"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ถนน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Road");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-road' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Road", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-phonenumber"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เบอร์โทรศัพท์บ้าน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Phone Number");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-phonenumber' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("PhoneNumber", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-mobilenumber"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เบอร์โทรศัพท์มือถือ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Mobile Number");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-mobilenumber' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("MobileNumber", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-faxnumber"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เบอร์แฟกซ์");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Fax Number");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-faxnumber' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("FaxNumber", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
                _contentTemp.AppendLine("               <li><div class='click-button en-label button-undo'>CLEAR</div></li>");
                _contentTemp.AppendLine("           </ul>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-save"));
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

                _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSection);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");

                if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE))
                    _html.AppendLine(           ePFUI.GetFrmColumn(_contentFrmColumn["SameAsPermanentAddress"]).ToString());

                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Country"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Province"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["District"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["SubDistrict"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["PostalCode"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Village"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["AddressNumber"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["VillageNo"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["LaneAlley"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Road"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["PhoneNumber"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["MobileNumber"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["FaxNumber"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());                
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class EducationUI
        {
            private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATION_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSEDUCATION];
                string _idSection = String.Empty;

                _idSection = PrimarySchoolUI._idSectionAddUpdate;

                _html.AppendFormat("<input type='hidden' id='{0}-institutename-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteNamePrimarySchool", _dataRecorded["InstituteNamePrimarySchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-institutecountry-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteCountryPrimarySchool", _dataRecorded["InstituteCountryPrimarySchool"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-instituteprovince-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteProvincePrimarySchool", _dataRecorded["InstituteProvincePrimarySchool"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-yearattended-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "YearAttendedPrimarySchool", _dataRecorded["YearAttendedPrimarySchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-yeargraduate-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "YearGraduatePrimarySchool", _dataRecorded["YearGraduatePrimarySchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gpa-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GPAPrimarySchool", _dataRecorded["GPAPrimarySchool"], Util._valueTextDefault) : Util._valueTextDefault));

                _idSection = JuniorHighSchoolUI._idSectionAddUpdate;

                _html.AppendFormat("<input type='hidden' id='{0}-institutename-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteNameJuniorHighSchool", _dataRecorded["InstituteNameJuniorHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-institutecountry-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteCountryJuniorHighSchool", _dataRecorded["InstituteCountryJuniorHighSchool"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-instituteprovince-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteProvinceJuniorHighSchool", _dataRecorded["InstituteProvinceJuniorHighSchool"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-yearattended-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "YearAttendedJuniorHighSchool", _dataRecorded["YearAttendedJuniorHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-yeargraduate-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "YearGraduateJuniorHighSchool", _dataRecorded["YearGraduateJuniorHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gpa-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GPAJuniorHighSchool", _dataRecorded["GPAJuniorHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));

                _idSection = HighSchoolUI._idSectionAddUpdate;

                _html.AppendFormat("<input type='hidden' id='{0}-institutename-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteNameHighSchool", _dataRecorded["InstituteNameHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-institutecountry-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteCountryHighSchool", _dataRecorded["InstituteCountryHighSchool"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-instituteprovince-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "InstituteProvinceHighSchool", _dataRecorded["InstituteProvinceHighSchool"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentid-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentIdHighSchool", _dataRecorded["StudentIdHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-educationalmajor-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EducationalMajorHighSchool", _dataRecorded["EducationalMajorHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-educationalmajorother-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EducationalMajorOtherHighSchool", _dataRecorded["EducationalMajorOtherHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-yearattended-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "YearAttendedHighSchool", _dataRecorded["YearAttendedHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-yeargraduate-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "YearGraduateHighSchool", _dataRecorded["YearGraduateHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gpa-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GPAHighSchool", _dataRecorded["GPAHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-educationalbackground-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EducationalBackgroundHighSchool", _dataRecorded["EducationalBackgroundHighSchool"], Util._valueTextDefault) : Util._valueTextDefault));

                _idSection = UniversityUI._idSectionAddUpdate;              

                _html.AppendFormat("<input type='hidden' id='{0}-educationalbackground-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EducationalBackground", _dataRecorded["EducationalBackground"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-graduateby-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GraduateBy", _dataRecorded["GraduateBy"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-graduatebyinstitutename-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GraduateByInstituteName", _dataRecorded["GraduateByInstituteName"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-entrancetime-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EntranceTime", _dataRecorded["EntranceTime"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentis-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentIs", _dataRecorded["StudentIs"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentisuniversity-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentIsUniversity", _dataRecorded["StudentIsUniversity"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentisfaculty-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentIsFaculty", _dataRecorded["StudentIsFaculty"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-studentisprogram-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "StudentIsProgram",_dataRecorded["StudentIsProgram"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-entrancetype-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "EntranceType",  _dataRecorded["EntranceType"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-admissionranking-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "AdmissionRanking", _dataRecorded["AdmissionRanking"], Util._valueTextDefault) : Util._valueTextDefault));

                _idSection = AdmissionScoresUI._idSectionAddUpdate;

                _html.AppendFormat("<input type='hidden' id='{0}-scoresonetthai-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresONETThai", _dataRecorded["ScoresONETThai"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresonetsocialscience-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresONETSocialScience", _dataRecorded["ScoresONETSocialScience"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresonetenglish-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresONETEnglish", _dataRecorded["ScoresONETEnglish"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresonetmathematics-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresONETMathematics", _dataRecorded["ScoresONETMathematics"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresonetscience-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresONETScience", _dataRecorded["ScoresONETScience"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresonethealthphysical-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresONETHealthPhysical", _dataRecorded["ScoresONETHealthPhysical"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresonetarts-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresONETArts", _dataRecorded["ScoresONETArts"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresonetoccupationtechnology-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresONETOccupationTechnology", _dataRecorded["ScoresONETOccupationTechnology"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresanetthai2-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresANETThai2", _dataRecorded["ScoresANETThai2"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresanetsocialscience2-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresANETSocialScience2", _dataRecorded["ScoresANETSocialScience2"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresanetenglish3-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresANETEnglish3", _dataRecorded["ScoresANETEnglish3"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresanetmathematics2-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresANETMathematics2", _dataRecorded["ScoresANETMathematics2"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresanetscience2-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresANETScience2", _dataRecorded["ScoresANETScience2"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scoresgatgenaralaptitudetest-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresGATGenaralAptitudeTest", _dataRecorded["ScoresGATGenaralAptitudeTest"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat1-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT1", _dataRecorded["ScoresPAT1"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat2-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT2", _dataRecorded["ScoresPAT2"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat3-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT3", _dataRecorded["ScoresPAT3"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat4-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT4", _dataRecorded["ScoresPAT4"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat5-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT5", _dataRecorded["ScoresPAT5"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat6-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT6", _dataRecorded["ScoresPAT6"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat7-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT7", _dataRecorded["ScoresPAT7"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat8-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT8", _dataRecorded["ScoresPAT8"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat9-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT9", _dataRecorded["ScoresPAT9"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat10-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT10", _dataRecorded["ScoresPAT10"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat11-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT11", _dataRecorded["ScoresPAT11"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scorespat12-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScoresPAT12", _dataRecorded["ScoresPAT12"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSEDUCATION_ADDUPDATE, _id);
                int _i = 0;

                _html.AppendFormat("<div class='sticky tabbar' id='{0}-menu'>", _idSectionAddUpdate);
                _html.AppendFormat("    <div class='tabbar-layout'>", _idSectionAddUpdate);
                _html.AppendFormat("        <div class='tabbar-content' id='{0}-menu-content'>", _idSectionAddUpdate);
                _html.AppendLine("              <ul>");

                for (_i = 11; _i <= 13; _i++)
                {
                    _html.AppendFormat("            <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (ePFStudentRecordsUtil._menuRecords[_i, 2].Equals("active") ? "tab-active" : String.Empty),
                        ePFStudentRecordsUtil._menuRecords[_i, 3].ToLower(),
                        ePFStudentRecordsUtil._menuRecords[_i, 0],
                        ePFStudentRecordsUtil._menuRecords[_i, 1]
                    );
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine(   GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div id='{0}'>", _idSectionAddUpdate);
                _html.AppendFormat("    <div id='{0}-layout'>", _idSectionAddUpdate);
                _html.AppendFormat("        <div id='{0}-content'>", _idSectionAddUpdate);            
                //_html.AppendFormat("          <div class='tab-active' id='{0}' alt='{1}'>{2}</div>",    ePFStudentRecordsUtil._menuRecords[9, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[9, 4], PrimarySchoolUI.GetMain());
                //_html.AppendFormat("          <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>",  ePFStudentRecordsUtil._menuRecords[10, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[10, 4], String.Empty);
                _html.AppendFormat("            <div class='tab-active' id='{0}' alt='{1}'>{2}</div>",    ePFStudentRecordsUtil._menuRecords[11, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[11, 4], HighSchoolUI.GetMain());
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>",  ePFStudentRecordsUtil._menuRecords[12, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[12, 4], String.Empty);
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>",  ePFStudentRecordsUtil._menuRecords[13, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[13, 4], String.Empty);
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }

            public class PrimarySchoolUI
            {
                public static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE.ToLower();

                public static StringBuilder GetMain()
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[7];
                    int _i = 0;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-institutename"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อสถานศึกษาระดับประถม");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Primary School Name");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-institutename' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteName", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-institutecountry"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Country");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-institutecountry-combobox'>" + ePFUI.GetComboboxCountry(_idSectionAddUpdate + "-institutecountry") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteCountry", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-instituteprovince"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "จังหวัด");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Province");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-instituteprovince-combobox'></div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteProvince", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yearattended"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ปีที่เข้าศึกษา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Year Attended");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-yearattended-combobox'>" + ePFUI.GetComboboxYear(_idSectionAddUpdate + "-yearattended") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yeargraduate"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ปีที่สำเร็จการศึกษา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Year Graduation");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-yeargraduate-combobox'>" + ePFUI.GetComboboxYear(_idSectionAddUpdate + "-yeargraduate") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("YearGraduate", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-gpa"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เกรดเฉลี่ยสะสม");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Grade Point Average ( GPA )");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox textbox-numeric' type='text' id='" + _idSectionAddUpdate + "-gpa' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("GPA", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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
                        
                    _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteName"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());                       
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["YearGraduate"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["GPA"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }
            }

            public class JuniorHighSchoolUI
            {
                public static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE.ToLower();

                public static StringBuilder GetMain()
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[7];
                    int _i = 0;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-institutename"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อสถานศึกษาระดับมัธยมต้น");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Junior High School Name");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-institutename' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteName", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-institutecountry"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Country");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-institutecountry-combobox'>" + ePFUI.GetComboboxCountry(_idSectionAddUpdate + "-institutecountry") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteCountry", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-instituteprovince"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "จังหวัด");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Province");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-instituteprovince-combobox'></div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteProvince", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yearattended"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ปีที่เข้าศึกษา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Year Attended");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-yearattended-combobox'>" + ePFUI.GetComboboxYear(_idSectionAddUpdate + "-yearattended") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yeargraduate"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ปีที่สำเร็จการศึกษา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Year Graduation");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-yeargraduate-combobox'>" + ePFUI.GetComboboxYear(_idSectionAddUpdate + "-yeargraduate") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("YearGraduate", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-gpa"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เกรดเฉลี่ยสะสม");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Grade Point Average ( GPA )");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox textbox-numeric' type='text' id='" + _idSectionAddUpdate + "-gpa' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("GPA", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                    _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteName"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());                       
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["YearGraduate"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["GPA"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }
            }

            public class HighSchoolUI
            {
                public static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE.ToLower();

                public static StringBuilder GetMain()
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[10];
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    DataSet _ds = new DataSet();
                    int _i = 0;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-institutename"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อสถานศึกษาระดับมัธยมปลาย");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "High School Name");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-institutename' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteName", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-institutecountry"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Country");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-institutecountry-combobox'>" + ePFUI.GetComboboxCountry(_idSectionAddUpdate + "-institutecountry") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteCountry", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-instituteprovince"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "จังหวัด");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Province");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-instituteprovince-combobox'></div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("InstituteProvince", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-studentid"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เลขประจำตัวนักเรียน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Students Identification Number");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-studentid' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("StudentId", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();

                    _paramSearch.Clear();
                    _paramSearch.Add("CancelledStatus", "N");

                    _ds = Util.DBUtil.GetListEducationalMajor(_paramSearch);

                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-educationalmajor' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["educationalMajorNameTH"].ToString(), _dr["educationalMajorNameEN"].ToString());
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _ds.Dispose();

                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-educationalmajor' value='0' /></li>", _idSectionAddUpdate);
                    _contentTemp.AppendLine("       <li class='radio-labelcol'><div class='th-label'>อื่น ๆ</div><div class='en-label'>Other</div></li>");
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                    _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                    _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-educationalmajorother' value='' /></div>", _idSectionAddUpdate);
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-educationalmajor"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "สายการเรียน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Major");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("EducationalMajor", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yearattended"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ปีที่เข้าศึกษา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Year Attended");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-yearattended-combobox'>" + ePFUI.GetComboboxYear(_idSectionAddUpdate + "-yearattended") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("YearAttended", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-yeargraduate"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ปีที่สำเร็จการศึกษา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Year Graduation");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-yeargraduate-combobox'>" + ePFUI.GetComboboxYear(_idSectionAddUpdate + "-yeargraduate") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("YearGraduate", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-gpa"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เกรดเฉลี่ยสะสม");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Grade Point Average ( GPA )");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox textbox-numeric' type='text' id='" + _idSectionAddUpdate + "-gpa' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("GPA", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();

                    _paramSearch.Clear();
                    _paramSearch.Add("DegreeLevel", "03, 04");
                    _paramSearch.Add("CancelledStatus", "N");

                    _ds = Util.DBUtil.GetListEducationalBackground(_paramSearch);

                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-educationalbackground' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["educationalBackgroundNameTH"].ToString(), _dr["educationalBackgroundNameEN"].ToString());
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _ds.Dispose();

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-educationalbackground"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "วุฒิการศึกษา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Educational Background");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("EducationalBackground", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                    _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteName"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["StudentId"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["EducationalMajor"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["YearAttended"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["YearGraduate"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["GPA"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["EducationalBackground"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");
                        
                    return _html;
                }
            }

            public class UniversityUI
            {
                public static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE.ToLower();

                public static StringBuilder GetMain()
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[7];
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    DataSet _ds = new DataSet();
                    int _i = 0;
                    int _j = 0;

                    _paramSearch.Clear();
                    _paramSearch.Add("DegreeLevel", "02, 03, 04, 05, 06");
                    _paramSearch.Add("CancelledStatus", "N");

                    _ds = Util.DBUtil.GetListEducationalBackground(_paramSearch);

                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-educationalbackground' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["educationalBackgroundNameTH"].ToString(), _dr["educationalBackgroundNameEN"].ToString());
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _ds.Dispose();

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-educationalbackground"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "วุฒิการศึกษาขั้นสูงสุดก่อนเข้าม.มหิดล");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "What was Your Highest Education Achieved Before;Enrolling to Mahidol University");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("EducationalBackground", _contentFrmColumnDetail[_i]);
                    _i++;
                        
                    _contentTemp.Clear();        

                    for (_j = 0; _j < ePFStudentRecordsUtil._graduateBy.GetLength(0); _j++)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-graduateby' value='{1}' /></li>", _idSectionAddUpdate, ePFStudentRecordsUtil._graduateBy[_j, 0]);
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFStudentRecordsUtil._graduateBy[_j, 1], ePFStudentRecordsUtil._graduateBy[_j, 2]);
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                    _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>สถานศึกษา</div><div class='en-label'>School Name</div></div>");
                    _contentTemp.AppendLine("   <div class='clear'></div>");
                    _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-graduatebyinstitutename' value='' /></div>", _idSectionAddUpdate);
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-graduateby"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "สำเร็จการศึกษาขั้นสูงสุดโดยวิธี");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "How was the Above Education Achieved");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("GraduateBy", _contentFrmColumnDetail[_i]);
                    _i++;
                        
                    _contentTemp.Clear();

                    for (_j = 0; _j < ePFStudentRecordsUtil._entranceTime.GetLength(0); _j++)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-entrancetime' value='{1}' /></li>", _idSectionAddUpdate, ePFStudentRecordsUtil._entranceTime[_j, 0]);
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFStudentRecordsUtil._entranceTime[_j, 1], ePFStudentRecordsUtil._entranceTime[_j, 2]);
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-entrancetime"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "จำนวนครั้งที่สอบเข้าในระดับมหาวิทยาลัย");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Number of Entrance Exams Taken");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("EntranceTime", _contentFrmColumnDetail[_i]);
                    _i++;
                        
                    _contentTemp.Clear();

                    for (_j = 0; _j < ePFStudentRecordsUtil._studentIs.GetLength(0); _j++)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-studentis' value='{1}' /></li>", _idSectionAddUpdate, ePFStudentRecordsUtil._studentIs[_j, 0]);
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFStudentRecordsUtil._studentIs[_j, 1], ePFStudentRecordsUtil._studentIs[_j, 2]);
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                    _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>มหาวิทยาลัย</div><div class='en-label'>University</div></div>");
                    _contentTemp.AppendLine("   <div class='clear'></div>");
                    _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-studentisuniversity' value='' /></div>", _idSectionAddUpdate);
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                    _contentTemp.AppendLine("<div class='form-subcontent'>");
                    _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>คณะ</div><div class='en-label'>Faculty</div></div>");
                    _contentTemp.AppendLine("   <div class='clear'></div>");
                    _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-studentisfaculty' value='' /></div>", _idSectionAddUpdate);
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                    _contentTemp.AppendLine("<div class='form-subcontent'>");
                    _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>หลักสูตร</div><div class='en-label'>Program</div></div>");
                    _contentTemp.AppendLine("   <div class='clear'></div>");
                    _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-studentisprogram' value='' /></div>", _idSectionAddUpdate);
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-studentis"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "การเข้าเป็นนักศึกษามหาวิทยาลัย");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Being a University Student");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("StudentIs", _contentFrmColumnDetail[_i]);
                    _i++;
                        
                    _contentTemp.Clear();

                    _paramSearch.Clear();
                    _paramSearch.Add("CancelledStatus", "N");

                    _ds = Util.DBUtil.GetListEntranceType(_paramSearch);

                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-entrancetype' value='{1}' /></li>", _idSectionAddUpdate, _dr["id"].ToString());
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["entranceTypeNameTH"].ToString(), _dr["entranceTypeNameEN"].ToString());
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _ds.Dispose();

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-entrancetype"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ระบบการสอบเข้า");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Entrance Examination System");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("EntranceType", _contentFrmColumnDetail[_i]);
                    _i++;
                        
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-admissionranking"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เลือก ม.มหิดลเป็นอันดับที่");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Rank Selected Mahidol University");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-admissionranking-combobox'>" + ePFUI.GetComboboxOrder((_idSectionAddUpdate + "-admissionranking"), ePFUtil._ranking) + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("AdmissionRanking", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                    _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["EducationalBackground"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["GraduateBy"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["EntranceTime"]).ToString());                       
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["StudentIs"]).ToString());                       
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["EntranceType"]).ToString());                       
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["AdmissionRanking"]).ToString());
                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }
            }

            public class AdmissionScoresUI
            {
                public static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE.ToLower();

                public static StringBuilder GetMain()
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[ePFStudentRecordsUtil._admissionScores.GetLength(0) + 1];
                    int _i = 0;

                    for (_i = 0; _i < ePFStudentRecordsUtil._admissionScores.GetLength(0); _i++)
                    {
                        _contentTemp.Clear();
                        _contentTemp.AppendLine("<div class='form-subcontent admissionscores'>");
                        _contentTemp.AppendFormat(" <div class='form-labelcol'><div><span class='en-label'>{0}&nbsp;</span><span class='th-label'>{1}</span></div><div><span class='en-label'>{0}&nbsp;</span><span class='en-label'>{2}</span></div></div>", ePFStudentRecordsUtil._admissionScores[_i, 0], ePFStudentRecordsUtil._admissionScores[_i, 1], ePFStudentRecordsUtil._admissionScores[_i, 2]);
                        _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox textbox-numeric' type='text' id='{0}-{1}' value='' /></div>", _idSectionAddUpdate, ePFStudentRecordsUtil._admissionScores[_i, 3].ToLower());
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");

                        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                        _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-" + ePFStudentRecordsUtil._admissionScores[_i, 3].ToLower()));
                        _contentFrmColumnDetail[_i].Add("HighLight", false);
                        _contentFrmColumnDetail[_i].Add("TitleTH", "คะแนนสอบ");
                        _contentFrmColumnDetail[_i].Add("TitleEN", "Scores");
                        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                        _contentFrmColumnDetail[_i].Add("Require", false);
                        _contentFrmColumnDetail[_i].Add("LastRow", false);
                        _contentFrmColumn.Add(ePFStudentRecordsUtil._admissionScores[_i, 3], _contentFrmColumnDetail[_i]);
                    }

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                    _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");

                    for (_i = 0; _i < ePFStudentRecordsUtil._admissionScores.GetLength(0); _i++)
                    {
                        _html.AppendLine(           ePFUI.GetFrmColumn(_contentFrmColumn[ePFStudentRecordsUtil._admissionScores[_i, 3]]).ToString());
                    }

                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }
            }
        }

        public class TalentUI
        {
            private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSTALENT_ADDUPDATE.ToLower();
                
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSTALENT];

                _html.AppendFormat("<input type='hidden' id='{0}-sportsmanstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SportsmanStatus", _dataRecorded["SportsmanStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-sportsmandetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SportsmanDetail", _dataRecorded["SportsmanDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialiststatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistStatus", _dataRecorded["SpecialistStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialistsportstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistSportStatus", _dataRecorded["SpecialistSportStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialistsportdetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistSportDetail", _dataRecorded["SpecialistSportDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialistartstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistArtStatus", _dataRecorded["SpecialistArtStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialistartdetail-hidden' value='{1}' />",  _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistArtDetail", _dataRecorded["SpecialistArtDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialisttechnicalstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistTechnicalStatus", _dataRecorded["SpecialistTechnicalStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialisttechnicaldetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistTechnicalDetail", _dataRecorded["SpecialistTechnicalDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialistotherstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistOtherStatus", _dataRecorded["SpecialistOtherStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-specialistotherdetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "SpecialistOtherDetail", _dataRecorded["SpecialistOtherDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-activitystatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ActivityStatus", _dataRecorded["ActivityStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-activitydetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ActivityDetail", _dataRecorded["ActivityDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-rewardstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "RewardStatus", _dataRecorded["RewardStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-rewarddetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "RewardDetail", _dataRecorded["RewardDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                    
                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[5];
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSTALENT_ADDUPDATE, _id);
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                int _i = 0;
                int _j = 0;
                    
                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynEverNever.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-sportsmanstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynEverNever[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynEverNever[_j, 1], ePFUtil._ynEverNever[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><textarea class='textareabox' id='{0}-sportsmandetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-sportsman"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เคยเป็นนักกีฬาหรือไม่");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Sportsman");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Sportsman", _contentFrmColumnDetail[_i]);
                _i++;
                    
                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynHaveWithout.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-specialiststatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynHaveWithout[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynHaveWithout[_j, 1], ePFUtil._ynHaveWithout[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }
                    
                _contentTemp.AppendFormat("<div class='form-subcontent first-child' id='{0}-specialistsport-content'>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <div class='form-labelcol'>");
                _contentTemp.AppendLine("           <div class='checkbox-content'>");
                _contentTemp.AppendLine("               <ul>");
                _contentTemp.AppendFormat("                 <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' id='{0}-specialistsportstatus' name='{0}-specialistsportstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynYesNo[1, 0]);
                _contentTemp.AppendLine("                   <li class='checkbox-labelcol'><div class='th-label'>กีฬา ( ฟุตบอล, เทนนิส, ฯลฯ )</div><div class='en-label'>Sports ( Soccer, Tennis, etc. )</div></li>");
                _contentTemp.AppendLine("               </ul>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("           <div class='clear'></div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendFormat("     <div class='form-inputcol'><textarea class='textareabox' id='{0}-specialistsportdetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("  </div>");
                _contentTemp.AppendLine("  <div class='clear'></div>");                    
                _contentTemp.AppendFormat("<div class='form-subcontent' id='{0}-specialistart-content'>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <div class='form-labelcol'>");
                _contentTemp.AppendLine("           <div class='checkbox-content'>");
                _contentTemp.AppendLine("               <ul>");
                _contentTemp.AppendFormat("                 <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' id='{0}-specialistartstatus' name='{0}-specialistartstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynYesNo[1, 0]);
                _contentTemp.AppendLine("                   <li class='checkbox-labelcol'><div class='th-label'>ศิลปะ ( ดนตรี, ขับร้อง, การแสดง, ฯลฯ )</div><div class='en-label'>Arts ( music, acting, etc. )</div></li>");
                _contentTemp.AppendLine("               </ul>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("           <div class='clear'></div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendFormat("     <div class='form-inputcol'><textarea class='textareabox' id='{0}-specialistartdetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("  </div>");
                _contentTemp.AppendLine("  <div class='clear'></div>");                    
                _contentTemp.AppendFormat("<div class='form-subcontent' id='{0}-specialisttechnical-content'>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <div class='form-labelcol'>");
                _contentTemp.AppendLine("           <div class='checkbox-content'>");
                _contentTemp.AppendLine("               <ul>");
                _contentTemp.AppendFormat("                 <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' id='{0}-specialisttechnicalstatus' name='{0}-specialisttechnicalstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynYesNo[1, 0]);
                _contentTemp.AppendLine("                   <li class='checkbox-labelcol'><div class='th-label'>วิชาการ ( วิทย์, ฟิสิกส์, ฯลฯ )</div><div class='en-label'>Academic ( Science, Physics, etc. )</div></li>");
                _contentTemp.AppendLine("               </ul>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("           <div class='clear'></div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendFormat("     <div class='form-inputcol'><textarea class='textareabox' id='{0}-specialisttechnicaldetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("  </div>");
                _contentTemp.AppendLine("  <div class='clear'></div>");                    
                _contentTemp.AppendFormat("<div class='form-subcontent' id='{0}-specialistother-content'>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <div class='form-labelcol'>");
                _contentTemp.AppendLine("           <div class='checkbox-content'>");
                _contentTemp.AppendLine("               <ul>");
                _contentTemp.AppendFormat("                 <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' id='{0}-specialistotherstatus' name='{0}-specialistotherstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynYesNo[1, 0]);
                _contentTemp.AppendLine("                   <li class='checkbox-labelcol'><div class='th-label'>อื่น ๆ</div><div class='en-label'>Others</div></li>");
                _contentTemp.AppendLine("               </ul>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("           <div class='clear'></div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendFormat("     <div class='form-inputcol'><textarea class='textareabox' id='{0}-specialistotherdetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("  </div>");
                _contentTemp.AppendLine("  <div class='clear'></div>");
                    
                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-specialist"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "มีความสามารถพิเศษหรือไม่");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Talent");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Specialist", _contentFrmColumnDetail[_i]);
                _i++;
                    
                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynEverNever.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-activitystatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynEverNever[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynEverNever[_j, 1], ePFUtil._ynEverNever[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><textarea class='textareabox' id='{0}-activitydetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-activity"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เคยร่วมกิจกรรมของโรงเรียนหรือไม่");
                _contentFrmColumnDetail[_i].Add("TitleEN", "School Activities Involvement");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Activity", _contentFrmColumnDetail[_i]);
                _i++;
                    
                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynEverNever.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-rewardstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynEverNever[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynEverNever[_j, 1], ePFUtil._ynEverNever[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><textarea class='textareabox' id='{0}-rewarddetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-reward"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "เคยได้รับทุน / รางวัลหรือไม่");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Awards");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Reward", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Sportsman"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Specialist"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Activity"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Reward"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class HealthyUI
        {
            private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSHEALTHY_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSHEALTHY];

                _html.AppendFormat("<input type='hidden' id='{0}-bodymassdetail' value='{1}' />", _idSectionAddUpdate, String.Empty);
                _html.AppendFormat("<input type='hidden' id='{0}-bodymassdetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "BodyMassDetail", _dataRecorded["BodyMassDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-intolerancestatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IntoleranceStatus", _dataRecorded["IntoleranceStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-intolerancedetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IntoleranceDetail", _dataRecorded["IntoleranceDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-diseasesstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "DiseasesStatus", _dataRecorded["DiseasesStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-diseasesdetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "DiseasesDetail", _dataRecorded["DiseasesDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-familyhistoryofillnessstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "AilHistoryFamilyStatus", _dataRecorded["AilHistoryFamilyStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-familyhistoryofillnessdetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "AilHistoryFamilyDetail", _dataRecorded["AilHistoryFamilyDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-travelabroadstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "TravelAbroadStatus", _dataRecorded["TravelAbroadStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-travelabroaddetail' value='{1}' />", _idSectionAddUpdate, String.Empty);
                _html.AppendFormat("<input type='hidden' id='{0}-travelabroaddetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "TravelAbroadDetail", _dataRecorded["TravelAbroadDetail"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-impairmentsstatus-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ImpairmentsStatus", _dataRecorded["ImpairmentsStatus"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-impairmentsdetail-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ImpairmentsDetail", _dataRecorded["ImpairmentsDetail"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-impairmentsequipment-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ImpairmentsEquipment", _dataRecorded["ImpairmentsEquipment"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-idcardpwd-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IdCardPWD", _dataRecorded["IdCardPWD"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-idcardpwdissuedate-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IdCardPWDIssueDateEN", _dataRecorded["IdCardPWDIssueDateEN"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-idcardpwdexpirydate-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "IdCardPWDExpiryDateEN", _dataRecorded["IdCardPWDExpiryDateEN"], Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[7];
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE, _id);
                Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                DataSet _ds = new DataSet();
                int _i = 0;
                int _j = 0;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='form-subcontent first-child form-inputlist'>");
                _contentTemp.AppendLine("   <div class='form-inputlist-input'>");
                _contentTemp.AppendLine("       <div class='contentbody-left'>");
                _contentTemp.AppendLine("           <div class='form-labelcol'><div class='th-label'>น้ำหนัก</div><div class='en-label'>Weight</div></div>");
                _contentTemp.AppendFormat("         <div class='form-inputcol'><input class='inputbox textbox-numeric' type='text' id='{0}-bodymassdetailweight' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='contentbody-left'>");
                _contentTemp.AppendLine("           <div class='form-labelcol'><div class='th-label'>ส่วนสูง</div><div class='en-label'>Height</div></div>");
                _contentTemp.AppendFormat("         <div class='form-inputcol'><input class='inputbox textbox-numeric' type='text' id='{0}-bodymassdetailheight' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='contentbody-left'>");
                _contentTemp.AppendLine("           <div class='form-labelcol'><div class='th-label'>ค่าดัชนีมวลกาย</div><div class='en-label'>BMI</div></div>");
                _contentTemp.AppendLine("           <div class='form-inputcol'>");
                _contentTemp.AppendFormat("             <div><input class='inputbox textbox-numeric' type='text' id='{0}-bodymassdetailbmi' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendFormat("             <div id='{0}-bodymassdetailcalcultebmi'></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("               <div class='button'>");
                _contentTemp.AppendLine("                   <div class='button-layout'>");
                _contentTemp.AppendLine("                       <div class='button-content'>");
                _contentTemp.AppendLine("                           <ul class='button-style2'>");
                _contentTemp.AppendLine("                               <li class='nomargin'><a class='click-button en-label button-calculate' href='javascript:void(0)'>CALCULATE</a></li>");
                _contentTemp.AppendLine("                           </ul>");
                _contentTemp.AppendLine("                       </div>");
                _contentTemp.AppendLine("                   </div>");
                _contentTemp.AppendLine("               </div>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='contentbody-left'>");
                _contentTemp.AppendLine("           <div class='form-labelcol'><div class='th-label'>ข้อมูล ณ วันที่</div><div class='en-label'>Latest Update</div></div>");
                _contentTemp.AppendFormat("         <div class='form-inputcol'><input class='inputcalendar' type='text' id='{0}-bodymassdetaildate' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='contentbody-left'>");
                _contentTemp.AppendLine("           <div class='link'>");
                _contentTemp.AppendLine("               <ul>");
                _contentTemp.AppendLine("                   <li><a class='click-button en-label button-add' id='add-bodymassdetail' href='javascript:void(0)'>ADD</a></li>");
                _contentTemp.AppendLine("               </ul>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendLine("   <div class='form-inputlist-list'></div>");
                _contentTemp.AppendLine("</div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-bodymassindex"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ดัชนีมวลกาย");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Body Mass Index");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", true);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("BodyMassIndex", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynHaveWithout.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-intolerancestatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynHaveWithout[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynHaveWithout[_j, 1], ePFUtil._ynHaveWithout[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><textarea class='textareabox' id='{0}-intolerancedetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-intolerance"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ประวัติการแพ้ยา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Drug Allergy History");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Intolerance", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynHaveWithout.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-diseasesstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynHaveWithout[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynHaveWithout[_j, 1], ePFUtil._ynHaveWithout[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><textarea class='textareabox' id='{0}-diseasesdetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-diseases"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "โรคประจำตัว");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Diseases");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Diseases", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynHaveWithout.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-familyhistoryofillnessstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynHaveWithout[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynHaveWithout[_j, 1], ePFUtil._ynHaveWithout[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendFormat("<div class='form-subcontent first-child' id='{0}-familyhistoryofillnessdetail-content'>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <div class='form-labelcol'><div class='th-label'>เลือกรายการด้านล่าง หรือพิมพ์ข้อความที่กล่องข้อความ</div><div class='en-label'>Choose from the list below or type a text box</div></div>");
                _contentTemp.AppendLine("       <div class='form-inputcol'>");
                _contentTemp.AppendLine("           <div class='list'>");
                _contentTemp.AppendLine("               <div class='list-layout'>");
                _contentTemp.AppendLine("                   <div class='list-content'>");

                _paramSearch.Clear();
                _paramSearch.Add("CancelledStatus", "N");
                    
                _ds = Util.DBUtil.GetListDiseases(_paramSearch);
                
                foreach (DataRow _dr in _ds.Tables[0].Rows)
                {
                    _contentTemp.AppendFormat("                 <div class='list-row' id='diseases-list-row{0}'>", _dr["id"].ToString());
                    _contentTemp.AppendFormat("                     <div class='list-col th-label'>{0} : {1}</div>", _dr["diseasesNameTH"].ToString(), _dr["diseasesNameEN"].ToString());
                    _contentTemp.AppendLine("                   </div>");
                }

                _ds.Dispose();

                _contentTemp.AppendLine("                   </div>");
                _contentTemp.AppendLine("               </div>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendFormat("         <div><textarea class='textareabox' id='{0}-familyhistoryofillnessdetail'></textarea></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("  </div>");
                _contentTemp.AppendLine("  <div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-familyhistoryofillness"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ประวัติการเจ็บป่วยในครอบครัว");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Family History of Illness");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("AilHistoryFamily", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynEverNever.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-travelabroadstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynEverNever[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynEverNever[_j, 1], ePFUtil._ynEverNever[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendFormat("<div class='form-subcontent first-child form-inputlist' id='{0}-travelabroaddetail-content'>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <div class='form-inputlist-input'>");
                _contentTemp.AppendLine("           <div class='contentbody-left'>");
                _contentTemp.AppendLine("               <div class='form-labelcol'><div class='th-label'>ประเทศ</div><div class='en-label'>Country</div></div>");
                _contentTemp.AppendFormat("             <div class='form-inputcol'><div id='{0}-travelabroaddetailcountry-combobox'>{1}</div></div>", _idSectionAddUpdate, ePFUI.GetComboboxCountry(_idSectionAddUpdate + "-travelabroaddetailcountry"));
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("           <div class='contentbody-left'>");
                _contentTemp.AppendLine("               <div class='form-labelcol'><div class='th-label'>วันที่เดินทาง</div><div class='en-label'>Date of Travel</div></div>");
                _contentTemp.AppendFormat("             <div class='form-inputcol'><input class='inputcalendar' type='text' id='{0}-travelabroaddetaildate' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("           <div class='contentbody-left'>");
                _contentTemp.AppendLine("               <div class='link'>");
                _contentTemp.AppendLine("                   <ul>");
                _contentTemp.AppendLine("                       <li><a class='click-button en-label button-add' id='add-travelabroaddetail' href='javascript:void(0)'>ADD</a></li>");
                _contentTemp.AppendLine("                   </ul>");
                _contentTemp.AppendLine("               </div>");
                _contentTemp.AppendLine("           </div>"); 
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendLine("       <div class='form-inputlist-list'></div>");
                _contentTemp.AppendLine("  </div>");        

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-travelabroad"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "การเดินทางไปต่างประเทศ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Travel Abroad");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("TravelAbroad", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynHaveWithout.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-impairmentsstatus' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynHaveWithout[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynHaveWithout[_j, 1], ePFUtil._ynHaveWithout[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendFormat("<div id='{0}-impairmentsdetail-content'>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("           <div class='form-labelcol'><div class='th-label'>มีความพิการทาง</div><div class='en-label'>Have a Disability</div></div>");
                _contentTemp.AppendLine("           <div class='clear'></div>");
                _contentTemp.AppendFormat("         <div class='form-inputcol'><div id='{0}-impairmentsdetail-combobox'>{1}</div></div>", _idSectionAddUpdate, ePFUI.GetComboboxImpairments(_idSectionAddUpdate + "-impairmentsdetail"));
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendLine("       <div class='form-subcontent'>");
                _contentTemp.AppendLine("           <div class='form-labelcol'><div class='th-label'>โดยมีอุปกรณ์ที่ใช้สำหรับช่วยเหลือ</div><div class='en-label'>The Equipment Used for Assistance</div></div>");
                _contentTemp.AppendLine("           <div class='clear'></div>");
                _contentTemp.AppendFormat("         <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-impairmentsequipment' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendFormat("     <div id='{0}-disability-content'>", _idSectionAddUpdate);
                _contentTemp.AppendLine("           <div class='form-subcontent'>");
                _contentTemp.AppendLine("               <div class='form-labelcol'><div class='th-label font-weight-bold'>บัตรประจำตัวคนพิการ</div><div class='en-label font-weight-bold'>ID Card for Person with Disabilities ( PWD )</div></div>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("           <div class='clear'></div>");
                _contentTemp.AppendLine("           <div class='form-subcontent'>");
                _contentTemp.AppendLine("               <div class='form-labelcol'><div class='th-label'>เลขประจำตัวคนพิการ</div><div class='en-label'>Identification Number</div></div>");
                _contentTemp.AppendLine("               <div class='clear'></div>");
                _contentTemp.AppendFormat("             <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-idcardpwd' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("           <div class='clear'></div>");
                _contentTemp.AppendLine("           <div class='form-subcontent form-inputlist'>");
                _contentTemp.AppendLine("               <div class='form-inputlist-input'>");
                _contentTemp.AppendLine("                   <div class='contentbody-left'>");
                _contentTemp.AppendLine("                       <div class='form-labelcol'><div class='th-label'>วันออกบัตร</div><div class='en-label'>Date of Issue</div></div>");
                _contentTemp.AppendFormat("                     <div class='form-inputcol'><input class='inputcalendar' type='text' id='{0}-idcardpwdissuedate' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("                   </div>");
                _contentTemp.AppendLine("                   <div class='contentbody-left'>");
                _contentTemp.AppendLine("                       <div class='form-labelcol'><div class='th-label'>วันหมดอายุ</div><div class='en-label'>Date of Expiry</div></div>");
                _contentTemp.AppendFormat("                     <div class='form-inputcol'><input class='inputcalendar' type='text' id='{0}-idcardpwdexpirydate' readonly value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("                   </div>");
                _contentTemp.AppendLine("               </div>");
                _contentTemp.AppendLine("               <div class='clear'></div>");
                _contentTemp.AppendLine("           </div>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("  </div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-impairments"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ความพิการ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Disability");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Impairments", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["BodyMassIndex"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Intolerance"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Diseases"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["AilHistoryFamily"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["TravelAbroad"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Impairments"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }

            public class BodyMassIndexUI
            {
                public static StringBuilder GetList(string _valueDataRecorded)
                {
                    StringBuilder _html = new StringBuilder();
                    DataTable _dt = ePFStudentRecordsUtil.HealthyUtil.BodyMassIndexUtil.SetValueDataRecorded(_valueDataRecorded);
                    StudentService _ss = new StudentService();
                    string _callFunc = String.Empty;        
                    string _weight = String.Empty;
                    string _height = String.Empty;
                    string _bmi = String.Empty;
                    string _date = String.Empty;
                    int _i = 0;
          
                    if (_dt != null)
                    {
                        if (_dt.Rows.Count > 0)
                        {
                            string[] _valueList = new string[_dt.Rows.Count];

                            foreach (DataRow _dr in _dt.Select(String.Empty, "4 DESC"))
                            {
                                _i++;

                                _weight = double.Parse(_dr["1"].ToString()).ToString("#,##0.00");                
                                _height = double.Parse(_dr["2"].ToString()).ToString("#,##0.00");
                                _bmi = _ss.CalBMI(_weight, _height).ToString("#,##0.00");                
                                _date = DateTime.Parse(_dr["4"].ToString()).ToString("dd/MM/yyyy");
                                _callFunc = "Util.tut.tsr.sectionAddUpdate.healthy.bodymassindex.setList({" +
                                            "   action:'delete'," + 
                                            "   row:" + _i +
                                            "})";
                
                                _html.AppendFormat("<div class='list-row' id='{0}-bodymassdetail-list-row{1}'>", _idSectionAddUpdate, _i);
                                _html.AppendFormat("    <div class='contentbody-left'><input type='hidden' value='{0}'><div class='th-label'>{0}</div></div>", _weight);
                                _html.AppendFormat("    <div class='contentbody-left'><input type='hidden' value='{0}'><div class='th-label'>{0}</div></div>", _height);
                                _html.AppendFormat("    <div class='contentbody-left'><input type='hidden' value='{0}'><div class='th-label'>{0}</div></div>", _bmi);
                                _html.AppendFormat("    <div class='contentbody-left'><input type='hidden' value='{0}'><div class='th-label'>{0}</div></div>", _date);
                                _html.AppendLine("      <div class='contentbody-left'>");
                                _html.AppendLine("          <div class='link'>");
                                _html.AppendLine("              <ul>");
                                _html.AppendFormat("                <li><a class='click-button en-label button-del' href='javascript:void(0)' onclick={0}>DELETE</a></li>", _callFunc);
                                _html.AppendLine("              </ul>");
                                _html.AppendLine("          </div>");
                                _html.AppendLine("      </div>");
                                _html.AppendLine("  </div>");
                                _html.AppendLine("  <div class='clear'></div>");                
                            }
                        }

                        _dt.Dispose();
                    }
          
                    return _html;
                }
            }

            public class TravelAbroadUI
            {
                public static StringBuilder GetList(string _valueDataRecorded)
                {
                    StringBuilder _html = new StringBuilder();
                    DataTable _dt = ePFStudentRecordsUtil.HealthyUtil.TravelAbroadUtil.SetValueDataRecorded(_valueDataRecorded);
                    string _callFunc = String.Empty;
                    string _country = String.Empty;        
                    string _date = String.Empty;
                    string[] _countryArray;
                    int _i = 0;
                        
                    if (_dt != null)
                    {
                        if (_dt.Rows.Count > 0)
                        {
                            foreach (DataRow _dr in _dt.Select(String.Empty, "2 DESC"))
                            {
                                _i++;

                                _country = _dr["1"].ToString();
                                _countryArray = _country.Split(':');
                                _date = DateTime.Parse(_dr["2"].ToString()).ToString("dd/MM/yyyy");
                                _callFunc = "Util.tut.tsr.sectionAddUpdate.healthy.travelabroad.setList({" +
                                            "   action:'delete'," +
                                            "   row:" + _i +
                                            "})";

                                _html.AppendFormat("<div class='list-row' id='{0}-travelabroaddetail-list-row{1}'>", _idSectionAddUpdate,  _i);
                                _html.AppendFormat("    <div class='contentbody-left'><input type='hidden' value='{0}'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></div>", _country, (_countryArray.GetLength(0) >= 1 ? _countryArray[0] : String.Empty), (_countryArray.GetLength(0).Equals(2) ? _countryArray[1] : String.Empty));
                                _html.AppendFormat("    <div class='contentbody-left'><input type='hidden' value='{0}'><div class='th-label'>{0}</div></div>", _date);
                                _html.AppendLine("      <div class='contentbody-left'>");
                                _html.AppendLine("          <div class='link'>");
                                _html.AppendLine("              <ul>");
                                _html.AppendFormat("                <li><a class='click-button en-label button-del' href='javascript:void(0)' onclick={0}>DELETE</a></li>", _callFunc);
                                _html.AppendLine("              </ul>");
                                _html.AppendLine("          </div>");
                                _html.AppendLine("      </div>");
                                _html.AppendLine("  </div>");
                                _html.AppendLine("  <div class='clear'></div>");
                            }
                        }

                        _dt.Dispose();
                    }

                    return _html;
                }
            }
        }

        public class WorkUI
        {
            private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSWORK_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSWORK];

                _html.AppendFormat("<input type='hidden' id='{0}-occupation-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Occupation", _dataRecorded["Occupation"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-agency-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Agency", _dataRecorded["Agency"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-agencyother-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "AgencyOther", _dataRecorded["AgencyOther"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-workplace-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Workplace", _dataRecorded["Workplace"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-workplaceposition-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Position", _dataRecorded["Position"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-workplacetelephone-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Telephone", _dataRecorded["Telephone"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-workplacesalary-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Salary", (!String.IsNullOrEmpty(_dataRecorded["Salary"].ToString()) ? double.Parse(_dataRecorded["Salary"].ToString()).ToString("#,##0.00") : _dataRecorded["Salary"]), Util._valueTextDefault) : Util._valueTextDefault));
   
                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[7];
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSWORK_ADDUPDATE, _id);
                int _i = 0;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-occupation"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "อาชีพ");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Occupation");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSectionAddUpdate + "-occupation-combobox'>" + ePFUI.GetComboboxOccupation(_idSectionAddUpdate + "-occupation") + "</div>"));
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Occupation", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div id='{0}-agency-combobox'>{1}</div>", _idSectionAddUpdate, ePFUI.GetComboboxAgency(_idSectionAddUpdate + "-agency"));
                _contentTemp.AppendLine("  <div class='agencyother'>");
                _contentTemp.AppendLine("       <div class='radio-content'>");
                _contentTemp.AppendLine("           <ul>");
                _contentTemp.AppendFormat("             <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-agencyother' value='0' /></li>", _idSectionAddUpdate);
                _contentTemp.AppendLine("               <li class='radio-labelcol'><div class='th-label'>อื่น ๆ</div><div class='en-label'>Other</div></li>");
                _contentTemp.AppendLine("           </ul>");
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendLine("       <div class='form-subcontent first-child'>");
                _contentTemp.AppendFormat("         <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-agencyotherdetail' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       </div>");
                _contentTemp.AppendLine("       <div class='clear'></div>");
                _contentTemp.AppendLine("  </div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-agency"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ต้นสังกัด");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Agency");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Agency", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-workplace"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "สถานที่ทำงาน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Workplace");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-workplace' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Workplace", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-workplaceposition"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ตำแหน่ง");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Position");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-workplaceposition' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Position", _contentFrmColumnDetail[_i]);
                _i++;

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-workplacetelephone"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "โทรศัพท์ที่ทำงาน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Workplace Telephone");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSectionAddUpdate + "-workplacetelephone' value='' />");
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Telephone", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<input class='inputbox textbox-numeric' type='text' id='{0}-workplacesalary' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendLine("  <span class='th-label'> บาท</span>");
                _contentTemp.AppendLine("  <span class='en-label'> : bath</span>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-workplacesalary"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "รายได้เฉลี่ยต่อเดือน");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Income");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("Salary", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Occupation"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Agency"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Workplace"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Position"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Telephone"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Salary"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class FinancialUI
        {
            private static string _idSectionAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFINANCIAL_ADDUPDATE.ToLower();

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSFINANCIAL];

                _html.AppendFormat("<input type='hidden' id='{0}-scholarshipfirstbachelor-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScholarshipFirstBachelor", _dataRecorded["ScholarshipFirstBachelor"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scholarshipfirstbachelorfrom-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScholarshipFirstBachelorFrom", _dataRecorded["ScholarshipFirstBachelorFrom"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scholarshipfirstbachelorname-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScholarshipFirstBachelorName", _dataRecorded["ScholarshipFirstBachelorName"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scholarshipfirstbachelormoney-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScholarshipFirstBachelorMoney", (!String.IsNullOrEmpty(_dataRecorded["ScholarshipFirstBachelorMoney"].ToString()) ? double.Parse(_dataRecorded["ScholarshipFirstBachelorMoney"].ToString()).ToString("#,##0.00") : _dataRecorded["ScholarshipFirstBachelorMoney"]), Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scholarshipbachelor-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScholarshipBachelor", _dataRecorded["ScholarshipBachelor"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scholarshipbachelorfrom-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScholarshipBachelorFrom", _dataRecorded["ScholarshipBachelorFrom"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scholarshipbachelorname-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScholarshipBachelorName", _dataRecorded["ScholarshipBachelorName"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-scholarshipbachelormoney-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "ScholarshipBachelorMoney", (!String.IsNullOrEmpty(_dataRecorded["ScholarshipBachelorMoney"].ToString()) ? double.Parse(_dataRecorded["ScholarshipBachelorMoney"].ToString()).ToString("#,##0.00") : _dataRecorded["ScholarshipBachelorMoney"]), Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-worked-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Worked", _dataRecorded["Worked"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-salary-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Salary", (!String.IsNullOrEmpty(_dataRecorded["Salary"].ToString()) ? double.Parse(_dataRecorded["Salary"].ToString()).ToString("#,##0.00") : _dataRecorded["Salary"]), Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-workplace-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Workplace", _dataRecorded["Workplace"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gotmoneyfrom-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GotMoneyFrom", _dataRecorded["GotMoneyFrom"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gotmoneyfromother-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GotMoneyFromOther", _dataRecorded["GotMoneyFromOther"], Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-gotmoneypermonth-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GotMoneyPerMonth", (!String.IsNullOrEmpty(_dataRecorded["GotMoneyPerMonth"].ToString()) ? double.Parse(_dataRecorded["GotMoneyPerMonth"].ToString()).ToString("#,##0.00") : _dataRecorded["GotMoneyPerMonth"]), Util._valueTextDefault) : Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-costpermonth-hidden' value='{1}' />", _idSectionAddUpdate, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "CostPerMonth", (!String.IsNullOrEmpty(_dataRecorded["CostPerMonth"].ToString()) ? double.Parse(_dataRecorded["CostPerMonth"].ToString()).ToString("#,##0.00") : _dataRecorded["CostPerMonth"]), Util._valueTextDefault) : Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[7];
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE, _id);
                int _i = 0;
                int _j = 0;

                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynEverNever.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-scholarshipfirstbachelor' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynEverNever[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynEverNever[_j, 1], ePFUtil._ynEverNever[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>ที่มาของทุนการศึกษา</div><div class='en-label'>Scholarship From</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><div id='{0}-scholarshipfirstbachelorfrom-combobox'>{1}</div></div>", _idSectionAddUpdate, ePFUI.GetComboboxScholarshipFrom(_idSectionAddUpdate + "-scholarshipfirstbachelorfrom"));
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                _contentTemp.AppendLine("<div class='form-subcontent'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>ชื่อของทุนการศึกษา</div><div class='en-label'>Scholarship Name</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-scholarshipfirstbachelorname' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                _contentTemp.AppendLine("<div class='form-subcontent'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>จำนวนเงิน</div><div class='en-label'>Amount</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendLine("   <div class='form-inputcol'>");
                _contentTemp.AppendFormat("     <input class='inputbox textbox-numeric' type='text' id='{0}-scholarshipfirstbachelormoney' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <span class='th-label'> บาท / ปี</span>");
                _contentTemp.AppendLine("       <span class='en-label'> : bath / yr</span>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-scholarshipfirstbachelor"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ทุนการศึกษาที่ได้รับก่อนศึกษาระดับป.ตรี");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Scholarship Prior Received to University Education");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ScholarshipFirstBachelor", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynEverNever.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-scholarshipbachelor' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynEverNever[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynEverNever[_j, 1], ePFUtil._ynEverNever[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>ที่มาของทุนการศึกษา</div><div class='en-label'>Scholarship From</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><div id='{0}-scholarshipbachelorfrom-combobox'>{1}</div></div>", _idSectionAddUpdate, ePFUI.GetComboboxScholarshipFrom(_idSectionAddUpdate + "-scholarshipbachelorfrom"));
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                _contentTemp.AppendLine("<div class='form-subcontent'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>ชื่อของทุนการศึกษา</div><div class='en-label'>Scholarship Name</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-scholarshipbachelorname' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                _contentTemp.AppendLine("<div class='form-subcontent'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>จำนวนเงิน</div><div class='en-label'>Amount</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendLine("   <div class='form-inputcol'>");
                _contentTemp.AppendFormat("     <input class='inputbox textbox-numeric' type='text' id='{0}-scholarshipbachelormoney' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <span class='th-label'> บาท / ปี</span>");
                _contentTemp.AppendLine("       <span class='en-label'> : bath / yr</span>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-scholarshipbachelor"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ทุนการศึกษาที่ได้รับระหว่างศึกษาระดับป.ตรี");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Scholarship During Received to Undergraduate");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("ScholarshipBachelor", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();

                for (_j = 0; _j < ePFUtil._ynYesNo.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-worked' value='{1}' /></li>", _idSectionAddUpdate, ePFUtil._ynYesNo[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFUtil._ynYesNo[_j, 1], ePFUtil._ynYesNo[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>มีรายได้ประมาณ</div><div class='en-label'>Income</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendLine("   <div class='form-inputcol'>");
                _contentTemp.AppendFormat("     <input class='inputbox textbox-numeric' type='text' id='{0}-salary' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <span class='th-label'> บาท / เดือน</span>");
                _contentTemp.AppendLine("       <span class='en-label'> : bath / month</span>");
                _contentTemp.AppendLine("   </div>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                _contentTemp.AppendLine("<div class='form-subcontent'>");
                _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'>สถานที่ทำงาน</div><div class='en-label'>Workplace</div></div>");
                _contentTemp.AppendLine("   <div class='clear'></div>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-workplace' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-worked"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ระหว่างศึกษานักศึกษาทำงานอยู่ใช่หรือไม่");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Work During Study");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Worked", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();        

                for (_j = 0; _j < ePFStudentRecordsUtil._financialSupportFrom.GetLength(0); _j++)
                {
                    _contentTemp.AppendLine("<div class='radio-content'>");
                    _contentTemp.AppendLine("   <ul>");
                    _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-gotmoneyfrom' value='{1}' /></li>", _idSectionAddUpdate, ePFStudentRecordsUtil._financialSupportFrom[_j, 0]);
                    _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFStudentRecordsUtil._financialSupportFrom[_j, 1], ePFStudentRecordsUtil._financialSupportFrom[_j, 2]);
                    _contentTemp.AppendLine("   </ul>");
                    _contentTemp.AppendLine("</div>");
                    _contentTemp.AppendLine("<div class='clear'></div>");
                }

                _contentTemp.AppendLine("<div class='radio-content'>");
                _contentTemp.AppendLine("   <ul>");
                _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-gotmoneyfrom' value='0' /></li>", _idSectionAddUpdate);
                _contentTemp.AppendLine("       <li class='radio-labelcol'><div class='th-label'>อื่น ๆ</div><div class='en-label'>Other</div></li>");
                _contentTemp.AppendLine("   </ul>");
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");
                _contentTemp.AppendLine("<div class='form-subcontent first-child'>");
                _contentTemp.AppendFormat(" <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-gotmoneyfromother' value='' /></div>", _idSectionAddUpdate);
                _contentTemp.AppendLine("</div>");
                _contentTemp.AppendLine("<div class='clear'></div>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-gotmoneyfrom"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ได้รับการอุปการะเงินค่าใช้จ่ายส่วนใหญ่จาก");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Financial Support From");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("GotMoneyFrom", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<input class='inputbox textbox-numeric' type='text' id='{0}-gotmoneypermonth' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendLine("  <span class='th-label'> บาท / เดือน</span>");
                _contentTemp.AppendLine("  <span class='en-label'> : bath / month</span>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-gotmoneypermonth"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ได้รับการอุปการะเงินค่าใช้จ่ายเดือนละเท่าไร");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Received Monthly Financial Support");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("GotMoneyPerMonth", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<input class='inputbox textbox-numeric' type='text' id='{0}-costpermonth' value='' />", _idSectionAddUpdate);
                _contentTemp.AppendLine("  <span class='th-label'> บาท / เดือน</span>");
                _contentTemp.AppendLine("  <span class='en-label'> : bath / month</span>");

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-costpermonth"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", "ค่าใช้จ่ายส่วนตัวไม่รวมค่าธรรมเนียมการศึกษา");
                _contentFrmColumnDetail[_i].Add("TitleEN", "Personal Expense Not Including Educational Fees");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", false);
                _contentFrmColumn.Add("CostPerMonth", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendLine("<div class='button'>");
                _contentTemp.AppendLine("   <div class='button-layout'>");
                _contentTemp.AppendLine("       <div class='button-content'>");
                _contentTemp.AppendLine("           <ul class='button-style1'>");
                _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
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

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSectionAddUpdate);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["ScholarshipFirstBachelor"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["ScholarshipBachelor"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Worked"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["GotMoneyFrom"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["GotMoneyPerMonth"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["CostPerMonth"]).ToString());
                _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }
        }

        public class FamilyUI
        {
            private static string _idSectionAddUpdate       = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILY_ADDUPDATE.ToLower();
            private static string _idSectionFatherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHER_ADDUPDATE.ToLower();
            private static string _idSectionMotherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHER_ADDUPDATE.ToLower();
            private static string _idSectionParentAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENT_ADDUPDATE.ToLower();

            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _valueDataRecorded = ePFUtil.SetValueDataRecorded(ePFUtil.PAGE_STUDENTRECORDSFAMILY_ADDUPDATE, _id);
                int _i = 0;

                _html.AppendFormat("<div class='sticky tabbar' id='{0}-menu'>", _idSectionAddUpdate);
                _html.AppendFormat("    <div class='tabbar-layout'>", _idSectionAddUpdate);
                _html.AppendFormat("        <div class='tabbar-content' id='{0}-menu-content'>", _idSectionAddUpdate);
                _html.AppendLine("              <ul>");

                for (_i = 14; _i <= 16; _i++)
                {
                    _html.AppendFormat("            <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (ePFStudentRecordsUtil._menuRecords[_i, 2].Equals("active") ? "tab-active" : String.Empty),
                        ePFStudentRecordsUtil._menuRecords[_i, 3].ToLower(),
                        ePFStudentRecordsUtil._menuRecords[_i, 0],
                        ePFStudentRecordsUtil._menuRecords[_i, 1]);
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendLine(   PersonalUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYFATHER).ToString());
                _html.AppendLine(   PersonalUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYMOTHER).ToString());
                _html.AppendLine(   PersonalUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYPARENT).ToString());
                _html.AppendLine(   AddressUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYFATHER).ToString());
                _html.AppendLine(   AddressUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYMOTHER).ToString());
                _html.AppendLine(   AddressUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYPARENT).ToString());
                _html.AppendLine(   WorkUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYFATHER).ToString());
                _html.AppendLine(   WorkUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYMOTHER).ToString());
                _html.AppendLine(   WorkUI.GetValueDataRecorded(_valueDataRecorded, ePFUtil.SUBJECT_FAMILYPARENT).ToString());
                _html.AppendFormat("<div id='{0}'>", _idSectionAddUpdate);
                _html.AppendFormat("    <div id='{0}-layout'>", _idSectionAddUpdate);
                _html.AppendFormat("        <div id='{0}-content'>", _idSectionAddUpdate);
                _html.AppendFormat("            <div class='tab-active' id='{0}' alt='{1}'>{2}</div>", ePFStudentRecordsUtil._menuRecords[14, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[14, 4], GetSubMain(ePFUtil.SUBJECT_FAMILYFATHER));
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>", ePFStudentRecordsUtil._menuRecords[15, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[15, 4], String.Empty);
                _html.AppendFormat("            <div class='tab-noactive' id='{0}' alt='{1}'>{2}</div>", ePFStudentRecordsUtil._menuRecords[16, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[16, 4], String.Empty);
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");

                return _html;
            }

            public static StringBuilder GetSubMain(string _familyRelation)
            {
                StringBuilder _html = new StringBuilder();
                string _idSection = String.Empty;
                int _i = 0;
                int _menu = 0;
                    
                _familyRelation = Util.UppercaseFirst(_familyRelation);
                _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, _idSectionFatherAddUpdate, _idSectionMotherAddUpdate, _idSectionParentAddUpdate);

                if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYFATHER))
                    _menu = 17;

                if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYMOTHER))
                    _menu = 18;

                if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                    _menu = 19;

                _html.AppendFormat("<div class='sticky tabbar subtabbar' id='{0}-menu'>", _idSection);
                _html.AppendFormat("    <div class='tabbar-layout'>", _idSection);
                _html.AppendFormat("        <div class='tabbar-content' id='{0}-menu-content'>", _idSection);
                _html.AppendLine("              <ul>");

                for (_i = _menu; _i <= (_menu + 9); _i += 3)
                {
                    _html.AppendFormat("            <li><a class='{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='tab-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (ePFStudentRecordsUtil._menuRecords[_i, 2].Equals("active") ? "subtab-active" : String.Empty),
                        ePFStudentRecordsUtil._menuRecords[_i, 3].ToLower(),
                        ePFStudentRecordsUtil._menuRecords[_i, 0],
                        ePFStudentRecordsUtil._menuRecords[_i, 1]);                        
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                _html.AppendFormat("<div id='{0}'>", _idSection);
                _html.AppendFormat("    <div id='{0}-layout'>", _idSection);
                _html.AppendFormat("        <div id='{0}-content'>", _idSection);
                _html.AppendFormat("            <div class='subtab-active' id='{0}' alt='{1}'>{2}</div>", ePFStudentRecordsUtil._menuRecords[_menu + 0, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[_menu + 0, 4], PersonalUI.GetMain(_familyRelation));
                _html.AppendFormat("            <div class='subtab-noactive' id='{0}' alt='{1}'>{2}</div>", ePFStudentRecordsUtil._menuRecords[_menu + 3, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[_menu + 3, 4], String.Empty);
                _html.AppendFormat("            <div class='subtab-noactive' id='{0}' alt='{1}'>{2}</div>", ePFStudentRecordsUtil._menuRecords[_menu + 6, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[_menu + 6, 4], String.Empty);
                _html.AppendFormat("            <div class='subtab-noactive' id='{0}' alt='{1}'>{2}</div>", ePFStudentRecordsUtil._menuRecords[_menu + 9, 3].ToLower(), ePFStudentRecordsUtil._menuRecords[_menu + 9, 4], String.Empty);
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
                    
                return _html;
            } 

            public class PersonalUI
            {
                private static string _idSectionFatherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE.ToLower();
                private static string _idSectionMotherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE.ToLower();
                private static string _idSectionParentAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE.ToLower();
                    
                public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded, string _familyRelation)
                {
                    StringBuilder _html = new StringBuilder();
                    Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSFAMILY];
                    string _idSection = String.Empty;

                    _familyRelation = Util.UppercaseFirst(_familyRelation);
                    _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, _idSectionFatherAddUpdate, _idSectionMotherAddUpdate, _idSectionParentAddUpdate);

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                    {
                        _html.AppendFormat("<input type='hidden' id='{0}-defaultpersonid-hidden' value='{1}' />", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE.ToLower(), (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("PersonId" + _familyRelation), _dataRecorded["PersonId" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-defaultrelationship-hidden' value='{1}' />", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE.ToLower(), (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Relationship", _dataRecorded["Relationship"], Util._valueTextDefault) : Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-defaultrelationship-hidden' value='{1}' />", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE.ToLower(), (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Relationship", _dataRecorded["Relationship"], Util._valueTextDefault) : Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-defaultrelationship-hidden' value='{1}' />", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE.ToLower(), (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Relationship", _dataRecorded["Relationship"], Util._valueTextDefault) : Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-defaultrelationship-hidden' value='{1}' />", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE.ToLower(), (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Relationship", _dataRecorded["Relationship"], Util._valueTextDefault) : Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-relationship-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "Relationship", _dataRecorded["Relationship"], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-relationshipnameen-hidden' value='{1}' />",  _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "RelationshipNameEN", _dataRecorded["RelationshipNameEN"], Util._valueTextDefault) : Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-relationshipnameth-hidden' value='{1}' />",  _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "RelationshipNameTH", _dataRecorded["RelationshipNameTH"], Util._valueTextDefault) : Util._valueTextDefault));
                        _html.AppendFormat("<input type='hidden' id='{0}-genderrelationship-hidden' value='{1}' />",  _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, "GenderRelationship", _dataRecorded["GenderRelationship"], Util._valueTextDefault) : Util._valueTextDefault));
                    }

                    _html.AppendFormat("<input type='hidden' id='{0}-personid-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("PersonId" + _familyRelation), _dataRecorded["PersonId" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-idcard-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("IdCard" + _familyRelation), _dataRecorded["IdCard" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-titleprefix-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("TitlePrefix" + _familyRelation), _dataRecorded["TitlePrefix" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-gendertitleprefix-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("GenderTitlePrefix" + _familyRelation), _dataRecorded["GenderTitlePrefix" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-firstname-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("FirstName" + _familyRelation), _dataRecorded["FirstName" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-middlename-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("MiddleName" + _familyRelation), _dataRecorded["MiddleName" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-lastname-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("LastName" + _familyRelation), _dataRecorded["LastName" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-firstnameen-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("FirstNameEN" + _familyRelation), _dataRecorded["FirstNameEN" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-middlenameen-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("MiddleNameEN" + _familyRelation), _dataRecorded["MiddleNameEN" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-lastnameen-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("LastNameEN" + _familyRelation), _dataRecorded["LastNameEN" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-gender-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Gender" + _familyRelation), _dataRecorded["Gender" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-alive-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Alive" + _familyRelation), _dataRecorded["Alive" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-birthdate-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("BirthDateEN" + _familyRelation), _dataRecorded["BirthDateEN" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-age-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Age" + _familyRelation), _dataRecorded["Age" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-birthplace-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Country" + _familyRelation), _dataRecorded["Country" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-nationality-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Nationality" + _familyRelation), _dataRecorded["Nationality" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-race-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Race" + _familyRelation), _dataRecorded["Race" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-religion-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Religion" + _familyRelation), _dataRecorded["Religion" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-bloodgroup-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("BloodGroup" + _familyRelation), _dataRecorded["BloodGroup" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-maritalstatus-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("MaritalStatus" + _familyRelation), _dataRecorded["MaritalStatus" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-educationalbackgroundperson-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("EducationalBackgroundPerson" + _familyRelation), _dataRecorded["EducationalBackgroundPerson" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                        
                    return _html;
                }

                public static StringBuilder GetMain(string _familyRelation)
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[20];
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    DataSet _ds = new DataSet();
                    string _idSection = String.Empty;
                    string _gender = String.Empty;
                    int _i = 0;
                    int _j = 0;
                    
                    _familyRelation = Util.UppercaseFirst(_familyRelation);
                    _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, _idSectionFatherAddUpdate, _idSectionMotherAddUpdate, _idSectionParentAddUpdate);
                    _gender = ePFStudentRecordsUtil.GetGenderByFamilyRelation(_familyRelation);

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                    {
                        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                        _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-relationship"));
                        _contentFrmColumnDetail[_i].Add("HighLight", false);
                        _contentFrmColumnDetail[_i].Add("TitleTH", "ความสัมพันธ์ของผู้ปกครอง");
                        _contentFrmColumnDetail[_i].Add("TitleEN", "Relationship of Parent");
                        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                        _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-relationship-combobox'>" + ePFUI.GetComboboxRelationship((_idSection + "-relationship"), "03, 04, 07, 09, 11, 12, 13, 14, 17, 18, 19, 20, 21, 22") + "</div>"));
                        _contentFrmColumnDetail[_i].Add("Require", true);
                        _contentFrmColumnDetail[_i].Add("LastRow", false);
                        _contentFrmColumn.Add("Relationship", _contentFrmColumnDetail[_i]);
                        _i++;
                    }
                        
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-idcard"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เลขประจำตัวประชาชน หรือ เลขหนังสือเดินทาง");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Identification Number or Passport No.");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", "เฉพาะตัวอักษรภาษาอังกฤษหรือตัวเลขเท่านั้น กรณีไม่ทราบข้อมูลให้ใส่ \"?\"");
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", "English only or numbers. If does not know please enter \"?\".");
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<input class='inputbox' type='text' id='" + _idSection + "-idcard' value='' />"));
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("IdCard", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-titleprefix"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "คำนำหน้า");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Title");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", "กรณีไม่ทราบข้อมูลให้เลือก \"นาย\" หรือ \"นาง\" หรือ \"นางสาว\"");
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", "If does not know please select \"Mister\" or \"Mistress\" or \"Miss\".");
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-titleprefix-combobox'>" + ePFUI.GetComboboxTitlePrefix(_idSection + "-titleprefix", _gender) + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("TitlePrefix", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-firstname"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "First Name");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", "กรณีไม่ทราบข้อมูลให้ใส่ \"?\"");
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", "If does not know please enter \"?\".");
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-firstname' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("FirstName", _contentFrmColumnDetail[_i]);
                    _i++;
                    
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-middlename"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อกลาง");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Middle Name");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-middlename' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("MiddleName", _contentFrmColumnDetail[_i]);
                    _i++;
                    
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-lastname"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "นามสกุล");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Last Name");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", "กรณีไม่ทราบข้อมูลให้ใส่ \"?\"");
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", "If does not know please enter \"?\".");
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-lastname' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("LastName", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-firstnameen"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อ ( ภาษาอังกฤษเท่านั้น )");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "First Name ( English Only )");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-firstnameen' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("FirstNameEN", _contentFrmColumnDetail[_i]);
                    _i++;
                    
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-middlenameen"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ชื่อกลาง ( ภาษาอังกฤษเท่านั้น )");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Middle Name ( English Only )");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-middlenameen' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("MiddleNameEN", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-lastnameen"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "นามสกุล ( ภาษาอังกฤษเท่านั้น )");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Last Name ( English Only )");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-lastnameen' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("LastNameEN", _contentFrmColumnDetail[_i]);
                    _i++;

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                    {
                        _contentTemp.Clear();

                        _paramSearch.Clear();
                        _paramSearch.Add("CancelledStatus", "N");

                        _ds = Util.DBUtil.GetListGender(_paramSearch);

                        foreach (DataRow _dr in _ds.Tables[0].Rows)
                        {
                            _contentTemp.AppendLine("<div class='radio-content'>");
                            _contentTemp.AppendLine("   <ul>");
                            _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-gender' value='{1}' /></li>", _idSection, _dr["id"].ToString());
                            _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["genderFullNameTH"].ToString(), _dr["genderFullNameEN"].ToString());
                            _contentTemp.AppendLine("   </ul>");
                            _contentTemp.AppendLine("</div>");
                            _contentTemp.AppendLine("<div class='clear'></div>");
                        }

                        _ds.Dispose();

                        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                        _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-gender"));
                        _contentFrmColumnDetail[_i].Add("HighLight", false);
                        _contentFrmColumnDetail[_i].Add("TitleTH", "เพศ");
                        _contentFrmColumnDetail[_i].Add("TitleEN", "Gender");
                        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                        _contentFrmColumnDetail[_i].Add("Require", false);
                        _contentFrmColumnDetail[_i].Add("LastRow", true);
                        _contentFrmColumn.Add("Gender", _contentFrmColumnDetail[_i]);
                        _i++;
                    }

                    _contentTemp.Clear();
        
                    for (_j = 0; _j < ePFStudentRecordsUtil._ynAlive.GetLength(0); _j++)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-alive' value='{1}' /></li>", _idSection, ePFStudentRecordsUtil._ynAlive[_j, 0]);
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", ePFStudentRecordsUtil._ynAlive[_j, 1], ePFStudentRecordsUtil._ynAlive[_j, 2]);
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-alive"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "สถานภาพชีวิต");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Living Status");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("Alive", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendFormat("<input class='inputcalendar' type='text' id='{0}-birthdate' readonly value='' />", _idSection);
                    _contentTemp.AppendLine("  <span class='th-label'> อายุ</span>");
                    _contentTemp.AppendLine("  <span class='en-label'> : Age</span>");
                    _contentTemp.AppendFormat("<span class='th-label age' id='{0}-age'></span>", _idSection);
                    _contentTemp.AppendLine("  <span class='th-label'>ปี</span>");
                    _contentTemp.AppendLine("  <span class='en-label'> : yr</span>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-birthdate"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "วันเดือนปีเกิด");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Date of Birth");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Birthdate", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-birthplace"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศบ้านเกิด");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Country of Birthplace");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-birthplace-combobox'>" + ePFUI.GetComboboxCountry(_idSection + "-birthplace") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Birthplace", _contentFrmColumnDetail[_i]);
                    _i++;
                    
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-nationality"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "สัญชาติ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Nationality");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-nationality-combobox'>" + ePFUI.GetComboboxNationality(_idSection + "-nationality") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Nationality", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-race"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เชื้อชาติ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Race");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-race-combobox'>" + ePFUI.GetComboboxNationality(_idSection + "-race") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Race", _contentFrmColumnDetail[_i]);
                    _i++;
                    
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-religion"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ศาสนา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Religion");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-religion-combobox'>" + ePFUI.GetComboboxReligion(_idSection + "-religion") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Religion", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();

                    _paramSearch.Clear();
                    _paramSearch.Add("CancelledStatus", "N");

                    _ds = Util.DBUtil.GetListBloodGroup(_paramSearch);

                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-bloodgroup' value='{1}' /></li>", _idSection, _dr["id"].ToString());
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["bloodTypeNameTH"].ToString(), _dr["bloodTypeNameEN"].ToString());
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _ds.Dispose();
                    
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-bloodgroup"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "กรุ๊ปเลือด");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Blood Group");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("BloodGroup", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();

                    _paramSearch.Clear();
                    _paramSearch.Add("CancelledStatus", "N");

                    _ds = Util.DBUtil.GetListMaritalStatus(_paramSearch);

                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-maritalstatus' value='{1}' /></li>", _idSection, _dr["id"].ToString());
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["maritalStatusNameTH"].ToString(), _dr["maritalStatusNameEN"].ToString());
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _ds.Dispose();

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-maritalstatus"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "สถานภาพทางการสมรส");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Marital Status");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("MaritalStatus", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();

                    _paramSearch.Clear();
                    _paramSearch.Add("CancelledStatus", "N");

                    _ds = Util.DBUtil.GetListEducationalBackground(_paramSearch);

                    foreach (DataRow _dr in _ds.Tables[0].Rows)
                    {
                        _contentTemp.AppendLine("<div class='radio-content'>");
                        _contentTemp.AppendLine("   <ul>");
                        _contentTemp.AppendFormat("     <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-educationalbackgroundperson' value='{1}' /></li>", _idSection, _dr["id"].ToString());
                        _contentTemp.AppendFormat("     <li class='radio-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", _dr["educationalBackgroundNameTH"].ToString(), _dr["educationalBackgroundNameEN"].ToString());
                        _contentTemp.AppendLine("   </ul>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");
                    }

                    _ds.Dispose();

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-educationalbackgroundperson"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "วุฒิการศึกษา");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Educational Background");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("EducationalBackgroundPerson", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
                    _contentTemp.AppendLine("               <li><div class='click-button en-label button-undo'>CLEAR</div></li>");
                    _contentTemp.AppendLine("           </ul>");
                    _contentTemp.AppendLine("       </div>");
                    _contentTemp.AppendLine("   </div>");
                    _contentTemp.AppendLine("</div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-save"));
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

                    _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSection);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                        _html.AppendLine(           ePFUI.GetFrmColumn(_contentFrmColumn["Relationship"]).ToString());

                    _html.AppendFormat("            <div id='{0}-form-content'>", _idSection);
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["IdCard"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["TitlePrefix"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["FirstName"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["MiddleName"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["LastName"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["FirstNameEN"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["MiddleNameEN"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["LastNameEN"]).ToString());

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                        _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Gender"]).ToString());

                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Alive"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Birthdate"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Birthplace"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Nationality"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Race"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Religion"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["BloodGroup"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["MaritalStatus"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["EducationalBackgroundPerson"]).ToString());
                    _html.AppendLine("              </div>");

                    _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("          /div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }
            }

            public class AddressUI
            {                   
                public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded, string _familyRelation)
                {
                    StringBuilder _html = new StringBuilder();
                    Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSFAMILY];
                    string _idSection = String.Empty;

                    _familyRelation = Util.UppercaseFirst(_familyRelation);
                    _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, PermanentAddressUI._idSectionFatherAddUpdate, PermanentAddressUI._idSectionMotherAddUpdate, PermanentAddressUI._idSectionParentAddUpdate);
                        
                    _html.AppendFormat("<input type='hidden' id='{0}-country-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("CountryPermanentAddress" + _familyRelation), _dataRecorded["CountryPermanentAddress" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-province-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("ProvincePermanentAddress" + _familyRelation), _dataRecorded["ProvincePermanentAddress" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-district-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("DistrictPermanentAddress" + _familyRelation), _dataRecorded["DistrictPermanentAddress" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-postalcodedistrict-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("PostalCodeDistrictPermanentAddress" + _familyRelation), _dataRecorded["PostalCodeDistrictPermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-subdistrict-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("SubDistrictPermanentAddress" + _familyRelation), _dataRecorded["SubDistrictPermanentAddress" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-postalcode-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("PostalCodePermanentAddress" + _familyRelation), _dataRecorded["PostalCodePermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-village-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("VillagePermanentAddress" + _familyRelation), _dataRecorded["VillagePermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-addressnumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("AddressNumberPermanentAddress" + _familyRelation), _dataRecorded["AddressNumberPermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-villageno-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("VillageNoPermanentAddress" + _familyRelation), _dataRecorded["VillageNoPermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-lanealley-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("LaneAlleyPermanentAddress" + _familyRelation), _dataRecorded["LaneAlleyPermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-road-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("RoadPermanentAddress" + _familyRelation), _dataRecorded["RoadPermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-phonenumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("PhoneNumberPermanentAddress" + _familyRelation), _dataRecorded["PhoneNumberPermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-mobilenumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("MobileNumberPermanentAddress" + _familyRelation), _dataRecorded["MobileNumberPermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-faxnumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("FaxNumberPermanentAddress" + _familyRelation), _dataRecorded["FaxNumberPermanentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));

                    _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, CurrentAddressUI._idSectionFatherAddUpdate, CurrentAddressUI._idSectionMotherAddUpdate, CurrentAddressUI._idSectionParentAddUpdate);

                    _html.AppendFormat("<input type='hidden' id='{0}-country-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("CountryCurrentAddress" + _familyRelation), _dataRecorded["CountryCurrentAddress" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-province-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("ProvinceCurrentAddress" + _familyRelation), _dataRecorded["ProvinceCurrentAddress" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-district-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("DistrictCurrentAddress" + _familyRelation), _dataRecorded["DistrictCurrentAddress" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-postalcodedistrict-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("PostalCodeDistrictCurrentAddress" + _familyRelation), _dataRecorded["PostalCodeDistrictCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-subdistrict-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("SubDistrictCurrentAddress" + _familyRelation), _dataRecorded["SubDistrictCurrentAddress" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-postalcode-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("PostalCodeCurrentAddress" + _familyRelation), _dataRecorded["PostalCodeCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-village-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("VillageCurrentAddress" + _familyRelation), _dataRecorded["VillageCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-addressnumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("AddressNumberCurrentAddress" + _familyRelation), _dataRecorded["AddressNumberCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-villageno-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("VillageNoCurrentAddress" + _familyRelation), _dataRecorded["VillageNoCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-lanealley-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("LaneAlleyCurrentAddress" + _familyRelation), _dataRecorded["LaneAlleyCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-road-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("RoadCurrentAddress" + _familyRelation), _dataRecorded["RoadCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-phonenumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("PhoneNumberCurrentAddress" + _familyRelation), _dataRecorded["PhoneNumberCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-mobilenumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("MobileNumberCurrentAddress" + _familyRelation), _dataRecorded["MobileNumberCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-faxnumber-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("FaxNumberCurrentAddress" + _familyRelation), _dataRecorded["FaxNumberCurrentAddress" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));

                    return _html;
                }

                public class PermanentAddressUI
                {
                    public static string _idSectionFatherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE.ToLower();
                    public static string _idSectionMotherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE.ToLower();
                    public static string _idSectionParentAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE.ToLower();

                    public static StringBuilder GetMain(string _familyRelation)
                    {
                        string _page = String.Empty;

                        _familyRelation = Util.UppercaseFirst(_familyRelation);

                        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYFATHER))
                            _page = ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE;

                        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYMOTHER))
                            _page = ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE;

                        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                            _page = ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE;
                        
                        return GetFrmAddress(_page, _familyRelation);
                    }
                }

                public class CurrentAddressUI
                {
                    public static string _idSectionFatherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE.ToLower();
                    public static string _idSectionMotherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE.ToLower();
                    public static string _idSectionParentAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE.ToLower();

                    public static StringBuilder GetMain(string _familyRelation)
                    {
                        string _page = String.Empty;

                        _familyRelation = Util.UppercaseFirst(_familyRelation);

                        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYFATHER))
                            _page = ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE;

                        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYMOTHER))
                            _page = ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE;

                        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                            _page = ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE;
                        
                        return GetFrmAddress(_page, _familyRelation);
                    }
                }

                public static StringBuilder GetFrmAddress(string _page, string _familyRelation)
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[16];
                    string _idSection = String.Empty;
                    int _i = 0;

                    _familyRelation = Util.UppercaseFirst(_familyRelation);

                    if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE) ||
                        _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE) ||
                        _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE))
                        _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, PermanentAddressUI._idSectionFatherAddUpdate, PermanentAddressUI._idSectionMotherAddUpdate, PermanentAddressUI._idSectionParentAddUpdate);

                    if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE) ||
                        _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE) ||
                        _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE))
                        _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, CurrentAddressUI._idSectionFatherAddUpdate, CurrentAddressUI._idSectionMotherAddUpdate, CurrentAddressUI._idSectionParentAddUpdate);

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                    {
                        _contentTemp.Clear();
                        _contentTemp.AppendLine("<div class='form-subcontent'>");
                        _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'></div><div class='en-label'></div></div>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");

                        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                        _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-relationship"));
                        _contentFrmColumnDetail[_i].Add("HighLight", false);
                        _contentFrmColumnDetail[_i].Add("TitleTH", "ความสัมพันธ์ของผู้ปกครอง");
                        _contentFrmColumnDetail[_i].Add("TitleEN", "Relationship of Parent");
                        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                        _contentFrmColumnDetail[_i].Add("Require", false);
                        _contentFrmColumnDetail[_i].Add("LastRow", false);
                        _contentFrmColumn.Add("Relationship", _contentFrmColumnDetail[_i]);
                        _i++;
                    }

                    if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE) ||
                        _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE) ||
                        _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE))
                    {
                        _contentTemp.Clear();
                        _contentTemp.AppendLine("<div class='button'>");
                        _contentTemp.AppendLine("   <div class='button-layout'>");
                        _contentTemp.AppendLine("       <div class='button-content'>");
                        _contentTemp.AppendLine("           <ul class='button-style1'>");
                        _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-copy'>COPY</div></li>");
                        _contentTemp.AppendLine("           </ul>");
                        _contentTemp.AppendLine("       </div>");
                        _contentTemp.AppendLine("   </div>");
                        _contentTemp.AppendLine("</div>");

                        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                        _contentFrmColumnDetail[_i].Add("ID", (_idSectionAddUpdate + "-copyaddress"));
                        _contentFrmColumnDetail[_i].Add("HighLight", false);
                        _contentFrmColumnDetail[_i].Add("TitleTH", "ใช้ที่อยู่เดียวกับที่อยู่ตามทะเบียนบ้าน");
                        _contentFrmColumnDetail[_i].Add("TitleEN", "Same As the Permanent Address");
                        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                        _contentFrmColumnDetail[_i].Add("Require", false);
                        _contentFrmColumnDetail[_i].Add("LastRow", false);
                        _contentFrmColumn.Add("SameAsPermanentAddress", _contentFrmColumnDetail[_i]);
                        _i++;
                    }

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-country"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ประเทศ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Country");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", "กรณีไม่ทราบข้อมูลให้เลือก \"ไทย\"");
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", "If does not know please select \"THAILAND\".");
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-country-combobox'>" + ePFUI.GetComboboxCountry(_idSection + "-country") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("Country", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-province"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "จังหวัด");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Province");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-province-combobox'></div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Province", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-district"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "อำเภอ / เขต");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "District / Area");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-district-combobox'></div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("District", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-subdistrict"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ตำบล / แขวง");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Sub-district / Sub-area");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-subdistrict-combobox'></div>"));
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("SubDistrict", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-postalcode"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "รหัสไปรษณีย์");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "ZIP / Postal Code");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-postalcode' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("PostalCode", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-village"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "หมู่บ้าน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Village");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-village' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Village", _contentFrmColumnDetail[_i]);
                    _i++;
                            
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-addressnumber"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "บ้านเลขที่");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Address Number");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", "กรณีไม่ทราบข้อมูลให้ใส่ \"?\"");
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", "If does not know please enter \"?\".");
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-addressnumber' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("AddressNumber", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-villageno"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "หมู่ที่");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Village No.");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-villageno' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("VillageNo", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-lanealley"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ตรอก / ซอย");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Lane / Alley");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-lanealley' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("LaneAlley", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-road"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ถนน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Road");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-road' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Road", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-phonenumber"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เบอร์โทรศัพท์บ้าน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Phone Number");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-phonenumber' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("PhoneNumber", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-mobilenumber"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เบอร์โทรศัพท์มือถือ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Mobile Number");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", "กรณีไม่ทราบข้อมูลให้ใส่ \"?\"");
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", "If does not know please enter \"?\".");
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-mobilenumber' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("MobileNumber", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-faxnumber"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "เบอร์แฟกซ์");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Fax Number");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-faxnumber' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("FaxNumber", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-save'>SAVE & NEXT</div></li>");
                    _contentTemp.AppendLine("               <li><div class='click-button en-label button-undo'>CLEAR</div></li>");
                    _contentTemp.AppendLine("           </ul>");
                    _contentTemp.AppendLine("       </div>");
                    _contentTemp.AppendLine("   </div>");
                    _contentTemp.AppendLine("</div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-save"));
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

                    _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSection);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                        _html.AppendLine(           ePFUI.GetFrmColumn(_contentFrmColumn["Relationship"]).ToString());


                    _html.AppendFormat("            <div id='{0}-form-content'>", _idSection);

                    if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE) ||
                        _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE) ||
                        _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE))
                        _html.AppendLine(               ePFUI.GetFrmColumn(_contentFrmColumn["SameAsPermanentAddress"]).ToString());

                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Country"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Province"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["District"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["SubDistrict"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["PostalCode"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Village"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["AddressNumber"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["VillageNo"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["LaneAlley"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Road"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["PhoneNumber"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["MobileNumber"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["FaxNumber"]).ToString());                    
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("              </div>");
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }
            }

            public class WorkUI
            {
                private static string _idSectionFatherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE.ToLower();
                private static string _idSectionMotherAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE.ToLower();
                private static string _idSectionParentAddUpdate = ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE.ToLower();

                public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded, string _familyRelation)
                {
                    StringBuilder _html = new StringBuilder();
                    Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFUtil.SUBJECT_SECTION_STUDENTRECORDSFAMILY];
                    string _idSection = String.Empty;

                    _familyRelation = Util.UppercaseFirst(_familyRelation);
                    _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, _idSectionFatherAddUpdate, _idSectionMotherAddUpdate, _idSectionParentAddUpdate);

                    _html.AppendFormat("<input type='hidden' id='{0}-occupation-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Occupation" + _familyRelation), _dataRecorded["Occupation" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-agency-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Agency" + _familyRelation), _dataRecorded["Agency" + _familyRelation], Util._valueComboboxDefault) : Util._valueComboboxDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-agencyother-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("AgencyOther" + _familyRelation), _dataRecorded["AgencyOther" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-workplace-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Workplace" + _familyRelation), _dataRecorded["Workplace" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-workplaceposition-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Position" + _familyRelation), _dataRecorded["Position" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-workplacetelephone-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Telephone" + _familyRelation), _dataRecorded["Telephone" + _familyRelation], Util._valueTextDefault) : Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-workplacesalary-hidden' value='{1}' />", _idSection, (_dataRecorded != null ? Util.GetValueDataDictionary(_dataRecorded, ("Salary" + _familyRelation), (!String.IsNullOrEmpty(_dataRecorded["Salary" + _familyRelation].ToString()) ? double.Parse(_dataRecorded["Salary" + _familyRelation].ToString()).ToString("#,##0.00") : _dataRecorded["Salary" + _familyRelation]), Util._valueTextDefault) : Util._valueTextDefault));

                    return _html;
                }

                public static StringBuilder GetMain(string _familyRelation)
                {
                    StringBuilder _html = new StringBuilder();
                    StringBuilder _contentTemp = new StringBuilder();
                    Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                    Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[8];
                    Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
                    DataSet _ds = new DataSet();
                    string _idSection = String.Empty;
                    int _i = 0;
                    int _j = 0;

                    _familyRelation = Util.UppercaseFirst(_familyRelation);
                    _idSection = ePFStudentRecordsUtil.GetSectionByFamilyRelation(_familyRelation, _idSectionFatherAddUpdate, _idSectionMotherAddUpdate, _idSectionParentAddUpdate);

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                    {
                        _contentTemp.Clear();
                        _contentTemp.AppendLine("<div class='form-subcontent'>");
                        _contentTemp.AppendLine("   <div class='form-labelcol'><div class='th-label'></div><div class='en-label'></div></div>");
                        _contentTemp.AppendLine("</div>");
                        _contentTemp.AppendLine("<div class='clear'></div>");

                        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                        _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-relationship"));
                        _contentFrmColumnDetail[_i].Add("HighLight", false);
                        _contentFrmColumnDetail[_i].Add("TitleTH", "ความสัมพันธ์ของผู้ปกครอง");
                        _contentFrmColumnDetail[_i].Add("TitleEN", "Relationship of Parent");
                        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
                        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                        _contentFrmColumnDetail[_i].Add("Require", false);
                        _contentFrmColumnDetail[_i].Add("LastRow", false);
                        _contentFrmColumn.Add("Relationship", _contentFrmColumnDetail[_i]);
                        _i++;
                    }                    
                                                                                
                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-occupation"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "อาชีพ");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Occupation");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idSection + "-occupation-combobox'>" + ePFUI.GetComboboxOccupation(_idSection + "-occupation") + "</div>"));
                    _contentFrmColumnDetail[_i].Add("Require", true);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Occupation", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendFormat("<div id='{0}-agency-combobox'>{1}</div>", _idSection, ePFUI.GetComboboxAgency(_idSection + "-agency"));
                    _contentTemp.AppendLine("  <div class='agencyother'>");
                    _contentTemp.AppendLine("       <div class='radio-content'>");
                    _contentTemp.AppendLine("           <ul>");
                    _contentTemp.AppendFormat("             <li class='radio-inputcol'><input class='radio' type='radio' name='{0}-agencyother' value='0' /></li>", _idSection);
                    _contentTemp.AppendLine("               <li class='radio-labelcol'><div class='th-label'>อื่น ๆ</div><div class='en-label'>Other</div></li>");
                    _contentTemp.AppendLine("           </ul>");
                    _contentTemp.AppendLine("       </div>");
                    _contentTemp.AppendLine("       <div class='clear'></div>");
                    _contentTemp.AppendLine("       <div class='form-subcontent first-child'>");
                    _contentTemp.AppendFormat("         <div class='form-inputcol'><input class='inputbox' type='text' id='{0}-agencyotherdetail' value='' /></div>", _idSection);
                    _contentTemp.AppendLine("       </div>");
                    _contentTemp.AppendLine("       <div class='clear'></div>");
                    _contentTemp.AppendLine("  </div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-agency"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ต้นสังกัด");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Agency");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", true);
                    _contentFrmColumn.Add("Agency", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-workplace"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "สถานที่ทำงาน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Workplace");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-workplace' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Workplace", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-workplaceposition"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "ตำแหน่ง");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Position");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-workplaceposition' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Position", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-workplacetelephone"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "โทรศัพท์ที่ทำงาน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Workplace Telephone");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", "<input class='inputbox' type='text' id='" + _idSection + "-workplacetelephone' value='' />");
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Telephone", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendFormat("<input class='inputbox textbox-numeric' type='text' id='{0}-workplacesalary' value='' />", _idSection);
                    _contentTemp.AppendLine("  <span class='th-label'> บาท</span>");
                    _contentTemp.AppendLine("  <span class='en-label'> : bath</span>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-workplacesalary"));
                    _contentFrmColumnDetail[_i].Add("HighLight", false);
                    _contentFrmColumnDetail[_i].Add("TitleTH", "รายได้เฉลี่ยต่อเดือน");
                    _contentFrmColumnDetail[_i].Add("TitleEN", "Income");
                    _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                    _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                    _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                    _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                    _contentFrmColumnDetail[_i].Add("Require", false);
                    _contentFrmColumnDetail[_i].Add("LastRow", false);
                    _contentFrmColumn.Add("Salary", _contentFrmColumnDetail[_i]);
                    _i++;

                    _contentTemp.Clear();
                    _contentTemp.AppendLine("<div class='button'>");
                    _contentTemp.AppendLine("   <div class='button-layout'>");
                    _contentTemp.AppendLine("       <div class='button-content'>");
                    _contentTemp.AppendLine("           <ul class='button-style1'>");
                    _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-save'>{0}</div></li>", (!_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT) ? "SAVE & NEXT" : "SAVE"));
                    _contentTemp.AppendLine("               <li><div class='click-button en-label button-undo'>CLEAR</div></li>");
                    _contentTemp.AppendLine("           </ul>");
                    _contentTemp.AppendLine("       </div>");
                    _contentTemp.AppendLine("   </div>");
                    _contentTemp.AppendLine("</div>");

                    _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                    _contentFrmColumnDetail[_i].Add("ID", (_idSection + "-save"));
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

                    _html.AppendFormat("<div class='form addupdate' id='{0}-form'>", _idSection);
                    _html.AppendLine("      <div class='form-layout'>");
                    _html.AppendLine("          <div class='form-content'>");

                    if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
                        _html.AppendLine(           ePFUI.GetFrmColumn(_contentFrmColumn["Relationship"]).ToString());

                    _html.AppendFormat("            <div id='{0}-form-content'>", _idSection);
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Occupation"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Agency"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Workplace"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Position"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Telephone"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Salary"]).ToString());
                    _html.AppendLine(                   ePFUI.GetFrmColumn(_contentFrmColumn["Save"]).ToString());
                    _html.AppendLine("              </div>");
                    _html.AppendLine("          </div>");
                    _html.AppendLine("      </div>");
                    _html.AppendLine("  </div>");

                    return _html;
                }
            }
        }
    }
}