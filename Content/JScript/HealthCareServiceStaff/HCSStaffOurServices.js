/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๒/๐๔/๒๕๕๙>
Modify date : <๑๖/๐๒/๒๕๖๓>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการบริการข้อมูล>
=============================================
*/

var HCSStaffOurServices = {
    healthinformation: {
        idSectionMain: HCSStaffUtil.idSectionOurServicesHealthInformationMain.toLowerCase(),
        idSectionProgress: HCSStaffUtil.idSectionOurServicesHealthInformationProgress.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.healthinformation;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });
                Util.initCheck({
                    id: "select-root"
                });

                $("#" + _this.idSectionMain + "-table .button .click-button").click(function () {
                    if ($(this).hasClass("button-exportselected") == true || $(this).hasClass("button-exportall") == true)
                        Util.tut.tpd.getProgress({
                            action: Util.tut.subjectSectionExport,
                            page: Util.tut.pageOurServicesHealthInformationProgress,
                            this: _this,
                            idMain: _this.idSectionMain,
                            idProgress: _this.idSectionProgress,
                            option: $(this).attr("alt")
                        });
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.healthinformation;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        },
        sectionProgress: {
            resetMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.healthinformation;
            },
            validateProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.healthinformation;
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            getResultProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
            }
        }
    },
    statisticsdownloadhealthcareserviceform: {
        idSectionMain: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.statisticsdownloadhealthcareserviceform;

                Util.initTabChartTable({
                    this: _this,
                    section: Util.tut.subjectSectionOurServices
                }, function (_result) { });
            }
        },
        viewchart: {
            idSectionMain: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormViewChartMain.toLowerCase(),
            sectionMain: {
                initMain: function () {
                },
            },
        },
        viewtable: {
            idSectionMain: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormViewTableMain.toLowerCase(),
            idSectionLevel1Main: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain.toLowerCase(),
            idSectionLevel2Main: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain.toLowerCase(),
            idSectionLevel1Progress: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableProgress.toLowerCase(),
            idSectionLevel2Progress: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableProgress.toLowerCase(),
            registrationForm: "",
            yearEntry: "",
            sectionMain: {
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain : _param["page"]);
                    
                    var _this1 = Util.tut.tos.statisticsdownloadhealthcareserviceform;
                    var _this2 = _this1.viewtable;
                    var _action;
                    var _page;
                    var _idMain;
                    var _idProgress;

                    if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain) {
                        _action = Util.tut.subjectSectionExport;
                        _page = Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableProgress;
                        _idMain = _this2.idSectionLevel1Main;
                        _idProgress = _this2.idSectionLevel1Progress;
                    }

                    if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain) {
                        _action = Util.tut.subjectSectionExport;
                        _page = Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableProgress;
                        _idMain = _this2.idSectionLevel2Main;
                        _idProgress = _this2.idSectionLevel2Progress;
                    }

                    $("#" + _idMain + "-table .button .click-button").click(function () {
                        if ($(this).hasClass("button-exportall") == true)
                            Util.tut.tpd.getProgress({
                                action: _action,
                                page: _page,
                                this: _this2,
                                idMain: _idMain,
                                idProgress: _idProgress,
                                option: $(this).attr("alt")
                            });
                    });

                    this.resetMain({
                        page: _param["page"]
                    });
                },
                resetMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain : _param["page"]);

                    var _this1 = Util.tut.tos.statisticsdownloadhealthcareserviceform;
                    var _this2 = _this1.viewtable;
                    var _idSectionOld;
                    var _idSectionNew;
                    var _objTableOld;
                    var _objTableNew;
                    var _subject;

                    if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain) {
                        _idSectionOld = "";
                        _idSectionNew = _this2.idSectionLevel1Main;
                        _subject = "";
                    }
                    
                    if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain) {
                        _idSectionOld = _this2.idSectionLevel1Main;
                        _idSectionNew = _this2.idSectionLevel2Main;
                        _subject = ("แบบฟอร์ม " + _this2.registrationForm + ", ปีที่เข้าศึกษา " + _this2.yearEntry);
                    }

                    _objTableOld = ("#" + _idSectionOld + "-table");
                    _objTableNew = ("#" + _idSectionNew + "-table");

                    if (_idSectionOld.length > 0) {
                        $(_objTableOld).hide();
                        $(_objTableNew + " .table-subject").html(_subject);
                        $(_objTableNew).show();

                        $(_objTableNew + " .link-goback").click(function () {
                            $(_objTableNew + " .table-subject").html("");
                            $(_objTableNew + " .table-recordcount .recordcountprimary-search").html("");
                            $(_objTableNew + " .table-recordcount .recordcountsecondary-search").html("");
                            $(_objTableNew + " .table-recordcount .recordcountprimary-all").html("");
                            $(_objTableNew + " .table-recordcount .recordcountsecondary-all").html("");
                            $(_objTableNew + " .table-title .contentbody-left").hide();
                            $(_objTableNew + " .table-list").html("");
                            $(_objTableNew + " .table-navpage").html("");
                            $(_objTableNew).hide();
                            $(_objTableOld).show();
                        });
                    }
                    else
                        $(_objTableNew + " .link-goback").hide();
                },
                initTable: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain : _param["page"]);

                    var _this1 = Util.tut.tos.statisticsdownloadhealthcareserviceform;
                    var _this2 = _this1.viewtable;
                    var _idSection;
                    var _page;
                    var _valueArray;

                    Util.tut.getDialogFormOnClick();
                    
                    if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain)
                        _idSection = _this2.idSectionLevel1Main;

                    $("#" + _idSection + "-table .table-grid .link-click").click(function () {
                        if ($(this).hasClass("link-" + Util.tut.subjectSectionStatisticsDownloadHealthCareServiceFormLevel2ViewTable.toLowerCase()) == true) {
                            _valueArray = ($(this).attr("alt")).split(",");
                            _page = _valueArray[0];
                            _this2.registrationForm = _valueArray[1];
                            _this2.yearEntry = _valueArray[2];

                            Util.tut.tse.getSearch({
                                page: _page
                            });
                        }
                    });
                }
            },
            sectionProgress: {
                resetMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this = Util.tut.tos.statisticsdownloadhealthcareserviceform;
                },
                validateProcess: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this = Util.tut.tos.statisticsdownloadhealthcareserviceform;
                    var _error = new Array();
                    var _i = 0;

                    return (_i > 0 ? false : true);
                },
                getResultProcess: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                    _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                }
            }
        }
    },
    termservicehcsconsent: {
        pageMain: "",
        pageEdit: "",
        pageProgress: "",
        idSectionMain: HCSStaffUtil.idSectionOurServicesTermServiceHCSConsentMain.toLowerCase(),
        idSectionProgress: HCSStaffUtil.idSectionOurServicesTermServiceHCSConsentProgress.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.termservicehcsconsent;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });
                Util.initCheck({
                    id: "select-root"
                });

                $("#" + _this.idSectionMain + "-table .button .click-button").click(function () {
                    if ($(this).hasClass("button-exportselected") == true || $(this).hasClass("button-exportall") == true)
                        Util.tut.tpd.getProgress({
                            action: Util.tut.subjectSectionExport,
                            page: HCSStaffOurServices.termservicehcsconsent.pageProgress,
                            this: _this,
                            idMain: _this.idSectionMain,
                            idProgress: _this.idSectionProgress,
                            option: $(this).attr("alt")
                        });
                });
							
                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.termservicehcsconsent;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            },
            initTable: function () {
                var _this1 = Util.tut.tos.termservicehcsconsent;
                var _this2 = this;
                var _id;
                var _studentId;
                var _consentStatusOld;
                var _consentStatus;

                Util.tut.getDialogFormOnClick();

                $("#" + _this1.idSectionMain + "-table .table-grid input[name=consent-status]").click(function () {
                    _id = $(this).val();
                    _studentId = $(this).data("studentid");
                    _consentStatus = ($(this).prop("checked") ? "Y" : "N");
                    
                    if (_consentStatus == "Y" && HCSStaffOurServices.termservicehcsconsent.pageEdit == Util.tut.pageOurServicesTermServiceHCSConsentRegistrationEdit) {
                        Util.loadForm({
                            index: 1,
                            name: Util.tut.pageOurServicesTermServiceHCSConsentSelectHospitalDialog,
                            dialog: true
                        }, function (_result, _e) {
                            if (_e != "close")
                                _this1.sectionDialog.selectHospital.initMain(_id, _studentId, _consentStatus);

                            if (_e == "close" && $("#table-row-id-" + _id + " input[name=consent-status]").data("consentstatus") != _consentStatus) {
                                $("#table-row-id-" + _id + " input[name=consent-status]").removeAttr("checked");
                                $("#table-row-id-" + _id + " .table-col-hospital").html("");
                            }
                        });
                    }
                    else
                        _this2.getSave({
                            id: $(this).val(),
                            studentId: $(this).data("studentid"),
                            consentStatus: _consentStatus
                        });
                });
            },
            getSave: function (_param) {
                _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);
                _param["studentId"] = (_param["studentId"] == undefined ? "" : _param["studentId"]);
                _param["consentStatus"] = (_param["consentStatus"] == undefined ? "" : _param["consentStatus"]);
                _param["note"] = (_param["note"] == undefined ? "" : _param["note"]);

                var _this1 = Util.tut;
                var _data = {};
                var _signinYN = "Y";
                var _error;

                _data.signinYN = _signinYN;
                _data.id = _param["id"];
                _data.studentId = _param["studentId"];
                _data.consentStatus = _param["consentStatus"];
                _data.note = _param["note"];

                Util.msgPreloading = "Saving...";

                Util.actionSave({
                    action: "save",
                    page: HCSStaffOurServices.termservicehcsconsent.pageEdit,
                    data: _data
                }, function (_result) {
                    _error = _this1.getErrorMsg({
                        signinYN: _signinYN,
                        pageError: 0,
                        cookieError: _result.CookieError,
                        userError: _result.UserError,
                        saveError: _result.SaveError
                    });

                    if (_error == false) {
                        $("#table-row-id-" + _param["id"] + " input[name=consent-status]").data("consentstatus", _param["consentStatus"]);
                        $("#table-row-id-" + _param["id"] + " .table-col-hospital").html(_param["note"]);
                        $("#table-row-id-" + _param["id"] + " .table-col-termdate").html(_result.TermDate);
                    }
                });
            }
        },
        sectionDialog: {
            selectHospital: {
                idSectionDialog: HCSStaffUtil.idSectionOurServicesTermServiceHCSConsentSelectHospitalDialog.toLowerCase(),
                initMain: function (_id, _studentId, _consentStatus) {
                    var _this1 = Util.tut;
                    var _this2 = _this1.tos.termservicehcsconsent;
                    var _this3 = this;
                
                    Util.initCheck({
                        id: (_this3.idSectionDialog + "-hospital")
                    });

                    $("#" + _this3.idSectionDialog + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-save")) {
                            if (_this3.validateSelect())
                                _this2.sectionMain.getSave({
                                    id: _id,
                                    studentId: _studentId,
                                    consentStatus: _consentStatus,
                                    note: Util.checkGetValue(_this3.idSectionDialog + "-hospital")
                                });
                        }
                    });
                
                    this.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut;
                    var _this2 = _this1.tos.termservicehcsconsent;
                    var _this3 = this;

                    Util.checkSetValue({
                        id: (_this3.idSectionDialog + "-hospital"),
                        value: ""
                    });
                },
                validateSelect: function () {
                    var _this1 = Util.tut;
                    var _this2 = _this1.tos.termservicehcsconsent;
                    var _this3 = this;
                    var _error = false;
                    var _msgTH;
                    var _msgEN;

                    if (_error == false && Util.checkGetValue(_this3.idSectionDialog + "-hospital").length == 0) {
                        _error = true;
                        _msgTH = "กรุณาเลือกสถานพยาบาล";
                        _msgEN = "Please select hospital of health care service.";
                    }
       
                    if (_error == true) {
                        Util.dialogMessageError({
                            content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                        });

                        return false;
                    }

                    return true;
                }
            }
        },
        sectionProgress: {
            resetMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.termservicehcsconsent;
            },
            validateProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.termservicehcsconsent;
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            getResultProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
            }
        }
    }
}