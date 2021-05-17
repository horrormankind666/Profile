/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๕/๐๘/๒๕๕๘>
Modify date : <๑๔/๐๒/๒๕๖๓>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการแสดงความคืบหน้าการประมวลผลข้อมูล>
=============================================
*/

var HCSStaffProgressData = {
    getProgress: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _this = this;

        if (_this.validateProgress({
                action: _param["action"],
                page: _param["page"],
                this: _param["this"],
                idMain: _param["idMain"],
                idProgress: _param["idProgress"],
                option: _param["option"]
            })) {
            Util.loadForm({
                index: 1,
                name: _param["page"],
                dialog: true
            }, function (_result, _e) {
                if (_result.Content.length > 0 && _e != "close") {
                    _this.initProgress({
                        action: _param["action"],
                        page: _param["page"],
                        this: _param["this"],
                        idMain: _param["idMain"],
                        idProgress: _param["idProgress"],
                        option: _param["option"]
                    });
                    _this.initProcess({
                        action: _param["action"],
                        page: _param["page"],
                        this: _param["this"],
                        idMain: _param["idMain"],
                        idProgress: _param["idProgress"],
                        option: _param["option"]
                    });
                }
            });
        }
    },
    validateProgress: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _idTable = (_param["idMain"] + "-table");
        var _objCheck = $("#" + _idTable + " input[name=select-child]:checked");

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
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        $("#" + Util.dialogForm + "1").dialog("option", "position", {
            my: "center",
            at: "center",
            of: window
        });
        
        this.resetProgress({
            action: _param["action"],
            page: _param["page"],
            this: _param["this"],
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

        _param["this"].sectionProgress.resetMain({
            page: _param["page"]
        });
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
            if ($(this).hasClass("button-start"))
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
        
        if (_param["action"] == Util.tut.subjectSectionDownload) {
            _msgTH = "ดาว์นโหลดข้อมูล";
            _msgEN = "download";
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
                        page: _param["page"],
                        this: _param["this"]
                    }))
                    _this.getProcess({
                        action: _param["action"],
                        page: _param["page"],
                        this: _param["this"],
                        idMain: _param["idMain"],
                        idProgress: _param["idProgress"],
                        option: _param["option"]
                    });
            }
        });
    },
    validateProcess: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);

        var _this = _param["this"].sectionProgress;
        var _validateResult = true;

        if (_this != null)
            _validateResult = _this.validateProcess({
                page: _param["page"]
            });

        return _validateResult;
    },
    getValueProcess: function (_param) {
        _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"] = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"] = (_param["option"] == undefined ? "" : _param["option"]);

        var _idTable = (_param["idMain"] + "-table");
        var _valueSelected = "";
        var _valueParamSearch = "";
        var _valueRegistrationForm = "";
        var _valueProgressResult = {};

        if (_param["page"] == Util.tut.pageDownloadRegistrationFormProgress) {
            _valueParamSearch = (JSON.stringify(Util.tut.tse.downloadregistrationform.valueSearch()));
            _valueRegistrationForm = Util.getSelectionIsSelect({
                id: ("#" + _param["this"].idSectionSearch + "-registrationform"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + _param["this"].idSectionSearch + "-registrationform")
            });
        }

        if (_param["page"] == Util.tut.pageOurServicesHealthInformationProgress)
            _valueParamSearch = (JSON.stringify(Util.tut.tse.ourservices.healthinformation.valueSearch()));

        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableProgress)
            _valueParamSearch = (JSON.stringify(Util.tut.tse.ourservices.statisticsdownloadhealthcareserviceform.valueSearch()));
       
        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableProgress) {
            _valueParamSearch = Util.tut.tse.ourservices.statisticsdownloadhealthcareserviceform.valueSearch();
            _valueParamSearch["registrationform"] = Util.tut.tos.statisticsdownloadhealthcareserviceform.viewtable.registrationForm;
            _valueParamSearch["yearentry"] = Util.tut.tos.statisticsdownloadhealthcareserviceform.viewtable.yearEntry;
            _valueParamSearch = JSON.stringify(_valueParamSearch);
        }

        if (_param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentRegistrationProgress ||
            _param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentOOCAProgress)
            _valueParamSearch = (JSON.stringify(Util.tut.tse.ourservices.termservicehcsconsent.valueSearch()));

        if (_param["option"] == "selected") {
            _valueParamSearch = "";
            _valueSelected = Util.getValueSelectCheck({
                id: "select-child",
                idParent: ("#" + _idTable)
            }).join("|");
        }

        if (_param["option"] == "all") {
            _valueParamSearch = _valueParamSearch.replace(/({|}|")/g, "");
            _valueSelected = "";
        }

        _valueProgressResult["paramsearch"] = _valueParamSearch;
        _valueProgressResult["selected"] = _valueSelected;
        _valueProgressResult["registrationform"] = _valueRegistrationForm;
        
        return _valueProgressResult;
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
        var _valueRegistrationForm = "";

        _valueProcess = _this2.getValueProcess({
            action: _param["action"],
            page: _param["page"],
            this: _param["this"],
            idMain: _param["idMain"],
            idProgress: _param["idProgress"],
            option: _param["option"]
        });

        _valueParamSearch = _valueProcess["paramsearch"];
        _valueSelected = _valueProcess["selected"];
        _valueRegistrationForm = _valueProcess["registrationform"];

        $("#" + _param["idProgress"] + "-totalcomplete-content .progresstotal span").html("");
        $("#" + _param["idProgress"] + "-totalincomplete-content .progresstotal span").html("");
            
        var _send = {};
        _send["option"] = _param["option"];
        _send["paramsearch"] = _valueParamSearch;
        _send["selected"] = _valueSelected;
        _send["registrationform"] = _valueRegistrationForm;

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
        var _totalUnitTH;
        var _totalUnitEN;
        var _downloadFolder = _param["resultValueProcess"].DownloadFolder;
        var _downloadFile = _param["resultValueProcess"].DownloadFile;

        if (_param["action"] == Util.tut.subjectSectionDownload) {
            _msgTH = "ดาว์นโหลดข้อมูล";
            _msgEN = "Download data";
        }

        if (_param["action"] == Util.tut.subjectSectionExport) {
            _msgTH = "ส่งออกข้อมูล";
            _msgEN = "Export data";
        }

        if (_param["page"] == Util.tut.pageDownloadRegistrationFormProgress ||
            _param["page"] == Util.tut.pageOurServicesHealthInformationProgress ||
            _param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableProgress ||
            _param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentRegistrationProgress ||
            _param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentOOCAProgress) {
            _totalUnitTH = "คน";
            _totalUnitEN = "people";
        }

        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableProgress) {
            _totalUnitTH = "รายการ";
            _totalUnitEN = "items";
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

        _param["this"].sectionProgress.getResultProcess({
            page: _param["page"],
            resultValueProcess: _param["resultValueProcess"]
        });

        if (parseInt(_totalComplete) > 0) {
            Util.dialogMessageBox({
                content: ("<div class='th-label'>" + _msgTH + "เรียบร้อย กรุณารอสักครู่ เพื่อทำการบันทึกไฟล์</div><div class='en-label'>" + _msgEN + " complete. Please wait to save file.</div>")
            });
            Util.gotoPage({
                page: ("HCSStaffDownloadFile.aspx?p=" + _downloadFolder + "&f=" + _downloadFile),
                target: "frame-util"
            });
        }
    }
}