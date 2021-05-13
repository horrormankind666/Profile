/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๕/๑๐/๒๕๕๘>
Modify date : <๐๕/๐๓/๒๕๖๔>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการแสดงความคืบหน้าการประมวลผลข้อมูล>
=============================================
*/

var ePFStaffProgressData = {
    getProgress: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["pageProgress"] = (_param["pageProgress"] == undefined ? "" : _param["pageProgress"]);
        _param["pagePreview"] = (_param["pagePreview"] == undefined ? "" : _param["pagePreview"]);
        _param["thisProgress"] = (_param["thisProgress"] == undefined || _param["thisProgress"] == "" ? null : _param["thisProgress"]);
        _param["thisPreview"] = (_param["thisPreview"] == undefined || _param["thisPreview"] == "" ? null : _param["thisPreview"]);
        _param["idMain"] = (_param["idMain"] == undefined ? "" : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? "" : _param["idProgress"]);
        _param["idPreview"] = (_param["idPreview"] == undefined ? "" : _param["idPreview"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _this = this;

        if (_this.validateProgress({
            page: _param["pageProgress"],
            idMain: _param["idMain"],
            option: _param["option"]
        })) {
            Util.loadForm({
                index: 1,
                name: _param["pageProgress"],
                dialog: true
            }, function (_result, _e) {
                if (_result.Content.length > 0 && _e != "close") {
                    _this.initProgress({
                        action: _param["action"],
                        pageProgress: _param["pageProgress"],
                        pagePreview: _param["pagePreview"],
                        thisProgress: _param["thisProgress"],
                        thisPreview: _param["thisPreview"],
                        idMain: _param["idMain"],
                        idProgress: _param["idProgress"],
                        idPreview: _param["idPreview"],
                        option: _param["option"]
                    });                    
                    _this.initProcess({
                        action: _param["action"],
                        page: _param["pageProgress"],
                        this: _param["thisProgress"],
                        idMain: _param["idMain"],
                        idProgress: _param["idProgress"],
                        option: _param["option"]
                    });
                }
            });
        }
    },
    validateProgress: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _idTable = (_param["idMain"] + "-table");
        var _objCheck = $("#" + _idTable + " input[name=select-child]:checked");

        if (_error == false && _param["page"].length == "0") {
            _error = true;
            _msgTH = "กรุณาเลือกรายการปรับปรุงข้อมูล";
            _msgEN = "Please select a update option.";
        }

        if (_error == false && _param["option"] == "selected" && _objCheck.length == 0) {
            _error = true;
            _msgTH = "กรุณาเลือกข้อมูล";
            _msgEN = "Please select a data from the list.";
        }

        if (_error == false && _param["option"] == "all" && $("#" + _idTable + " .table-recordcount .recordcount-search").html() == 0) {
            _error = true;
            _msgTH = "ไม่พบข้อมูล";
            _msgEN = "Data not found.";
        }
        
        if (_error == true) {
            Util.dialogMessageError({
                content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
            });

            return false;
        }
        
        return true;
    },
    initProgress: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["pageProgress"] = (_param["pageProgress"] == undefined ? "" : _param["pageProgress"]);
        _param["pagePreview"] = (_param["pagePreview"] == undefined ? "" : _param["pagePreview"]);
        _param["thisProgress"] = (_param["thisProgress"] == undefined || _param["thisProgress"] == "" ? null : _param["thisProgress"]);
        _param["thisPreview"] = (_param["thisPreview"] == undefined || _param["thisPreview"] == "" ? null : _param["thisPreview"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["idPreview"] = (_param["idPreview"] == undefined ? null : _param["idPreview"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _this = this;

        $("#" + Util.dialogForm + "1").dialog("option", "position", { my: "center", at: "center", of: window });
        
        _param["thisProgress"].initMain();

        $("#" + _param["idProgress"] + "-form .button .click-button").click(function () {
            if ($(this).hasClass("button-save") == true) {
                if (_param["thisProgress"].validateProcess())
                    _this.getFrmPreviewProgress({
                        action: _param["action"],
                        pageProgress: _param["pageProgress"],
                        pagePreview: _param["pagePreview"],
                        thisProgress: _param["thisProgress"],
                        thisPreview: _param["thisPreview"],
                        idMain: _param["idMain"],
                        idProgress: _param["idProgress"],
                        idPreview: _param["idPreview"],
                        option: _param["option"]
                    });
            }

            if ($(this).hasClass("button-undo") == true)
                _param["thisProgress"].resetMain();
        });

        this.resetProgress({
            action: _param["action"],
            page: _param["pageProgress"],
            this: _param["thisProgress"],
            idMain: _param["idMain"],
            idProgress: _param["idProgress"],
            option: _param["option"]
        });
    },
    resetProgress: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);
                          
        var _idTable = (_param["idMain"] + "-table");
        var _recordCount = ($("#" + _idTable + " .recordcount-search").length > 0 ? $("#" + _idTable + " .recordcount-search").html() : "");
        var _objCheck = $("#" + _idTable + " input[name=select-child]:checked");                        
        var _dataCount;
            
        Util.dialogMessageClose();

        if (_param["option"] == "selected")
            _dataCount = _objCheck.length;

        if (_param["option"] == "all")
            _dataCount = (_recordCount.length > 0 && _recordCount != "0" ? _recordCount : "0");           

        Util.resetForm({
            id: (_param["idProgress"] + "-form")
        });

        $("#" + _param["idProgress"] + "-total").html(_dataCount);
        $("#" + _param["idProgress"] + "-totalcomplete-content .progresstotal span").html("");
        $("#" + _param["idProgress"] + "-totalincomplete-content .progresstotal span").html("");

        _param["this"].resetMain();
    },
    getFrmPreviewProgress: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["pageProgress"] = (_param["pageProgress"] == undefined ? "" : _param["pageProgress"]);
        _param["pagePreview"] = (_param["pagePreview"] == undefined ? "" : _param["pagePreview"]);
        _param["thisProgress"] = (_param["thisProgress"] == undefined || _param["thisProgress"] == "" ? null : _param["thisProgress"]);
        _param["thisPreview"] = (_param["thisPreview"] == undefined || _param["thisPreview"] == "" ? null : _param["thisPreview"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["idPreview"] = (_param["idPreview"] == undefined ? null : _param["idPreview"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _this = this;
        var _valueProcess = {};

        _valueProcess = this.getValueProcess({
            this: _param["thisProgress"],
            idMain: _param["idMain"],
            option: _param["option"]
        });

        Util.loadForm({
            index: 2,
            name: _param["pagePreview"],
            dialog: true
        }, function (_result, _e) {            
            if (_result.Content.length > 0 && _e != "close") {
                Util.setTableLayoutOnDialogForm({
                    idForm: (_param["idPreview"] + "-form")
                });

                _param["thisPreview"].getList({
                    idProgress: _param["idProgress"],
                    idPreview: _param["idPreview"],
                    valueSelected: _valueProcess["selected"]
                });
                _this.initProcess({
                    action: _param["action"],
                    page: _param["pageProgress"],
                    this: _param["thisProgress"],
                    idMain: _param["idMain"],
                    idProgress: _param["idProgress"],
                    option: _param["option"]
                });
            }
        });
    },
    getValueProcess: function (_param) {
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);        
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _idTable = (_param["idMain"] + "-table");
        var _valueProgressResult = _param["this"].getValueProcess();
        var _valueParamSearch = "";
        var _valueSelected = "";

        if (_param["option"] == "selected") {
            _valueParamSearch = "";
            _valueSelected = Util.getValueSelectCheck({
                id: "select-child",
                idParent: ("#" + _idTable)
            }).join("|");
        }

        if (_param["option"] == "all") {
            _valueParamSearch = _valueProgressResult["paramsearch"].replace(/({|}|")/g, "");
            _valueSelected = "";
        }

        _valueProgressResult["paramsearch"] = _valueParamSearch;
        _valueProgressResult["selected"] = _valueSelected;
        
        return _valueProgressResult;
    },
    initProcess: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _this = this;

        $(".dialog-form .button .click-button").click(function () {
            if ($(this).hasClass("button-start") || $(this).hasClass("button-submit"))
                _this.confirmProcess({
                    action: _param["action"],
                    page: _param["page"],
                    this: _param["this"],
                    idMain: _param["idMain"],
                    idProgress: _param["idProgress"],
                    option: _param["option"]
                });
        });
    },
    confirmProcess: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _this = this;
        var _msgTH;
        var _msgEN;
        
        if (_param["action"] == Util.tut.subjectSectionUpdate) {
            _msgTH = "ปรับปรุงข้อมูล";
            _msgEN = "update";
        }

        if (_param["action"] == Util.tut.subjectSectionExport) {
            _msgTH = "ส่งออกข้อมูล";
            _msgEN = "export";
        }

        Util.dialogMessageConfirm({
            content: "<div class='th-label'>ต้องการ" + _msgTH + "นี้หรือไม่</div><div class='en-label'>Do you want to " + _msgEN + " ?</div>",
            button: {
                msgYes: "OK",
                msgNo: "CANCEL"
            }
        }, function (_result) {
            if (_result == "Y") {
                if (_this.validateProcess({
                    this: _param["this"]
                })) {
                    if ($("#" + Util.dialogForm + "2").is(":visible")) $("#" + Util.dialogForm + "2").dialog("close");
                        _this.getProcess({
                            action: _param["action"],
                            page: _param["page"],
                            this: _param["this"],
                            idMain: _param["idMain"],
                            idProgress: _param["idProgress"],
                            option: _param["option"]
                        });
                }
            }
        });
    },
    validateProcess: function (_param) {
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);

        var _validateResult = _param["this"].validateProcess();

        return _validateResult;
    },
    getProcess: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _this1;
        var _this2 = this;
        var _idTable = (_param["idMain"] + "-table");
        var _idSection = "";
        var _valueSelected = "";
        var _valueParamSearch = "";
        var _valueProcess = {};
        var _valueFaculty = "";
        var _valueProgram = "";
        var _valueClassYear = "";
        var _valueEntranceType = "";
        var _valueStudentStatus = "";
        var _valueYearAttended = "";
        var _valueAdmissionDate = "";
        var _valueGraduationDate = "";
        var _valueUpdateReason = "";
        var _valueJoinProgramStatus;
        var _valueStartSemester;
        var _valueStartYear;
        var _valueEndSemester;
        var _valueEndYear;
        var _valueResignDate;

        _valueProcess = _this2.getValueProcess({
            this: _param["this"],
            idMain: _param["idMain"],
            option: _param["option"]
        });

        _valueParamSearch = (_valueProcess["paramsearch"] == undefined ? "" : _valueProcess["paramsearch"]);
        _valueSelected = (_valueProcess["selected"] == undefined ? "" : _valueProcess["selected"]);
        _valueFaculty = (_valueProcess["valuefaculty"] == undefined ? "" : _valueProcess["valuefaculty"]);
        _valueProgram = (_valueProcess["valueprogram"] == undefined ? "" : _valueProcess["valueprogram"]);
        _valueClassYear = (_valueProcess["valueclassyear"] == undefined ? "" : _valueProcess["valueclassyear"]);
        _valueEntranceType = (_valueProcess["valueentrancetype"] == undefined ? "" : _valueProcess["valueentrancetype"]);
        _valueStudentStatus = (_valueProcess["valuestudentstatus"] == undefined ? "" : _valueProcess["valuestudentstatus"]);
        _valueYearAttended = (_valueProcess["valueyearattended"] == undefined ? "" : _valueProcess["valueyearattended"]);
        _valueAdmissionDate = (_valueProcess["valueadmissiondate"] == undefined ? "" : _valueProcess["valueadmissiondate"]);
        _valueGraduationDate = (_valueProcess["valuegraduationdate"] == undefined ? "" : _valueProcess["valuegraduationdate"]);
        _valueJoinProgramStatus = (_valueProcess["valuejoinprogramstatus"] == undefined ? "" : _valueProcess["valuejoinprogramstatus"]);
        _valueStartSemester = (_valueProcess["valuestartsemester"] == undefined ? "" : _valueProcess["valuestartsemester"]);
        _valueStartYear = (_valueProcess["valuestartyear"] == undefined ? "" : _valueProcess["valuestartyear"]);
        _valueEndSemester = (_valueProcess["valueendsemester"] == undefined ? "" : _valueProcess["valueendsemester"]);
        _valueEndYear = (_valueProcess["valueendyear"] == undefined ? "" : _valueProcess["valueendyear"]);
        _valueResignDate = (_valueProcess["valueresigndate"] == undefined ? "" : _valueProcess["valueresigndate"]);
        _valueUpdateReason = (_valueProcess["valueupdatereason"] == undefined ? "" : _valueProcess["valueupdatereason"]);

        $("#" + _param["idProgress"] + "-totalcomplete-content .progresstotal span").html("");
        $("#" + _param["idProgress"] + "-totalincomplete-content .progresstotal span").html("");
        
        var _send = {};
        _send["option"] = _param["option"];
        _send["paramsearch"] = _valueParamSearch;
        _send["selected"] = _valueSelected;
        _send["faculty"] = _valueFaculty;
        _send["program"] = _valueProgram;
        _send["class"] = _valueClassYear;
        _send["entrancetype"] = _valueEntranceType;
        _send["studentstatus"] = _valueStudentStatus;
        _send["yearattended"] = _valueYearAttended;
        _send["admissiondate"] = _valueAdmissionDate;
        _send["graduationdate"] = _valueGraduationDate;
        _send["joinprogramstatus"] = _valueJoinProgramStatus;
        _send["startsemester"] = _valueStartSemester;
        _send["startyear"] = _valueStartYear;
        _send["endsemester"] = _valueEndSemester;
        _send["endyear"] = _valueEndYear;
        _send["resigndate"] = _valueResignDate;
        _send["updatereason"] = _valueUpdateReason;

        this.actionProcess({
            page: _param["page"],
            data: _send
        }, function (_resultProcess, _resultValueProcess) {
            if (_resultProcess == true)
                _this2.getResultProcess({
                    action: _param["action"],
                    page: _param["page"],
                    this: _param["this"],
                    idMain: _param["idMain"],
                    idProgress: _param["idProgress"],
                    option: _param["option"],
                    resultValueProcess: _resultValueProcess,
                    dataProcess: _valueProcess
                });
        });
    },
    actionProcess: function (_param, _callBackFunc) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["data"] = (_param["data"] == undefined || _param["data"] == "" ? {} : _param["data"]);

        var _error;
        var _signinYN = "Y";
        var _send = _param["data"];
        _send["signinyn"] = _signinYN;

        Util.msgPreloading = "Processing...";

        Util.actionProcess({
            page: _param["page"],
            data: _param["data"]
        }, function (_result) {
            _error = Util.tut.getErrorMsg({
                signinYN: _signinYN,
                pageError: 0,
                cookieError: _result.CookieError,
                userError: _result.UserError,
                saveError: _result.ConnServer
            });

            _callBackFunc((_error == false ? true : false), _result);
        });
    },
    getResultProcess: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);
        _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
        _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _totalComplete = _param["resultValueProcess"].Complete;
        var _totalIncomplete = _param["resultValueProcess"].Incomplete;
        var _totalUnitTH = "รายการ";
        var _totalUnitEN = "items";
        var _downloadFolder = _param["resultValueProcess"].DownloadFolder;
        var _downloadFile = _param["resultValueProcess"].DownloadFile;

        if (_param["action"] == Util.tut.subjectSectionUpdate) {
            _msgTH = "ปรับปรุงข้อมูล";
            _msgEN = "Update data";
        }

        if (_param["action"] == Util.tut.subjectSectionExport) {
            _msgTH = "ส่งออกข้อมูล";
            _msgEN = "Export data";
        }

        if (_param["page"] == Util.tut.pageAdministrationStudentRecordsUpdateFacultyProgramProgress ||
            _param["page"] == Util.tut.pageAdministrationStudentRecordsUpdateClassYearProgress ||
            _param["page"] == Util.tut.pageAdministrationStudentRecordsUpdateEntranceTypeProgress ||
            _param["page"] == Util.tut.pageAdministrationStudentRecordsUpdateStudentStatusProgress ||
            _param["page"] == Util.tut.pageAdministrationStudentRecordsUpdateAdmissionDateProgress ||
            _param["page"] == Util.tut.pageAdministrationStudentRecordsUpdateDatatoOldDBProgress ||
            _param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationProgress ||
            _param["page"] == Util.tut.pageOurServicesUpdateStudentMedicalScholarsProgramProgress ||
            _param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel2ViewTableProgress) {
            _totalUnitTH = "คน";
            _totalUnitEN = "people";
        }
        
        if ($("#" + _param["idProgress"] + "-totalcomplete").length > 0) {
            $("#" + _param["idProgress"] + "-totalcomplete").html(_totalComplete);
            $("#" + _param["idProgress"] + "-totalcomplete-content .progresstotal span:eq(1)").html(" " + _totalUnitTH);
            $("#" + _param["idProgress"] + "-totalcomplete-content .progresstotal span:eq(2)").html(" : " + _totalUnitEN);
        }

        if ($("#" + _param["idProgress"] + "-totalincomplete").length > 0) {
            $("#" + _param["idProgress"] + "-totalincomplete").html(_totalIncomplete);
            $("#" + _param["idProgress"] + "-totalincomplete-content .progresstotal span:eq(1)").html(" " + _totalUnitTH);
            $("#" + _param["idProgress"] + "-totalincomplete-content .progresstotal span:eq(2)").html(" : " + _totalUnitEN);
        }

        $("#" + _param["idProgress"] + "-form .button li:eq(1)").hide();
        $("#" + _param["idProgress"] + "-form .button li div")
            .removeClass("button-save")
            .removeClass("button-start")
            .addClass("button-download").html("SAVE ZIP FILE").css("width", "185px").bind("click", function () {
                Util.gotoPage({
                    page: ("eProfileStaffDownloadFile.aspx?p=" + _downloadFolder + "&f=" + _downloadFile),
                    target: "frame-util"
                });
            });

        _param["this"].getResultProcess({
            page: _param["page"],
            resultValueProcess: _param["resultValueProcess"],
            dataProcess: _param["dataProcess"]
        });

        Util.dialogMessageBox({
            content: ("<div class='th-label'>" + _msgTH + "เรียบร้อย</div><div class='en-label'>" + _msgEN + " complete</div>")
        });
    }
}