/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๗/๐๕/๒๕๕๘>
Modify date : <๐๘/๐๖/๒๕๕๙>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;

public class UDSUI
{    
    public static StringBuilder GetMenuBar(Dictionary<string, object> _infoLogin)
    {
        StringBuilder _html = new StringBuilder();
        int _cookieError = int.Parse(_infoLogin["CookieError"].ToString());
        int _userError = int.Parse(_infoLogin["UserError"].ToString()); ;
        string _studentCode = _infoLogin["StudentCode"].ToString();
        string _fullnameEN = _infoLogin["FullnameEN"].ToString();

        if (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(2) || _userError.Equals(3) || _userError.Equals(4)))
        {
            _html.AppendLine("<div class='menubar'>");
            _html.AppendLine("  <div class='menubar-layout'>");
            _html.AppendLine("      <div class='menubar-content'>");
            _html.AppendLine("          <div class='contentbody-left'>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li class='nohave-link'><div class='link-msg en-label'>{0} ( {1} )</div></li>", _fullnameEN.ToUpper(), (!String.IsNullOrEmpty(_studentCode) ? _studentCode : "XXXXXXX"));
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("          <div class='contentbody-right'>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li class='have-link link-submenu' id='link-{0}'><div class='link-msg en-label'>{1}</div>", UDSUtil._menu[0, 2].ToLower(), UDSUtil._menu[0, 1]);
            _html.AppendLine("                      <div class='submenu'>");
            _html.AppendLine("                          <ul>");
            _html.AppendFormat("                            <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", UDSUtil._submenu[0, 2].ToLower(), "", UDSUtil._submenu[0, 1]);
            _html.AppendLine("                          </ul>");
            _html.AppendLine("                      </div>");
            _html.AppendLine("                  </li>");
            _html.AppendLine("                  <li class='split-vertical'></li>");
            _html.AppendLine("                  <li class='have-link'><a class='link-msg link-click en-label' id='link-signout' href='javascript:void(0)'>Close Window</a></li>");
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendLine("      <div class='clear'></div>");
            _html.AppendLine("  </div>");
            _html.AppendLine("</div>");
        }          

        return _html;
    }

    public static StringBuilder GetInfoBar(Dictionary<string, object> _data, bool _sticky)
    {        
        int _i = 0;
        string _infoId = _data["ID"].ToString();
        string _infoIcon = _data["Icon"].ToString();
        string _infoTitle = String.Empty;
        string _infoTitleTH = _data["TitleTH"].ToString();
        string _infoTitleEN = _data["TitleEN"].ToString();
        string _infoContent = _data["Content"].ToString();
        string _infoOperatorHome = _data["OperatorHome"].ToString();
        string _infoOperatorNew = _data["OperatorNew"].ToString();
        string _infoOperatorEdit = _data["OperatorEdit"].ToString();
        string _infoOperatorDelete = _data["OperatorDelete"].ToString();
        string _infoOperatorSearch = _data["OperatorSearch"].ToString();
        string _infoOperatorReset = _data["OperatorReset"].ToString();
        string _infoOperatorSave = _data["OperatorSave"].ToString();
        string _infoOperatorApply = _data["OperatorApply"].ToString();
        string _infoOperatorUndo = _data["OperatorUndo"].ToString();
        string _infoOperatorPrint = _data["OperatorPrint"].ToString();
        string _infoOperatorUpload = _data["OperatorUpload"].ToString();
        string _infoOperatorTransfer = _data["OperatorTransfer"].ToString();
        string _infoOperatorExportAll = _data["OperatorExportAll"].ToString();
        string _infoOperatorExportSelected = _data["OperatorExportSelected"].ToString();
        string _infoOperatorProfile = _data["OperatorProfile"].ToString();
        string _infoOperatorClose = _data["OperatorClose"].ToString();
        string _infoImportantId = _data["ImportantID"].ToString();
        string _infoImportantRecommendTitle = _data["ImportantRecommendTitle"].ToString();
        string _infoImportantRecommendMsgTH = _data["ImportantRecommendMsgTH"].ToString();
        string _infoImportantRecommendMsgEN = _data["ImportantRecommendMsgEN"].ToString();
        string _infoImportantSuccessTitle = _data["ImportantSuccessTitle"].ToString();
        string _infoImportantSuccessMsg = _data["ImportantSuccessMsg"].ToString();
        string[] _infoOperatorArray;
        string[] _infoImportantMsgArray;
        List<string> _infoOperator = new List<string>();
        StringBuilder _html = new StringBuilder();

        _html.AppendFormat("<div class='infobar{0}' id='{1}'>", (_sticky.Equals(true) ? " sticky" : String.Empty), _infoId);
        _html.AppendLine("      <div class='infobar-layout'>");
        _html.AppendLine("          <div class='infobar-content'>");
        _html.AppendLine("              <div class='contentbody-left'>");

        if (!String.IsNullOrEmpty(_infoIcon) && (!String.IsNullOrEmpty(_infoTitleTH) || !String.IsNullOrEmpty(_infoTitleEN)) && String.IsNullOrEmpty(_infoContent))
        {
            _infoTitle += (!String.IsNullOrEmpty(_infoTitleTH) ? ("<div class='th-label'>" + _infoTitleTH + "</div>") : _infoTitle);
            //_infoTitle += (!String.IsNullOrEmpty(_infoTitleTH) && !String.IsNullOrEmpty(_infoTitleEN) ? "<span class='en-label'>&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;</span>" : _infoTitle);
            _infoTitle += (!String.IsNullOrEmpty(_infoTitleEN) ? ("<div class='en-label'>" + _infoTitleEN + "</div>") : _infoTitle);
            
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='icon {0}'></div></li>", _infoIcon);
            _html.AppendFormat("                <li><div class='title'>{0}</div></li>", _infoTitle);
            _html.AppendLine("              </ul>");
        }

        _html.AppendLine("              </div>");        
        _html.AppendLine("              <div class='contentbody-right'>");

        if (!String.IsNullOrEmpty(_infoOperatorHome) ||
            !String.IsNullOrEmpty(_infoOperatorNew) ||
            !String.IsNullOrEmpty(_infoOperatorEdit) ||
            !String.IsNullOrEmpty(_infoOperatorDelete) ||
            !String.IsNullOrEmpty(_infoOperatorSearch) ||
            !String.IsNullOrEmpty(_infoOperatorReset) ||
            !String.IsNullOrEmpty(_infoOperatorSave) ||
            !String.IsNullOrEmpty(_infoOperatorApply) ||
            !String.IsNullOrEmpty(_infoOperatorUndo) ||
            !String.IsNullOrEmpty(_infoOperatorPrint) ||
            !String.IsNullOrEmpty(_infoOperatorUpload) ||
            !String.IsNullOrEmpty(_infoOperatorTransfer) ||
            !String.IsNullOrEmpty(_infoOperatorExportAll) ||
            !String.IsNullOrEmpty(_infoOperatorExportSelected) ||
            !String.IsNullOrEmpty(_infoOperatorProfile) ||
            !String.IsNullOrEmpty(_infoOperatorClose))
        {
            _html.AppendLine("              <div class='operator'>");
            _html.AppendLine("                  <ul>");

            if (!String.IsNullOrEmpty(_infoOperatorHome))
                _infoOperator.Add("operator-home;" + _infoOperatorHome + ";Home");

            if (!String.IsNullOrEmpty(_infoOperatorNew))
                _infoOperator.Add("operator-new;" + _infoOperatorNew + ";New");

            if (!String.IsNullOrEmpty(_infoOperatorEdit))
                _infoOperator.Add("operator-edit;" + _infoOperatorEdit + ";Edit");

            if (!String.IsNullOrEmpty(_infoOperatorDelete))
                _infoOperator.Add("operator-delete;" + _infoOperatorDelete + ";Delete");

            if (!String.IsNullOrEmpty(_infoOperatorExportAll))
                _infoOperator.Add("operator-exportall;" + _infoOperatorExportAll + ";Export All");

            if (!String.IsNullOrEmpty(_infoOperatorExportSelected))
                _infoOperator.Add("operator-exportselected;" + _infoOperatorExportSelected + ";Export Selected");

            if (!String.IsNullOrEmpty(_infoOperatorSearch))
                _infoOperator.Add("operator-search;" + _infoOperatorSearch + ";Search");

            if (!String.IsNullOrEmpty(_infoOperatorReset))
                _infoOperator.Add("operator-reset;" + _infoOperatorReset + ";Reset");

            if (!String.IsNullOrEmpty(_infoOperatorSave))
                _infoOperator.Add("operator-save;" + _infoOperatorSave + ";Save");

            if (!String.IsNullOrEmpty(_infoOperatorApply))
                _infoOperator.Add("operator-apply;" + _infoOperatorApply + ";Apply");

            if (!String.IsNullOrEmpty(_infoOperatorUndo))
                _infoOperator.Add("operator-undo;" + _infoOperatorUndo + ";Clear");

            if (!String.IsNullOrEmpty(_infoOperatorPrint))
                _infoOperator.Add("operator-print;" + _infoOperatorPrint + ";Print");

            if (!String.IsNullOrEmpty(_infoOperatorUpload))
                _infoOperator.Add("operator-upload;" + _infoOperatorUpload + ";Upload");

            if (!String.IsNullOrEmpty(_infoOperatorTransfer))
                _infoOperator.Add("operator-transfer;" + _infoOperatorTransfer + ";Transfer");

            if (!String.IsNullOrEmpty(_infoOperatorProfile))
                _infoOperator.Add("operator-profile;" + _infoOperatorProfile + ";Profile");

            if (!String.IsNullOrEmpty(_infoOperatorClose))
                _infoOperator.Add("operator-close;" + _infoOperatorClose + ";Close");

            for (_i = 0; _i < _infoOperator.Count; _i++)
            {
                _infoOperatorArray = _infoOperator[_i].Split(';');

                _html.AppendFormat("                <li class='{0}'><a class='link-click' id='{1}' href='javascript:void(0)'><div class='operator-img'></div><div class='operator-msg en-label'>{2}</div></a></li>", _infoOperatorArray[0], _infoOperatorArray[1], _infoOperatorArray[2]);
            }

            _html.AppendLine("                  </ul>");
            _html.AppendLine("              </div>");
        }
                 
        _html.AppendLine("              </div>");
        _html.AppendLine("          </div>");
        _html.AppendLine("          <div class='clear'></div>");
        _html.AppendLine("      </div>");

        if (!String.IsNullOrEmpty(_infoImportantId))
        {
            _html.AppendFormat("<div class='important' id='{0}'>", _infoImportantId);

            if (!String.IsNullOrEmpty(_infoImportantRecommendTitle) || !String.IsNullOrEmpty(_infoImportantRecommendMsgTH) || !String.IsNullOrEmpty(_infoImportantRecommendMsgEN))
            {
                _html.AppendLine("  <div class='important-recommend'>");
                _html.AppendLine("      <div class='important-layout'>");
                _html.AppendLine("          <div class='important-content'>");
                _html.AppendLine("              <div class='important-msg'>");

                if (!String.IsNullOrEmpty(_infoImportantRecommendTitle))
                    _html.AppendFormat("            <div class='en-label title'>{0}</div>", _infoImportantRecommendTitle);

                if (!String.IsNullOrEmpty(_infoImportantRecommendMsgTH))
                {
                    _infoImportantMsgArray = _infoImportantRecommendMsgTH.Split(';');

                    for (_i = 0; _i < _infoImportantMsgArray.GetLength(0); _i++)
                    {
                        _html.AppendFormat("        <div class='th-label'>{0}</div>", _infoImportantMsgArray[_i]);
                    }
                }

                if (!String.IsNullOrEmpty(_infoImportantRecommendMsgEN))
                {
                    _infoImportantMsgArray = _infoImportantRecommendMsgEN.Split(';');

                    for (_i = 0; _i < _infoImportantMsgArray.GetLength(0); _i++)
                    {
                        _html.AppendFormat("        <div class='en-label'>{0}</div>", _infoImportantMsgArray[_i]);
                    }
                }

                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
            }

            if (!String.IsNullOrEmpty(_infoImportantSuccessTitle) || !String.IsNullOrEmpty(_infoImportantSuccessMsg))
            {
                _html.AppendLine("  <div class='important-success'>");
                _html.AppendLine("      <div class='important-layout'>");
                _html.AppendLine("          <div class='important-content'>");
                _html.AppendLine("              <div class='important-msg'>");

                if (!String.IsNullOrEmpty(_infoImportantSuccessTitle))
                    _html.AppendFormat("            <div class='en-label title'>{0}</div>", _infoImportantSuccessTitle);

                if (!String.IsNullOrEmpty(_infoImportantSuccessMsg))
                {
                    _infoImportantMsgArray = _infoImportantSuccessMsg.Split(';');

                    for (_i = 0; _i < _infoImportantMsgArray.GetLength(0); _i++)
                    {
                        _html.AppendFormat("        <div class='en-label'>{0}</div>", _infoImportantMsgArray[_i]);
                    }
                }

                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
            }

            _html.AppendLine("  </div>");
        }

        _html.AppendLine("  </div>");

        return _html;
    }
    
    public static StringBuilder GetFrmColumn(Dictionary<string, object> _contentFrmColumn)
    {
        StringBuilder _html = new StringBuilder();
        string _id = _contentFrmColumn["ID"].ToString();
        bool _highlight = (bool)_contentFrmColumn["HighLight"];
        string _titleTH = _contentFrmColumn["TitleTH"].ToString();
        string _titleEN = _contentFrmColumn["TitleEN"].ToString();
        string[] _titleENArray;
        string _discriptionTH = _contentFrmColumn["DiscriptionTH"].ToString();
        string _discriptionEN = _contentFrmColumn["DiscriptionEN"].ToString();
        bool _inputContentPaddingDown = (bool)_contentFrmColumn["InputContentPaddingDown"];
        string _inputContent = _contentFrmColumn["InputContent"].ToString();
        bool _require = (bool)_contentFrmColumn["Require"];
        bool _lastRow = (bool)_contentFrmColumn["LastRow"];
        int _i = 0;

        _html.AppendFormat("<div class='{0} {1}' id='{2}-content'>", (_lastRow.Equals(true) ? "form-lastrow" : "form-row"), (_highlight.Equals(true) ? "highlight-style3" : String.Empty), _id);
        _html.AppendLine("      <div>");
        _html.AppendLine("          <div class='form-labelcol'>");
        _html.AppendFormat("            <div id='{0}-label'>", _id);
        _html.AppendLine("                  <div class='form-label'>");

        if (!String.IsNullOrEmpty(_titleTH))
            _html.AppendFormat("                <div class='th-label'>{0}<div class='{1}'></div></div>", _titleTH, (_require.Equals(true) ? "icon-fieldmark" : "icon-fieldmarkblank"));

        if (!String.IsNullOrEmpty(_titleEN))
        {
            _titleENArray = _titleEN.Split(';');

            for (_i = 0; _i < _titleENArray.GetLength(0); _i++)
            {
                _html.AppendFormat("            <div class='en-label'>{0}<div class='icon-fieldmarkblank'></div></div>", _titleENArray[_i]);
            }
        }

        _html.AppendLine("                  </div>");
        _html.AppendLine("              </div>");
        _html.AppendLine("          </div>");
        _html.AppendFormat("        <div class='form-inputcol {0}'>", (_inputContentPaddingDown.Equals(true) ? "form-inputcol-paddingbottom" : String.Empty));
        _html.AppendFormat("            <div id='{0}-input'>", _id);
        _html.AppendLine("                  <div class='form-input'>");

        if (!String.IsNullOrEmpty(_inputContent))
            _html.AppendLine(_inputContent);

        if (!String.IsNullOrEmpty(_discriptionTH) || !String.IsNullOrEmpty(_discriptionEN))
        {
            _html.AppendLine("                  <div class='form-input-discription'>");

            if (!String.IsNullOrEmpty(_discriptionTH))
                _html.AppendFormat("                <div class='th-label'>{0}</div>", _discriptionTH);

            if (!String.IsNullOrEmpty(_discriptionEN))
                _html.AppendFormat("                <div class='en-label'>{0}</div>", _discriptionEN);

            _html.AppendLine("                  </div>");
        }

        _html.AppendLine("                  </div>");
        _html.AppendLine("              </div>");
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("      <div class='clear'></div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    public static StringBuilder GetComboboxCountry(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("CancelledStatus", "N");
        _paramSearch.Add("SortOrderBy", "Full Name ( TH )");

        DataSet _ds = Util.DBUtil.GetListCountry(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["countryNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["countryNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["countryNameTH"].ToString()) ? " : " : String.Empty) + _dr["countryNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxProvince(string _idCombobox, string _countryId)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Country", _countryId);
        _paramSearch.Add("CancelledStatus", "N");
        _paramSearch.Add("SortOrderBy", "Full Name ( TH )");

        DataSet _ds = Util.DBUtil.GetListProvince(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["provinceNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["provinceNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["provinceNameTH"].ToString()) ? " : " : String.Empty) + _dr["provinceNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxInsititue(string _idCombobox, string _provinceId)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Province", _provinceId);
        _paramSearch.Add("CancelledStatus", "N");
        _paramSearch.Add("SortOrderBy", "Full Name ( TH )");

        DataSet _ds = Util.DBUtil.GetListInstitute(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["institutelNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["institutelNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["institutelNameTH"].ToString()) ? " : " : String.Empty) + _dr["institutelNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetFrmContactUS()
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();
        int _i = 0;

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");

        _ls = UDSDB.GetListText("TH", "ContactUS.txt");

        _html.AppendFormat("        <div class='th-label'>{0}</div>", _ls[0]);
        _html.AppendLine("          <hr />");

        _ls = UDSDB.GetListText("EN", "ContactUS.txt");

        _html.AppendFormat("        <div class='en-label'>{0}</div>", _ls[0]);
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetFrmMeaningOfDocumentApprovalStatus()
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", UDSUtil.ID_SECTION_MEANINGOFAPPROVALSTATUS_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");

        for (_i = 0; _i < UDSUtil._approvalStatus.GetLength(0); _i++)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='uploaddocument-approvalstatus uploaddocument-approvalstatus-{0}'></div></li>", UDSUtil._approvalStatus[_i, 2].ToLower());
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>", UDSUtil._approvalStatus[_i, 0]);
            _html.AppendFormat("                <li><div class='en-label'>&nbsp;: {0}</div></li>", UDSUtil._approvalStatus[_i, 1]);
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("          <div class='clear'></div>");
            _html.AppendLine("          <hr />");
        }

        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    public static StringBuilder GetFrmViewDocument(string _section, string _fileFullPath)
    {
        StringBuilder _html = new StringBuilder();
        Dictionary<string, object> _fileAttribute = UDSUtil.GetDocumentFileAttribute(_section);

        _fileFullPath = (Util.FileExist(_fileFullPath) ? (UDSUtil._myHandlerPath + "?action=imagefile2stream&f=" + Util.EncodeToBase64(_fileFullPath)) : String.Empty);

        if (!String.IsNullOrEmpty(_fileFullPath))
        {
            _html.AppendLine("<div class='dialogpicture-form' align='center'>");
            _html.AppendLine("  <div class='form-layout'>");
            _html.AppendLine("      <div class='form-content'>");
            _html.AppendLine("          <div class='picture-content'>");
            _html.AppendLine("              <div class='picture-watermark'></div>");
            _html.AppendFormat("            <img src='{0}' width='{1}px' height='{2}px' />", _fileFullPath, _fileAttribute["Width"], _fileAttribute["Height"]);
            _html.AppendLine("          </div>");
            _html.AppendLine("      </div>");
            _html.AppendLine("  </div>");
            _html.AppendLine("</div>");
        }

        return _html;
    }

    public static StringBuilder GetFrmViewMessage()
    {
        StringBuilder _html = new StringBuilder();

        _html.AppendFormat("<div class='dialog-form' id='{0}-form'>", UDSUtil.ID_SECTION_VIEWMESSAGE_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        _html.AppendFormat("            <textarea class='textareabox'></textarea>");
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    public static StringBuilder GetFrmRecommendUploadProfilePicture()
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");

        _ls = UDSDB.GetListText("TH", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}</div>", _ls[0]);
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetFrmRecommendUploadIdentityCard()
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");

        _ls = UDSDB.GetListText("TH", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}<br />{1}<br />{2}<br />{3}<br />{4}<br />{5}<br /><br />{6}</div>", _ls[1], _ls[2], _ls[3], _ls[4], _ls[5], _ls[6], _ls[7]);
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetFrmRecommendUploadTranscript()
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");

        _ls = UDSDB.GetListText("TH", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}<br />{1}<br />{2}<br />{3}<br />{4}<br />{5}<br /><br />{6}</div>", _ls[8], _ls[9], _ls[10], _ls[11], _ls[12], _ls[13], _ls[14]);
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetFrmRecommendUploadTranscriptFrontside()
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");

        _ls = UDSDB.GetListText("TH", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}<br />{1}<br />{2}<br />{3}<br />{4}<br />{5}<br /><br />{6}</div>", _ls[15], _ls[16], _ls[17], _ls[18], _ls[19], _ls[20], _ls[21]);
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetFrmRecommendUploadTranscriptBackside()
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");

        _ls = UDSDB.GetListText("TH", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}<br />{1}<br />{2}<br />{3}<br />{4}<br />{5}<br /><br />{6}</div>", _ls[22], _ls[23], _ls[24], _ls[25], _ls[26], _ls[27], _ls[28]);
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetFrmRecommendSubmit()
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");

        _ls = UDSDB.GetListText("TH", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}</div>", _ls[29]);
        _html.AppendLine("          <hr />");

        _ls = UDSDB.GetListText("EN", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}</div>", _ls[0]);        
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }
}