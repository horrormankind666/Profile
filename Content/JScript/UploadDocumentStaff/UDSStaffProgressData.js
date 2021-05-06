// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๐๒/๐๙/๒๕๕๘>
// Modify date  : <๒๙/๐๕/๒๕๖๒>
// Description  : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการแสดงความคืบหน้าการประมวลผลข้อมูล>
// =============================================

var UDSStaffProgressData = {
    //ฟังก์ชั่นสำหรับเริ่มต้นการแสดงความคืบหน้าการประมวลผลข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action        รับค่าการกระทำที่เกิดขึ้น
    //page          รับค่าชื่อหน้า
    //this          รับค่าชื่อออบเจ็กต์
    //idMain        รับค่าชื่อส่วนหลัก
    //idProgress    รับค่าชื่อส่วนแสดงความคืบหน้า
    //option        รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    getProgress: function (_param) {
        _param["action"]        = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]          = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]        = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]    = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]        = (_param["option"] == undefined ? "" : _param["option"]);

        var _this = this;

        if (_this.validateProgress({
                action: _param["action"],
                page: _param["page"],
                this: _param["this"],
                idMain: _param["idMain"],
                idProgress: _param["idProgress"],
                option: _param["option"]
            }))
        {
            Util.loadForm({
                index: 1,
                name: _param["page"],
                dialog: true
            }, function (_result, _e) {
                if (_result.Content.length > 0 && _e != "close")
                {
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

    //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องในส่้วนของการแสดงความคืบหน้าการประมวลผลข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action        รับค่าการกระทำที่เกิดขึ้น
    //page          รับค่าชื่อหน้า
    //this          รับค่าชื่อออบเจ็กต์
    //idMain        รับค่าชื่อส่วนหลัก
    //idProgress    รับค่าชื่อส่วนแสดงความคืบหน้า
    //option        รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    validateProgress: function (_param) {
        _param["action"]        = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]          = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]        = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]    = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]        = (_param["option"] == undefined ? "" : _param["option"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _idTable = (_param["idMain"] + "-table");
        var _objCheck = $("#" + _idTable + " input[name=select-child]:checked");

        if (_error == false && _param["option"] == "selected" && _objCheck.length == 0) { _error = true; _msgTH = "กรุณาเลือกข้อมูล"; _msgEN = "Please select a data from the list."; }
        if (_error == false && _param["option"] == "all" && $("#" + _idTable + " .table-recordcount .recordcount-search").html() == 0) { _error = true; _msgTH = "ไม่พบข้อมูล"; _msgEN = "Data not found."; }
        
        if (_error == true)
        {
            Util.dialogMessageError({
                content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
            });

            return false;
        }
        
        return true;
    },

    //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการแสดงความคืบหน้าการประมวลผลข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action        รับค่าการกระทำที่เกิดขึ้น
    //page          รับค่าชื่อหน้า
    //this          รับค่าชื่อออบเจ็กต์
    //idMain        รับค่าชื่อส่วนหลัก
    //idProgress    รับค่าชื่อส่วนแสดงความคืบหน้า
    //option        รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    initProgress: function (_param) {
        _param["action"]        = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]          = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]        = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]    = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]        = (_param["option"] == undefined ? "" : _param["option"]);

        $("#" + Util.dialogForm + "1").dialog("option", "position", { my: "center", at: "center", of: window });
        
        this.resetProgress({
            action: _param["action"],
            page: _param["page"],
            this: _param["this"],
            idMain: _param["idMain"],
            idProgress: _param["idProgress"],
            option: _param["option"]
        });
    },

    //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานให้กับการแสดงความคืบหน้าการประมวลผลข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action        รับค่าการกระทำที่เกิดขึ้น
    //page          รับค่าชื่อหน้า
    //this          รับค่าชื่อออบเจ็กต์
    //idMain        รับค่าชื่อส่วนหลัก
    //idProgress    รับค่าชื่อส่วนแสดงความคืบหน้า
    //option        รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    resetProgress: function (_param) {
        _param["action"]        = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]          = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]        = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]    = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]        = (_param["option"] == undefined ? "" : _param["option"]);
                          
        var _idTable = (_param["idMain"] + "-table");
        var _recordCount = ($("#" + _idTable + " .recordcount-search").length > 0 ? $("#" + _idTable + " .recordcount-search").html() : "");
        var _objCheck = $("#" + _idTable + " input[name=select-child]:checked");                        
        var _dataCount;
            
        Util.dialogMessageClose();

        if (_param["option"] == "selected") _dataCount = _objCheck.length;
        if (_param["option"] == "all")      _dataCount = (_recordCount.length > 0 && _recordCount != "0" ? _recordCount : "0");           

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

    //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานในส่วนของการประมวลผลข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action        รับค่าการกระทำที่เกิดขึ้น
    //page          รับค่าชื่อหน้า
    //this          รับค่าชื่อออบเจ็กต์
    //idMain        รับค่าชื่อส่วนหลัก
    //idProgress    รับค่าชื่อส่วนแสดงความคืบหน้า
    //option        รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    initProcess: function (_param) {
        _param["action"]        = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]          = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]        = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]    = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]        = (_param["option"] == undefined ? "" : _param["option"]);

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

    //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการประมวลผลข้ัอมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action        รับค่าการกระทำที่เกิดขึ้น
    //page          รับค่าชื่อหน้า
    //this          รับค่าชื่อออบเจ็กต์
    //idMain        รับค่าชื่อส่วนหลัก
    //idProgress    รับค่าชื่อส่วนแสดงความคืบหน้า
    //option        รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    confirmProcess: function (_param) {
        _param["action"]        = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]          = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]        = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]    = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]        = (_param["option"] == undefined ? "" : _param["option"]);

        var _this = this;
        var _msgTH;
        var _msgEN;
        
        if (_param["action"] == Util.tut.subjectSectionExport)
        {
            _msgTH  = "ส่งออกข้อมูล";
            _msgEN  = "export";
        }
        
        if (_param["action"] == Util.tut.subjectSectionCopy) {
            _msgTH  = "คัดลอกข้อมูล";
            _msgEN  = "copy";
        }

        if (_param["action"] == Util.tut.subjectSectionSave) {
            _msgTH  = "บันทึกข้อมูล";
            _msgEN  = "save";
        }

        Util.dialogMessageConfirm({
            content: "<div class='th-label'>ต้องการ" + _msgTH + "นี้หรือไม่</div><div class='en-label'>Do you want to " + _msgEN + " ?</div>",
            button: {
                msgYes: "OK",
                msgNo: "CANCEL"
            }
        }, function (_result) {
            if (_result == "Y")
            {
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

    //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องในการประมวลผลข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้า
    //this      รับค่าชื่อออบเจ็กต์
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

    //ฟังก์ชั่นสำหรับรับค่าสำหรับการประมวลผลข้อมูล
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action        รับค่าการกระทำที่เกิดขึ้น
    //page          รับค่าชื่อหน้า
    //this          รับค่าชื่อออบเจ็กต์
    //idMain        รับค่าชื่อส่วนหลัก
    //idProgress    รับค่าชื่อส่วนแสดงความคืบหน้า
    //option        รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    getValueProcess: function (_param) {
        _param["action"]        = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]          = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]        = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]    = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]        = (_param["option"] == undefined ? "" : _param["option"]);

        var _idTable = (_param["idMain"] + "-table");
        var _valueSelected = "";
        var _valueParam = {};
        var _valueParamSearch = "";
        var _valueProgressResult = {};
        var _valueSentDateAudit = "";
        var _valueAuditedStatus = "";
        var _valueReceivedDateResultAudit = "";

        if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableProgress)
            _valueParamSearch               = JSON.stringify(Util.tut.tse.ourservices.documentstatusstudent.valueSearch());

        if (_param["page"] == Util.tut.pageOurServicesExportProfilePictureApprovedProgress)
            _valueParamSearch               = JSON.stringify(Util.tut.tse.ourservices.exportprofilepictureapproved.valueSearch());

        if (_param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardProgress)
            _valueParamSearch               = JSON.stringify(Util.tut.tse.ourservices.exportstudentrecordsinformationforsmartcard.valueSearch());

        if (_param["page"] == Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreProgress)        
            _valueParamSearch               = JSON.stringify(Util.tut.tse.ourservices.copyprofilepictureapprovedtothestore.valueSearch());

        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableProgress)
            _valueParamSearch               = JSON.stringify(Util.tut.tse.ourservices.audittranscriptapproved.valueSearch());
        
        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveProgress)
        {
            _valueParam                     = Util.tut.tse.ourservices.audittranscriptapproved.valueSearch();
            _valueParam["yearentry"]        = _param["this"].yearEntry;
            _valueParamSearch               = JSON.stringify(_valueParam);
        }

        if (_param["page"] == Util.tut.pageOurServicesExportTranscriptApprovedProgress)
        {
            _valueParamSearch               = JSON.stringify(Util.tut.tse.ourservices.exportsaveaudittranscriptapproved.valueSearch());
            _valueSentDateAudit             = $("#" + _param["idProgress"] + "-sentdateaudit").val();
        }

        if (_param["page"] == Util.tut.pageOurServicesSaveAuditTranscriptApprovedProgress)
        {
            _valueParamSearch               = JSON.stringify(Util.tut.tse.ourservices.exportsaveaudittranscriptapproved.valueSearch());
            _valueAuditedStatus             = Util.getSelectionIsSelect({
                                                id: ("#" + _param["idProgress"] + "-auditedstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-auditedstatus")
                                              });
            _valueReceivedDateResultAudit   = $("#" + _param["idProgress"] + "-receiveddateresultaudit").val();
        }


        if (_param["option"] == "selected")
        {
            _valueParamSearch   = "";
            _valueSelected      = Util.getValueSelectCheck({
                                    id: "select-child",
                                    idParent: ("#" + _idTable)
                                  }).join("|");
        }

        if (_param["option"] == "all")
        {
            _valueParamSearch   = _valueParamSearch.replace(/({|}|")/g, "");
            _valueSelected      = "";
        }

        _valueProgressResult["paramsearch"]                     = _valueParamSearch;
        _valueProgressResult["selected"]                        = _valueSelected;
        _valueProgressResult["valuesentdateaudit"]              = _valueSentDateAudit;
        _valueProgressResult["valueauditedstatus"]              = _valueAuditedStatus;
        _valueProgressResult["valuereceiveddateresultaudit"]    = _valueReceivedDateResultAudit;
        
        return _valueProgressResult;
    },

    //ฟังก์ชั่นสำหรับเตรียมข้อมูลสำหรับประมวลผลข้อมูล
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action        รับค่าการกระทำที่เกิดขึ้น
    //page          รับค่าชื่อหน้า
    //this          รับค่าชื่อออบเจ็กต์
    //idMain        รับค่าชื่อส่วนหลัก
    //idProgress    รับค่าชื่อส่วนแสดงความคืบหน้า
    //option        รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    getProcess: function (_param) {
        _param["action"]        = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]          = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]        = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]    = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]        = (_param["option"] == undefined ? "" : _param["option"]);

        var _this1;
        var _this2 = this;
        var _idTable = (_param["idMain"] + "-table");
        var _idSection = "";
        var _valueSelected = "";
        var _valueParamSearch = "";
        var _valueProcess = {};
        var _valueSentDateAudit = "";
        var _valueAuditedStatus = "";
        var _valueReceivedDateResultAudit = "";

        _valueProcess       = _this2.getValueProcess({
                                action: _param["action"],
                                page: _param["page"],
                                this: _param["this"],
                                idMain: _param["idMain"],
                                idProgress: _param["idProgress"],
                                option: _param["option"]
                              });

        _valueParamSearch               = _valueProcess["paramsearch"];
        _valueSelected                  = _valueProcess["selected"];
        _valueSentDateAudit             = _valueProcess["valuesentdateaudit"];
        _valueAuditedStatus             = _valueProcess["valueauditedstatus"];
        _valueReceivedDateResultAudit   = _valueProcess["valuereceiveddateresultaudit"];

        $("#" + _param["idProgress"] + "-totalcomplete-content .progresstotal span").html("");
        $("#" + _param["idProgress"] + "-totalincomplete-content .progresstotal span").html("");
            
        var _send = {};
        _send["option"]                     = _param["option"];
        _send["paramsearch"]                = _valueParamSearch;
        _send["selected"]                   = _valueSelected;        
        _send["sentdateaudit"]              = _valueSentDateAudit;
        _send["auditedstatus"]              = _valueAuditedStatus;
        _send["receiveddateresultaudit"]    = _valueReceivedDateResultAudit;

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

    //ฟังก์ชั่นสำหรับส่งข้อมูลไปประมวลผลข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page              รับค่าชื่อหน้าหลัก
    //data              รับค่าข้อมูลที่ต้องการส่ง
    //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
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

    //ฟังก์ชั่นสำหรับแสดงผลการประมวลผลข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param             รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //action                รับค่าการกระทำที่เกิดขึ้น
    //page                  รับค่าชื่อหน้า
    //this                  รับค่าชื่อออบเจ็กต์
    //idMain                รับค่าชื่อส่วนหลัก
    //idProgress            รับค่าชื่อส่วนแสดงความคืบหน้า
    //option                รับค่ารูปแบบประมวลผลข้อมูล select ประมวลผลข้อมูลเฉพาะข้อมูลที่เลือก, all ประมวลผลข้อมูลทั้งหมด
    //resultValueProcess    รับค่าผลลัพธ์ของการประมวลผลข้อมูล
    //dataProcess           รับค่าชุดข้อมูลที่ใช้สำหรับประมวลผลข้อมูล
    getResultProcess: function (_param) {
        _param["action"]                = (_param["action"] == undefined ? "" : _param["action"]);
        _param["page"]                  = (_param["page"] == undefined ? "" : _param["page"]);
        _param["this"]                  = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
        _param["idMain"]                = (_param["idMain"] == undefined ? null : _param["idMain"]);
        _param["idProgress"]            = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
        _param["option"]                = (_param["option"] == undefined ? "" : _param["option"]);
        _param["resultValueProcess"]    = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
        _param["dataProcess"]           = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _totalComplete = _param["resultValueProcess"].Complete;
        var _totalIncomplete = _param["resultValueProcess"].Incomplete;
        var _totalUnitTH = "รายการ";
        var _totalUnitEN = "items";
        var _downloadFolder = _param["resultValueProcess"].DownloadFolder;
        var _downloadFile = _param["resultValueProcess"].DownloadFile;

        if (_param["action"] == Util.tut.subjectSectionExport)
        {
            _msgTH  = "ส่งออกข้อมูล";
            _msgEN  = "Export data";
        }

        if (_param["action"] == Util.tut.subjectSectionCopy)
        {
            _msgTH  = "คัดลอกข้อมูล";
            _msgEN  = "Copy data";
        }

        if (_param["action"] == Util.tut.subjectSectionSave)
        {
            _msgTH  = "บันทึกข้อมูล";
            _msgEN  = "Save data";
        }

        if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableProgress ||
            _param["page"] == Util.tut.pageOurServicesExportProfilePictureApprovedProgress ||
            _param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardProgress ||
            _param["page"] == Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveProgress ||
            _param["page"] == Util.tut.pageOurServicesExportTranscriptApprovedProgress ||
            _param["page"] == Util.tut.pageOurServicesSaveAuditTranscriptApprovedProgress)
        {
            _totalUnitTH    = "คน";
            _totalUnitEN    = "people";
        }

        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveProgress ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveProgress)
        {
            _totalUnitTH    = "โรงเรียน";
            _totalUnitEN    = "school";
        }
        
        if ($("#" + _param["idProgress"] + "-totalcomplete").length > 0)
        {
            $("#" + _param["idProgress"] + "-totalcomplete").html(_totalComplete);
            $("#" + _param["idProgress"] + "-totalcomplete-content .progresstotal span:eq(1)").html(" " + _totalUnitTH);
            $("#" + _param["idProgress"] + "-totalcomplete-content .progresstotal span:eq(2)").html(" : " + _totalUnitEN);
        }

        if ($("#" + _param["idProgress"] + "-totalincomplete").length > 0)
        {
            $("#" + _param["idProgress"] + "-totalincomplete").html(_totalIncomplete);
            $("#" + _param["idProgress"] + "-totalincomplete-content .progresstotal span:eq(1)").html(" " + _totalUnitTH);
            $("#" + _param["idProgress"] + "-totalincomplete-content .progresstotal span:eq(2)").html(" : " + _totalUnitEN);
        }

        $("#" + _param["idProgress"] + "-form .button li div").removeClass("button-start").addClass("button-save").html("SAVE ZIP FILE").css("width", "205px").bind("click", function () {
            Util.gotoPage({
                page: ("UDSStaffDownloadFile.aspx?p=" + _downloadFolder + "&f=" + _downloadFile),
                target: "frame-util"
            });
        });

        _param["this"].sectionProgress.getResultProcess({
            page: _param["page"],
            resultValueProcess: _param["resultValueProcess"]
        });

        Util.dialogMessageBox({
            content: ("<div class='th-label'>" + _msgTH + "เรียบร้อย</div><div class='en-label'>" + _msgEN + " complete</div>")
        });
    }
}