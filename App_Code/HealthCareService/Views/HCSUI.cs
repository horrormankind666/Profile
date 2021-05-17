/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๖/๑๒/๒๕๕๗>
Modify date : <๐๘/๐๔/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผล>
=============================================
*/

using System.Collections.Generic;
using System.Text;
using NUtil;

public class HCSUI
{
    public class HCSStaffDownloadRegistrationFormUI
    {
        private static string _idSectionMain = HCSUtil.ID_SECTION_DOWNLOADREGISTRATIONFORM_MAIN.ToLower();

        public static StringBuilder GetSection(Dictionary<string, object> _infoLogin, string _section, string _sectionAction, string _id)
        {
            StringBuilder _html = new StringBuilder();

            switch (_section)
            {
                case "MAIN":
                    _html = SectionMainUI.GetMain(_id);
                    break;
            }

            return _html;
        }
        
        public class SectionMainUI
        {
            private static string _idSectionMain = HCSUtil.ID_SECTION_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS_MAIN.ToLower();
            
            public static StringBuilder GetMain(string _id)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _valueDataRecorded = HCSUtil.SetValueDataRecorded(HCSUtil.PAGE_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS_MAIN, _id);
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + HCSUtil.SUBJECT_SECTION_DOWNLOADREGISTRATIONFORMSTUDENTRECORDS];

                _html.AppendFormat("<div id='{0}-form'>", HCSStaffDownloadRegistrationFormUI._idSectionMain);
                _html.AppendLine("      <div class='form-layout'>");
                _html.AppendLine("          <div class='form-content'>");
                _html.AppendLine("              <div class='title'></div>");
                _html.AppendFormat("            <div class='slide' id='{0}-slide'>", HCSStaffDownloadRegistrationFormUI._idSectionMain);
                _html.AppendLine("                  <div class='slideimage1'></div>");
                _html.AppendLine("                  <div class='slideimage2'></div>");
                _html.AppendLine("                  <div class='slideimage3'></div>");
                _html.AppendLine("                  <div class='active slideimage4'></div>");
                _html.AppendLine("              </div>");
                _html.AppendFormat("            <div id='{0}'>", _idSectionMain);
                _html.AppendFormat("                <div class='en-label' id='{0}-studentid'>{1}</div>", _idSectionMain, _dataRecorded["StudentCode"]);
                _html.AppendFormat("                <div class='th-label' id='{0}-studentnameth'>{1}</div>", _idSectionMain, Util.GetFullName(_dataRecorded["TitleInitialsTH"].ToString(), _dataRecorded["TitleFullNameTH"].ToString(), _dataRecorded["FirstName"].ToString(), _dataRecorded["MiddleName"].ToString(), _dataRecorded["LastName"].ToString()));
                _html.AppendFormat("                <div class='en-label' id='{0}-studentnameen'>{1}</div>", _idSectionMain, Util.GetFullName(_dataRecorded["TitleInitialsEN"].ToString(), _dataRecorded["TitleFullNameEN"].ToString(), _dataRecorded["FirstNameEN"].ToString(), _dataRecorded["MiddleNameEN"].ToString(), _dataRecorded["LastNameEN"].ToString()).ToUpper());
                _html.AppendFormat("                <div class='th-label' id='{0}-facultyth'>{1}</div>", _idSectionMain, _dataRecorded["FacultyNameTH"]);
                _html.AppendFormat("                <div class='en-label' id='{0}-facultyen'>{1}</div>", _idSectionMain, Util.UppercaseFirst(_dataRecorded["FacultyNameEN"].ToString()));
                _html.AppendFormat("                <div class='th-label' id='{0}-programth'>{1}</div>", _idSectionMain, _dataRecorded["ProgramNameTH"]);
                _html.AppendFormat("                <div class='en-label' id='{0}-programen'>{1}</div>", _idSectionMain, Util.UppercaseFirst(_dataRecorded["ProgramNameEN"].ToString()));
                _html.AppendFormat("                <div class='th-label' id='{0}-hospitalth'>{1}</div>", _idSectionMain, _dataRecorded["HospitalNameTH"]);
                _html.AppendFormat("                <div class='en-label' id='{0}-hospitalen'>{1}</div>", _idSectionMain, Util.UppercaseFirst(_dataRecorded["HospitalNameEN"].ToString()));
                _html.AppendFormat("            </div>");
                _html.AppendLine("              <div class='button'>");
                _html.AppendLine("                  <div class='button-layout'>");
                _html.AppendLine("                      <div class='button-content'>");
                _html.AppendLine("                          <ul class='button-style1'>");
                _html.AppendLine("                              <li class='nomargin'><div class='click-button button-download'><div class='th-label'>คลิกเพื่อดาว์นโหลดแบบฟอร์ม</div><div class='en-label'>Click to Download Form</div></div></li>");
                _html.AppendLine("                          </ul>");
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