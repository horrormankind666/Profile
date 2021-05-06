// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๗/๐๕/๒๕๕๘>
// Modify date  : <๒๙/๐๕/๒๕๖๒>
// Description  : <รวมรวบฟังก์ชั่นใช้งานทั่วไปของระบบ>
// =============================================

var UDSUtil = {
    tus: null,
    parentWidth: 1008,
    pathProject: "UploadDocument",
    urlHandler: "../../../Content/Handler/UploadDocument/UDSHandler.ashx",
    supportFileType: "jpg, jpeg",

    subjectSectionMeaningOfApprovalStatus: "MeaningOfApprovalStatus",
    subjectSectionStudentRecords: "StudentRecords",
    subjectSectionOverview: "Overview",
    subjectSectionProfilePicture: "ProfilePicture",
    subjectSectionIdentityCard: "IdentityCard",
    subjectSectionProfilePictureIdentityCard: "ProfilePictureIdentityCard",
    subjectSectionTranscript: "Transcript",
    subjectSectionTranscriptInstitute: "TranscriptInstitute",
    subjectSectionTranscriptFrontside: "TranscriptFrontside",
    subjectSectionTranscriptBackside: "TranscriptBackside",
    subjectSectionHelp: "Help",
    subjectSectionContactUS: "ContactUS",

    idSectionViewMessageMain: "Main-ViewMessage",
    idSectionUploadSubmitDocumentMain: "Main-UploadSubmitDocument",
    idSectionUploadSubmitDocumentAddUpdate: "AddUpdate-UploadSubmitDocument",
    idSectionUploadSubmitDocumentStudentRecordsAddUpdate: "AddUpdate-UploadSubmitDocumentStudentRecords",
    idSectionUploadSubmitDocumentOverviewAddUpdate: "AddUpdate-UploadSubmitDocumentOverview",
    idSectionUploadSubmitDocumentProfilePictureAddUpdate: "AddUpdate-UploadSubmitDocumentProfilePicture",
    idSectionUploadSubmitDocumentIdentityCardAddUpdate: "AddUpdate-UploadSubmitDocumentIdentityCard",
    idSectionUploadSubmitDocumentTranscriptAddUpdate: "AddUpdate-UploadSubmitDocumentTranscript",
    idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate: "AddUpdate-UploadSubmitDocumentTranscriptInstitute",
    idSectionUploadSubmitDocumentTranscriptFrontsideAddUpdate: "AddUpdate-UploadSubmitDocumentTranscriptFrontside",
    idSectionUploadSubmitDocumentTranscriptBacksideAddUpdate: "AddUpdate-UploadSubmitDocumentTranscriptBackside",
    
    pageContactUSMain: "ContactUSMain",
    pageMeaningOfApprovalStatusMain: "MeaningOfApprovalStatusMain",
    pageViewProfilePictureMain: "ViewProfilePictureMain",
    pageViewIdentityCardMain: "ViewIdentityCardMain",
    pageViewTranscriptFrontsideMain: "ViewTranscriptFrontsideMain",
    pageViewTranscriptBacksideMain: "ViewTranscriptBacksideMain",
    pageViewMessageMain: "ViewMessageMain",
    pageRecommendUploadProfilePictureMain: "RecommendUploadProfilePictureMain",
    pageRecommendUploadIdentityCardMain: "RecommendUploadIdentityCardMain",
    pageRecommendUploadTranscriptMain: "RecommendUploadTranscriptMain",
    pageRecommendUploadTranscriptFrontsideMain: "RecommendUploadTranscriptFrontsideMain",
    pageRecommendUploadTranscriptBacksideMain: "RecommendUploadTranscriptBacksideMain",
    pageRecommendSubmitMain: "RecommendSubmitMain",
    pageStudentRecordsStudentCVMain: "StudentRecordsStudentCVMain",
    pageUploadSubmitDocumentMain: "UploadSubmitDocumentMain",
    pageUploadSubmitDocumentAddUpdate: "UploadSubmitDocumentAddUpdate",
    pageUploadSubmitDocumentStudentRecordsAddUpdate: "UploadSubmitDocumentStudentRecordsAddUpdate",
    pageUploadSubmitDocumentOverviewAddUpdate: "UploadSubmitDocumentOverviewAddUpdate",
    pageUploadSubmitDocumentProfilePictureAddUpdate: "UploadSubmitDocumentProfilePictureAddUpdate",
    pageUploadSubmitDocumentIdentityCardAddUpdate: "UploadSubmitDocumentIdentityCardAddUpdate",
    pageUploadSubmitDocumentTranscriptAddUpdate: "UploadSubmitDocumentTranscriptAddUpdate",

    //ฟังก์ชั่นสำหรับกำหนดให้ทำงานตามเหตุการณ์ต่าง ๆ ที่เกิดขึ้นบน Menu Bar
    initMenuBar: function () {
        var _this = this;

        $(function () {
            $(".menubar .link-click").click(function () {
                var _idLink = $(this).attr("id");

                Util.dialogMessageClose();

                if (_idLink == ("link-" + _this.subjectSectionContactUS.toLowerCase())) Util.loadForm({
                                                                                            index: 1,
                                                                                            name: _this.pageContactUSMain,
                                                                                            dialog: true
                                                                                        }, function() {});
                if (_idLink == "link-signout") Util.confirmeSignOut();
            });
        });
    },

    //ฟังก์ชั่นสำหรับกำหนดให้ทำงานตามเหตุการณ์ต่าง ๆ ที่เกิดขึ้นบน Info Bar
    initInfoBar: function () {
        var _this = this;

        $(function () {
            $(".infobar .link-click").click(function () {
                var _idLink = $(this).attr("id");

                Util.dialogMessageClose();

                if (_idLink == ("home-"     + _this.pageUploadSubmitDocumentMain.toLowerCase()))    Util.getPage();
                if (_idLink == ("profile-" + _this.pageUploadSubmitDocumentMain.toLowerCase()))     Util.gotoPage({
                                                                                                        page: ("index.aspx?p=" + _this.pageStudentRecordsStudentCVMain),
                                                                                                        target: "_newtab"
                                                                                                    });
            });
        });
    },

    //ฟังก์ชั่นสำหรับแสดงข้อความผิดพลาดเมื่อมีการเปลี่ยนหน้าใหม่หรือความผิดพลาดของผู้ใช้่งานหรือความผิดพลาดของใบสมัคร
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //signinYN      รับค่าความต้องการเข้าสู่ระบบ
    //pageError     รับค่าผลของการตรวจสอบหน้าที่แสดง
    //cookieError   รับค่าผลของการตรวจสอบ Cookie
    //userError     รับค่าผลของการตรวจสอบ User
    //saveError     รับค่าผลของการบันทึกข้อมูล
    getErrorMsg: function (_param) {
        _param["signinYN"]      = (_param["signinYN"] == undefined || _param["signinYN"] == "" ? "N" : _param["signinYN"]);
        _param["pageError"]     = (_param["pageError"] == undefined || _param["pageError"] == "" ? 0 : _param["pageError"]);
        _param["cookieError"]   = (_param["cookieError"] == undefined || _param["cookieError"] == "" ? 0 : _param["cookieError"]);
        _param["userError"]     = (_param["userError"] == undefined || _param["userError"] == "" ? 0 : _param["userError"]);
        _param["saveError"]     = (_param["saveError"] == undefined || _param["saveError"] == "" ? 0 : _param["saveError"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _status = (_param["signinYN"] + _param["cookieError"] + _param["userError"] + _param["saveError"]);

        if (_error == false && _param["pageError"] == 1)    { _error = true; _msgTH = "ไม่พบหน้านี้"; _msgEN = "Page not found."; }
        if (_error == false && _status == "Y100")           { _error = true; _msgTH = "กรุณาเข้าระบบนักศึกษา"; _msgEN = "Please sign in student portal"; }
        if (_error == false && _status == "Y020")           { _error = true; _msgTH = "ระบบยังไม่เปิดทำการ"; _msgEN = "The system is not open"; }
        if (_error == false && _status == "Y030")           { _error = true; _msgTH = "ระบบปิดทำการ"; _msgEN = "Close system"; }
        if (_error == false && _status == "Y040")           { _error = true; _msgTH = "นักศึกษาไม่มีสิทธิ์เข้าใช้ระบบ"; _msgEN = "No permission students"; }
        if (_error == false && _status == "Y001")           { _error = true; _msgTH = "บันทึกข้อมูลไม่สำเร็จ"; _msgEN = "Save was not successful"; }
        if (_error == false && _status == "N010")           { _error = true; _msgTH = "กรุณาออกจากระบบระเบียนประวัตินักศึกษา"; _msgEN = "Please sign out student records"; }
        if (_error == false && _status == "N110")           { _error = true; _msgTH = "ไม่พบนักศึกษา"; _msgEN = "Students not found"; }
      
        if (_error == true && _msgTH.length > 0 && _msgEN.length > 0)
            Util.dialogMessageError({
                content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
            });

        if (_status == "Y020" || _status == "Y030" || _status == "Y040")
            _error = false;

        return _error;
    },

    //ฟังก์ชั่นสำหรับโหลดหน้าที่ต้องการมาแสดง
    //โดยมีพารามิเตอร์ดังนี้
    //1. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
    loadPage: function (_callBackFunc) {
        var _this = this;
        var _error;
        var _page = ($("#page").html().length > 0 ? $("#page").html() : this.pageUploadSubmitDocumentMain);
        var _send = {};
        _send["action"] = "page";
        _send["page"]   = _page;
        
        Util.msgPreloading = "Loading...";

        Util.loadAjax({
            url: this.urlHandler,
            method: "POST",
            data: _send,
            showPreloadingInline: false
        }, function (_result) {            
            Util.clearPage();

            $("#page").html(_result.Page);
            $("#menubar-content").html(_result.MenuBarContent);

            _error = _this.getErrorMsg({
                        signinYN: _result.SignInYN,
                        pageError: _result.PageError,
                        cookieError: _result.CookieError,
                        userError: _result.UserError
                     });

            if (_error == false)
            {
                if (_page == _this.pageStudentRecordsStudentCVMain)
                    $("#bodymain #mainbody .sticky").html("");

                $("#contentbody-content").html(_result.MainContent).show();

                Util.setMenuBarLayout();
                Util.setInfoBarLayout();
                Util.setStickyTop(0);
                Util.setFooterLayout();

                if (_page == _this.pageUploadSubmitDocumentMain)
                {
                    if (_result.UserError == "2" || _result.UserError == "3" || _result.UserError == "4")
                    {
                        $("#link-" + Util.tut.idSectionUploadSubmitDocumentProfilePictureAddUpdate.toLowerCase()).closest("li").hide();
                        $("#link-" + Util.tut.idSectionUploadSubmitDocumentIdentityCardAddUpdate.toLowerCase()).closest("li").hide();
                        $("#link-" + Util.tut.idSectionUploadSubmitDocumentTranscriptAddUpdate.toLowerCase()).closest("li").hide();
                    }

                    Util.tut.tus.sectionMain.initMain();
                }
            }
                       
            _this.initMenuBar();
            _this.initInfoBar();

            Util.initTextSelect();
            Util.gotoTopElement();
            
            _callBackFunc();
        });
    },

    //ฟังก์ชั่นสำหรับกำหนดให้มีการทำงานอย่างใดอย่างหนึ่งเมื่อมีการเลือกรายการใน Combobox
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //id        รับค่าชื่อของ Combobox
    //value     รับค่าค่าของ Combobox
    setSelectCombobox: function (_param) {
        _param["id"]    = (_param["id"] == undefined ? "" : _param["id"]);
        _param["value"] = (_param["value"] == undefined ? "" : _param["value"]);

        var _this = this;
        var _cmd;
        var _idCombobox;
        var _idContainer;
        var _idRadiobox;
        var _idCheckbox;
        var _idTextbox;
        var _valueParam = {};
        var _valueDefault;
        var _valueArray;
        var _valueCountry = "";
        var _valueProvince = "";
        var _widthInput;
        var _heightInput;
        var _idContent;
        var _page;    

        if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-instituteprovince"))
        {
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institutecountry"))
            {
                _idContent          = this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase();
                _cmd                = "getprovince";
                _idCombobox         = (_idContent + "-instituteprovince");
                _idContainer        = (_idContent + "-instituteprovince-combobox");
                _valueCountry       = _param["value"];
                _widthInput         = 463;
                _heightInput        = 29;
            }
            
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-instituteprovince"))
            {
                _idContent          = this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase();
                _cmd                = "getinstitute";
                _idCombobox         = (_idContent + "-institute");
                _idContainer        = (_idContent + "-institute-combobox");
                _valueProvince      = _param["value"];
                _widthInput         = 463;
                _heightInput        = 29;
            }

            _cmd                        = _cmd;
            _idCombobox                 = _idCombobox;
            _idContainer                = _idContainer;
            _valueParam["id"]           = _idCombobox;
            _valueParam["country"]      = _valueCountry;
            _valueParam["province"]     = _valueProvince;
            _valueDefault               = "0";
            _widthInput                 = _widthInput;
            _heightInput                = _heightInput;

            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () {
                if (_param["id"] == ("#" + _this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institutecountry"))
                {
                    if (_param["id"] == ("#" + _this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institutecountry"))
                        _idContent = _this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase();
                    
                    _this.setSelectDefaultCombobox({
                        id: ("#" + _idContent + "-institute"),
                        value: "0"
                    }, function () { });
                }
            });
        }
    },

    //ฟังก์ชั่นสำหรับกำหนดค่าตามที่ต้องการให้กับ Combobox
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //id                รับค่าชื่อของ Combobox
    //value             รับค่าค่าของ Combobox 
    //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
    setSelectDefaultCombobox: function (_param, _callBackFunc) {
        _param["id"]    = (_param["id"] == undefined ? "" : _param["id"]);
        _param["value"] = (_param["value"] == undefined ? "" : _param["value"]);

        var _cmd;
        var _idCombobox;
        var _idCheckbox;
        var _idContainer;
        var _valueParam = {};
        var _valueDefault;
        var _valueArray;
        var _valueCountry = "";
        var _valueProvince = "";
        var _widthInput;
        var _heightInput;
        var _idContent;

        if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institute"))
        {
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-instituteprovince"))
            {
                _idContent          = this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase();
                _cmd                = "getprovince";
                _idCombobox         = (_idContent + "-instituteprovince");
                _idContainer        = (_idContent + "-instituteprovince-combobox");
                _valueCountry       = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-institutecountry"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-institutecountry"),
                                        valueFalse: "0"
                                      });
                _widthInput         = 463;
                _heightInput        = 29;
            }
            
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institute"))
            {
                _idContent          = this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase();
                _cmd                = "getinstitute";
                _idCombobox         = (_idContent + "-institute");
                _idContainer        = (_idContent + "-institute-combobox");
                _valueProvince      = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-instituteprovince"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-instituteprovince"),
                                        valueFalse: "0"
                                      });
                _widthInput         = 463;
                _heightInput        = 29;
            }

            _cmd                    = _cmd;
            _idCombobox             = _idCombobox;
            _idContainer            = _idContainer;
            _valueParam["id"]       = _idCombobox;
            _valueParam["country"]  = _valueCountry;
            _valueParam["province"] = _valueProvince;
            _valueDefault           = _param["value"];
            _widthInput             = _widthInput;
            _heightInput            = _heightInput;

            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () { _callBackFunc(); });
        }
    },
    /*
    //ฟังก์ชั่นสำหรับเพิ่มหรือแก้ไขข้อมูล โดยส่งไปให้ C# ทำ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _action        รับค่า action ที่ต้องการให้ C# ทำ
    //2. _page          รับค่าชื่อหน้าเพจ
    //3. _valueSend     รับค่าค่าที่ต้องการส่งไปเพิ่มหรือแก้ไขข้อมูล
    //4. _closeFrm      รับค่าว่าต้องการให้ปิดฟอร์มหรือไม่
    //5. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
    actionSave: function (_action, _page, _valueSend, _closeFrm, _callBackFunc) {
        var _send = _valueSend;
        _send["action"] = _action;
        _send["page"] = _page;

        Util.loadAjax(_send, this.urlHandler, "POST", false, "", function (_result) {
            if (_result.SaveError == "0" && _result.KeyUpdateError == "0")
            {
                if (_closeFrm == true) $("#" + Util.dialogForm + "1").dialog("close");
            }

            _callBackFunc(_result);
        });
    }
    */

    //ฟังก์ชั่นสำหรับแสดงสัญลักษณ์สถานะการอนุมัติเอกสารที่นักศึกษาอัพโหลด
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //status    รับค่าสถานะการอนุมัติเอกสาร
    getIconApprovalStatus: function (_param) {
        _param["status"] = (_param["status"] == undefined || _param["status"] == "" ? "S" : _param["status"]);

        var _icon;

        switch (_param["status"].toUpperCase())
        {
            case "S"    : { _icon = "uploaddocument-approvalstatus-s"; break; }
            case "W"    : { _icon = "uploaddocument-approvalstatus-w"; break; }
            case "Y"    : { _icon = "uploaddocument-approvalstatus-y"; break; }
            case "N"    : { _icon = "uploaddocument-approvalstatus-n"; break; }
            default     : { _icon = "uploaddocument-approvalstatus-s"; break; }            
        }

        return _icon;
    },

    //ฟังก์ชั่นสำหรับแสดงเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้า
    //fileDir   รับค่าโฟล์เดอร์ที่เก็บเอกสาร
    //fileName  รับค่าชื่อเอกสาร
    getFrmViewDocument: function (_param) {
        _param["page"]      = (_param["page"] == undefined ? "" : _param["page"]);
        _param["fileDir"]   = (_param["fileDir"] == undefined ? "" : _param["fileDir"]);
        _param["fileName"]  = (_param["fileName"] == undefined ? "" : _param["fileName"]);

        var _width;
        var _height;

        Util.loadForm({
            index: "picture",
            name: _param["page"],
            dialog: true,
            data: (_param["fileDir"] + "/" + _param["fileName"])
        }, function (_result, _e) {
            if (_result.Content.length > 0 && _e != "close")
            {
                _width  = $(".dialogpicture-form .picture-content img").width();
                _height = $(".dialogpicture-form .picture-content img").height();

                $(".dialogpicture-form .picture-content").css({
                    "width": (_width + "px"),
                    "height": (_height + "px")
                });
            }
        });
    },

    //ฟังก์ชั่นสำหรับแสดงไดอะล็อคฟอร์มเมื่อมีการกดลิงค์
    getDialogFormOnClick: function () {
        var _this = this;
        var _page;

        $(".link-" + _this.subjectSectionMeaningOfApprovalStatus.toLowerCase()).click(function () {
              if ($(this).hasClass("link-" + _this.subjectSectionMeaningOfApprovalStatus.toLowerCase()) == true)    _page = _this.pageMeaningOfApprovalStatusMain;

              Util.loadForm({
                  index: 1,
                  name: _page,
                  dialog: true
              }, function () { });
          });
    },
}