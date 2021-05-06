using System;
using System.Web.UI;

public partial class index : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        int _error = Util.CopyFileServerToServer(@"D:\Programming\Profile\Content\FileUpload\UploadDocument", "2559000002Profile20-01-2016@14-28-58.jpg", @"\\10.41.101.31\f\STWeb\StudentWeb\Resources\images", "2559000002Profile20-01-2016@14-28-58.jpg");

        string _command = "COPY D:\\Programming\\Profile\\Content\\FileUpload\\UploadDocument\\2559000002Profile20-01-2016@14-28-58.jpg \\\\10.41.101.31\\f\\STWeb\\StudentWeb\\Resources\\images";
        int _errorCommand = Util.ExecuteCommand(_command, 30000);

        int _connServer = Util.ConnectServerToServer(@"\\localhost\IPC$\Profile\Content\FileUpload\UploadDocument", "", "", UDSStaffUtil._mySiteServerPictureStudent, "cccbd", "46900000");

        int _timeOut = 30000;

        string _command = "NET USE " + @"\\localhost\Profile\Content\FileUpload\UploadDocument";
        int _errorCommand1 = Util.ExecuteCommand(_command, _timeOut);

        Response.Write(_errorCommand);
         Use ProcessStartInfo class.
        ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/C COPY D:\\Programming\\Profile\\Content\\FileUpload\\UploadDocument\\2559000002Profile20-01-2016@14-28-58.jpg D:\\");
        startInfo.CreateNoWindow = true;
        startInfo.UseShellExecute = true;
        startInfo.WindowStyle = ProcessWindowStyle.Normal;
        startInfo.Arguments = "COPY D:\\Programming\\Profile\\Content\\FileUpload\\UploadDocument\\2559000002Profile20-01-2016@14-28-58.jpg \\\\10.41.101.31\\f\\STWeb\\StudentWeb\\Resources\\images";
        Process _process = Process.Start(startInfo);
        _process.WaitForExit();
        */
        /*
        Dictionary<string, object> _valueProgressDataResult = new Dictionary<string, object>();
        _valueProgressDataResult.Add("Option",                  "selected");
        _valueProgressDataResult.Add("ParamSearch",             "");
        _valueProgressDataResult.Add("Selected",                "2559000001");
        _valueProgressDataResult.Add("SentDateAudit",           "");
        _valueProgressDataResult.Add("AuditedStatus",           "");
        _valueProgressDataResult.Add("ReceivedDateResultAudit", "");

        Dictionary<string, object> _infoLoginResult = UDSStaffUtil.GetInfoLogin(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS, "");
        UDSStaffProgressDataUtil.GetProcess(_infoLoginResult, UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS, _valueProgressDataResult);
        */
        /*
        Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        Dictionary<string, object> _paramChart = new Dictionary<string, object>();
        List<object> _level1SeriesName = new List<object>();
        List<object> _level1SeriesColor = new List<object>();
        List<object> _level1SeriesDataName = new List<object>();
        List<object> _level1SeriesDataColor = new List<object>();
        List<object> _level1SeriesDataValue = new List<object>();
        List<object> _level1SeriesDataDrillDown = new List<object>();
                    
        List<object> _level2SeriesId = new List<object>();
        List<object> _level2SeriesName = new List<object>();
        List<object> _level2SeriesDataName = new List<object>();
        List<object> _level2SeriesDataColor = new List<object>();
        List<object> _level2SeriesDataValue = new List<object>();
        List<object> _level2SeriesDataDrillDown = new List<object>();

        List<object> _seriesNameTemp1 = new List<object>();
        List<object> _seriesNameTemp2 = new List<object>();
        List<object> _seriesColorTemp1 = new List<object>();
        List<object> _seriesColorTemp2 = new List<object>();
        List<object> _seriesValueTemp1 = new List<object>();
        List<object> _seriesValueTemp2 = new List<object>();
        List<object> _seriesDrillDownTemp1 = new List<object>();
        List<object> _seriesDrillDownTemp2 = new List<object>();

        string[] _seriesArray1 = new string[10];
        string[] _seriesArray2 = new string[10];
        int _i;
                        
        _paramSearch.Add("SectionAction",   "approve");
        _paramSearch.Add("DocumentUpload",  "TranscriptFrontsideTranscriptBackside");
        _paramSearch.Add("ApprovalStatus",  "Y");

        DataSet _ds = UDSStaffDB.GetListUDSStudentRecords(
        _loginResult["Username"].ToString(),
        _loginResult["Userlevel"].ToString(),
        _loginResult["SystemGroup"].ToString(),
        UDSStaffUtil.SUBJECT_SECTION_AUDITTRANSCRIPTAPPROVEDVIEWCHART,
        _paramSearch);

        _paramChart.Add("RenderTo",         "container");
        _paramChart.Add("BackgroundColor",  "#FFFFFF");
        _paramChart.Add("Title",            "จำนวนโรงเรียนและจำนวนคนทั้งหมดที่ต้องส่งไปตรวจสอบคุณวุฒื");
        _paramChart.Add("LegendTitle",      "จำนวน ( โรงเรียน / คน ) : Number of ( school / people )");
        _paramChart.Add("Level1XAxisTitle", "");

        if (_ds.Tables[2].Rows.Count > 0)
        {
            _level1SeriesName.Clear();
            _level1SeriesColor.Clear();
            _level1SeriesDataName.Clear();
            _level1SeriesDataColor.Clear();
            _level1SeriesDataValue.Clear();
            _level1SeriesDataDrillDown.Clear();

            _level2SeriesId.Clear();
            _level2SeriesName.Clear();
            _level2SeriesDataName.Clear();
            _level2SeriesDataColor.Clear();
            _level2SeriesDataValue.Clear();
            _level2SeriesDataDrillDown.Clear();
                                                
            DataRow _dr1 = _ds.Tables[2].Rows[0];                        

            for(_i = 1; _i <= 2; _i++)
            {
                _seriesArray1 = _dr1["series" + _i].ToString().Split(',');

                _level1SeriesName.Add(_seriesArray1[2] + " : " + _seriesArray1[3]);
                _level1SeriesColor.Add(_seriesArray1[4]);

                _seriesNameTemp1 = new List<object>();
                _seriesColorTemp1 = new List<object>();
                _seriesValueTemp1 = new List<object>();
                _seriesDrillDownTemp1 = new List<object>();

                _seriesNameTemp1.Add(_seriesArray1[0] + " : " + _seriesArray1[1]);
                _seriesColorTemp1.Add(_seriesArray1[4]);
                _seriesValueTemp1.Add(_dr1["seriesValue" + _i]);
                _seriesDrillDownTemp1.Add(_seriesArray1[5]);

                _level1SeriesDataName.Add(_seriesNameTemp1);
                _level1SeriesDataColor.Add(_seriesColorTemp1);
                _level1SeriesDataValue.Add(_seriesValueTemp1);
                _level1SeriesDataDrillDown.Add(_seriesDrillDownTemp1);

                _level2SeriesId.Add(_seriesArray1[5]);
                _level2SeriesName.Add(_seriesArray1[2] + " : " + _seriesArray1[3] + " ( " + double.Parse(_dr1["seriesValue" + _i].ToString()).ToString("#,##0") + " )");
            }

            for (_i = 0; _i < _level2SeriesId.Count; _i++)
            {
                _seriesNameTemp2 = new List<object>();
                _seriesColorTemp2 = new List<object>();
                _seriesValueTemp2 = new List<object>();
                _seriesDrillDownTemp2 = new List<object>();

                foreach (DataRow _dr2 in _ds.Tables[3].Rows)
                {
                    _seriesNameTemp2.Add(_dr2["yearEntry"]);
                    _seriesColorTemp2.Add("");
                    _seriesValueTemp2.Add(_dr2["seriesValue" + (_i + 1)]);
                    _seriesDrillDownTemp2.Add("");
                }

                _level2SeriesDataName.Add(_seriesNameTemp2);
                _level2SeriesDataColor.Add(_seriesColorTemp2);
                _level2SeriesDataValue.Add(_seriesValueTemp2);
                _level2SeriesDataDrillDown.Add(_seriesDrillDownTemp2);
            }
        }
                    
        _ds.Dispose();

        Util.ChartUtil.Type                         = "bar";
        Util.ChartUtil.RenderTo                     = _paramChart["RenderTo"].ToString().ToLower();
        Util.ChartUtil.BackgroundColor              = _paramChart["BackgroundColor"].ToString();
        Util.ChartUtil.Title                        = _paramChart["Title"].ToString();
        Util.ChartUtil.LegendTitle                  = _paramChart["LegendTitle"].ToString();
        Util.ChartUtil.Level1XAxisTitle             = _paramChart["Level1XAxisTitle"].ToString();
        Util.ChartUtil.Level1YAxisTitle             = "";
        Util.ChartUtil.Level1SeriesName             = _level1SeriesName;
        Util.ChartUtil.Level1SeriesColor            = _level1SeriesColor;
        Util.ChartUtil.Level1SeriesColorByPoint     =  false;
        Util.ChartUtil.Level1SeriesDataName         = _level1SeriesDataName;
        Util.ChartUtil.Level1SeriesDataColor        = _level1SeriesDataColor;
        Util.ChartUtil.Level1SeriesDataValue        = _level1SeriesDataValue;
        Util.ChartUtil.Level1SeriesDataDrillDown    = _level1SeriesDataDrillDown;
        Util.ChartUtil.Level2SeriesId               = _level2SeriesId;
        Util.ChartUtil.Level2SeriesName             = _level2SeriesName;
        Util.ChartUtil.Level2SeriesColorByPoint     = false;
        Util.ChartUtil.Level2SeriesDataName         = _level2SeriesDataName;
        Util.ChartUtil.Level2SeriesDataColor        = _level2SeriesDataColor;
        Util.ChartUtil.Level2SeriesDataValue        = _level2SeriesDataValue;
        Util.ChartUtil.Level2SeriesDataDrillDown    = _level2SeriesDataDrillDown;
        Util.ChartUtil.Level3XAxisTitle             = "";
        Util.ChartUtil.Level3YAxisTitle             = "";
        Util.ChartUtil.Level3SeriesId               = new List<object>();
        Util.ChartUtil.Level3SeriesName             = new List<object>();
        Util.ChartUtil.Level3SeriesColorByPoint     = false;
        Util.ChartUtil.Level3SeriesDataName         = new List<object>();
        Util.ChartUtil.Level3SeriesDataColor        = new List<object>();
        Util.ChartUtil.Level3SeriesDataValue        = new List<object>();
        Util.ChartUtil.Level3SeriesDataDrillDown    = new List<object>();        

        Util.ChartUtil.GetChart();
        */
        /*
        Dictionary<string, object> _infoLoginResult = UDSStaffUtil.GetInfoLogin(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS, "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        string _option = "all";
        string _fileFullPath = String.Empty;
        string _studentId = String.Empty;
        string _folderEncode = String.Empty;
        string _fileEncode = String.Empty;
        int _connServer = 0;
        int _error = 0;
        int _complete = 0;
        int _i = 0;
        bool _copy = false;

        _paramSearch.Add("Keyword",         "");
        _paramSearch.Add("SectionAction",   "approve");
        _paramSearch.Add("YearEntry",       "2558");
        _paramSearch.Add("DocumentUpload",  "ProfilePictureIdentityCard");
        _paramSearch.Add("ApprovalStatus",  "Y");

        _connServer = Util.ConnectServerToServer(UDSStaffUtil._mySiteLocalPictureStudent, "", "", UDSStaffUtil._mySiteServerPictureStudent, "cccbd", "46900000");

        if (_connServer.Equals(0))
        {                        
        DataTable _dt1 = new DataTable();
        DataSet _ds1 = new DataSet();

        if (_option.Equals("selected"))
        {
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
            _ds1 = UDSStaffDB.GetListUDSStudentRecords(
                _infoLoginResult["Username"].ToString(),
                _infoLoginResult["Userlevel"].ToString(),
                _infoLoginResult["SystemGroup"].ToString(),
                _paramSearch);
        }

        foreach (DataRow _dr1 in _ds1.Tables[0].Rows)
        {                
            try
            {
                DataSet _ds2 = UDSStaffDB.GetUDSStudentRecords(_dr1["id"].ToString());
                        
                if (_ds2.Tables[0].Rows.Count > 0)
                {
                    DataRow _dr2 = _ds2.Tables[0].Rows[0];

                    _fileFullPath = (!String.IsNullOrEmpty(_dr2["profilepictureFileName"].ToString()) ? (UDSStaffUtil._myFileUploadPath + "/" + _dr2["profilepictureFileName"].ToString()) : String.Empty);
                                                            
                    _studentId  = _dr2["studentCode"].ToString();
                    _copy       = (!String.IsNullOrEmpty(_fileFullPath) && Util.FileExist(_fileFullPath) ? true : false);
                            
                    if (_copy.Equals(true))
                    {
                        _fileEncode     = (Util.EncodeToMD5(_studentId) + ".jpg");
                        _folderEncode   = Util.GetFolderNameFromStudentId(_studentId);
                        _error          = Util.CopyFileServerToServer(UDSStaffUtil._mySiteLocalPictureStudent, _dr2["profilepictureFileName"].ToString(), UDSStaffUtil._mySiteServerPictureStudent, (_folderEncode + "\\" + _fileEncode));

                        _complete++;
                    }

                    _ds2.Dispose();                    
                }
            }
            catch
            {
            }
        }
        }

        Response.Write(_complete);
        */
    }
}