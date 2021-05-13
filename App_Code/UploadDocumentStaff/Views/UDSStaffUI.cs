/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๒/๐๖/๒๕๕๘>
Modify date : <๑๔/๐๖/๒๕๖๒>
Description : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผล>
=============================================
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using NUtil;
using NFinServiceLogin;

public class UDSStaffUI
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
                _html.AppendFormat("            <li class='have-link link-submenu' id='link-{0}'><div class='link-msg th-label'>{1}</div>", UDSStaffUtil._menu[0, 2].ToLower(), UDSStaffUtil._menu[0, 0]);
                _html.AppendLine("                  <div class='submenu'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", UDSStaffUtil._submenu[0, 2].ToLower(), UDSStaffUtil._submenu[0, 0], "");
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </li>");
                _html.AppendFormat("            <li class='have-link'><a class='link-msg link-click th-label' id='link-{0}' href='javascript:void(0)'>{1}</a></li>", UDSStaffUtil._menu[1, 2].ToLower(), UDSStaffUtil._menu[1, 0]);
                _html.AppendFormat("            <li class='have-link'><a class='link-msg link-click th-label' id='link-{0}' href='javascript:void(0)'>{1}</a></li>", UDSStaffUtil._menu[2, 2].ToLower(), UDSStaffUtil._menu[2, 0]);
                _html.AppendFormat("            <li class='have-link link-submenu' id='link-{0}'><div class='link-msg th-label'>{1}</div>", UDSStaffUtil._menu[3, 2].ToLower(), UDSStaffUtil._menu[3, 0]);
                _html.AppendLine("                  <div class='submenu'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", UDSStaffUtil._submenu[6, 2].ToLower(), UDSStaffUtil._submenu[6, 0], "");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", UDSStaffUtil._submenu[1, 2].ToLower(), UDSStaffUtil._submenu[1, 0], "");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", UDSStaffUtil._submenu[20, 2].ToLower(), UDSStaffUtil._submenu[20, 0], "");

                /*
                if (_username.Equals("yutthaphoom.taw"))
                    _html.AppendFormat("                    <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", UDSStaffUtil._submenu[2, 2].ToLower(), UDSStaffUtil._submenu[2, 0], "");
                */

                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", UDSStaffUtil._submenu[8, 2].ToLower(), UDSStaffUtil._submenu[8, 0], "");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", UDSStaffUtil._submenu[3, 2].ToLower(), UDSStaffUtil._submenu[3, 0], "");                
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

            if (!String.IsNullOrEmpty(_infoOperatorHome)) _infoOperator.Add("operator-home;" + _infoOperatorHome + ";Home");
            if (!String.IsNullOrEmpty(_infoOperatorNew)) _infoOperator.Add("operator-new;" + _infoOperatorNew + ";New");
            if (!String.IsNullOrEmpty(_infoOperatorEdit)) _infoOperator.Add("operator-edit;" + _infoOperatorEdit + ";Edit");
            if (!String.IsNullOrEmpty(_infoOperatorDelete)) _infoOperator.Add("operator-delete;" + _infoOperatorDelete + ";Delete");
            if (!String.IsNullOrEmpty(_infoOperatorExportAll)) _infoOperator.Add("operator-exportall;" + _infoOperatorExportAll + ";Export All");
            if (!String.IsNullOrEmpty(_infoOperatorExportSelected)) _infoOperator.Add("operator-exportselected;" + _infoOperatorExportSelected + ";Export Selected");
            if (!String.IsNullOrEmpty(_infoOperatorSearch)) _infoOperator.Add("operator-search;" + _infoOperatorSearch + ";Search");
            if (!String.IsNullOrEmpty(_infoOperatorReset)) _infoOperator.Add("operator-reset;" + _infoOperatorReset + ";Reset");
            if (!String.IsNullOrEmpty(_infoOperatorSave)) _infoOperator.Add("operator-save;" + _infoOperatorSave + ";Save");
            if (!String.IsNullOrEmpty(_infoOperatorApply)) _infoOperator.Add("operator-apply;" + _infoOperatorApply + ";Apply");
            if (!String.IsNullOrEmpty(_infoOperatorUndo)) _infoOperator.Add("operator-undo;" + _infoOperatorUndo + ";Clear");
            if (!String.IsNullOrEmpty(_infoOperatorPrint)) _infoOperator.Add("operator-print;" + _infoOperatorPrint + ";Print");
            if (!String.IsNullOrEmpty(_infoOperatorUpload)) _infoOperator.Add("operator-upload;" + _infoOperatorUpload + ";Upload");
            if (!String.IsNullOrEmpty(_infoOperatorTransfer)) _infoOperator.Add("operator-transfer;" + _infoOperatorTransfer + ";Transfer");
            if (!String.IsNullOrEmpty(_infoOperatorProfile)) _infoOperator.Add("operator-profile;" + _infoOperatorProfile + ";Profile");
            if (!String.IsNullOrEmpty(_infoOperatorClose)) _infoOperator.Add("operator-close;" + _infoOperatorClose + ";Close");

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

    public static StringBuilder GetFrmMeaningOfAdmissionType()
    {
        StringBuilder _html = new StringBuilder();        
        DataSet _ds = Util.DBUtil.GetListEntranceType(new Dictionary<string, object>());

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", UDSStaffUtil.ID_SECTION_MEANINGOFADMISSIONTYPE_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        
        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",  _dr["id"]);
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",  _dr["entranceTypeNameTH"]);

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

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", UDSStaffUtil.ID_SECTION_MEANINGOFSTUDENTSTATUS_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        
        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",  _dr["id"]);
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",  _dr["statusTypeNameTH"]);

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

    //ฟังก์ชั่นสำหรับแสดงความหมายของสถานะการส่งเอกสารที่อัพโหลด แล้วส่งค่ากลับเป็น StringBuilder
    public static StringBuilder GetFrmMeaningOfDocumentSubmittedStatus()
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", UDSStaffUtil.ID_SECTION_MEANINGOFSUBMITTEDSTATUS_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");

        for (_i = 0; _i < UDSStaffUtil._documentUpload.GetLength(0); _i++)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='uploaddocument-submittedstatus uploaddocument-submittedstatus-blank'><div class='en-label'>{0}</div></div></li>", UDSStaffUtil._documentUpload[_i, 3]);
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",     UDSStaffUtil._documentUpload[_i, 0]);
            _html.AppendFormat("                <li><div class='en-label'>&nbsp;: {0}</div></li>", UDSStaffUtil._documentUpload[_i, 1]);
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("          <div class='clear'></div>");
            _html.AppendLine("          <hr />");
        }        
        
        for (_i = 0; _i < UDSStaffUtil._submittedStatus.GetLength(0); _i++)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='uploaddocument-submittedstatus uploaddocument-submittedstatus-{0}'></div></li>", UDSStaffUtil._submittedStatus[_i, 2].ToLower());
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",      UDSStaffUtil._submittedStatus[_i, 0]);
            _html.AppendFormat("                <li><div class='en-label'>&nbsp;: {0}</div></li>", UDSStaffUtil._submittedStatus[_i, 1]);
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

    public static StringBuilder GetFrmMeaningOfDocumentApprovalStatus()
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", UDSStaffUtil.ID_SECTION_MEANINGOFAPPROVALSTATUS_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");

        for (_i = 0; _i < UDSStaffUtil._documentUpload.GetLength(0); _i++)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='uploaddocument-approvalstatus uploaddocument-approvalstatus-blank'><div class='en-label'>{0}</div></div></li>", UDSStaffUtil._documentUpload[_i, 3]);
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",     UDSStaffUtil._documentUpload[_i, 0]);
            _html.AppendFormat("                <li><div class='en-label'>&nbsp;: {0}</div></li>", UDSStaffUtil._documentUpload[_i, 1]);
            _html.AppendLine("              </ul>");
            _html.AppendLine("          </div>");
            _html.AppendLine("          <div class='clear'></div>");
            _html.AppendLine("          <hr />");
        }        
        
        for (_i = 0; _i < UDSStaffUtil._approvalStatus.GetLength(0); _i++)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='uploaddocument-approvalstatus uploaddocument-approvalstatus-{0}'></div></li>", UDSStaffUtil._approvalStatus[_i, 2].ToLower());
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",     UDSStaffUtil._approvalStatus[_i, 0]);
            _html.AppendFormat("                <li><div class='en-label'>&nbsp;: {0}</div></li>", UDSStaffUtil._approvalStatus[_i, 1]);
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

    public static StringBuilder GetFrmMeaningOfDocumentAuditedStatus()
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", UDSStaffUtil.ID_SECTION_MEANINGOFAUDITEDSTATUS_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");

        for (_i = 0; _i < UDSStaffUtil._auditedStatus.GetLength(0); _i++)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='uploaddocument-auditedstatus uploaddocument-auditedstatus-{0}'></div></li>", UDSStaffUtil._auditedStatus[_i, 2].ToLower());
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>", UDSStaffUtil._auditedStatus[_i, 0]);
            _html.AppendFormat("                <li><div class='en-label'>&nbsp;: {0}</div></li>", UDSStaffUtil._auditedStatus[_i, 1]);
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
        Dictionary<string, object> _fileAttribute = UDSStaffUtil.GetDocumentFileAttribute(_section);

        _fileFullPath = (Util.FileExist(_fileFullPath) ? (UDSStaffUtil._myHandlerPath + "?action=imagefile2stream&f=" + Util.EncodeToBase64(_fileFullPath)) : String.Empty);

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

    public static StringBuilder GetFrmEnterMessage(string _idContent)
    {
        StringBuilder _html = new StringBuilder();

        _html.AppendFormat("<div class='dialogaddupdate-form' id='{0}-form'>", _idContent.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        _html.AppendFormat("            <div><textarea class='textareabox' id='{0}-message'></textarea></div>", _idContent.ToLower());
        _html.AppendLine("              <div class='button'>");
        _html.AppendLine("                  <div class='button-layout'>");
        _html.AppendLine("                      <div class='button-content'>");
        _html.AppendLine("                          <ul class='button-style1'>");
        _html.AppendFormat("                            <li class='nomargin'><a class='en-label button-save' href='javascript:void(0)'>SAVE</a></li>");
        _html.AppendLine("                              <li><a class='en-label button-undo' href='javascript:void(0)'>CLEAR</a></li>");
        _html.AppendLine("                          </ul>");
        _html.AppendLine("                      </div>");
        _html.AppendLine("                  </div>");
        _html.AppendLine("              </div>");
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    public static StringBuilder GetFrmViewMessage()
    {
        StringBuilder _html = new StringBuilder();

        _html.AppendFormat("<div class='dialog-form' id='{0}-form'>", UDSStaffUtil.ID_SECTION_VIEWMESSAGE_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        _html.AppendFormat("            <textarea class='textareabox'></textarea>");
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    public static StringBuilder GetFrmProgressExportData(string _page, string _idContent)
    {
        StringBuilder _html = new StringBuilder();
        StringBuilder _contentTemp = new StringBuilder();
        Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
        Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[5];
        string _unitTH = String.Empty;
        string _unitEN = String.Empty;
        int _i = 0;

        _unitTH = "รายการ";
        _unitEN = "items";

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENTLEVEL1VIEWTABLE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL22VIEWTABLE_PROGRESS) ||
            _page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS)) 
        {
            _unitTH = "คน";
            _unitEN = "people";
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVEDLEVEL21VIEWTABLE_PROGRESS))
        {
            _unitTH = "โรงเรียน";
            _unitEN = "school";
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS))
        {
            _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
            _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-sentdateaudit"));
            _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
            _contentFrmColumnDetail[_i].Add("TitleTH", "วันที่ส่งวุฒิการศึกษาตรวจสอบ");
            _contentFrmColumnDetail[_i].Add("TitleEN", "Sent Date Transcript Audit");
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", ("<input class='inputcalendar' type='text' id='" + _idContent + "-sentdateaudit' readonly value='' />"));
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", false);
            _contentFrmColumn.Add("SentDateTranscriptAudit", _contentFrmColumnDetail[_i]);
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
        _contentFrmColumnDetail[_i].Add("TitleTH", "ส่งออกข้อมูลจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Export Total of");
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
        _contentFrmColumnDetail[_i].Add("TitleTH", "ส่งออกข้อมูลสำเร็จจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Export Complete Total of");
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
        _contentFrmColumnDetail[_i].Add("TitleTH", "ส่งออกข้อมูลไม่สำเร็จจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Export Incomplete Total of");
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
        _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-start'>START EXPORT DATA</div></li>");
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

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTTRANSCRIPTAPPROVED_PROGRESS))
            _html.AppendLine(           UDSStaffUI.GetFrmColumn(_contentFrmColumn["SentDateTranscriptAudit"]).ToString());

        _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["Total"]).ToString());
        _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["TotalComplete"]).ToString());
        _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["TotalIncomplete"]).ToString());
        _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["Start"]).ToString());
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }
    public static StringBuilder GetFrmProgressCopyData(string _page, string _idContent)
    {
        StringBuilder _html = new StringBuilder();
        StringBuilder _contentTemp = new StringBuilder();
        Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
        Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[5];
        string _unitTH = String.Empty;
        string _unitEN = String.Empty;
        string _copyTo = String.Empty;
        int _i = 0;

        _unitTH = "รายการ";
        _unitEN = "items";

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_PROGRESS))
        {
            _unitTH = "คน";
            _unitEN = "people";
            _copyTo = UDSStaffUtil._mySiteServerPictureStudent;
        }

        _contentTemp.Clear();
        _contentTemp.AppendLine("<div class='progresstotal'>");
        _contentTemp.AppendFormat(" <span class='th-label' id='{0}-total'></span>", _idContent);
        _contentTemp.AppendFormat("   <span class='th-label'> {0}</span>", _unitTH);
        _contentTemp.AppendFormat("   <span class='en-label'> : {0}</span>", _unitEN);
        _contentTemp.AppendLine("</div>");
        
        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-total"));
        _contentFrmColumnDetail[_i].Add("HighLight", true);
        _contentFrmColumnDetail[_i].Add("TitleTH", "คัดลอกข้อมูลจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Copy Total of");
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
        _contentTemp.AppendFormat(" <span class='en-label' id='{0}-tostore'>{1}</span>", _idContent, _copyTo);
        _contentTemp.AppendLine("</div>");

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-tostore"));
        _contentFrmColumnDetail[_i].Add("HighLight", false);
        _contentFrmColumnDetail[_i].Add("TitleTH", "คัดลอกข้อมูลไปยัง");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Copy to");
        _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
        _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
        _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
        _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
        _contentFrmColumnDetail[_i].Add("Require", false);
        _contentFrmColumnDetail[_i].Add("LastRow", false);
        _contentFrmColumn.Add("ToStore", _contentFrmColumnDetail[_i]);
        _i++;

        _contentTemp.Clear();
        _contentTemp.AppendLine("<div class='progresstotal'>");
        _contentTemp.AppendFormat(" <span class='th-label' id='{0}-totalcomplete'></span>", _idContent);
        _contentTemp.AppendLine("   <span class='th-label'></span>");
        _contentTemp.AppendLine("   <span class='en-label'></span>");
        _contentTemp.AppendLine("</div>");

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-totalcomplete"));
        _contentFrmColumnDetail[_i].Add("HighLight", true);
        _contentFrmColumnDetail[_i].Add("TitleTH", "คัดลอกข้อมูลสำเร็จจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Copy Complete Total of");
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
        _contentFrmColumnDetail[_i].Add("HighLight", false);
        _contentFrmColumnDetail[_i].Add("TitleTH", "คัดลอกข้อมูลไม่สำเร็จจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Copy Incomplete Total of");
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
        _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-start'>START COPY DATA</div></li>");
        _contentTemp.AppendLine("           </ul>");
        _contentTemp.AppendLine("       </div>");
        _contentTemp.AppendLine("   </div>");
        _contentTemp.AppendLine("</div>");

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-start"));
        _contentFrmColumnDetail[_i].Add("HighLight", true);
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
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Total"]).ToString());
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["ToStore"]).ToString());
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["TotalComplete"]).ToString());
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["TotalIncomplete"]).ToString());
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Start"]).ToString());
        _html.AppendLine("              </div>");
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetFrmProgressSaveData(string _page, string _idContent)
    {
        StringBuilder _html = new StringBuilder();
        StringBuilder _contentTemp = new StringBuilder();
        Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
        Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[6];
        string _unitTH = String.Empty;
        string _unitEN = String.Empty;
        int _i = 0;

        _unitTH = "รายการ";
        _unitEN = "items";

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
        {
            _unitTH = "คน";
            _unitEN = "people";
        }
        
        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
        {
            _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
            _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-auditedstatus"));
            _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
            _contentFrmColumnDetail[_i].Add("TitleTH", "ผลการตรวจสอบวุฒิการศึกษา");
            _contentFrmColumnDetail[_i].Add("TitleEN", "Result Transcript Audit");
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", ("<div id='" + _idContent + "-auditedstatus-combobox'>" + UDSStaffUI.GetComboboxAuditedStatus(_idContent + "-auditedstatus") + "</div>"));
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", false);
            _contentFrmColumn.Add("ResultTranscriptAudit", _contentFrmColumnDetail[_i]);
            _i++;

            _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
            _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-receiveddateresultaudit"));
            _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
            _contentFrmColumnDetail[_i].Add("TitleTH", "วันที่รับผลการตรวจสอบวุฒิการศึกษา");
            _contentFrmColumnDetail[_i].Add("TitleEN", "Received Date Result Transcript Audit");
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", ("<input class='inputcalendar' type='text' id='" + _idContent + "-receiveddateresultaudit' readonly value='' />"));
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", false);
            _contentFrmColumn.Add("ReceivedDateResultTranscriptAudit", _contentFrmColumnDetail[_i]);
            _i++;
        }

        _contentTemp.Clear();
        _contentTemp.AppendLine("<div class='progresstotal'>");
        _contentTemp.AppendFormat(" <span class='th-label' id='{0}-total'></span>", _idContent);
        _contentTemp.AppendFormat("   <span class='th-label'> {0}</span>", _unitTH);
        _contentTemp.AppendFormat("   <span class='en-label'> : {0}</span>", _unitEN);
        _contentTemp.AppendLine("</div>"); 

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-total"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
        _contentFrmColumnDetail[_i].Add("TitleTH", "บันทึกข้อมูลจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Save Total of");
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
        _contentFrmColumnDetail[_i].Add("TitleTH", "บันทึกข้อมูลสำเร็จจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Save Complete Total of");
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
        _contentFrmColumnDetail[_i].Add("TitleTH", "บันทึกข้อมูลไม่สำเร็จจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Save Incomplete Total of");
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
        _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-start'>START SAVE DATA</div></li>");
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
        
        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESSAVEAUDITTRANSCRIPTAPPROVED_PROGRESS))
        {
            _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["ResultTranscriptAudit"]).ToString());
            _html.AppendLine(               UDSStaffUI.GetFrmColumn(_contentFrmColumn["ReceivedDateResultTranscriptAudit"]).ToString());
        }
        
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Total"]).ToString());
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["TotalComplete"]).ToString());
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["TotalIncomplete"]).ToString());
        _html.AppendLine(                   UDSStaffUI.GetFrmColumn(_contentFrmColumn["Start"]).ToString());
        _html.AppendLine("              </div>");
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetComboboxHour(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil.MAX_HOUR + 1];
        string[] _optionText = new string[UDSStaffUtil.MAX_HOUR + 1];

        for (_i = 0; _i <= UDSStaffUtil.MAX_HOUR; _i++)
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

        string[] _optionValue = new string[UDSStaffUtil.MAX_MINUTE + 1];
        string[] _optionText = new string[UDSStaffUtil.MAX_MINUTE + 1];

        for (_i = 0; _i <= UDSStaffUtil.MAX_MINUTE; _i++)
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

        string[] _optionValue = new string[UDSStaffUtil.MAX_SECOND + 1];
        string[] _optionText = new string[UDSStaffUtil.MAX_SECOND + 1];

        for (_i = 0; _i <= UDSStaffUtil.MAX_SECOND; _i++)
        {
            _optionValue[_i] = _i.ToString();
            _optionText[_i] = _i.ToString("00 ");
        }

        _html = Util.GetSelect(_idCombobox, "", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxRowPerPage(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[] _rowPerPage = UDSStaffUtil._myRowPerPage.Split(',');
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

    public static StringBuilder GetComboboxExportOption(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil._selectOption.GetLength(0)];
        string[] _optionText = new string[UDSStaffUtil._selectOption.GetLength(0)];

        for (_i = 0; _i < UDSStaffUtil._selectOption.GetLength(0); _i++)
        {
            _optionValue[_i] = UDSStaffUtil._selectOption[_i].ToLower();
            _optionText[_i] = ("Export " + UDSStaffUtil._selectOption[_i]);
        }

        _html = Util.GetSelect(_idCombobox, "Export Option", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxExportAndSaveOption(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil._selectOption.GetLength(0)];
        string[] _optionText = new string[UDSStaffUtil._selectOption.GetLength(0)];

        for (_i = 0; _i < UDSStaffUtil._selectOption.GetLength(0); _i++)
        {
            _optionValue[_i] = UDSStaffUtil._selectOption[_i].ToLower();
            _optionText[_i] = ("Export & Save " + UDSStaffUtil._selectOption[_i]);
        }

        _html = Util.GetSelect(_idCombobox, "Export & Save Option", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxCopyOption(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil._selectOption.GetLength(0)];
        string[] _optionText = new string[UDSStaffUtil._selectOption.GetLength(0)];

        for (_i = 0; _i < UDSStaffUtil._selectOption.GetLength(0); _i++)
        {
            _optionValue[_i] = UDSStaffUtil._selectOption[_i].ToLower();
            _optionText[_i] = ("Copy " + UDSStaffUtil._selectOption[_i]);
        }

        _html = Util.GetSelect(_idCombobox, "Copy Option", _optionValue, _optionText);

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

    public static StringBuilder GetComboboxFaculty(string _idCombobox)
    {
        Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        string _username = _loginResult["Username"].ToString();
        string _systemGroup = _loginResult["SystemGroup"].ToString();
        string _faculty = _loginResult["Faculty"].ToString();
        int _i = 0;

        _paramSearch.Clear();
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

    public static StringBuilder GetComboboxProgram(string _idCombobox, string _degreeLevel, string _faculty)
    {
        Dictionary<string, object> _loginResult = UDSStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        string _username = _loginResult["Username"].ToString();
        string _systemGroup = _loginResult["SystemGroup"].ToString();
        string _program = _loginResult["Program"].ToString();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("DegreeLevel", _degreeLevel);
        _paramSearch.Add("Faculty", _faculty);
        _paramSearch.Add("Program", _program);

        DataSet _ds = Util.DBUtil.GetListProgram(_username, _systemGroup, _paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i] = _dr["programId"].ToString();
            _optionText[_i] = (_dr["programCode"].ToString() + " " + _dr["majorCode"].ToString() + " " + _dr["groupNum"].ToString() + " : " + _dr["programNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? " : " : String.Empty) + _dr["programNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

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

    public static StringBuilder GetComboboxDocumentUpload(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil._documentUpload.GetLength(0)];
        string[] _optionText = new string[UDSStaffUtil._documentUpload.GetLength(0)];

        for (_i = 0; _i < UDSStaffUtil._documentUpload.GetLength(0); _i++)
        {
            _optionValue[_i] = UDSStaffUtil._documentUpload[_i, 2];
            _optionText[_i] = (UDSStaffUtil._documentUpload[_i, 0] + " : " + UDSStaffUtil._documentUpload[_i, 1]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxSubmittedStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil._submittedStatus.GetLength(0)];
        string[] _optionText = new string[UDSStaffUtil._submittedStatus.GetLength(0)];

        for (_i = 0; _i < UDSStaffUtil._submittedStatus.GetLength(0); _i++)
        {
            _optionValue[_i] = UDSStaffUtil._submittedStatus[_i, 2];
            _optionText[_i] = (UDSStaffUtil._submittedStatus[_i, 0] + " : " + UDSStaffUtil._submittedStatus[_i, 1]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxApprovalStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil._approvalStatus.GetLength(0)];
        string[] _optionText = new string[UDSStaffUtil._approvalStatus.GetLength(0)];

        for (_i = 0; _i < UDSStaffUtil._approvalStatus.GetLength(0); _i++)
        {
            _optionValue[_i] = UDSStaffUtil._approvalStatus[_i, 2];
            _optionText[_i] = (UDSStaffUtil._approvalStatus[_i, 0] + " : " + UDSStaffUtil._approvalStatus[_i, 1]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxAuditedStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil._auditedStatus.GetLength(0)];
        string[] _optionText = new string[UDSStaffUtil._auditedStatus.GetLength(0)];

        for (_i = 0; _i < UDSStaffUtil._auditedStatus.GetLength(0); _i++)
        {
            _optionValue[_i] = UDSStaffUtil._auditedStatus[_i, 2];
            _optionText[_i] = (UDSStaffUtil._auditedStatus[_i, 0] + " : " + UDSStaffUtil._auditedStatus[_i, 1]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    public static StringBuilder GetComboboxExportStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[UDSStaffUtil._exportStatus.GetLength(0)];
        string[] _optionText = new string[UDSStaffUtil._exportStatus.GetLength(0)];

        for (_i = 0; _i < UDSStaffUtil._exportStatus.GetLength(0); _i++)
        {
            _optionValue[_i] = UDSStaffUtil._exportStatus[_i, 2];
            _optionText[_i] = (UDSStaffUtil._exportStatus[_i, 0] + " : " + UDSStaffUtil._exportStatus[_i, 1]);
        }

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

    public static StringBuilder GetComboboxUDSCountry(string _idCombobox)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("CancelledStatus", "N");
        _paramSearch.Add("SortOrderBy", "Full Name ( TH )");

        DataSet _ds = UDSStaffDB.GetListUDSCountry(_paramSearch);
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

    public static StringBuilder GetComboboxUDSProvince(string _idCombobox, string _countryId)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Country",  _countryId);
        _paramSearch.Add("CancelledStatus", "N");
        _paramSearch.Add("SortOrderBy", "Full Name ( TH )");

        DataSet _ds = UDSStaffDB.GetListUDSProvince(_paramSearch);
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
        _paramSearch.Add("Province",  _provinceId);
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

    public static StringBuilder GetComboboxUDSInsititue(string _idCombobox, string _provinceId)
    {
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Province", _provinceId);
        _paramSearch.Add("CancelledStatus", "N");
        _paramSearch.Add("SortOrderBy", "Full Name ( TH )");

        DataSet _ds = UDSStaffDB.GetListUDSInstitute(_paramSearch);
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
    
    public static StringBuilder GetValueSearch(string _page)
    {
        StringBuilder _html = new StringBuilder();
        Dictionary<string, object> _valueSearch = UDSStaffUtil.SetValueSearch(_page);
        string _keyword = (string)Util.GetValueDataDictionary(_valueSearch, "Keyword", _valueSearch["Keyword"], String.Empty);
        string _degreeLevel = (string)Util.GetValueDataDictionary(_valueSearch, "DegreeLevel", _valueSearch["DegreeLevel"], String.Empty);
        string _faculty = (string)Util.GetValueDataDictionary(_valueSearch, "Faculty", _valueSearch["Faculty"], String.Empty);
        string _program = (string)Util.GetValueDataDictionary(_valueSearch, "Program", _valueSearch["Program"], String.Empty);
        string _yearEntry = (string)Util.GetValueDataDictionary(_valueSearch, "YearEntry", _valueSearch["YearEntry"], String.Empty);
        string _entranceType = (string)Util.GetValueDataDictionary(_valueSearch, "EntranceType", _valueSearch["EntranceType"], String.Empty);
        string _studentStatus = (string)Util.GetValueDataDictionary(_valueSearch, "StudentStatus", _valueSearch["StudentStatus"], String.Empty);
        string _documentUpload = (string)Util.GetValueDataDictionary(_valueSearch, "DocumentUpload", _valueSearch["DocumentUpload"], String.Empty);
        string _submittedStatus = (string)Util.GetValueDataDictionary(_valueSearch, "SubmittedStatus", _valueSearch["SubmittedStatus"], String.Empty);
        string _approvalStatus = (string)Util.GetValueDataDictionary(_valueSearch, "ApprovalStatus", _valueSearch["ApprovalStatus"], String.Empty);
        string _instituteCountry = (string)Util.GetValueDataDictionary(_valueSearch, "InstituteCountry", _valueSearch["InstituteCountry"], String.Empty);
        string _instituteProvince = (string)Util.GetValueDataDictionary(_valueSearch, "InstituteProvince", _valueSearch["InstituteProvince"], String.Empty);
        string _institute = (string)Util.GetValueDataDictionary(_valueSearch, "Institute", _valueSearch["Institute"], String.Empty);
        string _sentDateStartAudit = (string)Util.GetValueDataDictionary(_valueSearch, "SentDateStartAudit", _valueSearch["SentDateStartAudit"], String.Empty);
        string _sentDateEndAudit = (string)Util.GetValueDataDictionary(_valueSearch, "SentDateEndAudit", _valueSearch["SentDateEndAudit"], String.Empty);
        string _auditedStatus = (string)Util.GetValueDataDictionary(_valueSearch, "AuditedStatus", _valueSearch["AuditedStatus"], String.Empty);
        string _exportStatus = (string)Util.GetValueDataDictionary(_valueSearch, "ExportStatus", _valueSearch["ExportStatus"], String.Empty);        
        string _sortOrderBy = (string)Util.GetValueDataDictionary(_valueSearch, "SortOrderBy", _valueSearch["SortOrderBy"], String.Empty);
        string _sortExpression = (string)Util.GetValueDataDictionary(_valueSearch, "SortExpression", _valueSearch["SortExpression"], String.Empty);
        string _rowPerPage = (string)Util.GetValueDataDictionary(_valueSearch, "RowPerPage", _valueSearch["RowPerPage"].ToString(), String.Empty);
        string _idSectionMain = String.Empty;
        string _idSectionSearch = String.Empty;
        string _sortOrderByDefault = String.Empty;
                        
        if (_page.Equals(UDSStaffUtil.PAGE_UPLOADSUBMITDOCUMENT_MAIN))
        { 
            _idSectionMain = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENT_MAIN.ToLower();
            _idSectionSearch = UDSStaffUtil.ID_SECTION_UPLOADSUBMITDOCUMENT_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }
        
        if (_page.Equals(UDSStaffUtil.PAGE_APPROVEDOCUMENT_MAIN))
        {
            _idSectionMain = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENT_MAIN.ToLower();
            _idSectionSearch = UDSStaffUtil.ID_SECTION_APPROVEDOCUMENT_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }
        
        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN))
        {
            _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENT_MAIN.ToLower();
            _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESDOCUMENTSTATUSSTUDENT_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }
        
        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN))
        {
            _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_MAIN.ToLower();
            _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTPROFILEPICTUREAPPROVED_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }
        
        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN))
        {
            _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_MAIN.ToLower();
            _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSTUDENTRECORDSINFORMATIONFORSMARTCARD_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN))
        {
            _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_MAIN.ToLower();
            _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESCOPYPROFILEPICTUREAPPROVEDTOTHESTORE_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN))
        {
            _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVED_MAIN.ToLower();
            _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESAUDITTRANSCRIPTAPPROVED_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }
        
        if (_page.Equals(UDSStaffUtil.PAGE_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN))
        {
            _idSectionMain = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_MAIN.ToLower();
            _idSectionSearch = UDSStaffUtil.ID_SECTION_OURSERVICESEXPORTSAVEAUDITTRANSCRIPTAPPROVED_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        _html.AppendFormat("<input type='hidden' id='{0}-keyword-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_keyword) ? _keyword : Util._valueTextDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-degreelevel-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_degreeLevel) ? _degreeLevel : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-faculty-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_faculty) ? _faculty : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-program-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_program) ? _program : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-yearattended-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_yearEntry) ? _yearEntry : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-entrancetype-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_entranceType) ? _entranceType : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-studentstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_studentStatus) ? _studentStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-documentupload-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_documentUpload) ? _documentUpload : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_submittedStatus) ? _submittedStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_approvalStatus) ? _approvalStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-institutecountry-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_instituteCountry) ? _instituteCountry : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-instituteprovince-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_instituteProvince) ? _instituteProvince : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-institute-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_institute) ? _institute : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-sentdatestartaudit-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_sentDateStartAudit) ? _sentDateStartAudit : Util._valueTextDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-sentdateendaudit-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_sentDateEndAudit) ? _sentDateEndAudit : Util._valueTextDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-auditedstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_auditedStatus) ? _auditedStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-exportstatus-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_exportStatus) ? _exportStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-sortorderby-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_sortOrderBy) ? _sortOrderBy : _sortOrderByDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-sortexpression-hidden' value='{1}' />", _idSectionSearch, (!String.IsNullOrEmpty(_sortExpression) ? _sortExpression : "Ascending"));
        _html.AppendFormat("<input type='hidden' id='{0}-rowperpage-hidden' value='{1}' />", _idSectionMain, (!String.IsNullOrEmpty(_rowPerPage) ? _rowPerPage : UDSStaffUtil._myRowPerPageDefault));

        return _html;
    }

    public static StringBuilder GetFrmRecommendUploadProfilePicture()
    {
        StringBuilder _html = new StringBuilder();
        List<string> _ls = new List<string>();

        _html.AppendLine("<div class='dialogmessage-form'>");
        _html.AppendLine("  <div class='form-layout'>");
        _html.AppendLine("      <div class='form-content'>");

        _ls = UDSStaffDB.GetListText("TH", "Recommend.txt");

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

        _ls = UDSStaffDB.GetListText("TH", "Recommend.txt");

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

        _ls = UDSStaffDB.GetListText("TH", "Recommend.txt");

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

        _ls = UDSStaffDB.GetListText("TH", "Recommend.txt");

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

        _ls = UDSStaffDB.GetListText("TH", "Recommend.txt");

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

        _ls = UDSStaffDB.GetListText("TH", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}</div>", _ls[29]);
        _html.AppendLine("          <hr />");

        _ls = UDSStaffDB.GetListText("EN", "Recommend.txt");

        _html.AppendFormat("        <div class='th-label'>{0}</div>", _ls[0]);        
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");
        _html.AppendLine("</div>");

        return _html;
    }

    public static StringBuilder GetFrmPreviewDocument(string _section)
    {
        StringBuilder _html = new StringBuilder();

        _html.AppendFormat("<div class='picture-content {0}-content'>", _section.ToLower());
        _html.AppendFormat("    <div class='picture-zoom en-label' alt='{0}'>Click Here to Enlarge</div>", _section);
        _html.AppendLine("      <div class='picture-watermark'></div>");
        _html.AppendLine("      <img/>");
        _html.AppendLine("  </div>");

        return _html;
    }

    public class PreviewDocumentUI
    {
        private static StringBuilder GetFrmPreviewDocument(string _section, bool _upload, bool _approve)
        {
            StringBuilder _html = new StringBuilder();

            _html.AppendLine(UDSStaffUI.GetFrmPreviewDocument(_section).ToString());

            if (_upload.Equals(true))
            {
                _html.AppendFormat("<div class='{0}-preview-content' align='center'>", UDSStaffUtil.SUBJECT_SECTION_UPLOADSUBMITDOCUMENT.ToLower());
                _html.AppendLine("      <div class='uploaddocument-submittedstatus'></div>");
                _html.AppendLine("  </div>");
            }

            if (_approve.Equals(true))
            {               
                _html.AppendFormat("<div class='{0}-preview-content' align='center'>", UDSStaffUtil.SUBJECT_SECTION_APPROVEDOCUMENT.ToLower());
                _html.AppendFormat("    <input class='radio hidden' type='radio' name='{0}-approvalstatus' value='Y' />", (UDSStaffUtil.ID_SECTION_APPROVEDOCUMENT_EDIT + _section).ToLower());
                _html.AppendFormat("    <input class='radio hidden' type='radio' name='{0}-approvalstatus' value='N' />", (UDSStaffUtil.ID_SECTION_APPROVEDOCUMENT_EDIT + _section).ToLower());
                _html.AppendLine("      <div>");
                _html.AppendLine("          <div class='nomargin uploaddocument-approvalstatus uploaddocument-approvalstatus-y'><div class='check-mark hidden'></div></div>");
                _html.AppendLine("          <div class='uploaddocument-approvalstatus uploaddocument-approvalstatus-n'><div class='check-mark hidden'></div></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("      <div class='button'>");
                _html.AppendLine("          <div class='button-layout'>");
                _html.AppendLine("              <div class='button-content'>");
                _html.AppendLine("                  <ul class='button-style1'>");
                _html.AppendLine("                      <li class='nomargin'><a class='en-label button-save' href='javascript:void(0)'>SAVE</a></li>");
                _html.AppendLine("                      <li><a class='en-label button-undo' href='javascript:void(0)'>CLEAR</a></li>");
                _html.AppendLine("                  </ul>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("  </div>");
            }

            return _html;
        }
        
        public class ProfilePictureIdentityCardUI
        {
            public static string _subjectSectionProfilePictureIdentityCard;
            public static string _idSectionProfilePictureIdentityCardPreview;
            public static string _idSectionProfilePicturePreview;
            public static string _idSectionIdentityCardPreview;
            public static string _pageProfilePictureIdentityCardPreview;
           
            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + _subjectSectionProfilePictureIdentityCard];

                if (!String.IsNullOrEmpty(_idSectionProfilePictureIdentityCardPreview) || !String.IsNullOrEmpty(_idSectionProfilePicturePreview))
                {
                    _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureFileDir", _dataRecorded["ProfilePictureFileDir"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureFileName", _dataRecorded["ProfilePictureFileName"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-filefullpath-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureFileFullPath", _dataRecorded["ProfilePictureFileFullPath"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureWidth", _dataRecorded["ProfilePictureWidth"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureHeight", _dataRecorded["ProfilePictureHeight"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureSavedStatus", _dataRecorded["ProfilePictureSavedStatus"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureSubmittedStatus", _dataRecorded["ProfilePictureSubmittedStatus"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureApprovalStatus", _dataRecorded["ProfilePictureApprovalStatus"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-message-hidden' value='{1}' />", _idSectionProfilePicturePreview, Util.GetValueDataDictionary(_dataRecorded, "ProfilePictureMessage", _dataRecorded["ProfilePictureMessage"], Util._valueTextDefault));
                }

                if (!String.IsNullOrEmpty(_idSectionProfilePictureIdentityCardPreview) || !String.IsNullOrEmpty(_idSectionIdentityCardPreview))
                {
                    _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardFileDir", _dataRecorded["IdentityCardFileDir"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardFileName", _dataRecorded["IdentityCardFileName"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-filefullpath-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardFileFullPath", _dataRecorded["IdentityCardFileFullPath"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardWidth", _dataRecorded["IdentityCardWidth"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardHeight", _dataRecorded["IdentityCardHeight"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardSavedStatus", _dataRecorded["IdentityCardSavedStatus"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardSubmittedStatus", _dataRecorded["IdentityCardSubmittedStatus"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardApprovalStatus", _dataRecorded["IdentityCardApprovalStatus"], Util._valueTextDefault));
                    _html.AppendFormat("<input type='hidden' id='{0}-message-hidden' value='{1}' />", _idSectionIdentityCardPreview, Util.GetValueDataDictionary(_dataRecorded, "IdentityCardMessage", _dataRecorded["IdentityCardMessage"], Util._valueTextDefault));
                }

                return _html;
            }

            public static StringBuilder GetMain(string _id, bool _upload, bool _approve)
            {
                StringBuilder _html = new StringBuilder();
                
                _html.AppendLine(GetValueDataRecorded(UDSStaffUtil.SetValueDataRecorded(_pageProfilePictureIdentityCardPreview, _id)).ToString());
                
                if (!String.IsNullOrEmpty(_idSectionProfilePictureIdentityCardPreview) && !String.IsNullOrEmpty(_idSectionProfilePicturePreview) && !String.IsNullOrEmpty(_idSectionIdentityCardPreview))
                {
                    _html.AppendFormat("<div id='{0}-form'>", _idSectionProfilePictureIdentityCardPreview);
                    _html.AppendLine("      <div>");
                    _html.AppendFormat("        <div class='contentbody-left' id='{0}-form'>{1}</div>", _idSectionProfilePicturePreview, GetFrmPreviewDocument(UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTURE, _upload, _approve));
                    _html.AppendFormat("        <div class='contentbody-left' id='{0}-form'>{1}</div>", _idSectionIdentityCardPreview, GetFrmPreviewDocument(UDSStaffUtil.SUBJECT_SECTION_IDENTITYCARD, _upload, _approve));
                    _html.AppendLine("      </div>");
                    _html.AppendLine("      <div class='clear'></div>");
                    _html.AppendLine("  </div>");
                }

                if (String.IsNullOrEmpty(_idSectionProfilePictureIdentityCardPreview) && !String.IsNullOrEmpty(_idSectionProfilePicturePreview) && String.IsNullOrEmpty(_idSectionIdentityCardPreview))
                {
                    _html.AppendLine("<div>");
                    _html.AppendFormat("    <div class='contentbody-left' id='{0}-form'>{1}</div>", _idSectionProfilePicturePreview, UDSStaffUI.GetFrmPreviewDocument(UDSStaffUtil.SUBJECT_SECTION_PROFILEPICTURE));
                    _html.AppendLine("</div>");
                    _html.AppendLine("<div class='clear'></div>");
                }

                return _html;
            }
        }

        public class TranscriptUI
        {
            public static string _subjectSectionTranscript;
            public static string _idSectionTranscriptPreview;
            public static string _idSectionTranscriptInstitutePreview;
            public static string _idSectionTranscriptFrontsidePreview;
            public static string _idSectionTranscriptBacksidePreview;
            public static string _pageTranscriptPreview;

            public static StringBuilder GetValueDataRecorded(Dictionary<string, object> _valueDataRecorded)
            {
                StringBuilder _html = new StringBuilder();
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + _subjectSectionTranscript];

                _html.AppendFormat("<input type='hidden' id='{0}-institute-hidden' value='{1}' />", _idSectionTranscriptInstitutePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptInstitute", _dataRecorded["TranscriptInstitute"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideFileDir", _dataRecorded["TranscriptFrontsideFileDir"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideFileName", _dataRecorded["TranscriptFrontsideFileName"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filefullpath-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideFileFullPath", _dataRecorded["TranscriptFrontsideFileFullPath"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideWidth", _dataRecorded["TranscriptFrontsideWidth"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideHeight", _dataRecorded["TranscriptFrontsideHeight"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideSavedStatus", _dataRecorded["TranscriptFrontsideSavedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideSubmittedStatus", _dataRecorded["TranscriptFrontsideSubmittedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideApprovalStatus", _dataRecorded["TranscriptFrontsideApprovalStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-message-hidden' value='{1}' />", _idSectionTranscriptFrontsidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptFrontsideMessage", _dataRecorded["TranscriptFrontsideMessage"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filedir-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideFileDir", _dataRecorded["TranscriptBacksideFileDir"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filename-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideFileName", _dataRecorded["TranscriptBacksideFileName"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-filefullpath-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideFileFullPath", _dataRecorded["TranscriptBacksideFileFullPath"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-width-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideWidth", _dataRecorded["TranscriptBacksideWidth"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-height-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideHeight", _dataRecorded["TranscriptBacksideHeight"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-savedstatus-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideSavedStatus", _dataRecorded["TranscriptBacksideSavedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-submittedstatus-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideSubmittedStatus", _dataRecorded["TranscriptBacksideSubmittedStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-approvalstatus-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideApprovalStatus", _dataRecorded["TranscriptBacksideApprovalStatus"], Util._valueTextDefault));
                _html.AppendFormat("<input type='hidden' id='{0}-message-hidden' value='{1}' />", _idSectionTranscriptBacksidePreview, Util.GetValueDataDictionary(_dataRecorded, "TranscriptBacksideMessage", _dataRecorded["TranscriptBacksideMessage"], Util._valueTextDefault));

                return _html;
            }

            public static StringBuilder GetMain(string _id, bool _upload, bool _approve)
            {
                StringBuilder _html = new StringBuilder();
                StringBuilder _contentTemp = new StringBuilder();
                Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
                Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[3];
                Dictionary<string, object> _valueDataRecorded = UDSStaffUtil.SetValueDataRecorded(_pageTranscriptPreview, _id);
                Dictionary<string, object> _dataRecorded = (Dictionary<string, object>)_valueDataRecorded["DataRecorded" + _subjectSectionTranscript];
                int _i = 0;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label' id='{0}'>{1}</div>", (_idSectionTranscriptPreview + "-institutenameth"), _dataRecorded["TranscriptInstituteNameTH"]);
                _contentTemp.AppendFormat("<div class='th-label' id='{0}'>{1}</div>", (_idSectionTranscriptPreview + "-institutenameen"), _dataRecorded["TranscriptInstituteNameEN"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionTranscriptPreview + "-nameofinstitution"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("TitleEN", "Name of Institution");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("Institute", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label' id='{0}'>{1}</div>", (_idSectionTranscriptPreview + "-institutecountrynameth"), _dataRecorded["TranscriptInstituteCountryNameTH"]);
                _contentTemp.AppendFormat("<div class='th-label' id='{0}'>{1}</div>", (_idSectionTranscriptPreview + "-institutecountrynameen"), _dataRecorded["TranscriptInstituteCountryNameEN"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionTranscriptPreview + "-countryofinstitution"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("TitleEN", "Country");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("InstituteCountry", _contentFrmColumnDetail[_i]);
                _i++;

                _contentTemp.Clear();
                _contentTemp.AppendFormat("<div class='th-label' id='{0}'>{1}</div>", (_idSectionTranscriptPreview + "-instituteprovincenameth"), _dataRecorded["TranscriptInstituteProvinceNameTH"]);
                _contentTemp.AppendFormat("<div class='th-label' id='{0}'>{1}</div>", (_idSectionTranscriptPreview + "-instituteprovincenameth"), _dataRecorded["TranscriptInstituteProvinceNameEN"]);

                _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
                _contentFrmColumnDetail[_i].Add("ID", (_idSectionTranscriptPreview + "-provinceofinstitution"));
                _contentFrmColumnDetail[_i].Add("HighLight", false);
                _contentFrmColumnDetail[_i].Add("TitleTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("TitleEN", "State / Province");
                _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
                _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
                _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
                _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
                _contentFrmColumnDetail[_i].Add("Require", false);
                _contentFrmColumnDetail[_i].Add("LastRow", true);
                _contentFrmColumn.Add("InstituteProvince", _contentFrmColumnDetail[_i]);

                _html.AppendLine(GetValueDataRecorded(_valueDataRecorded).ToString());
                _html.AppendLine("<div>");
                _html.AppendFormat("    <div class='preview-transcriptinstitute' id='{0}-form'>", _idSectionTranscriptInstitutePreview);
                _html.AppendLine("          <div class='form'>");
                _html.AppendLine("              <div class='form-layout'>");
                _html.AppendLine("                  <div class='form-content'>");
                _html.AppendLine(                       UDSStaffUI.GetFrmColumn(_contentFrmColumn["Institute"]).ToString());
                _html.AppendLine(                       UDSStaffUI.GetFrmColumn(_contentFrmColumn["InstituteCountry"]).ToString());
                _html.AppendLine(                       UDSStaffUI.GetFrmColumn(_contentFrmColumn["InstituteProvince"]).ToString());
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </div>");
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='button-toggle'><a class='en-label' href='javascript:void(0)'>Click to View Institution Transcript</a></div>");
                _html.AppendLine("      </div>");
                _html.AppendFormat("    <div id='{0}-form'>", _idSectionTranscriptPreview);
                _html.AppendLine("          <div>");
                _html.AppendFormat("            <div class='contentbody-left' id='{0}-form'>{1}</div>", _idSectionTranscriptFrontsidePreview, GetFrmPreviewDocument(UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTFRONTSIDE, _upload, _approve));
                _html.AppendFormat("            <div class='contentbody-left' id='{0}-form'>{1}</div>", _idSectionTranscriptBacksidePreview, GetFrmPreviewDocument(UDSStaffUtil.SUBJECT_SECTION_TRANSCRIPTBACKSIDE, _upload, _approve));
                _html.AppendLine("          </div>");
                _html.AppendLine("          <div class='clear'></div>");
                _html.AppendLine("      </div>");
                _html.AppendLine("</div>");

                return _html;
            }
        }
    }
}