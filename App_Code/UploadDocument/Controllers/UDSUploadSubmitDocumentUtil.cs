/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๘/๐๕/๒๕๕๘>
Modify date : <๐๗/๐๖/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นทั่วไปในส่วนของการอัพโหลดเอกสารของนักศึกษา>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using NUtil;

public class UDSUploadSubmitDocumentUtil
{    
    public static string[,] _menuUpload = new string[,]
    {
        { "ผลการอัพโหลดเอกสาร", "Overview", "", "", "", UDSUtil.SUBJECT_SECTION_OVERVIEW, UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE, UDSUtil.PAGE_UPLOADSUBMITDOCUMENTOVERVIEW_ADDUPDATE },
        { "อัพโหลดรูปภาพประจำตัว", "Upload Profile Picture", "รูปภาพประจำตัว", "Profile Picture", "", UDSUtil.SUBJECT_SECTION_PROFILEPICTURE, UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE, UDSUtil.PAGE_UPLOADSUBMITDOCUMENTPROFILEPICTURE_ADDUPDATE },
        { "อัพโหลดบัตรประจำตัวประชาชน", "Upload Identity Card", "บัตรประจำตัวประชาชน", "Identity Card", "", UDSUtil.SUBJECT_SECTION_IDENTITYCARD, UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE, UDSUtil.PAGE_UPLOADSUBMITDOCUMENTIDENTITYCARD_ADDUPDATE },
        { "อัพโหลดระเบียนแสดงผลการเรียน", "Upload Transcript", "ระเบียนแสดงผลการเรียน", "Transcript", "", UDSUtil.SUBJECT_SECTION_TRANSCRIPT, UDSUtil.ID_SECTION_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE, UDSUtil.PAGE_UPLOADSUBMITDOCUMENTTRANSCRIPT_ADDUPDATE }
    };

    public static string[,] _documentUpload = new string[,]
    {
        { "รูปภาพประจำตัว", "Profile Picture", "ProfilePicture" },
        { "บัตรประจำตัวประชาชน", "Identity Card", "IdentityCard" },
        { "ระเบียนแสดงผลการเรียน ( ด้านหน้า ) ", "Transcript ( Frontside )", "TranscriptFrontside" },
        { "ระเบียนแสดงผลการเรียน ( ด้านหลัง ) ", "Transcript ( Backside )", "TranscriptBackside" }
    };

    public static string[,] _documentUploadDetail = new string[,]
    {
        { "Name of Institution", "NameofInstitution" },
        { "Country", "Country" },
        { "State / Province", "Province" },
        { "File Name", "FileName" },
        { "File Type", "FileType" },
        { "File Size", "FileSize" },
        { "Uploaded Date", "SavedDate" },
        { "Submitted Date", "SubmittedStatus" },
        { "Approval Status", "ApprovalStatus" },
        { "Approval Date", "ApprovalDate" },
        { "Message", "Message" }
    };

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

            _studentPicture = (_dr != null && !String.IsNullOrEmpty(_dr["profilePictureName"].ToString()) ? (UDSUtil._myURLPictureStudent + "/" + _dr["profilePictureName"].ToString()) : String.Empty);
            _studentPicture = (!String.IsNullOrEmpty(_studentPicture) && Util.FileSiteExist(_studentPicture) ? (UDSUtil._myHandlerPath + "?action=image2stream&f=" + Util.EncodeToBase64(_studentPicture)) : String.Empty);

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
            _dataRecorded.Add("DegreeLevelNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["degreeLevelNameTH"].ToString()) ? _dr["degreeLevelNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("DegreeLevelNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["degreeLevelNameEN"].ToString()) ? _dr["degreeLevelNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("FacultyNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameTH"].ToString()) ? _dr["facultyNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("FacultyNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["facultyNameEN"].ToString()) ? _dr["facultyNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? _dr["programNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("ProgramNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? _dr["programNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("YearEntry", (_dr != null && !String.IsNullOrEmpty(_dr["yearEntry"].ToString()) ? _dr["yearEntry"].ToString() : String.Empty));
            _dataRecorded.Add("Class", (_dr != null && !String.IsNullOrEmpty(_dr["class"].ToString()) ? _dr["class"].ToString() : String.Empty));
            _dataRecorded.Add("StatusTypeNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["statusTypeNameTH"].ToString()) ? _dr["statusTypeNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("StatusTypeNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["statusTypeNameEN"].ToString()) ? _dr["statusTypeNameEN"].ToString() : String.Empty));
            _dataRecorded.Add("GraduationDate", (_dr != null && !String.IsNullOrEmpty(_dr["graduateDate"].ToString()) ? DateTime.Parse(_dr["graduateDate"].ToString()).ToString("dd/MM/yyyy") : String.Empty));
            _dataRecorded.Add("EntranceTypeNameTH", (_dr != null && !String.IsNullOrEmpty(_dr["stdEntranceTypeNameTH"].ToString()) ? _dr["stdEntranceTypeNameTH"].ToString() : String.Empty));
            _dataRecorded.Add("EntranceTypeNameEN", (_dr != null && !String.IsNullOrEmpty(_dr["stdEntranceTypeNameEN"].ToString()) ? _dr["stdEntranceTypeNameEN"].ToString() : String.Empty));

            return _dataRecorded;
        }
    }
    
    public class OverviewUtil
    {
        public static Dictionary<string, object> SetValueDataRecorded(Dictionary<string, object> _dataRecorded, DataSet _ds)
        {                     
            string _instituteNameTH = String.Empty;
            string _instituteNameEN = String.Empty;
            string _instituteCountryNameTH = String.Empty;
            string _instituteCountryNameEN = String.Empty;
            string _instituteProvinceNameTH = String.Empty;
            string _instituteProvinceNameEN = String.Empty;
            string _fileDir = String.Empty;
            string _fileName = String.Empty;
            string _fileFullPath = String.Empty;
            string _fileExtension = String.Empty;
            string _fileSize = String.Empty;
            string _savedStatus = String.Empty;
            string _savedDate = String.Empty;
            string _submittedStatus = String.Empty;
            string _submittedDate = String.Empty;
            string _approvalStatus = String.Empty;
            string _approvalDate = String.Empty;
            string _message = String.Empty;            
            string _section = String.Empty;
            string[] _keyDict = new string[16];
            int _i = 0;
            DataRow _dr = null;

            if (_ds.Tables[0].Rows.Count > 0)
                _dr = _ds.Tables[0].Rows[0];

            for (_i = 0; _i < _documentUpload.GetLength(0); _i++)
            {
                _section = _documentUpload[_i, 2];
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

                _instituteNameTH = String.Empty;
                _instituteNameEN = String.Empty;
                _instituteCountryNameTH = String.Empty;
                _instituteCountryNameEN = String.Empty;
                _instituteProvinceNameTH = String.Empty;
                _instituteProvinceNameEN = String.Empty;

                if (_section.Equals(UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE) || _section.Equals(UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE))
                {                
                    _instituteNameTH = (_dr != null && !String.IsNullOrEmpty(_dr["institutelNameTHTranscript"].ToString()) ? _dr["institutelNameTHTranscript"].ToString() : String.Empty);
                    _instituteNameEN = (_dr != null && !String.IsNullOrEmpty(_dr["institutelNameENTranscript"].ToString()) ? _dr["institutelNameENTranscript"].ToString() : String.Empty);
                    _instituteCountryNameTH = (_dr != null && !String.IsNullOrEmpty(_dr["instituteCountryNameTHTranscript"].ToString()) ? _dr["instituteCountryNameTHTranscript"].ToString() : String.Empty);
                    _instituteCountryNameEN = (_dr != null && !String.IsNullOrEmpty(_dr["instituteCountryNameENTranscript"].ToString()) ? _dr["instituteCountryNameENTranscript"].ToString() : String.Empty);
                    _instituteProvinceNameTH = (_dr != null && !String.IsNullOrEmpty(_dr["instituteProvinceNameTHTranscript"].ToString()) ? _dr["instituteProvinceNameTHTranscript"].ToString() : String.Empty);
                    _instituteProvinceNameEN = (_dr != null && !String.IsNullOrEmpty(_dr["instituteProvinceNameENTranscript"].ToString()) ? _dr["instituteProvinceNameENTranscript"].ToString() : String.Empty);
                }

                _fileName = (_dr != null ? _dr[_section.ToLower() + "FileName"].ToString() : String.Empty);
                _fileDir = (!String.IsNullOrEmpty(_fileName) ? UDSUtil._myFileUploadPath : String.Empty);
                _fileName = (!String.IsNullOrEmpty(_fileName) ? _fileName : String.Empty); 
                _fileFullPath = (!String.IsNullOrEmpty(_fileName) ? (UDSUtil._myFileUploadPath + "/" + _fileName) : String.Empty);
                _fileExtension = String.Empty;
                _fileSize = String.Empty;

                if (!String.IsNullOrEmpty(_fileFullPath))
                {
                    FileInfo _f = new FileInfo(HttpContext.Current.Server.MapPath(_fileFullPath));                    
                    
                    _fileExtension = (_f.Extension.ToUpper().Replace(".", "") + " File");

                    try
                    {
                        _fileSize = (((double)_f.Length / (double)1024).ToString("#,##0.00") + " KB");                    
                    }
                    catch
                    {
                        _fileSize = "0 KB";
                    }
                }

                _fileFullPath = (Util.FileExist(_fileFullPath) ? (UDSUtil._myHandlerPath + "?action=imagefile2stream&f=" + Util.EncodeToBase64(_fileFullPath)) : String.Empty);

                _savedStatus = (_dr != null ? _dr[_section.ToLower() + "SavedStatus"].ToString() : String.Empty);
                _savedDate = (_savedStatus.Equals("Y") ? DateTime.Parse(_dr[_section.ToLower() + "SavedDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty);

                _submittedStatus = (_dr != null ? _dr[_section.ToLower() + "SubmittedStatus"].ToString() : String.Empty);
                _submittedDate = (_submittedStatus.Equals("Y") ? DateTime.Parse(_dr[_section.ToLower() + "SubmittedDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty);

                _approvalStatus = (_dr != null ? _dr[_section.ToLower() + "ApprovalStatus"].ToString() : String.Empty);
                _approvalStatus = (!String.IsNullOrEmpty(_approvalStatus) ? _approvalStatus : String.Empty);
                _approvalDate = (_approvalStatus.Equals("Y") || _approvalStatus.Equals("N") ? DateTime.Parse(_dr[_section.ToLower() + "ApprovalDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : String.Empty);
                _message = (_approvalStatus.Equals("N") && !String.IsNullOrEmpty(_dr[_section.ToLower() + "Message"].ToString()) ? _dr[_section.ToLower() + "Message"].ToString() : String.Empty);

                _dataRecorded.Add(_keyDict[0], _instituteNameTH);
                _dataRecorded.Add(_keyDict[1], _instituteNameEN);
                _dataRecorded.Add(_keyDict[2], _instituteCountryNameTH);
                _dataRecorded.Add(_keyDict[3], _instituteCountryNameEN);
                _dataRecorded.Add(_keyDict[4], _instituteProvinceNameTH);
                _dataRecorded.Add(_keyDict[5], _instituteProvinceNameEN);
                _dataRecorded.Add(_keyDict[6], _fileDir);
                _dataRecorded.Add(_keyDict[7], _fileName);
                _dataRecorded.Add(_keyDict[8], _fileFullPath);
                _dataRecorded.Add(_keyDict[9], _fileExtension);
                _dataRecorded.Add(_keyDict[10], _fileSize);
                _dataRecorded.Add(_keyDict[11], _savedDate);
                _dataRecorded.Add(_keyDict[12], _submittedDate);
                _dataRecorded.Add(_keyDict[13], _approvalStatus);
                _dataRecorded.Add(_keyDict[14], _approvalDate);
                _dataRecorded.Add(_keyDict[15], _message);
            }
            
            return _dataRecorded;
        }
    }        

    public static Dictionary<string, object> GetFileAttribute(string _section)
    {
        Dictionary<string, object> _fileAttributeResult = new Dictionary<string, object>();
        int _width = 0;
        int _height = 0;
        int _widthShow = 0;
        int _heightShow = 0;
        int _zoom = 0;

        if (_section.Equals(UDSUtil.SUBJECT_SECTION_PROFILEPICTURE))
        {
            _section = "Profile";
            _width = UDSUtil._myProfilePictureWidth;
            _height = UDSUtil._myProfilePictureHeight;
            _widthShow = UDSUtil._myProfilePictureWidthShow;
            _heightShow = UDSUtil._myProfilePictureHeightShow;
            _zoom = UDSUtil._myProfilePictureZoom;
        }

        if (_section.Equals(UDSUtil.SUBJECT_SECTION_IDENTITYCARD))
        {
            _section = "IdCard";
            _width = UDSUtil._myIdentityCardWidth;
            _height = UDSUtil._myIdentityCardHeight;
            _widthShow = UDSUtil._myIdentityCardWidthShow;
            _heightShow = UDSUtil._myIdentityCardHeightShow;
            _zoom = UDSUtil._myIdentityCardZoom;
        }

        if (_section.Equals(UDSUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE) || _section.Equals(UDSUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE))
        {
            _width = UDSUtil._myTranscriptWidth;
            _height = UDSUtil._myTranscriptHeight;
            _widthShow = UDSUtil._myTranscriptWidthShow;
            _heightShow = UDSUtil._myTranscriptHeightShow;
            _zoom = UDSUtil._myTranscriptZoom;
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

    public static Dictionary<string, object> CropAndSaveFile(string _personId, string _section, string _sourceDir, string _sourceFile, int _cropX, int _cropY)
    {        
        Dictionary<string, object> _saveFileResult = new Dictionary<string, object>();
        Dictionary<string, object> _fileAttribute = GetFileAttribute(_section);
        string[] _sourceFileArray = _sourceFile.Split('.');
        string _destDir = UDSUtil._myFileUploadPath;
        string _destFile = String.Empty;
        string _destFileFormat = _sourceFileArray[_sourceFileArray.GetLength(0) - 1].ToLower();
        int _error = 0;
        int _destWidth = 0;
        int _destHeight = 0;

        _destFile = (_personId + _fileAttribute["Section"].ToString() + (DateTime.Now).ToString("dd-MM-yyyy@HH-mm-ss", new CultureInfo("en-US")) + "." + _destFileFormat);
        _destWidth = (int)_fileAttribute["Width"];
        _destHeight = (int)_fileAttribute["Height"];

        Util.RemoveMultipleFiles(_destDir, ("*" + _personId + _fileAttribute["Section"].ToString() + "*.*"));

        _error = Util.ImageProcessUtil.CropAndSaveFile(_sourceDir, _sourceFile, _destDir, _destFile, _destFileFormat, _destWidth, _destHeight, (_cropX * (int)_fileAttribute["Zoom"]), (_cropY * (int)_fileAttribute["Zoom"]));

        _saveFileResult.Add("Error", _error);
        _saveFileResult.Add("FileDir", _destDir);
        _saveFileResult.Add("FileName", _destFile);
        _saveFileResult.Add("WidthShow", _fileAttribute["WidthShow"]);
        _saveFileResult.Add("HeightShow", _fileAttribute["HeightShow"]);
        _saveFileResult.Add("FileFullPath", (_error.Equals(0) ? ("../../../Content/Handler/UploadDocument/UDSHandler.ashx?action=image2stream&f=" + Util.EncodeToBase64(_destDir + "/" + _destFile)) : String.Empty));

        return _saveFileResult;
    }
}