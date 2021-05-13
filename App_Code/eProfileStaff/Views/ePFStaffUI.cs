/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๔/๑๒/๒๕๕๗>
Modify date : <๑๒/๐๕/๒๕๖๔>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using NUtil;
using NFinServiceLogin;

public class ePFStaffUI
{
    public static StringBuilder GetMenuBar(Dictionary<string, object> _infoLogin, string _page)
    {
        StringBuilder _html = new StringBuilder();
        int _cookieError = int.Parse(_infoLogin["CookieError"].ToString());
        int _userError = int.Parse(_infoLogin["UserError"].ToString());
        int _i = 0;
        int _j = 0;
        string _username = _infoLogin["Username"].ToString();
        string _fullnameEN = _infoLogin["FullnameEN"].ToString();
        string _fullnameTH = _infoLogin["FullnameTH"].ToString();
        string _department = _infoLogin["Department"].ToString();
        string _faculty = _infoLogin["Faculty"].ToString();
        string _userlevel = _infoLogin["Userlevel"].ToString();
    
        if (_cookieError.Equals(0) && _userError.Equals(0))
        {
            _html.AppendLine("<div class='menubar'>");
            _html.AppendLine("  <div class='menubar-layout'>");
            _html.AppendLine("      <div class='menubar-content'>");
            _html.AppendLine("          <div class='contentbody-left'>");
            _html.AppendLine("              <ul>");

            if (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01"))
            {
                _html.AppendFormat("            <li class='have-link link-submenu' id='link-{0}'><div class='link-msg th-label'>{1}</div>", ePFStaffUtil._menu[0, 2].ToLower(), ePFStaffUtil._menu[0, 0]);
                _html.AppendLine("                  <div class='submenu'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFStaffUtil._submenu[0, 2].ToLower(), ePFStaffUtil._submenu[0, 0], "");
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </li>");
            }

            if (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER))
            {
                _html.AppendFormat("            <li class='have-link link-submenu' id='link-{0}'><div class='link-msg th-label'>{1}</div>", ePFStaffUtil._menu[1, 2].ToLower(), ePFStaffUtil._menu[1, 0]);
                _html.AppendLine("                  <div class='submenu'>");
                _html.AppendLine("                      <ul>");

                for (_i = 1, _j = 1; _i <= 20; _i++, _j++)
                {
                    _html.AppendFormat("                    <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFStaffUtil._submenu[_i, 2].ToLower(), ePFStaffUtil._submenu[_i, 0], "");
                }

                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </li>");
                _html.AppendFormat("            <li class='have-link'><a class='link-msg link-click th-label' id='link-{0}' href='javascript:void(0)'>{1}</a></li>", ePFStaffUtil._menu[2, 2].ToLower(), ePFStaffUtil._menu[2, 0]);
                _html.AppendFormat("            <li class='have-link link-submenu' id='link-{0}'><div class='link-msg th-label'>{1}</div>", ePFStaffUtil._menu[3, 2].ToLower(), ePFStaffUtil._menu[3, 0]);
                _html.AppendLine("                  <div class='submenu'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFStaffUtil._submenu[21, 2].ToLower(), ePFStaffUtil._submenu[21, 0], "");

                if (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER))
                    _html.AppendFormat("                    <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFStaffUtil._submenu[23, 2].ToLower(), ePFStaffUtil._submenu[23, 0], "");

                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFStaffUtil._submenu[24, 2].ToLower(), ePFStaffUtil._submenu[24, 0], "");

                if (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER))
                    _html.AppendFormat("                    <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFStaffUtil._submenu[26, 2].ToLower(), ePFStaffUtil._submenu[26, 0], "");
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </li>");
            }
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("          <div class='contentbody-right'>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li class='nohave-link'><div class='link-msg en-label'>{0} ( {1} - {2} )</div></li>", _username, _department, _userlevel);
            _html.AppendLine("                  <li class='split-vertical'></li>");
            _html.AppendFormat("                <li class='have-link link-submenu' id='link-{0}'><div class='link-msg en-label'>{1}</div>", ePFStaffUtil._menu[4, 2].ToLower(), ePFStaffUtil._menu[4, 1]);
            _html.AppendLine("                      <div class='submenu'>");
            _html.AppendLine("                          <ul>");
            _html.AppendFormat("                            <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", ePFStaffUtil._submenu[22, 2].ToLower(), ePFStaffUtil._submenu[22, 0], "");
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

    public static StringBuilder GetFrmHelp(string _page)
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");
        
        _ls = ePFStaffDB.GetListText("TH", "Help.txt");

        if (_page.Equals(ePFStaffUtil.PAGE_HELPFILLINFORMATIONSTUDENTRECORDS_MAIN))
            _html.AppendFormat("    <div class='th-label'>{0}</div>", _ls[0]);

        _html.AppendLine("          <hr />");

        _ls = ePFStaffDB.GetListText("EN", "Help.txt");

        if (_page.Equals(ePFStaffUtil.PAGE_HELPFILLINFORMATIONSTUDENTRECORDS_MAIN))
            _html.AppendFormat("    <div class='en-label'>{0}</div>", _ls[0]);

        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }    
    
    public static StringBuilder GetFrmViewMessage(string _msg)
    {
        StringBuilder _html = new StringBuilder();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");
        _html.AppendFormat("        <div class='th-label'>{0}</div>", _msg.Replace("\n", "<br />"));
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }
    
    public static StringBuilder GetFrmMeaningOfAdmissionType()
    {
        StringBuilder _html = new StringBuilder();        
        DataSet _ds = Util.DBUtil.GetListEntranceType(new Dictionary<string, object>());

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", ePFStaffUtil.ID_SECTION_MEANINGOFADMISSIONTYPE_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        
        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>", _dr["id"]);
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>", _dr["entranceTypeNameTH"]);

            if (!String.IsNullOrEmpty(_dr["entranceTypeNameTH"].ToString()) && !String.IsNullOrEmpty(_dr["entranceTypeNameEN"].ToString())) 
                _html.AppendFormat("            <li><div class='en-label'>&nbsp;: {0}</div></li>", _dr["entranceTypeNameEN"]);
            
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("          <div class='clear'></div>");
        }
        
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        _ds.Dispose();

        return _html;
    }

    public static StringBuilder GetFrmMeaningOfStudentStatus()
    {
        StringBuilder _html = new StringBuilder();        
        DataSet _ds = Util.DBUtil.GetListStudentStatus(new Dictionary<string, object>());

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", ePFStaffUtil.ID_SECTION_MEANINGOFSTUDENTSTATUS_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        
        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>", _dr["id"]);
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>", _dr["statusTypeNameTH"]);

            if (!String.IsNullOrEmpty(_dr["statusTypeNameTH"].ToString()) && !String.IsNullOrEmpty(_dr["statusTypeNameEN"].ToString()))
                _html.AppendFormat("            <li><div class='en-label'>&nbsp;: {0}</div></li>", _dr["statusTypeNameEN"]);
            
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("          <div class='clear'></div>");
        }
        
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        _ds.Dispose();

        return _html;
    }

    public static StringBuilder GetFrmTopicsStudentRecordsStatusNotComplete(string _id, string _idContent)
    {
        StringBuilder _html = new StringBuilder();
        StringBuilder _contentTemp = new StringBuilder();
        Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
        Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
        Dictionary<string, object> _valueDataRecorded = ePFStaffUtil.SetValueDataRecorded(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSSTUDENTRECORDS_ADDUPDATE, _id);
        Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSSTUDENTRECORDS];
        string _studentRecordsStatus = String.Empty;
        string _msgTH = String.Empty;
        string _msgEN = String.Empty;        
        int _i = 0;
        int _j = 0;

        _contentTemp.Clear();
        _contentTemp.AppendFormat("<div class='en-label'>{0}</div>", _dataRecorded["StudentCode"]);
        
        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-studentid"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
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
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-studentname"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
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

        for (_j = 0; _j < ePFStaffStudentRecordsUtil._topicsStudentRecords.GetLength(0); _j++)
        {
            _studentRecordsStatus = String.Empty;

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSPERSONAL))
                _studentRecordsStatus = _dataRecorded["StudentRecordsPersonalStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSADDRESSPERMANENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsAddressPermanentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSADDRESSCURRENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsAddressCurrentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONPRIMARYSCHOOL))
                _studentRecordsStatus = _dataRecorded["StudentRecordsEducationPrimarySchoolStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONJUNIORHIGHSCHOOL))
                _studentRecordsStatus = _dataRecorded["StudentRecordsEducationJuniorHighSchoolStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONHIGHSCHOOL))
                _studentRecordsStatus = _dataRecorded["StudentRecordsEducationHighSchoolStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONUNIVERSITY))
                _studentRecordsStatus = _dataRecorded["StudentRecordsEducationUniversityStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSEDUCATIONADMISSIONSCORES))
                _studentRecordsStatus = _dataRecorded["StudentRecordsEducationAdmissionScoresStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSTALENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsTalentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSHEALTHY))
                _studentRecordsStatus = _dataRecorded["StudentRecordsHealthyStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSWORK))
                _studentRecordsStatus = _dataRecorded["StudentRecordsWorkStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFINANCIAL))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFinancialStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERPERSONAL))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyFatherPersonalStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSPERMANENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyFatherAddressPermanentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERADDRESSCURRENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyFatherAddressCurrentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYFATHERWORK))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyFatherWorkStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERPERSONAL))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyMotherPersonalStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSPERMANENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyMotherAddressPermanentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERADDRESSCURRENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyMotherAddressCurrentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYMOTHERWORK))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyMotherWorkStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTPERSONAL))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyParentPersonalStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSPERMANENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyParentAddressPermanentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTADDRESSCURRENT))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyParentAddressCurrentStatus"].ToString();

            if (ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 2].Equals(ePFStaffUtil.SUBJECT_SECTION_ADMINISTRATIONSTUDENTRECORDSFAMILYPARENTWORK))
                _studentRecordsStatus = _dataRecorded["StudentRecordsFamilyParentWorkStatus"].ToString();

            if (_studentRecordsStatus.Equals("N"))
            {
                _msgTH = ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 0];
                _msgEN = ePFStaffStudentRecordsUtil._topicsStudentRecords[_j, 1];

                _contentTemp.AppendLine("<div class='topicsstudentrecords'>");
                _contentTemp.AppendFormat(" <span class='th-label'> {0}</span>", _msgTH);
                _contentTemp.AppendFormat(" <span class='en-label'> : {0}</span>", _msgEN);
                _contentTemp.AppendLine("</div>"); 
            }
        }

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-topicsnotcomplete"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
        _contentFrmColumnDetail[_i].Add("TitleTH", "ข้อมูลที่ยังกรอกไม่เสร็จสมบูรณ์");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Topics that the filling is not complete");
        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
        _contentFrmColumnDetail[_i].Add("Require", false);
        _contentFrmColumnDetail[_i].Add("LastRow", true);
        _contentFrmColumn.Add("TopicsNotComplete", _contentFrmColumnDetail[_i]);

        _html.AppendFormat("<div class='dialog-form form detail' id='{0}-form'>", _idContent);
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        _html.AppendLine("              <div>");
        _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentID"]).ToString());
        _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["FullName"]).ToString());
        _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["TopicsNotComplete"]).ToString());
        _html.AppendLine("              </div>");
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    public static StringBuilder GetFrmProgressData(string _page, string _idContent)
    {
        StringBuilder _html = new StringBuilder();
        StringBuilder _contentTemp = new StringBuilder();
        Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
        Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[6];
        string _msgTH = String.Empty;
        string _msgEN = String.Empty;
        string _unitTH = String.Empty;
        string _unitEN = String.Empty;
        int _i = 0;

        _msgTH = "บันทึก";
        _msgEN = "Save";
        _unitTH = "รายการ";
        _unitEN = "items";

        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDSUPDATEDATATOOLDDB_PROGRESS))
        {
            _msgTH = "ปรับปรุง";
            _msgEN = "Update";
            _unitTH = "คน";
            _unitEN = "people";
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_PROGRESS) ||
            _page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
        {
            _msgTH = "ส่งออก";
            _msgEN = "Export";
            _unitTH = "คน";
            _unitEN = "people";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL1VIEWTABLE_PROGRESS))
        {
            _msgTH = "ส่งออก";
            _msgEN = "Export";
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
        {
            _contentTemp.Clear();
            _contentTemp.AppendLine("<div class='progresstext'>");
            _contentTemp.AppendLine("   <div class='th-label'></div>");
            _contentTemp.AppendLine("   <div class='en-label'></div>");
            _contentTemp.AppendLine("</div>");

            _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
            _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-byitems"));
            _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
            _contentFrmColumnDetail[_i].Add("TitleTH", "ข้อมูลนักศึกษาตามรายการ");
            _contentFrmColumnDetail[_i].Add("TitleEN", "Student Information by Items");
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
            _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", true);
            _contentFrmColumn.Add("StudentInformationByItems", _contentFrmColumnDetail[_i]);
            _i++;
        }

        _contentTemp.Clear();
        _contentTemp.AppendLine("<div class='progresstotal'>");
        _contentTemp.AppendFormat(" <span class='th-label' id='{0}-total'></span>", _idContent);
        _contentTemp.AppendFormat(" <span class='th-label'> {0}</span>", _unitTH);
        _contentTemp.AppendFormat(" <span class='en-label'> : {0}</span>", _unitEN);
        _contentTemp.AppendLine("</div>"); 

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-total"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
        _contentFrmColumnDetail[_i].Add("TitleTH", (_msgTH + "ข้อมูลจำนวน"));
        _contentFrmColumnDetail[_i].Add("TitleEN", (_msgEN + " Total of"));
        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
        _contentFrmColumnDetail[_i].Add("Require", false);
        _contentFrmColumnDetail[_i].Add("LastRow", false);
        _contentFrmColumn.Add("Total", _contentFrmColumnDetail[_i]);
        _i++;

        _contentTemp.Clear();
        _contentTemp.AppendLine("<div class='progresstotal'>");
        _contentTemp.AppendFormat(" <span class='th-label' id='{0}-totalcomplete'></span>", _idContent);
        _contentTemp.AppendLine("   <span class='th-label'></span>");
        _contentTemp.AppendLine("   <span class='en-label'></span>");
        _contentTemp.AppendLine("</div>");

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-totalcomplete"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
        _contentFrmColumnDetail[_i].Add("TitleTH", (_msgTH + "ข้อมูลสำเร็จจำนวน"));
        _contentFrmColumnDetail[_i].Add("TitleEN", (_msgEN + " Complete Total of"));
        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
        _contentFrmColumnDetail[_i].Add("Require", false);
        _contentFrmColumnDetail[_i].Add("LastRow", false);
        _contentFrmColumn.Add("TotalComplete", _contentFrmColumnDetail[_i]);
        _i++;

        _contentTemp.Clear();
        _contentTemp.AppendLine("<div class='progresstotal'>");
        _contentTemp.AppendFormat(" <span class='th-label' id='{0}-totalincomplete'></span>", _idContent);
        _contentTemp.AppendLine("   <span class='th-label'></span>");
        _contentTemp.AppendLine("   <span class='en-label'></span>");
        _contentTemp.AppendLine("</div>");

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-totalincomplete"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
        _contentFrmColumnDetail[_i].Add("TitleTH", (_msgTH + "ข้อมูลไม่สำเร็จจำนวน"));
        _contentFrmColumnDetail[_i].Add("TitleEN", (_msgEN + " Incomplete Total of"));
        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
        _contentFrmColumnDetail[_i].Add("Require", false);
        _contentFrmColumnDetail[_i].Add("LastRow", false);
        _contentFrmColumn.Add("TotalIncomplete", _contentFrmColumnDetail[_i]);
        _i++;

        _contentTemp.Clear();
        _contentTemp.AppendLine("<div class='button'>");
        _contentTemp.AppendLine("   <div class='button-layout'>");
        _contentTemp.AppendLine("       <div class='button-content'>");
        _contentTemp.AppendLine("           <ul class='button-style1'>");
        _contentTemp.AppendFormat("             <li class='nomargin'><div class='click-button en-label button-start'>START {0} DATA</div></li>", _msgEN.ToUpper());
        _contentTemp.AppendLine("           </ul>");
        _contentTemp.AppendLine("       </div>");
        _contentTemp.AppendLine("   </div>");
        _contentTemp.AppendLine("</div>");

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-start"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
        _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
        _contentFrmColumnDetail[_i].Add("TitleEN", String.Empty);
        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
        _contentFrmColumnDetail[_i].Add("Require", false);
        _contentFrmColumnDetail[_i].Add("LastRow", false);
        _contentFrmColumn.Add("Start", _contentFrmColumnDetail[_i]);

        _html.AppendFormat("<div class='dialog-form form progress' id='{0}-form'>", _idContent);
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        _html.AppendLine("              <div>");

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENTLEVEL2VIEWTABLE_PROGRESS))
            _html.AppendLine(               ePFStaffUI.GetFrmColumn(_contentFrmColumn["StudentInformationByItems"]).ToString());

        _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Total"]).ToString());
        _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["TotalComplete"]).ToString());
        _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["TotalIncomplete"]).ToString());
        _html.AppendLine(                   ePFStaffUI.GetFrmColumn(_contentFrmColumn["Start"]).ToString());
        _html.AppendLine("              </div>");
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    public static StringBuilder GetComboboxHour(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[ePFStaffUtil.MAX_HOUR + 1];
        string[] _optionText = new string[ePFStaffUtil.MAX_HOUR + 1];

        for (_i = 0; _i <= ePFStaffUtil.MAX_HOUR; _i++)
        {
            _optionValue[_i] = _i.ToString();
            _optionText[_i] = _i.ToString("00 ");
        }

        _html = Util.GetSelect(_idCombobox, "", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxMinute(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[ePFStaffUtil.MAX_MINUTE + 1];
        string[] _optionText = new string[ePFStaffUtil.MAX_MINUTE + 1];

        for (_i = 0; _i <= ePFStaffUtil.MAX_MINUTE; _i++)
        {
            _optionValue[_i] = _i.ToString();
            _optionText[_i] = _i.ToString("00 ");
        }

        _html = Util.GetSelect(_idCombobox, "", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxSecond(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[ePFStaffUtil.MAX_SECOND + 1];
        string[] _optionText = new string[ePFStaffUtil.MAX_SECOND + 1];

        for (_i = 0; _i <= ePFStaffUtil.MAX_SECOND; _i++)
        {
            _optionValue[_i] = _i.ToString();
            _optionText[_i] = _i.ToString("00 ");
        }

        _html = Util.GetSelect(_idCombobox, "", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxSemester(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[] _semester = ePFStaffUtil._mySemester.Split(',');
        int _i = 0;

        string[] _optionValue = new string[_semester.GetLength(0)];
        string[] _optionText = new string[_semester.GetLength(0)];

        for (_i = 0; _i < _semester.GetLength(0); _i++)
        {
            _optionValue[_i] = _semester[_i];
            _optionText[_i] = _semester[_i];
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }    

    public static StringBuilder GetComboboxRowPerPage(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[] _rowPerPage = ePFStaffUtil._myRowPerPage.Split(',');
        int _i = 0;

        string[] _optionValue = new string[_rowPerPage.GetLength(0)];
        string[] _optionText = new string[_rowPerPage.GetLength(0)];

        for (_i = 0; _i < _rowPerPage.GetLength(0); _i++)
        {
            _optionValue[_i] = _rowPerPage[_i];
            _optionText[_i] = ("Display " + _rowPerPage[_i]);
        }

        _html = Util.GetSelect(_idCombobox, "", _optionValue, _optionText);

        return _html;
    }    
    
    public static StringBuilder GetComboboxGender(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("CancelledStatus", "N");

        DataSet _ds = Util.DBUtil.GetListGender(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["genderFullNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["genderFullNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["genderFullNameTH"].ToString()) ? " : " : String.Empty) + _dr["genderFullNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxCancelledStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[ePFStaffUtil._cancelledStatus.GetLength(0)];
        string[] _optionText = new string[ePFStaffUtil._cancelledStatus.GetLength(0)];

        for (_i = 0; _i < ePFStaffUtil._cancelledStatus.GetLength(0); _i++)
        {
            _optionValue[_i] = ePFStaffUtil._cancelledStatus[_i, 0];
            _optionText[_i] = (ePFStaffUtil._cancelledStatus[_i, 1] + " : " + ePFStaffUtil._cancelledStatus[_i, 2]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxEducationalLevel(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("CancelledStatus", "N");

        DataSet _ds = Util.DBUtil.GetListEducationalLevel(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["educationalLevelNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["educationalLevelNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["educationalLevelNameTH"].ToString()) ? " : " : String.Empty) + _dr["educationalLevelNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxDegreeLevel(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        DataSet _ds = Util.DBUtil.GetListDegreeLevel();
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["degreeLevelNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["degreeLevelNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["degreeLevelNameTH"].ToString()) ? " : " : String.Empty) + _dr["degreeLevelNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetSelectFaculty(string _idCombobox, Dictionary<string, object> _paramSearch)
    {
        Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
        StringBuilder _html = new StringBuilder();
        string _username = _loginResult["Username"].ToString();
        string _systemGroup = _loginResult["SystemGroup"].ToString();
        string _faculty = _loginResult["Faculty"].ToString();
        int _i = 0;

        _paramSearch.Add("Faculty", _faculty);

        DataSet _ds = Util.DBUtil.GetListFaculty(_username, _systemGroup, _paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["facultyId"].ToString();
            _optionText[_i] = (_dr["facultyCode"].ToString() + " : " + _dr["facultyNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["facultyNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["facultyNameTH"].ToString()) ? " : " : String.Empty) + _dr["facultyNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }    
    
    public static StringBuilder GetComboboxFaculty(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();

        _html = GetSelectFaculty(_idCombobox, _paramSearch);

        return _html;
    }
    
    public static StringBuilder GetComboboxFacultyByJoinProgram(string _idCombobox, string _joinProgram)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("JoinProgram", _joinProgram);

        _html = GetSelectFaculty(_idCombobox, _paramSearch);

        return _html;
    }
   
    public static StringBuilder GetSelectProgram(string _idCombobox, string _degreeLevel, string _faculty, Dictionary<string, object> _paramSearch)
    {
        Dictionary<string, object> _loginResult = ePFStaffUtil.GetInfoLogin("", "");
        StringBuilder _html = new StringBuilder();
        string _username = _loginResult["Username"].ToString();
        string _systemGroup = _loginResult["SystemGroup"].ToString();
        string _program = _loginResult["Program"].ToString();
        int _i = 0;

        _paramSearch.Add("DegreeLevel", _degreeLevel);
        _paramSearch.Add("Faculty", _faculty);
        _paramSearch.Add("Program", _program);

        DataSet _ds = Util.DBUtil.GetListProgram(_username, _systemGroup, _paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["programId"].ToString();
            _optionText[_i] = (_dr["programCode"].ToString() + " " +_dr["majorCode"].ToString() + " " +_dr["groupNum"].ToString() + " : " + _dr["programNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? " : " : String.Empty) + _dr["programNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }    
        
    public static StringBuilder GetComboboxProgram(string _idCombobox, string _degreeLevel, string _faculty)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();

        _paramSearch.Clear();

        _html = GetSelectProgram(_idCombobox, _degreeLevel, _faculty, _paramSearch);

        return _html;
    }

    public static StringBuilder GetComboboxProgramByJoinProgram(string _idCombobox, string _degreeLevel, string _faculty, string _joinProgram)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();

        _paramSearch.Clear();
        _paramSearch.Add("JoinProgram", _joinProgram);

        _html = GetSelectProgram(_idCombobox, _degreeLevel, _faculty, _paramSearch);

        return _html;
    }
    
    public static StringBuilder GetComboboxYearAttended(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        DataSet _ds = Util.DBUtil.GetListYearEntry();
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["yearEntry"].ToString();
            _optionText[_i] = _dr["yearEntry"].ToString();

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxClass(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[6];
        string[] _optionText = new string[6];

        for (_i = 0; _i < 6; _i++ )
        {
            _optionValue[_i] = (_i + 1).ToString();
            _optionText[_i] = (_i + 1).ToString();
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxEntranceType(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;        

        _paramSearch.Clear();
        _paramSearch.Add("CancelledStatus", "N");

        DataSet _ds = Util.DBUtil.GetListEntranceType(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["entranceTypeNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["entranceTypeNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["entranceTypeNameTH"].ToString()) ? " : " : String.Empty) + _dr["entranceTypeNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxStudentStatus(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        DataSet _ds = Util.DBUtil.GetListStudentStatus(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["id"].ToString();
            _optionText[_i] = (_dr["statusTypeNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["statusTypeNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["statusTypeNameTH"].ToString()) ? " : " : String.Empty) + _dr["statusTypeNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    public static StringBuilder GetComboboxStudentRecordsStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[,] _optionList = ePFStaffUtil._studentRecordsStatus;
        int _i = 0;

        string[] _optionValue = new string[_optionList.GetLength(0)];
        string[] _optionText = new string[_optionList.GetLength(0)];

        for (_i = 0; _i < _optionList.GetLength(0); _i++)
        {
            _optionValue[_i] = _optionList[_i, 0];
            _optionText[_i] = (_optionList[_i, 1] + (!String.IsNullOrEmpty(_optionList[_i, 2]) ? (!String.IsNullOrEmpty(_optionList[_i, 1]) ? " : " : String.Empty) + _optionList[_i, 2] : String.Empty));
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

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
        _paramSearch.Add("District",  _districtId);
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
        string[,] _optionList = ePFStaffStudentRecordsUtil._occupation;
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
        string[,] _optionList = ePFStaffStudentRecordsUtil._scholarshipFrom;
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
    
    public static StringBuilder GetComboboxStudentRecordsUpdateOption(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[,] _optionList = ePFStaffUtil._studentRecordsUpdateOption;
        int _i = 0;

        string[] _optionValue = new string[_optionList.GetLength(0)];
        string[] _optionText = new string[_optionList.GetLength(0)];

        for (_i = 0; _i < _optionList.GetLength(0); _i++)
        {
            _optionValue[_i] = _optionList[_i, 2];
            _optionText[_i] = _optionList[_i, 0];
        }

        _html = Util.GetSelect(_idCombobox, "รายการปรับปรุง : Update Option", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxJoinProgramStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[,] _optionList = ePFStaffUtil._joinProgramStatus;
        int _i = 0;

        string[] _optionValue = new string[_optionList.GetLength(0)];
        string[] _optionText = new string[_optionList.GetLength(0)];

        for (_i = 0; _i < _optionList.GetLength(0); _i++)
        {
            _optionValue[_i] = _optionList[_i, 0];
            _optionText[_i] = (_optionList[_i, 1] + (!String.IsNullOrEmpty(_optionList[_i, 2]) ? (!String.IsNullOrEmpty(_optionList[_i, 1]) ? " : " : String.Empty) + _optionList[_i, 2] : String.Empty));
        }

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

    public static StringBuilder GetComboboxOrder(string _idCombobox, int _orderStart, int _orderEnd)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[(_orderEnd - _orderStart) + 1];
        string[] _optionText = new string[(_orderEnd - _orderStart) + 1];

        for (_i = 0; _i < ((_orderEnd - _orderStart) + 1); _i++)
        {
            _optionValue[_i] = (_orderStart + _i).ToString();
            _optionText[_i] = (_orderStart + _i).ToString();
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

    public static StringBuilder GetValueSearch(string _page)
    {
        StringBuilder _html = new StringBuilder();
        Dictionary<string, object> _valueSearch = ePFStaffUtil.SetValueSearch(_page);
        string _keyword = (string)Util.GetValueDataDictionary(_valueSearch, "Keyword", _valueSearch["Keyword"], String.Empty);
        string _gender = (string)Util.GetValueDataDictionary(_valueSearch, "Gender", _valueSearch["Gender"], String.Empty);
        string _degreeLevel = (string)Util.GetValueDataDictionary(_valueSearch, "DegreeLevel", _valueSearch["DegreeLevel"], String.Empty);
        string _country = (string)Util.GetValueDataDictionary(_valueSearch, "Country", _valueSearch["Country"], String.Empty);
        string _province = (string)Util.GetValueDataDictionary(_valueSearch, "Province", _valueSearch["Province"], String.Empty);
        string _district = (string)Util.GetValueDataDictionary(_valueSearch, "District", _valueSearch["District"], String.Empty);
        string _postalCode = (string)Util.GetValueDataDictionary(_valueSearch, "PostalCode", _valueSearch["PostalCode"], String.Empty);
        string _cancelledStatus = (string)Util.GetValueDataDictionary(_valueSearch, "CancelledStatus", _valueSearch["CancelledStatus"], String.Empty);
        string _faculty = (string)Util.GetValueDataDictionary(_valueSearch, "Faculty", _valueSearch["Faculty"], String.Empty);
        string _program = (string)Util.GetValueDataDictionary(_valueSearch, "Program", _valueSearch["Program"], String.Empty);
        string _yearEntry = (string)Util.GetValueDataDictionary(_valueSearch, "YearEntry", _valueSearch["YearEntry"], String.Empty);
        string _yearGraduate = (string)Util.GetValueDataDictionary(_valueSearch, "YearGraduate", _valueSearch["YearGraduate"], String.Empty);
        string _class = (string)Util.GetValueDataDictionary(_valueSearch, "Class", _valueSearch["Class"], String.Empty);
        string _entranceType = (string)Util.GetValueDataDictionary(_valueSearch, "EntranceType", _valueSearch["EntranceType"], String.Empty);
        string _studentStatus = (string)Util.GetValueDataDictionary(_valueSearch, "StudentStatus", _valueSearch["StudentStatus"], String.Empty);
        string _studentRecordsStatus = (string)Util.GetValueDataDictionary(_valueSearch, "StudentRecordsStatus", _valueSearch["StudentRecordsStatus"], String.Empty);
        string _joinProgramStatus = (string)Util.GetValueDataDictionary(_valueSearch, "JoinProgramStatus", _valueSearch["JoinProgramStatus"], String.Empty);
        string _startAcademicYear = (string)Util.GetValueDataDictionary(_valueSearch, "StartAcademicYear", _valueSearch["StartAcademicYear"], String.Empty);
        string _endAcademicYear = (string)Util.GetValueDataDictionary(_valueSearch, "EndAcademicYear", _valueSearch["EndAcademicYear"], String.Empty);
        string _sortOrderBy  = (string)Util.GetValueDataDictionary(_valueSearch, "SortOrderBy", _valueSearch["SortOrderBy"], String.Empty);
        string _sortExpression = (string)Util.GetValueDataDictionary(_valueSearch, "SortExpression", _valueSearch["SortExpression"], String.Empty);
        string _rowPerPage = (string)Util.GetValueDataDictionary(_valueSearch, "RowPerPage", _valueSearch["RowPerPage"].ToString(), String.Empty);
        string _idSectionMain = String.Empty;
        string _idSectionSearch = String.Empty;
        string _sortOrderByDefault = String.Empty;
                        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATATITLEPREFIX_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATATITLEPREFIX_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATATITLEPREFIX_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAGENDER_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAGENDER_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAGENDER_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATANATIONALITYRACE_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATANATIONALITYRACE_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATANATIONALITYRACE_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }

        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATARELIGION_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATARELIGION_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATARELIGION_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATABLOODGROUP_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATABLOODGROUP_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATABLOODGROUP_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAMARITALSTATUS_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAMARITALSTATUS_MAIN.ToLower();
            _idSectionSearch  = ePFStaffUtil.ID_SECTION_MASTERDATAMARITALSTATUS_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAFAMILYRELATIONSHIPS_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAFAMILYRELATIONSHIPS_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAFAMILYRELATIONSHIPS_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAAGENCY_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAAGENCY_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAAGENCY_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALLEVEL_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALLEVEL_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALLEVEL_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALBACKGROUND_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALBACKGROUND_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALBACKGROUND_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAEDUCATIONALMAJOR_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALMAJOR_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAEDUCATIONALMAJOR_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAADMISSIONTYPE_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAADMISSIONTYPE_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAADMISSIONTYPE_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATASTUDENTSTATUS_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATASTUDENTSTATUS_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATASTUDENTSTATUS_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATACOUNTRY_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATACOUNTRY_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATACOUNTRY_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAPROVINCE_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAPROVINCE_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAPROVINCE_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATADISTRICT_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATADISTRICT_MAIN.ToLower();
            _idSectionSearch  = ePFStaffUtil.ID_SECTION_MASTERDATADISTRICT_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATASUBDISTRICT_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATASUBDISTRICT_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATASUBDISTRICT_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAINSTITUTE_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAINSTITUTE_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAINSTITUTE_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATADISEASES_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATADISEASES_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATADISEASES_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_MASTERDATAHEALTHIMPAIRMENTS_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_MASTERDATAHEALTHIMPAIRMENTS_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_MASTERDATAHEALTHIMPAIRMENTS_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }
        
        if (_page.Equals(ePFStaffUtil.PAGE_ADMINISTRATIONSTUDENTRECORDS_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDS_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_ADMINISTRATIONSTUDENTRECORDS_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATION_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_OURSERVICESUPDATESTUDENTMEDICALSCHOLARSPROGRAM_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENT_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_OURSERVICESSUMMARYNUMBEROFSTUDENT_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(ePFStaffUtil.PAGE_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN))
        { 
            _idSectionMain = ePFStaffUtil.ID_SECTION_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_MAIN.ToLower();
            _idSectionSearch = ePFStaffUtil.ID_SECTION_OURSERVICESTRANSACTIONLOGSTUDENTRECORDS_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }
        
        _html.AppendFormat("<input type='hidden' id='{0}-keyword-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_keyword) ? _keyword : Util._valueTextDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-gender-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_gender) ? _gender : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-degreelevel-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_degreeLevel) ? _degreeLevel : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-country-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_country) ? _country : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-province-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_province) ? _province : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-district-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_district) ? _district : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-postalcode-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_postalCode) ? _postalCode : Util._valueTextDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-cancelledstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_cancelledStatus) ? _cancelledStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-faculty-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_faculty) ? _faculty : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-program-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_program) ? _program : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-yearattended-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_yearEntry) ? _yearEntry : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-yeargraduate-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_yearGraduate) ? _yearGraduate : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-class-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_class) ? _class : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-entrancetype-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_entranceType) ? _entranceType : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-studentstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_studentStatus) ? _studentStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-studentrecordsstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_studentRecordsStatus) ? _studentRecordsStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-joinprogramstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_joinProgramStatus) ? _joinProgramStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-startacademicyear-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_startAcademicYear) ? _startAcademicYear : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-endacademicyear-hidden' value='{1}' />",  _idSectionSearch, (!String.IsNullOrEmpty(_endAcademicYear) ? _endAcademicYear : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-sortorderby-hidden' value='{1}' />",  _idSectionSearch, (!String.IsNullOrEmpty(_sortOrderBy) ? _sortOrderBy : _sortOrderByDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-sortexpression-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_sortExpression) ? _sortExpression : "Ascending"));
        _html.AppendFormat("<input type='hidden' id='{0}-rowperpage-hidden' value='{1}' />", _idSectionMain, (!String.IsNullOrEmpty(_rowPerPage) ? _rowPerPage : ePFStaffUtil._myRowPerPageDefault));

        return _html;
    }
}