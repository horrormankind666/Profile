/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๔/๐๖/๒๕๕๘>
Modify date : <๐๖/๐๘/๒๕๖๔>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการส่งออกข้อมูล>
=============================================
*/

var UDSStaffOurServices = {
    documentstatusstudent: {
        idSectionMain: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.documentstatusstudent;
                
                Util.initTabChartTable({
                    this: _this,
                    section: Util.tut.subjectSectionOurServices
                }, function (_result) {
                });
            }
        },
        viewchart: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentViewChartMain.toLowerCase(),
            sectionMain: {
                initMain: function () {
                },
            },
        },
        viewtable: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentViewTableMain.toLowerCase(),
            idSectionLevel1Main: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentLevel1ViewTableMain.toLowerCase(),
            idSectionLevel1Preview: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentLevel1ViewTablePreview.toLowerCase(),
            idSectionLevel1Progress: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentLevel1ViewTableProgress.toLowerCase(),
            sectionMain: {
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain : _param["page"]);
                    
                    var _this1 = Util.tut.tos.documentstatusstudent;
                    var _this2 = _this1.viewtable;
                    var _action;
                    var _page;
                    var _idMain;
                    var _idPreview;
                    var _idProgress;

                    if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain) {
                        _action = Util.tut.subjectSectionExport;
                        _page = Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableProgress;
                        _idMain = _this2.idSectionLevel1Main;
                        _idPreview = _this2.idSectionLevel1Preview;
                        _idProgress = _this2.idSectionLevel1Progress;

                        Util.tut.initPreviewDocument({
                            idMain: _idMain,
                            idPreview: _idPreview
                        });
                        Util.initCombobox({
                            id: ("#" + _idMain + "-rowperpage"),
                            width: 103,
                            height: 25
                        });
                        Util.initCheck({
                            id: "select-root"
                        });
                    }
                    
                    $("#" + _idMain + "-table .button .click-button").click(function () {
                        if ($(this).hasClass("button-exportselected") == true || $(this).hasClass("button-exportall") == true)
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
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain : _param["page"]);

                    var _this1 = Util.tut.tos.documentstatusstudent;
                    var _this2 = _this1.viewtable;

                    if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain) {
                        Util.comboboxSetValue({
                            id: ("#" + _this2.idSectionLevel1Main + "-rowperpage"),
                            value: $("#" + _this1.idSectionMain + "-rowperpage-hidden").val()
                        });
                    }
                },
                initTable: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain : _param["page"]);

                    var _this1 = Util.tut.tos.documentstatusstudent;
                    var _this2 = _this1.viewtable;

                    Util.tut.getDialogFormOnClick();
                }
            },
            sectionPreview: {
                resetMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain : _param["page"]);
                    _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

                    var _this1 = Util.tut.tos.documentstatusstudent;
                    var _this2 = _this1.viewtable;
                    var _idMain;
                    var _idPreview;
                    var _idProgress;

                    if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain) {
                        _idMain = _this2.idSectionLevel1Main;
                        _idPreview = _this2.idSectionLevel1Preview;
                    }

                    var _idContent = (_idPreview + _param["section"].toLowerCase());
                    var _idTableRowActive = $("#" + _idMain + "-table .table-grid .table-row.active").attr("id");
                    var _valueFileFullPath = $("#" + _idContent + "-filefullpath-hidden").val();
                    var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
                    var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
                    var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
                    var _valueDocumentStatus = (_valueSavedStatus + _valueSubmittedStatus + _valueApprovalStatus);
                    var _valueSubject;
                    var _objWatermark = $("#" + _idContent + "-form .picture-watermark");
                    var _objImage = $("#" + _idContent + "-form img");
                    var _show = false;
                    
                    if (_valueDocumentStatus == "NNS" || _valueDocumentStatus == "YNS" || _valueDocumentStatus == "YYS" || _valueDocumentStatus == "YYW" || _valueDocumentStatus == "YYY" || _valueDocumentStatus == "YYN")
                        _show = true;
                    else {
                        _valueSubject = Util.tut.getSubjectDocumentUpload({
                            section: _param["section"]
                        });
                        Util.dialogMessageError({
                            content: ("<div class='th-label'>สถานะเอกสารของ" + _valueSubject["subjectth"] + "มีการเปลี่ยนแปลง กรุณารีเฟรชหน้าจอ</div><div class='en-label'>Document status " + $.trim(_valueSubject["subjecten"]) + " is not valid, Please refresh this page.</div>")
                        });
                    }

                    if (_show == true) {
                        if (_objImage.is("[src]") == false) {
                            _objWatermark.hide();
                            _objImage.removeAttr("src").hide();

                            if (_valueFileFullPath.length > 0) {
                                _objWatermark.show();
                                _objImage.attr({
                                    "src": _valueFileFullPath
                                }).show();
                            }
                        }
                    }
                },
            },
            sectionProgress: {
                resetMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this = Util.tut.tos.documentstatusstudent;
                },
                validateProcess: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this = Util.tut.tos.documentstatusstudent;
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
    exportprofilepictureapproved: {
        idSectionMain: UDSStaffUtil.idSectionOurServicesExportProfilePictureApprovedMain.toLowerCase(),
        idSectionPreview: UDSStaffUtil.idSectionOurServicesExportProfilePictureApprovedPreview.toLowerCase(),
        idSectionProgress: UDSStaffUtil.idSectionOurServicesExportProfilePictureApprovedProgress.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.exportprofilepictureapproved;
                
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
                            page: Util.tut.pageOurServicesExportProfilePictureApprovedProgress,
                            this: _this,
                            idMain: _this.idSectionMain,
                            idProgress: _this.idSectionProgress,
                            option: $(this).attr("alt")
                        });
                });
                    
                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.exportprofilepictureapproved;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            },
            initTable: function () {
                Util.tut.getDialogFormOnClick();
            },
        },        
        sectionPreview: {
            resetMain: function (_param) {
                _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

                var _this = Util.tut.tos.exportprofilepictureapproved;
                var _idContent = (_this.idSectionPreview + _param["section"].toLowerCase());
                var _idTableRowActive = $("#" + _this.idSectionMain + "-table .table-grid .table-row.active").attr("id");
                var _valueFileFullPath = $("#" + _idContent + "-filefullpath-hidden").val();
                var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
                var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
                var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
                var _valueDocumentStatus = (_valueSavedStatus + _valueSubmittedStatus + _valueApprovalStatus);
                var _valueSubject;
                var _objWatermark = $("#" + _idContent + "-form .picture-watermark");
                var _objImage = $("#" + _idContent + "-form img");
                var _show = false;
        
                if (_valueDocumentStatus == "YYY")
                    _show = true;
                else {
                    _valueSubject = Util.tut.getSubjectDocumentUpload({
                        section: _param["section"]
                    });
                    Util.dialogMessageError({
                        content: ("<div class='th-label'>สถานะการอนุมัติ" + _valueSubject["subjectth"] + "มีการเปลี่ยนแปลง กรุณารีเฟรชหน้าจอ</div><div class='en-label'>Approval status " + $.trim(_valueSubject["subjecten"]) + " is not valid, Please refresh this page.</div>")
                    });
                }

                if (_show == true) {
                    if (_objImage.is("[src]") == false) {
                        _objWatermark.hide();
                        _objImage.removeAttr("src").hide();

                        if (_valueFileFullPath.length > 0) {
                            _objWatermark.show();
                            _objImage.attr({
                                "src": _valueFileFullPath
                            }).show();
                        }
                    }
                }
            }
        },
        sectionProgress: {
            resetMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.exportprofilepictureapproved;
            },
            validateProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.exportprofilepictureapproved;
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
    exportstudentrecordsinformationforsmartcard: {
        idSectionMain: UDSStaffUtil.idSectionOurServicesExportStudentRecordsInformationForSmartCardMain.toLowerCase(),
        idSectionPreview: UDSStaffUtil.idSectionOurServicesExportStudentRecordsInformationForSmartCardPreview.toLowerCase(),
        idSectionProgress: UDSStaffUtil.idSectionOurServicesExportStudentRecordsInformationForSmartCardProgress.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.exportstudentrecordsinformationforsmartcard;
                
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
                            page: Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardProgress,
                            this: _this,
                            idMain: _this.idSectionMain,
                            idProgress: _this.idSectionProgress,
                            option: $(this).attr("alt")
                        });
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.exportstudentrecordsinformationforsmartcard;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            },
            initTable: function () {
                Util.tut.getDialogFormOnClick();
            },
        },
        sectionPreview: {
            resetMain: function (_param) {
                _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

                var _this = Util.tut.tos.exportstudentrecordsinformationforsmartcard;
                var _idContent = (_this.idSectionPreview + _param["section"].toLowerCase());
                var _idTableRowActive = $("#" + _this.idSectionMain + "-table .table-grid .table-row.active").attr("id");
                var _valueFileFullPath = $("#" + _idContent + "-filefullpath-hidden").val();
                var _objWatermark = $("#" + _idContent + "-form .picture-watermark");
                var _objImage = $("#" + _idContent + "-form img");
        
                if (_objImage.is("[src]") == false) {
                    _objWatermark.hide();
                    _objImage.removeAttr("src").hide();

                    if (_valueFileFullPath.length > 0) {
                        _objWatermark.show();
                        _objImage.attr({
                            "src": _valueFileFullPath
                        }).show();
                    }
                }
            }
        },
        sectionProgress: {
            resetMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.exportstudentrecordsinformationforsmartcard;
            },
            validateProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.exportstudentrecordsinformationforsmartcard;
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            getResultProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);

                var _this = Util.tut.tos.exportstudentrecordsinformationforsmartcard;
                var _detailComplete = _param["resultValueProcess"].DetailComplete;
                var _idTable = (_this.idSectionMain + "-table");
                var _idTableRow;
                var _valueArray = _detailComplete.split(",");
                var _valueSubArray;

                for (_i = 0; _i < _valueArray.length; _i++) {
                    _valueSubArray = _valueArray[_i].split(";");
                    _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueSubArray[0]);

                    if ($("#" + _idTableRow).length > 0)
                        $("#" + _idTableRow + " .table-col-exportdate").html(_valueSubArray[1]);
                }
            }
        }
    },
    copyprofilepictureapprovedtothestore: {
        idSectionMain: UDSStaffUtil.idSectionOurServicesCopyProfilePictureApprovedtotheStoreMain.toLowerCase(),
        idSectionPreview: UDSStaffUtil.idSectionOurServicesCopyProfilePictureApprovedtotheStorePreview.toLowerCase(),
        idSectionProgress: UDSStaffUtil.idSectionOurServicesCopyProfilePictureApprovedtotheStoreProgress.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.copyprofilepictureapprovedtothestore;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });
                Util.initCheck({
                    id: "select-root"
                });
                
                $("#" + _this.idSectionMain + "-table .button .click-button").click(function () {
                    if ($(this).hasClass("button-copyselected") == true || $(this).hasClass("button-copyall") == true)
                        Util.tut.tpd.getProgress({
                            action: Util.tut.subjectSectionCopy,
                            page: Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreProgress,
                            this: _this,
                            idMain: _this.idSectionMain,
                            idProgress: _this.idSectionProgress,
                            option: $(this).attr("alt")
                        });
                });
                
                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.copyprofilepictureapprovedtothestore;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            },
            initTable: function () {
                Util.tut.getDialogFormOnClick();
            }
        },
        sectionPreview: {
            resetMain: function (_param) {
                _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

                var _this = Util.tut.tos.copyprofilepictureapprovedtothestore;
                var _idContent = (_this.idSectionPreview + _param["section"].toLowerCase());
                var _idTableRowActive = $("#" + _this.idSectionMain + "-table .table-grid .table-row.active").attr("id");
                var _valueFileFullPath = $("#" + _idContent + "-filefullpath-hidden").val();
                var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
                var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
                var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
                var _valueDocumentStatus = (_valueSavedStatus + _valueSubmittedStatus + _valueApprovalStatus);
                var _valueSubject;
                var _objWatermark = $("#" + _idContent + "-form .picture-watermark");
                var _objImage = $("#" + _idContent + "-form img");
                var _show = false;
        
                if (_valueDocumentStatus == "YYY")
                    _show = true;
                else {
                    _valueSubject = Util.tut.getSubjectDocumentUpload({
                        section: _param["section"]
                    });
                    Util.dialogMessageError({
                        content: ("<div class='th-label'>สถานะการอนุมัติ" + _valueSubject["subjectth"] + "มีการเปลี่ยนแปลง กรุณารีเฟรชหน้าจอ</div><div class='en-label'>Approval status " + $.trim(_valueSubject["subjecten"]) + " is not valid, Please refresh this page.</div>")
                    });
                }

                if (_show == true) {
                    if (_objImage.is("[src]") == false) {
                        _objWatermark.hide();
                        _objImage.removeAttr("src").hide();

                        if (_valueFileFullPath.length > 0) {
                            _objWatermark.show();
                            _objImage.attr({
                                "src": _valueFileFullPath
                            }).show();
                        }
                    }
                }
            }
        },
        sectionProgress: {
            resetMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.copyprofilepictureapprovedtothestore;
            },
            validateProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.exportprofilepictureapproved;
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
    audittranscriptapproved: {
        idSectionMain: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.audittranscriptapproved;

                Util.initTabChartTable({
                    this: _this,
                    section: Util.tut.subjectSectionOurServices
                }, function (_result) { });
            }
        },
        viewchart: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedViewChartMain.toLowerCase(),
            sectionMain: {
                initMain: function () {
                },
            },
        },
        viewtable: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedViewTableMain.toLowerCase(),
            idSectionLevel1Main: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedLevel1ViewTableMain.toLowerCase(),
            idSectionLevel21Main: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedLevel21ViewTableMain.toLowerCase(),
            idSectionLevel22Main: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedLevel22ViewTableMain.toLowerCase(),
            idSectionLevel1Progress: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedLevel1ViewTableProgress.toLowerCase(),
            idSectionLevel21Progress: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedLevel21ViewTableProgress.toLowerCase(),
            idSectionLevel22Progress: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedLevel22ViewTableProgress.toLowerCase(),
            yearEntry: "",
            sectionMain: {
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain : _param["page"]);
                    
                    var _this1 = Util.tut.tos.audittranscriptapproved;
                    var _this2 = _this1.viewtable;
                    var _action;
                    var _page;
                    var _idMain;
                    var _idProgress;

                    if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain) {
                        _action = Util.tut.subjectSectionExport;
                        _page = Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableProgress;
                        _idMain = _this2.idSectionLevel1Main;
                        _idProgress = _this2.idSectionLevel1Progress;
                    }

                    if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveMain) {
                        _action = Util.tut.subjectSectionExport;
                        _page = _param["page"].replace("Main", "Progress")
                        _idMain = _this2.idSectionLevel21Main;
                        _idProgress = _this2.idSectionLevel21Progress;
                    }

                    if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveMain) {
                        _action = Util.tut.subjectSectionExport;
                        _page = _param["page"].replace("Main", "Progress")
                        _idMain = _this2.idSectionLevel22Main;
                        _idProgress = _this2.idSectionLevel22Progress;
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
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain : _param["page"]);

                    var _this1 = Util.tut.tos.audittranscriptapproved;
                    var _this2 = _this1.viewtable;
                    var _idSectionOld;
                    var _idSectionNew;
                    var _objTableOld;
                    var _objTableNew;
                    var _subject;

                    if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain) {
                        _idSectionOld = "";
                        _idSectionNew = _this2.idSectionLevel1Main;
                        _subject = "";
                    }

                    if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveMain) {
                        _subject = _param["page"].replace("OurServicesAuditTranscriptApprovedLevel21ViewTable", "").replace("Main", "");
                        
                        if (_subject == "NeedSend")
                            _subject = "ต้องส่งไปตรวจสอบคุณวุฒิ";

                        if (_subject == "Send")
                            _subject = "ส่งไปตรวจสอบคุณวุฒิ";

                        if (_subject == "NotSend")
                            _subject = "ยังไม่ส่งไปตรวจสอบคุณวุฒิ";

                        if (_subject == "SendReceive")
                            _subject = "ส่งไปตรวจสอบคุณวุฒิและตอบกลับมา";

                        if (_subject == "SendNotReceive")
                            _subject = "ส่งไปตรวจสอบคุณวุฒิและยังไม่ตอบกลับมา";

                        _idSectionOld = _this2.idSectionLevel1Main;
                        _idSectionNew = _this2.idSectionLevel21Main;
                        _subject = ("โรงเรียนทั้งหมดที่" + _subject + ", ปีที่เข้าศึกษา " + _this2.yearEntry);
                    }

                    if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveMain ||
                        _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveMain) {
                        _subject = _param["page"].replace("OurServicesAuditTranscriptApprovedLevel22ViewTable", "").replace("Main", "");
                        
                        if (_subject == "NeedSend")
                            _subject = "ต้องส่งไปตรวจสอบคุณวุฒิ";

                        if (_subject == "Send")
                            _subject = "ส่งไปตรวจสอบคุณวุฒิ";

                        if (_subject == "NotSend")
                            _subject = "ยังไม่ส่งไปตรวจสอบคุณวุฒิ";

                        if (_subject == "SendReceive")
                            _subject = "ส่งไปตรวจสอบคุณวุฒิและตอบกลับมา";

                        if (_subject == "SendNotReceive")
                            _subject = "ส่งไปตรวจสอบคุณวุฒิและยังไม่ตอบกลับมา";

                        _idSectionOld = _this2.idSectionLevel1Main;
                        _idSectionNew = _this2.idSectionLevel22Main;
                        _subject = ("นักศึกษาทั้งหมดที่" + _subject + ", ปีที่เข้าศึกษา " + _this2.yearEntry);
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
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain : _param["page"]);

                    var _this1 = Util.tut.tos.audittranscriptapproved;
                    var _this2 = _this1.viewtable;
                    var _idSection;
                    var _page;
                    var _valueArray;

                    Util.tut.getDialogFormOnClick();
                    
                    if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain)
                        _idSection = _this2.idSectionLevel1Main;

                    $("#" + _idSection + "-table .table-grid .link-click").click(function () {
                        if ($(this).hasClass("link-" + Util.tut.subjectSectionAuditTranscriptApprovedLevel21ViewTable.toLowerCase()) == true ||
                            $(this).hasClass("link-" + Util.tut.subjectSectionAuditTranscriptApprovedLevel22ViewTable.toLowerCase()) == true) {
                            _valueArray = ($(this).attr("alt")).split(",");
                            _page = _valueArray[0];
                            _this2.yearEntry = _valueArray[1];
                            
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

                    var _this1 = Util.tut.tos.audittranscriptapproved;
                    var _this2 = _this1.viewtable;
                    
                    if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableProgress)
                        $("#" + _this2.idSectionLevel1Progress + "-total").html($("#" + _this2.idSectionLevel1Main + "-table .table-grid .table-row").length);
                },
                validateProcess: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this = Util.tut.tos.audittranscriptapproved;
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
    exportsaveaudittranscriptapproved: {
        idSectionMain: UDSStaffUtil.idSectionOurServicesExportSaveAuditTranscriptApprovedMain.toLowerCase(),
        idSectionPreview: UDSStaffUtil.idSectionOurServicesExportSaveAuditTranscriptApprovedPreview.toLowerCase(),
        idSectionProgress: "",
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.exportsaveaudittranscriptapproved;
                var _action;
                var _page;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });
                Util.initCheck({
                    id: "select-root"
                });

                $("#" + _this.idSectionMain + "-table .button .click-button").click(function () {
                    if ($(this).hasClass("button-exportselected") == true || $(this).hasClass("button-exportall") == true) {
                        _action = Util.tut.subjectSectionExport;
                        _page = Util.tut.pageOurServicesExportTranscriptApprovedProgress;
                        _this.idSectionProgress = Util.tut.idSectionOurServicesExportTranscriptApprovedProgress.toLowerCase();
                    }

                    if ($(this).hasClass("button-saveselected") == true) {
                        _action = Util.tut.subjectSectionSave;
                        _page = Util.tut.pageOurServicesSaveAuditTranscriptApprovedProgress;
                        _this.idSectionProgress = Util.tut.idSectionOurServicesSaveAuditTranscriptApprovedProgress.toLowerCase();
                    }

                    Util.tut.tpd.getProgress({
                        action: _action,
                        page: _page,
                        this: _this,
                        idMain: _this.idSectionMain,
                        idProgress: _this.idSectionProgress,
                        option: $(this).attr("alt")
                    });
                });
                
                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.exportsaveaudittranscriptapproved;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            },
            initTable: function () {
                Util.tut.getDialogFormOnClick();
            }
        },
        sectionPreview: {
            resetMain: function (_param) {
                _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

                var _this = Util.tut.tos.exportsaveaudittranscriptapproved;
                var _idContent = (_this.idSectionPreview + _param["section"].toLowerCase());
                var _idTableRowActive = $("#" + _this.idSectionMain + "-table .table-grid .table-row.active").attr("id");
                var _valueFileFullPath = $("#" + _idContent + "-filefullpath-hidden").val();
                var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
                var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
                var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
                var _valueDocumentStatus = (_valueSavedStatus + _valueSubmittedStatus + _valueApprovalStatus);
                var _valueSubject;
                var _objWatermark = $("#" + _idContent + "-form .picture-watermark");
                var _objImage = $("#" + _idContent + "-form img");
                var _show = false;

                if (_valueDocumentStatus == "YYY")
                    _show = true;
                else {
                    _valueSubject = Util.tut.getSubjectDocumentUpload({
                        section: _param["section"]
                    });
                    Util.dialogMessageError({
                        content: ("<div class='th-label'>สถานะการอนุมัติ" + _valueSubject["subjectth"] + "มีการเปลี่ยนแปลง กรุณารีเฟรชหน้าจอ</div><div class='en-label'>Approval status " + $.trim(_valueSubject["subjecten"]) + " is not valid, Please refresh this page.</div>")
                    });
                }

                if (_show == true) {
                    if (_objImage.is("[src]") == false) {
                        _objWatermark.hide();
                        _objImage.removeAttr("src").hide();

                        if (_valueFileFullPath.length > 0) {
                            _objWatermark.show();
                            _objImage.attr({
                                "src": _valueFileFullPath
                            }).show();
                        }
                    }
                }
            }
        },
        sectionProgress: {
            resetMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.exportsaveaudittranscriptapproved;
                    
                if (_param["page"] == Util.tut.pageOurServicesExportTranscriptApprovedProgress) {
                    Util.initCalendar({
                        id: ("#" + _this.idSectionProgress + "-sentdateaudit")
                    });
                    $("#" + _this.idSectionProgress + "-sentdateaudit").val("");
                }

                if (_param["page"] == Util.tut.pageOurServicesSaveAuditTranscriptApprovedProgress) {
                    Util.initCombobox({
                        id: ("#" + _this.idSectionProgress + "-auditedstatus"),
                        width: 480,
                        height: 29
                    });
                    Util.comboboxSetValue({
                        id: ("#" + _this.idSectionProgress + "-auditedstatus"),
                        value: "0"
                    });

                    Util.initCalendar({
                        id: ("#" + _this.idSectionProgress + "-receiveddateresultaudit")
                    });
                    $("#" + _this.idSectionProgress + "-receiveddateresultaudit").val("");
                }
            },
            validateProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this = Util.tut.tos.exportsaveaudittranscriptapproved;
                var _error = new Array();
                var _i = 0;

                if (_param["page"] == Util.tut.pageOurServicesSaveAuditTranscriptApprovedProgress) {
                    if (Util.comboboxGetValue("#" + _this.idSectionProgress + "-auditedstatus") == "0") {
                        _error[_i] = "กรุณาเลือกผลการตรวจสอบวุฒิการศึกษา;Please select result transcript audit.;";
                        _i++;
                    }

                    if ($("#" + _this.idSectionProgress + "-receiveddateresultaudit").val().length == 0) {
                        _error[_i] = "กรุณาใส่วันที่รับผลการตรวจสอบวุฒิการศึกษา;Please enter received date result transcript audit.;";
                        _i++;
                    }
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
            getResultProcess: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);

                var _this = Util.tut.tos.exportsaveaudittranscriptapproved;
                var _detailComplete = _param["resultValueProcess"].DetailComplete;
                var _idTable = (_this.idSectionMain + "-table");
                var _idTableRow;
                var _auditedStatus = "";

                var _valueArray = _detailComplete.split(",");
                var _i;

                for (_i = 0; _i < _valueArray.length; _i++) {
                    _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueArray[_i]);

                    if ($("#" + _idTableRow).length > 0) {
                        if (_param["page"] == Util.tut.pageOurServicesExportTranscriptApprovedProgress) {
                            if ($("#" + _this.idSectionProgress + "-sentdateaudit").val().length > 0)
                                $("#" + _idTableRow + " .table-col-sentdateaudit").html($("#" + _this.idSectionProgress + "-sentdateaudit").val());
                        }

                        if (_param["page"] == Util.tut.pageOurServicesSaveAuditTranscriptApprovedProgress) {
                            _auditedStatus = Util.getSelectionIsSelect({
                                id: ("#" + _this.idSectionProgress + "-auditedstatus"),
                                type: "select",
                                valueTrue: Util.comboboxGetValue("#" + _this.idSectionProgress + "-auditedstatus"),
                                valueFalse: "blank"
                            });

                            $("#" + _idTableRow + " .uploaddocument-auditedstatus").removeClass("uploaddocument-auditedstatus-blank")
                            $("#" + _idTableRow + " .uploaddocument-auditedstatus").removeClass("uploaddocument-auditedstatus-y");
                            $("#" + _idTableRow + " .uploaddocument-auditedstatus").removeClass("uploaddocument-auditedstatus-n");
                            $("#" + _idTableRow + " .uploaddocument-auditedstatus").addClass("uploaddocument-auditedstatus-" + _auditedStatus.toLowerCase());

                            if ($("#" + _this.idSectionProgress + "-receiveddateresultaudit").val().length > 0)
                                $("#" + _idTableRow + " .table-col-receiveddateresultaudit").html($("#" + _this.idSectionProgress + "-receiveddateresultaudit").val());
                        }
                    }
                }
            }
        }
    }
}