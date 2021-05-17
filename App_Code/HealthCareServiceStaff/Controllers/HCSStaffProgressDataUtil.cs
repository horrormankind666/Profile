/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๙/๑๒/๒๕๕๘>
Modify date : <๑๘/๐๓/๒๕๖๓>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานฟังก์ชั่นการประมวลผลข้อมูล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web;
using NUtil;
using NExportToPDF;
using OfficeOpenXml;
using MUAccountService;

public class HCSStaffProgressDataUtil
{
    public static Dictionary<string, object> SetValueProcess(HttpContext _c)
    {
        Dictionary<string, object> _valueProcessResult = new Dictionary<string, object>();
        _valueProcessResult.Add("Option", _c.Request["option"]);
        _valueProcessResult.Add("ParamSearch", _c.Request["paramsearch"]);
        _valueProcessResult.Add("Selected", _c.Request["selected"]);
        _valueProcessResult.Add("RegistrationForm", _c.Request["registrationform"]);

        return _valueProcessResult;
    }

    public static Dictionary<string, object> GetProcess(Dictionary<string, object> _infoLogin, string _page, Dictionary<string, object> _dataProcess)
    {
        Dictionary<string, object> _processResult = new Dictionary<string, object>();
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        string _option = _dataProcess["Option"].ToString();
        string _valueParamSearch = _dataProcess["ParamSearch"].ToString();
        string _valueSelected = _dataProcess["Selected"].ToString();
        string _keyword = String.Empty;
        string _degreeLevel = String.Empty;
        string _faculty = String.Empty;
        string _program = String.Empty;
        string _yearEntry = String.Empty;
        string _entranceType = String.Empty;
        string _studentStatus = String.Empty;
        string _hcsJoin = String.Empty;
        string _registrationForm = String.Empty;        
        string _downloadStatus = String.Empty;
        string _termServiceType = String.Empty;
        string _consentStatus = String.Empty;
        string _termServiceNote = String.Empty;
        string _consentDateStart = String.Empty;
        string _consentDateEnd = String.Empty;
        string _sortOrderBy = String.Empty;
        string _sortExpression = String.Empty;
        string[] _valueArray1;
        string[] _valueArray2;
        string[] _valueSearch;
        int _i = 0;
        
        if (_option.Equals("selected") || _option.Equals("all"))
        {
            if (_option.Equals("selected") && !String.IsNullOrEmpty(_valueSelected))
                _keyword = _valueSelected;

            if (_option.Equals("all") && !String.IsNullOrEmpty(_valueParamSearch))
            {
                _valueArray1 = _valueParamSearch.Split(',');
                _valueSearch = new string[_valueArray1.GetLength(0)];

                for (_i = 0; _i < _valueArray1.GetLength(0); _i++)
                {
                    _valueArray2 = _valueArray1[_i].Split(':');
                    _valueSearch[_i] = _valueArray2[1];
                }

                if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS) ||
                    _page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS) ||
                    _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS) ||
                    _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS) ||
                    _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS) ||
                    _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
                {
                    _keyword = _valueSearch[0];
                    _degreeLevel = _valueSearch[1];
                    _faculty = _valueSearch[2];
                    _program = _valueSearch[3];
                    _yearEntry = _valueSearch[4];
                    _entranceType = _valueSearch[5];
                    _studentStatus = _valueSearch[6];
                    _hcsJoin = _valueSearch[7];
                    _registrationForm = _valueSearch[8];
                    _downloadStatus = _valueSearch[9];
                    _termServiceType = _valueSearch[10];
                    _consentStatus = _valueSearch[11];
                    _termServiceNote = _valueSearch[12];
                    _consentDateStart = _valueSearch[13];
                    _consentDateEnd = _valueSearch[14];
                    _sortOrderBy = _valueSearch[15];
                    _sortExpression = _valueSearch[16];
                }
            }

            _paramSearch.Add("Keyword", _keyword);
            _paramSearch.Add("DegreeLevel", _degreeLevel);
            _paramSearch.Add("Faculty", _faculty);
            _paramSearch.Add("Program", _program);
            _paramSearch.Add("YearEntry", _yearEntry);
            _paramSearch.Add("EntranceType", _entranceType);
            _paramSearch.Add("StudentStatus", _studentStatus);
            _paramSearch.Add("HCSJoin", _hcsJoin);
            _paramSearch.Add("RegistrationForm", _registrationForm);
            _paramSearch.Add("DownloadStatus", _downloadStatus);
            _paramSearch.Add("TermServiceType", _termServiceType);
            _paramSearch.Add("ConsentStatus", _consentStatus);
            _paramSearch.Add("TermServiceNote", _termServiceNote);
            _paramSearch.Add("ConsentDateStart", _consentDateStart);
            _paramSearch.Add("ConsentDateEnd", _consentDateEnd);
            _paramSearch.Add("SortOrderBy", _sortOrderBy);
            _paramSearch.Add("SortExpression", _sortExpression);
        }

        _processResult = GetProcess(_infoLogin, _page, _paramSearch, _dataProcess);

        return _processResult;
    }

    private static Dictionary<string, object> GetProcess(Dictionary<string, object> _infoLogin, string _page, Dictionary<string, object> _paramSearch, Dictionary<string, object> _dataProcess)
    {
        Dictionary<string, object> _processResult = new Dictionary<string, object>();
        Dictionary<string, object> _dataRecorded = new Dictionary<string, object>();
        string _username = _infoLogin["Username"].ToString();
        string _option = _dataProcess["Option"].ToString();
        string _fileName = ((DateTime.Now).ToString("dd-MM-yyyy@HH-mm-ss", new CultureInfo("en-US")));
        string _filePath = HttpContext.Current.Server.MapPath(HCSStaffUtil._myFileDownloadPath + "\\");
        string _msgTH = String.Empty;
        string _msgDetail = String.Empty;
        string _reportName = String.Empty;
        int _tbIndex = 0;
        int _saveError = 0;
        int _complete = 0;
        int _incomplete = 0;
        int _i = 0;
        int _j = 0;
        bool _error = false;
        List<string> _valueDetailCompleteTemp = new List<string>();
        List<string> _valueDetailComplte = new List<string>();
        List<string> _valueDetailIncomplte = new List<string>();        

        if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS))
        {
            _fileName = (_dataProcess["RegistrationForm"] + _fileName);
            _msgTH = "ดาว์นโหลดข้อมูล";
            _tbIndex = 0;
        }
        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS))
        {
            _fileName = (HCSStaffUtil.SUBJECT_SECTION_HEALTHINFORMATION + _fileName);
            _msgTH = "ส่งออกข้อมูล";
            _tbIndex = 0;
        }
        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS))
        {
            _fileName = (HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM + _fileName);
            _msgTH = "ส่งออกข้อมูล";
            _reportName = HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE;
            _tbIndex = 2;
        }
        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS))
        {
            _fileName = (HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORM + _fileName);
            _msgTH = "ส่งออกข้อมูล";
            _reportName = HCSStaffUtil.SUBJECT_SECTION_STATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE;
            _tbIndex = 2;
        }
        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS))
        {
            _fileName = (HCSStaffUtil.SUBJECT_SECTION_TERMSERVICEHCSCONSENTREGISTRATION + _fileName);
            _msgTH = "ส่งออกข้อมูล";
            _tbIndex = 0;
        }
        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
        {
            _fileName = (HCSStaffUtil.SUBJECT_SECTION_TERMSERVICEHCSCONSENTOOCA + _fileName);
            _msgTH = "ส่งออกข้อมูล";
            _tbIndex = 0;
        }

        ExportToPDF _e = new ExportToPDF();
        DataTable _dt1 = new DataTable();
        DataTable _dt2 = new DataTable();
        DataSet _ds1 = new DataSet();
        MUService _account = new MUService();

        if (_option.Equals("selected"))
        {
            _tbIndex = 0;
                
            string[] _valueSelected = _paramSearch["Keyword"].ToString().Split('|');
            _dt1.Columns.Add("id");

            for (_i = 0; _i < _valueSelected.GetLength(0); _i++)
            {
                _dt1.Rows.Add(_valueSelected[_i]);
            }

            _ds1.Tables.Add(_dt1);
        }                
                                    
        if (_option.Equals("all"))
        {
            if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS))
                _ds1 = HCSStaffDB.GetListHCSStudentRecords(
                    _infoLogin["Username"].ToString(),
                    _infoLogin["Userlevel"].ToString(),
                    _infoLogin["SystemGroup"].ToString(),
                    _paramSearch
                );

            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS))
                _ds1 = HCSStaffDB.GetListHCSDownloadLog(
                    _infoLogin["Username"].ToString(),
                    _infoLogin["Userlevel"].ToString(),
                    _infoLogin["SystemGroup"].ToString(),
                    _reportName,
                    _paramSearch
                );

            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
                _ds1 = HCSStaffDB.GetListHCSStudentTermServiceConsent(
                    _infoLogin["Username"].ToString(),
                    _infoLogin["Userlevel"].ToString(),
                    _infoLogin["SystemGroup"].ToString(),
                    _paramSearch
                );
        }

        if (_ds1.Tables[_tbIndex].Rows.Count > 0)
        {
            if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS))
            {
                _fileName += ".pdf";

                _e.ExportToPDFConnectWithSaveFile(_filePath + _fileName);
                _e.PDFConnectTemplate(HCSStaffUtil._myPDFFormTemplate, "pdfwithsavefile");
            }
                
            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
                _dt2 = HCSStaffUtil.SetColumnDataTable(_page);

            _i = 0;
                
            foreach (DataRow _dr1 in _ds1.Tables[_tbIndex].Rows)
            {
                try
                {
                    _error = false;
                    _saveError = 0;
                        
                    if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS) ||
                        _page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS) ||
                        _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS) ||
                        _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS) ||
                        _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
                    {
                        DataSet _ds2 = new DataSet();

                        if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS) ||
                            _page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS) ||
                            _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS))
                            _ds2 = HCSStaffDB.GetHCSStudentRecords(_dr1["id"].ToString());

                        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS))
                            _ds2 = HCSStaffDB.GetHCSStudentTermServiceConsent(_dr1["id"].ToString(), "HCS_CONSENT_REGISTRATION");

                        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
                            _ds2 = HCSStaffDB.GetHCSStudentTermServiceConsent(_dr1["id"].ToString(), "HCS_CONSENT_OOCA");

                        if (_ds2.Tables[0].Rows.Count > 0)
                        {
                            DataRow _dr2 = _ds2.Tables[0].Rows[0];
                                
                            if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS))
                            {
                                _dataRecorded.Clear();
                                _dataRecorded = HCSStaffDownloadRegistrationFormUtil.StudentRecordsUtil.SetValueDataRecorded(_dataRecorded, _ds2);
                                
                                HCSStaffDownloadRegistrationFormUtil.GenerateRegistrationFormUtil _h = new HCSStaffDownloadRegistrationFormUtil.GenerateRegistrationFormUtil();                                
                                   
                                DataSet _ds3 = Util.DBUtil.ExecuteCommandStoredProcedure("sp_hcsSetDownloadLog",
                                    new SqlParameter("@personId", _dataRecorded["PersonId"]),
                                    new SqlParameter("@registrationForm", _dataProcess["RegistrationForm"]),
                                    new SqlParameter("@by", _username),
                                    new SqlParameter("@ip", Util.GetIP())
                                );
                         
                                DataRow _dr3 = _ds3.Tables[0].Rows[0];
                                _saveError = (int.Parse(_dr3[0].ToString()).Equals(1) ? 0 : 1);
                                   
                                if (_saveError.Equals(0))
                                {
                                    _h.GetRegistrationForm(_dataProcess["RegistrationForm"].ToString(), _dataRecorded, _e);

                                    _error = false;
                                    _msgDetail = (_dr2["studentCode"] + "-" + _dr2["idCard"]);
                                    _valueDetailCompleteTemp.Add(
                                        _dr2["id"].ToString() + ";" +
                                        DateTime.Parse(_dr3[1].ToString()).ToString("dd/MM/yyyy HH:mm:ss") + ";" +
                                        double.Parse(_dr3[2].ToString()).ToString("#,##0")
                                    );
                                }
                                else
                                {
                                    _error = true;
                                    _msgDetail = (_dr2["studentCode"] + "-" + _dr2["idCard"] + " : บันทึกข้อมูลไม่สำเร็จ");
                                }

                                _ds3.Dispose();
                            }
                                
                            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS))
                            {
                                _i++;

                                string _weight = String.Empty;
                                string _height = String.Empty;
                                string _bmi = String.Empty;
                                string _bmiDate = String.Empty;
                                string _country = String.Empty;
                                string _travelDate = String.Empty;
                                string _travelAbroad = String.Empty;
                                string[] _bodyMassArray;
                                string[] _bodyMassDetail = new string[4];
                                string[] _travelAbroadArray;
                                string[] _travelAbroadDetail = new string[2];
                                    
                                if (!String.IsNullOrEmpty(_dr2["bodyMassDetail"].ToString()))
                                {
                                    _bodyMassArray = _dr2["bodyMassDetail"].ToString().Split(';');

                                    for (_j = 0; _j < _bodyMassArray.GetLength(0); _j++)
                                    {
                                        _bodyMassDetail = _bodyMassArray[_j].Split(':');
                                        _weight += _bodyMassDetail[0];
                                        _height += _bodyMassDetail[1];
                                        _bmi += _bodyMassDetail[2];
                                        _bmiDate += (_bodyMassDetail[3].Substring(6, 4) + "-" + _bodyMassDetail[3].Substring(3, 2) + "-" + _bodyMassDetail[3].Substring(0, 2));

                                        if ((_j + 1) < _bodyMassArray.GetLength(0))
                                        {
                                            _weight += "\r\n";
                                            _height += "\r\n";
                                            _bmi += "\r\n";
                                            _bmiDate += "\r\n";
                                        }
                                    }
                                }
                                    
                                if (!String.IsNullOrEmpty(_dr2["travelAbroadDetail"].ToString()))
                                {
                                    _travelAbroadArray = _dr2["travelAbroadDetail"].ToString().Split(';');

                                    for (_j = 0; _j < _travelAbroadArray.GetLength(0); _j++)
                                    {
                                        _travelAbroadDetail = _travelAbroadArray[_j].Split(',');
                                        _country = (_travelAbroadDetail[0].Split(':'))[0];
                                        _travelDate = (_travelAbroadDetail[1].Substring(6, 4) + "-" + _travelAbroadDetail[1].Substring(3, 2) + "-" + _travelAbroadDetail[1].Substring(0, 2));
                                        _travelAbroad += (_country + ", " + _travelDate);

                                        if ((_j + 1) < _travelAbroadArray.GetLength(0))
                                            _travelAbroad += "\r\n";
                                    }
                                }

                                _dt2.Rows.Add(
                                    _i.ToString("#,##0"),
                                    _dr2["studentCode"],
                                    _dr2["idCard"],
                                    _dr2["titlePrefixFullNameTH"],
                                    _dr2["firstName"],
                                    _dr2["middleName"],
                                    _dr2["lastName"],
                                    _dr2["titlePrefixFullNameEN"],
                                    _dr2["firstNameEN"],
                                    _dr2["middleNameEN"],
                                    _dr2["lastNameEN"],
                                    (!String.IsNullOrEmpty(_dr2["birthDate"].ToString()) ? DateTime.Parse(_dr2["birthDate"].ToString()).ToString("yyyy-MM-dd") : ""),
                                    _dr2["nationalityNameTH"],
                                    _dr2["facultyCode"],
                                    (_dr2["programCode"] + " " + _dr2["majorCode"] + " " + _dr2["groupNum"]),
                                    _dr2["hcsJoin"],
                                    _dr2["bloodTypeNameEN"],
                                    _weight,
                                    _height,
                                    _bmi,
                                    _bmiDate,
                                    _dr2["diseasesDetail"].ToString().Replace("\n", "\r\n"),
                                    _dr2["intoleranceDetail"].ToString().Replace("\n", "\r\n"),
                                    "",
                                    _travelAbroad,
                                    _dr2["impairmentsNameTH"],
                                    _dr2["impairmentsEquipment"],
                                    _dr2["childhoodNumber"],
                                    _dr2["occupationNameTHFather"],
                                    _dr2["occupationNameTHMother"],
                                    _dr2["occupationNameTHParent"]
                                );
                            }

                            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS))
                            {
                                _i++;

                                _dt2.Rows.Add(
                                    _i.ToString("#,##0"),
                                    _dr2["studentCode"],
                                    _dr2["idCard"],
                                    _dr2["titlePrefixFullNameTH"],
                                    _dr2["firstName"],
                                    _dr2["middleName"],
                                    _dr2["lastName"],
                                    _dr2["titlePrefixFullNameEN"],
                                    _dr2["firstNameEN"],
                                    _dr2["middleNameEN"],
                                    _dr2["lastNameEN"],
                                    _dr2["facultyCode"],
                                    (_dr2["programCode"] + " " + _dr2["majorCode"] + " " + _dr2["groupNum"]),
                                    _dr2["yearEntry"],
                                    _dr2["stdEntranceTypeNameTH"],
                                    _dr2["statusTypeNameTH"],
                                    _dr1["logForm"],
                                    DateTime.Parse(_dr1["latestDateDownload"].ToString()).ToString("dd/MM/yyyy HH:mm:ss"),
                                    double.Parse(_dr1["countDownload"].ToString()).ToString("#,##0")
                                );
                            }

                            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS))
                            {
                                _i++;

                                _dt2.Rows.Add(
                                    _i.ToString("#,##0"),
                                    _dr2["studentCode"],
                                    _dr2["idCard"],
                                    _dr2["titlePrefixFullNameTH"],
                                    Util.GetFullName("", "", _dr2["firstName"].ToString(), _dr2["middleName"].ToString(), _dr2["lastName"].ToString()),
                                    (!String.IsNullOrEmpty(_dr2["birthDate"].ToString()) ? DateTime.Parse(_dr2["birthDate"].ToString()).ToString("yyyy-MM-dd") : ""),
                                    _dr2["facultyNameEN"],
                                    (_dr2["termStatus"].Equals("Y") ? "Agree" : (_dr2["termStatus"].Equals("N") ? "Disagree" : "No Comment")),
                                    _dr2["termNote"],
                                    (!String.IsNullOrEmpty(_dr2["termDate"].ToString()) ? DateTime.Parse(_dr2["termDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : "")
                                );
                            }

                            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
                            {
                                _i++;
                                
                                string _mailMU = _account.getMailAddress(("u" + _dr2["studentCode"]), "2efa3ac33e", 1).Replace(",", ", ");

                                _dt2.Rows.Add(
                                    _mailMU,
                                    _dr2["email"],
                                    _dr2["studentCode"],
                                    _dr2["class"],
                                    _dr2["facultyNameEN"],
                                    _dr2["titlePrefixFullNameTH"],
                                    (_dr2["firstName"] + (!String.IsNullOrEmpty(_dr2["middleName"].ToString()) ? (" " + _dr2["middleName"]) : String.Empty)),
                                    _dr2["lastName"],
                                    _dr2["genderFullNameEN"],
                                    _dr2["nationalityNameEN"],
                                    _dr2["statusTypeNameTH"],
                                    (_dr2["termStatus"].Equals("Y") ? "Agree" : (_dr2["termStatus"].Equals("N") ? "Disagree" : "No Comment")),
                                    (!String.IsNullOrEmpty(_dr2["termDate"].ToString()) ? DateTime.Parse(_dr2["termDate"].ToString()).ToString("dd/MM/yyyy HH:mm:ss") : ""),
                                    (!String.IsNullOrEmpty(_dr2["telephoneCurrent"].ToString()) ? _dr2["telephoneCurrent"] : _dr2["telephonePermanent"]),
                                    (!String.IsNullOrEmpty(_dr2["telephoneCurrentParent"].ToString()) ? _dr2["telephoneCurrentParent"] : _dr2["telephonePermanentParent"])
                                );
                            }
                        }
                        else
                        {
                            _error = true;
                            _msgDetail = (_dr1["id"].ToString() + " : ไม่พบข้อมูล");
                        }

                        _ds2.Dispose();
                    }
                        
                    if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS))
                    {
                        _dt2.Rows.Add(
                            _dr1["logForm"].ToString(),
                            _dr1["yearEntry"].ToString(),
                            double.Parse(_dr1["countDownload"].ToString()).ToString("#,##0"),
                            double.Parse(_dr1["countPeople"].ToString()).ToString("#,##0")
                        );
                    }

                    if (_error.Equals(false))
                    {
                        _valueDetailComplte.Add(_msgDetail);
                        _complete++;
                    }
                    else
                    {
                        _valueDetailIncomplte.Add(_msgDetail);
                        _incomplete++;
                    }
                }
                catch
                {
                    _valueDetailIncomplte.Add(_dr1["id"].ToString() + " : ประมวลผลไม่สำเร็จ");
                    _incomplete++;
                }
            }
                
            if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS))
                _e.ExportToPdfDisconnectWithSaveFile();
        }
           
        _ds1.Dispose();

        if (_complete > 0)
        {   
            if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS) ||
                _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
            {
                _fileName += ".xlsx";

                MemoryStream _ms = new MemoryStream();
                FileStream _fs = new FileStream(_filePath + _fileName, FileMode.Create, FileAccess.Write);
                ExcelPackage _pk = new ExcelPackage();
                ExcelWorksheet _ws = _pk.Workbook.Worksheets.Add("Sheet1");

                int _maxRowCellRange = (_complete + 1); ;
                int _maxColCellRange = _dt2.Columns.Count;
                int _maxRowCellHeader = 1;
                int _maxColCellHeader = _dt2.Columns.Count;

                Util.SetCellExcel(_ws, _maxRowCellRange, _maxColCellRange, _maxRowCellHeader, _maxColCellHeader);

                if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS))
                {
                    List<object> _cellContent = new List<object>
                    {
                        new[] { "ลำดับ", "No.", "center", "" },
                        new[] { "Student ID", "StudentCode", "center", "" },
                        new[] { "ID Card / Passport", "IdCard", "center", "" },
                        new[] { "คำนำหน้าภาษาไทย", "TitlePrefixTH", "", "" },
                        new[] { "ชื่อภาษาไทย", "FirstName", "", "" },
                        new[] { "ชื่อกลางภาษาไทย", "MiddleName", "", "" },
                        new[] { "นามสกุลภาษาไทย", "LastName", "", "" },
                        new[] { "คำนำหน้าภาษาอังกฤษ", "TitlePrefixEN", "", "" },
                        new[] { "ชื่อภาษาอังกฤษ", "FirstNameEN", "", "" },
                        new[] { "ชื่อกลางภาษาอังกฤษ", "MiddleNameEN", "", "" },
                        new[] { "นามสกุลภาษาอังกฤษ", "LastNameEN", "", "" },
                        new[] { "วันเกิด", "BirthDate", "center", "" },
                        new[] { "สัญชาติ", "Nationality", "center", "" },
                        new[] { "คณะ", "Faculty", "center", "" },
                        new[] { "หลักสูตร", "Program", "center", "" },
                        new[] { "สิทธิขึ้นทะเบียนสิทธิรักษาพยาบาล", "HCSJoin", "center", "" },
                        new[] { "หมู่เลือด", "BloodType", "center", "" },
                        new[] { "น้ำหนัก ( กก. )", "Weight", "center", "" },
                        new[] { "ส่วนสูง ( ซม. )", "Height", "center", "" },
                        new[] { "BMI", "BMI", "center", "" },
                        new[] { "BMI ข้อมูล ณ วันที่", "BMIDate", "center", "" },
                        new[] { "โรคประจำตัว", "Diseases", "", "true" },
                        new[] { "ประวัติแพ้ยา", "Intolerance", "", "true" },
                        new[] { "วัคซีนที่เคยรับ", "Vaccine", "", "" },
                        new[] { "ประวัติเดินทางไปต่างประเทศและวันที่เดินทาง", "TravelAbroad", "", "true" },
                        new[] { "ความบกพร่อง", "Impairments", "", "" },
                        new[] { "อุปกรณ์ช่วยเหลือ", "ImpairmentsEquipment", "", "" },
                        new[] { "เป็นบุตรลำดับที่", "ChildhoodNumber", "center", "" },
                        new[] { "อาชีพของบิดา", "OccupationFather", "", "" },
                        new[] { "อาชีพของมารดา", "OccupationMother", "", "" },
                        new[] { "อาชีพของผู้ปกครอง", "OccupationParent", "", "" }
                    };

                    _i = 1;

                    foreach (object _c in _cellContent)
                    {
                        string _header = ((string[])_c)[0];

                        _ws.Cells[1, _i].Value = _header;
                        _i++;
                    }

                    Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                }

                if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL1VIEWTABLE_PROGRESS))
                {
                    List<object> _cellContent = new List<object>
                    {
                        new[] { "แบบฟอร์มบริการสุขภาพ", "HealthCareServiceForm", "", "" },
                        new[] { "ปีที่เข้าศึกษา", "YearEntry", "center", "" },
                        new[] { "จำนวนการดาวน์โหลด ( ครั้ง )", "NumberofDownload", "right", "" },
                        new[] { "จำนวนนักศึกษาที่ดาวน์โหลด ( คน )", "NumberofStudent", "right", "" }
                    };

                    _i = 1;

                    foreach (object _c in _cellContent)
                    {
                        string _header = ((string[])_c)[0];

                        _ws.Cells[1, _i].Value = _header;
                        _i++;
                    }

                    Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                }

                if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS))
                {
                    List<object> _cellContent = new List<object>
                    {
                        new[] { "ลำดับ", "No.", "center", "" },
                        new[] { "Student ID", "StudentCode", "center", "" },
                        new[] { "ID Card / Passport", "IdCard", "center", "" },
                        new[] { "คำนำหน้าภาษาไทย", "TitlePrefixTH", "", "" },
                        new[] { "ชื่อภาษาไทย", "FirstName", "", "" },
                        new[] { "ชื่อกลางภาษาไทย", "MiddleName", "", "" },
                        new[] { "นามสกุลภาษาไทย", "LastName", "", "" },
                        new[] { "คำนำหน้าภาษาอังกฤษ", "TitlePrefixEN", "", "" },
                        new[] { "ชื่อภาษาอังกฤษ", "FirstNameEN", "", "" },
                        new[] { "ชื่อกลางภาษาอังกฤษ", "MiddleNameEN", "", "" },
                        new[] { "นามสกุลภาษาอังกฤษ", "LastNameEN", "", "" },
                        new[] { "คณะ", "Faculty", "center", "" },
                        new[] { "หลักสูตร", "Program", "center", "" },
                        new[] { "ปีที่เข้าศึกษา", "YearEntry", "center", "" },
                        new[] { "ระบบการสอบเข้า", "AdmissionType", "", "" },
                        new[] { "สถานภาพการเป็นนักศึกษา", "StudentStatus", "center", "" },
                        new[] { "แบบฟอร์มบริการสุขภาพ", "HealthCareServiceForm", "center", "" },
                        new[] { "วันที่ดาวน์โหลดล่าสุด", "LatestDateDownload", "center", "" },
                        new[] { "จำนวนการดาวน์โหลด ( ครั้ง )", "NumberofDownload", "center", "" }
                    };

                    _i = 1;

                    foreach (object _c in _cellContent)
                    {
                        string _header = ((string[])_c)[0];

                        _ws.Cells[1, _i].Value = _header;
                        _i++;
                    }

                    Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                }

                if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_PROGRESS))
                {
                    List<object> _cellContent = new List<object>
                    {
                        new[] { "ลำดับที่ ", "No.", "center", "" },
                        new[] { "รหัสนักศึกษา", "StudentCode", "center", "" },
                        new[] { "เลขบัตรประชาชน", "IdCard", "center", "" },
                        new[] { "คำนำหน้า", "TitlePrefixTH", "center", "" },
                        new[] { "ชื่อ-สกุล", "Fullname", "", "" },
                        new[] { "วันเกิด", "BirthDate", "center", "" },
                        new[] { "ส่วนงาน", "Faculty", "", "" },
                        new[] { "ความประสงค์", "ConsentStatus", "center", "" },
                        new[] { "สถานพยาบาล", "Hospital", "center", "" },
                        new[] { "วันที่ยินยอม", "ConsentDate", "center", "" }
                    };

                    _i = 1;

                    foreach (object _c in _cellContent)
                    {
                        string _header = ((string[])_c)[0];

                        _ws.Cells[1, _i].Value = _header;
                        _i++;
                    }

                    Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                }

                if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
                {
                    List<object> _cellContent = new List<object>
                    {
                        new[] { "E-mail", "EmailAddress", "", "" },
                        new[] { "E-mail [MU]", "MuEmailAddress", "", "" },
                        new[] { "Student ID", "StudentCode", "center", "" },
                        new[] { "Class", "Class", "center", "" },
                        new[] { "Faculty [EN]", "Faculty", "", "" },
                        new[] { "Title [TH]", "TitlePrefixTH", "", "" },
                        new[] { "First Name [TH]", "FirstName", "", "" },
                        new[] { "Surname [TH]", "LastName", "", "" },
                        new[] { "Sex", "Gender", "center", "" },
                        new[] { "Nationality", "Nationality", "center", "" },
                        new[] { "Student Status", "StudentStatus", "center", "" },
                        new[] { "Status Concent Form", "ConsentStatus", "center", "" },
                        new[] { "Last Update [Concent]", "ConsentDate", "center", "" },
                        new[] { "เบอร์ผู้ปกครอง", "TelephoneParent", "", "" },
                        new[] { "เบอร์ นศ.", "Telephone", "", "" }
                    };

                    _i = 1;

                    foreach (object _c in _cellContent)
                    {
                        string _header = ((string[])_c)[0];

                        _ws.Cells[1, _i].Value = _header;
                        _i++;
                    }

                    Util.GetListDataToExcel(_cellContent, _dt2, _ws, (_maxRowCellHeader + 1));
                }

                _ws.Cells.AutoFitColumns();

                _pk.SaveAs(_ms);
                _ms.WriteTo(_fs);

                _ms.Close();
                _ms.Dispose();
                _fs.Close();
                _fs.Dispose();
            }
        }

        if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS))
        {
            _valueDetailComplte.Clear();
            _valueDetailComplte = _valueDetailCompleteTemp;
        }

        _processResult.Add("Complete", _complete.ToString("#,##0"));
        _processResult.Add("Incomplete", _incomplete.ToString("#,##0"));
        _processResult.Add("DetailComplete", String.Join(",", _valueDetailComplte.ToArray()));
        _processResult.Add("DetailIncomplete", String.Join(",", _valueDetailIncomplte.ToArray()));
        _processResult.Add("DownloadFolder", HCSStaffUtil._myFileDownloadPath);
        _processResult.Add("DownloadFile", _fileName);

        return _processResult;
    }
}