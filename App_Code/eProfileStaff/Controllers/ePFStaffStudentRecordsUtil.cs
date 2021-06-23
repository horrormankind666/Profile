/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๙/๐๑/๒๕๕๘>
Modify date : <๒๓/๐๖/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการจัดการข้อมูลระเบียนประวัตินักศึกษา>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;

public class ePFStaffStudentRecordsUtil
{
    public static string[] _sortOrderBy = new string[]
    {
        "Student ID"
        /*
        "Name",
        "Faculty",
        "Program",
        "Year Attended",
        "Class"
        */
    };
    
    public static string[,] _menuRecords = new string[,]
    {
        { "ข้อมูลส่วนตัว", "Student's Personal Data", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSPERSONAL_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSPERSONAL_ADDUPDATE },
        { "ข้อมูลที่อยู่", "Student's Address", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSADDRESS_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSADDRESS_ADDUPDATE },
        { "ข้อมูลการศึกษา", "Educational Record", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATION_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATION_ADDUPDATE },
        { "ข้อมูลความสามารถพิเศษ", "Talent Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSTALENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSTALENT_ADDUPDATE },
        { "ข้อมูลความพิการ", "Disability Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSHEALTHY_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSHEALTHY_ADDUPDATE },
        //{ "ข้อมูลการทำงาน", "Work Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSWORK_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSWORK_ADDUPDATE },
        { "ข้อมูลการเงิน", "Finance Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFINANCIAL_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFINANCIAL_ADDUPDATE },
        { "ข้อมูลครอบครัว", "Family Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILY_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILY_ADDUPDATE },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address", "active", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSADDRESSPERMANENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSADDRESSPERMANENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSADDRESSCURRENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSADDRESSCURRENT_ADDUPDATE },
        { "ระดับประถม", "Primary Education", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE },
        { "ระดับมัธยมต้น", "Junior Education", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE },
        { "ระดับมัธยมปลาย", "High School Education", "active", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE },
        { "ก่อนที่เข้า&nbsp;ม.มหิดล", "Prior to Entering MU", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE },
        { "คะแนนสอบ", "Admission Scores", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE },
        { "ข้อมูลบิดา", "Father Information", "active", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHER_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHER_ADDUPDATE },
        { "ข้อมูลมารดา", "Mother Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHER_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHER_ADDUPDATE },
        { "ข้อมูลผู้ปกครอง", "Parent Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENT_ADDUPDATE , ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENT_ADDUPDATE },
        { "ข้อมูลส่วนตัว", "Personal Data", "active", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE },
        { "ข้อมูลส่วนตัว", "Personal Data", "active", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE },
        { "ข้อมูลส่วนตัว", "Personal Data", "active", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE },
        { "ข้อมูลการทำงาน", "Work Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE },
        { "ข้อมูลการทำงาน", "Work Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE },
        { "ข้อมูลการทำงาน", "Work Information", "", ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE, ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE },
    };

    public static string[,] _topicsStudentRecords = new string[,]
    {
        { "ข้อมูลส่วนตัว", "Student's Personal Data", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSPERSONAL },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSADDRESSPERMANENT },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSADDRESSCURRENT },
        { "ข้อมูลการศึกษาระดับประถม", "Primary Educational Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONPRIMARYSCHOOL },
        { "ข้อมูลการศึกษาระดับมัธยมต้น", "Junior Educational Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL },
        { "ข้อมูลการศึกษาระดับมัธยมปลาย", "High School Educational Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONHIGHSCHOOL },
        { "ข้อมูลการศึกษาก่อนที่เข้า ม.มหิดล", "Prior to Entering MU Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONUNIVERSITY },
        { "ข้อมูลการศึกษาคะแนนสอบ", "Admission Scores Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONADMISSIONSCORES },
        { "ข้อมูลความสามารถพิเศษ", "Talent Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSTALENT },
        { "ข้อมูลสุขภาพ", "Health Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSHEALTHY },
        { "ข้อมูลการทำงาน", "Work Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSWORK },
        { "ข้อมูลการเงิน", "Finance Information", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFINANCIAL },
        { "ข้อมูลส่วนตัวของบิดา", "Personal Data of Father", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERPERSONAL },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้านของบิดา", "Permanent Address Information of Father", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSPERMANENT },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้ของบิดา", "Current Address Information of Father", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSCURRENT },
        { "ข้อมูลการทำงานของบิดา", "Work Information of Father", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERWORK },
        { "ข้อมูลส่วนตัวของมารดา", "Personal Data of Mother", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERPERSONAL },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้านของมารดา", "Permanent Address Information of Mother", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้ของมารดา", "Current Address Information of Mother", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSCURRENT },
        { "ข้อมูลการทำงานของมารดา", "Work Information of Mother", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERWORK },
        { "ข้อมูลส่วนตัวของผู้ปกครอง", "Personal Data of Parent", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTPERSONAL },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้านของผู้ปกครอง", "Permanent Address Information of Parent", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSPERMANENT },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้ของผู้ปกครอง", "Current Address Information of Parent", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSCURRENT },
        { "ข้อมูลการทำงานของผู้ปกครอง", "Work Information of Parent", ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTWORK }
    };

    public static string[,] _graduateBy = new string[,]
    {
        { "01", "สอบปกติ", "High School Education" },
        { "02", "สอบเทียบ", "Informal Education" }
    };
        
    public static string[,] _entranceTime = new string[,]
    {
        { "1", "ครั้งแรก", "First Time" },
        { "2", "ครั้งที่ 2", "2 Times" },
        { "3", "ครั้งที่ 3", "3 Times" },
        { "4", "มากกว่า 3 ครั้ง", "More Than 3 Times" }
    };

    public static string[,] _studentIs = new string[,]
    {
        { "01", "เป็นนักศึกษาม.มหิดลครั้งแรก", "First Time Student at Mahidol University" },
        { "02", "เคยเป็นนักศึกษา", "Previously" }
    };
        
    public static string[,] _admissionScores = new string[,]
    {
        { "O-NET", "ภาษาไทย", "Thai", "ScoresONETThai" },
        { "O-NET", "สังคมศึกษา", "Social Science", "ScoresONETSocialScience" },
        { "O-NET", "ภาษาอังกฤษ", "English", "ScoresONETEnglish" },
        { "O-NET", "คณิตศาสตร์", "Mathematics", "ScoresONETMathematics" },
        { "O-NET", "วิทยาศาสตร์", "Science", "ScoresONETScience" },
        { "O-NET", "สุขศึกษาและพลศึกษา", "Health Education & Physical Education", "ScoresONETHealthPhysical" },
        { "O-NET", "ศิลปะ", "Arts", "ScoresONETArts" },
        { "O-NET", "การงานอาชีพและเทคโนโลยี", "Occupation & Teachnology", "ScoresONETOccupationTechnology" },
        { "A-NET", "ภาษาไทย 2", "Thai 2", "ScoresANETThai2" },
        { "A-NET", "สังคมศึกษา 2", "Social Science 2", "ScoresANETSocialScience2" },
        { "A-NET", "ภาษาอังกฤษ 3", "English 3", "ScoresANETEnglish3" },
        { "A-NET", "คณิตศาสตร์ 2", "Mathematics 2", "ScoresANETMathematics2" },
        { "A-NET", "วิทยาศาสตร์ 2", "Science 2", "ScoresANETScience2" },
        { "GAT", "ความถนัดทั่วไป", "Genaral Aptitude Test", "ScoresGATGenaralAptitudeTest" },
        { "PAT 1", "ความถนัดคณิตศาสตร์", "Aptitude In Mathematics", "ScoresPAT1" },
        { "PAT 2", "ความถนัดวิทยาศาสตร์", "Aptitude In Science", "ScoresPAT2" },
        { "PAT 3", "ความถนัดวิศวกรรมศาสตร์", "Aptitude In Engineering", "ScoresPAT3" },
        { "PAT 4", "ความถนัดสถาปัตยกรรมศาสตร์", "Aptitude In Architecture", "ScoresPAT4" },
        { "PAT 5", "ความถนัดวิชาชีพครู", "Aptitude In Teaching", "ScoresPAT5" },
        { "PAT 6", "ความถนัดศิลปกรรมศาสตร์", "Aptitude In Arts", "ScoresPAT6" },
        { "PAT 7.1", "ภาษาฝรั่งเศส", "French Languages", "ScoresPAT7" },
        { "PAT 7.2", "ภาษาเยอรมัน", "Germany Languages", "ScoresPAT8" },
        { "PAT 7.3", "ภาษาญี่ปุ่น", "Japanese Languages", "ScoresPAT9" },
        { "PAT 7.4", "ภาษาจีน", "Chinese Languages", "ScoresPAT10" },
        { "PAT 7.5", "ภาษาอาหรับ", "Arabic Languages", "ScoresPAT11" },
        { "PAT 7.6", "ภาษาบาลี", "Bali Languages", "ScoresPAT12" }
    };
        
    public static string[,] _occupation = new string[,]
    {
        { "01", "รับราชการ", "Public Servant" },
        { "02", "พนักงาน / ลูกจ้าง ส่วนราชการ", "Staff / Employee Government" },
        { "03", "พนักงาน / ลูกจ้างเอกชน", "Staff / Employee in Private Company" },
        { "04", "พนักงานรัฐวิสาหกิจ", "State Enterprise Employees" },
        { "05", "ธุรกิจส่วนตัว / ค้าขาย / อาชีพอิสระ / แม่บ้าน", "Independent Business / Family Business / Freelance / Housewife" },
        { "06", "เกษตรกร / ชาวประมง", "Farmer / Fisherman" },
        { "07", "องค์การมหาชน", "Public Organization" },
        { "08", "รับจ้าง", "Hired Hands" }
    };
        
    public static string[,] _scholarshipFrom = new string[,]
    {
        { "01", "กยศ.", "Student Loan" },
        { "02", "หน่วยงานรัฐ", "Government Agency" },
        { "03", "หน่วยงานเอกชน", "Private Agency" }
    };

    public static string[,] _financialSupportFrom = new string[,]
    {
        { "01", "บิดา", "Father" },
        { "02", "มารดา", "Mother" },
        { "03", "บิดาและมารดา", "Father And Mother" },
        { "04", "กู้ยืม", "Loan" },
        { "05", "ทำงานด้วยตนเอง", "Self Support" },
        { "06", "ผู้ปกครอง / ญาติ", "Benefactor / Relative" },
        { "07", "ทุนการศึกษา", "Scholarship" }
    };

    public static string[,] _ynAlive = new string[,]
    {
        { "Y", "มีชีวิตอยู่", "Alive" },
        { "N", "ถึงแก่กรรม", "Deceased" }
    };

    public static Dictionary<string, object> GetSearch(Dictionary<string, object> _paramSearch)
    {
        Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _searchResult = new Dictionary<string, object>();
        DataSet _ds = new DataSet();
        DataRow[] _dr = null;
        int _recordCount = 0;
        int _recordCountPrimary = 0;
        int _recordCountSecondary = 0;
        int _recordCountAllPrimary = 0;
        int _recordCountAllSecondary = 0; 
        StringBuilder _list = new StringBuilder();
        StringBuilder _navPage = new StringBuilder();

        _ds = Util.DBUtil.GetListStudentRecords(
            _loginResult["Username"].ToString(),
            _loginResult["Userlevel"].ToString(),
            _loginResult["SystemGroup"].ToString(),
            "",
            _paramSearch
        );

        _dr = _ds.Tables[0].Select("rowNum >= " + _paramSearch["StartRow"] + " AND rowNum <= " + _paramSearch["EndRow"]);
        _recordCount = _ds.Tables[0].Rows.Count;
        _recordCountPrimary = _ds.Tables[0].Rows.Count;
        _list = ePFStaffStudentRecordsUI.SectionMainUI.GetList(_loginResult, _dr);
        _navPage = Util.GetNavPageNew(_recordCount, (int)(_paramSearch["CurrentPage"]), ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDS_MAIN, (int)(_paramSearch["RowPerPage"]));

        _ds.Dispose();

        _searchResult.Add("RecordCount", _recordCount);
        _searchResult.Add("RecordCountPrimary", _recordCountPrimary);
        _searchResult.Add("RecordCountSecondary", _recordCountSecondary);
        _searchResult.Add("RecordCountAllPrimary", _recordCountAllPrimary);
        _searchResult.Add("RecordCountAllSecondary", _recordCountAllSecondary);
        _searchResult.Add("List", _list);
        _searchResult.Add("NavPage", _navPage);

        return _searchResult;
    }

    public static string GetSectionByFamilyRelation(string _familyRelation, string _idFather, string _idMother, string _idParent)
    {
        string _idSection = String.Empty;

        if (_familyRelation.Equals(ePFStaffUtil.SUBJECT_FAMILYFATHER))
            _idSection = _idFather;

        if (_familyRelation.Equals(ePFStaffUtil.SUBJECT_FAMILYMOTHER))
            _idSection = _idMother;

        if (_familyRelation.Equals(ePFStaffUtil.SUBJECT_FAMILYPARENT))
            _idSection = _idParent;

        return _idSection;
    }
    
    public static string GetGenderByFamilyRelation(string _familyRelation)
    {
        string _gender = String.Empty;

        if (_familyRelation.Equals(ePFStaffUtil.SUBJECT_FAMILYFATHER))
            _gender = "M";

        if (_familyRelation.Equals(ePFStaffUtil.SUBJECT_FAMILYMOTHER))
            _gender = "F";

        if (_familyRelation.Equals(ePFStaffUtil.SUBJECT_FAMILYPARENT))
            _gender = String.Empty;

        return _gender;
    }
    
    public class StudentRecordsUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            string _studentPicture = String.Empty;
            DataRow _dr = null;

            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[0].Rows[0];
            }

            _studentPicture = (_dr != null && !String.IsNullOrEmpty(_dr["profilePictureName"].ToString()) ? (ePFStaffUtil._myURLPictureStudent + "/" + _dr["profilePictureName"].ToString()) : String.Empty);
            _studentPicture = (!String.IsNullOrEmpty(_studentPicture) && Util.FileSiteExist(_studentPicture) ? (ePFStaffUtil._myHandlerPath + "?action=image2stream&f=" + Util.EncodeToBase64(_studentPicture)) : String.Empty);
      
            _dataRecorded.Add("ConsentField", (_dr != null && !String.IsNullOrEmpty(_dr["consentField"].ToString()) ? _dr["consentField"] : String.Empty));
            _dataRecorded.Add("PersonId", (_dr != null && !String.IsNullOrEmpty(_dr["id"].ToString()) ? _dr["id"] : String.Empty));
            _dataRecorded.Add("StudentId", (_dr != null && !String.IsNullOrEmpty(_dr["studentId"].ToString()) ? _dr["studentId"] : String.Empty));
            _dataRecorded.Add("StudentCode", (_dr != null && !String.IsNullOrEmpty(_dr["studentCode"].ToString()) ? _dr["studentCode"] : "XXXXXXX"));
            _dataRecorded.Add("StudentPicture", (!String.IsNullOrEmpty(_studentPicture) ? _studentPicture : String.Empty));
            _dataRecorded.Add("TitleInitialsTH", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsTH"].ToString()) ? _dr["titlePrefixInitialsTH"].ToString() : String.Empty));
            _dataRecorded.Add("TitleInitialsEN", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixInitialsEN"].ToString()) ? _dr["titlePrefixInitialsEN"].ToString() : String.Empty));
            _dataRecorded.Add("TitleFullNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameTH"].ToString()) ? _dr["titlePrefixFullNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("TitleFullNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["titlePrefixFullNameEN"].ToString()) ? _dr["titlePrefixFullNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("FirstName", (_dr != null && !String.IsNullOrEmpty(_dr["firstName"].ToString()) ? _dr["firstName"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleName", (_dr != null && !String.IsNullOrEmpty(_dr["middleName"].ToString()) ? _dr["middleName"].ToString() : String.Empty));
            _dataRecorded.Add("LastName", (_dr != null && !String.IsNullOrEmpty(_dr["lastName"].ToString()) ? _dr["lastName"].ToString() : String.Empty));
            _dataRecorded.Add("FirstNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["firstNameEN"].ToString()) ? _dr["firstNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["middleNameEN"].ToString()) ? _dr["middleNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("LastNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["lastNameEN"].ToString()) ? _dr["lastNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("Gender", (_dr != null && !String.IsNullOrEmpty(_dr["genderInitialsEN"].ToString()) ? _dr["genderInitialsEN"].ToString() : String.Empty));
            _dataRecorded.Add("NationalityNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["nationalityNameTH"].ToString()) ? _dr["nationalityNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("DegreeLevelNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["degreeLevelNameTH"].ToString()) ? _dr["degreeLevelNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("DegreeLevelNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["degreeLevelNameEN"].ToString()) ? _dr["degreeLevelNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("FacultyNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameTH"].ToString()) ? _dr["facultyNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("FacultyNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameEN"].ToString()) ? _dr["facultyNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramCode", (_dr != null && !String.IsNullOrEmpty(_dr["programCodeNew"].ToString()) ? _dr["programCodeNew"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? _dr["programNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? _dr["programNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("IsProgramContract", (_dr != null && !String.IsNullOrEmpty(_dr["isProgramContract"].ToString()) ? _dr["isProgramContract"].ToString() : String.Empty));
            _dataRecorded.Add("YearEntry", (_dr != null && !String.IsNullOrEmpty(_dr["yearEntry"].ToString()) ? _dr["yearEntry"].ToString() : String.Empty));
            _dataRecorded.Add("Class", (_dr != null && !String.IsNullOrEmpty(_dr["class"].ToString()) ? _dr["class"].ToString() : String.Empty));
            _dataRecorded.Add("StatusTypeNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["statusTypeNameTH"].ToString()) ? _dr["statusTypeNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("StatusTypeNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["statusTypeNameEN"].ToString()) ? _dr["statusTypeNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("StatusGroup", (_dr != null && !String.IsNullOrEmpty(_dr["statusGroup"].ToString()) ? _dr["statusGroup"].ToString() : String.Empty));            
            _dataRecorded.Add("AdmissionDate", (_dr != null && !String.IsNullOrEmpty(_dr["admissionDate"].ToString()) ? DateTime.Parse(_dr["admissionDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
            _dataRecorded.Add("GraduationDate", (_dr != null && !String.IsNullOrEmpty(_dr["graduateDate"].ToString()) ? DateTime.Parse(_dr["graduateDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
            _dataRecorded.Add("UpdateReason", (_dr != null && !String.IsNullOrEmpty(_dr["updateReason"].ToString()) ? _dr["updateReason"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceType", (_dr != null && !String.IsNullOrEmpty(_dr["perEntranceTypeId"].ToString()) ? _dr["perEntranceTypeId"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTypeNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["stdEntranceTypeNameTH"].ToString()) ? _dr["stdEntranceTypeNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTypeNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["stdEntranceTypeNameEN"].ToString()) ? _dr["stdEntranceTypeNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsPersonalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsPersonalStatus"].ToString()) ? _dr["studentRecordsPersonalStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsAddressPermanentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsAddressPermanentStatus"].ToString()) ? _dr["studentRecordsAddressPermanentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsAddressCurrentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsAddressCurrentStatus"].ToString()) ? _dr["studentRecordsAddressCurrentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsEducationPrimarySchoolStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsEducationPrimarySchoolStatus"].ToString()) ? _dr["studentRecordsEducationPrimarySchoolStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsEducationJuniorHighSchoolStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsEducationJuniorHighSchoolStatus"].ToString()) ? _dr["studentRecordsEducationJuniorHighSchoolStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsEducationHighSchoolStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsEducationHighSchoolStatus"].ToString()) ? _dr["studentRecordsEducationHighSchoolStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsEducationUniversityStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsEducationUniversityStatus"].ToString()) ? _dr["studentRecordsEducationUniversityStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsEducationAdmissionScoresStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsEducationAdmissionScoresStatus"].ToString()) ? _dr["studentRecordsEducationAdmissionScoresStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsTalentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsTalentStatus"].ToString()) ? _dr["studentRecordsTalentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsHealthyStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsHealthyStatus"].ToString()) ? _dr["studentRecordsHealthyStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsWorkStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsWorkStatus"].ToString()) ? _dr["studentRecordsWorkStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFinancialStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFinancialStatus"].ToString()) ? _dr["studentRecordsFinancialStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyFatherPersonalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyFatherPersonalStatus"].ToString()) ? _dr["studentRecordsFamilyFatherPersonalStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyMotherPersonalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyMotherPersonalStatus"].ToString()) ? _dr["studentRecordsFamilyMotherPersonalStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyParentPersonalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyParentPersonalStatus"].ToString()) ? _dr["studentRecordsFamilyParentPersonalStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyFatherAddressPermanentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyFatherAddressPermanentStatus"].ToString()) ? _dr["studentRecordsFamilyFatherAddressPermanentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyMotherAddressPermanentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyMotherAddressPermanentStatus"].ToString()) ? _dr["studentRecordsFamilyMotherAddressPermanentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyParentAddressPermanentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyParentAddressPermanentStatus"].ToString()) ? _dr["studentRecordsFamilyParentAddressPermanentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyFatherAddressCurrentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyFatherAddressCurrentStatus"].ToString()) ? _dr["studentRecordsFamilyFatherAddressCurrentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyMotherAddressCurrentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyMotherAddressCurrentStatus"].ToString()) ? _dr["studentRecordsFamilyMotherAddressCurrentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyParentAddressCurrentStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyParentAddressCurrentStatus"].ToString()) ? _dr["studentRecordsFamilyParentAddressCurrentStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyFatherWorkStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyFatherWorkStatus"].ToString()) ? _dr["studentRecordsFamilyFatherWorkStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyMotherWorkStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyMotherWorkStatus"].ToString()) ? _dr["studentRecordsFamilyMotherWorkStatus"].ToString() : String.Empty));
            _dataRecorded.Add("StudentRecordsFamilyParentWorkStatus", (_dr != null && !String.IsNullOrEmpty(_dr["studentRecordsFamilyParentWorkStatus"].ToString()) ? _dr["studentRecordsFamilyParentWorkStatus"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class PersonalUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            Dictionary<string, object> _age = new Dictionary<string, object>();
            DataRow _dr = null;

            if (_ds != null)
            {
                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[0].Rows[0];
            }

            if (_dr != null && !String.IsNullOrEmpty(_dr["enBirthDate"].ToString()))
                _age = ePFStaffUtil.CalAge(_dr["enBirthDate"].ToString(), Util.CurrentDate("dd/MM/yyyy"));

            _dataRecorded.Add("IdCard", (_dr != null && !String.IsNullOrEmpty(_dr["idCard"].ToString()) ? _dr["idCard"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardIssueDateTH", (_dr != null && !String.IsNullOrEmpty(_dr["thIdCardIssueDate"].ToString()) ? _dr["thIdCardIssueDate"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardIssueDateEN", (_dr != null && !String.IsNullOrEmpty(_dr["enIdCardIssueDate"].ToString()) ? _dr["enIdCardIssueDate"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardExpiryDateTH", (_dr != null && !String.IsNullOrEmpty(_dr["thIdCardExpiryDate"].ToString()) ? _dr["thIdCardExpiryDate"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardExpiryDateEN", (_dr != null && !String.IsNullOrEmpty(_dr["enIdCardExpiryDate"].ToString()) ? _dr["enIdCardExpiryDate"].ToString() : String.Empty));
            _dataRecorded.Add("TitlePrefix", (_dr != null && !String.IsNullOrEmpty(_dr["perTitlePrefixId"].ToString()) ? _dr["perTitlePrefixId"].ToString() : String.Empty));
            _dataRecorded.Add("GenderTitlePrefix", (_dr != null && !String.IsNullOrEmpty(_dr["perGenderIdTitlePrefix"].ToString()) ? _dr["perGenderIdTitlePrefix"].ToString() : String.Empty));
            _dataRecorded.Add("FirstName", (_dr != null && !String.IsNullOrEmpty(_dr["firstName"].ToString()) ? _dr["firstName"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleName", (_dr != null && !String.IsNullOrEmpty(_dr["middleName"].ToString()) ? _dr["middleName"].ToString() : String.Empty));
            _dataRecorded.Add("LastName", (_dr != null && !String.IsNullOrEmpty(_dr["lastName"].ToString()) ? _dr["lastName"].ToString() : String.Empty));
            _dataRecorded.Add("FirstNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enFirstName"].ToString()) ? _dr["enFirstName"].ToString() : String.Empty));
            _dataRecorded.Add("MiddleNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enMiddleName"].ToString()) ? _dr["enMiddleName"].ToString() : String.Empty));
            _dataRecorded.Add("LastNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enLastName"].ToString()) ? _dr["enLastName"].ToString() : String.Empty));
            _dataRecorded.Add("Gender", (_dr != null && !String.IsNullOrEmpty(_dr["perGenderId"].ToString()) ? _dr["perGenderId"].ToString() : String.Empty));
            _dataRecorded.Add("GenderFullNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thGenderFullName"].ToString()) ? _dr["thGenderFullName"].ToString() : String.Empty));
            _dataRecorded.Add("GenderFullNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enGenderFullName"].ToString()) ? _dr["enGenderFullName"].ToString() : String.Empty));
            _dataRecorded.Add("GenderInitialsTH", (_dr != null && !String.IsNullOrEmpty(_dr["thGenderInitials"].ToString()) ? _dr["thGenderInitials"].ToString() : String.Empty));
            _dataRecorded.Add("GenderInitialsEN", (_dr != null && !String.IsNullOrEmpty(_dr["enGenderInitials"].ToString()) ? _dr["enGenderInitials"].ToString() : String.Empty));
            _dataRecorded.Add("Alive", (_dr != null && !String.IsNullOrEmpty(_dr["alive"].ToString()) ? _dr["alive"].ToString() : String.Empty));
            _dataRecorded.Add("AliveTH", (_dr != null && !String.IsNullOrEmpty(_dr["thAlive"].ToString()) ? _dr["thAlive"].ToString() : String.Empty));
            _dataRecorded.Add("AliveEN", (_dr != null && !String.IsNullOrEmpty(_dr["enAlive"].ToString()) ? _dr["enAlive"].ToString() : String.Empty));
            _dataRecorded.Add("BirthdateTH", (_dr != null && !String.IsNullOrEmpty(_dr["thBirthDate"].ToString()) ? _dr["thBirthDate"].ToString() : String.Empty));
            _dataRecorded.Add("BirthDateEN", (_dr != null && !String.IsNullOrEmpty(_dr["enBirthDate"].ToString()) ? _dr["enBirthDate"].ToString() : String.Empty));                        
            _dataRecorded.Add("AgeYear", (_age.ContainsKey("Year").Equals(true) ? (!_age["Year"].Equals(0) ? _age["Year"].ToString() : String.Empty) : String.Empty));
            _dataRecorded.Add("AgeMonth", (_age.ContainsKey("Month").Equals(true) ? (!_age["Month"].Equals(0) ? _age["Month"].ToString() : String.Empty) : String.Empty));
            _dataRecorded.Add("AgeDay", (_age.ContainsKey("Day").Equals(true) ? (!_age["Day"].Equals(0) ? _age["Day"].ToString() : String.Empty) : String.Empty));
            _dataRecorded.Add("Country", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryId"].ToString()) ? _dr["plcCountryId"].ToString() : String.Empty));
            _dataRecorded.Add("CountryNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["countryNameTH"].ToString()) ? _dr["countryNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("CountryNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["countryNameEN"].ToString()) ? _dr["countryNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("Nationality", (_dr != null && !String.IsNullOrEmpty(_dr["perNationalityId"].ToString()) ? _dr["perNationalityId"].ToString() : String.Empty));
            _dataRecorded.Add("NationalityNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thNationalityName"].ToString()) ? _dr["thNationalityName"].ToString() : String.Empty));
            _dataRecorded.Add("NationalityNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enNationalityName"].ToString()) ? _dr["enNationalityName"].ToString() : String.Empty));
            _dataRecorded.Add("Race", (_dr != null && !String.IsNullOrEmpty(_dr["perOriginId"].ToString()) ? _dr["perOriginId"].ToString() : String.Empty));
            _dataRecorded.Add("RaceNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thOriginName"].ToString()) ? _dr["thOriginName"].ToString() : String.Empty));
            _dataRecorded.Add("RaceNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enOriginName"].ToString()) ? _dr["enOriginName"].ToString() : String.Empty));
            _dataRecorded.Add("Religion", (_dr != null && !String.IsNullOrEmpty(_dr["perReligionId"].ToString()) ? _dr["perReligionId"].ToString() : String.Empty));
            _dataRecorded.Add("ReligionNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thReligionName"].ToString()) ? _dr["thReligionName"].ToString() : String.Empty));
            _dataRecorded.Add("ReligionNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enReligionName"].ToString()) ? _dr["enReligionName"].ToString() : String.Empty));
            _dataRecorded.Add("BloodGroup", (_dr != null && !String.IsNullOrEmpty(_dr["perBloodTypeId"].ToString()) ? _dr["perBloodTypeId"].ToString() : String.Empty));
            _dataRecorded.Add("BloodGroupNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thBloodTypeName"].ToString()) ? _dr["thBloodTypeName"].ToString() : String.Empty));
            _dataRecorded.Add("BloodGroupNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enBloodTypeName"].ToString()) ? _dr["enBloodTypeName"].ToString() : String.Empty));
            _dataRecorded.Add("MaritalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["perMaritalStatusId"].ToString()) ? _dr["perMaritalStatusId"].ToString() : String.Empty));
            _dataRecorded.Add("MaritalStatusNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thMaritalStatusName"].ToString()) ? _dr["thMaritalStatusName"].ToString() : String.Empty));
            _dataRecorded.Add("MaritalStatusNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enMaritalStatusName"].ToString()) ? _dr["enMaritalStatusName"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundPerson", (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalBackgroundId"].ToString()) ? _dr["perEducationalBackgroundId"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundPersonNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thEducationalBackgroundName"].ToString()) ? _dr["thEducationalBackgroundName"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundPersonNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enEducationalBackgroundName"].ToString()) ? _dr["enEducationalBackgroundName"].ToString() : String.Empty));
            _dataRecorded.Add("EmailAddress", (_dr != null && !String.IsNullOrEmpty(_dr["email"].ToString()) ? _dr["email"] : String.Empty));
            _dataRecorded.Add("Brotherhood", (_dr != null && !String.IsNullOrEmpty(_dr["brotherhoodNumber"].ToString()) ? _dr["brotherhoodNumber"] : String.Empty));
            _dataRecorded.Add("Childhood", (_dr != null && !String.IsNullOrEmpty(_dr["childhoodNumber"].ToString()) ? _dr["childhoodNumber"] : String.Empty));
            _dataRecorded.Add("Studyhood", (_dr != null && !String.IsNullOrEmpty(_dr["studyhoodNumber"].ToString()) ? _dr["studyhoodNumber"] : String.Empty));

            return _dataRecorded;
        }
    }

    public class AddressUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {                
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];
      
            _dataRecorded.Add("CountryPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdPermanent"].ToString()) ? _dr["plcCountryIdPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("CountryNameTHPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["thCountryNamePermanent"].ToString()) ? _dr["thCountryNamePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("CountryNameENPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["enCountryNamePermanent"].ToString()) ? _dr["enCountryNamePermanent"].ToString() : String.Empty));            
            _dataRecorded.Add("ProvincePermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdPermanent"].ToString()) ? _dr["plcProvinceIdPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("ProvinceNameTHPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["thPlaceNamePermanent"].ToString()) ? _dr["thPlaceNamePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("ProvinceNameENPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["enPlaceNamePermanent"].ToString()) ? _dr["enPlaceNamePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcDistrictIdPermanent"].ToString()) ? _dr["plcDistrictIdPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictNameTHPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["thDistrictNamePermanent"].ToString()) ? _dr["thDistrictNamePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictNameENPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["enDistrictNamePermanent"].ToString()) ? _dr["enDistrictNamePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("PostalCodeDistrictPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeDistrictPermanent"].ToString()) ? _dr["zipCodeDistrictPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcSubdistrictIdPermanent"].ToString()) ? _dr["plcSubdistrictIdPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictNameTHPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["thSubdistrictNamePermanent"].ToString()) ? _dr["thSubdistrictNamePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictNameENPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["enSubdistrictNamePermanent"].ToString()) ? _dr["enSubdistrictNamePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("PostalCodePermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodePermanent"].ToString()) ? _dr["zipCodePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("VillagePermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["villagePermanent"].ToString()) ? _dr["villagePermanent"].ToString() : String.Empty));
            _dataRecorded.Add("AddressNumberPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["noPermanent"].ToString()) ? _dr["noPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("VillageNoPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["mooPermanent"].ToString()) ? _dr["mooPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("LaneAlleyPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["soiPermanent"].ToString()) ? _dr["soiPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("RoadPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["roadPermanent"].ToString()) ? _dr["roadPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("PhoneNumberPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["phoneNumberPermanent"].ToString()) ? _dr["phoneNumberPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("MobileNumberPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberPermanent"].ToString()) ? _dr["mobileNumberPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("FaxNumberPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["faxNumberPermanent"].ToString()) ? _dr["faxNumberPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("CountryCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdCurrent"].ToString()) ? _dr["plcCountryIdCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("CountryNameTHCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["thCountryNameCurrent"].ToString()) ? _dr["thCountryNameCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("CountryNameENCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["enCountryNameCurrent"].ToString()) ? _dr["enCountryNameCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("ProvinceCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdCurrent"].ToString()) ? _dr["plcProvinceIdCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("ProvinceNameTHCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["thPlaceNameCurrent"].ToString()) ? _dr["thPlaceNameCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("ProvinceNameENCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["enPlaceNameCurrent"].ToString()) ? _dr["enPlaceNameCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcDistrictIdCurrent"].ToString()) ? _dr["plcDistrictIdCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictNameTHCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["thDistrictNameCurrent"].ToString()) ? _dr["thDistrictNameCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictNameENCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["enDistrictNameCurrent"].ToString()) ? _dr["enDistrictNameCurrent"].ToString() : String.Empty));			
            _dataRecorded.Add("PostalCodeDistrictCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeDistrictCurrent"].ToString()) ? _dr["zipCodeDistrictCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcSubdistrictIdCurrent"].ToString()) ? _dr["plcSubdistrictIdCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictNameTHCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["thSubdistrictNameCurrent"].ToString()) ? _dr["thSubdistrictNameCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictNameENCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["enSubdistrictNameCurrent"].ToString()) ? _dr["enSubdistrictNameCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("PostalCodeCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeCurrent"].ToString()) ? _dr["zipCodeCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("VillageCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["villageCurrent"].ToString()) ? _dr["villageCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("AddressNumberCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["noCurrent"].ToString()) ? _dr["noCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("VillageNoCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["mooCurrent"].ToString()) ? _dr["mooCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("LaneAlleyCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["soiCurrent"].ToString()) ? _dr["soiCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("RoadCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["roadCurrent"].ToString()) ? _dr["roadCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("PhoneNumberCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["phoneNumberCurrent"].ToString()) ? _dr["phoneNumberCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("MobileNumberCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberCurrent"].ToString()) ? _dr["mobileNumberCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("FaxNumberCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["faxNumberCurrent"].ToString()) ? _dr["faxNumberCurrent"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class EducationUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _dataRecorded.Add("InstituteNamePrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["primarySchoolName"].ToString()) ? _dr["primarySchoolName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdPrimarySchool"].ToString()) ? _dr["plcCountryIdPrimarySchool"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryNameTHPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["thPrimarySchoolCountryName"].ToString()) ? _dr["thPrimarySchoolCountryName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryNameENPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["enPrimarySchoolCountryName"].ToString()) ? _dr["enPrimarySchoolCountryName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvincePrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdPrimarySchool"].ToString()) ? _dr["plcProvinceIdPrimarySchool"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceNameTHPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["thPrimarySchoolPlaceName"].ToString()) ? _dr["thPrimarySchoolPlaceName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceNameENPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["enPrimarySchoolPlaceName"].ToString()) ? _dr["enPrimarySchoolPlaceName"].ToString() : String.Empty));
            _dataRecorded.Add("YearAttendedPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["primarySchoolYearAttended"].ToString()) ? _dr["primarySchoolYearAttended"].ToString() : String.Empty));
            _dataRecorded.Add("YearGraduatePrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["primarySchoolYearGraduate"].ToString()) ? _dr["primarySchoolYearGraduate"].ToString() : String.Empty));
            _dataRecorded.Add("GPAPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["primarySchoolGPA"].ToString()) ? _dr["primarySchoolGPA"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteNameJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["juniorHighSchoolName"].ToString()) ? _dr["juniorHighSchoolName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdJuniorHighSchool"].ToString()) ? _dr["plcCountryIdJuniorHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryNameTHJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["thJuniorHighSchoolCountryName"].ToString()) ? _dr["thJuniorHighSchoolCountryName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryNameENJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["enJuniorHighSchoolCountryName"].ToString()) ? _dr["enJuniorHighSchoolCountryName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdJuniorHighSchool"].ToString()) ? _dr["plcProvinceIdJuniorHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceNameTHJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["thJuniorHighSchoolPlaceName"].ToString()) ? _dr["thJuniorHighSchoolPlaceName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceNameENJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["enJuniorHighSchoolPlaceName"].ToString()) ? _dr["enJuniorHighSchoolPlaceName"].ToString() : String.Empty));
            _dataRecorded.Add("YearAttendedJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["juniorHighSchoolYearAttended"].ToString()) ? _dr["juniorHighSchoolYearAttended"].ToString() : String.Empty));
            _dataRecorded.Add("YearGraduateJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["juniorHighSchoolYearGraduate"].ToString()) ? _dr["juniorHighSchoolYearGraduate"].ToString() : String.Empty));
            _dataRecorded.Add("GPAJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["juniorHighSchoolGPA"].ToString()) ? _dr["juniorHighSchoolGPA"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteNameHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolName"].ToString()) ? _dr["highSchoolName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdHighSchool"].ToString()) ? _dr["plcCountryIdHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryNameTHHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["thHighSchoolCountryName"].ToString()) ? _dr["thHighSchoolCountryName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryNameENHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["enHighSchoolCountryName"].ToString()) ? _dr["enHighSchoolCountryName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdHighSchool"].ToString()) ? _dr["plcProvinceIdHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceNameTHHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["thHighSchoolPlaceName"].ToString()) ? _dr["thHighSchoolPlaceName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceNameENHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["enHighSchoolPlaceName"].ToString()) ? _dr["enHighSchoolPlaceName"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIdHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolStudentId"].ToString()) ? _dr["highSchoolStudentId"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalMajorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalMajorIdHighSchool"].ToString()) ? _dr["perEducationalMajorIdHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalMajorNameTHHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["thHighSchoolEducationalMajorName"].ToString()) ? _dr["thHighSchoolEducationalMajorName"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalMajorNameENHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["enHighSchoolEducationalMajorName"].ToString()) ? _dr["enHighSchoolEducationalMajorName"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalMajorOtherHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["educationalMajorOtherHighSchool"].ToString()) ? _dr["educationalMajorOtherHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("YearAttendedHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolYearAttended"].ToString()) ? _dr["highSchoolYearAttended"].ToString() : String.Empty));
            _dataRecorded.Add("YearGraduateHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolYearGraduate"].ToString()) ? _dr["highSchoolYearGraduate"].ToString() : String.Empty));
            _dataRecorded.Add("GPAHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolGPA"].ToString()) ? _dr["highSchoolGPA"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalBackgroundIdHighSchool"].ToString()) ? _dr["perEducationalBackgroundIdHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundNameTHHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["thHighSchoolEducationalBackgroundName"].ToString()) ? _dr["thHighSchoolEducationalBackgroundName"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundNameENHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["enHighSchoolEducationalBackgroundName"].ToString()) ? _dr["enHighSchoolEducationalBackgroundName"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackground", (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalBackgroundId"].ToString()) ? _dr["perEducationalBackgroundId"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thEducationalBackgroundName"].ToString()) ? _dr["thEducationalBackgroundName"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enEducationalBackgroundName"].ToString()) ? _dr["enEducationalBackgroundName"].ToString() : String.Empty));
            _dataRecorded.Add("GraduateBy", (_dr != null && !String.IsNullOrEmpty(_dr["graduateBy"].ToString()) ? _dr["graduateBy"].ToString() :String.Empty));
            _dataRecorded.Add("GraduateByTH", (_dr != null && !String.IsNullOrEmpty(_dr["thGraduateBy"].ToString()) ? _dr["thGraduateBy"].ToString() :String.Empty));
            _dataRecorded.Add("GraduateByEN", (_dr != null && !String.IsNullOrEmpty(_dr["enGraduateBy"].ToString()) ? _dr["enGraduateBy"].ToString() :String.Empty));
            _dataRecorded.Add("GraduateByInstituteName", (_dr != null && !String.IsNullOrEmpty(_dr["graduateBySchoolName"].ToString()) ? _dr["graduateBySchoolName"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTime", (_dr != null && !String.IsNullOrEmpty(_dr["entranceTime"].ToString()) ? _dr["entranceTime"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTimeTH", (_dr != null && !String.IsNullOrEmpty(_dr["thEntranceTime"].ToString()) ? _dr["thEntranceTime"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTimeEN", (_dr != null && !String.IsNullOrEmpty(_dr["enEntranceTime"].ToString()) ? _dr["enEntranceTime"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIs", (_dr != null && !String.IsNullOrEmpty(_dr["studentIs"].ToString()) ? _dr["studentIs"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIsTH", (_dr != null && !String.IsNullOrEmpty(_dr["thStudentIs"].ToString()) ? _dr["thStudentIs"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIsEN", (_dr != null && !String.IsNullOrEmpty(_dr["enStudentIs"].ToString()) ? _dr["enStudentIs"].ToString() : String.Empty));		
            _dataRecorded.Add("StudentIsUniversity", (_dr != null && !String.IsNullOrEmpty(_dr["studentIsUniversity"].ToString()) ? _dr["studentIsUniversity"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIsFaculty", (_dr != null && !String.IsNullOrEmpty(_dr["studentIsFaculty"].ToString()) ? _dr["studentIsFaculty"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIsProgram", (_dr != null && !String.IsNullOrEmpty(_dr["studentIsProgram"].ToString()) ? _dr["studentIsProgram"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceType", (_dr != null && !String.IsNullOrEmpty(_dr["perEntranceTypeId"].ToString()) ? _dr["perEntranceTypeId"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTypeNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["entranceTypeNameTH"].ToString()) ? _dr["entranceTypeNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTypeNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["entranceTypeNameEN"].ToString()) ? _dr["entranceTypeNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("AdmissionRanking", (_dr != null && !String.IsNullOrEmpty(_dr["admissionRanking"].ToString()) ? _dr["admissionRanking"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETThai", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET01"].ToString()) ? _dr["scoreONET01"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETThaiNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreONET01Name"].ToString()) ? _dr["thScoreONET01Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETThaiNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreONET01Name"].ToString()) ? _dr["enScoreONET01Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETSocialScience", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET02"].ToString()) ? _dr["scoreONET02"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETSocialScienceNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreONET02Name"].ToString()) ? _dr["thScoreONET02Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETSocialScienceNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreONET02Name"].ToString()) ? _dr["enScoreONET02Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETEnglish", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET03"].ToString()) ? _dr["scoreONET03"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETEnglishNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreONET03Name"].ToString()) ? _dr["thScoreONET03Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETEnglishNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreONET03Name"].ToString()) ? _dr["enScoreONET03Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETMathematics", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET04"].ToString()) ? _dr["scoreONET04"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETMathematicsNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreONET04Name"].ToString()) ? _dr["thScoreONET04Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETMathematicsNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreONET04Name"].ToString()) ? _dr["enScoreONET04Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETScience", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET05"].ToString()) ? _dr["scoreONET05"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETScienceNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreONET05Name"].ToString()) ? _dr["thScoreONET05Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETScienceNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreONET05Name"].ToString()) ? _dr["enScoreONET05Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETHealthPhysical", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET06"].ToString()) ? _dr["scoreONET06"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETHealthPhysicalNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreONET06Name"].ToString()) ? _dr["thScoreONET06Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETHealthPhysicalNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreONET06Name"].ToString()) ? _dr["enScoreONET06Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETArts", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET07"].ToString()) ? _dr["scoreONET07"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETArtsNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreONET07Name"].ToString()) ? _dr["thScoreONET07Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETArtsNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreONET07Name"].ToString()) ? _dr["enScoreONET07Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETOccupationTechnology", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET08"].ToString()) ? _dr["scoreONET08"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETOccupationTechnologyNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreONET08Name"].ToString()) ? _dr["thScoreONET08Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETOccupationTechnologyNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreONET08Name"].ToString()) ? _dr["enScoreONET08Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETThai2", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET11"].ToString()) ? _dr["scoreANET11"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETThai2NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreANET11Name"].ToString()) ? _dr["thScoreANET11Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETThai2NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreANET11Name"].ToString()) ? _dr["enScoreANET11Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETSocialScience2", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET12"].ToString()) ? _dr["scoreANET12"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETSocialScience2NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreANET12Name"].ToString()) ? _dr["thScoreANET12Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETSocialScience2NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreANET12Name"].ToString()) ? _dr["enScoreANET12Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETEnglish3", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET13"].ToString()) ? _dr["scoreANET13"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETEnglish3NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreANET13Name"].ToString()) ? _dr["thScoreANET13Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETEnglish3NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreANET13Name"].ToString()) ? _dr["enScoreANET13Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETMathematics2", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET14"].ToString()) ? _dr["scoreANET14"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETMathematics2NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreANET14Name"].ToString()) ? _dr["thScoreANET14Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETMathematics2NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreANET14Name"].ToString()) ? _dr["enScoreANET14Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETScience2", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET15"].ToString()) ? _dr["scoreANET15"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETScience2NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreANET15Name"].ToString()) ? _dr["thScoreANET15Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETScience2NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreANET15Name"].ToString()) ? _dr["enScoreANET15Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresGATGenaralAptitudeTest", (_dr != null && !String.IsNullOrEmpty(_dr["scoreGAT85"].ToString()) ? _dr["scoreGAT85"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresGATGenaralAptitudeTestNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScoreGAT85Name"].ToString()) ? _dr["thScoreGAT85Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresGATGenaralAptitudeTestNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScoreGAT85Name"].ToString()) ? _dr["enScoreGAT85Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT1", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT71"].ToString()) ? _dr["scorePAT71"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT1NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT71Name"].ToString()) ? _dr["thScorePAT71Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT1NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT71Name"].ToString()) ? _dr["enScorePAT71Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT2", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT72"].ToString()) ? _dr["scorePAT72"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT2NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT72Name"].ToString()) ? _dr["thScorePAT72Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT2NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT72Name"].ToString()) ? _dr["enScorePAT72Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT3", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT73"].ToString()) ? _dr["scorePAT73"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT3NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT73Name"].ToString()) ? _dr["thScorePAT73Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT3NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT73Name"].ToString()) ? _dr["enScorePAT73Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT4", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT74"].ToString()) ? _dr["scorePAT74"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT4NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT74Name"].ToString()) ? _dr["thScorePAT74Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT4NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT74Name"].ToString()) ? _dr["enScorePAT74Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT5", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT75"].ToString()) ? _dr["scorePAT75"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT5NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT75Name"].ToString()) ? _dr["thScorePAT75Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT5NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT75Name"].ToString()) ? _dr["enScorePAT75Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT6", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT76"].ToString()) ? _dr["scorePAT76"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT6NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT76Name"].ToString()) ? _dr["thScorePAT76Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT6NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT76Name"].ToString()) ? _dr["enScorePAT76Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT7", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT77"].ToString()) ? _dr["scorePAT77"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT7NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT77Name"].ToString()) ? _dr["thScorePAT77Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT7NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT77Name"].ToString()) ? _dr["enScorePAT77Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT8", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT78"].ToString()) ? _dr["scorePAT78"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT8NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT78Name"].ToString()) ? _dr["enScorePAT78Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT8NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT78Name"].ToString()) ? _dr["enScorePAT78Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT9", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT79"].ToString()) ? _dr["scorePAT79"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT9NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT79Name"].ToString()) ? _dr["thScorePAT79Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT9NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT79Name"].ToString()) ? _dr["enScorePAT79Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT10", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT80"].ToString()) ? _dr["scorePAT80"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT10NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT80Name"].ToString()) ? _dr["thScorePAT80Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT10NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT80Name"].ToString()) ? _dr["enScorePAT80Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT11", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT81"].ToString()) ? _dr["scorePAT81"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT11NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT81Name"].ToString()) ? _dr["thScorePAT81Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT11NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT81Name"].ToString()) ? _dr["enScorePAT81Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT12", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT82"].ToString()) ? _dr["scorePAT82"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT12NameTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScorePAT82Name"].ToString()) ? _dr["thScorePAT82Name"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT12NameEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScorePAT82Name"].ToString()) ? _dr["enScorePAT82Name"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class TalentUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _dataRecorded.Add("SportsmanStatus", (_dr != null && !String.IsNullOrEmpty(_dr["sportsman"].ToString()) ? _dr["sportsman"].ToString() : String.Empty));
            _dataRecorded.Add("SportsmanDetail", (_dr != null && !String.IsNullOrEmpty(_dr["sportsmanDetail"].ToString()) ? _dr["sportsmanDetail"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistStatus", (_dr != null && !String.IsNullOrEmpty(_dr["specialist"].ToString()) ? _dr["specialist"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistSportStatus", (_dr != null && !String.IsNullOrEmpty(_dr["specialistSport"].ToString()) ? _dr["specialistSport"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistSportDetail", (_dr != null && !String.IsNullOrEmpty(_dr["specialistSportDetail"].ToString()) ? _dr["specialistSportDetail"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistArtStatus", (_dr != null && !String.IsNullOrEmpty(_dr["specialistArt"].ToString()) ? _dr["specialistArt"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistArtDetail", (_dr != null && !String.IsNullOrEmpty(_dr["specialistArtDetail"].ToString()) ? _dr["specialistArtDetail"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistTechnicalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["specialistTechnical"].ToString()) ? _dr["specialistTechnical"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistTechnicalDetail", (_dr != null && !String.IsNullOrEmpty(_dr["specialistTechnicalDetail"].ToString()) ? _dr["specialistTechnicalDetail"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistOtherStatus", (_dr != null && !String.IsNullOrEmpty(_dr["specialistOther"].ToString()) ? _dr["specialistOther"].ToString() : String.Empty));
            _dataRecorded.Add("SpecialistOtherDetail", (_dr != null && !String.IsNullOrEmpty(_dr["specialistOtherDetail"].ToString()) ? _dr["specialistOtherDetail"].ToString() : String.Empty));
            _dataRecorded.Add("ActivityStatus", (_dr != null && !String.IsNullOrEmpty(_dr["activity"].ToString()) ? _dr["activity"].ToString() : String.Empty));
            _dataRecorded.Add("ActivityDetail", (_dr != null && !String.IsNullOrEmpty(_dr["activityDetail"].ToString()) ? _dr["activityDetail"].ToString() : String.Empty));
            _dataRecorded.Add("RewardStatus", (_dr != null && !String.IsNullOrEmpty(_dr["reward"].ToString()) ? _dr["reward"].ToString() : String.Empty));
            _dataRecorded.Add("RewardDetail", (_dr != null && !String.IsNullOrEmpty(_dr["rewardDetail"].ToString()) ? _dr["rewardDetail"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class HealthyUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _dataRecorded.Add("BodyMassDetail", (_dr != null && !String.IsNullOrEmpty(_dr["bodyMassDetail"].ToString()) ? _dr["bodyMassDetail"].ToString() : String.Empty));
            _dataRecorded.Add("IntoleranceStatus", (_dr != null && !String.IsNullOrEmpty(_dr["intolerance"].ToString()) ? _dr["intolerance"].ToString() : String.Empty));
            _dataRecorded.Add("IntoleranceDetail", (_dr != null && !String.IsNullOrEmpty(_dr["intoleranceDetail"].ToString()) ? _dr["intoleranceDetail"].ToString() : String.Empty));
            _dataRecorded.Add("DiseasesStatus", (_dr != null && !String.IsNullOrEmpty(_dr["diseases"].ToString()) ? _dr["diseases"].ToString() : String.Empty));
            _dataRecorded.Add("DiseasesDetail", (_dr != null && !String.IsNullOrEmpty(_dr["diseasesDetail"].ToString()) ? _dr["diseasesDetail"].ToString() : String.Empty));
            _dataRecorded.Add("AilHistoryFamilyStatus", (_dr != null && !String.IsNullOrEmpty(_dr["ailHistoryFamily"].ToString()) ? _dr["ailHistoryFamily"].ToString() : String.Empty));
            _dataRecorded.Add("AilHistoryFamilyDetail", (_dr != null && !String.IsNullOrEmpty(_dr["ailHistoryFamilyDetail"].ToString()) ? _dr["ailHistoryFamilyDetail"].ToString() : String.Empty));
            _dataRecorded.Add("TravelAbroadStatus", (_dr != null && !String.IsNullOrEmpty(_dr["travelAbroad"].ToString()) ? _dr["travelAbroad"].ToString() : String.Empty));
            _dataRecorded.Add("TravelAbroadDetail", (_dr != null && !String.IsNullOrEmpty(_dr["travelAbroadDetail"].ToString()) ? _dr["travelAbroadDetail"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsStatus", (_dr != null && !String.IsNullOrEmpty(_dr["impairments"].ToString()) ? _dr["impairments"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsDetail", (_dr != null && !String.IsNullOrEmpty(_dr["perImpairmentsId"].ToString()) ? _dr["perImpairmentsId"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["impairmentsNameTH"].ToString()) ? _dr["impairmentsNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["impairmentsNameEN"].ToString()) ? _dr["impairmentsNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("ImpairmentsEquipment", (_dr != null && !String.IsNullOrEmpty(_dr["impairmentsEquipment"].ToString()) ? _dr["impairmentsEquipment"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardPWD", (_dr != null && !String.IsNullOrEmpty(_dr["idCardPWD"].ToString()) ? _dr["idCardPWD"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardPWDIssueDateTH", (_dr != null && !String.IsNullOrEmpty(_dr["thIdCardPWDIssueDate"].ToString()) ? _dr["thIdCardPWDIssueDate"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardPWDIssueDateEN", (_dr != null && !String.IsNullOrEmpty(_dr["enIdCardPWDIssueDate"].ToString()) ? _dr["enIdCardPWDIssueDate"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardPWDExpiryDateTH", (_dr != null && !String.IsNullOrEmpty(_dr["thIdCardPWDExpiryDate"].ToString()) ? _dr["thIdCardPWDExpiryDate"].ToString() : String.Empty));
            _dataRecorded.Add("IdCardPWDExpiryDateEN", (_dr != null && !String.IsNullOrEmpty(_dr["enIdCardPWDExpiryDate"].ToString()) ? _dr["enIdCardPWDExpiryDate"].ToString() : String.Empty));

            return _dataRecorded;
        }

        public class BodyMassIndexUtil
        {
            public static DataTable SetValueDataRecorded(string _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                DataTable _dt = new DataTable();

                if (!String.IsNullOrEmpty(_valueDataRecorded))
                {
                    Dictionary<string, object> _dtContent = new Dictionary<string, object>();
                    string[] _dtColumn = new string[4];

                    _dtColumn[0] = "string";
                    _dtColumn[1] = "string";
                    _dtColumn[2] = "string";
                    _dtColumn[3] = "datetime";

                    _dtContent.Add("Data", _valueDataRecorded);
                    _dtContent.Add("SeparatorRow", ';');
                    _dtContent.Add("Column", _dtColumn);
                    _dtContent.Add("SeparatorColumn", ':');

                    _dt = ePFStaffUtil.StringArrayToDataTable(_dtContent);
                }

                return _dt;
            }
        }

        public class TravelAbroadUtil
        {
            public static DataTable SetValueDataRecorded(string _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                DataTable _dt = new DataTable();

                if (!String.IsNullOrEmpty(_valueDataRecorded))
                {
                    Dictionary<string, object> _dtContent = new Dictionary<string, object>();
                    string[] _dtColumn = new string[2];

                    _dtColumn[0] = "string";
                    _dtColumn[1] = "datetime";

                    _dtContent.Add("Data", _valueDataRecorded);
                    _dtContent.Add("SeparatorRow", ';');
                    _dtContent.Add("Column", _dtColumn);
                    _dtContent.Add("SeparatorColumn", ',');

                    _dt = ePFStaffUtil.StringArrayToDataTable(_dtContent);
                }

                return _dt;
            }
        }
    }

    public class WorkUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _dataRecorded.Add("Occupation", (_dr != null && !String.IsNullOrEmpty(_dr["occupation"].ToString()) ? _dr["occupation"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationTH", (_dr != null && !String.IsNullOrEmpty(_dr["thOccupation"].ToString()) ? _dr["thOccupation"].ToString() : String.Empty));
            _dataRecorded.Add("OccupationEN", (_dr != null && !String.IsNullOrEmpty(_dr["enOccupation"].ToString()) ? _dr["enOccupation"].ToString() : String.Empty));
            _dataRecorded.Add("Agency", (_dr != null && !String.IsNullOrEmpty(_dr["perAgencyId"].ToString()) ? _dr["perAgencyId"].ToString() : String.Empty));
            _dataRecorded.Add("AgencyNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["agencyNameTH"].ToString()) ? _dr["agencyNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("AgencyNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["agencyNameEN"].ToString()) ? _dr["agencyNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("AgencyOther", (_dr != null && !String.IsNullOrEmpty(_dr["agencyOther"].ToString()) ? _dr["agencyOther"].ToString() : String.Empty));
            _dataRecorded.Add("Workplace", (_dr != null && !String.IsNullOrEmpty(_dr["workplace"].ToString()) ? _dr["workplace"].ToString() : String.Empty));
            _dataRecorded.Add("Position", (_dr != null && !String.IsNullOrEmpty(_dr["position"].ToString()) ? _dr["position"].ToString() : String.Empty));
            _dataRecorded.Add("Telephone", (_dr != null && !String.IsNullOrEmpty(_dr["telephone"].ToString()) ? _dr["telephone"].ToString() : String.Empty));
            _dataRecorded.Add("Salary", (_dr != null && !String.IsNullOrEmpty(_dr["salary"].ToString()) ? _dr["salary"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class FinancialUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _dataRecorded.Add("ScholarshipFirstBachelor", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipFirstBachelor"].ToString()) ? _dr["scholarshipFirstBachelor"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipFirstBachelorFrom", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipFirstBachelorFrom"].ToString()) ? _dr["scholarshipFirstBachelorFrom"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipFirstBachelorFromTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScholarshipFirstBachelorFrom"].ToString()) ? _dr["thScholarshipFirstBachelorFrom"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipFirstBachelorFromEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScholarshipFirstBachelorFrom"].ToString()) ? _dr["enScholarshipFirstBachelorFrom"].ToString() : String.Empty));            
            _dataRecorded.Add("ScholarshipFirstBachelorName", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipFirstBachelorName"].ToString()) ? _dr["scholarshipFirstBachelorName"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipFirstBachelorMoney", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipFirstBachelorMoney"].ToString()) ? _dr["scholarshipFirstBachelorMoney"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelor", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipBachelor"].ToString()) ? _dr["scholarshipBachelor"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelorFrom", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipBachelorFrom"].ToString()) ? _dr["scholarshipBachelorFrom"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelorFromTH", (_dr != null && !String.IsNullOrEmpty(_dr["thScholarshipBachelorFrom"].ToString()) ? _dr["thScholarshipBachelorFrom"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelorFromEN", (_dr != null && !String.IsNullOrEmpty(_dr["enScholarshipBachelorFrom"].ToString()) ? _dr["enScholarshipBachelorFrom"].ToString() : String.Empty));            
            _dataRecorded.Add("ScholarshipBachelorName", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipBachelorName"].ToString()) ? _dr["scholarshipBachelorName"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelorMoney", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipBachelorMoney"].ToString()) ? _dr["scholarshipBachelorMoney"].ToString() : String.Empty));
            _dataRecorded.Add("Worked", (_dr != null && !String.IsNullOrEmpty(_dr["worked"].ToString()) ? _dr["worked"].ToString() : String.Empty));
            _dataRecorded.Add("Salary", (_dr != null && !String.IsNullOrEmpty(_dr["salary"].ToString()) ? _dr["salary"].ToString() : String.Empty));
            _dataRecorded.Add("Workplace", (_dr != null && !String.IsNullOrEmpty(_dr["workplace"].ToString()) ? _dr["workplace"].ToString() : String.Empty));
            _dataRecorded.Add("GotMoneyFrom", (_dr != null && !String.IsNullOrEmpty(_dr["gotMoneyFrom"].ToString()) ? _dr["gotMoneyFrom"].ToString() : String.Empty));
            _dataRecorded.Add("GotMoneyFromTH", (_dr != null && !String.IsNullOrEmpty(_dr["thGotMoneyFrom"].ToString()) ? _dr["thGotMoneyFrom"].ToString() : String.Empty));
            _dataRecorded.Add("GotMoneyFromEN", (_dr != null && !String.IsNullOrEmpty(_dr["enGotMoneyFrom"].ToString()) ? _dr["enGotMoneyFrom"].ToString() : String.Empty));
            _dataRecorded.Add("GotMoneyFromOther", (_dr != null && !String.IsNullOrEmpty(_dr["gotMoneyFromOther"].ToString()) ? _dr["gotMoneyFromOther"].ToString() : String.Empty));
            _dataRecorded.Add("GotMoneyPerMonth", (_dr != null && !String.IsNullOrEmpty(_dr["gotMoneyPerMonth"].ToString()) ? _dr["gotMoneyPerMonth"].ToString() : String.Empty));
            _dataRecorded.Add("CostPerMonth", (_dr != null && !String.IsNullOrEmpty(_dr["costPerMonth"].ToString()) ? _dr["costPerMonth"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class FamilyUtil
    {
        public class PersonalUtil
        {
            public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds, string _familyRelation)
            {
                Dictionary<string, object> _age = new Dictionary<string, object>();
                DataRow _dr = null;

                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[0].Rows[0];

                _familyRelation = Util.UppercaseFirst(_familyRelation);

                if (_familyRelation.Equals(ePFStaffUtil.SUBJECT_FAMILYPARENT))
                {
                    _dataRecorded.Add("Relationship", (_dr != null && !String.IsNullOrEmpty(_dr["perRelationshipId"].ToString()) ? _dr["perRelationshipId"].ToString() : String.Empty));
                    _dataRecorded.Add("RelationshipNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["relationshipNameEN"].ToString()) ? _dr["relationshipNameEN"].ToString() : String.Empty));
                    _dataRecorded.Add("RelationshipNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["relationshipNameTH"].ToString()) ? _dr["relationshipNameTH"].ToString() : String.Empty));
                    _dataRecorded.Add("GenderRelationship", (_dr != null && !String.IsNullOrEmpty(_dr["perGenderIdRelationship"].ToString()) ? _dr["perGenderIdRelationship"].ToString() : String.Empty));
                }

                if (_dr != null && !String.IsNullOrEmpty(_dr["enBirthDate" + _familyRelation].ToString()))
                    _age = ePFStaffUtil.CalAge(_dr["enBirthDate" + _familyRelation].ToString(), Util.CurrentDate("dd/MM/yyyy"));

                _dataRecorded.Add(("PersonId" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perPersonId" + _familyRelation].ToString()) ? _dr["perPersonId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("IdCard" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["idCard" + _familyRelation].ToString()) ? _dr["idCard" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("TitlePrefix" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perTitlePrefixId" + _familyRelation].ToString()) ? _dr["perTitlePrefixId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("TitleInitialsTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thTitleInitials" + _familyRelation].ToString()) ? _dr["thTitleInitials" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("TitleInitialsEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enTitleInitials" + _familyRelation].ToString()) ? _dr["enTitleInitials" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("TitleFullNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thTitleFullName" + _familyRelation].ToString()) ? _dr["thTitleFullName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("TitleFullNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enTitleFullName" + _familyRelation].ToString()) ? _dr["enTitleFullName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("GenderTitlePrefix" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perGenderIdTitlePrefix" + _familyRelation].ToString()) ? _dr["perGenderIdTitlePrefix" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("FirstName" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["firstName" + _familyRelation].ToString()) ? _dr["firstName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MiddleName" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["middleName" + _familyRelation].ToString()) ? _dr["middleName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("LastName" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["lastName" + _familyRelation].ToString()) ? _dr["lastName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("FirstNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enFirstName" + _familyRelation].ToString()) ? _dr["enFirstName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MiddleNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enMiddleName" + _familyRelation].ToString()) ? _dr["enMiddleName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("LastNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enLastName" + _familyRelation].ToString()) ? _dr["enLastName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Gender" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perGenderId" + _familyRelation].ToString()) ? _dr["perGenderId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Alive" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["alive" + _familyRelation].ToString()) ? _dr["alive" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AliveTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thAlive" + _familyRelation].ToString()) ? _dr["thAlive" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AliveEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enAlive" + _familyRelation].ToString()) ? _dr["enAlive" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("BirthdateTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thBirthDate" + _familyRelation].ToString()) ? _dr["thBirthDate" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("BirthDateEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enBirthDate" + _familyRelation].ToString()) ? _dr["enBirthDate" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AgeYear" + _familyRelation), (_age.ContainsKey("Year").Equals(true) ? (!_age["Year"].Equals(0) ? _age["Year"].ToString() : String.Empty) : String.Empty));
                _dataRecorded.Add(("AgeMonth" + _familyRelation), (_age.ContainsKey("Month").Equals(true) ? (!_age["Month"].Equals(0) ? _age["Month"].ToString() : String.Empty) : String.Empty));
                _dataRecorded.Add(("AgeDay" + _familyRelation), (_age.ContainsKey("Day").Equals(true) ? (!_age["Day"].Equals(0) ? _age["Day"].ToString() : String.Empty) : String.Empty));
                _dataRecorded.Add(("Country" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryId" + _familyRelation].ToString()) ? _dr["plcCountryId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("CountryNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thCountryName" + _familyRelation].ToString()) ? _dr["thCountryName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("CountryNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enCountryName" + _familyRelation].ToString()) ? _dr["enCountryName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Nationality" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perNationalityId" + _familyRelation].ToString()) ? _dr["perNationalityId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("NationalityNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thNationalityName" + _familyRelation].ToString()) ? _dr["thNationalityName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("NationalityNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enNationalityName" + _familyRelation].ToString()) ? _dr["enNationalityName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Race" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perOriginId" + _familyRelation].ToString()) ? _dr["perOriginId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("RaceNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thOriginName" + _familyRelation].ToString()) ? _dr["thOriginName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("RaceNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enOriginName" + _familyRelation].ToString()) ? _dr["enOriginName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Religion" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perReligionId" + _familyRelation].ToString()) ? _dr["perReligionId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("ReligionNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thReligionName" + _familyRelation].ToString()) ? _dr["thReligionName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("ReligionNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enReligionName" + _familyRelation].ToString()) ? _dr["enReligionName" + _familyRelation].ToString() : String.Empty));                
                _dataRecorded.Add(("BloodGroup" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perBloodTypeId" + _familyRelation].ToString()) ? _dr["perBloodTypeId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("BloodGroupNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thBloodTypeName" + _familyRelation].ToString()) ? _dr["thBloodTypeName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("BloodGroupNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enBloodTypeName" + _familyRelation].ToString()) ? _dr["enBloodTypeName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MaritalStatus" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perMaritalStatusId" + _familyRelation].ToString()) ? _dr["perMaritalStatusId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MaritalStatusNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thMaritalStatusName" + _familyRelation].ToString()) ? _dr["thMaritalStatusName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MaritalStatusNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enMaritalStatusName" + _familyRelation].ToString()) ? _dr["enMaritalStatusName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("EducationalBackgroundPerson" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalBackgroundId" + _familyRelation].ToString()) ? _dr["perEducationalBackgroundId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("EducationalBackgroundPersonNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thEducationalBackgroundName" + _familyRelation].ToString()) ? _dr["thEducationalBackgroundName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("EducationalBackgroundPersonNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enEducationalBackgroundName" + _familyRelation].ToString()) ? _dr["enEducationalBackgroundName" + _familyRelation].ToString() : String.Empty));

                return _dataRecorded;
            }
        }

        public class AddressUtil
        {
            public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds, string _familyRelation)
            {
                DataRow _dr = null;

                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[1].Rows[0];

                _familyRelation = Util.UppercaseFirst(_familyRelation);

                _dataRecorded.Add(("CountryPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdPermanent" + _familyRelation].ToString()) ? _dr["plcCountryIdPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("CountryNameTHPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thCountryNamePermanent" + _familyRelation].ToString()) ? _dr["thCountryNamePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("CountryNameENPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enCountryNamePermanent" + _familyRelation].ToString()) ? _dr["enCountryNamePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("ProvincePermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdPermanent" + _familyRelation].ToString()) ? _dr["plcProvinceIdPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("ProvinceNameTHPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thPlaceNamePermanent" + _familyRelation].ToString()) ? _dr["thPlaceNamePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("ProvinceNameENPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enPlaceNamePermanent" + _familyRelation].ToString()) ? _dr["enPlaceNamePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("DistrictPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcDistrictIdPermanent" + _familyRelation].ToString()) ? _dr["plcDistrictIdPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("DistrictNameTHPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thDistrictNamePermanent" + _familyRelation].ToString()) ? _dr["thDistrictNamePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("DistrictNameENPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enDistrictNamePermanent" + _familyRelation].ToString()) ? _dr["enDistrictNamePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("PostalCodeDistrictPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeDistrictPermanent" + _familyRelation].ToString()) ? _dr["zipCodeDistrictPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("SubDistrictPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcSubdistrictIdPermanent" + _familyRelation].ToString()) ? _dr["plcSubdistrictIdPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("SubDistrictNameTHPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thSubdistrictNamePermanent" + _familyRelation].ToString()) ? _dr["thSubdistrictNamePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("SubDistrictNameENPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enSubdistrictNamePermanent" + _familyRelation].ToString()) ? _dr["enSubdistrictNamePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("PostalCodePermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["zipCodePermanent" + _familyRelation].ToString()) ? _dr["zipCodePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("VillagePermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["villagePermanent" + _familyRelation].ToString()) ? _dr["villagePermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AddressNumberPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["noPermanent" + _familyRelation].ToString()) ? _dr["noPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("VillageNoPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["mooPermanent" + _familyRelation].ToString()) ? _dr["mooPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("LaneAlleyPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["soiPermanent" + _familyRelation].ToString()) ? _dr["soiPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("RoadPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["roadPermanent" + _familyRelation].ToString()) ? _dr["roadPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("PhoneNumberPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["phoneNumberPermanent" + _familyRelation].ToString()) ? _dr["phoneNumberPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MobileNumberPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberPermanent" + _familyRelation].ToString()) ? _dr["mobileNumberPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("FaxNumberPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["faxNumberPermanent" + _familyRelation].ToString()) ? _dr["faxNumberPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("CountryCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdCurrent" + _familyRelation].ToString()) ? _dr["plcCountryIdCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("CountryNameTHCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thCountryNameCurrent" + _familyRelation].ToString()) ? _dr["thCountryNameCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("CountryNameENCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enCountryNameCurrent" + _familyRelation].ToString()) ? _dr["enCountryNameCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("ProvinceCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdCurrent" + _familyRelation].ToString()) ? _dr["plcProvinceIdCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("ProvinceNameTHCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thPlaceNameCurrent" + _familyRelation].ToString()) ? _dr["thPlaceNameCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("ProvinceNameENCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enPlaceNameCurrent" + _familyRelation].ToString()) ? _dr["enPlaceNameCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("DistrictCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcDistrictIdCurrent" + _familyRelation].ToString()) ? _dr["plcDistrictIdCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("DistrictNameTHCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thDistrictNameCurrent" + _familyRelation].ToString()) ? _dr["thDistrictNameCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("DistrictNameENCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enDistrictNameCurrent" + _familyRelation].ToString()) ? _dr["enDistrictNameCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("PostalCodeDistrictCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeDistrictCurrent" + _familyRelation].ToString()) ? _dr["zipCodeDistrictCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("SubDistrictCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcSubdistrictIdCurrent" + _familyRelation].ToString()) ? _dr["plcSubdistrictIdCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("SubDistrictNameTHCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thSubdistrictNameCurrent" + _familyRelation].ToString()) ? _dr["thSubdistrictNameCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("SubDistrictNameENCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enSubdistrictNameCurrent" + _familyRelation].ToString()) ? _dr["enSubdistrictNameCurrent" + _familyRelation].ToString() : String.Empty));              
                _dataRecorded.Add(("PostalCodeCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeCurrent" + _familyRelation].ToString()) ? _dr["zipCodeCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("VillageCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["villageCurrent" + _familyRelation].ToString()) ? _dr["villageCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AddressNumberCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["noCurrent" + _familyRelation].ToString()) ? _dr["noCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("VillageNoCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["mooCurrent" + _familyRelation].ToString()) ? _dr["mooCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("LaneAlleyCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["soiCurrent" + _familyRelation].ToString()) ? _dr["soiCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("RoadCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["roadCurrent" + _familyRelation].ToString()) ? _dr["roadCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("PhoneNumberCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["phoneNumberCurrent" + _familyRelation].ToString()) ? _dr["phoneNumberCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MobileNumberCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["mobileNumberCurrent" + _familyRelation].ToString()) ? _dr["mobileNumberCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("FaxNumberCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["faxNumberCurrent" + _familyRelation].ToString()) ? _dr["faxNumberCurrent" + _familyRelation].ToString() : String.Empty));

                return _dataRecorded;
            }
        }

        public class WorkUtil
        {
            public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds, string _familyRelation)
            {
                DataRow _dr = null;

                if (_ds.Tables[0].Rows.Count > 0)
                    _dr = _ds.Tables[2].Rows[0];

                _familyRelation = Util.UppercaseFirst(_familyRelation);

                _dataRecorded.Add(("Occupation" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["occupation" + _familyRelation].ToString()) ? _dr["occupation" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("OccupationTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thOccupation" + _familyRelation].ToString()) ? _dr["thOccupation" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("OccupationEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enOccupation" + _familyRelation].ToString()) ? _dr["enOccupation" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Agency" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perAgencyId" + _familyRelation].ToString()) ? _dr["perAgencyId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AgencyNameTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thAgencyName" + _familyRelation].ToString()) ? _dr["thAgencyName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AgencyNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enAgencyName" + _familyRelation].ToString()) ? _dr["enAgencyName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AgencyOther" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["agencyOther" + _familyRelation].ToString()) ? _dr["agencyOther" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Workplace" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["workplace" + _familyRelation].ToString()) ? _dr["workplace" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Position" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["position" + _familyRelation].ToString()) ? _dr["position" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Telephone" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["telephone" + _familyRelation].ToString()) ? _dr["telephone" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Salary" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["salary" + _familyRelation].ToString()) ? _dr["salary" + _familyRelation].ToString() : String.Empty));

                return _dataRecorded;
            }
        }
    }

    public static string GetValuePersonIdByPage(string _page, string _personId, string _personIdFather, string _personIdMother, string _personIdParent)
    {
        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE))
            _personId = _personIdFather;

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE))
            _personId = _personIdMother;

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE))
            _personId = _personIdParent;

        return _personId;
    }

    public static bool GetValueActionSaveStudentRecordsByPage(string _page, string _personIdFather, string _personIdMother, string _personIdParent)
    {
        bool _actionSave = true;

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE) ||
            _page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE))
            _actionSave = (String.IsNullOrEmpty(_personIdParent) || (!_personIdParent.Equals(_personIdFather) && !_personIdParent.Equals(_personIdMother)) ? true : false);

        return _actionSave;
    }
}