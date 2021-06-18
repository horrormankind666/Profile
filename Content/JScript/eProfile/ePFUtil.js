/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๘/๐๙/๒๕๕๖>
Modify date : <๑๗/๐๖/๒๕๖๔>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปของระบบ>
=============================================
*/

var ePFUtil = {
    tsr: null,
    parentWidth: 1008,
    pathProject: "eProfile",
    urlHandler: "../../../Content/Handler/eProfile/ePFHandler.ashx",

    subjectSectionPrivacyPolicy: "PrivacyPolicy",
    subjectSectionManual: "Manual",
    subjectSectionHelpContactUS: "HelpContactUs",
    subjectSectionHelpFillInformationStudentRecords: "HelpFillInformationStudentRecords",
    subjectSectionHelpAllowPopUp: "HelpAllowPopup",
    subjectSectionSCBAccountOpeningForm: "SCBAccountOpeningForm",
    subjectSectionStudentRecords: "StudentRecords",
    subjectSectionStudentRecordsStudentRecords: "StudentRecordsStudentRecords",
    subjectSectionStudentRecordsPersonal: "StudentRecordsPersonal",
    subjectSectionStudentRecordsAddress: "StudentRecordsAddress",
    subjectSectionStudentRecordsAddressPermanent: "StudentRecordsAddressPermanent",
    subjectSectionStudentRecordsAddressCurrent: "StudentRecordsAddressCurrent",
    subjectSectionStudentRecordsEducation: "StudentRecordsEducation",
    subjectSectionStudentRecordsEducationPrimarySchool: "StudentRecordsEducationPrimarySchool",
    subjectSectionStudentRecordsEducationJuniorHighSchool: "StudentRecordsEducationJuniorHighSchool",
    subjectSectionStudentRecordsEducationHighSchool: "StudentRecordsEducationHighSchool",
    subjectSectionStudentRecordsEducationUniversity: "StudentRecordsEducationUniversity",
    subjectSectionStudentRecordsEducationAdmissionScores: "StudentRecordsEducationAdmissionScores",
    subjectSectionStudentRecordsTalent: "StudentRecordsTalent",
    subjectSectionStudentRecordsHealthy: "StudentRecordsHealthy",
    subjectSectionStudentRecordsBodyMassIndex: "StudentRecordsBodyMassIndex",
    subjectSectionStudentRecordsTravelAbroad: "StudentRecordsTravelAbroad",
    subjectSectionStudentRecordsWork: "StudentRecordsWork",
    subjectSectionStudentRecordsFinancial: "StudentRecordsFinancial",
    subjectSectionStudentRecordsFamily: "StudentRecordsFamily",
    subjectSectionStudentRecordsFamilyPersonal: "StudentRecordsFamilyPersonal",
    subjectSectionStudentRecordsFamilyAddressPermanent: "StudentRecordsFamilyAddressPermanent",
    subjectSectionStudentRecordsFamilyAddressCurrent: "StudentRecordsFamilyAddressCurrent",
    subjectSectionStudentRecordsFamilyWork: "StudentRecordsFamilyWork",
    subjectFamilyFather: "Father",
    subjectFamilyMother: "Mother",
    subjectFamilyParent: "Parent",

    idSectionPrivacyPolicyMain: "Main-PrivacyPolicy",
    idSectionPrivacyPolicyTermsConditionMain: "Main-PrivacyPolicyTermsCondition",
    idSectionPrivacyPolicyPrivacyNoticeMain: "Main-PrivacyPolicyPrivacyNotice",
    idSectionPrivacyPolicyConsentMain: "Main-PrivacyPolicyConsent",

    idSectionStudentRecordsMain: "Main-StudentRecords",
    idSectionStudentRecordsAddUpdate: "AddUpdate-StudentRecords",
    idSectionStudentRecordsStudentRecordsAddUpdate: "AddUpdate-StudentRecordsStudentRecords",
    idSectionStudentRecordsPersonalAddUpdate: "AddUpdate-StudentRecordsPersonal",
    idSectionStudentRecordsAddressAddUpdate: "AddUpdate-StudentRecordsAddress",
    idSectionStudentRecordsAddressPermanentAddUpdate: "AddUpdate-StudentRecordsAddressPermanent",
    idSectionStudentRecordsAddressCurrentAddUpdate: "AddUpdate-StudentRecordsAddressCurrent",
    idSectionStudentRecordsEducationAddUpdate: "AddUpdate-StudentRecordsEducation",
    idSectionStudentRecordsEducationPrimarySchoolAddUpdate: "AddUpdate-StudentRecordsEducationPrimarySchool",
    idSectionStudentRecordsEducationJuniorHighSchoolAddUpdate: "AddUpdate-StudentRecordsEducationJuniorHighSchool",
    idSectionStudentRecordsEducationHighSchoolAddUpdate: "AddUpdate-StudentRecordsEducationHighSchool",
    idSectionStudentRecordsEducationUniversityAddUpdate: "AddUpdate-StudentRecordsEducationUniversity",
    idSectionStudentRecordsEducationAdmissionScoresAddUpdate: "AddUpdate-StudentRecordsEducationAdmissionScores",
    idSectionStudentRecordsTalentAddUpdate: "AddUpdate-StudentRecordsTalent",
    idSectionStudentRecordsHealthyAddUpdate: "AddUpdate-StudentRecordsHealthy",
    idSectionStudentRecordsWorkAddUpdate: "AddUpdate-StudentRecordsWork",
    idSectionStudentRecordsFinancialAddUpdate: "AddUpdate-StudentRecordsFinancial",
    idSectionStudentRecordsFamilyAddUpdate: "AddUpdate-StudentRecordsFamily",
    idSectionStudentRecordsFamilyPersonalAddUpdate: "AddUpdate-StudentRecordsFamilyPersonal",
    idSectionStudentRecordsFamilyAddressPermanentAddUpdate: "AddUpdate-StudentRecordsFamilyAddressPermanent",
    idSectionStudentRecordsFamilyAddressCurrentAddUpdate: "AddUpdate-StudentRecordsFamilyAddressCurrent",
    idSectionStudentRecordsFamilyWorkAddUpdate: "AddUpdate-StudentRecordsFamilyWork",
    idSectionStudentRecordsFamilyFatherAddUpdate: "AddUpdate-StudentRecordsFamilyFather",
    idSectionStudentRecordsFamilyFatherPersonalAddUpdate: "AddUpdate-StudentRecordsFamilyFatherPersonal",
    idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate: "AddUpdate-StudentRecordsFamilyFatherAddressPermanent",
    idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate: "AddUpdate-StudentRecordsFamilyFatherAddressCurrent",
    idSectionStudentRecordsFamilyFatherWorkAddUpdate: "AddUpdate-StudentRecordsFamilyFatherWork",
    idSectionStudentRecordsFamilyMotherAddUpdate: "AddUpdate-StudentRecordsFamilyMother",
    idSectionStudentRecordsFamilyMotherPersonalAddUpdate: "AddUpdate-StudentRecordsFamilyMotherPersonal",
    idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate: "AddUpdate-StudentRecordsFamilyMotherAddressPermanent",
    idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate: "AddUpdate-StudentRecordsFamilyMotherAddressCurrent",
    idSectionStudentRecordsFamilyMotherWorkAddUpdate: "AddUpdate-StudentRecordsFamilyMotherWork",
    idSectionStudentRecordsFamilyParentAddUpdate: "AddUpdate-StudentRecordsFamilyParent",
    idSectionStudentRecordsFamilyParentPersonalAddUpdate: "AddUpdate-StudentRecordsFamilyParentPersonal",
    idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate: "AddUpdate-StudentRecordsFamilyParentAddressPermanent",
    idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate: "AddUpdate-StudentRecordsFamilyParentAddressCurrent",
    idSectionStudentRecordsFamilyParentWorkAddUpdate: "AddUpdate-StudentRecordsFamilyParentWork",

    pageMSentMain: "M-SentMain",
    pagePrivacyPolicyMain: "PrivacyPolicyMain",
    pagePrivacyPolicyTermsConditionMain: "PrivacyPolicyTermsConditionMain",
    pagePrivacyPolicyPrivacyNoticeMain: "PrivacyPolicyPrivacyNoticeMain",
    pagePrivacyPolicyConsentMain: "PrivacyPolicyConsentMain",
    pageHelpContactUSMain: "HelpContactUsMain",
    pageHelpFillInformationStudentRecordsMain: "HelpFillInformationStudentRecordsMain",
    pageStudentRecordsStudentCVMain: "StudentRecordsStudentCVMain",
    pageStudentRecordsMain: "StudentRecordsMain",
    pageStudentRecordsAddUpdate: "StudentRecordsAddUpdate",
    pageStudentRecordsStudentRecordsAddUpdate: "StudentRecordsStudentRecordsAddUpdate",
    pageStudentRecordsPersonalAddUpdate: "StudentRecordsPersonalAddUpdate",
    pageStudentRecordsAddressAddUpdate: "StudentRecordsAddressAddUpdate",
    pageStudentRecordsAddressPermanentAddUpdate: "StudentRecordsAddressPermanentAddUpdate",
    pageStudentRecordsAddressCurrentAddUpdate: "StudentRecordsAddressCurrentAddUpdate",
    pageStudentRecordsEducationAddUpdate: "StudentRecordsEducationAddUpdate",
    pageStudentRecordsEducationPrimarySchoolAddUpdate: "StudentRecordsEducationPrimarySchoolAddUpdate",
    pageStudentRecordsEducationJuniorHighSchoolAddUpdate: "StudentRecordsEducationJuniorHighSchoolAddUpdate",
    pageStudentRecordsEducationHighSchoolAddUpdate: "StudentRecordsEducationHighSchoolAddUpdate",
    pageStudentRecordsEducationUniversityAddUpdate: "StudentRecordsEducationUniversityAddUpdate",
    pageStudentRecordsEducationAdmissionScoresAddUpdate: "StudentRecordsEducationAdmissionScoresAddUpdate",
    pageStudentRecordsTalentAddUpdate: "StudentRecordsTalentAddUpdate",
    pageStudentRecordsHealthyAddUpdate: "StudentRecordsHealthyAddUpdate",
    pageStudentRecordsWorkAddUpdate: "StudentRecordsWorkAddUpdate",
    pageStudentRecordsFinancialAddUpdate: "StudentRecordsFinancialAddUpdate",
    pageStudentRecordsFamilyAddUpdate: "StudentRecordsFamilyAddUpdate",
    pageStudentRecordsFamilyFatherAddUpdate: "StudentRecordsFamilyFatherAddUpdate",
    pageStudentRecordsFamilyFatherPersonalAddUpdate: "StudentRecordsFamilyFatherPersonalAddUpdate",
    pageStudentRecordsFamilyFatherAddressPermanentAddUpdate: "StudentRecordsFamilyFatherAddressPermanentAddUpdate",
    pageStudentRecordsFamilyFatherAddressCurrentAddUpdate: "StudentRecordsFamilyFatherAddressCurrentAddUpdate",
    pageStudentRecordsFamilyFatherWorkAddUpdate: "StudentRecordsFamilyFatherWorkAddUpdate",
    pageStudentRecordsFamilyMotherAddUpdate: "StudentRecordsFamilyMotherAddUpdate",
    pageStudentRecordsFamilyMotherPersonalAddUpdate: "StudentRecordsFamilyMotherPersonalAddUpdate",
    pageStudentRecordsFamilyMotherAddressPermanentAddUpdate: "StudentRecordsFamilyMotherAddressPermanentAddUpdate",
    pageStudentRecordsFamilyMotherAddressCurrentAddUpdate: "StudentRecordsFamilyMotherAddressCurrentAddUpdate",
    pageStudentRecordsFamilyMotherWorkAddUpdate: "StudentRecordsFamilyMotherWorkAddUpdate",
    pageStudentRecordsFamilyParentAddUpdate: "StudentRecordsFamilyParentAddUpdate",
    pageStudentRecordsFamilyParentPersonalAddUpdate: "StudentRecordsFamilyParentPersonalAddUpdate",
    pageStudentRecordsFamilyParentAddressPermanentAddUpdate: "StudentRecordsFamilyParentAddressPermanentAddUpdate",
    pageStudentRecordsFamilyParentAddressCurrentAddUpdate: "StudentRecordsFamilyParentAddressCurrentAddUpdate",
    pageStudentRecordsFamilyParentWorkAddUpdate: "StudentRecordsFamilyParentWorkAddUpdate",

    initMenuBar: function () {
        var _this = this;

        $(function () {
            $(".menubar .link-click").click(function () {
                var _idLink = $(this).attr("id");
                
                Util.dialogMessageClose();

                if (_idLink == ("link-" + _this.subjectSectionPrivacyPolicy.toLowerCase())) {
                    $("#page").html(_this.pagePrivacyPolicyMain);
                    Util.getPage();
                }

                if (_idLink == ("link-" + _this.subjectSectionManual.toLowerCase()))
                    Util.gotoPage({ page: ("ePFDownloadFile.aspx?f=" + _this.subjectSectionManual), target: "frame-util" });

                if (_idLink == ("link-" + _this.subjectSectionHelpFillInformationStudentRecords.toLowerCase()))
                    Util.loadForm({ index: 1, name: _this.pageHelpFillInformationStudentRecordsMain, dialog: true }, function () { });

                if (_idLink == ("link-" + _this.subjectSectionHelpContactUS.toLowerCase()))
                    Util.loadForm({ index: 1, name: _this.pageHelpContactUSMain, dialog: true }, function () { });

                if (_idLink == ("link-" + _this.subjectSectionHelpAllowPopUp.toLowerCase()))
                    Util.gotoPage({ page: ("ePFDownloadFile.aspx?f=" + _this.subjectSectionHelpAllowPopUp), target: "frame-util" });

                if (_idLink == "link-signout") Util.confirmeSignOut();
            });
        });
    },
    initInfoBar: function () {
        var _this = this;
        var _page;

        $(function () {
            $(".infobar .link-click").click(function () {
                var _idLink = $(this).attr("id");

                Util.dialogMessageClose();
                
                if ($("#page").html() == _this.pageStudentRecordsAddUpdate)
                    _page = Util.getPageActive({
                        id: (_this.idSectionStudentRecordsAddUpdate.toLowerCase() + "-content")
                    });

                if (_idLink == ("home-" + _this.pagePrivacyPolicyMain.toLowerCase())) {
                    $("#page").html(_this.pageStudentRecordsAddUpdate);
                    Util.getPage();
                }

                if (_idLink == ("profile-" + _this.pagePrivacyPolicyMain.toLowerCase()))
                    Util.gotoPage({ page: ("index.aspx?p=" + _this.pageStudentRecordsStudentCVMain), target: "_blank" });

                if (_idLink == ("profile-" + _this.pageStudentRecordsMain.toLowerCase()))
                    Util.gotoPage({ page: ("index.aspx?p=" + _this.pageStudentRecordsStudentCVMain), target: "_blank" });

                if (_idLink == ("home-" + _this.pageStudentRecordsAddUpdate.toLowerCase()))
                    Util.getPage();

                if (_idLink == ("save-" + _this.pageStudentRecordsAddUpdate.toLowerCase()))
                    Util.tut.tsr.sectionAddUpdate.confirmSave({ page: _page, option: "self" });

                if (_idLink == ("saveall-" + _this.pageStudentRecordsAddUpdate.toLowerCase()))
                    Util.tut.tsr.sectionAddUpdate.confirmSave({ page: _page, option: "all" });

                if (_idLink == ("undo-" + _this.pageStudentRecordsAddUpdate.toLowerCase()))
                    Util.tut.tsr.sectionAddUpdate.resetMainSection({ page: _page });

                if (_idLink == ("profile-" + _this.pageStudentRecordsAddUpdate.toLowerCase()))
                    Util.gotoPage({ page: ("index.aspx?p=" + _this.pageStudentRecordsStudentCVMain), target: "_blank" });

                if (_idLink == ("linkto-" + _this.pageStudentRecordsMain.toLowerCase()) ||
                    _idLink == ("linkto-" + _this.pageStudentRecordsAddUpdate.toLowerCase()))
                    Util.setLinkToShow();

                if (_idLink == "linkto-healthcareservice" || _idLink == "linkto-uploaddocument") {
                    var _w;

                    if (Util.tut.tsr.sectionAddUpdate.chkStudentRecordsFillComplete()) {
                        if (_idLink == "linkto-healthcareservice")
                            _w = Util.gotoPage({ page: "https://smartedu.mahidol.ac.th/eProfileApp/Module/Operation/HealthCareService/index.aspx", target: "_blank" });

                        if (_idLink == "linkto-uploaddocument")
                            _w = Util.gotoPage({ page: "../UploadDocument/index.aspx", target: "_blank" });
                    }
                }

                if (_idLink == "linkto-downloadscbaccountopeningform")
                    Util.gotoPage({ page: ("ePFDownloadFile.aspx?f=" + _this.subjectSectionSCBAccountOpeningForm), target: "frame-util" });
            });
        });
    },
    getErrorMsg: function (_param) {
        _param["signinYN"] = (_param["signinYN"] == undefined || _param["signinYN"] == "" ? "N" : _param["signinYN"]);
        _param["pageError"] = (_param["pageError"] == undefined || _param["pageError"] == "" ? 0 : _param["pageError"]);
        _param["cookieError"] = (_param["cookieError"] == undefined || _param["cookieError"] == "" ? 0 : _param["cookieError"]);
        _param["userError"] = (_param["userError"] == undefined || _param["userError"] == "" ? 0 : _param["userError"]);
        _param["saveError"] = (_param["saveError"] == undefined || _param["saveError"] == "" ? 0 : _param["saveError"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _status = (_param["signinYN"] + _param["cookieError"] + _param["userError"] + _param["saveError"]);

        if (_error == false && _param["pageError"] == 1) {
            _error = true;
            _msgTH = "ไม่พบหน้านี้";
            _msgEN = "Page not found.";
        }

        if (_error == false && _param["pageError"] == 2) {
            _error = true;
            _msgTH = "ไม่พบข้อมูล";
            _msgEN = "Data not found.";
        }

        if (_error == false && _status == "Y100") {
            _error = true;
            _msgTH = "กรุณาเข้าระบบนักศึกษา";
            _msgEN = "Please sign in student portal.";
        }

        if (_error == false && _status == "Y010") {
            _error = true;
            _msgTH = "ไม่พบนักศึกษา";
            _msgEN = "Student not found.";
        }

        if (_error == false && _status == "Y020") {
            _error = true;
            _msgTH = "ระบบยังไม่เปิดทำการ";
            _msgEN = "The system is not open.";
        }

        if (_error == false && _status == "Y030") {
            _error = true;
            _msgTH = "ระบบปิดทำการ";
            _msgEN = "Close system.";
        }

        if (_error == false && _status == "Y040") {
            _error = true;
            _msgTH = "นักศึกษาไม่มีสิทธิ์เข้าใช้ระบบ";
            _msgEN = "No permission students.";
        }

        if (_error == false && _status == "Y001") {
            _error = true;
            _msgTH = "บันทึกข้อมูลไม่สำเร็จ";
            _msgEN = "Save was not successful.";
        }

        if (_error == false && _status == "N010") {
            _error = true;
            _msgTH = "กรุณาออกจากระบบระเบียนประวัตินักศึกษา";
            _msgEN = "Please sign out student records.";
        }

        if (_error == false && _status == "N110") {
            _error = true;
            _msgTH = "ไม่พบนักศึกษา";
            _msgEN = "Students not found.";
        }

        if (_error == true && _msgTH.length > 0 && _msgEN.length > 0)
            Util.dialogMessageError({
                content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
            });

        return _error;
    },
    loadPage: function (_callBackFunc) {
        var _this = this;
        var _error;
        var _page = ($("#page").html().length > 0 ? $("#page").html() : this.pageStudentRecordsAddUpdate);
        var _send = {};
        _send["action"] = "page";
        _send["page"] = _page;
        
        Util.msgPreloading = "Loading...";
        
        Util.loadAjax({
            url: this.urlHandler,
            method: "POST",
            data: _send,
            showPreloadingInline: false
        }, function (_result) {
            Util.clearPage();

            _page = _result.Page;
            $("#page").html(_result.Page);
            $("#menubar-content").html(_result.MenuBarContent);

            if (_page == _this.pageStudentRecordsStudentCVMain)
                $("#bodymain #mainbody .sticky").html("");

            $("#contentbody-content").html(_result.MainContent).show();

            Util.setMenuBarLayout();
            Util.setInfoBarLayout();
            Util.setStickyTop(0);
            Util.setFooterLayout();

            if (_page == _this.pageStudentRecordsMain)
                Util.tut.tsr.sectionMain.initMain();

            if (_page == _this.pagePrivacyPolicyMain)
                privacyPolicy.init();

            _error = _this.getErrorMsg({
                signinYN: _result.SignInYN,
                pageError: _result.PageError,
                cookieError: _result.CookieError,
                userError: _result.UserError
            });

            if (_error == false) {
                if (_page == _this.pageStudentRecordsAddUpdate)
                    Util.tut.tsr.sectionAddUpdate.initMain();
            }

            _this.initMenuBar();
            _this.initInfoBar();

            Util.initTable();
            Util.initTextSelect();
            Util.gotoTopElement();

            _callBackFunc();
        });
    },  
    setSelectCombobox: function (_param) {
        _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);
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
        var _valueDistrict = "";
        var _valuePostalCode = "";
        var _valueDegreeLevel = "";
        var _valueFaculty = "";
        var _valueProgram = "";
        var _valueFamilyRelation = "";
        var _valueGender = "";
        var _valueAction = "";
        var _widthInput;
        var _heightInput;
        var _idContent;
        var _page;
        var _familyRelation;

        if (_param["id"] == ("#" + this.idSectionStudentRecordsPersonalAddUpdate.toLowerCase() + "-titleprefix")) {
            _idContent = this.idSectionStudentRecordsPersonalAddUpdate.toLowerCase();

            Util.tut.tsr.sectionAddUpdate.setGenderByTitlePrefix({
                idTitlePrefix: ("#" + _idContent + "-titleprefix"),
                idGender: (_idContent + "-gender")
            });
        }

        if (_param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsEducationHighSchoolAddUpdate.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-relationship") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district")) {
            if (_param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-country")) {
                _idContent = _param["id"].replace("#", "").replace("-country", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = _param["value"];
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province")) {
                _idContent = _param["id"].replace("#", "").replace("-province", "");
                _cmd = "getdistrict";
                _idCombobox = (_idContent + "-district");
                _idContainer = (_idContent + "-district-combobox");
                _valueProvince = _param["value"];
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district")) {
                _idContent = _param["id"].replace("#", "").replace("-district", "");
                _cmd = "getsubdistrict";
                _idCombobox = (_idContent + "-subdistrict");
                _idContainer = (_idContent + "-subdistrict-combobox");
                _valueDistrict = _param["value"];
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase() + "-institutecountry") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase() + "-institutecountry") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsEducationHighSchoolAddUpdate.toLowerCase() + "-institutecountry")) {
                _idContent = _param["id"].replace("#", "").replace("-institutecountry", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-instituteprovince");
                _idContainer = (_idContent + "-instituteprovince-combobox");
                _valueCountry = _param["value"];
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-relationship")) {
                if (_param["value"].length > 0) {
                    _valueArray = _param["value"].split(";");

                    if (_valueArray.length == 4) {
                        _valueFamilyRelation = _valueArray[1];
                        _valueGender = _valueArray[3];
                    }

                    _idContent = _param["id"].replace("#", "").replace("-relationship", "");
                    _cmd = "gettitleprefix";
                    _idCombobox = (_idContent + "-titleprefix");
                    _idContainer = (_idContent + "-titleprefix-combobox");
                    _valueGender = _valueGender;
                    _widthInput = 426;
                    _heightInput = 29;
                }
            }

            if (_valueDistrict.length > 0 && _valueDistrict != "0") {
                _valueArray = _valueDistrict.split(";");

                if (_valueArray.length == 2) {
                    _valueDistrict = _valueArray[0];
                    _valuePostalCode = _valueArray[1];
                }
            }

            _cmd = _cmd;
            _idCombobox = _idCombobox;
            _idContainer = _idContainer;
            _valueParam["id"] = _idCombobox;
            _valueParam["country"] = _valueCountry;
            _valueParam["province"] = _valueProvince;
            _valueParam["district"] = _valueDistrict;
            _valueParam["degreelevel"] = _valueDegreeLevel;
            _valueParam["faculty"] = _valueFaculty;
            _valueParam["gender"] = _valueGender;
            _valueDefault = "0";
            _widthInput = _widthInput;
            _heightInput = _heightInput;

            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () {
                if (_param["id"] == ("#" + _this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-country")) {
                    _this.setSelectDefaultCombobox({
                        id: ("#" + _idContent + "-district"),
                        value: "0"
                    }, function () {
                        if (_param["id"] == ("#" + _this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-country")) {
                            _this.setSelectDefaultCombobox({
                                id: ("#" + _idContent + "-subdistrict"),
                                value: "0"
                            }, function () {
                            });
                            $("#" + (_idContent + "-postalcode")).val("");
                        }
                    });
                }

                if (_param["id"] == ("#" + _this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province")) {
                    _this.setSelectDefaultCombobox({
                        id: ("#" + _idContent + "-subdistrict"),
                        value: "0"
                    }, function () {
                    });
                    $("#" + (_idContent + "-postalcode")).val("");
                }

                if (_param["id"] == ("#" + _this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district"))
                    $("#" + (_idContent + "-postalcode")).val(_valuePostalCode);

                if (_param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-relationship")) {
                    Util.tut.tsr.sectionAddUpdate.setGenderByTitlePrefix({
                        idTitlePrefix: ("#" + _idCombobox),
                        idGender: (_idContent + "-gender"),
                        valueGender: _valueGender
                    });
                    Util.tut.tsr.sectionAddUpdate.family.setParentOnRelationship({
                        page: _this.pageStudentRecordsFamilyParentPersonalAddUpdate,
                        this: Util.tut.tsr.sectionAddUpdate.family.personal
                    });
                }
            });
        }

        if (_param["id"] == ("#" + this.idSectionStudentRecordsWorkAddUpdate.toLowerCase() + "-agency") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherWorkAddUpdate.toLowerCase() + "-agency") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherWorkAddUpdate.toLowerCase() + "-agency") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentWorkAddUpdate.toLowerCase() + "-agency")) {
            _idContent = _param["id"].replace("#", "").replace("-agency", "")
            _idRadiobox = (_idContent + "-agencyother");
            _idTextbox = (_idContent + "-agencyotherdetail");

            $("input[name=" + _idRadiobox + "]").iCheck("uncheck");
            $("#" + _idTextbox).val("");
            Util.textboxDisable("#" + _idTextbox);
        }
    },
    setSelectDefaultCombobox: function (_param, _callBackFunc) {
        _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);
        _param["value"] = (_param["value"] == undefined ? "" : _param["value"]);

        var _this = this;
        var _cmd;
        var _idCombobox;
        var _idCheckbox;
        var _idContainer;
        var _valueParam = {};
        var _valueDefault;
        var _valueArray;
        var _valueCountry = "";
        var _valueProvince = "";
        var _valueDistrict = "";
        var _valueDegreeLevel = "";
        var _valueFaculty = "";
        var _valueFamilyRelation = "";
        var _valueGender = "";
        var _widthInput;
        var _heightInput;
        var _idContent;
        var _familyRelation;

        if (_param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsEducationHighSchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-titleprefix") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-subdistrict")) {
            if (_param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province")) {
                _idContent = _param["id"].replace("#", "").replace("-province", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-country"),
                    valueFalse: "0"
                });
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district")) {
                _idContent = _param["id"].replace("#", "").replace("-district", "");
                _cmd = "getdistrict";
                _idCombobox = (_idContent + "-district");
                _idContainer = (_idContent + "-district-combobox");
                _valueProvince = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-province"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-province"),
                    valueFalse: "0"
                });
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-subdistrict")) {
                _idContent = _param["id"].replace("#", "").replace("-subdistrict", "");
                _cmd = "getsubdistrict";
                _idCombobox = (_idContent + "-subdistrict");
                _idContainer = (_idContent + "-subdistrict-combobox");
                _valueDistrict = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-district"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-district"),
                    valueFalse: "0"
                });
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
                _param["id"] == ("#" + this.idSectionStudentRecordsEducationHighSchoolAddUpdate.toLowerCase() + "-instituteprovince")) {
                _idContent = _param["id"].replace("#", "").replace("-instituteprovince", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-instituteprovince");
                _idContainer = (_idContent + "-instituteprovince-combobox");
                _valueCountry = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-institutecountry"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-institutecountry"),
                    valueFalse: "0"
                });
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-titleprefix")) {
                _idContent = _param["id"].replace("#", "").replace("-titleprefix", "");
                _valueFamilyRelation = Util.comboboxGetValue("#" + _idContent + "-relationship");

                if (_valueFamilyRelation != "0") {
                    _valueArray = _valueFamilyRelation.split(";");

                    if (_valueArray.length == 4)
                        _valueGender = _valueArray[3];
                }

                _cmd = "gettitleprefix";
                _idCombobox = (_idContent + "-titleprefix");
                _idContainer = (_idContent + "-titleprefix-combobox");
                _valueGender = _valueGender;
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_valueDistrict.length > 0 && _valueDistrict != "0") {
                _valueArray = _valueDistrict.split(";");

                if (_valueArray.length == 2)
                    _valueDistrict = _valueArray[0];
            }

            _cmd = _cmd;
            _idCombobox = _idCombobox;
            _idContainer = _idContainer;
            _valueParam["id"] = _idCombobox;
            _valueParam["country"] = _valueCountry;
            _valueParam["province"] = _valueProvince;
            _valueParam["district"] = _valueDistrict;
            _valueParam["degreelevel"] = _valueDegreeLevel;
            _valueParam["faculty"] = _valueFaculty;
            _valueParam["gender"] = _valueGender;
            _valueDefault = _param["value"];
            _widthInput = _widthInput;
            _heightInput = _heightInput;

            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () {
                if (_param["id"] == ("#" + _this.idSectionStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-titleprefix"))
                    Util.tut.tsr.sectionAddUpdate.setGenderByTitlePrefix({
                        idTitlePrefix: ("#" + _idCombobox),
                        idGender: (_idContent + "-gender"),
                        valueGender: _valueGender
                    });

                _callBackFunc();
            });
        }
    },
    getMSent: function (callBackFunc) {
        var that = this;
        var isError = false;

        $.ajax({
            beforeSend: function () {
                Util.dialogMessagePreloading();
            },
            async: true,
            type: "GET",
            url: that.urlHandler,
            data: {
                action: "page",
                page: that.pageMSentMain
            },
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                isError = that.getErrorMsg({
                    signinYN: result.SignInYN,
                    pageError: result.PageError,
                    cookieError: result.CookieError,
                    userError: result.UserError
                });

                var cuid = "";
                var userCode = "";

                if (result.CUID.length > 0) {
                    cuid = window.atob(result.CUID).split(".");
                    userCode = (cuid.length == 3 ? cuid[2] : "");
                    userCode = (userCode.length > 20 ? userCode.substring(0, 20) : userCode);
                }

                if (isError == false) {
                    MSent.getIsConsent(userCode, function () {
                        if (MSent.isConsent) {
                            var consentField = [];

                            if (MSent.consentField.religion.isConsent)
                                consentField.push(MSent.consentField.religion.name);

                            Util.actionSave({
                                action: "save",
                                page: that.pageMSentMain,
                                data: {
                                    signinyn: "Y",
                                    consentField: (consentField.length > 0 ? consentField.join(",") : "")
                                }
                            }, function () {
                                callBackFunc(isError);
                            });
                        }
                        else
                            callBackFunc(isError);
                    });
                }
                else
                    callBackFunc(isError);
            }
        });
    }
};

var privacyPolicy = {
    idSectionMain: ePFUtil.idSectionPrivacyPolicyMain.toLowerCase(),
    init: function () {
        this.setMenuLayout();
        this.initMenu();
        this.initSwitchLang();
        this.getContent("termsAndCond", ePFUtil.idSectionPrivacyPolicyTermsConditionMain.toLowerCase(), ePFUtil.pagePrivacyPolicyTermsConditionMain);
    },
    setMenuLayout: function () {
        if ($("#" + this.idSectionMain + "-menu").length > 0) {
            $("#" + this.idSectionMain + "-menu").css("top", Util.offsetTop);
            $("#" + this.idSectionMain + "-menu").height($(window).height() - Util.offsetTop);
        }
    },
    initMenu: function () {
        var that = this;
        
        Util.initTab({
            id: ("#" + this.idSectionMain + "-menu-content"),
            idContent: ("#" + this.idSectionMain + "-content"),
            classActive: "menu-active",
            classNoActive: "menu-noactive"
        }, function (result) {
            var idLink = result;
            var page = $("#" + idLink).attr("alt");
            var route;

            if (page == ePFUtil.pagePrivacyPolicyTermsConditionMain)
                route = "termsAndCond";

            if (page == ePFUtil.pagePrivacyPolicyPrivacyNoticeMain)
                route = "privacyPolicy";

            if (page == ePFUtil.pagePrivacyPolicyConsentMain)
                route = "consent";

            if ($("#" + idLink).html().length == 0)
                that.getContent(route, idLink, page);
        });
    },
    initSwitchLang: function () {    
        var that = this;

        $(function () {
            $("#" + that.idSectionMain + "-content .switch-lang .link-click").click(function () {
                var idLink = $(this).attr("id");
                var lang = $(this).attr("alt");

                $("#" + that.idSectionMain + "-content .switch-lang .link-click").removeClass("active");
                $("#" + idLink).addClass("active");

                $("#" + that.idSectionMain + "-content .content-th").addClass("hidden");
                $("#" + that.idSectionMain + "-content .content-en").addClass("hidden");
                $("#" + that.idSectionMain + "-content .content-" + lang.toLowerCase()).removeClass("hidden");
            });
        });
    },
    getContent: function (route, idLink, page) {
        var that = this;

        Util.msgPreloading = "Loading...";
        $("#" + this.idSectionMain + "-content .switch-lang").addClass("hidden");


        MSent.getAccepted(route, function (data) {
            $("#" + Util.dialogPreloading).dialog("close");
            $("#" + that.idSectionMain + "-content .switch-lang").removeClass("hidden");

            var html = "";
            var langActive = $("#" + that.idSectionMain + "-content .switch-lang .link-click.active").attr("alt");

            if (data != null) {
                if (page == ePFUtil.pagePrivacyPolicyTermsConditionMain ||
                    page == ePFUtil.pagePrivacyPolicyPrivacyNoticeMain) {
                    html = (
                        "<div class='content-th th-label hidden'>" +
                        "   <div class='header'>" + data.nameTh + "</div>" +
                        "   <div class='body'>" + data.descTh + "</div>" +
                        "   <div class='footer'>" + 
                        "       <div class='checkbox-content'>" +
                        "           <ul>" +
                        "               <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='accept'" + (data.acceptFlag == "Y" ? " checked" : "") + " disabled /></li>" +
                        "               <li class='checkbox-labelcol'><div>" + data.acceptMessageTh + "</div></li>" +
                        "           </ul>" +
                        "       </div>" +
                        "       <div class='clear'></div>" +
                        "   </div>" +
                        "</div>" +
                        "<div class='content-en th-label hidden'>" +
                        "   <div class='header'>" + data.nameEn + "</div>" +
                        "   <div class='body'>" + data.descEn + "</div>" +
                        "   <div class='footer'>" +
                        "       <div class='checkbox-content'>" +
                        "           <ul>" +
                        "               <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='accept'" + (data.acceptFlag == "Y" ? " checked" : "") + " disabled /></li>" +
                        "               <li class='checkbox-labelcol'><div>" + data.acceptMessageEn + "</div></li>" +
                        "           </ul>" +
                        "       </div>" +
                        "       <div class='clear'></div>" +
                        "       </div>" +
                        "</div>"
                    );
                }

                if (page == ePFUtil.pagePrivacyPolicyConsentMain) {
                    var consentTopicTH = "";
                    var consentTopicEN = "";

                    for (var i = 0; i < data.consentTopics.length; i++) {
                        var consentChoiceTH = "";
                        var consentChoiceEN = "";

                        for (var j = 0; j < data.consentTopics[i].consentChoices.length; j++) {
                            consentChoiceTH += (
                                "<div class='choice'>" +
                                "   <div class='checkbox-content'>" +
                                "       <ul>" +
                                "           <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='accept'" + (data.consentChoiceIds.indexOf(data.consentTopics[i].consentChoices[j].id) >= 0 ? " checked" : "") + " disabled /></li>" +
                                "           <li class='checkbox-labelcol'><div>" + data.consentTopics[i].consentChoices[j].choiceTh + "</div></li>" +
                                "       </ul>" +
                                "   </div>" +
                                "   <div class='clear'></div>" +
                                "</div>"
                            );

                            consentChoiceEN += (
                                "<div class='choice'>" +
                                "   <div class='checkbox-content'>" +
                                "       <ul>" +
                                "           <li class='checkbox-inputcol'><input class='checkbox' type='checkbox' name='accept'" + (data.consentChoiceIds.indexOf(data.consentTopics[i].consentChoices[j].id) >= 0 ? " checked" : "") + " disabled /></li>" +
                                "           <li class='checkbox-labelcol'><div>" + data.consentTopics[i].consentChoices[j].choiceEn + "</div></li>" +
                                "       </ul>" +
                                "   </div>" +
                                "   <div class='clear'></div>" +
                                "</div>"
                            );
                        }

                        consentTopicTH += (
                            "<div class='consent-topics'>" +
                            "   <div class='topic'>" + data.consentTopics[i].topicTh + "</div>" +
                            "   <div class='choices'>" + consentChoiceTH + "</div>" +
                            "</div>"
                        );

                        consentTopicEN += (
                            "<div class='consent-topics'>" +
                            "   <div class='topic'>" + data.consentTopics[i].topicEn + "</div>" +
                            "   <div class='choices'>" + consentChoiceEN + "</div>" +
                            "</div>"
                        )
                    }

                    html = (
                        "<div class='content-th th-label hidden'>" +
                        "   <div class='header'>" + data.nameTh + "</div>" +
                        "   <div class='body'><p>" + consentTopicTH + "</p></div>" +
                        "   <div class='footer'><p><a class='link-click' id='link-updateconsent' href='" + MSent.getPage.consent() + "'>แก้ไขความยินยอม</a></p></div>" + 
                        "</div>" +
                        "<div class='content-en th-label hidden'>" +
                        "   <div class='header'>" + data.nameEn + "</div>" +
                        "   <div class='body'><p>" + consentTopicEN + "</p></div>" +
                        "   <div class='footer'><p><a class='link-click' id='link-updateconsent' href='" + MSent.getPage.consent() + "'>Update Consent</a></p></div>" +
                        "</div>"
                    );
                }
            }

            $("#" + idLink).html(html);
                Util.initCheck({
                id: ("accept")
            });
            $("#" + idLink + " .content-" + langActive.toLowerCase()).removeClass("hidden");
        });
    }
}