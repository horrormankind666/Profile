/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๘/๐๙/๒๕๕๗>
Modify date : <๑๘/๐๒/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using NUtil;

public class ePFUI
{   
    public static StringBuilder GetMenuBar(Dictionary<string, object> _infoLogin)
    {
        StringBuilder _html = new StringBuilder();
        int _cookieError = int.Parse(_infoLogin["CookieError"].ToString());
        int _userError = int.Parse(_infoLogin["UserError"].ToString());
        string _studentCode = _infoLogin["StudentCode"].ToString();
        string _fullnameEN = _infoLogin["FullnameEN"].ToString();
    
        if (_cookieError.Equals(0) && _userError.Equals(0))
        {
            _html.AppendLine("<div class='menubar'>");
            _html.AppendLine("  <div class='menubar-layout'>");
            _html.AppendLine("      <div class='menubar-content'>");
            _html.AppendLine("          <div class='contentbody-left'>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li class='nohave-link'>");
            _html.AppendFormat("                    <div class='contentbody-left'>");
            _html.AppendFormat("                        <div class='float-left link-msg pr-0 en-label'>{0} ( {1} )</div>", _fullnameEN.ToUpper(), (!String.IsNullOrEmpty(_studentCode) ? _studentCode : "XXXXXXX"));
            _html.AppendFormat("                        <div class='float-left link-msg'><a class='link-click' id='link-{0}' href='javascript:void(0)'><span class='th-label'>{1}</span> <span class='en-label'>( {2} )</span></a></div>", ePFUtil._menu[3, 2].ToLower(), ePFUtil._menu[3, 0], ePFUtil._menu[3, 1]);
            _html.AppendLine("                      </div>");
            _html.AppendLine("                  </li>");
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("          <div class='contentbody-right'>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li class='have-link'><a class='link-msg link-click en-label' id='link-{0}' href='javascript:void(0)'>{1}</a></li>", ePFUtil._menu[1, 2].ToLower(), ePFUtil._menu[1, 1]);
            _html.AppendLine("                  <li class='split-vertical'></li>");
            _html.AppendFormat("                <li class='have-link link-submenu' id='link-{0}'><div class='link-msg en-label'>{1}</div>", ePFUtil._menu[2, 2].ToLower(), ePFUtil._menu[2, 1]);
            _html.AppendLine("                      <div class='submenu'>");
            _html.AppendLine("                          <ul>");
            _html.AppendFormat("                            <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFUtil._submenu[0, 2].ToLower(), ePFUtil._submenu[0, 0], "");
            _html.AppendFormat("                            <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFUtil._submenu[1, 2].ToLower(), ePFUtil._submenu[1, 0], "");
            _html.AppendFormat("                            <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFUtil._submenu[2, 2].ToLower(), ePFUtil._submenu[2, 0], "");
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
        string _infoOperatorSaveAll = _data["OperatorSaveAll"].ToString();
        string _infoOperatorApply = _data["OperatorApply"].ToString();
        string _infoOperatorUndo = _data["OperatorUndo"].ToString();
        string _infoOperatorPrint = _data["OperatorPrint"].ToString();
        string _infoOperatorUpload = _data["OperatorUpload"].ToString();
        string _infoOperatorTransfer = _data["OperatorTransfer"].ToString();
        string _infoOperatorExportAll = _data["OperatorExportAll"].ToString();
        string _infoOperatorExportSelected = _data["OperatorExportSelected"].ToString();
        string _infoOperatorProfile = _data["OperatorProfile"].ToString();
        string _infoOperatorClose = _data["OperatorClose"].ToString();        
        string _infoLinkTo = _data["LinkTo"].ToString();
        string _infoLinkTo1Id = _data["LinkTo1ID"].ToString();
        string _infoLinkTo1TH = _data["LinkTo1TH"].ToString();
        string _infoLinkTo1EN = _data["LinkTo1EN"].ToString();
        string _infoLinkTo1Page = _data["LinkTo1Page"].ToString();
        string _infoLinkTo2Id = _data["LinkTo2ID"].ToString();
        string _infoLinkTo2TH = _data["LinkTo2TH"].ToString();
        string _infoLinkTo2EN = _data["LinkTo2EN"].ToString();
        string _infoLinkTo2Page = _data["LinkTo2Page"].ToString();
        string _infoImportantId = _data["ImportantID"].ToString();
        string _infoImportantRecommendTitle = _data["ImportantRecommendTitle"].ToString();
        string _infoImportantRecommendMsgTH = _data["ImportantRecommendMsgTH"].ToString();
        string _infoImportantRecommendMsgEN = _data["ImportantRecommendMsgEN"].ToString();
        string _infoImportantSuccessTitle = _data["ImportantSuccessTitle"].ToString();
        string _infoImportantSuccessMsg = _data["ImportantSuccessMsg"].ToString();
        string[] _infoOperatorArray;
        string[] _infoLinkToArray;
        string[] _infoImportantMsgArray;
        List<string> _listOperator = new List<string>();
        List<string> _listLinkTo = new List<string>();
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
            !String.IsNullOrEmpty(_infoOperatorSaveAll) ||
            !String.IsNullOrEmpty(_infoOperatorApply) ||
            !String.IsNullOrEmpty(_infoOperatorUndo) ||
            !String.IsNullOrEmpty(_infoOperatorPrint) ||
            !String.IsNullOrEmpty(_infoOperatorUpload) ||
            !String.IsNullOrEmpty(_infoOperatorTransfer) ||
            !String.IsNullOrEmpty(_infoOperatorExportAll) ||
            !String.IsNullOrEmpty(_infoOperatorExportSelected) ||
            !String.IsNullOrEmpty(_infoOperatorProfile) ||
            !String.IsNullOrEmpty(_infoOperatorClose) ||            
            !String.IsNullOrEmpty(_infoLinkTo))
        {
            _html.AppendLine("              <div class='operator'>");
            _html.AppendLine("                  <ul>");

            if (!String.IsNullOrEmpty(_infoOperatorHome))
                _listOperator.Add("operator-home;" + _infoOperatorHome + ";Home");

            if (!String.IsNullOrEmpty(_infoOperatorNew))
                _listOperator.Add("operator-new;" + _infoOperatorNew + ";New");

            if (!String.IsNullOrEmpty(_infoOperatorEdit))
                _listOperator.Add("operator-edit;" + _infoOperatorEdit + ";Edit");

            if (!String.IsNullOrEmpty(_infoOperatorDelete))
                _listOperator.Add("operator-delete;" + _infoOperatorDelete + ";Delete");

            if (!String.IsNullOrEmpty(_infoOperatorExportAll))
                _listOperator.Add("operator-exportall;" + _infoOperatorExportAll + ";Export All");

            if (!String.IsNullOrEmpty(_infoOperatorExportSelected))
                _listOperator.Add("operator-exportselected;" + _infoOperatorExportSelected + ";Export Selected");

            if (!String.IsNullOrEmpty(_infoOperatorSearch))
                _listOperator.Add("operator-search;" + _infoOperatorSearch + ";Search");

            if (!String.IsNullOrEmpty(_infoOperatorReset))
                _listOperator.Add("operator-reset;" + _infoOperatorReset + ";Reset");

            if (!String.IsNullOrEmpty(_infoOperatorSave))
                _listOperator.Add("operator-save;" + _infoOperatorSave + ";Save");

            if (!String.IsNullOrEmpty(_infoOperatorSaveAll))
                _listOperator.Add("operator-saveall;" + _infoOperatorSaveAll + ";Save All");

            if (!String.IsNullOrEmpty(_infoOperatorApply))
                _listOperator.Add("operator-apply;" + _infoOperatorApply + ";Apply");

            if (!String.IsNullOrEmpty(_infoOperatorUndo))
                _listOperator.Add("operator-undo;" + _infoOperatorUndo + ";Clear");

            if (!String.IsNullOrEmpty(_infoOperatorPrint))
                _listOperator.Add("operator-print;" + _infoOperatorPrint + ";Print");

            if (!String.IsNullOrEmpty(_infoOperatorUpload))
                _listOperator.Add("operator-upload;" + _infoOperatorUpload + ";Upload");

            if (!String.IsNullOrEmpty(_infoOperatorTransfer))
                _listOperator.Add("operator-transfer;" + _infoOperatorTransfer + ";Transfer");

            if (!String.IsNullOrEmpty(_infoOperatorProfile))
                _listOperator.Add("operator-profile;" + _infoOperatorProfile + ";Profile");

            if (!String.IsNullOrEmpty(_infoOperatorClose))
                _listOperator.Add("operator-close;" + _infoOperatorClose + ";Close");

            if (!String.IsNullOrEmpty(_infoLinkTo))
                _listOperator.Add("operator-linkto;" + _infoLinkTo + ";Link To");

            for (_i = 0; _i < _listOperator.Count; _i++)
            {
                _infoOperatorArray = _listOperator[_i].Split(';');

                _html.AppendFormat("                <li class='{0}'><a class='link-click' id='{1}' href='javascript:void(0)'><div class='operator-img'></div><div class='operator-msg en-label'>{2}</div></a></li>", _infoOperatorArray[0], _infoOperatorArray[1], _infoOperatorArray[2]);
            }

            _html.AppendLine("                  </ul>");
            _html.AppendLine("              </div>");

            if (!String.IsNullOrEmpty(_infoLinkTo))
            {
                _html.AppendLine("          <div class='linkto'>");
                _html.AppendLine("              <ul>");
                
                if (!String.IsNullOrEmpty(_infoLinkTo1Id))
                    _listLinkTo.Add(_infoLinkTo1Id + ";" + _infoLinkTo1TH + ";" + _infoLinkTo1EN + ";" + _infoLinkTo1Page);

                if (!String.IsNullOrEmpty(_infoLinkTo2Id))
                    _listLinkTo.Add(_infoLinkTo2Id + ";" + _infoLinkTo2TH + ";" + _infoLinkTo2EN + ";" + _infoLinkTo2Page);

                for (_i = 0; _i < _listLinkTo.Count; _i++)
                {
                    _infoLinkToArray = _listLinkTo[_i].Split(';');

                    _html.AppendFormat("            <li class='{0}'><div class='link-click' id='{0}'><div class='linkto-msg th-label'>{1}</div><div class='linkto-msg en-label'>{2}</div></div></li>", _infoLinkToArray[0], _infoLinkToArray[1], _infoLinkToArray[2], (!String.IsNullOrEmpty(_infoLinkToArray[3]) ? _infoLinkToArray[3] : "javascript:void(0)"));
                }

                _html.AppendLine("              </ul>");
                _html.AppendLine("          </div>");
            }
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

    public static StringBuilder GetFrmHelp(string _page)
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");
        
        _ls = ePFDB.GetListText("TH", "Help.txt");

        if (_page.Equals(ePFUtil.PAGE_HELPCONTACTUS_MAIN))
        {
            _html.AppendLine("      <div>");
            _html.AppendLine("          <ul>");
            _html.AppendFormat("            <li class='th-label'>{0}</li>", _ls[0]);
            _html.AppendFormat("            <li class='th-label'>{0}</li>", _ls[1]);
            _html.AppendFormat("            <li class='th-label'>{0}</li>", _ls[2]);
            _html.AppendLine("          </ul>");
            _html.AppendLine("      </div>");
        }

        if (_page.Equals(ePFUtil.PAGE_HELPFILLINFORMATIONSTUDENTRECORDS_MAIN))
            _html.AppendFormat("    <div class='th-label'>{0}</div>", _ls[3]);

        _html.AppendLine("          <hr />");

        _ls = ePFDB.GetListText("EN", "Help.txt");

        if (_page.Equals(ePFUtil.PAGE_HELPCONTACTUS_MAIN))
        {
            _html.AppendLine("      <div>");
            _html.AppendLine("          <ul>");
            _html.AppendFormat("            <li class='en-label'>{0}</li>", _ls[0]);
            _html.AppendFormat("            <li class='en-label'>{0}</li>", _ls[1]);
            _html.AppendFormat("            <li class='en-label'>{0}</li>", _ls[2]);
            _html.AppendLine("          </ul>");
            _html.AppendLine("      </div>");
        }

        if (_page.Equals(ePFUtil.PAGE_HELPFILLINFORMATIONSTUDENTRECORDS_MAIN))
            _html.AppendFormat("    <div class='en-label'>{0}</div>", _ls[3]);

        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }
    
    public static StringBuilder GetComboboxTitlePrefix(string _idCombobox, string _gender)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Gender", _gender);
        _paramSearch.Add("CancelledStatus", "N");

        DataSet _ds = Util.DBUtil.GetListTitlePrefix(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = (_dr["id"].ToString() + ";" + _dr["perGenderId"].ToString());
            _optionText[_i] = (_dr["titlePrefixFullNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["titlePrefixFullNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["titlePrefixFullNameTH"].ToString()) ? " : " : String.Empty) + _dr["titlePrefixFullNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

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

    public static StringBuilder GetComboboxDistrict(string _idCombobox, string _provinceId)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Province", _provinceId);
        _paramSearch.Add("CancelledStatus", "N");

        DataSet _ds = Util.DBUtil.GetListDistrict(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = (_dr["id"].ToString() + ";" + _dr["zipCode"].ToString());
            _optionText[_i] = (_dr["districtNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["districtNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["districtNameTH"].ToString()) ? " : " : String.Empty) + _dr["districtNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxSubdistrict(string _idCombobox, string _districtId)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();        
        _paramSearch.Add("District", _districtId);
        _paramSearch.Add("CancelledStatus", "N");

        DataSet _ds = Util.DBUtil.GetListSubdistrict(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["subdistrictNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["subdistrictNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["subdistrictNameTH"].ToString()) ? " : " : String.Empty) + _dr["subdistrictNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxNationality(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();        
        _paramSearch.Add("CancelledStatus", "N");
        _paramSearch.Add("SortOrderBy", "Full Name ( TH )");

        DataSet _ds = Util.DBUtil.GetListNationality(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["nationalityNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["nationalityNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["nationalityNameTH"].ToString()) ? " : " : String.Empty) + _dr["nationalityNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxReligion(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();        
        _paramSearch.Add("CancelledStatus", "N");

        DataSet _ds = Util.DBUtil.GetListReligion(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["religionNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["religionNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["religionNameTH"].ToString()) ? " : " : String.Empty) + _dr["religionNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxImpairments(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("CancelledStatus", "N");

        DataSet _ds = Util.DBUtil.GetListImpairments(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["impairmentsNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["impairmentsNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["impairmentsNameTH"].ToString()) ? " : " : String.Empty) + _dr["impairmentsNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxOccupation(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[,] _optionList = ePFStudentRecordsUtil._occupation;
        int _i = 0;

        string[] _optionValue = new string[_optionList.GetLength(0)];
        string[] _optionText = new string[_optionList.GetLength(0)];

        for (_i = 0; _i < _optionList.GetLength(0); _i++)
        {
            _optionValue[_i] = _optionList[_i, 0];
            _optionText[_i] = (_optionList[_i, 1] + " : " + _optionList[_i, 2]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }    

    public static StringBuilder GetComboboxAgency(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("CancelledStatus", "N");
        _paramSearch.Add("SortOrderBy", "Full Name ( TH )");

        DataSet _ds = Util.DBUtil.GetListAgency(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["agencyNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["agencyNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["agencyNameTH"].ToString()) ? " : " : String.Empty) + _dr["agencyNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxScholarshipFrom(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[,] _optionList = ePFStudentRecordsUtil._scholarshipFrom;
        int _i = 0;

        string[] _optionValue = new string[_optionList.GetLength(0)];
        string[] _optionText = new string[_optionList.GetLength(0)];

        for (_i = 0; _i < _optionList.GetLength(0); _i++)
        {
            _optionValue[_i] = _optionList[_i, 0];
            _optionText[_i] = (_optionList[_i, 1] + " : " + _optionList[_i, 2]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }    

    public static StringBuilder GetComboboxRelationship(string _idCombobox, string _relationshipId)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Relationship", _relationshipId);
        _paramSearch.Add("CancelledStatus", "N");        

        DataSet _ds = Util.DBUtil.GetListRelationship(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = (_dr["id"].ToString() + ";" + _dr["relationshipNameEN"].ToString() + ";" + _dr["relationshipNameTH"].ToString() + ";" + _dr["perGenderId"].ToString());
            _optionText[_i] = (_dr["relationshipNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["relationshipNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["relationshipNameTH"].ToString()) ? " : " : String.Empty) + _dr["relationshipNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }    
    
    public static StringBuilder GetComboboxOrder(string _idCombobox, string[] _listCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[_listCombobox.GetLength(0)];
        string[] _optionText = new string[_listCombobox.GetLength(0)];

        for (_i = 0; _i < _listCombobox.GetLength(0); _i++)
        {
            _optionValue[_i] = _listCombobox[_i];
            _optionText[_i] = _listCombobox[_i];
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxYear(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _startYear = 2520;
        int _endYear = int.Parse(DateTime.Today.ToString("yyyy", new CultureInfo("th-TH")));
        int _i = 0;
        int _j = 0;

        string[] _optionValue = new string[(_endYear - _startYear) + 1];
        string[] _optionText = new string[(_endYear - _startYear) + 1];

        for (_i = _startYear; _i <= _endYear; _i++)
        {
            _optionValue[_j] = _i.ToString();
            _optionText[_j] = (_i.ToString() + " ( " + (_i - 543).ToString() + " )");

            _j++;
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public class PrivacyPolicyUI
    {
        private static string _idSectionMain = ePFUtil.ID_SECTION_PRIVACYPOLICY_MAIN.ToLower();

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
            public static StringBuilder GetMain(string _id)
            {
                Dictionary<string, object> _infoData = new Dictionary<string, object>();
                Dictionary<string, object> _infoDataResult = ePFUtil.GetInfoData(ePFUtil.PAGE_PRIVACYPOLICY_MAIN, _infoData);
                StringBuilder _html = new StringBuilder();
                int _i = 0;

                _html.AppendLine(ePFUI.GetInfoBar(_infoDataResult, true).ToString());
                _html.AppendLine("<div class='after-sticky'>");
                _html.AppendLine("  <div>");
                _html.AppendFormat("    <div class='sticky-left menulist' id='{0}-menu'>", _idSectionMain);
                _html.AppendLine("          <div class='menulist-layout'>");
                _html.AppendFormat("            <div class='menulist-content' id='{0}-menu-content'>", _idSectionMain);
                _html.AppendLine("                  <ul>");

                for (_i = 0; _i < 3; _i++)
                {
                    _html.AppendFormat("                <li class='have-link'><a class='link-click link-msg{0}' id='link-{1}' href='javascript:void(0)' alt='{1}'><div class='menu-itemtext'><div class='th-label'>{2}</div><div class='en-label'>{3}</div></div></a></li>",
                        (ePFUtil._menuPrivacyPolicy[_i, 2].Equals("active") ? " menu-active" : String.Empty),
                        ePFUtil._menuPrivacyPolicy[_i, 3].ToLower(),
                        ePFUtil._menuPrivacyPolicy[_i, 0],
                        ePFUtil._menuPrivacyPolicy[_i, 1]);
                }

                _html.AppendLine("                  </ul>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div id='{0}'>", _idSectionMain);
                _html.AppendFormat("        <div id='{0}-layout'>", _idSectionMain);
                _html.AppendFormat("            <div id='{0}-content'>", _idSectionMain);
                _html.AppendLine("                  <div class='switch-lang'>");
                _html.AppendLine("                      <ul>");
                _html.AppendLine("                          <li class='have-link'><a class='link-click active en-label' alt='TH' id='link-langth' href='javascript:void(0)'>TH</a></li>");
                _html.AppendLine("                          <li class='split-vertical'></li>");
                _html.AppendLine("                          <li class='have-link'><a class='link-click en-label' alt='EN' id='link-langen' href='javascript:void(0)'>EN</a></li>");
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                      <div class='clear'></div>");
                _html.AppendLine("                  </div>");
                _html.AppendFormat("                <div class='menu-active' id='{0}' alt='{1}'>{2}</div>",   ePFUtil._menuPrivacyPolicy[0, 3].ToLower(), ePFUtil._menuPrivacyPolicy[0, 4], String.Empty);
                _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>", ePFUtil._menuPrivacyPolicy[1, 3].ToLower(), ePFUtil._menuPrivacyPolicy[1, 4], String.Empty);
                _html.AppendFormat("                <div class='menu-noactive' id='{0}' alt='{1}'>{2}</div>", ePFUtil._menuPrivacyPolicy[2, 3].ToLower(), ePFUtil._menuPrivacyPolicy[2, 4], String.Empty);
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div");
                _html.AppendLine("</div");

                return _html;
            }
        }
    }
}