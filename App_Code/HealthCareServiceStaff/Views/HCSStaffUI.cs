// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๖/๐๗/๒๕๕๘>
// Modify date  : <๑๖/๐๒/๒๕๖๓>
// Description  : <คลาสใช้งานเกี่ยวกับการใช้งานแสดงผล>
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using NUtil;
using NFinServiceLogin;

public class HCSStaffUI
{
    //ฟังก์ชั่นสำหรับแสดงเมนูบาร์ แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _infoLogin เป็น Dictionary<string, object> รับค่าชุดข้อมูลของผู้ใช้งาน
    //2. _page      เป็น string รับค่าชื่อหน้า
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

        if (_cookieError.Equals(0) && (_userError.Equals(0) || _userError.Equals(3)))
        {
            _html.AppendLine("<div class='menubar'>");
            _html.AppendLine("  <div class='menubar-layout'>");
            _html.AppendLine("      <div class='menubar-content'>");
            _html.AppendLine("          <div class='contentbody-left'>");
            _html.AppendLine("              <ul>");

            if (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) && _faculty.Equals("MU-01"))
            {
                _html.AppendFormat("            <li class='have-link link-submenu' id='link-{0}'><div class='link-msg th-label'>{1}</div>", HCSStaffUtil._menu[0, 2].ToLower(), HCSStaffUtil._menu[0, 0]);
                _html.AppendLine("                  <div class='submenu'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", HCSStaffUtil._submenu[0, 2].ToLower(), HCSStaffUtil._submenu[0, 0], "");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", HCSStaffUtil._submenu[1, 2].ToLower(), HCSStaffUtil._submenu[1, 0], "");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", HCSStaffUtil._submenu[2, 2].ToLower(), HCSStaffUtil._submenu[2, 0], "");
                _html.AppendLine("                      </ul>");
                _html.AppendLine("                  </div>");
                _html.AppendLine("              </li>");
            }
             
            if (_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_USER))
            {
                _html.AppendFormat("            <li class='have-link'><a class='link-msg link-click th-label' id='link-{0}' href='javascript:void(0)'>{1}</a></li>", HCSStaffUtil._menu[1, 2].ToLower(), HCSStaffUtil._menu[1, 0]);
                _html.AppendFormat("            <li class='have-link link-submenu' id='link-{0}'><div class='link-msg th-label'>{1}</div>", HCSStaffUtil._menu[2, 2].ToLower(), HCSStaffUtil._menu[2, 0]);
                _html.AppendLine("                  <div class='submenu'>");
                _html.AppendLine("                      <ul>");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", HCSStaffUtil._submenu[3, 2].ToLower(), HCSStaffUtil._submenu[3, 0], "");
                _html.AppendFormat("                        <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", HCSStaffUtil._submenu[4, 2].ToLower(), HCSStaffUtil._submenu[4, 0], "");

                if ((_userlevel.Equals(FinServiceLogin.USERLEVEL_ADMIN) || _userlevel.Equals(FinServiceLogin.USERLEVEL_ADMINUSER) || _userlevel.Equals(FinServiceLogin.USERLEVEL_SUPERUSER)) && _faculty.Equals("MU-01"))
                {
                    _html.AppendFormat("                    <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", HCSStaffUtil._submenu[7, 2].ToLower(), HCSStaffUtil._submenu[7, 0], "");
                    _html.AppendFormat("                    <li class='have-link'><a class='link-msg link-click' id='link-{0}' href='javascript:void(0)'><div class='th-label'>{1}</div><div class='en-label'>{2}</div></a></li>", HCSStaffUtil._submenu[8, 2].ToLower(), HCSStaffUtil._submenu[8, 0], "");
                }

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
    
    //ฟังก์ชั่นสำหรับแสดงเนื้อหาที่เป็นหัวข้อในหน้าที่ต้องการ แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _data      เป็น Dictionary รับค่าข้อมูลที่ต้องการให้แสดง
    //2. _sticky    เป็น bool รับค่าการว่าต้องการให้ตรึงแนวหรือไม่
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
            !String.IsNullOrEmpty(_infoOperatorClose))
        {
            _html.AppendLine("              <div class='operator'>");
            _html.AppendLine("                  <ul>");

            if (!String.IsNullOrEmpty(_infoOperatorHome))           _infoOperator.Add("operator-home;" + _infoOperatorHome + ";Home");
            if (!String.IsNullOrEmpty(_infoOperatorNew))            _infoOperator.Add("operator-new;" + _infoOperatorNew + ";New");
            if (!String.IsNullOrEmpty(_infoOperatorEdit))           _infoOperator.Add("operator-edit;" + _infoOperatorEdit + ";Edit");
            if (!String.IsNullOrEmpty(_infoOperatorDelete))         _infoOperator.Add("operator-delete;" + _infoOperatorDelete + ";Delete");
            if (!String.IsNullOrEmpty(_infoOperatorExportAll))      _infoOperator.Add("operator-exportall;" + _infoOperatorExportAll + ";Export All");
            if (!String.IsNullOrEmpty(_infoOperatorExportSelected)) _infoOperator.Add("operator-exportselected;" + _infoOperatorExportSelected + ";Export Selected");
            if (!String.IsNullOrEmpty(_infoOperatorSearch))         _infoOperator.Add("operator-search;" + _infoOperatorSearch + ";Search");
            if (!String.IsNullOrEmpty(_infoOperatorReset))          _infoOperator.Add("operator-reset;" + _infoOperatorReset + ";Reset");
            if (!String.IsNullOrEmpty(_infoOperatorSave))           _infoOperator.Add("operator-save;" + _infoOperatorSave + ";Save");
            if (!String.IsNullOrEmpty(_infoOperatorApply))          _infoOperator.Add("operator-apply;" + _infoOperatorApply + ";Apply");
            if (!String.IsNullOrEmpty(_infoOperatorUndo))           _infoOperator.Add("operator-undo;" + _infoOperatorUndo + ";Clear");
            if (!String.IsNullOrEmpty(_infoOperatorPrint))          _infoOperator.Add("operator-print;" + _infoOperatorPrint + ";Print");
            if (!String.IsNullOrEmpty(_infoOperatorUpload))         _infoOperator.Add("operator-upload;" + _infoOperatorUpload + ";Upload");
            if (!String.IsNullOrEmpty(_infoOperatorTransfer))       _infoOperator.Add("operator-transfer;" + _infoOperatorTransfer + ";Transfer");
            if (!String.IsNullOrEmpty(_infoOperatorClose))          _infoOperator.Add("operator-close;" + _infoOperatorClose + ";Close");

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

    //สำหรับแสดงรายละเบียดรายการต่าง ๆ ของฟอร์มแล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _contentFrmColumn  เป็น Dictionary<string, object> รับค่ารายละเอียดของคอลัมภ์
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

    //ฟังก์ชั่นสำหรับแสดงความหมายของระบบการสอบเข้า แล้วส่งค่ากลับเป็น StringBuilder
    public static StringBuilder GetFrmMeaningOfAdmissionType()
    {
        StringBuilder _html = new StringBuilder();        
        DataSet _ds = Util.DBUtil.GetListEntranceType(new Dictionary<string, object>());

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", HCSStaffUtil.ID_SECTION_MEANINGOFADMISSIONTYPE_MAIN.ToLower());
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

    //ฟังก์ชั่นสำหรับแสดงความหมายของสถานภาพการเป็นนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
    public static StringBuilder GetFrmMeaningOfStudentStatus()
    {
        StringBuilder _html = new StringBuilder();        
        DataSet _ds = Util.DBUtil.GetListStudentStatus(new Dictionary<string, object>());

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", HCSStaffUtil.ID_SECTION_MEANINGOFSTUDENTSTATUS_MAIN.ToLower());
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

    //ฟังก์ชั่นสำหรับแสดงแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
    public static StringBuilder GetFrmMeaningOfHealthCareServiceForm()
    {
        StringBuilder _html = new StringBuilder();        
        DataSet _ds = HCSStaffDB.GetListHCSRegistrationForm(new Dictionary<string, object>());

        _html.AppendFormat("<div class='dialogmessage-form' id='{0}-form'>", HCSStaffUtil.ID_SECTION_MEANINGOFHEALTHCARESERVICEFORM_MAIN.ToLower());
        _html.AppendLine("      <div class='form-layout'>");
        _html.AppendLine("          <div class='form-content'>");
        
        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _html.AppendLine("          <div>");
            _html.AppendLine("              <ul>");
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",  _dr["id"]);
            _html.AppendFormat("                <li><div class='th-label'>{0}</div></li>",  _dr["formNameTH"]);

            if (!String.IsNullOrEmpty(_dr["formNameTH"].ToString()) && !String.IsNullOrEmpty(_dr["formNameEN"].ToString()))
                _html.AppendFormat("            <li><div class='en-label'>&nbsp;: {0}</div></li>", _dr["formNameEN"]);
            
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

    //ฟังก์ชั่นสำหรับสร้างฟอร์มแสดงการประมวลผลข้อมูลในส่วนของการดาว์นโหลดข้อมูล แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _page      เป็น string รับค่าชื่อหน้า
    //2. _idContent เป็น string รับค่าชื่อฟอร์ม
    public static StringBuilder GetFrmProgressDownloadData(string _page, string _idContent)
    {
        StringBuilder _html = new StringBuilder();
        StringBuilder _contentTemp = new StringBuilder();
        Dictionary<string, Dictionary<string, object>> _contentFrmColumn = new Dictionary<string, Dictionary<string, object>>();
        Dictionary<string, object>[] _contentFrmColumnDetail = new Dictionary<string, object>[5];
        int _i = 0;

        if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS))
        {
            _contentTemp.Clear();
            _contentTemp.AppendLine("<div class='progresstext'>");
            _contentTemp.AppendFormat("   <div class='th-label' id='{0}-registrationformnameth'></div>", _idContent);
            _contentTemp.AppendFormat("   <div class='en-label' id='{0}-registrationformnameen'></div>", _idContent);
            _contentTemp.AppendLine("</div>");

            _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
            _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-registrationform"));
            _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
            _contentFrmColumnDetail[_i].Add("TitleTH", "แบบฟอร์มบริการสุขภาพ");
            _contentFrmColumnDetail[_i].Add("TitleEN", "Registration Form");
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", true);
            _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", true);
            _contentFrmColumn.Add("RegistrationForm", _contentFrmColumnDetail[_i]);
            _i++;

            _contentTemp.Clear();
            _contentTemp.AppendLine("<div class='progresstotal'>");
            _contentTemp.AppendFormat(" <span class='th-label' id='{0}-total'></span>", _idContent);
            _contentTemp.AppendLine("   <span class='th-label'> คน</span>");
            _contentTemp.AppendLine("   <span class='en-label'> : people</span>");
            _contentTemp.AppendLine("</div>");

            _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
            _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-total"));
            _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
            _contentFrmColumnDetail[_i].Add("TitleTH", "ดาวน์โหลดให้กับนักศึกษาจำนวน");
            _contentFrmColumnDetail[_i].Add("TitleEN", "Download Provides Students With a Total of");
            _contentFrmColumnDetail[_i].Add("DiscriptionTH", String.Empty);
            _contentFrmColumnDetail[_i].Add("DiscriptionEN", String.Empty);
            _contentFrmColumnDetail[_i].Add("InputContentPaddingDown", false);
            _contentFrmColumnDetail[_i].Add("InputContent", _contentTemp.ToString());
            _contentFrmColumnDetail[_i].Add("Require", false);
            _contentFrmColumnDetail[_i].Add("LastRow", false);
            _contentFrmColumn.Add("Total", _contentFrmColumnDetail[_i]);
            _i++;
        }            

        _contentTemp.Clear();
        _contentTemp.AppendLine("<div class='progresstotal'>");
        _contentTemp.AppendFormat(" <span class='th-label' id='{0}-totalcomplete'></span>", _idContent);
        _contentTemp.AppendLine("   <span class='th-label'></span>");
        _contentTemp.AppendLine("   <span class='en-label'></span>");
        _contentTemp.AppendLine("</div>");

        _contentFrmColumnDetail[_i] = new Dictionary<string, object>();
        _contentFrmColumnDetail[_i].Add("ID", (_idContent + "-totalcomplete"));
        _contentFrmColumnDetail[_i].Add("HighLight", ((_i % 2) == 0 ? true : false));
        _contentFrmColumnDetail[_i].Add("TitleTH", "ดาว์นโหลดสำเร็จจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Download Complete Total of");
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
        _contentFrmColumnDetail[_i].Add("TitleTH", "ดาว์นโหลดไม่สำเร็จจำนวน");
        _contentFrmColumnDetail[_i].Add("TitleEN", "Download Incomplete Total of");
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
        _contentTemp.AppendLine("               <li class='nomargin'><div class='click-button en-label button-start'>START DOWNLOAD DATA</div></li>");
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

        if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_PROGRESS))
            _html.AppendLine(           HCSStaffUI.GetFrmColumn(_contentFrmColumn["RegistrationForm"]).ToString());

        _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Total"]).ToString());
        _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["TotalComplete"]).ToString());
        _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["TotalIncomplete"]).ToString());
        _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Start"]).ToString());
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้างฟอร์มแสดงการประมวลผลข้อมูลในส่วนของการส่งออกข้อมูล แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _page      เป็น string รับค่าชื่อหน้า
    //2. _idContent เป็น string รับค่าชื่อฟอร์ม
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

        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_PROGRESS) ||
            _page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORMLEVEL2VIEWTABLE_PROGRESS) ||
            _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_PROGRESS))
        {
            _unitTH = "คน";
            _unitEN = "people";
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
        _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Total"]).ToString());
        _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["TotalComplete"]).ToString());
        _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["TotalIncomplete"]).ToString());
        _html.AppendLine(               HCSStaffUI.GetFrmColumn(_contentFrmColumn["Start"]).ToString());
        _html.AppendLine("          </div>");
        _html.AppendLine("      </div>");
        _html.AppendLine("  </div>");

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลระดับปริญญา แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxDegreeLevel(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        DataSet _ds = Util.DBUtil.GetListDegreeLevel();
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i]    = _dr["id"].ToString();
            _optionText[_i]     = (_dr["degreeLevelNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["degreeLevelNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["degreeLevelNameTH"].ToString()) ? " : " : String.Empty) + _dr["degreeLevelNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลคณะ แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxFaculty(string _idCombobox)
    {
        Dictionary<string, object> _infoLoginResult = HCSStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        string _username = _infoLoginResult["Username"].ToString();
        string _systemGroup = _infoLoginResult["SystemGroup"].ToString();
        string _faculty = _infoLoginResult["Faculty"].ToString();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("Faculty", _faculty);

        DataSet _ds = Util.DBUtil.GetListFaculty(_username, _systemGroup, _paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i]    = _dr["facultyId"].ToString();
            _optionText[_i]     = (_dr["facultyCode"].ToString() + " : " + _dr["facultyNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["facultyNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["facultyNameTH"].ToString()) ? " : " : String.Empty) + _dr["facultyNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลหลักสูตร แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    //2. _degreeLevel   เป็น string รับค่าระดับปริญญา
    //3. _faculty       เป็น string รับค่ารหัสคณะ
    public static StringBuilder GetComboboxProgram(string _idCombobox, string _degreeLevel, string _faculty)
    {
        Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        string _username = _loginResult["Username"].ToString();
        string _systemGroup = _loginResult["SystemGroup"].ToString();
        string _program = _loginResult["Program"].ToString();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("DegreeLevel", _degreeLevel);
        _paramSearch.Add("Faculty",     _faculty);
        _paramSearch.Add("Program",     _program);

        DataSet _ds = Util.DBUtil.GetListProgram(_username, _systemGroup, _paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i]    = _dr["programId"].ToString();
            _optionText[_i]     = (_dr["programCode"].ToString() + " " + _dr["majorCode"].ToString() + " " + _dr["groupNum"].ToString() + " : " + _dr["programNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? " : " : String.Empty) + _dr["programNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลการแสดงจำนวนข้อมูลในแต่ละหน้า แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxRowPerPage(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        string[] _rowPerPage = HCSStaffUtil._myRowPerPage.Split(',');
        int _i = 0;

        string[] _optionValue = new string[_rowPerPage.GetLength(0)];
        string[] _optionText = new string[_rowPerPage.GetLength(0)];

        for (_i = 0; _i < _rowPerPage.GetLength(0); _i++)
        {
            _optionValue[_i]    = _rowPerPage[_i];
            _optionText[_i]     = ("Display " + _rowPerPage[_i]);
        }

        _html = Util.GetSelect(_idCombobox, "", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลสถานะการยกเลิก แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxCancelledStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[HCSStaffUtil._cancelledStatus.GetLength(0)];
        string[] _optionText = new string[HCSStaffUtil._cancelledStatus.GetLength(0)];

        for (_i = 0; _i < HCSStaffUtil._cancelledStatus.GetLength(0); _i++)
        {
            _optionValue[_i]    = HCSStaffUtil._cancelledStatus[_i, 0];
            _optionText[_i]     = (HCSStaffUtil._cancelledStatus[_i, 1] + " : " + HCSStaffUtil._cancelledStatus[_i, 2]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลสถานะการใช้งาน แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxActiveStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[HCSStaffUtil._activeStatus.GetLength(0)];
        string[] _optionText = new string[HCSStaffUtil._activeStatus.GetLength(0)];

        for (_i = 0; _i < HCSStaffUtil._activeStatus.GetLength(0); _i++)
        {
            _optionValue[_i] = HCSStaffUtil._activeStatus[_i, 0];
            _optionText[_i] = (HCSStaffUtil._activeStatus[_i, 1] + " : " + HCSStaffUtil._activeStatus[_i, 2]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลหน่วยบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    //2. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    public static StringBuilder GetComboboxHospital(string _idCombobox, Dictionary<string, object> _paramSearch)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        DataSet _ds = HCSStaffDB.GetListHCSHospital(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i]    = _dr["id"].ToString();
            _optionText[_i]     = (_dr["id"].ToString() + " - " + _dr["hospitalNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["hospitalNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["hospitalNameTH"].ToString()) ? " : " : String.Empty) + _dr["hospitalNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลแบบฟอร์มบริการสุขภาพ แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    //2. _paramSearch   เป็น Dictionary<string, object> รับค่าพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    public static StringBuilder GetComboboxRegistrationForm(string _idCombobox, Dictionary<string, object> _paramSearch)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        _paramSearch.Add("Cancel", "N");

        DataSet _ds = HCSStaffDB.GetListHCSRegistrationForm(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i]    = _dr["id"].ToString();
            _optionText[_i]     = (_dr["id"].ToString() + " - " + _dr["formNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["formNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["formNameTH"].ToString()) ? " : " : String.Empty) + _dr["formNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox        เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    //2. _yearEntry         เป็น string รับค่าปีที่เข้าศึกษา
    //3. _registrationForm  เป็น string รับค่าแบบฟอร์มบริการสุขภาพ   
    public static StringBuilder GetComboboxAgencyRegistered(string _idCombobox, string _yearEntry, string _registrationForm)
    {
        Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        string _faculty = _loginResult["Faculty"].ToString();
        string _program = _loginResult["Program"].ToString();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("YearEntry",           _yearEntry);
        _paramSearch.Add("Faculty",             _faculty);
        _paramSearch.Add("Program",             _program);
        _paramSearch.Add("RegistrationForm",    _registrationForm);

        DataSet _ds = HCSStaffDB.GetListHCSAgencyRegistered(_paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i]    = _dr["acaProgramId"].ToString();
            _optionText[_i]     = (_dr["programCode"].ToString() + " " + _dr["majorCode"].ToString() + " " + _dr["groupNum"].ToString() + " : " + _dr["programNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["programNameTH"].ToString()) ? " : " : String.Empty) + _dr["programNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }
    
    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลปีที่เข้าศึกษา แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxYearAttended(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        DataSet _ds = Util.DBUtil.GetListYearEntry();
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count + 1];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count + 1];

        _optionValue[_i]    = (int.Parse(_ds.Tables[0].Rows[0]["yearEntry"].ToString()) + 1).ToString();
        _optionText[_i]     = (int.Parse(_ds.Tables[0].Rows[0]["yearEntry"].ToString()) + 1).ToString();
        _i = 1;

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _optionValue[_i]    = _dr["yearEntry"].ToString();
            _optionText[_i]     = _dr["yearEntry"].ToString();

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลประเภทการสอบเข้ามหาวิทยาลัยมหิดล แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
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
            _optionValue[_i]    = _dr["id"].ToString();
            _optionText[_i]     = (_dr["entranceTypeNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["entranceTypeNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["entranceTypeNameTH"].ToString()) ? " : " : String.Empty) + _dr["entranceTypeNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลสถานภาพการเป็นนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
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
            _optionValue[_i]    = _dr["id"].ToString();
            _optionText[_i]     = (_dr["statusTypeNameTH"].ToString() + (!String.IsNullOrEmpty(_dr["statusTypeNameEN"].ToString()) ? (!String.IsNullOrEmpty(_dr["statusTypeNameTH"].ToString()) ? " : " : String.Empty) + _dr["statusTypeNameEN"].ToString() : String.Empty));

            _i++;
        }

        _ds.Dispose();

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลสถานะการด่่่าว์นโหลด แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxDownloadStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[HCSStaffUtil._downloadStatus.GetLength(0)];
        string[] _optionText = new string[HCSStaffUtil._downloadStatus.GetLength(0)];

        for (_i = 0; _i < HCSStaffUtil._downloadStatus.GetLength(0); _i++)
        {
            _optionValue[_i]    = HCSStaffUtil._downloadStatus[_i, 0];
            _optionText[_i]     = (HCSStaffUtil._downloadStatus[_i, 1] + " : " + HCSStaffUtil._downloadStatus[_i, 2]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลสถานะสิทธิขึ้นทะเบียนสิทธิรักษาพยาบาล แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxHCSJoinStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[HCSStaffUtil._hcsJoinStatus.GetLength(0)];
        string[] _optionText = new string[HCSStaffUtil._hcsJoinStatus.GetLength(0)];

        for (_i = 0; _i < HCSStaffUtil._hcsJoinStatus.GetLength(0); _i++)
        {
            _optionValue[_i] = HCSStaffUtil._hcsJoinStatus[_i, 0];
            _optionText[_i] = (HCSStaffUtil._hcsJoinStatus[_i, 1] + " : " + HCSStaffUtil._hcsJoinStatus[_i, 2]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลสถานะการแสดงความยินยอมให้ข้อมูลสำหรับการรับบริการปรึกษาออนไลน์สำหรับนักศึกษา แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    public static StringBuilder GetComboboxConsentStatus(string _idCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[HCSStaffUtil._consentStatus.GetLength(0)];
        string[] _optionText = new string[HCSStaffUtil._consentStatus.GetLength(0)];

        for (_i = 0; _i < HCSStaffUtil._consentStatus.GetLength(0); _i++)
        {
            _optionValue[_i] = HCSStaffUtil._consentStatus[_i, 0];
            _optionText[_i] = (HCSStaffUtil._consentStatus[_i, 1] + " : " + HCSStaffUtil._consentStatus[_i, 2]);
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ตามรายการข้อมูล แล้วค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    //2. _listCombobox  เป็น string[] รับค่ารายการที่ต้องการเรียง
    public static StringBuilder GetComboboxOrder(string _idCombobox, string[] _listCombobox)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[_listCombobox.GetLength(0)];
        string[] _optionText = new string[_listCombobox.GetLength(0)];

        for (_i = 0; _i < _listCombobox.GetLength(0); _i++)
        {
            _optionValue[_i]    = _listCombobox[_i];
            _optionText[_i]     = _listCombobox[_i];
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง Combobox ข้อมูลลำดับตัวเลข แล้วค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCombobox    เป็น string รับค่าชื่อ Combobox ที่ต้องการตั้ง
    //2. _listCombobox  เป็น string[] รับค่ารายการที่ต้องการเรียง
    public static StringBuilder GetComboboxOrder(string _idCombobox, int _orderStart, int _orderEnd)
    {
        StringBuilder _html = new StringBuilder();
        int _i = 0;

        string[] _optionValue = new string[(_orderEnd - _orderStart) + 1];
        string[] _optionText = new string[(_orderEnd - _orderStart) + 1];

        for (_i = 0; _i < ((_orderEnd - _orderStart) + 1); _i++)
        {
            _optionValue[_i]    = (_orderStart + _i).ToString();
            _optionText[_i]     = (_orderStart + _i).ToString();
        }

        _html = Util.GetSelect(_idCombobox, "กรุณาเลือก : Please Select", _optionValue, _optionText);

        return _html;
    }

    //ฟังก์ชั่นสำหรับสร้าง List ข้อมูลหลักสูตร แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _idCheckbox    เป็น string รับค่าชื่อ Checkbox ที่ต้องการตั้ง
    //2. _degreeLevel   เป็น string รับค่าระดับปริญญา
    //3. _faculty       เป็น string รับค่ารหัสคณะ
    //4. _program       เป็น string รับค่ารหัสหลักสูตร
    public static StringBuilder GetListProgram(string _idCheckbox, string _degreeLevel, string _faculty, string _program)
    {
        Dictionary<string, object> _loginResult = HCSStaffUtil.GetInfoLogin("", "");
        Dictionary<string, object> _paramSearch = new Dictionary<string, object>();
        StringBuilder _html = new StringBuilder();
        string _username = _loginResult["Username"].ToString();
        string _systemGroup = _loginResult["SystemGroup"].ToString();
        int _i = 0;

        _paramSearch.Clear();
        _paramSearch.Add("DegreeLevel", _degreeLevel);
        _paramSearch.Add("Faculty",     _faculty);
        _paramSearch.Add("Program",     _program);

        DataSet _ds = Util.DBUtil.GetListProgram(_username, _systemGroup, _paramSearch);
        string[] _optionValue = new string[_ds.Tables[0].Rows.Count];
        string[] _optionText = new string[_ds.Tables[0].Rows.Count];

        foreach (DataRow _dr in _ds.Tables[0].Rows)
        {
            _html.AppendLine("<div class='list-row'>");
            _html.AppendLine("  <div class='list-col'>");
            _html.AppendLine("      <div class='checkbox-content'>");
            _html.AppendLine("          <ul>");
            _html.AppendFormat("            <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='{0}' value='{1}' /></li>", _idCheckbox, _dr["programId"].ToString());
            _html.AppendFormat("            <li class='checkbox-labelcol'><div class='th-label'>{0}</div><div class='en-label'>{1}</div></li>", (_dr["programCode"].ToString() + " " + _dr["majorCode"].ToString() + " " + _dr["groupNum"].ToString() + " : " + _dr["programNameTH"].ToString()), (!String.IsNullOrEmpty(_dr["programNameEN"].ToString()) ? Util.UppercaseFirst(_dr["programNameEN"].ToString()) : String.Empty));
            _html.AppendLine("          </ul>");
            _html.AppendLine("      </div>");
            _html.AppendLine("      <div class='clear'></div>");
            _html.AppendLine("  </div>");
            _html.AppendLine("</div>");
        }

        _ds.Dispose();

        return _html;
    }
    
    //ฟังก์ชั่นสำหรับแสดงค่าที่ใช้ค้นหาข้อมูล แล้วส่งค่ากลับเป็น StringBuilder
    //โดยมีพารามิเตอร์ดังนี้
    //1. _page  เป็น string รับค่าชื่อหน้า
    public static StringBuilder GetValueSearch(string _page)
    {
        StringBuilder _html = new StringBuilder();
        Dictionary<string, object> _valueSearch = HCSStaffUtil.SetValueSearch(_page);
        string _keyword                 = (string)Util.GetValueDataDictionary(_valueSearch, "Keyword", _valueSearch["Keyword"], String.Empty);
        string _degreeLevel             = (string)Util.GetValueDataDictionary(_valueSearch, "DegreeLevel", _valueSearch["DegreeLevel"], String.Empty);
        string _faculty                 = (string)Util.GetValueDataDictionary(_valueSearch, "Faculty", _valueSearch["Faculty"], String.Empty);
        string _program                 = (string)Util.GetValueDataDictionary(_valueSearch, "Program", _valueSearch["Program"], String.Empty);
        string _yearEntry               = (string)Util.GetValueDataDictionary(_valueSearch, "YearEntry", _valueSearch["YearEntry"], String.Empty);
        string _entranceType            = (string)Util.GetValueDataDictionary(_valueSearch, "EntranceType", _valueSearch["EntranceType"], String.Empty);
        string _studentStatus           = (string)Util.GetValueDataDictionary(_valueSearch, "StudentStatus", _valueSearch["StudentStatus"], String.Empty);
        string _cancelledStatus         = (string)Util.GetValueDataDictionary(_valueSearch, "CancelledStatus", _valueSearch["CancelledStatus"], String.Empty);
        string _forPublicServant        = (string)Util.GetValueDataDictionary(_valueSearch, "ForPublicServant", _valueSearch["ForPublicServant"], String.Empty);        
        string _hospital                = (string)Util.GetValueDataDictionary(_valueSearch, "Hospital", _valueSearch["Hospital"], String.Empty);
        string _hcsJoin                 = (string)Util.GetValueDataDictionary(_valueSearch, "HCSJoin", _valueSearch["HCSJoin"], String.Empty);
        string _registrationForm        = (string)Util.GetValueDataDictionary(_valueSearch, "RegistrationForm", _valueSearch["RegistrationForm"], String.Empty);        
        string _downloadStatus          = (string)Util.GetValueDataDictionary(_valueSearch, "DownloadStatus", _valueSearch["DownloadStatus"], String.Empty);
        string _consentStatus           = (string)Util.GetValueDataDictionary(_valueSearch, "ConsentStatus", _valueSearch["ConsentStatus"], String.Empty);
        string _termServiceNote         = (string)Util.GetValueDataDictionary(_valueSearch, "TermServiceNote", _valueSearch["TermServiceNote"], String.Empty);
        string _consentDateStart        = (string)Util.GetValueDataDictionary(_valueSearch, "ConsentDateStart", _valueSearch["ConsentDateStart"], String.Empty);
        string _consentDateEnd          = (string)Util.GetValueDataDictionary(_valueSearch, "ConsentDateEnd", _valueSearch["ConsentDateEnd"], String.Empty);        
        string _sortOrderBy             = (string)Util.GetValueDataDictionary(_valueSearch, "SortOrderBy", _valueSearch["SortOrderBy"], String.Empty);
        string _sortExpression          = (string)Util.GetValueDataDictionary(_valueSearch, "SortExpression", _valueSearch["SortExpression"], String.Empty);
        string _rowPerPage              = (string)Util.GetValueDataDictionary(_valueSearch, "RowPerPage", _valueSearch["RowPerPage"].ToString(), String.Empty);
        string _idSectionMain           = String.Empty;
        string _idSectionSearch         = String.Empty;
        string _sortOrderByDefault      = String.Empty;

        if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN))
        {
            _idSectionMain      = HCSStaffUtil.ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_MAIN.ToLower();
            _idSectionSearch    = HCSStaffUtil.ID_SECTION_MASTERDATAHOSPITALOFHEALTHCARESERVICE_SEARCH.ToLower();
            _sortOrderByDefault = "ID";
        }

        if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAREGISTRATIONFORM_MAIN))
        {
            _idSectionMain      = HCSStaffUtil.ID_SECTION_MASTERDATAREGISTRATIONFORM_MAIN.ToLower();
            _idSectionSearch    = HCSStaffUtil.ID_SECTION_MASTERDATAREGISTRATIONFORM_SEARCH.ToLower();
            _sortOrderByDefault = "Order Form";
        }

        if (_page.Equals(HCSStaffUtil.PAGE_MASTERDATAAGENCYREGISTERED_MAIN))
        {
            _idSectionMain      = HCSStaffUtil.ID_SECTION_MASTERDATAAGENCYREGISTERED_MAIN.ToLower();
            _idSectionSearch    = HCSStaffUtil.ID_SECTION_MASTERDATAAGENCYREGISTERED_SEARCH.ToLower();
            _sortOrderByDefault = "Program";
        }

        if (_page.Equals(HCSStaffUtil.PAGE_DOWNLOADREGISTRATIONFORM_MAIN))
        {
            _idSectionMain      = HCSStaffUtil.ID_SECTION_DOWNLOADREGISTRATIONFORM_MAIN.ToLower();
            _idSectionSearch    = HCSStaffUtil.ID_SECTION_DOWNLOADREGISTRATIONFORM_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESHEALTHINFORMATION_MAIN))
        {
            _idSectionMain      = HCSStaffUtil.ID_SECTION_OURSERVICESHEALTHINFORMATION_MAIN.ToLower();
            _idSectionSearch    = HCSStaffUtil.ID_SECTION_OURSERVICESHEALTHINFORMATION_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN))
        {
            _idSectionMain      = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_MAIN.ToLower();
            _idSectionSearch    = HCSStaffUtil.ID_SECTION_OURSERVICESSTATISTICSDOWNLOADHEALTHCARESERVICEFORM_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        if (_page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTREGISTRATION_MAIN) ||
            _page.Equals(HCSStaffUtil.PAGE_OURSERVICESTERMSERVICEHCSCONSENTOOCA_MAIN))
        {
            _idSectionMain      = HCSStaffUtil.ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENT_MAIN.ToLower();
            _idSectionSearch    = HCSStaffUtil.ID_SECTION_OURSERVICESTERMSERVICEHCSCONSENT_SEARCH.ToLower();
            _sortOrderByDefault = "Student ID";
        }

        _html.AppendFormat("<input type='hidden' id='{0}-keyword-hidden' value='{1}' />",           _idSectionSearch, (!String.IsNullOrEmpty(_keyword) ? _keyword : Util._valueTextDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-degreelevel-hidden' value='{1}' />",       _idSectionSearch, (!String.IsNullOrEmpty(_degreeLevel) ? _degreeLevel : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-faculty-hidden' value='{1}' />",           _idSectionSearch, (!String.IsNullOrEmpty(_faculty) ? _faculty : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-program-hidden' value='{1}' />",           _idSectionSearch, (!String.IsNullOrEmpty(_program) ? _program : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-yearattended-hidden' value='{1}' />",      _idSectionSearch, (!String.IsNullOrEmpty(_yearEntry) ? _yearEntry : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-entrancetype-hidden' value='{1}' />",      _idSectionSearch, (!String.IsNullOrEmpty(_entranceType) ? _entranceType : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-studentstatus-hidden' value='{1}' />",     _idSectionSearch, (!String.IsNullOrEmpty(_studentStatus) ? _studentStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-cancelledstatus-hidden' value='{1}' />",   _idSectionSearch, (!String.IsNullOrEmpty(_cancelledStatus) ? _cancelledStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-forpublicservant-hidden' value='{1}' />",  _idSectionSearch, (!String.IsNullOrEmpty(_forPublicServant) ? _forPublicServant : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-hospital-hidden' value='{1}' />",          _idSectionSearch, (!String.IsNullOrEmpty(_hospital) ? _hospital : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-hcsjoin-hidden' value='{1}' />",           _idSectionSearch, (!String.IsNullOrEmpty(_hcsJoin) ? _hcsJoin : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-registrationform-hidden' value='{1}' />",  _idSectionSearch, (!String.IsNullOrEmpty(_registrationForm) ? _registrationForm : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-downloadstatus-hidden' value='{1}' />",    _idSectionSearch, (!String.IsNullOrEmpty(_downloadStatus) ? _downloadStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-consentstatus-hidden' value='{1}' />",     _idSectionSearch, (!String.IsNullOrEmpty(_consentStatus) ? _consentStatus : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-termservicenote-hidden' value='{1}' />",   _idSectionSearch, (!String.IsNullOrEmpty(_termServiceNote) ? _termServiceNote : Util._valueComboboxDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-consentdatestart-hidden' value='{1}' />",  _idSectionSearch, (!String.IsNullOrEmpty(_consentDateStart) ? _consentDateStart : Util._valueTextDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-consentdateend-hidden' value='{1}' />",    _idSectionSearch, (!String.IsNullOrEmpty(_consentDateEnd) ? _consentDateEnd : Util._valueTextDefault));        
        _html.AppendFormat("<input type='hidden' id='{0}-sortorderby-hidden' value='{1}' />",       _idSectionSearch, (!String.IsNullOrEmpty(_sortOrderBy) ? _sortOrderBy : _sortOrderByDefault));
        _html.AppendFormat("<input type='hidden' id='{0}-sortexpression-hidden' value='{1}' />",    _idSectionSearch, (!String.IsNullOrEmpty(_sortExpression) ? _sortExpression : "Ascending"));
        _html.AppendFormat("<input type='hidden' id='{0}-rowperpage-hidden' value='{1}' />",        _idSectionMain, (!String.IsNullOrEmpty(_rowPerPage) ? _rowPerPage : HCSStaffUtil._myRowPerPageDefault));

        return _html;
    }
}