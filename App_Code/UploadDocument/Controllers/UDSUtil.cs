/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๗/๐๕/๒๕๕๘>
Modify date : <๐๘/๐๖/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไป>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;
using NFinServiceLogin;

public class UDSUtil
{
    public const string SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS = "MeaningOfApprovalStatus";
    public const string SUBJECT_SECTION_STUDENTRECORDS = "StudentRecords";
    public const string SUBJECT_SECTION_OVERVIEW = "Overview";
    public const string SUBJECT_SECTION_PROFILEPICTURE = "ProfilePicture";
    public const string SUBJECT_SECTION_IDENTITYCARD = "IdentityCard";
    public const string SUBJECT_SECTION_TRANSCRIPT = "Transcript";
    public const string SUBJECT_SECTION_TRANSCRIPTINSTITUTE = "TranscriptInstitute";
    public const string SUBJECT_SECTION_TRANSCRIPTFRONTSIDE = "TranscriptFrontside";
    public const string SUBJECT_SECTION_TRANSCRIPTBACKSIDE = "TranscriptBackside";
    public const string SUBJECT_SECTION_VIEWPROFILEPICTURE = ("View" + SUBJECT_SECTION_PROFILEPICTURE);
    public const string SUBJECT_SECTION_VIEWIDENTITYCARD = ("View" + SUBJECT_SECTION_IDENTITYCARD);
    public const string SUBJECT_SECTION_VIEWTRANSCRIPTFRONTSIDE = ("View" + SUBJECT_SECTION_TRANSCRIPTFRONTSIDE);
    public const string SUBJECT_SECTION_VIEWTRANSCRIPTBACKSIDE = ("View" + SUBJECT_SECTION_TRANSCRIPTBACKSIDE);
    public const string SUBJECT_SECTION_VIEWMESSAGE = "ViewMessage";
    public const string SUBJECT_SECTION_RECOMMENDUPLOADPROFILEPICTURE = ("RecommendUpload" + SUBJECT_SECTION_PROFILEPICTURE);
    public const string SUBJECT_SECTION_RECOMMENDUPLOADIDENTITYCARD = ("RecommendUpload" + SUBJECT_SECTION_IDENTITYCARD);
    public const string SUBJECT_SECTION_RECOMMENDUPLOADTRANSCRIPT = ("RecommendUpload" + SUBJECT_SECTION_TRANSCRIPT);
    public const string SUBJECT_SECTION_RECOMMENDUPLOADTRANSCRIPTFRONTSIDE = ("RecommendUpload" + SUBJECT_SECTION_TRANSCRIPTFRONTSIDE);
    public const string SUBJECT_SECTION_RECOMMENDUPLOADTRANSCRIPTBACKSIDE = ("RecommendUpload" + SUBJECT_SECTION_TRANSCRIPTBACKSIDE);
    public const string SUBJECT_SECTION_RECOMMENDSUBMIT = "RecommendSubmit";
    public const string SUBJECT_SECTION_STUDENTRECORDSSTUDENTCV = (SUBJECT_SECTION_STUDENTRECORDS + "StudentCV");
    public const string SUBJECT_SECTION_HELP = "Help";
    public const string SUBJECT_SECTION_CONTACTUS = "ContactUS";
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENT = "UploadSubmitDocument";
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + SUBJECT_SECTION_STUDENTRECORDS);
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + SUBJECT_SECTION_OVERVIEW);
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + SUBJECT_SECTION_PROFILEPICTURE);
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + SUBJECT_SECTION_IDENTITYCARD);
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + SUBJECT_SECTION_TRANSCRIPT);
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTINSTITUTE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + SUBJECT_SECTION_TRANSCRIPTINSTITUTE);
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTFRONTSIDE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + SUBJECT_SECTION_TRANSCRIPTFRONTSIDE);
    public const string SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTBACKSIDE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + SUBJECT_SECTION_TRANSCRIPTBACKSIDE);

    public const string ID_SECTION_MEANINGOFAPPROVALSTATUS_MAIN = ("Main-" + SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS);
    public const string ID_SECTION_VIEWMESSAGE_MAIN = ("Main-" + SUBJECT_SECTION_VIEWMESSAGE);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENT_MAIN = ("Main-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENT);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENT);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTINSTITUTE_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTINSTITUTE);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTFRONTSIDE_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTFRONTSIDE);
    public const string ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTBACKSIDE_ADDUPDATE = ("AddUpdate-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPTBACKSIDE);

    public const string PAGE_CONTACTUS_MAIN = (SUBJECT_SECTION_CONTACTUS + "Main");
    public const string PAGE_MEANINGOFAPPROVALSTATUS_MAIN = (SUBJECT_SECTION_MEANINGOFAPPROVALSTATUS + "Main");
    public const string PAGE_VIEWPROFILEPICTURE_MAIN = (SUBJECT_SECTION_VIEWPROFILEPICTURE + "Main");
    public const string PAGE_VIEWIDENTITYCARD_MAIN = (SUBJECT_SECTION_VIEWIDENTITYCARD + "Main");
    public const string PAGE_VIEWTRANSCRIPTFRONTSIDE_MAIN = (SUBJECT_SECTION_VIEWTRANSCRIPTFRONTSIDE + "Main");
    public const string PAGE_VIEWTRANSCRIPTBACKSIDE_MAIN = (SUBJECT_SECTION_VIEWTRANSCRIPTBACKSIDE + "Main");
    public const string PAGE_VIEWMESSAGE_MAIN = (SUBJECT_SECTION_VIEWMESSAGE + "Main");
    public const string PAGE_RECOMMENDUPLOADPROFILEPICTURE_MAIN = (SUBJECT_SECTION_RECOMMENDUPLOADPROFILEPICTURE + "Main");
    public const string PAGE_RECOMMENDUPLOADIDENTITYCARD_MAIN = (SUBJECT_SECTION_RECOMMENDUPLOADIDENTITYCARD + "Main");
    public const string PAGE_RECOMMANDUPLOADTRANSCRIPT_MAIN = (SUBJECT_SECTION_RECOMMENDUPLOADTRANSCRIPT + "Main");
    public const string PAGE_RECOMMANDUPLOADTRANSCRIPTFRONTSIDE_MAIN = (SUBJECT_SECTION_RECOMMENDUPLOADTRANSCRIPTFRONTSIDE + "Main");
    public const string PAGE_RECOMMANDUPLOADTRANSCRIPTBACKSIDE_MAIN = (SUBJECT_SECTION_RECOMMENDUPLOADTRANSCRIPTBACKSIDE + "Main");
    public const string PAGE_RECOMMENDSUBMIT_MAIN = (SUBJECT_SECTION_RECOMMENDSUBMIT + "Main");    
    public const string PAGE_STUDENTRECORDSSTUDENTCV_MAIN = (SUBJECT_SECTION_STUDENTRECORDSSTUDENTCV + "Main");
    public const string PAGE_UPLOADSUBMITDOCUMENT_MAIN = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + "Main");
    public const string PAGE_UPLOADSUBMITDOCUMENT_ADDUPDATE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENT + "AddUpdate");
    public const string PAGE_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS + "AddUpdate");
    public const string PAGE_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW + "AddUpdate");
    public const string PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE + "AddUpdate");
    public const string PAGE_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD + "AddUpdate");
    public const string PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE = (SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT + "AddUpdate");    

    public static string _myURLPictureStudent = System.Configuration.ConfigurationManager.AppSettings["urlPictureStudent"].ToString();
    public static string _myFileUploadTempPath = System.Configuration.ConfigurationManager.AppSettings["udsFileUploadTempPath"].ToString();
    public static string _myFileUploadPath = System.Configuration.ConfigurationManager.AppSettings["udsFileUploadPath"].ToString();
    public static string _myHandlerPath = System.Configuration.ConfigurationManager.AppSettings["udsHandlerPath"].ToString();    
    public static int _myProfilePictureWidth = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsProfilePictureWidth"].ToString());
    public static int _myProfilePictureHeight = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsProfilePictureHeight"].ToString());
    public static int _myProfilePictureWidthShow = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsProfilePictureWidthShow"].ToString());
    public static int _myProfilePictureHeightShow = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsProfilePictureHeightShow"].ToString());
    public static int _myProfilePictureZoom = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsProfilePictureZoom"].ToString());
    public static int _myIdentityCardWidth = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsIdentityCardWidth"].ToString());
    public static int _myIdentityCardHeight = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsIdentityCardHeight"].ToString());
    public static int _myIdentityCardWidthShow = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsIdentityCardWidthShow"].ToString());
    public static int _myIdentityCardHeightShow = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsIdentityCardHeightShow"].ToString());
    public static int _myIdentityCardZoom = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsIdentityCardZoom"].ToString());
    public static int _myTranscriptWidth = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsTranscriptWidth"].ToString());
    public static int _myTranscriptHeight = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsTranscriptHeight"].ToString());
    public static int _myTranscriptWidthShow = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsTranscriptWidthShow"].ToString());
    public static int _myTranscriptHeightShow = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsTranscriptHeightShow"].ToString());
    public static int _myTranscriptZoom = int.Parse(System.Configuration.ConfigurationManager.AppSettings["udsTranscriptZoom"].ToString());

    public static string[,] _menu = new string[,]
    {
        { "ช่วยเหลือ", "Help", SUBJECT_SECTION_HELP },
        { "อัพโหลดและส่งเอกสาร", "Upload & Submit Document", SUBJECT_SECTION_UPLOADSUBMITDOCUMENT }
    };

    public static string[,] _submenu = new string[,]
    {
        { "ติดต่อสอบถาม", "Contact US", SUBJECT_SECTION_CONTACTUS }
    };

    public static string[,] _documentUpload = new string[,]
    {
        { "รูปภาพประจำตัว", "Profile Picture", "ProfilePicture", "P" },
        { "บัตรประจำตัวประชาชน", "Identity Card", "IdentityCard", "I" },
        { "ระเบียนแสดงผลการเรียน ( ด้านหน้า ) ", "Transcript ( Frontside )", "TranscriptFrontside", "TF" },
        { "ระเบียนแสดงผลการเรียน ( ด้านหลัง ) ", "Transcript ( Backside )", "TranscriptBackside", "TB" }
    };

    public static string[,] _approvalStatus = new string[,]
    {
        { "รอยืนยันการส่ง", "Pending Submit", "S" },
        { "รอผลการอนุมัติ", "Pending Approved", "W" },
        { "ได้รับการอนุมัติ", "Approved", "Y" },
        { "ไม่ได้รับการอนุมัติ", "Not Approved", "N" }
    };

    public static Dictionary<string, object> GetInfoLogin(string _page, string _id)
    {
        Dictionary<string, object> _finServiceLoginResult = FinServiceLogin.GetFinServiceLogin(FinServiceLogin.USERTYPE_STUDENT, "UploadDocumentStudent");
        Dictionary<string, object> _loginResult = new Dictionary<string, object>();
        int _systemError = Util.DBUtil.ChkSystemPermissionStudent(_finServiceLoginResult);
        int _cookieError = 0;
        int _userError = 0;
        string _personId = _finServiceLoginResult["PersonID"].ToString();
        string _studentId = _finServiceLoginResult["StudentID"].ToString();
        string _studentCode = _finServiceLoginResult["StudentCode"].ToString();
        string _fullnameEN = _finServiceLoginResult["FullnameEN"].ToString();

        switch (_systemError)
        {
            case 1:
                _cookieError = 1;
                break;
            case 2:
                _userError = 1;
                break;
            case 3:
                _userError = 2;
                break;
            case 4:
                _userError = 3;
                break;
            case 5:
                _userError = 4;
                break;
        }

        _loginResult.Add("CookieError", _cookieError.ToString());
        _loginResult.Add("UserError", _userError.ToString());
        _loginResult.Add("PersonId", _personId);
        _loginResult.Add("StudentId", _studentId);
        _loginResult.Add("StudentCode", _studentCode);
        _loginResult.Add("FullnameEN", _fullnameEN);

        return _loginResult;
    }
   
    public static Dictionary<string, object> GetPage(string _page)
    {
        Dictionary<string, object> _loginResult = GetInfoLogin(_page, "");
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();
        int _pageError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString()); ;
        string _signinYN = String.Empty;
        string _personId = _loginResult["PersonId"].ToString();
        string _studentId = _loginResult["StudentId"].ToString();
        StringBuilder _menuContent = new StringBuilder();
        StringBuilder _mainContent = new StringBuilder();
       
        _pageError = 1;
        _signinYN = String.Empty;
        _mainContent = null;
        
        if (_userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4))
            _page = (_page.Equals(PAGE_STUDENTRECORDSSTUDENTCV_MAIN) ? _page : PAGE_UPLOADSUBMITDOCUMENT_MAIN);

        if (_page.Equals(PAGE_STUDENTRECORDSSTUDENTCV_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) ? Util.GetStudentRecordsToStudentCV(_personId) : null);
        }
        
        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENT_MAIN))
        {
            _pageError = 0;
            _signinYN = "Y";
            _mainContent = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUploadSubmitDocumentUI.GetSection(_loginResult, "MAIN", "", _personId) : null);
        }
        
        _pageResult.Add("Page", _page);
        _pageResult.Add("PageError", _pageError.ToString());
        _pageResult.Add("SignInYN", _signinYN);
        _pageResult.Add("CookieError", _cookieError.ToString());
        _pageResult.Add("UserError", _userError.ToString());
        _pageResult.Add("MenuBarContent", (_pageError.Equals(0) ? UDSUI.GetMenuBar(_loginResult).ToString() : String.Empty));
        _pageResult.Add("MainContent", (_mainContent != null ? _mainContent.ToString() : String.Empty));

        return _pageResult;
    }

    public static Dictionary<string, object> GetForm(string _form, string _id)
    {
        Dictionary<string, object> _loginResult = UDSUtil.GetInfoLogin("", "");
        Dictionary<string, object> _pageResult = new Dictionary<string, object>();
        int _formError = 0;
        int _cookieError = int.Parse(_loginResult["CookieError"].ToString());
        int _userError = int.Parse(_loginResult["UserError"].ToString()); ;
        int _width = 0;
        int _height = 0;
        string _signinYN = String.Empty;
        string _title = String.Empty;
        StringBuilder _content = new StringBuilder();
        Dictionary<string, object> _formResult = new Dictionary<string, object>();
               
        _formError = 1;

        if (_form.Equals(PAGE_CONTACTUS_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUI.GetFrmContactUS() : null);
            _width = 800;
            _height = 0;
            _title = (_submenu[0, 0] + " : " + _submenu[0, 1]);
        }
        
        if (_form.Equals(PAGE_MEANINGOFAPPROVALSTATUS_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUI.GetFrmMeaningOfDocumentApprovalStatus() : null);
            _width = 800;
            _height = 0;
            _title = "ความหมายของสถานะการอนุมัติเอกสาร : Meaning of Document Approval Status";
        }

        if (_form.Equals(PAGE_VIEWPROFILEPICTURE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUI.GetFrmViewDocument(UDSUtil.SUBJECT_SECTION_PROFILEPICTURE, _id) : null);
            _width = (_myProfilePictureWidth + 40);
            _height = (_myProfilePictureHeight + 80);
            _title = (_documentUpload[0, 0] + " : " + _documentUpload[0, 1]);
        }

        if (_form.Equals(PAGE_VIEWIDENTITYCARD_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUI.GetFrmViewDocument(UDSUtil.SUBJECT_SECTION_IDENTITYCARD, _id) : null);
            _width = (_myIdentityCardWidth + 40);
            _height = (_myIdentityCardHeight + 80);
            _title = (_documentUpload[1, 0] + " : " + _documentUpload[1, 1]);
        }

        if (_form.Equals(PAGE_VIEWTRANSCRIPTFRONTSIDE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUI.GetFrmViewDocument(UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE, _id) : null);
            _width = (_myTranscriptWidth + 40);
            _height = (_myTranscriptHeight + 80);
            _title = (_documentUpload[2, 0] + " : " + _documentUpload[2, 1]);
        }

        if (_form.Equals(PAGE_VIEWTRANSCRIPTBACKSIDE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUI.GetFrmViewDocument(UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE, _id) : null);
            _width = (_myTranscriptWidth + 40);
            _height = (_myTranscriptHeight + 80);
            _title = (_documentUpload[3, 0] + " : " + _documentUpload[3, 1]);
        }

        if (_form.Equals(PAGE_VIEWMESSAGE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUI.GetFrmViewMessage() : null);
            _width = 800;
            _height = 0;
            _title = "ข้อความ : Message";
        }

        if (_form.Equals(PAGE_RECOMMENDUPLOADPROFILEPICTURE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUI.GetFrmRecommendUploadProfilePicture() : null);
            _width = 800;
            _height = 0;
            _title = "คำแนะนำ : Recommend";
        }        

        if (_form.Equals(PAGE_RECOMMENDUPLOADIDENTITYCARD_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUI.GetFrmRecommendUploadIdentityCard() : null);
            _width = 800;
            _height = 0;
            _title = "คำแนะนำ : Recommend";
        }

        if (_form.Equals(PAGE_RECOMMANDUPLOADTRANSCRIPT_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUI.GetFrmRecommendUploadTranscript() : null);
            _width = 800;
            _height = 0;
            _title = "คำแนะนำ : Recommend";
        }

        if (_form.Equals(PAGE_RECOMMANDUPLOADTRANSCRIPTFRONTSIDE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUI.GetFrmRecommendUploadTranscriptFrontside() : null);
            _width = 800;
            _height = 0;
            _title = "คำแนะนำ : Recommend";
        }

        if (_form.Equals(PAGE_RECOMMANDUPLOADTRANSCRIPTBACKSIDE_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUI.GetFrmRecommendUploadTranscriptBackside() : null);
            _width = 800;
            _height = 0;
            _title = "คำแนะนำ : Recommend";
        }

        if (_form.Equals(PAGE_RECOMMENDSUBMIT_MAIN))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUI.GetFrmRecommendSubmit() : null);
            _width = 800;
            _height = 0;
            _title = "คำแนะนำ : Recommend";
        }

        if (_form.Equals(PAGE_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)) ? UDSUploadSubmitDocumentUI.SectionAddUpdateUI.OverviewUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUploadSubmitDocumentUI.SectionAddUpdateUI.ProfilePictureUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUploadSubmitDocumentUI.SectionAddUpdateUI.IdentityCardUI.GetMain(_id) : null);
        }

        if (_form.Equals(PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE))
        {
            _formError = 0;
            _signinYN = "Y";
            _content = (_cookieError.Equals(0) && _userError.Equals(0) ? UDSUploadSubmitDocumentUI.SectionAddUpdateUI.TranscriptUI.GetMain(_id) : null);
        }

        _formResult.Add("FormError", _formError.ToString());
        _formResult.Add("SignInYN", _signinYN);
        _formResult.Add("CookieError", _cookieError.ToString());
        _formResult.Add("UserError", _userError.ToString());
        _formResult.Add("Content", (_content != null ? _content.ToString() : String.Empty));
        _formResult.Add("Width", _width.ToString());
        _formResult.Add("Height", _height.ToString());
        _formResult.Add("Title", _title);

        return _formResult;
    }

    public static Dictionary<string, object> GetInfoData(string _page, Dictionary<string, object> _data)
    {
        Dictionary<string, object> _infoDataResult = new Dictionary<string, object>();
        StringBuilder _contentTemp = new StringBuilder();
        string _infoId = String.Empty;
        string _infoIcon = String.Empty;
        string _infoTitleTH = String.Empty;
        string _infoTitleEN = String.Empty;
        string _infoContent = String.Empty;
        string _infoOperatorHome = String.Empty;
        string _infoOperatorNew = String.Empty;
        string _infoOperatorEdit = String.Empty;
        string _infoOperatorDelete = String.Empty;
        string _infoOperatorSearch = String.Empty;
        string _infoOperatorReset = String.Empty;
        string _infoOperatorSave = String.Empty;
        string _infoOperatorApply = String.Empty;
        string _infoOperatorUndo = String.Empty;
        string _infoOperatorPrint = String.Empty;
        string _infoOperatorUpload = String.Empty;
        string _infoOperatorTransfer = String.Empty;
        string _infoOperatorExportAll = String.Empty;
        string _infoOperatorExportSelected = String.Empty;
        string _infoOperatorProfile = String.Empty;
        string _infoOperatorClose = String.Empty;
        string _infoImportantId = String.Empty;
        string _infoImportantRecommendTitle = String.Empty;
        string _infoImportantRecommendMsgTH = String.Empty;
        string _infoImportantRecommendMsgEN = String.Empty;
        string _infoImportantSuccessTitle = String.Empty;
        string _infoImportantSuccessMsg = String.Empty;

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENT_MAIN))
        {
            _infoId = ("infobar-" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENT.ToLower());
            _infoIcon = "icon-upload";
            _infoTitleTH = _menu[1, 0];
            _infoTitleEN = _menu[1, 1];
            _infoOperatorHome = ("home-" + _page.ToLower());
            _infoOperatorProfile = ("profile-" + _page.ToLower());
            _infoImportantId = ("important-" + _page.ToLower());
            _infoImportantRecommendMsgTH = "คลิก \"SUBMIT\" ทุกครั้ง เพื่อส่งเอกสารให้เจ้าหน้าที่พิจารณาอนุมัติ";
            _infoImportantRecommendMsgEN = "Click \"SUBMIT\" to send document to the authorities for approval.";
        }
        
        _infoDataResult.Add("ID", _infoId);
        _infoDataResult.Add("Icon", _infoIcon);
        _infoDataResult.Add("TitleTH", _infoTitleTH);
        _infoDataResult.Add("TitleEN", _infoTitleEN);
        _infoDataResult.Add("Content", _infoContent);
        _infoDataResult.Add("OperatorHome", _infoOperatorHome);
        _infoDataResult.Add("OperatorNew", _infoOperatorNew);
        _infoDataResult.Add("OperatorEdit", _infoOperatorEdit);
        _infoDataResult.Add("OperatorDelete", _infoOperatorDelete);
        _infoDataResult.Add("OperatorExportAll", _infoOperatorExportAll);
        _infoDataResult.Add("OperatorExportSelected", _infoOperatorExportSelected);
        _infoDataResult.Add("OperatorSearch", _infoOperatorSearch);
        _infoDataResult.Add("OperatorReset", _infoOperatorReset);
        _infoDataResult.Add("OperatorSave", _infoOperatorSave);
        _infoDataResult.Add("OperatorApply", _infoOperatorApply);
        _infoDataResult.Add("OperatorUndo", _infoOperatorUndo);
        _infoDataResult.Add("OperatorPrint", _infoOperatorPrint);
        _infoDataResult.Add("OperatorUpload", _infoOperatorUpload);
        _infoDataResult.Add("OperatorTransfer", _infoOperatorTransfer);
        _infoDataResult.Add("OperatorProfile", _infoOperatorProfile);
        _infoDataResult.Add("OperatorClose", _infoOperatorClose);
        _infoDataResult.Add("ImportantID", _infoImportantId);
        _infoDataResult.Add("ImportantRecommendTitle", _infoImportantRecommendTitle);
        _infoDataResult.Add("ImportantRecommendMsgTH", _infoImportantRecommendMsgTH);
        _infoDataResult.Add("ImportantRecommendMsgEN", _infoImportantRecommendMsgEN);
        _infoDataResult.Add("ImportantSuccessTitle", _infoImportantSuccessTitle);
        _infoDataResult.Add("ImportantSuccessMsg", _infoImportantSuccessMsg);

        return _infoDataResult;
    }

    public class ProfilePictureUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            string _fileFullPath = String.Empty;
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _fileFullPath = (_dr != null && !String.IsNullOrEmpty(_dr["profilepictureFileName"].ToString()) ? (UDSUtil._myFileUploadPath + "/" + _dr["profilepictureFileName"].ToString()) : String.Empty);
            _fileFullPath = (!String.IsNullOrEmpty(_fileFullPath) && Util.FileExist(_fileFullPath) ? (UDSUtil._myHandlerPath + "?action=imagefile2stream&f=" + Util.EncodeToBase64(_fileFullPath)) : String.Empty);

            _dataRecorded.Add("ProfilePictureFileDir", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myFileUploadPath : String.Empty));
            _dataRecorded.Add("ProfilePictureFileName", (!String.IsNullOrEmpty(_fileFullPath) ? _dr["profilepictureFileName"] : String.Empty));
            _dataRecorded.Add("ProfilePictureFileFullPath", (!String.IsNullOrEmpty(_fileFullPath) ? _fileFullPath : String.Empty));
            _dataRecorded.Add("ProfilePictureWidth", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myProfilePictureWidthShow.ToString() : String.Empty));
            _dataRecorded.Add("ProfilePictureHeight", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myProfilePictureHeightShow.ToString() : String.Empty));
            _dataRecorded.Add("ProfilePictureSavedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["profilepictureSavedStatus"].ToString()) ? _dr["profilepictureSavedStatus"] : "N"));
            _dataRecorded.Add("ProfilePictureSubmittedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["profilepictureSubmittedStatus"].ToString()) ? _dr["profilepictureSubmittedStatus"].ToString() : "N"));
            _dataRecorded.Add("ProfilePictureApprovalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["profilepictureApprovalStatus"].ToString()) ? _dr["profilepictureApprovalStatus"].ToString() : "S"));
            _dataRecorded.Add("ProfilePictureMessage", (_dr != null && !String.IsNullOrEmpty(_dr["profilepictureMessage"].ToString()) ? _dr["profilepictureMessage"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public class IdentityCardUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            string _fileFullPath = String.Empty;
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            _fileFullPath = (_dr != null && !String.IsNullOrEmpty(_dr["identitycardFileName"].ToString()) ? (UDSUtil._myFileUploadPath + "/" + _dr["identitycardFileName"].ToString()) : String.Empty);
            _fileFullPath = (!String.IsNullOrEmpty(_fileFullPath) && Util.FileExist(_fileFullPath) ? (UDSUtil._myHandlerPath + "?action=imagefile2stream&f=" + Util.EncodeToBase64(_fileFullPath)) : String.Empty);

            _dataRecorded.Add("IdentityCardFileDir", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myFileUploadPath : String.Empty));
            _dataRecorded.Add("IdentityCardFileName", (!String.IsNullOrEmpty(_fileFullPath) ? _dr["identitycardFileName"] : String.Empty));
            _dataRecorded.Add("IdentityCardFileFullPath", (!String.IsNullOrEmpty(_fileFullPath) ? _fileFullPath : String.Empty));
            _dataRecorded.Add("IdentityCardWidth", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myIdentityCardWidthShow.ToString() : String.Empty));
            _dataRecorded.Add("IdentityCardHeight", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myIdentityCardHeightShow.ToString() : String.Empty));
            _dataRecorded.Add("IdentityCardSavedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["identitycardSavedStatus"].ToString()) ? _dr["identitycardSavedStatus"] : String.Empty));
            _dataRecorded.Add("IdentityCardSubmittedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["identitycardSubmittedStatus"].ToString()) ? _dr["identitycardSubmittedStatus"].ToString() : String.Empty));
            _dataRecorded.Add("IdentityCardApprovalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["identitycardApprovalStatus"].ToString()) ? _dr["identitycardApprovalStatus"].ToString() : String.Empty));
            _dataRecorded.Add("IdentityCardMessage", (_dr != null && !String.IsNullOrEmpty(_dr["identitycardMessage"].ToString()) ? _dr["identitycardMessage"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }
    
    public class TranscriptUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {
            string _fileFullPath = String.Empty;
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];
            
            _dataRecorded.Add("TranscriptInstitute", (_dr != null && !String.IsNullOrEmpty(_dr["perInstituteIdTranscript"].ToString()) ? _dr["perInstituteIdTranscript"] : String.Empty));
            _dataRecorded.Add("TranscriptInstituteNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["institutelNameTHTranscript"].ToString()) ? _dr["institutelNameTHTranscript"].ToString() : String.Empty));
            _dataRecorded.Add("TranscriptInstituteNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["institutelNameENTranscript"].ToString()) ? _dr["institutelNameENTranscript"].ToString() : String.Empty));
            _dataRecorded.Add("TranscriptInstituteCountry", (_dr != null && !String.IsNullOrEmpty(_dr["instituteCountryIdTranscript"].ToString()) ? _dr["instituteCountryIdTranscript"] : String.Empty));
            _dataRecorded.Add("TranscriptInstituteCountryNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["instituteCountryNameTHTranscript"].ToString()) ? _dr["instituteCountryNameTHTranscript"].ToString() : String.Empty));
            _dataRecorded.Add("TranscriptInstituteCountryNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["instituteCountryNameENTranscript"].ToString()) ? _dr["instituteCountryNameENTranscript"].ToString() : String.Empty));
            _dataRecorded.Add("TranscriptInstituteProvince", (_dr != null && !String.IsNullOrEmpty(_dr["instituteProvinceIdTranscript"].ToString()) ? _dr["instituteProvinceIdTranscript"] : String.Empty));
            _dataRecorded.Add("TranscriptInstituteProvinceNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["instituteProvinceNameTHTranscript"].ToString()) ? _dr["instituteProvinceNameTHTranscript"].ToString() : String.Empty));
            _dataRecorded.Add("TranscriptInstituteProvinceNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["instituteProvinceNameENTranscript"].ToString()) ? _dr["instituteProvinceNameENTranscript"].ToString() : String.Empty));

            _fileFullPath = (_dr != null && !String.IsNullOrEmpty(_dr["transcriptfrontsideFileName"].ToString()) ? (UDSUtil._myFileUploadPath + "/" + _dr["transcriptfrontsideFileName"].ToString()) : String.Empty);
            _fileFullPath = (!String.IsNullOrEmpty(_fileFullPath) && Util.FileExist(_fileFullPath) ? (UDSUtil._myHandlerPath + "?action=imagefile2stream&f=" + Util.EncodeToBase64(_fileFullPath)) : String.Empty);

            _dataRecorded.Add("TranscriptFrontsideFileDir", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myFileUploadPath : String.Empty));
            _dataRecorded.Add("TranscriptFrontsideFileName", (!String.IsNullOrEmpty(_fileFullPath) ? _dr["transcriptfrontsideFileName"] : String.Empty));
            _dataRecorded.Add("TranscriptFrontsideFileFullPath", (!String.IsNullOrEmpty(_fileFullPath) ? _fileFullPath : String.Empty));
            _dataRecorded.Add("TranscriptFrontsideWidth", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myTranscriptWidthShow.ToString() : String.Empty));
            _dataRecorded.Add("TranscriptFrontsideHeight", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myTranscriptHeightShow.ToString() : String.Empty));
            _dataRecorded.Add("TranscriptFrontsideSavedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["transcriptfrontsideSavedStatus"].ToString()) ? _dr["transcriptfrontsideSavedStatus"] : "N"));
            _dataRecorded.Add("TranscriptFrontsideSubmittedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["transcriptfrontsideSubmittedStatus"].ToString()) ? _dr["transcriptfrontsideSubmittedStatus"].ToString() : "N"));
            _dataRecorded.Add("TranscriptFrontsideApprovalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["transcriptfrontsideApprovalStatus"].ToString()) ? _dr["transcriptfrontsideApprovalStatus"].ToString() : "S"));
            _dataRecorded.Add("TranscriptFrontsideMessage", (_dr != null && !String.IsNullOrEmpty(_dr["transcriptfrontsideMessage"].ToString()) ? _dr["transcriptfrontsideMessage"].ToString() : String.Empty));

            _fileFullPath = (_dr != null && !String.IsNullOrEmpty(_dr["transcriptbacksideFileName"].ToString()) ? (UDSUtil._myFileUploadPath + "/" + _dr["transcriptbacksideFileName"].ToString()) : String.Empty);
            _fileFullPath = (!String.IsNullOrEmpty(_fileFullPath) && Util.FileExist(_fileFullPath) ? (UDSUtil._myHandlerPath + "?action=imagefile2stream&f=" + Util.EncodeToBase64(_fileFullPath)) : String.Empty);

            _dataRecorded.Add("TranscriptBacksideFileDir", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myFileUploadPath : String.Empty));
            _dataRecorded.Add("TranscriptBacksideFileName", (!String.IsNullOrEmpty(_fileFullPath) ? _dr["transcriptbacksideFileName"] : String.Empty));
            _dataRecorded.Add("TranscriptBacksideFileFullPath", (!String.IsNullOrEmpty(_fileFullPath) ? _fileFullPath : String.Empty));
            _dataRecorded.Add("TranscriptBacksideWidth", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myTranscriptWidthShow.ToString() : String.Empty));
            _dataRecorded.Add("TranscriptBacksideHeight", (!String.IsNullOrEmpty(_fileFullPath) ? UDSUtil._myTranscriptHeightShow.ToString() : String.Empty));
            _dataRecorded.Add("TranscriptBacksideSavedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["transcriptbacksideSavedStatus"].ToString()) ? _dr["transcriptbacksideSavedStatus"] : "N"));
            _dataRecorded.Add("TranscriptBacksideSubmittedStatus", (_dr != null && !String.IsNullOrEmpty(_dr["transcriptbacksideSubmittedStatus"].ToString()) ? _dr["transcriptbacksideSubmittedStatus"].ToString() : "N"));
            _dataRecorded.Add("TranscriptBacksideApprovalStatus", (_dr != null && !String.IsNullOrEmpty(_dr["transcriptbacksideApprovalStatus"].ToString()) ? _dr["transcriptbacksideApprovalStatus"].ToString() : "S"));
            _dataRecorded.Add("TranscriptBacksideMessage", (_dr != null && !String.IsNullOrEmpty(_dr["transcriptbacksideMessage"].ToString()) ? _dr["transcriptbacksideMessage"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }

    public static Dictionary<string, object> SetValueDataRecorded(string _page, string _id)
    {
        Dictionary<string, object> _valueDataRecordedResult = new Dictionary<string, object>();
        Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
        DataSet _ds = new DataSet();

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE))
            _ds = Util.DBUtil.GetStudentRecords(_id);

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE))
            _ds = UDSDB.GetUDSStudentRecords(_id);

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE))
            _ds = UDSDB.GetUDSStudentRecords(_id);

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE))
            _ds = UDSDB.GetUDSStudentRecords(_id);

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE))
            _ds = UDSDB.GetUDSStudentRecords(_id);        

        if (_ds.Tables.Count > 0)
        {
            if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE))
                _dataRecorded = UDSUploadSubmitDocumentUtil.StudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE))
                _dataRecorded = UDSUploadSubmitDocumentUtil.OverviewUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE))
                _dataRecorded = ProfilePictureUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE))
                _dataRecorded = IdentityCardUtil.SetValueDataRecorded(_dataRecorded, _ds);

            if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE))
                _dataRecorded = TranscriptUtil.SetValueDataRecorded(_dataRecorded, _ds);
        }

        _ds.Dispose();

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTSTUDENTRECORDS_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTSTUDENTRECORDS), _dataRecorded);

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW), _dataRecorded);

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE), _dataRecorded);

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD), _dataRecorded);

        if (_page.Equals(PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE))
            _valueDataRecordedResult.Add(("DataRecorded" + SUBJECT_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT), _dataRecorded);

        return _valueDataRecordedResult;
    }

    public static Dictionary<string, object> GetDocumentFileAttribute(string _section)
    {
        Dictionary<string, object> _fileAttributeResult = new Dictionary<string, object>();
        int _width = 0;
        int _height = 0;
        int _widthShow = 0;
        int _heightShow = 0;
        int _zoom = 0;

        if (_section.Equals(SUBJECT_SECTION_PROFILEPICTURE))
        {
            _width = _myProfilePictureWidth;
            _height = _myProfilePictureHeight;
        }

        if (_section.Equals(SUBJECT_SECTION_IDENTITYCARD))
        {
            _width = _myIdentityCardWidth;
            _height = _myIdentityCardHeight;
        }

        if (_section.Equals(SUBJECT_SECTION_TRANSCRIPTFRONTSIDE))
        {
            _width = _myTranscriptWidth;
            _height = _myTranscriptHeight;
        }

        if (_section.Equals(SUBJECT_SECTION_TRANSCRIPTBACKSIDE))
        {
            _width = _myTranscriptWidth;
            _height = _myTranscriptHeight;
        }

        _fileAttributeResult.Clear();
        _fileAttributeResult.Add("Section", _section);
        _fileAttributeResult.Add("Width", _width);
        _fileAttributeResult.Add("Height", _height);
        _fileAttributeResult.Add("WidthShow", _widthShow);
        _fileAttributeResult.Add("HeightShow", _heightShow);
        _fileAttributeResult.Add("Zoom", _zoom);

        return _fileAttributeResult;
    }
}