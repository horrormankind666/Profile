/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๔/๐๖/๒๕๕๘>
Modify date : <๒๙/๐๕/๒๕๖๒>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการอนุมัติเอกสาร>
=============================================
*/

var UDSStaffApproveDocument = {
    idSectionMain: UDSStaffUtil.idSectionApproveDocumentMain.toLowerCase(),
    idSectionEdit: UDSStaffUtil.idSectionApproveDocumentEdit.toLowerCase(),
    idSectionProfilePictureIdentityCardEdit: UDSStaffUtil.idSectionApproveDocumentProfilePictureIdentityCardEdit.toLowerCase(),
    idSectionProfilePictureEdit: UDSStaffUtil.idSectionApproveDocumentProfilePictureEdit.toLowerCase(),
    idSectionIdentityCardEdit: UDSStaffUtil.idSectionApproveDocumentIdentityCardEdit.toLowerCase(),
    idSectionTranscriptEdit: UDSStaffUtil.idSectionApproveDocumentTranscriptEdit.toLowerCase(),
    idSectionTranscriptInstituteEdit: UDSStaffUtil.idSectionApproveDocumentTranscriptInstituteEdit.toLowerCase(),
    idSectionTranscriptFrontsideEdit: UDSStaffUtil.idSectionApproveDocumentTranscriptFrontsideEdit.toLowerCase(),
    idSectionTranscriptBacksideEdit: UDSStaffUtil.idSectionApproveDocumentTranscriptBacksideEdit.toLowerCase(),
    
    sectionMain: {
        initMain: function () {
            var _this = Util.tut.tap;

            Util.initCombobox({
                id: ("#" + _this.idSectionMain + "-rowperpage"),
                width: 103,
                height: 25
            });

            this.resetMain();
        },
        resetMain: function () {
            var _this = Util.tut.tap;

            Util.comboboxSetValue({
                id: ("#" + _this.idSectionMain + "-rowperpage"),
                value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
            });
        },
        initTable: function () {
            Util.tut.getDialogFormOnClick();
        },
    },   
    sectionAddUpdate: {
        idSectionAddUpdate: "",
        sectionEdit: {
            initMain: function (_param) {
                _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

                var _this1 = Util.tut.tap;
                var _this2 = _this1.sectionAddUpdate;

                _this2.idSectionAddUpdate = _this1.idSectionEdit;
                _this2.initMain({
                    section: _param["section"]
                });
            },
            resetMain: function (_param) {
                _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
                
                var _this1 = Util.tut.tap;
                var _this2 = _this1.sectionAddUpdate;
            }
        },
        initMain: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tap;
            var _this2 = this;
            var _idContent = (_this2.idSectionAddUpdate + _param["section"].toLowerCase());
            var _idApprovalStatus = (_idContent + "-approvalstatus");
            var _valueApprovalStatus;

            $("#" + _idContent + "-form .uploaddocument-approvalstatus").click(function () {
                $("#" + _idContent + "-form .check-mark").hide();

                _valueApprovalStatus = ($(this).hasClass("uploaddocument-approvalstatus-y") == true ? "Y" : _valueApprovalStatus);
                _valueApprovalStatus = ($(this).hasClass("uploaddocument-approvalstatus-n") == true ? "N" : _valueApprovalStatus);

                if ($("input[name=" + _idApprovalStatus + "]:checked").val() == _valueApprovalStatus)
                    $("input[name=" + _idApprovalStatus + "]:radio").filter("[value=" + _valueApprovalStatus + "]").prop("checked", false);
                else {
                    $("#" + _idContent + "-form .uploaddocument-approvalstatus-" + _valueApprovalStatus.toLowerCase() + " .check-mark").show();
                    $("input[name=" + _idApprovalStatus + "]:radio").filter("[value=" + _valueApprovalStatus + "]").prop("checked", true);
                }
            
                if ($("input[name=" + _idApprovalStatus + "]:checked").val() == "N") {
                    Util.getFrmAddUpdateMessage({
                        page: Util.tut.pageApproveDocumentMessageAddUpdate,
                        id: Util.tut.idSectionApproveDocumentMessageAddUpdate.toLowerCase(),
                        idMessage: (_idContent + "-message-hidden")
                    });
                }
            });
            
            $("#" + _idContent + "-form ." + Util.tut.subjectSectionApproveDocument.toLowerCase() + "-preview-content .button a").click(function () {
                if ($(this).hasClass("button-save"))
                    _this2.confirmSave({
                        section: _param["section"]
                    });

                if ($(this).hasClass("button-undo"))
                    _this2.resetMain({
                        section: _param["section"]
                    });
            });
        },
        resetMain: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
                
            var _this1 = Util.tut.tap;
            var _this2 = this;
            var _idContent = (_this2.idSectionAddUpdate + _param["section"].toLowerCase());            
            var _idApprovalStatus = (_idContent + "-approvalstatus");
            var _idTableRowActive = $("#" + _this1.idSectionMain + "-table .table-grid .table-row.active").attr("id");                
            var _valueFileFullPath = $("#" + _idContent + "-filefullpath-hidden").val();
            var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
            var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
            var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
            var _valueDocumentStatus = (_valueSavedStatus + _valueSubmittedStatus + _valueApprovalStatus);
            var _valueSubject;
            var _objWatermark = $("#" + _idContent + "-form .picture-watermark");
            var _objImage = $("#" + _idContent + "-form img");
            var _show = false;

            $("input[name=" + _idApprovalStatus + "]:radio").prop("checked", false);
            $("#" + _idContent + "-form .check-mark").hide();
            $("#" + _idContent + "-form ." + Util.tut.subjectSectionApproveDocument.toLowerCase() + "-preview-content").hide();

            if ($("#" + _idTableRowActive + " .table-col-approvalstatus .uploaddocument-approvalstatus").hasClass(_param["section"].toLowerCase() + "-approvalstatus")) {
                if ($("#" + _idTableRowActive + " .table-col-approvalstatus ." + _param["section"].toLowerCase() + "-approvalstatus").hasClass("uploaddocument-approvalstatus-" + _valueApprovalStatus.toLowerCase()))
                    _show = true;
                else {
                    _valueSubject = Util.tut.getSubjectDocumentUpload({
                        section: _param["section"]
                    });
                    Util.dialogMessageError({
                        content: ("<div class='th-label'>สถานะการอนุมัติ" + _valueSubject["subjectth"] + "มีการเปลี่ยนแปลง กรุณารีเฟรชหน้าจอ</div><div class='en-label'>Approval status " + $.trim(_valueSubject["subjecten"]) + " is not valid, Please refresh this page.</div>")
                    });
                }
            }
            else
                _show = true;

            if (_show == true) {
                if (_valueDocumentStatus == "YNS" || _valueDocumentStatus == "YYS" || _valueDocumentStatus == "YYW" || _valueDocumentStatus == "YYY" || _valueDocumentStatus == "YYN") {
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
                
                if (_valueDocumentStatus == "YYS" || _valueDocumentStatus == "YYW" || _valueDocumentStatus == "YYY" || _valueDocumentStatus == "YYN") {
                    $("#" + _idContent + "-form ." + Util.tut.subjectSectionApproveDocument.toLowerCase() + "-preview-content").show();
                    $("input[name=" + _idApprovalStatus + "]:radio").filter("[value=" + _valueApprovalStatus + "]").prop("checked", true);
                    $("#" + _idContent + "-form .uploaddocument-approvalstatus-" + _valueApprovalStatus.toLowerCase() + " .check-mark").show();
                }
            }
        },
        confirmSave: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this = this;
            var _valueSubject = Util.tut.getSubjectDocumentUpload({
                section: _param["section"]
            });

            Util.dialogMessageConfirm({
                content: ("<div class='th-label'>ต้องการบันทึกผลการอนุมัติ" + _valueSubject["subjectth"] + "นี้หรือไม่</div><div class='en-label'>Do you want to save " + _valueSubject["subjecten"].toLowerCase() + " approval result ?</div>"),
                button: {
                    msgYes: "OK",
                    msgNo: "CANCEL"
                }
            }, function (_result) {
                if (_result == "Y") {
                    if (_this.validateSave({
                            section: _param["section"]
                        }))
                        _this.getSave({
                            section: _param["section"],
                            sectionAction: "approve"
                        });
                }
            });
        },
        validateSave: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tap;
            var _this2 = this;
            var _error = false;
            var _msgTH;
            var _msgEN;
            var _idContent = (_this2.idSectionAddUpdate + _param["section"].toLowerCase());
            var _idApprovalStatus = (_idContent + "-approvalstatus");
            var _valueApprovalStatus = Util.getSelectionIsSelect({
                id: _idApprovalStatus,
                type: "radio",
                valueTrue: $("input[name=" + _idApprovalStatus + "]:checked").val()
            });
            var _valueSubject = Util.tut.getSubjectDocumentUpload({
                section: _param["section"]
            });

            if (_error == false && _valueApprovalStatus == "N" && $("#" + _idContent + "-message-hidden").val().length == 0) {
                _error = true;
                _msgTH = ("กรุณาระบุเหตุผลที่ไม่อนุมัติ" + _valueSubject["subjectth"]);
                _msgEN = ("Please enter a reason not approve " + $.trim(_valueSubject["subjecten"].toLowerCase()) + ".");
            }

            if (_error == true) {
                Util.dialogMessageError({
                    content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                });

                return false;
            }

            return true;
        },
        getSave: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            _param["sectionAction"] = (_param["sectionAction"] == undefined ? "" : _param["sectionAction"]);

            var _this1 = Util.tut.tap;
            var _this2 = this;
            var _idContent = (_this2.idSectionAddUpdate + _param["section"].toLowerCase());
            var _idApprovalStatus = (_idContent + "-approvalstatus");
            var _idTableRowActive = $("#" + _this1.idSectionMain + "-table .table-grid .table-row.active").attr("id");
            var _transcriptInstitute = (_param["section"] == Util.tut.subjectSectionTranscriptFrontside || _param["section"] == Util.tut.subjectSectionTranscriptBackside ? $("#" + _this1.idSectionTranscriptInstituteEdit + "-institute-hidden").val() : "");
            var _fileName = $("#" + _idContent + "-filename-hidden").val();
            var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
            var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
            var _valueApprovalStatusOld = $("#" + _idContent + "-approvalstatus-hidden").val();
            var _valueApprovalStatus;
            var _valueApprovalDate;
            var _valueMessage = $("#" + _idContent + "-message-hidden").val();
            var _valueSave = {};
            
            _valueApprovalStatus = Util.getSelectionIsSelect({
                id: _idApprovalStatus,
                type: "radio",
                valueTrue: $("input[name=" + _idApprovalStatus + "]:checked").val(),
                valueFalse: "S"
            });
            _valueSubmittedStatus = (_valueApprovalStatus == "S" ? "N" : _valueSubmittedStatus);
            _valueMessage = (_valueApprovalStatus != "N" ? "" : _valueMessage);

            $("#" + _idContent + "-submittedstatus-hidden").val(_valueSubmittedStatus);
            $("#" + _idContent + "-approvalstatus-hidden").val(_valueApprovalStatus);
            $("#" + _idContent + "-message-hidden").val(_valueMessage);

            _valueSave["section"] = _param["section"];
            _valueSave["sectionaction"] = _param["sectionAction"];
            _valueSave["personid"] = $("#" + _this2.idSectionAddUpdate + "-personid-hidden").val();
            _valueSave["transcriptinstitute"] = _transcriptInstitute;
            _valueSave["filename"] = _fileName;
            _valueSave["savedstatus"] = _valueSavedStatus;
            _valueSave["submittedstatus"] = _valueSubmittedStatus;
            _valueSave["approvalstatus"] = _valueApprovalStatus;
            _valueSave["message"] = _valueMessage;

            Util.msgPreloading = "Saving...";

            this.actionSave({
                page: Util.tut.pageApproveDocumentEdit,
                data: _valueSave
            }, function (_resultSave, _resultValueSave) {
                if (_resultSave == true) {
                    if ($("#" + _idTableRowActive + " .table-col-approvalstatus .uploaddocument-approvalstatus").hasClass(_param["section"].toLowerCase() + "-approvalstatus")) {
                        _valueApprovalDate = (_param["section"] == Util.tut.subjectSectionProfilePicture ? _resultValueSave.ProfilePictureApprovalDate : _valueApprovalDate);
                        _valueApprovalDate = (_param["section"] == Util.tut.subjectSectionIdentityCard ? _resultValueSave.IdentityCardApprovalDate : _valueApprovalDate);
                        _valueApprovalDate = (_param["section"] == Util.tut.subjectSectionTranscriptFrontside ? _resultValueSave.TranscriptFrontsideApprovalDate : _valueApprovalDate);
                        _valueApprovalDate = (_param["section"] == Util.tut.subjectSectionTranscriptBackside ? _resultValueSave.TranscriptBacksideApprovalDate : _valueApprovalDate);
                        _valueApprovalDate = (_valueApprovalDate.length > 0 ? _valueApprovalDate : "&nbsp;");

                        $("#" + _idTableRowActive + " .table-col-approvalstatus ." + _param["section"].toLowerCase() + "-approvalstatus").removeClass("uploaddocument-approvalstatus-" + _valueApprovalStatusOld.toLowerCase()).addClass("uploaddocument-approvalstatus-" + _valueApprovalStatus.toLowerCase());
                        $("#" + _idTableRowActive + " .table-col-approvaldate ." + _param["section"].toLowerCase() + "-approvaldate").html(_valueApprovalDate);
                    }
               
                    _this2.resetMain({
                        section: _param["section"]
                    });

                    Util.dialogMessageBox({
                        content: "<div class='th-label'>บันทึกผลการอนุมัติเรียบร้อย</div><div class='en-label'>Save document approval result complete.</div>"
                    });
                }
            });
        },
        actionSave: function (_param, _callBackFunc) {        
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["data"] = (_param["data"] == undefined || _param["data"] == "" ? {} : _param["data"]);

            var _error;
            var _signinYN = "Y";
            var _send = _param["data"];
            _send["signinyn"] = _signinYN;

            Util.actionSave({
                action: "save",
                page: _param["page"],
                data: _send
            }, function (_result) {
                _error = Util.tut.getErrorMsg({
                    signinYN: _signinYN,
                    pageError: 0,
                    cookieError: _result.CookieError,
                    userError: _result.UserError,
                    saveError: _result.SaveError
                });

                _callBackFunc((_error == false ? true : false), _result);
            });
        },
    }
}