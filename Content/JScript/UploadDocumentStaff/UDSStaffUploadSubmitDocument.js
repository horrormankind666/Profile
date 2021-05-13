/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๕/๐๘/๒๕๕๘>
Modify date : <๒๙/๐๕/๒๕๖๒>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา>
=============================================
*/

var UDSStaffUploadSubmitDocument = {
    idSectionMain: UDSStaffUtil.idSectionUploadSubmitDocumentMain.toLowerCase(),
    idSectionPreview: UDSStaffUtil.idSectionUploadSubmitDocumentPreview.toLowerCase(),
    idSectionAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentAddUpdate.toLowerCase(),    
    sectionMain: {
        initMain: function () {
            var _this = Util.tut.tus;

            Util.initCombobox({
                id: ("#" + _this.idSectionMain + "-rowperpage"),
                width: 103,
                height: 25
            });

            this.resetMain();
        },
        resetMain: function () {
            var _this = Util.tut.tus;

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

            var _this = Util.tut.tus;
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
        
            $("#" + _idContent + "-form ." + Util.tut.subjectSectionUploadSubmitDocument.toLowerCase() + "-preview-content").hide();
            
            if ($("#" + _idTableRowActive + " .table-col-submittedstatus .uploaddocument-submittedstatus").hasClass(_param["section"].toLowerCase() + "-submittedstatus")) {
                if ($("#" + _idTableRowActive + " .table-col-submittedstatus ." + _param["section"].toLowerCase() + "-submittedstatus").hasClass("uploaddocument-submittedstatus-" + _valueSubmittedStatus.toLowerCase()))
                    _show = true;
                else {
                    _valueSubject = Util.tut.getSubjectDocumentUpload({
                        section: _param["section"]
                    });
                    Util.dialogMessageError({
                        content: ("<div class='th-label'>สถานะการส่ง" + _valueSubject["subjectth"] + "มีการเปลี่ยนแปลง กรุณารีเฟรชหน้าจอ</div><div class='en-label'>Submitted status " + $.trim(_valueSubject["subjecten"]) + " is not valid, Please refresh this page.</div>")
                    });
                }
            }
            else
                _show = true;

            if (_show == true) {
                if (_valueDocumentStatus == "NNS" || _valueDocumentStatus == "YNS" || _valueDocumentStatus == "YYS" || _valueDocumentStatus == "YYW" || _valueDocumentStatus == "YYY" || _valueDocumentStatus == "YYN") {
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

                    $("#" + _idContent + "-form ." + Util.tut.subjectSectionUploadSubmitDocument.toLowerCase() + "-preview-content").show();
                    $("#" + _idContent + "-form .uploaddocument-submittedstatus").addClass("uploaddocument-submittedstatus-" + _valueSubmittedStatus.toLowerCase());
                }
            }
        },
    },    
    sectionAddUpdate: {
        initMain: function () {
            this.setMenuLayout();
            this.initMenu();
            this.initMainSection({
                section: Util.tut.subjectSectionStudentRecords
            });
        },
        setMenuLayout: function () {
            var _this = Util.tut.tus;

            if ($("#" + _this.idSectionAddUpdate + "-menu").length > 0)
                $("#" + _this.idSectionAddUpdate + "-menu").height($(window).height() - Util.offsetTop);
        },
        initMenu: function () {
            var _this1 = Util.tut.tus;
            var _this2 = this;            
            
            Util.initTab({
                id: ("#" + _this1.idSectionAddUpdate + "-menu-content"),
                idContent: ("#" + _this1.idSectionAddUpdate + "-content"),
                classActive: "menu-active",
                classNoActive: "menu-noactive",
            }, function (_result) {
                var _idLink = _result;
                var _page = $("#" + _idLink).attr("alt")

                Util.getTabOnClick({
                    idLink: _idLink,
                    data: $("#" + _this2.studentrecords.idSectionAddUpdate + "-personid-hidden").val(),
                    loadFormRepeat: true
                }, function (_result) {
                    if (_result == true) {
                        _this2.initMainSection({
                            page: _page
                        });
                        
                        Util.tut.getDialogFormOnClick();

                        if (_page == Util.tut.pageUploadSubmitDocumentProfilePictureAddUpdate)
                            _this2.getFrmRecommend({
                                page: Util.tut.pageRecommendUploadProfilePictureMain
                            }, function () {
                            });

                        if (_page == Util.tut.pageUploadSubmitDocumentIdentityCardAddUpdate)
                            _this2.getFrmRecommend({
                                page: Util.tut.pageRecommendUploadIdentityCardMain
                            }, function () {
                            });

                        if (_page == Util.tut.pageUploadSubmitDocumentTranscriptAddUpdate)
                            _this2.getFrmRecommend({
                                page: Util.tut.pageRecommendUploadTranscriptMain
                            }, function () {
                            });
                    }
                });
            });
        },
        initMainSection: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            
            if (_param["page"] == Util.tut.pageUploadSubmitDocumentStudentRecordsAddUpdate || _param["section"] == Util.tut.subjectSectionStudentRecords)
                this.studentrecords.initMain();

            if (_param["page"] == Util.tut.pageUploadSubmitDocumentOverviewAddUpdate || _param["section"] == Util.tut.subjectSectionOverview)
                this.overview.initMain();

            if (_param["page"] == Util.tut.pageUploadSubmitDocumentProfilePictureAddUpdate || _param["section"] == Util.tut.subjectSectionProfilePicture)
                this.profilepicture.initMain();

            if (_param["page"] == Util.tut.pageUploadSubmitDocumentIdentityCardAddUpdate || _param["section"] == Util.tut.subjectSectionIdentityCard)
                this.identitycard.initMain();

            if (_param["page"] == Util.tut.pageUploadSubmitDocumentTranscriptAddUpdate || _param["section"] == Util.tut.subjectSectionTranscript)
                this.transcript.initMain();
        },
        getFrmRecommend: function (_param, _callBackFunc) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

            Util.loadForm({
                index: 1,
                name: _param["page"],
                dialog: true
            }, function (_result, _e) {
                $("#" + Util.dialogPreloading).dialog("close");
                _callBackFunc(_result, _e);
            });
        },
        getMsgRecommend: function (_param) {
            _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);

            var _msgTH;
            var _msgEN;
            var _valueMsg = {};

            if (_param["action"] == "browse") {
                _msgTH = "คลิก \"BROWSE\" เพื่อเลือกไฟล์";
                _msgEN = " : Click \"BROWSE\" to select a file";
            }

            if (_param["action"] == "save") {
                _msgTH = "คลิกลากรูปเพื่อปรับตำแหน่ง";
                _msgEN = " : Drag the image to adjust position";
            }

            if (_param["action"] == "submit") {
                _msgTH = "คลิก \"SUBMIT\" เพื่อส่งเอกสารให้เจ้าหน้าที่พิจารณาอนุมัติ";
                _msgEN = " : Click \"SUBMIT\" to send document to the authorities for approval";
            }

            _valueMsg["msgth"] = _msgTH;
            _valueMsg["msgen"] = _msgEN;

            return _valueMsg;
        },
        setStatusUploadDocument: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            _param["savedStatus"] = (_param["savedStatus"] == undefined ? "" : _param["savedStatus"]);
            _param["submittedStatus"] = (_param["submittedStatus"] == undefined ? "" : _param["submittedStatus"]);
            _param["approvalStatus"] = (_param["approvalStatus"] == undefined ? "" : _param["approvalStatus"]);

            var _this = Util.tut.tus;
            var _idContent = (_this.idSectionAddUpdate + _param["section"].toLowerCase());

            $("#" + _idContent + "-savedstatus-hidden").val(_param["savedStatus"]);
            $("#" + _idContent + "-submittedstatus-hidden").val(_param["submittedStatus"]);
            $("#" + _idContent + "-approvalstatus-hidden").val(_param["approvalStatus"]);
        },
        initUploadFile: function () {
            var _this1 = Util.tut.tus;
            var _this2 = this;

            Util.initUploadFile();
        
            $(".uploadfile-button").click(function () {            
                var _idUploadFileButton = $(this).attr("id");
                var _section = $(this).attr("alt");
                var _page;

                if ($("#" + _idUploadFileButton).hasClass("disable") == false) {   
                    Util.dialogMessageClose();

                    if (_idUploadFileButton == ("clear-uploadfile-" + _section.toLowerCase())) {
                        if (_section == Util.tut.subjectSectionProfilePicture)
                            _this2.profilepicture.resetMain();

                        if (_section == Util.tut.subjectSectionIdentityCard)
                            _this2.identitycard.resetMain();

                        if (_section == Util.tut.subjectSectionTranscriptFrontside)
                            _this2.transcript.resetMainSection({
                                section: _section
                            });

                        if (_section == Util.tut.subjectSectionTranscriptBackside)
                            _this2.transcript.resetMainSection({
                                section: _section
                            });
                    }

                    if (_idUploadFileButton == ("upload-uploadfile-" + _section.toLowerCase())) {
                        if (_section == Util.tut.subjectSectionProfilePicture)
                            _page = Util.tut.pageRecommendUploadProfilePictureMain;

                        if (_section == Util.tut.subjectSectionIdentityCard)
                            _page = Util.tut.pageRecommendUploadIdentityCardMain;

                        if (_section == Util.tut.subjectSectionTranscriptFrontside)
                            _page = Util.tut.pageRecommendUploadTranscriptFrontsideMain;

                        if (_section == Util.tut.subjectSectionTranscriptBackside)
                            _page = Util.tut.pageRecommendUploadTranscriptBacksideMain;

                        _this2.getFrmRecommend({
                            page: _page
                        }, function (_result, _e) {
                            if (_e == "close")
                                _this2.confirmUploadFile({
                                    section: _section
                                });
                        });
                    }

                    if (_idUploadFileButton == ("save-uploadfile-" + _section.toLowerCase()))
                        _this2.confirmSaveFile({
                            section: _section
                        });

                    if (_idUploadFileButton == ("delete-uploadfile-" + _section.toLowerCase()))
                        _this2.confirmRemoveFile({
                            section: _section
                        });

                    if (_idUploadFileButton == ("submit-uploadfile-" + _section.toLowerCase())) {
                        _this2.getFrmRecommend({
                            page: Util.tut.pageRecommendSubmitMain
                        }, function (_result, _e) {
                            if (_e == "close")
                                _this2.confirmSubmitFile({
                                    section: _section
                                });
                        });
                    }
                }
            })
        },
        setFrmUploadFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            _param["uploadedStatus"] = (_param["uploadedStatus"] == undefined ? "" : _param["uploadedStatus"]);

            var _this = Util.tut.tus;
            var _idContent = (_this.idSectionAddUpdate + _param["section"].toLowerCase());
            var _valueFileDir = $("#" + _idContent + "-filedir-hidden").val();
            var _valueFileName = $("#" + _idContent + "-filename-hidden").val();
            var _valueWidth = $("#" + _idContent + "-width-hidden").val();
            var _valueHeight = $("#" + _idContent + "-height-hidden").val();
            var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
            var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
            var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
            var _valueDocumentStatus = (_valueSavedStatus + _valueSubmittedStatus + _valueApprovalStatus);
            var _valueMsg;
            var _objImage = $("#" + _idContent + "-image");
            var _objRecommend = $("#" + _idContent + "-recommend");
            var _objUploadFileForm = $("#uploadfile-" + _param["section"].toLowerCase() + "-form");
            var _objUploadFileLabel = $("#uploadfile-" + _param["section"].toLowerCase() + "-label");
            var _objInputUploadFile = $("#" + _param["section"].toLowerCase() + "-browse-uploadfile");
            var _objBrowseUploadFile = $("#browse-uploadfile-" + _param["section"].toLowerCase());
            var _objClearUploadFile = $("#clear-uploadfile-" + _param["section"].toLowerCase());
            var _objUploadUploadFile = $("#upload-uploadfile-" + _param["section"].toLowerCase());
            var _objSaveUploadFile = $("#save-uploadfile-" + _param["section"].toLowerCase());
            var _objDeleteUploadFile = $("#delete-uploadfile-" + _param["section"].toLowerCase());
            var _objSubmitUploadFile = $("#submit-uploadfile-" + _param["section"].toLowerCase());

            _objImage.removeAttr("src").hide();
            $(".jwc_image").css({ "cursor": "default" });
            _objRecommend.hide();
            _objUploadFileForm.trigger("reset");
            _objUploadFileLabel.html("").hide();
            _objInputUploadFile.hide();
            _objBrowseUploadFile.addClass("disable");
            _objClearUploadFile.addClass("disable");
            _objUploadUploadFile.addClass("disable");
            _objSaveUploadFile.addClass("disable");
            _objDeleteUploadFile.addClass("disable");
            _objSubmitUploadFile.addClass("disable");

            if ((_param["uploadedStatus"].length == 0 || _param["uploadedStatus"] == "N") && (_valueDocumentStatus.length == 0 || _valueDocumentStatus == "NNS")) {
                _valueMsg = this.getMsgRecommend({
                    action: "browse"
                });

                _objRecommend.show();
                _objUploadFileLabel.html(_valueMsg["msgth"] + _valueMsg["msgen"]).show();
                _objInputUploadFile.show();
                _objBrowseUploadFile.removeClass("disable");
                _objClearUploadFile.removeClass("disable");
                _objUploadUploadFile.removeClass("disable");
            }
        
            if (_param["uploadedStatus"] == "Y" && _valueDocumentStatus == "NNS") {
                _valueMsg = this.getMsgRecommend({
                    action: "save"
                });

                if (_valueFileDir.length > 0 && _valueFileName.length > 0)
                    _objImage.attr({
                        "src": (_valueFileDir + "/" + _valueFileName),
                        "width": (_valueWidth + "px"),
                        "height": (_valueHeight + "px")
                    }).show();

                $(".jwc_image").css({
                    "cursor": "move"
                });
                _objUploadFileLabel.html(_valueMsg["msgth"] + _valueMsg["msgen"]).show();
                _objSaveUploadFile.removeClass("disable");
                _objDeleteUploadFile.removeClass("disable");
            }

            if (_param["uploadedStatus"] == "Y" && _valueDocumentStatus == "YNS") {
                _valueMsg = this.getMsgRecommend({
                    action: "submit"
                });

                if (_valueFileDir.length > 0 && _valueFileName.length > 0)
                    _objImage.attr({
                        "src": (_valueFileDir + "/" + _valueFileName),
                        "width": (_valueWidth + "px"),
                        "height": (_valueHeight + "px")
                    }).show();

                _objUploadFileLabel.html(_valueMsg["msgth"] + _valueMsg["msgen"]).show();
                _objDeleteUploadFile.removeClass("disable");
                _objSubmitUploadFile.removeClass("disable");
            }
        
            if (_param["uploadedStatus"] == "Y" && (_valueDocumentStatus == "YYS" || _valueDocumentStatus == "YYW" || _valueDocumentStatus == "YYY" || _valueDocumentStatus == "YYN")) {
                if (_valueFileDir.length > 0 && _valueFileName.length > 0)
                    _objImage.attr({
                        "src": (_valueFileDir + "/" + _valueFileName),
                        "width": (_valueWidth + "px"),
                        "height": (_valueHeight + "px")
                    }).show();

                if (_valueApprovalStatus == "N")
                    _objDeleteUploadFile.removeClass("disable");
            }
        },        
        studentrecords: {
            idSectionAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentStudentRecordsAddUpdate.toLowerCase(),
            initMain: function () {
                var _this = Util.tut.tus;

                $("#" + _this.idSectionAddUpdate + "-studentcode").html($("#" + this.idSectionAddUpdate + "-studentcode-hidden").val());

                this.resetMain();
            },
            resetMain: function () {
                Util.dialogMessageClose();
                Util.gotoTopElement();
                
                if ($("#" + this.idSectionAddUpdate + "-studentpicture-hidden").val().length > 0) {
                    $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content .picture-watermark").show();
                    $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content img").prop({
                        "src": $("#" + this.idSectionAddUpdate + "-studentpicture-hidden").val()
                    }).show();
                }
                else {
                    $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content .picture-watermark").hide();
                    $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content img").hide();
                }
            }
        },        
        overview: {
            idSectionAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentOverviewAddUpdate.toLowerCase(),
            setMainLayout: function () {
                var _idContentLayout = $("#" + this.idSectionAddUpdate + "-form .form .form-layout");
                var _idContentPicture = $("#" + this.idSectionAddUpdate + "-form .picture-content");            
                var _idContentLabelCol = $("#" + this.idSectionAddUpdate + "-form .form .form-labelcol");
                var _idContentInputCol = $("#" + this.idSectionAddUpdate + "-form .form .form-inputcol");

                _idContentInputCol.width(_idContentLayout.width() - _idContentPicture.width() - _idContentLabelCol.width() - 55);
            },
            initMain: function () {
                var _this = this;
                var _idContentProfilePicture = (this.idSectionAddUpdate + "-form ." + Util.tut.subjectSectionProfilePicture.toLowerCase() + "-content");
                var _idContentIdentityCard = (this.idSectionAddUpdate + "-form ." + Util.tut.subjectSectionIdentityCard.toLowerCase() + "-content");
                var _idContentTranscriptFrontside = (this.idSectionAddUpdate + "-form ." + Util.tut.subjectSectionTranscriptFrontside.toLowerCase() + "-content");
                var _idContentTranscriptBackside = (this.idSectionAddUpdate + "-form ." + Util.tut.subjectSectionTranscriptBackside.toLowerCase() + "-content");

                $("#" + this.idSectionAddUpdate + "-form .picture-content").hover(
                    function () {                
                        if ($(this).hasClass(Util.tut.subjectSectionProfilePicture.toLowerCase() + "-content") &&
                            $("#" + _idContentProfilePicture + " img").is(":visible"))
                            $("#" + _idContentProfilePicture + " .picture-zoom").show();

                        if ($(this).hasClass(Util.tut.subjectSectionIdentityCard.toLowerCase() + "-content") &&
                            $("#" + _idContentIdentityCard + " img").is(":visible"))
                            $("#" + _idContentIdentityCard + " .picture-zoom").show();

                        if ($(this).hasClass(Util.tut.subjectSectionTranscriptFrontside.toLowerCase() + "-content") &&
                            $("#" + _idContentTranscriptFrontside + " img").is(":visible"))
                            $("#" + _idContentTranscriptFrontside + " .picture-zoom").show();

                        if ($(this).hasClass(Util.tut.subjectSectionTranscriptBackside.toLowerCase() + "-content") &&
                            $("#" + _idContentTranscriptBackside + " img").is(":visible"))
                            $("#" + _idContentTranscriptBackside + " .picture-zoom").show();
                    },
                    function () {
                        if ($(this).hasClass(Util.tut.subjectSectionProfilePicture.toLowerCase() + "-content") &&
                            $("#" + _idContentProfilePicture + " img").is(":visible"))
                            $("#" + _idContentProfilePicture + " .picture-zoom").hide();

                        if ($(this).hasClass(Util.tut.subjectSectionIdentityCard.toLowerCase() + "-content") &&
                            $("#" + _idContentIdentityCard + " img").is(":visible"))
                            $("#" + _idContentIdentityCard + " .picture-zoom").hide();

                        if ($(this).hasClass(Util.tut.subjectSectionTranscriptFrontside.toLowerCase() + "-content") &&
                            $("#" + _idContentTranscriptFrontside + " img").is(":visible"))
                            $("#" + _idContentTranscriptFrontside + " .picture-zoom").hide();

                        if ($(this).hasClass(Util.tut.subjectSectionTranscriptBackside.toLowerCase() + "-content") &&
                            $("#" + _idContentTranscriptBackside + " img").is(":visible"))
                            $("#" + _idContentTranscriptBackside + " .picture-zoom").hide();
                    }
                );
            
                $("#" + this.idSectionAddUpdate + "-form .picture-zoom").click(function () {
                    var _page = $(this).attr("alt")
                    var _valueFileDir = $("#" + _this.idSectionAddUpdate + "-" + _page.replace("View", "").replace("Main", "").toLowerCase() + "filedir-hidden").val();
                    var _valueFileName = $("#" + _this.idSectionAddUpdate + "-" + _page.replace("View", "").replace("Main", "").toLowerCase() + "filename-hidden").val();

                    Util.tut.getFrmViewDocument({
                        page: _page,
                        fileDir: _valueFileDir,
                        fileName: _valueFileName
                    });
                });

                this.setMainLayout();
                this.resetMain();
            },
            resetMain: function () {                
                var _this = Util.tut.tus;
                var _fileArray;
                var _fileType;
                var _documentUpload = new Array();
                var _documentUploadDetail = new Array();
                var _section;
                var _idContent;
                var _callFunc;
                var _i = 0;

                _documentUpload[0] = Util.tut.subjectSectionProfilePicture;
                _documentUpload[1] = Util.tut.subjectSectionIdentityCard;
                _documentUpload[2] = Util.tut.subjectSectionTranscriptFrontside;
                _documentUpload[3] = Util.tut.subjectSectionTranscriptBackside;

                Util.dialogMessageClose();
                Util.gotoTopElement();            
                Util.resetForm({
                    id: (this.idSectionAddUpdate + "-form")
                });

                for (_i = 0; _i < _documentUpload.length; _i++) {
                    _section = _documentUpload[_i];
                    _documentUploadDetail[0] = (_section + "InstituteNameTH");
                    _documentUploadDetail[1] = (_section + "InstituteNameEN");
                    _documentUploadDetail[2] = (_section + "InstituteCountryNameTH");
                    _documentUploadDetail[3] = (_section + "InstituteCountryNameEN");
                    _documentUploadDetail[4] = (_section + "InstituteProvinceNameTH");
                    _documentUploadDetail[5] = (_section + "InstituteProvinceNameEN");
                    _documentUploadDetail[6] = (_section + "FileName");
                    _documentUploadDetail[7] = (_section + "FullPath");
                    _documentUploadDetail[8] = (_section + "FileType");
                    _documentUploadDetail[9] = (_section + "FileSize");
                    _documentUploadDetail[10] = (_section + "SavedDate");
                    _documentUploadDetail[11] = (_section + "SubmittedStatus");
                    _documentUploadDetail[12] = (_section + "ApprovalStatus");
                    _documentUploadDetail[13] = (_section + "ApprovalDate");
                    _documentUploadDetail[14] = (_section + "Message");

                    if ($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[7].toLowerCase() + "-hidden").val().length > 0) {
                        $("#" + this.idSectionAddUpdate + "-" + _section.toLowerCase() + "-form ." + _section.toLowerCase() + "-content .picture-watermark").show();
                        $("#" + this.idSectionAddUpdate + "-" + _section.toLowerCase() + "-form ." + _section.toLowerCase() + "-content img").prop({
                            "src": $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[7].toLowerCase() + "-hidden").val()
                        }).show();
                    }

                    if (_section == Util.tut.subjectSectionTranscriptFrontside || _section == Util.tut.subjectSectionTranscriptBackside) {
                        $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[0].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[0].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[1].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[1].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[2].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[2].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[3].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[3].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[4].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[4].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[5].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[5].toLowerCase() + "-hidden").val());
                    }

                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[6].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[6].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[8].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[8].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[9].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[9].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[10].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[10].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[11].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[11].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[12].toLowerCase())
                        .addClass(Util.tut.getIconApprovalStatus({
                            status: $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[12].toLowerCase() + "-hidden").val()
                        }));
                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[13].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[13].toLowerCase() + "-hidden").val());

                    if ($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[14].toLowerCase() + "-hidden").val().length > 0) {
                        _callFunc = "Util.getFrmViewMessage({" +
                                    "page:'" + Util.tut.pageViewMessageMain + "'," +
                                    "id:'" + Util.tut.idSectionViewMessageMain.toLowerCase() + "'," +
                                    "idMessage:'" + (this.idSectionAddUpdate + "-" + _documentUploadDetail[14].toLowerCase() + "-hidden") + "'" +
                                    "})";
                        
                        $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[14].toLowerCase()).html("<a class='th-label' href='javascript:void(0)' onclick=" + _callFunc + ">Click to Read Message</a>");
                    }
                }
            },
        },
        profilepicture: {
            idSectionAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentProfilePictureAddUpdate.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;

                _this2.initUploadFile();
                
                $("." + Util.tut.subjectSectionProfilePicture.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this2.getFrmRecommend({
                        page: Util.tut.pageRecommendUploadProfilePictureMain
                    }, function () {
                    });
                });
                
                this.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;
                var _idProfilePictureExample = $("#" + this.idSectionAddUpdate + "-form .profilepicture-example");
                var _valueGender = $("#" + _this2.studentrecords.idSectionAddUpdate + "-gender-hidden").val();
                var _valueUpload = $("#" + this.idSectionAddUpdate + "-savedstatus-hidden").val();

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionAddUpdate + "-form")
                });
                
                if (_valueGender == "M") _idProfilePictureExample.css({
                    "background-position": "0px -501px"
                });

                if (_valueGender == "F") _idProfilePictureExample.css({
                    "background-position": "-230px -501px"
                });
              
                _this2.setFrmUploadFile({
                    section: Util.tut.subjectSectionProfilePicture,
                    uploadedStatus: _valueUpload
                });
            },
        },        
        identitycard: {
            idSectionAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentIdentityCardAddUpdate.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;

                _this2.initUploadFile();

                $("." + Util.tut.subjectSectionIdentityCard.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this2.getFrmRecommend({
                        page: Util.tut.pageRecommendUploadIdentityCardMain
                    }, function () { });
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;
                var _valueUpload = $("#" + this.idSectionAddUpdate + "-savedstatus-hidden").val();

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionAddUpdate + "-form")
                });

                _this2.setFrmUploadFile({
                    section: Util.tut.subjectSectionIdentityCard,
                    uploadedStatus: _valueUpload
                });
            },
        },        
        transcript: {
            idSectionAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentTranscriptAddUpdate.toLowerCase(),
            idSectionTranscriptInstituteAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase(),
            idSectionTranscriptFrontsideAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentTranscriptFrontsideAddUpdate.toLowerCase(),
            idSectionTranscriptBacksideAddUpdate: UDSStaffUtil.idSectionUploadSubmitDocumentTranscriptBacksideAddUpdate.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;

                Util.initCombobox({
                    id: ("#" + this.idSectionTranscriptInstituteAddUpdate + "-institutecountry"),
                    width: 463,
                    height: 29
                });
                _this2.initUploadFile();

                $("." + Util.tut.subjectSectionTranscriptFrontside.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this2.getFrmRecommend({
                        page: Util.tut.pageRecommendUploadTranscriptFrontsideMain
                    }, function () {
                    });
                });

                $("." + Util.tut.subjectSectionTranscriptBackside.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this2.getFrmRecommend({
                        page: Util.tut.pageRecommendUploadTranscriptBacksideMain
                    }, function () {
                    });
                });
            
                this.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _valueUploadTranscriptFrontside = $("#" + this.idSectionTranscriptFrontsideAddUpdate + "-savedstatus-hidden").val();
                var _valueUploadTranscriptBackside = $("#" + this.idSectionTranscriptBacksideAddUpdate + "-savedstatus-hidden").val();

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionAddUpdate + "-form")
                });
                
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionTranscriptInstituteAddUpdate + "-institutecountry"),
                    value: $("#" + this.idSectionTranscriptInstituteAddUpdate + "-institutecountry-hidden").val()
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionTranscriptInstituteAddUpdate + "-instituteprovince"),
                    value: $("#" + this.idSectionTranscriptInstituteAddUpdate + "-instituteprovince-hidden").val()
                }, function () {
                    Util.tut.setSelectDefaultCombobox({
                        id: ("#" + _this3.idSectionTranscriptInstituteAddUpdate + "-institute"),
                        value: $("#" + _this3.idSectionTranscriptInstituteAddUpdate + "-institute-hidden").val()
                    }, function () {
                    });
                });

                _this2.setFrmUploadFile({
                    section: Util.tut.subjectSectionTranscriptFrontside,
                    uploadedStatus: _valueUploadTranscriptFrontside
                });
                _this2.setFrmUploadFile({
                    section: Util.tut.subjectSectionTranscriptBackside,
                    uploadedStatus: _valueUploadTranscriptBackside
                });
            },
            resetMainSection: function (_param) {
                _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;
                var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
                var _idSection;
                var _valueUpload = $("#" + _idContent + "-savedstatus-hidden").val();

                Util.dialogMessageClose();

                if (_param["section"] == Util.tut.subjectSectionTranscriptFrontside) {
                    _idSection = this.idSectionTranscriptFrontsideAddUpdate;
                    Util.gotoTopElement();                
                }

                if (_param["section"] == Util.tut.subjectSectionTranscriptBackside) {
                    _idSection = this.idSectionTranscriptBacksideAddUpdate;

                    Util.gotoElement({
                        anchorName: ("#" + _idSection + "-form"),
                        top: (Util.offsetTop + 10)
                    });

                }

                Util.resetForm({
                    id: (_idSection + "-form")
                });

                _this2.setFrmUploadFile({
                    section: _param["section"],
                    uploadedStatus: _valueUpload
                });
            },
        },
        confirmUploadFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;

            Util.dialogMessageConfirm({
                content: "<div class='th-label'>ต้องการอัพโหลดไฟล์นี้หรือไม่</div><div class='en-label'>Do you want to upload this file ?</div>",
                button: {
                    msgYes: "OK",
                    msgNo: "CANCEL"
                }
            }, function (_result) {
                if (_result == "Y") {
                    if (_this2.validateUploadFile({ 
                            section: _param["section"]
                        })) {
                        $("#uploadfile-" + _param["section"].toLowerCase() + "-form #uploadfile-personid").val($("#" + _this2.studentrecords.idSectionAddUpdate + "-personid-hidden").val());
                        $("#uploadfile-" + _param["section"].toLowerCase() + "-form").attr("method", "POST");
                        $("#uploadfile-" + _param["section"].toLowerCase() + "-form").submit();
                    }
                }
            });
        },
        validateUploadFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _error = false;
            var _msgTH;
            var _msgEN;
            var _valueBrowseUploadFile = $("#uploadfile-" + _param["section"].toLowerCase() + "-label").html();
            var _value = _valueBrowseUploadFile.split(".");
            
            if (_error == false && _value.length < 2) {
                _error = true;
                _msgTH = "กรุณาเลือกไฟล์";
                _msgEN = "Please browse to select a file.";
            }

            if (_error == false && Util.tut.supportFileType.indexOf(_value[_value.length - 1]) < 0) {
                _error = true;
                _msgTH = "นามสกุลของไฟล์ไม่ถูกต้อง";
                _msgEN = "Invalid file type.";
            }

            if (_error == true) {
                Util.dialogMessageError({
                    content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                });

                return false;
            }

            return true;
        },
        stopUploadFile: function (_param) {
            _param["result"] = (_param["result"] == undefined ? "" : _param["result"]);
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            _param["fileDir"] = (_param["fileDir"] == undefined ? "" : _param["fileDir"]);
            _param["fileName"] = (_param["fileName"] == undefined ? "" : _param["fileName"]);
            _param["width"] = (_param["width"] == undefined ? "" : _param["width"]);
            _param["height"] = (_param["height"] == undefined ? "" : _param["height"]);
            _param["widthShow"] = (_param["widthShow"] == undefined ? "" : _param["widthShow"]);
            _param["heightShow"] = (_param["heightShow"] == undefined ? "" : _param["heightShow"]);
                        
            var _this = Util.tut.tus;
            var _idContent = (_this.idSectionAddUpdate + _param["section"].toLowerCase());
            var _idImage = ("#" + _idContent + "-image");

            $("#" + Util.dialogPreloading).dialog("close");

            if (_param["result"] == 0)
            {
                Util.dialogMessageBox({
                    content: "<div class='th-label'>อัพโหลดไฟล์เรียบร้อย</div><div class='en-label'>Upload file complete</div>"
                });

                Util.initDragAndCropImage({
                    id: _idImage,
                    width: _param["widthShow"],
                    height: _param["heightShow"]
                }, function (_result) {
                    $("#" + _idContent + "-cropx-hidden").val(_result.CropX);
                    $("#" + _idContent + "-cropy-hidden").val(_result.CropY);
                });

                $("#" + _idContent + "-filedir-hidden").val(_param["fileDir"]);
                $("#" + _idContent + "-filename-hidden").val(_param["fileName"]);
                $("#" + _idContent + "-width-hidden").val(_param["width"]);
                $("#" + _idContent + "-height-hidden").val(_param["height"]);
                this.setStatusUploadDocument({
                    section: _param["section"],
                    savedStatus: "N",
                    submittedStatus: "N",
                    approvalStatus: "S"
                });
                this.setFrmUploadFile({
                    section: _param["section"],
                    uploadedStatus: "Y"
                });
            }
            else {
                var _error = false;
                var _msgTH;
                var _msgEN;
                    
                if (_error == false && _param["result"] == 1) {
                    _error = true;
                    _msgTH = "อัพโหลดไฟล์ไม่สำเร็จ";
                    _msgEN = "Upload file was not successful.";
                }

                if (_error == false && _param["result"] == 2) {
                    _error = true;
                    _msgTH = "ขนาดของไฟล์ไม่ถูกต้อง";
                    _msgEN = "Invalid file size.";
                }

                if (_error == true)
                    Util.dialogMessageError({
                        content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                    });
            }
        },
        confirmSaveFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;

            Util.dialogMessageConfirm({
                content: "<div class='th-label'>ต้องการบันทึกไฟล์นี้หรือไม่</div><div class='en-label'>Do you want to save this file ?</div>",
                button: {
                    msgYes: "OK",
                    msgNo: "CANCEL"
                }
            }, function (_result) {
                if (_result == "Y")
                    _this2.getSaveFile({
                        section: _param["section"]
                    });
            });
        },
        getSaveFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
            var _valueSaveFile = {};
            _valueSaveFile["personid"] = $("#" + this.studentrecords.idSectionAddUpdate + "-personid-hidden").val();
            _valueSaveFile["section"] = _param["section"];
            _valueSaveFile["filedir"] = $("#" + _idContent + "-filedir-hidden").val();
            _valueSaveFile["filename"] = $("#" + _idContent + "-filename-hidden").val();
            _valueSaveFile["cropx"] = $("#" + _idContent + "-cropx-hidden").val();
            _valueSaveFile["cropy"] = $("#" + _idContent + "-cropy-hidden").val();

            this.actionSaveFile({
                section: _param["section"],
                data: _valueSaveFile
            }, function (_resultSaveFile, _resultValueSaveFile) {
                if (_resultSaveFile == false) {
                    Util.dialogMessageError({
                        content: ("<div class='th-label'>บันทึกไฟล์ไม่สำเร็จ</div><div class='en-label'>Save file was not successful.</div>")
                    });

                    $("#" + _idContent + "-filedir-hidden").val("");
                    $("#" + _idContent + "-filename-hidden").val("");
                    $("#" + _idContent + "-width-hidden").val("");
                    $("#" + _idContent + "height-hidden").val("");
                    _this2.setStatusUploadDocument({
                        section: _param["section"],
                        savedStatus: "N",
                        submittedStatus: "N",
                        approvalStatus: "S"
                    });
                    _this2.setFrmUploadFile({
                        section: _param["section"],
                        uploadedStatus: "N"
                    });
                }
                else {
                    Util.dialogMessageBox({
                        content: "<div class='th-label'>บันทึกไฟล์เรียบร้อย</div><div class='en-label'>Save file complete.</div>"
                    });

                    _this2.setFrmUploadFile({
                        section: _param["section"],
                        uploadedStatus: "Y"
                    });
                }
            });
        },
        actionSaveFile: function (_param, _callBackFunc) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            _param["data"] = (_param["data"] == undefined || _param["data"] == "" ? {} : _param["data"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
            var _error = false;
            var _send = _param["data"];

            Util.msgPreloading = "Saving...";

            Util.actionSaveFile({
                data: _send
            }, function (_result) {
                if (_result.Error == 0) {
                    $("#" + _idContent + "-filedir-hidden").val(_result.FileDir);
                    $("#" + _idContent + "-filename-hidden").val(_result.FileName);
                    $("#" + _idContent + "-width-hidden").val(_result.WidthShow);
                    $("#" + _idContent + "-height-hidden").val(_result.HeightShow);
                    _this2.setStatusUploadDocument({
                        section: _param["section"],
                        savedStatus: "Y",
                        submittedStatus: "N",
                        approvalStatus: "S"
                    });
                    
                    _this2.getSave({
                        section: _param["section"],
                        sectionAction: "save"
                    }, function (_resultSave, _resultValueSave) {
                        if (_resultSave == true) {
                            if (_resultValueSave.SaveError != 0)
                                _error = true;
                        }
                        else
                            _error = true;
                        
                        _callBackFunc((_error == false ? true : false), _result);
                    });
                }
                else
                    _callBackFunc(false, _result);
            });
        },
        confirmRemoveFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;

            Util.dialogMessageConfirm({
                content: "<div class='th-label'>ต้องการลบไฟล์นี้หรือไม่</div><div class='en-label'>Do you want to remove this file ?</div>",
                button: {
                    msgYes: "OK",
                    msgNo: "CANCEL"
                }
            }, function (_result) {
                if (_result == "Y")
                    _this2.getRemoveFile({
                        section: _param["section"]
                    });
            });
        },
        getRemoveFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
            var _error = false;
            var _valueRemoveFile = {};
            _valueRemoveFile["filedir"] = $("#" + _idContent + "-filedir-hidden").val();
            _valueRemoveFile["filename"] = $("#" + _idContent + "-filename-hidden").val();
            
            this.actionRemoveFile({
                section: _param["section"],
                data: _valueRemoveFile
            }, function (_resultRemoveFile, _resultValueRemoveFile) {
                if (_resultRemoveFile == false) {
                    if (_error == false && _resultValueRemoveFile.Error == 1) {
                        _error = true;
                        _msgTH = "ลบไฟล์ไม่สำเร็จ";
                        _msgEN = "Remove file was not successful.";
                    }

                    if (_error == false && _resultValueRemoveFile.Error == 2) {
                        _error = true;
                        _msgTH = "ไม่พบไฟล์ที่ต้องการลบ";
                        _msgEN = "File not found.";
                    }

                    if (_error == true)
                        Util.dialogMessageError({
                            content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                        });

                    $("#" + _idContent + "-filedir-hidden").val("");
                    $("#" + _idContent + "-filename-hidden").val("");
                    $("#" + _idContent + "-width-hidden").val("");
                    $("#" + _idContent + "height-hidden").val("");
                    _this2.setStatusUploadDocument({
                        section: _param["section"],
                        savedStatus: "N",
                        submittedStatus: "N",
                        approvalStatus: "S"
                    });
                    _this2.setFrmUploadFile({
                        section: _param["section"],
                        uploadedStatus: "N"
                    });
                }
                else {
                    Util.dialogMessageBox({
                        content: "<div class='th-label'>ลบไฟล์เรียบร้อย</div><div class='en-label'>Remove file complete.</div>"
                    });

                    _this2.setFrmUploadFile({
                        section: _param["section"],
                        uploadedStatus: "N"
                    });
                }
            });
        },
        actionRemoveFile: function (_param, _callBackFunc) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            _param["data"] = (_param["data"] == undefined || _param["data"] == "" ? {} : _param["data"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
            var _error = false;
            var _send = _param["data"];

            Util.msgPreloading = "Removing...";

            Util.actionRemoveFile({
                data: _send
            }, function (_result) {
                if (_result.Error == 0) {
                    $("#" + _idContent + "-filedir-hidden").val("");
                    $("#" + _idContent + "-filename-hidden").val("");
                    $("#" + _idContent + "-width-hidden").val("");
                    $("#" + _idContent + "-height-hidden").val("");
                    _this2.setStatusUploadDocument({
                        section: _param["section"],
                        savedStatus: "N",
                        submittedStatus: "N",
                        approvalStatus: "S"
                    });
                    
                    _this2.getSave({
                        section: _param["section"],
                        sectionAction: "save"
                    }, function (_resultSave, _resultValueSave) {
                        if (_resultSave == true) {
                            if (_resultValueSave.SaveError != 0)
                                _error = true;
                        }
                        else
                            _error = true;
                        
                        _callBackFunc((_error == false ? true : false), _result);
                    });
                }
                else
                    _callBackFunc(false, _result);
            });
        },
        confirmSubmitFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;

            Util.dialogMessageConfirm({
                content: "<div class='th-label'>ต้องการส่งไฟล์นี้หรือไม่</div><div class='en-label'>Do you want to submit these files ?</div>",
                button: {
                    msgYes: "OK",
                    msgNo: "CANCEL"
                }
            }, function (_result) {
                if (_result == "Y") {
                    if (_this2.validateSubmitFile({ 
                            section: _param["section"]
                        }))
                        _this2.getSubmitFile({
                            section: _param["section"]
                        });
                }
            });
        },
        validateSubmitFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this = Util.tut.tus;
            var _error = false;
            var _idContent = (_this.idSectionAddUpdate + _param["section"].toLowerCase());
            var _valueSavedStatus = ($("#" + _idContent + "-savedstatus-hidden").val());
            var _i = 0;

            if (_error == false && _valueSavedStatus == "N") {
                _error = true;
                _msgTH = "กรุณาบันทึกไฟล์";
                _msgEN = "Please save file.";
            }

            if (_error == false && _valueSavedStatus == "Y" && (_param["section"] == Util.tut.subjectSectionTranscriptFrontside || _param["section"] == Util.tut.subjectSectionTranscriptBackside) && Util.comboboxGetValue("#" + this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute") == "0") {
                _error = true;
                _msgTH = "กรุณาเลือกโรงเรียน / สถาบัน";
                _msgEN = "Please select institute.";
            }

            if (_error == true) {
                Util.dialogMessageError({
                    content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                });

                return false;
            }

            return true;
        },
        getSubmitFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;

            this.setStatusUploadDocument({
                section: _param["section"],
                savedStatus: "Y",
                submittedStatus: "Y",
                approvalStatus: "W"
            });

            this.actionSubmitfile({
                section: _param["section"]
            }, function (_resultSubmitfile) {
                if (_resultSubmitfile == false) {
                    Util.dialogMessageError({
                        content: "<div class='th-label'>ส่งไฟล์ไม่สำเร็จ</div><div class='en-label'>Submit these files was not successful.</div>"
                    });                    
                    _this2.setStatusUploadDocument({
                        section: _param["section"], 
                        savedStatus: "Y",
                        submittedStatus: "N",
                        approvalStatus: "S"
                    });
                    _this2.setFrmUploadFile({
                        section: _param["section"],
                        uploadedStatus: "Y"
                    });
                }
                else {
                    Util.dialogMessageBox({
                        content: "<div class='th-label'>ส่งไฟล์เรียบร้อย</div><div class='en-label'>Submit file complete.</div>"
                    });

                    _this2.setFrmUploadFile({
                        section: _param["section"],
                        uploadedStatus: "Y"
                    });
                }
            });
        },
        actionSubmitfile: function (_param, _callBackFunc) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _error = false;

            Util.msgPreloading = "Submitting...";

            this.getSave({
                section: _param["section"],
                sectionAction: "submit"
            }, function (_resultSave, _resultValueSave) {
                if (_resultSave == true) {
                    if (_resultValueSave.SaveError != 0)
                        _error = true;
                }
                else
                    _error = true;

                _callBackFunc(_error == false ? true : false);
            });
        },
        getSave: function (_param, _callBackFunc) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            _param["sectionAction"] = (_param["sectionAction"] == undefined ? "" : _param["sectionAction"]);

            var _this = Util.tut.tus;
            var _idContent = (_this.idSectionAddUpdate + _param["section"].toLowerCase());
            var _error = false;
            var _transcriptInstitute = "";
            var _fileName = $("#" + _idContent + "-filename-hidden").val();
            var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
            var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
            var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
            var _valueSave = {};

            if (_param["section"] == Util.tut.subjectSectionTranscriptFrontside || _param["section"] == Util.tut.subjectSectionTranscriptBackside)
                _transcriptInstitute = Util.getSelectionIsSelect({
                    id: ("#" + this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute")
                });

            _valueSave["section"] = _param["section"];
            _valueSave["sectionaction"] = _param["sectionAction"];
            _valueSave["personid"] = $("#" + this.studentrecords.idSectionAddUpdate + "-personid-hidden").val();
            _valueSave["transcriptinstitute"] = _transcriptInstitute;
            _valueSave["filename"] = _fileName;
            _valueSave["savedstatus"] = _valueSavedStatus;
            _valueSave["submittedstatus"] = _valueSubmittedStatus;
            _valueSave["approvalstatus"] = _valueApprovalStatus;

            this.actionSave({
                page: Util.tut.pageUploadSubmitDocumentAddUpdate,
                data: _valueSave
            }, function (_resultSave, _resultValueSave) {
                _callBackFunc(_resultSave, _resultValueSave)
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