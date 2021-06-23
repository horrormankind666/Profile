/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๕/๐๙/๒๕๕๗>
Modify date : <๑๕/๐๕/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการจัดการข้อมูลระเบียนประวัตินักศึกษา>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;

public class ePFStudentRecordsUtil
{
    public static string[,] _menuRecords = new string[,]
    {
        { "ข้อมูลส่วนตัว", "Student's Personal Data", "", ePFUtil.ID_SECTION_STUDENTRECORDSPERSONAL_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSPERSONAL_ADDUPDATE },
        { "ข้อมูลที่อยู่", "Student's Address", "", ePFUtil.ID_SECTION_STUDENTRECORDSADDRESS_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSADDRESS_ADDUPDATE },
        { "ข้อมูลการศึกษา", "Educational Record", "", ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATION_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSEDUCATION_ADDUPDATE },
        { "ข้อมูลความสามารถพิเศษ", "Talent Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSTALENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSTALENT_ADDUPDATE },
        { "ข้อมูลความพิการ", "Disability Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSHEALTHY_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSHEALTHY_ADDUPDATE },
        //{ "ข้อมูลการทำงาน", "Work Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSWORK_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSWORK_ADDUPDATE },
        { "ข้อมูลการเงิน", "Finance Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSFINANCIAL_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFINANCIAL_ADDUPDATE },
        { "ข้อมูลครอบครัว", "Family Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILY_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILY_ADDUPDATE },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address", "active", ePFUtil.ID_SECTION_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSADDRESSPERMANENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address", "", ePFUtil.ID_SECTION_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSADDRESSCURRENT_ADDUPDATE },
        { "ระดับประถม", "Primary Education", "", ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSEDUCATIONPRIMARYSCHOOL_ADDUPDATE },
        { "ระดับมัธยมต้น", "Junior Education", "", ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL_ADDUPDATE },
        { "ระดับมัธยมปลาย", "High School Education", "active", ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSEDUCATIONHIGHSCHOOL_ADDUPDATE },
        { "ก่อนที่เข้า ม.มหิดล", "Prior to Entering MU", "", ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSEDUCATIONUNIVERSITY_ADDUPDATE },
        { "คะแนนสอบ", "Admission Scores", "", ePFUtil.ID_SECTION_STUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSEDUCATIONADMISSIONSCORES_ADDUPDATE },
        { "ข้อมูลบิดา", "Father Information", "active", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHER_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHER_ADDUPDATE },
        { "ข้อมูลมารดา", "Mother Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHER_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHER_ADDUPDATE },
        { "ข้อมูลผู้ปกครอง", "Parent Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENT_ADDUPDATE , ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENT_ADDUPDATE },
        { "ข้อมูลส่วนตัว", "Personal Data", "active", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE },
        { "ข้อมูลส่วนตัว", "Personal Data", "active", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE },
        { "ข้อมูลส่วนตัว", "Personal Data", "active", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ตามทะเบียนบ้าน", "Permanent Address", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE },
        { "ข้อมูลที่อยู่ปัจจุบันที่ติดต่อได้", "Current Address", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE },
        { "ข้อมูลการทำงาน", "Work Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE },
        { "ข้อมูลการทำงาน", "Work Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE },
        { "ข้อมูลการทำงาน", "Work Information", "", ePFUtil.ID_SECTION_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE, ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE }
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
        { "O-NET", "สังคมศึกษา ศาสนา และวัฒนธรรม", "Social Science", "ScoresONETSocialScience" },
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

    public static string GetSectionByFamilyRelation(string _familyRelation, string _idFather, string _idMother, string _idParent)
    {
        string _idSection = String.Empty;

        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYFATHER))
            _idSection = _idFather;

        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYMOTHER))
            _idSection = _idMother;

        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
            _idSection = _idParent;

        return _idSection;
    }
    
    public static string GetGenderByFamilyRelation(string _familyRelation)
    {
        string _gender = String.Empty;

        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYFATHER))
            _gender = "M";

        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYMOTHER))
            _gender = "F";

        if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
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

            _studentPicture = (_dr != null && !String.IsNullOrEmpty(_dr["profilePictureName"].ToString()) ? (ePFUtil._myURLPictureStudent + "/" + _dr["profilePictureName"].ToString()) : String.Empty);
            _studentPicture = (!String.IsNullOrEmpty(_studentPicture) && Util.FileSiteExist(_studentPicture) ? (ePFUtil._myHandlerPath + "?action=image2stream&f=" + Util.EncodeToBase64(_studentPicture)) : String.Empty);

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
            _dataRecorded.Add("ProgramNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? _dr["programNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? _dr["programNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("IsProgramContract", (_dr != null && !String.IsNullOrEmpty(_dr["isProgramContract"].ToString()) ? _dr["isProgramContract"].ToString() : String.Empty));
            _dataRecorded.Add("YearEntry", (_dr != null && !String.IsNullOrEmpty(_dr["yearEntry"].ToString()) ? _dr["yearEntry"].ToString() : String.Empty));
            _dataRecorded.Add("Class", (_dr != null && !String.IsNullOrEmpty(_dr["class"].ToString()) ? _dr["class"].ToString() : String.Empty));
            _dataRecorded.Add("StatusTypeNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["statusTypeNameTH"].ToString()) ? _dr["statusTypeNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("StatusTypeNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["statusTypeNameEN"].ToString()) ? _dr["statusTypeNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("AdmissionDate", (_dr != null && !String.IsNullOrEmpty(_dr["admissionDate"].ToString()) ? DateTime.Parse(_dr["admissionDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
            _dataRecorded.Add("GraduationDate", (_dr != null && !String.IsNullOrEmpty(_dr["graduateDate"].ToString()) ? DateTime.Parse(_dr["graduateDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
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
            _dataRecorded.Add("Alive", (_dr != null && !String.IsNullOrEmpty(_dr["alive"].ToString()) ? _dr["alive"].ToString() : String.Empty));
            _dataRecorded.Add("BirthdateTH", (_dr != null && !String.IsNullOrEmpty(_dr["thBirthDate"].ToString()) ? _dr["thBirthDate"].ToString() : String.Empty));
            _dataRecorded.Add("BirthDateEN", (_dr != null && !String.IsNullOrEmpty(_dr["enBirthDate"].ToString()) ? _dr["enBirthDate"].ToString() : String.Empty));
            _dataRecorded.Add("AgeYear", (_age.ContainsKey("Year").Equals(true) ? (!_age["Year"].Equals(0) ? _age["Year"].ToString() : String.Empty) : String.Empty));
            _dataRecorded.Add("AgeMonth", (_age.ContainsKey("Month").Equals(true) ? (!_age["Month"].Equals(0) ? _age["Month"].ToString() : String.Empty) : String.Empty));
            _dataRecorded.Add("AgeDay", (_age.ContainsKey("Day").Equals(true) ? (!_age["Day"].Equals(0) ? _age["Day"].ToString() : String.Empty) : String.Empty));
            _dataRecorded.Add("Country", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryId"].ToString()) ? _dr["plcCountryId"].ToString() : String.Empty));
            _dataRecorded.Add("Nationality", (_dr != null && !String.IsNullOrEmpty(_dr["perNationalityId"].ToString()) ? _dr["perNationalityId"].ToString() : String.Empty));
            _dataRecorded.Add("Race", (_dr != null && !String.IsNullOrEmpty(_dr["perOriginId"].ToString()) ? _dr["perOriginId"].ToString() : String.Empty));
            _dataRecorded.Add("Religion", (_dr != null && !String.IsNullOrEmpty(_dr["perReligionId"].ToString()) ? _dr["perReligionId"].ToString() : String.Empty));
            _dataRecorded.Add("BloodGroup", (_dr != null && !String.IsNullOrEmpty(_dr["perBloodTypeId"].ToString()) ? _dr["perBloodTypeId"].ToString() : String.Empty));
            _dataRecorded.Add("MaritalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["perMaritalStatusId"].ToString()) ? _dr["perMaritalStatusId"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundPerson", (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalBackgroundId"].ToString()) ? _dr["perEducationalBackgroundId"].ToString() : String.Empty));
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
            _dataRecorded.Add("ProvincePermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdPermanent"].ToString()) ? _dr["plcProvinceIdPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcDistrictIdPermanent"].ToString()) ? _dr["plcDistrictIdPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("PostalCodeDistrictPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeDistrictPermanent"].ToString()) ? _dr["zipCodeDistrictPermanent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictPermanentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcSubdistrictIdPermanent"].ToString()) ? _dr["plcSubdistrictIdPermanent"].ToString() : String.Empty));
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
            _dataRecorded.Add("ProvinceCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdCurrent"].ToString()) ? _dr["plcProvinceIdCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("DistrictCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcDistrictIdCurrent"].ToString()) ? _dr["plcDistrictIdCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("PostalCodeDistrictCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeDistrictCurrent"].ToString()) ? _dr["zipCodeDistrictCurrent"].ToString() : String.Empty));
            _dataRecorded.Add("SubDistrictCurrentAddress", (_dr != null && !String.IsNullOrEmpty(_dr["plcSubdistrictIdCurrent"].ToString()) ? _dr["plcSubdistrictIdCurrent"].ToString() : String.Empty));
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
            _dataRecorded.Add("InstituteProvincePrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdPrimarySchool"].ToString()) ? _dr["plcProvinceIdPrimarySchool"].ToString() : String.Empty));
            _dataRecorded.Add("YearAttendedPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["primarySchoolYearAttended"].ToString()) ? _dr["primarySchoolYearAttended"].ToString() : String.Empty));
            _dataRecorded.Add("YearGraduatePrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["primarySchoolYearGraduate"].ToString()) ? _dr["primarySchoolYearGraduate"].ToString() : String.Empty));
            _dataRecorded.Add("GPAPrimarySchool", (_dr != null && !String.IsNullOrEmpty(_dr["primarySchoolGPA"].ToString()) ? _dr["primarySchoolGPA"].ToString() : String.Empty));           
            _dataRecorded.Add("InstituteNameJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["juniorHighSchoolName"].ToString()) ? _dr["juniorHighSchoolName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdJuniorHighSchool"].ToString()) ? _dr["plcCountryIdJuniorHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdJuniorHighSchool"].ToString()) ? _dr["plcProvinceIdJuniorHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("YearAttendedJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["juniorHighSchoolYearAttended"].ToString()) ? _dr["juniorHighSchoolYearAttended"].ToString() : String.Empty));
            _dataRecorded.Add("YearGraduateJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["juniorHighSchoolYearGraduate"].ToString()) ? _dr["juniorHighSchoolYearGraduate"].ToString() : String.Empty));
            _dataRecorded.Add("GPAJuniorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["juniorHighSchoolGPA"].ToString()) ? _dr["juniorHighSchoolGPA"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteNameHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolName"].ToString()) ? _dr["highSchoolName"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteCountryHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryIdHighSchool"].ToString()) ? _dr["plcCountryIdHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("InstituteProvinceHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdHighSchool"].ToString()) ? _dr["plcProvinceIdHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIdHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolStudentId"].ToString()) ? _dr["highSchoolStudentId"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalMajorHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalMajorIdHighSchool"].ToString()) ? _dr["perEducationalMajorIdHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalMajorOtherHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["educationalMajorOtherHighSchool"].ToString()) ? _dr["educationalMajorOtherHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("YearAttendedHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolYearAttended"].ToString()) ? _dr["highSchoolYearAttended"].ToString() : String.Empty));
            _dataRecorded.Add("YearGraduateHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolYearGraduate"].ToString()) ? _dr["highSchoolYearGraduate"].ToString() : String.Empty));
            _dataRecorded.Add("GPAHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["highSchoolGPA"].ToString()) ? _dr["highSchoolGPA"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackgroundHighSchool", (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalBackgroundIdHighSchool"].ToString()) ? _dr["perEducationalBackgroundIdHighSchool"].ToString() : String.Empty));
            _dataRecorded.Add("EducationalBackground", (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalBackgroundId"].ToString()) ? _dr["perEducationalBackgroundId"].ToString() : String.Empty));
            _dataRecorded.Add("GraduateBy", (_dr != null && !String.IsNullOrEmpty(_dr["graduateBy"].ToString()) ? _dr["graduateBy"].ToString() :String.Empty));
            _dataRecorded.Add("GraduateByInstituteName", (_dr != null && !String.IsNullOrEmpty(_dr["graduateBySchoolName"].ToString()) ? _dr["graduateBySchoolName"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTime", (_dr != null && !String.IsNullOrEmpty(_dr["entranceTime"].ToString()) ? _dr["entranceTime"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIs", (_dr != null && !String.IsNullOrEmpty(_dr["studentIs"].ToString()) ? _dr["studentIs"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIsUniversity", (_dr != null && !String.IsNullOrEmpty(_dr["studentIsUniversity"].ToString()) ? _dr["studentIsUniversity"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIsFaculty", (_dr != null && !String.IsNullOrEmpty(_dr["studentIsFaculty"].ToString()) ? _dr["studentIsFaculty"].ToString() : String.Empty));
            _dataRecorded.Add("StudentIsProgram", (_dr != null && !String.IsNullOrEmpty(_dr["studentIsProgram"].ToString()) ? _dr["studentIsProgram"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceType", (_dr != null && !String.IsNullOrEmpty(_dr["perEntranceTypeId"].ToString()) ? _dr["perEntranceTypeId"].ToString() : String.Empty));
            _dataRecorded.Add("AdmissionRanking", (_dr != null && !String.IsNullOrEmpty(_dr["admissionRanking"].ToString()) ? _dr["admissionRanking"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETThai", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET01"].ToString()) ? _dr["scoreONET01"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETSocialScience", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET02"].ToString()) ? _dr["scoreONET02"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETEnglish", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET03"].ToString()) ? _dr["scoreONET03"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETMathematics", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET04"].ToString()) ? _dr["scoreONET04"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETScience", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET05"].ToString()) ? _dr["scoreONET05"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETHealthPhysical", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET06"].ToString()) ? _dr["scoreONET06"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETArts", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET07"].ToString()) ? _dr["scoreONET07"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresONETOccupationTechnology", (_dr != null && !String.IsNullOrEmpty(_dr["scoreONET08"].ToString()) ? _dr["scoreONET08"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETThai2", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET11"].ToString()) ? _dr["scoreANET11"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETSocialScience2", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET12"].ToString()) ? _dr["scoreANET12"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETEnglish3", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET13"].ToString()) ? _dr["scoreANET13"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETMathematics2", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET14"].ToString()) ? _dr["scoreANET14"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresANETScience2", (_dr != null && !String.IsNullOrEmpty(_dr["scoreANET15"].ToString()) ? _dr["scoreANET15"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresGATGenaralAptitudeTest", (_dr != null && !String.IsNullOrEmpty(_dr["scoreGAT85"].ToString()) ? _dr["scoreGAT85"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT1", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT71"].ToString()) ? _dr["scorePAT71"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT2", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT72"].ToString()) ? _dr["scorePAT72"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT3", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT73"].ToString()) ? _dr["scorePAT73"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT4", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT74"].ToString()) ? _dr["scorePAT74"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT5", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT75"].ToString()) ? _dr["scorePAT75"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT6", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT76"].ToString()) ? _dr["scorePAT76"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT7", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT77"].ToString()) ? _dr["scorePAT77"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT8", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT78"].ToString()) ? _dr["scorePAT78"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT9", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT79"].ToString()) ? _dr["scorePAT79"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT10", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT80"].ToString()) ? _dr["scorePAT80"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT11", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT81"].ToString()) ? _dr["scorePAT81"].ToString() : String.Empty));
            _dataRecorded.Add("ScoresPAT12", (_dr != null && !String.IsNullOrEmpty(_dr["scorePAT82"].ToString()) ? _dr["scorePAT82"].ToString() : String.Empty));

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

                    _dt = ePFUtil.StringArrayToDataTable(_dtContent);
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

                    _dt = ePFUtil.StringArrayToDataTable(_dtContent);
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
            _dataRecorded.Add("Agency", (_dr != null && !String.IsNullOrEmpty(_dr["perAgencyId"].ToString()) ? _dr["perAgencyId"].ToString() : String.Empty));
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
            _dataRecorded.Add("ScholarshipFirstBachelorName", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipFirstBachelorName"].ToString()) ? _dr["scholarshipFirstBachelorName"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipFirstBachelorMoney", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipFirstBachelorMoney"].ToString()) ? _dr["scholarshipFirstBachelorMoney"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelor", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipBachelor"].ToString()) ? _dr["scholarshipBachelor"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelorFrom", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipBachelorFrom"].ToString()) ? _dr["scholarshipBachelorFrom"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelorName", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipBachelorName"].ToString()) ? _dr["scholarshipBachelorName"].ToString() : String.Empty));
            _dataRecorded.Add("ScholarshipBachelorMoney", (_dr != null && !String.IsNullOrEmpty(_dr["scholarshipBachelorMoney"].ToString()) ? _dr["scholarshipBachelorMoney"].ToString() : String.Empty));
            _dataRecorded.Add("Worked", (_dr != null && !String.IsNullOrEmpty(_dr["worked"].ToString()) ? _dr["worked"].ToString() : String.Empty));
            _dataRecorded.Add("Salary", (_dr != null && !String.IsNullOrEmpty(_dr["salary"].ToString()) ? _dr["salary"].ToString() : String.Empty));
            _dataRecorded.Add("Workplace", (_dr != null && !String.IsNullOrEmpty(_dr["workplace"].ToString()) ? _dr["workplace"].ToString() : String.Empty));
            _dataRecorded.Add("GotMoneyFrom", (_dr != null && !String.IsNullOrEmpty(_dr["gotMoneyFrom"].ToString()) ? _dr["gotMoneyFrom"].ToString() : String.Empty));
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

                if (_familyRelation.Equals(ePFUtil.SUBJECT_FAMILYPARENT))
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
                _dataRecorded.Add(("GenderTitlePrefix" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perGenderIdTitlePrefix" + _familyRelation].ToString()) ? _dr["perGenderIdTitlePrefix" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("FirstName" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["firstName" + _familyRelation].ToString()) ? _dr["firstName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MiddleName" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["middleName" + _familyRelation].ToString()) ? _dr["middleName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("LastName" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["lastName" + _familyRelation].ToString()) ? _dr["lastName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("FirstNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enFirstName" + _familyRelation].ToString()) ? _dr["enFirstName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MiddleNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enMiddleName" + _familyRelation].ToString()) ? _dr["enMiddleName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("LastNameEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enLastName" + _familyRelation].ToString()) ? _dr["enLastName" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Gender" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perGenderId" + _familyRelation].ToString()) ? _dr["perGenderId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Alive" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["alive" + _familyRelation].ToString()) ? _dr["alive" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("BirthdateTH" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["thBirthDate" + _familyRelation].ToString()) ? _dr["thBirthDate" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("BirthDateEN" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["enBirthDate" + _familyRelation].ToString()) ? _dr["enBirthDate" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("AgeYear" + _familyRelation), (_age.ContainsKey("Year").Equals(true) ? (!_age["Year"].Equals(0) ? _age["Year"].ToString() : String.Empty) : String.Empty));
                _dataRecorded.Add(("AgeMonth" + _familyRelation), (_age.ContainsKey("Month").Equals(true) ? (!_age["Month"].Equals(0) ? _age["Month"].ToString() : String.Empty) : String.Empty));
                _dataRecorded.Add(("AgeDay" + _familyRelation), (_age.ContainsKey("Day").Equals(true) ? (!_age["Day"].Equals(0) ? _age["Day"].ToString() : String.Empty) : String.Empty));
                _dataRecorded.Add(("Country" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcCountryId" + _familyRelation].ToString()) ? _dr["plcCountryId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Nationality" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perNationalityId" + _familyRelation].ToString()) ? _dr["perNationalityId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Race" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perOriginId" + _familyRelation].ToString()) ? _dr["perOriginId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("Religion" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perReligionId" + _familyRelation].ToString()) ? _dr["perReligionId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("BloodGroup" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perBloodTypeId" + _familyRelation].ToString()) ? _dr["perBloodTypeId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("MaritalStatus" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perMaritalStatusId" + _familyRelation].ToString()) ? _dr["perMaritalStatusId" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("EducationalBackgroundPerson" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perEducationalBackgroundId" + _familyRelation].ToString()) ? _dr["perEducationalBackgroundId" + _familyRelation].ToString() : String.Empty));

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
                _dataRecorded.Add(("ProvincePermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdPermanent" + _familyRelation].ToString()) ? _dr["plcProvinceIdPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("DistrictPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcDistrictIdPermanent" + _familyRelation].ToString()) ? _dr["plcDistrictIdPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("PostalCodeDistrictPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeDistrictPermanent" + _familyRelation].ToString()) ? _dr["zipCodeDistrictPermanent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("SubDistrictPermanentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcSubdistrictIdPermanent" + _familyRelation].ToString()) ? _dr["plcSubdistrictIdPermanent" + _familyRelation].ToString() : String.Empty));
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
                _dataRecorded.Add(("ProvinceCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcProvinceIdCurrent" + _familyRelation].ToString()) ? _dr["plcProvinceIdCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("DistrictCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcDistrictIdCurrent" + _familyRelation].ToString()) ? _dr["plcDistrictIdCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("PostalCodeDistrictCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["zipCodeDistrictCurrent" + _familyRelation].ToString()) ? _dr["zipCodeDistrictCurrent" + _familyRelation].ToString() : String.Empty));
                _dataRecorded.Add(("SubDistrictCurrentAddress" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["plcSubdistrictIdCurrent" + _familyRelation].ToString()) ? _dr["plcSubdistrictIdCurrent" + _familyRelation].ToString() : String.Empty));
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
                _dataRecorded.Add(("Agency" + _familyRelation), (_dr != null && !String.IsNullOrEmpty(_dr["perAgencyId" + _familyRelation].ToString()) ? _dr["perAgencyId" + _familyRelation].ToString() : String.Empty));
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
        if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERPERSONAL_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSPERMANENT_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERADDRESSCURRENT_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYFATHERWORK_ADDUPDATE))
            _personId = _personIdFather;

        if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERPERSONAL_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERADDRESSCURRENT_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYMOTHERWORK_ADDUPDATE))
            _personId = _personIdMother;

        if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE))
            _personId = _personIdParent;

        return _personId;
    }

    public static bool GetValueActionSaveStudentRecordsByPage(string _page, string _personIdFather, string _personIdMother, string _personIdParent)
    {
        bool _actionSave = true;

        if (_page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTPERSONAL_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSPERMANENT_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTADDRESSCURRENT_ADDUPDATE) ||
            _page.Equals(ePFUtil.PAGE_STUDENTRECORDSFAMILYPARENTWORK_ADDUPDATE))
            _actionSave = (String.IsNullOrEmpty(_personIdParent) || (!_personIdParent.Equals(_personIdFather) && !_personIdParent.Equals(_personIdMother)) ? true : false);

        return _actionSave;
    }
}