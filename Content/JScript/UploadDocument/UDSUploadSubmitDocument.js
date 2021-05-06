// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๘/๐๕/๒๕๕๘>
// Modify date  : <๑๑/๐๗/๒๕๕๙>
// Description  : <รวมรวบฟังก์ชั่นสำหรับใช้งานฟังก์ชั่นทั่วไปในส่วนของการอัพโหลดเอกสารของนักศึกษา>
// =============================================

var UDSUploadSubmitDocument = {
    idSectionMain: UDSUtil.idSectionUploadSubmitDocumentMain.toLowerCase(),
    idSectionAddUpdate: UDSUtil.idSectionUploadSubmitDocumentAddUpdate.toLowerCase(),

    sectionMain: {
        //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับหน้าหลักในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
        initMain: function () {
            this.setMenuLayout();
            this.initMenu();
            this.initMainSection({
                section: Util.tut.subjectSectionStudentRecords
            });
        },

        //ฟังก์ชั่นสำหรับกำหนดการแสดงผลให้กับเมนูการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
        setMenuLayout: function () {
            var _this = Util.tut.tus;

            if ($("#" + _this.idSectionMain + "-menu").length > 0)
                $("#" + _this.idSectionMain + "-menu").height($(window).height() - Util.offsetTop);
        },

        //ฟังก์ชั่นสำหรับกำหนดให้ทำงานตามเหตุการณ์ต่าง ๆ ที่เกิดขึ้นบนเมนูการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
        initMenu: function () {
            var _this1 = Util.tut.tus;
            var _this2 = _this1.sectionAddUpdate;
            var _this3 = this;

            Util.initTab({
                id: ("#" + _this1.idSectionMain + "-menu-content"),
                idContent: ("#" + _this1.idSectionAddUpdate + "-content"),
                classActive: "menu-active",
                classNoActive: "menu-noactive",
            }, function (_result) {
                var _idLink = _result;
                var _page = $("#" + _idLink).attr("alt");

                Util.getTabOnClick({
                    idLink: _idLink,
                    data: $("#" + _this2.studentrecords.idSectionAddUpdate + "-personid-hidden").val(),
                    loadFormRepeat: true
                }, function (_result) {
                    if (_result == true)
                    {                    
                        _this3.initMainSection({
                            page: _page
                        });
                        
                        Util.tut.getDialogFormOnClick();

                        if (_page == Util.tut.pageUploadSubmitDocumentProfilePictureAddUpdate)  _this2.getFrmRecommend({ page: Util.tut.pageRecommendUploadProfilePictureMain }, function () { });
                        if (_page == Util.tut.pageUploadSubmitDocumentIdentityCardAddUpdate)    _this2.getFrmRecommend({ page: Util.tut.pageRecommendUploadIdentityCardMain }, function () { });
                        if (_page == Util.tut.pageUploadSubmitDocumentTranscriptAddUpdate)      _this2.getFrmRecommend({ page: Util.tut.pageRecommendUploadTranscriptMain }, function () { });
                    }
                });
            });
        },

        //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษาตามหัวข้อต่าง ๆ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //page      รับค่าชื่อหน้า
        //section   รับค่าชื่อหัวข้อที่ต้องการ
        initMainSection: function (_param) {
            _param["page"]      = (_param["page"] == undefined ? "" : _param["page"]);
            _param["section"]   = (_param["section"] == undefined ? "" : _param["section"]);
            
            var _this1 = Util.tut.tus;
            var _this2 = _this1.sectionAddUpdate;

            if (_param["page"] == Util.tut.pageUploadSubmitDocumentStudentRecordsAddUpdate || _param["section"] == Util.tut.subjectSectionStudentRecords)   _this2.studentrecords.initMain();
            if (_param["page"] == Util.tut.pageUploadSubmitDocumentOverviewAddUpdate || _param["section"] == Util.tut.subjectSectionOverview)               _this2.overview.initMain();
            if (_param["page"] == Util.tut.pageUploadSubmitDocumentProfilePictureAddUpdate || _param["section"] == Util.tut.subjectSectionProfilePicture)   _this2.profilepicture.initMain();
            if (_param["page"] == Util.tut.pageUploadSubmitDocumentIdentityCardAddUpdate || _param["section"] == Util.tut.subjectSectionIdentityCard)       _this2.identitycard.initMain();
            if (_param["page"] == Util.tut.pageUploadSubmitDocumentTranscriptAddUpdate ||_param["section"] == Util.tut.subjectSectionTranscript)            _this2.transcript.initMain();            
        },
    },

    sectionAddUpdate: {
        //ฟังก์ชั่นสำหรับแสดงหน้าข้อความสำหรับคำแนะนำการอัพโหลดเอกสารของนักศึกษาตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //page              รับค่าชื่อหน้า
        //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
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

        //ฟังก์ชั่นสำหรับแสดงข้อความแนะนำการอัพโหลดเอกสารของนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //action    รับค่าการกระทำ
        getMsgRecommend: function (_param) {
            _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);

            var _msgTH;
            var _msgEN;
            var _valueMsg = {};

            if (_param["action"] == "browse")
            {        
                _msgTH = "คลิก \"BROWSE\" เพื่อเลือกไฟล์";
                _msgEN = " : Click \"BROWSE\" to select a file";
            }

            if (_param["action"] == "save")
            {
                _msgTH = "คลิกลากรูปเพื่อปรับตำแหน่ง";
                _msgEN = " : Drag the image to adjust position";
            }

            if (_param["action"] == "submit")
            {
                _msgTH = "คลิก \"SUBMIT\" เพื่อส่งเอกสารให้เจ้าหน้าที่พิจารณาอนุมัติ";
                _msgEN = " : Click \"SUBMIT\" to send document to the authorities for approval";
            }

            _valueMsg["msgth"] = _msgTH;
            _valueMsg["msgen"] = _msgEN;

            return _valueMsg;
        },

        //ฟังก์ชั่นสำหรับกำหนดสถานะการอัพโหลดเอกสารของนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section           รับค่าชื่อหัวข้อที่ต้องการ
        //savedStatus       รับค่าสถานะการบันทึกการอัพโหลดเอกสารของนักศึกษา
        //submittedStatus   รับค่าสถานะการยืนยันการส่งเอกสารที่นักศึกษาอัพโหลด
        //approvalStatus    รับค่าสถานะการอนุมัตืเอกสารที่นักศึกษาอัพโหลด
        setStatusUploadDocument: function (_param) {
            _param["section"]           = (_param["section"] == undefined ? "" : _param["section"]);
            _param["savedStatus"]       = (_param["savedStatus"] == undefined ? "" : _param["savedStatus"]);
            _param["submittedStatus"]   = (_param["submittedStatus"] == undefined ? "" : _param["submittedStatus"]);
            _param["approvalStatus"]    = (_param["approvalStatus"] == undefined ? "" : _param["approvalStatus"]);

            var _this = Util.tut.tus;
            var _idContent = (_this.idSectionAddUpdate + _param["section"].toLowerCase());

            $("#" + _idContent + "-savedstatus-hidden").val(_param["savedStatus"]);
            $("#" + _idContent + "-submittedstatus-hidden").val(_param["submittedStatus"]);
            $("#" + _idContent + "-approvalstatus-hidden").val(_param["approvalStatus"]);
        },

        //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการอัพโหลดเอกสารในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา
        initUploadFile: function () {
            var _this1 = Util.tut.tus;
            var _this2 = this;

            Util.initUploadFile();
        
            $(".uploadfile-button").click(function () {            
                var _idUploadFileButton = $(this).attr("id");
                var _section = $(this).attr("alt");
                var _page;

                if ($("#" + _idUploadFileButton).hasClass("disable") == false)
                {   
                    Util.dialogMessageClose();

                    if (_idUploadFileButton == ("clear-uploadfile-" + _section.toLowerCase()))
                    {
                        if (_section == Util.tut.subjectSectionProfilePicture)      _this2.profilepicture.resetMain();
                        if (_section == Util.tut.subjectSectionIdentityCard)        _this2.identitycard.resetMain();
                        if (_section == Util.tut.subjectSectionTranscriptFrontside) _this2.transcript.resetMainSection({ section: _section });
                        if (_section == Util.tut.subjectSectionTranscriptBackside)  _this2.transcript.resetMainSection({ section: _section });
                    }

                    if (_idUploadFileButton == ("upload-uploadfile-" + _section.toLowerCase()))
                    {
                        if (_section == Util.tut.subjectSectionProfilePicture)      _page = Util.tut.pageRecommendUploadProfilePictureMain;
                        if (_section == Util.tut.subjectSectionIdentityCard)        _page = Util.tut.pageRecommendUploadIdentityCardMain;
                        if (_section == Util.tut.subjectSectionTranscriptFrontside) _page = Util.tut.pageRecommendUploadTranscriptFrontsideMain;
                        if (_section == Util.tut.subjectSectionTranscriptBackside)  _page = Util.tut.pageRecommendUploadTranscriptBacksideMain;

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

                    if (_idUploadFileButton == ("submit-uploadfile-" + _section.toLowerCase()))                
                    {
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

        //ฟังก์ชั่นสำหรับกำหนดการแสดงผลหน้าการอัพโหลดเอกสารของนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section           รับค่าชื่อหัวข้อที่ต้องการ
        //uploadedStatus    รับค่าสถานะการอัพโหลดเอกสารของนักศึกษา
        setFrmUploadFile: function (_param) {
            _param["section"]           = (_param["section"] == undefined ? "" : _param["section"]);
            _param["uploadedStatus"]    = (_param["uploadedStatus"] == undefined ? "" : _param["uploadedStatus"]);

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

            if ((_param["uploadedStatus"].length == 0 || _param["uploadedStatus"] == "N") && (_valueDocumentStatus.length == 0 || _valueDocumentStatus == "NNS"))
            {
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
        
            if (_param["uploadedStatus"] == "Y" && _valueDocumentStatus == "NNS")
            {            
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

            if (_param["uploadedStatus"] == "Y" && _valueDocumentStatus == "YNS")
            {
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
        
            if (_param["uploadedStatus"] == "Y" && (_valueDocumentStatus == "YYS" || _valueDocumentStatus == "YYW" || _valueDocumentStatus == "YYY" || _valueDocumentStatus == "YYN"))
            {
                if (_valueFileDir.length > 0 && _valueFileName.length > 0)
                    _objImage.attr({
                        "src": (_valueFileDir + "/" + _valueFileName),
                        "width": (_valueWidth + "px"),
                        "height": (_valueHeight + "px")
                    }).show();
                if (_valueApprovalStatus == "N") _objDeleteUploadFile.removeClass("disable");
            }
        },

        studentrecords: {
            idSectionAddUpdate: UDSUtil.idSectionUploadSubmitDocumentStudentRecordsAddUpdate.toLowerCase(),
            
            //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการเพิ่มหรือแก้ไขในส่วนของข้อมูลการเป็นนักศึกษาในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
            initMain: function () {
                var _this = Util.tut.tus;

                this.resetMain();
            },
            
            //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานให้กับการแสดงข้อมูลการเป็นนักศึกษาในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
            resetMain: function () {
                Util.gotoTopElement();
                
                if ($("#" + this.idSectionAddUpdate + "-studentpicture-hidden").val().length > 0)
                {
                    $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content .picture-watermark").show();
                    $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content img").prop({ "src": $("#" + this.idSectionAddUpdate + "-studentpicture-hidden").val() }).show();
                }
                else
                    {
                        $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content .picture-watermark").hide();
                        $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content img").hide();
                    }
            }
        },

        overview: {
            idSectionAddUpdate: UDSUtil.idSectionUploadSubmitDocumentOverviewAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการแสดงผลให้กับผลการอัพโหลดเอกสารในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
            setMainLayout: function () {
                var _idContentLayout = $("#" + this.idSectionAddUpdate + "-form .form .form-layout");
                var _idContentPicture = $("#" + this.idSectionAddUpdate + "-form .picture-content");
                var _idContentLabelCol = $("#" + this.idSectionAddUpdate + "-form .form .form-labelcol");
                var _idContentInputCol = $("#" + this.idSectionAddUpdate + "-form .form .form-inputcol");

                _idContentInputCol.width(_idContentLayout.width() - _idContentPicture.width() - _idContentLabelCol.width() - 55);
            },

            //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับผลการอัพโหลดเอกสารในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
            initMain: function () {
                var _this = this;
                var _idContentProfilePicture = (this.idSectionAddUpdate + "-form ." + Util.tut.subjectSectionProfilePicture.toLowerCase() + "-content");
                var _idContentIdentityCard = (this.idSectionAddUpdate + "-form ." + Util.tut.subjectSectionIdentityCard.toLowerCase() + "-content");
                var _idContentTranscriptFrontside = (this.idSectionAddUpdate + "-form ." + Util.tut.subjectSectionTranscriptFrontside.toLowerCase() + "-content");
                var _idContentTranscriptBackside = (this.idSectionAddUpdate + "-form ." + Util.tut.subjectSectionTranscriptBackside.toLowerCase() + "-content");

                $("#" + this.idSectionAddUpdate + "-form .picture-content").hover(
                    function () {
                        if ($(this).hasClass(Util.tut.subjectSectionProfilePicture.toLowerCase() + "-content") && $("#" + _idContentProfilePicture + " img").is(":visible")) $("#" + _idContentProfilePicture + " .picture-zoom").show();
                        if ($(this).hasClass(Util.tut.subjectSectionIdentityCard.toLowerCase() + "-content") && $("#" + _idContentIdentityCard + " img").is(":visible")) $("#" + _idContentIdentityCard + " .picture-zoom").show();
                        if ($(this).hasClass(Util.tut.subjectSectionTranscriptFrontside.toLowerCase() + "-content") && $("#" + _idContentTranscriptFrontside + " img").is(":visible")) $("#" + _idContentTranscriptFrontside + " .picture-zoom").show();
                        if ($(this).hasClass(Util.tut.subjectSectionTranscriptBackside.toLowerCase() + "-content") && $("#" + _idContentTranscriptBackside + " img").is(":visible")) $("#" + _idContentTranscriptBackside + " .picture-zoom").show();
                    },
                    function () {
                        if ($(this).hasClass(Util.tut.subjectSectionProfilePicture.toLowerCase() + "-content") && $("#" + _idContentProfilePicture + " img").is(":visible")) $("#" + _idContentProfilePicture + " .picture-zoom").hide();
                        if ($(this).hasClass(Util.tut.subjectSectionIdentityCard.toLowerCase() + "-content") && $("#" + _idContentIdentityCard + " img").is(":visible")) $("#" + _idContentIdentityCard + " .picture-zoom").hide();
                        if ($(this).hasClass(Util.tut.subjectSectionTranscriptFrontside.toLowerCase() + "-content") && $("#" + _idContentTranscriptFrontside + " img").is(":visible")) $("#" + _idContentTranscriptFrontside + " .picture-zoom").hide();
                        if ($(this).hasClass(Util.tut.subjectSectionTranscriptBackside.toLowerCase() + "-content") && $("#" + _idContentTranscriptBackside + " img").is(":visible")) $("#" + _idContentTranscriptBackside + " .picture-zoom").hide();
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

            //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานให้กับผลการอัพโหลดเอกสารในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
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

                Util.gotoTopElement();            
                Util.resetForm({
                    id: (this.idSectionAddUpdate + "-form")
                });

                for (_i = 0; _i < _documentUpload.length; _i++)
                {
                    _section = _documentUpload[_i];
                    _documentUploadDetail[0]  = (_section + "InstituteNameTH");
                    _documentUploadDetail[1]  = (_section + "InstituteNameEN");
                    _documentUploadDetail[2]  = (_section + "InstituteCountryNameTH");
                    _documentUploadDetail[3]  = (_section + "InstituteCountryNameEN");
                    _documentUploadDetail[4]  = (_section + "InstituteProvinceNameTH");
                    _documentUploadDetail[5]  = (_section + "InstituteProvinceNameEN");
                    _documentUploadDetail[6]  = (_section + "FileName");
                    _documentUploadDetail[7]  = (_section + "FullPath");
                    _documentUploadDetail[8]  = (_section + "FileType");
                    _documentUploadDetail[9]  = (_section + "FileSize");
                    _documentUploadDetail[10] = (_section + "SavedDate");
                    _documentUploadDetail[11] = (_section + "SubmittedStatus");
                    _documentUploadDetail[12] = (_section + "ApprovalStatus");
                    _documentUploadDetail[13] = (_section + "ApprovalDate");
                    _documentUploadDetail[14] = (_section + "Message");
                    
                    if ($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[7].toLowerCase() + "-hidden").val().length > 0)
                    {
                        $("#" + this.idSectionAddUpdate + "-" + _section.toLowerCase() + "-form ." + _section.toLowerCase() + "-content .picture-watermark").show();
                        $("#" + this.idSectionAddUpdate + "-" + _section.toLowerCase() + "-form ." + _section.toLowerCase() + "-content img").prop({ "src": $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[7].toLowerCase() + "-hidden").val() }).show();
                    }

                    if (_section == Util.tut.subjectSectionTranscriptFrontside || _section == Util.tut.subjectSectionTranscriptBackside)
                    {
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
                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[12].toLowerCase()).addClass(Util.tut.getIconApprovalStatus({ status: $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[12].toLowerCase() + "-hidden").val() }));
                    $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[13].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[13].toLowerCase() + "-hidden").val());

                    if ($("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[14].toLowerCase() + "-hidden").val().length > 0)
                    {                    
                        _callFunc = "Util.getFrmViewMessage({" +
                                    "page:'" + Util.tut.pageViewMessageMain + "'," +
                                    "id:'" + Util.tut.idSectionViewMessageMain.toLowerCase() + "'," +
                                    "idMessage:'" + (this.idSectionAddUpdate + "-" + _documentUploadDetail[14].toLowerCase() + "-hidden") + "'" +
                                    "})";
                        
                        $("#" + this.idSectionAddUpdate + "-" + _documentUploadDetail[14].toLowerCase()).html("<a class='th-label' href='javascript:void(0)' onclick=" + _callFunc + ">Click to Read Message</a>");
                    }
                }
            }
        },

        profilepicture: {
            idSectionAddUpdate: UDSUtil.idSectionUploadSubmitDocumentProfilePictureAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการอัพโหลดรูปภาพประจำตัวในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
            initMain: function () {
                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;

                _this2.initUploadFile();

                $("." + Util.tut.subjectSectionProfilePicture.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this2.getFrmRecommend({
                        page: Util.tut.pageRecommendUploadProfilePictureMain
                    }, function () { });
                });

                this.resetMain();
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานให้กับการอัพโหลดรูปภาพประจำตัวในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
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
                
                if (_valueGender == "M") _idProfilePictureExample.css({ "background-position": "0px -501px" });
                if (_valueGender == "F") _idProfilePictureExample.css({ "background-position": "-230px -501px" });
              
                _this2.setFrmUploadFile({
                    section: Util.tut.subjectSectionProfilePicture,
                    uploadedStatus: _valueUpload
                });
            }
        },

        identitycard: {
            idSectionAddUpdate: UDSUtil.idSectionUploadSubmitDocumentIdentityCardAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการอัพโหลดบัตรประจำตัวประชาชนในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
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
            
            //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานให้กับการอัพโหลดบัตรประจำตัวประชาชนในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
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
            }
        },

        transcript: {
            idSectionAddUpdate: UDSUtil.idSectionUploadSubmitDocumentTranscriptAddUpdate.toLowerCase(),
            idSectionTranscriptInstituteAddUpdate: UDSUtil.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase(),
            idSectionTranscriptFrontsideAddUpdate: UDSUtil.idSectionUploadSubmitDocumentTranscriptFrontsideAddUpdate.toLowerCase(),
            idSectionTranscriptBacksideAddUpdate: UDSUtil.idSectionUploadSubmitDocumentTranscriptBacksideAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการอัพโหลดระเบียนแสดงผลการเรียนในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
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
                    }, function () { });
                });

                $("." + Util.tut.subjectSectionTranscriptBackside.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this2.getFrmRecommend({
                        page: Util.tut.pageRecommendUploadTranscriptBacksideMain
                    }, function () { });
                });
            
                this.resetMain();
            },
            
            //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานให้กับการอัพโหลดระเบียนแสดงผลการเรียนในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
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
                    }, function () { });
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

            //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานให้กับการอัพโหลดระเบียนแสดงผลการเรียนในแต่ละด้านในส่วนของการเพิ่มหรือแก้ไขในส่วนของการอัพโหลดและส่งเอกสารของนักศึกษา
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //section   รับค่าชื่อหัวข้อที่ต้องการ
            resetMainSection: function (_param) {
                _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

                var _this1 = Util.tut.tus;
                var _this2 = _this1.sectionAddUpdate;
                var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
                var _idSection;
                var _valueUpload = $("#" + _idContent + "-savedstatus-hidden").val();

                Util.dialogMessageClose();
                if (_param["section"] == Util.tut.subjectSectionTranscriptFrontside)
                {                
                    _idSection = this.idSectionTranscriptFrontsideAddUpdate;
                    Util.gotoTopElement();                
                }
                if (_param["section"] == Util.tut.subjectSectionTranscriptBackside)
                {
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
            }
        },

        //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการอัพโหลดเอกสารของนักศึกษาตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
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
                if (_result == "Y")
                {
                    if (_this2.validateUploadFile({ 
                            section: _param["section"]
                        }))
                    {
                        $("#uploadfile-" + _param["section"].toLowerCase() + "-form #uploadfile-personid").val($("#" + _this2.studentrecords.idSectionAddUpdate + "-personid-hidden").val());
                        $("#uploadfile-" + _param["section"].toLowerCase() + "-form").attr("method", "POST");
                        $("#uploadfile-" + _param["section"].toLowerCase() + "-form").submit();
                    }
                }
            });
        },

        //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องในการอัพโหลดเอกสารของนักศึกษาตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
        validateUploadFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _error = false;
            var _msgTH;
            var _msgEN;
            var _valueBrowseUploadFile = $("#uploadfile-" + _param["section"].toLowerCase() + "-label").html();
            var _value = _valueBrowseUploadFile.split(".");
            
            if (_error == false && _value.length < 2) { _error = true; _msgTH = "กรุณาเลือกไฟล์"; _msgEN = "Please browse to select a file."; }
            if (_error == false && Util.tut.supportFileType.indexOf(_value[_value.length - 1]) < 0) { _error = true; _msgTH = "นามสกุลของไฟล์ไม่ถูกต้อง"; _msgEN = "Invalid file type."; }

            if (_error == true)
            {
                Util.dialogMessageError({
                    content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                });
                return false;
            }

            return true;
        },

        //ฟังก์ชั่นสำหรับหยุดการอัพโหลดเอกสารของนักศึกษา แล้วรับค่าจากการอัพโหลดใน C# มาทำงาน
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //result        รับค่าผลการอัพโหลดเอกสารของนักศึกษา
        //section       รับค่าชื่อหัวข้อที่ต้องการ
        //fileDir       รับค่าชื่อ Directory ที่เก็บไฟล์ที่ได้อัพโหลดเอกสารของนักศึกษา
        //fileName      รับค่าชื่อ File ที่ได้จากการอัพโหลดเอกสารของนักศึกษา
        //width         รับค่าชื่อความกว้างของเอกสารที่นักศึกษาอัพโหลด
        //height        รับค่าชื่อความสูงของเอกสารที่นักศึกษาอัพโหลด
        //widthShow     รับค่าชื่อความกว้างของเอกสารที่นักศึกษาอัพโหลดสำหรับแสดง
        //heightShow    รับค่าชื่อความสูงของเอกสารที่นักศึกษาอัพโหลดสำหรับแสดง
        stopUploadFile: function (_param) {
            _param["result"]        = (_param["result"] == undefined ? "" : _param["result"]);
            _param["section"]       = (_param["section"] == undefined ? "" : _param["section"]);
            _param["fileDir"]       = (_param["fileDir"] == undefined ? "" : _param["fileDir"]);
            _param["fileName"]      = (_param["fileName"] == undefined ? "" : _param["fileName"]);
            _param["width"]         = (_param["width"] == undefined ? "" : _param["width"]);
            _param["height"]        = (_param["height"] == undefined ? "" : _param["height"]);
            _param["widthShow"]     = (_param["widthShow"] == undefined ? "" : _param["widthShow"]);
            _param["heightShow"]    = (_param["heightShow"] == undefined ? "" : _param["heightShow"]);
                        
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
            else
                {
                    var _error = false;
                    var _msgTH;
                    var _msgEN;

                    if (_error == false && _param["result"] == 1) { _error = true; _msgTH = "อัพโหลดไฟล์ไม่สำเร็จ"; _msgEN = "Upload file was not successful."; }
                    if (_error == false && _param["result"] == 2) { _error = true; _msgTH = "ขนาดของไฟล์ไม่ถูกต้อง"; _msgEN = "Invalid file size."; }

                    if (_error == true)
                        Util.dialogMessageError({
                            content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                        });
                }
        },

        //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการบันทึกเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
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

        //ฟังก์ชั่นสำหรับบันทึกเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
        getSaveFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
            var _valueSaveFile = {};
            _valueSaveFile["personid"]  = $("#" + this.studentrecords.idSectionAddUpdate + "-personid-hidden").val();
            _valueSaveFile["section"]   = _param["section"];
            _valueSaveFile["filedir"]   = $("#" + _idContent + "-filedir-hidden").val();
            _valueSaveFile["filename"]  = $("#" + _idContent + "-filename-hidden").val();
            _valueSaveFile["cropx"]     = $("#" + _idContent + "-cropx-hidden").val();
            _valueSaveFile["cropy"]     = $("#" + _idContent + "-cropy-hidden").val();

            this.actionSaveFile({
                section: _param["section"],
                data: _valueSaveFile
            }, function (_resultSaveFile, _resultValueSaveFile) {
                if (_resultSaveFile == false)
                {
                    Util.dialogMessageError({
                        content: ("<div class='th-label'>บันทึกไฟล์ไม่สำเร็จ</div><div class='en-label'>Save file was not successful.</div>"),
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
                else
                    {
                        Util.dialogMessageBox({
                            content: "<div class='th-label'>บันทึกไฟล์เรียบร้อย</div><div class='en-label'>Save file complete.</div>",
                        });

                        _this2.setFrmUploadFile({
                            section: _param["section"],
                            uploadedStatus: "Y"
                        });
                    }
            });
        },

        //ฟังก์ชั่นสำหรับบันทึกเอกสารที่นักศึกษาอัพโหลด
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section           รับค่าชื่อหัวข้อที่ต้องการ
        //data              รับค่าข้อมูลที่ต้องการส่ง
        //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        actionSaveFile: function (_param, _callBackFunc) {
            _param["section"]   = (_param["section"] == undefined ? "" : _param["section"]);
            _param["data"]      = (_param["data"] == undefined || _param["data"] == "" ? {} : _param["data"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
            var _error = false;
            var _send = _param["data"];

            Util.msgPreloading = "Saving...";

            Util.actionSaveFile({
                data: _send
            }, function (_result) {
                if (_result.Error == 0)
                {
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
                        if (_resultSave == true)
                        {
                            if (_resultValueSave.SaveError != 0) _error = true;
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

        //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการลบเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
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

        //ฟังก์ชั่นสำหรับลบเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
        getRemoveFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
            var _error = false;
            var _valueRemoveFile = {};
            _valueRemoveFile["filedir"]     = $("#" + _idContent + "-filedir-hidden").val();
            _valueRemoveFile["filename"]    = $("#" + _idContent + "-filename-hidden").val();
            
            this.actionRemoveFile({
                section: _param["section"],
                data: _valueRemoveFile
            }, function (_resultRemoveFile, _resultValueRemoveFile) {
                if (_resultRemoveFile == false)
                {
                    if (_error == false && _resultValueRemoveFile.Error == 1) { _error = true; _msgTH = "ลบไฟล์ไม่สำเร็จ"; _msgEN = "Remove file was not successful."; }
                    if (_error == false && _resultValueRemoveFile.Error == 2) { _error = true; _msgTH = "ไม่พบไฟล์ที่ต้องการลบ"; _msgEN = "File not found."; }

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
                else
                    {
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

        //ฟังก์ชั่นสำหรับลบเอกสารที่นักศึกษาอัพโหลด
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section           รับค่าชื่อหัวข้อที่ต้องการ
        //data              รับค่าข้อมูลที่ต้องการส่ง
        //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        actionRemoveFile: function (_param, _callBackFunc) {
            _param["section"]   = (_param["section"] == undefined ? "" : _param["section"]);
            _param["data"]      = (_param["data"] == undefined || _param["data"] == "" ? {} : _param["data"]);

            var _this1 = Util.tut.tus;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _param["section"].toLowerCase());
            var _error = false;
            var _send = _param["data"];

            Util.msgPreloading = "Removing...";

            Util.actionRemoveFile({
                data: _send
            }, function (_result) {
                if (_result.Error == 0)
                {
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
                        if (_resultSave == true)
                        {
                            if (_resultValueSave.SaveError != 0) _error = true;
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

        //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการส่งเอกสารที่นักศึกษาอัพโหลดให้เจ้าหน้าที่ตรวจสอบตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
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
                if (_result == "Y")
                {
                    if (_this2.validateSubmitFile({ 
                            section: _param["section"]
                        }))
                        _this2.getSubmitFile({
                            section: _param["section"]
                        });
                }
            });
        },

        //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องในการส่งเอกสารที่นักศึกษาอัพโหลดให้เจ้าหน้าที่ตรวจสอบตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
        validateSubmitFile: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this = Util.tut.tus;
            var _error = false;
            var _idContent = (_this.idSectionAddUpdate + _param["section"].toLowerCase());
            var _valueSavedStatus = ($("#" + _idContent + "-savedstatus-hidden").val());
            var _i = 0;

            if (_error == false && _valueSavedStatus == "N") { _error = true; _msgTH = "กรุณาบันทึกไฟล์"; _msgEN = "Please save file."; }
            if (_error == false && _valueSavedStatus == "Y" && (_param["section"] == Util.tut.subjectSectionTranscriptFrontside || _param["section"] == Util.tut.subjectSectionTranscriptBackside) && Util.comboboxGetValue("#" + this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute") == "0") { _error = true; _msgTH = "กรุณาเลือกโรงเรียน / สถาบัน"; _msgEN = "Please select institute."; }

            if (_error == true)
            {
                Util.dialogMessageError({
                    content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
                });
                return false;
            }

            return true;
        },

        //ฟังก์ชั่นสำหรับส่งเอกสารที่นักศึกษาอัพโหลดให้เจ้าหน้าที่ตรวจสอบตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section   รับค่าชื่อหัวข้อที่ต้องการ
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
                if (_resultSubmitfile == false)
                {
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
                else
                    {
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

        //ฟังก์ชั่นสำหรับส่งเอกสารที่นักศึกษาอัพโหลดให้เจ้าหน้าที่ตรวจสอบ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section           รับค่าชื่อหัวข้อที่ต้องการ
        //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        actionSubmitfile: function (_param, _callBackFunc) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _error = false;

            Util.msgPreloading = "Submitting...";

            this.getSave({
                section: _param["section"],
                sectionAction: "submit"
            }, function (_resultSave, _resultValueSave) {
                if (_resultSave == true)
                {
                    if (_resultValueSave.SaveError != 0) _error = true;
                }
                else
                    _error = true;

                _callBackFunc(_error == false ? true : false);
            });
        },

        //ฟังก์ชั่นสำหรับนำข้อมูลในฟอร์มข้อมูลในส่วนของการอัพโหลดเอกสารของนักศึกษามาเตรียมสำหรับบันทึกข้อมูลลงฐานข้อมูล
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //section           รับค่าชื่อหัวข้อที่ต้องการ
        //sectionAction     รับค่าการกระทำที่เกิดขึ้นกับหัวข้อที่อัพโหลด
        //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        getSave: function (_param, _callBackFunc) {
            _param["section"]       = (_param["section"] == undefined ? "" : _param["section"]);
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

            _valueSave["section"]               = _param["section"];
            _valueSave["sectionaction"]         = _param["sectionAction"];
            _valueSave["personid"]              = $("#" + this.studentrecords.idSectionAddUpdate + "-personid-hidden").val();
            _valueSave["transcriptinstitute"]   = _transcriptInstitute;
            _valueSave["filename"]              = _fileName;
            _valueSave["savedstatus"]           = _valueSavedStatus;
            _valueSave["submittedstatus"]       = _valueSubmittedStatus;
            _valueSave["approvalstatus"]        = _valueApprovalStatus;

            this.actionSave({
                page: Util.tut.pageUploadSubmitDocumentAddUpdate,
                data: _valueSave
            }, function (_resultSave, _resultValueSave) {
                _callBackFunc(_resultSave, _resultValueSave)
            });
        },

        //ฟังก์ชั่นสำหรับบันทึกข้อมูลการอัพโหลดเอกสารของนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //page              รับค่าชื่อหน้าหลัก
        //data              รับค่าข้อมูลที่ต้องการส่ง
        //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
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

    /*
    idSectionAddUpdate: UDSUtil.idSectionUploadDocumentAddUpdate.toLowerCase(),

    sectionMain: {
        //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานในส่วนของการเพิ่มหรือแก้ไขการอัพโหลดเอกสารของนักศึกษา
        initMain: function () {
            var _this = UDSUploadDocument.sectionAddUpdate

            this.setMenuLayout();
            this.initMenu();
            _this.initMain(UDSUtil.subjectSectionStudentRecords);
        },

        //ฟังก์ชั่นสำหรับกำหนดการแสดงผลให้กับเมนูการอัพโหลดเอกสารของนักศึกษา
        setMenuLayout: function () {
            var _this = UDSUploadDocument;

            if ($("#" + _this.idSectionAddUpdate + "-menu").length > 0)
            {
                $("#" + _this.idSectionAddUpdate + "-menu").height($(window).height());
            }
        },

        //ฟังก์ชั่นสำหรับกำหนดให้ทำงานตามเหตุการณ์ต่าง ๆ ที่เกิดขึ้นบนเมนูในส่วนของการเพิ่มหรือแก้ไขการอัพโหลดเอกสารของนักศึกษา
        initMenu: function () {
            var _this1 = UDSUploadDocument;
            var _this2 = this;

            Util.initTab("#" + _this1.idSectionAddUpdate + "-menu-content", ("#" + _this1.idSectionAddUpdate + "-content"), true, "menu-active", "menu-noactive", function (_result) {
                var _idLink = _result;

                _this2.getTabOnClick(_idLink, function (_result) {
                    if (_result == true)
                    {
                        if (_idLink == UDSUtil.idSectionUploadDocumentProfilePictureAddUpdate.toLowerCase())    _this1.sectionAddUpdate.getFrmRecommend(UDSUtil.pageRecommendUploadProfilePictureMain, function () { });
                        if (_idLink == UDSUtil.idSectionUploadDocumentIdentityCardAddUpdate.toLowerCase())      _this1.sectionAddUpdate.getFrmRecommend(UDSUtil.pageRecommendUploadIdentityCardMain, function () { });
                        if (_idLink == UDSUtil.idSectionUploadDocumentTranscriptAddUpdate.toLowerCase())        _this1.sectionAddUpdate.getFrmRecommend(UDSUtil.pageRecommendUploadTranscriptMain, function () { });
                    }
                }); 
            });
        },

        //ฟังก์ชั่นสำหรับแสดงแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาตามหัวข้อเมื่อมีการกดเมนูหรือแท็บ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _idLink        รับค่าชื่อเมนูหรือชื่อแท็บ
        //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        getTabOnClick: function (_idLink, _callBackFunc) {
            var _this1 = UDSUploadDocument;
            var _this2 = _this1.sectionAddUpdate;
            var _loadForm = false;
            var _section;
            var _page;        

            if (_idLink == UDSUtil.idSectionUploadDocumentOverviewAddUpdate.toLowerCase())
            {
                _section    = UDSUtil.subjectSectionOverview;
                _page       = UDSUtil.pageUploadDocumentOverviewAddUpdate;
            }

            if (_idLink == UDSUtil.idSectionUploadDocumentProfilePictureAddUpdate.toLowerCase())
            {
                _section    = UDSUtil.subjectSectionProfilePicture;
                _page       = UDSUtil.pageUploadDocumentProfilePictureAddUpdate;
            }

            if (_idLink == UDSUtil.idSectionUploadDocumentIdentityCardAddUpdate.toLowerCase())
            {
                _section    = UDSUtil.subjectSectionIdentityCard;
                _page       = UDSUtil.pageUploadDocumentIdentityCardAddUpdate;
            }

            if (_idLink == UDSUtil.idSectionUploadDocumentTranscriptAddUpdate.toLowerCase())
            {
                _section    = UDSUtil.subjectSectionTranscript;
                _page       = UDSUtil.pageUploadDocumentTranscriptAddUpdate;
            }

            _loadForm = true;
            $("#" + _idLink).html("");

            if (_loadForm == true)
            {
                UDSUtil.loadForm(0, _page, false, _idLink, $("#" + _this2.studentrecords.idSectionAddUpdate + "-personid-hidden").val(), "", false, false, "", function () {
                    UDSUtil.setInfoBarLayout();
                    _this2.initMain(_section);

                    $(".link-" + UDSUtil.subjectSectionMeaningOfApprovalStatus.toLowerCase() + "-uploaddocument").click(function () {
                        UDSUtil.loadForm(1, UDSUtil.pageMeaningOfApprovalStatusMain, true, "", "", "", true, false, "", function () { });
                    });
                    _callBackFunc(true);
                });
            }
            else
                _callBackFunc(false);
        },
    },

    //ฟังก์ชั่นสำหรับแสดงสัญลักษณ์สถานะการอนุมัติเอกสารที่นักศึกษาอัพโหลด
    //โดยมีพารามิเตอร์ดังนี้
    //1. _approvalStatus    รับค่าสถานะการอนุมัติเอกสาร
    getIconApprovalStatus: function (_approvalStatus) {
        var _icon;

        switch (_approvalStatus.toUpperCase())
        {
            case "S"    :   { _icon = "uploaddocument-approvalstatus-s"; break; }
            case "W"    :   { _icon = "uploaddocument-approvalstatus-w"; break; }
            case "Y"    :   { _icon = "uploaddocument-approvalstatus-y"; break; }
            case "N"    :   { _icon = "uploaddocument-approvalstatus-n"; break; }
            default     :   { _icon = "uploaddocument-approvalstatus-s"; break; }
        }

        return _icon;
    },

    //ฟังก์ชั่นสำหรับแสดงเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
    getFrmViewDocument: function (_section) {
        var _idContent = (UDSUtil.idSectionUploadDocumentOverviewAddUpdate.toLowerCase() + "-" + _section.toLowerCase());
        var _valueFileDir = $("#" + _idContent + "filedir-hidden").val();
        var _valueFileName = $("#" + _idContent + "filename-hidden").val();
        var _page;
        var _width;
        var _height;

        _page = (_section == UDSUtil.subjectSectionProfilePicture ? UDSUtil.pageViewProfilePictureMain : _page);
        _page = (_section == UDSUtil.subjectSectionIdentityCard ? UDSUtil.pageViewIdentityCardMain : _page);
        _page = (_section == UDSUtil.subjectSectionTranscriptFrontside ? UDSUtil.pageViewTranscriptFrontsideMain : _page);
        _page = (_section == UDSUtil.subjectSectionTranscriptBackside ? UDSUtil.pageViewTranscriptBacksideMain : _page);
               
        UDSUtil.loadForm("picture", _page, true, "", (_valueFileDir + "/" + _valueFileName), "", true, false, "", function (_result, _e) {
            if (_result.Content.length > 0 && _e != "close")
            {
                _width = $(".dialogpicture-form .picture-content img").width();
                _height = $(".dialogpicture-form .picture-content img").height();

                $(".dialogpicture-form .picture-content").css({ "width": (_width + "px"), "height": (_height + "px") });
            }
        });
    },

    //ฟังก์ชั่นสำหรับแสดงข้อความในส่วนของเหตุผลที่ไม่อนุมัติเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
    getFrmMessageDocumentApproval: function (_section) {
        var _idContent = (UDSUtil.idSectionUploadDocumentOverviewAddUpdate.toLowerCase() + "-" + _section.toLowerCase());

        UDSUtil.loadForm(1, UDSUtil.pageViewMessageDocumentApprovalMain, true, "", "", "", true, false, "", function (_result, _e) {
            if (_result.Content.length > 0 && _e != "close")
            {
                var _valueMessage = $("#" + _idContent + "message-hidden").val();

                $("#" + UDSUtil.idSectionViewMessageDocumentApprovalMain.toLowerCase() + "-form .textareabox").prop("disabled", true).val(_valueMessage);
            }
        });
    },

    sectionAddUpdate: {
        //ฟังก์ชั่นสำหรับเตรียมแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาและสร้างเหตุการณ์ต่าง ๆ ในแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาหัวข้อต่าง ๆ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section รับค่าชื่อส่วนที่ต้องการ
        initMain: function (_section) {
            if (_section == UDSUtil.subjectSectionStudentRecords)   { this.studentrecords.initMain(); }
            if (_section == UDSUtil.subjectSectionOverview)         { this.overview.initMain(); }
            if (_section == UDSUtil.subjectSectionProfilePicture)   { this.profilepicture.initMain(); }
            if (_section == UDSUtil.subjectSectionIdentityCard)     { this.identitycard.initMain(); }
            if (_section == UDSUtil.subjectSectionTranscript)       { this.transcript.initMain(); }
        },

        //ฟังก์ชั่นสำหรับเตรียมแบบฟอร์มการอัพโหลดเอกสารและสร้างเหตุการณ์ต่าง ๆ ในแบบฟอร์มการอัพโหลดเอกสาร
        initUploadFile: function () {
            var _this1 = UDSUploadDocument;
            var _this2 = this;

            Util.initUploadFile();
        
            $(".uploadfile-button").click(function () {            
                var _idUploadFileButton = $(this).attr("id");
                var _section = (_idUploadFileButton.split("-"))[2];
                var _pageRecommend;

                if (_section == UDSUtil.subjectSectionProfilePicture.toLowerCase())         _section = UDSUtil.subjectSectionProfilePicture;
                if (_section == UDSUtil.subjectSectionIdentityCard.toLowerCase())           _section = UDSUtil.subjectSectionIdentityCard;
                if (_section == UDSUtil.subjectSectionTranscriptFrontside.toLowerCase())    _section = UDSUtil.subjectSectionTranscriptFrontside;
                if (_section == UDSUtil.subjectSectionTranscriptBackside.toLowerCase())     _section = UDSUtil.subjectSectionTranscriptBackside;

                if ($("#" + _idUploadFileButton).hasClass("disable") == false)
                {   
                    Util.dialogMessageClose();

                    if (_idUploadFileButton == ("clear-uploadfile-" + _section.toLowerCase()))
                    {
                        if (_section == UDSUtil.subjectSectionProfilePicture)       _this2.profilepicture.resetMain();
                        if (_section == UDSUtil.subjectSectionIdentityCard)         _this2.identitycard.resetMain();
                        if (_section == UDSUtil.subjectSectionTranscriptFrontside)  _this2.transcript.resetMainSection(_section);
                        if (_section == UDSUtil.subjectSectionTranscriptBackside)   _this2.transcript.resetMainSection(_section);
                    }

                    if (_idUploadFileButton == ("upload-uploadfile-" + _section.toLowerCase()))
                    {
                        if (_section == UDSUtil.subjectSectionProfilePicture)       _pageRecommend = UDSUtil.pageRecommendUploadProfilePictureMain;
                        if (_section == UDSUtil.subjectSectionIdentityCard)         _pageRecommend = UDSUtil.pageRecommendUploadIdentityCardMain;
                        if (_section == UDSUtil.subjectSectionTranscriptFrontside)  _pageRecommend = UDSUtil.pageRecommendUploadTranscriptFrontsideMain;
                        if (_section == UDSUtil.subjectSectionTranscriptBackside)   _pageRecommend = UDSUtil.pageRecommendUploadTranscriptBacksideMain;

                        _this2.getFrmRecommend(_pageRecommend, function (_result, _e) {
                            if (_e == "close")
                                _this2.confirmUploadFile(_section);
                        });
                    }

                    if (_idUploadFileButton == ("save-uploadfile-" + _section.toLowerCase()))
                        _this2.confirmSaveFile(_section);

                    if (_idUploadFileButton == ("delete-uploadfile-" + _section.toLowerCase()))
                        _this2.confirmRemoveFile(_section);

                    if (_idUploadFileButton == ("submit-uploadfile-" + _section.toLowerCase()))                
                    {
                        _this2.getFrmRecommend(UDSUtil.pageRecommendSubmitMain, function (_result, _e) {
                            if (_e == "close")
                                _this2.confirmSubmitFile(_section);
                        });
                    }
                }
            })
        },
    
        studentrecords: {
            idSectionAddUpdate: UDSUtil.idSectionUploadDocumentStudentRecordsAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับเตรียมแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาและสร้างเหตุการณ์ต่าง ๆ ในแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของข้อมูลการเป็นนักศึกษา
            initMain: function () {
                this.resetMain();
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตแบบฟอร์มข้อมูลระเบียนประวัตินักศึกษาในส่วนของข้อมูลการเป็นนักศึกษา
            resetMain: function () {
                //Util.dialogMessageClose();
                Util.gotoTopElement();

                if ($("#" + this.idSectionAddUpdate + "-studentpicture-hidden").val().length > 0)
                {
                    $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content .picture-watermark").show();
                    $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content img").attr({ "src": $("#" + this.idSectionAddUpdate + "-studentpicture-hidden").val() }).show();
                }
                else
                    {
                        $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content .picture-watermark").hide();
                        $("#" + this.idSectionAddUpdate + "-studentpicture-content .picture-content img").hide();
                    }
            }
        },
        
        overview: {
            idSectionAddUpdate: UDSUtil.idSectionUploadDocumentOverviewAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการแสดงผลผลการอัพโหลดเอกสาร
            setLayout: function () {
                var _idContentLayout = $("#" + this.idSectionAddUpdate + "-form .form .form-layout");
                var _idContentPicture = $("#" + this.idSectionAddUpdate + "-form .picture-content");            
                var _idContentLabelCol = $("#" + this.idSectionAddUpdate + "-form .form .form-labelcol");
                var _idContentInputCol = $("#" + this.idSectionAddUpdate + "-form .form .form-inputcol");

                _idContentInputCol.width(_idContentLayout.width() - _idContentPicture.width() - _idContentLabelCol.width() - 55);
            },

            //ฟังก์ชั่นสำหรับเตรียมแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาและสร้างเหตุการณ์ต่าง ๆ ในแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของผลการอัพโหลดเอกสาร
            initMain: function () {
                var _this = UDSUploadDocument;
                var _idContentProfilePicture = (this.idSectionAddUpdate + "-form ." + UDSUtil.subjectSectionProfilePicture.toLowerCase() + "-content");
                var _idContentIdentityCard = (this.idSectionAddUpdate + "-form ." + UDSUtil.subjectSectionIdentityCard.toLowerCase() + "-content");
                var _idContentTranscriptFrontside = (this.idSectionAddUpdate + "-form ." + UDSUtil.subjectSectionTranscriptFrontside.toLowerCase() + "-content");
                var _idContentTranscriptBackside = (this.idSectionAddUpdate + "-form ." + UDSUtil.subjectSectionTranscriptBackside.toLowerCase() + "-content");

                $("#" + this.idSectionAddUpdate + "-form .picture-content").hover(
                    function () {                
                        if ($(this).hasClass(UDSUtil.subjectSectionProfilePicture.toLowerCase() + "-content") && $("#" + _idContentProfilePicture + " img").is(":visible")) $("#" + _idContentProfilePicture + " .picture-zoom").show();
                        if ($(this).hasClass(UDSUtil.subjectSectionIdentityCard.toLowerCase() + "-content") && $("#" + _idContentIdentityCard + " img").is(":visible")) $("#" + _idContentIdentityCard + " .picture-zoom").show();
                        if ($(this).hasClass(UDSUtil.subjectSectionTranscriptFrontside.toLowerCase() + "-content") && $("#" + _idContentTranscriptFrontside + " img").is(":visible")) $("#" + _idContentTranscriptFrontside + " .picture-zoom").show();
                        if ($(this).hasClass(UDSUtil.subjectSectionTranscriptBackside.toLowerCase() + "-content") && $("#" + _idContentTranscriptBackside + " img").is(":visible")) $("#" + _idContentTranscriptBackside + " .picture-zoom").show();
                    },
                    function () {                
                        if ($(this).hasClass(UDSUtil.subjectSectionProfilePicture.toLowerCase() + "-content") && $("#" + _idContentProfilePicture + " img").is(":visible")) $("#" + _idContentProfilePicture + " .picture-zoom").hide();
                        if ($(this).hasClass(UDSUtil.subjectSectionIdentityCard.toLowerCase() + "-content") && $("#" + _idContentIdentityCard + " img").is(":visible")) $("#" + _idContentIdentityCard + " .picture-zoom").hide();
                        if ($(this).hasClass(UDSUtil.subjectSectionTranscriptFrontside.toLowerCase() + "-content") && $("#" + _idContentTranscriptFrontside + " img").is(":visible")) $("#" + _idContentTranscriptFrontside + " .picture-zoom").hide();
                        if ($(this).hasClass(UDSUtil.subjectSectionTranscriptBackside.toLowerCase() + "-content") && $("#" + _idContentTranscriptBackside + " img").is(":visible")) $("#" + _idContentTranscriptBackside + " .picture-zoom").hide();
                    }
                );
            
                $("#" + this.idSectionAddUpdate + "-form .picture-zoom").click(function () {
                    _this.getFrmViewDocument($(this).attr("alt"));
                });

                this.setLayout();
                this.resetMain();
            },
        
            //ฟังก์ชั่นสำหรับรีเซ็ตแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของผลการอัพโหลดเอกสาร
            resetMain: function () {
                var _this = UDSUploadDocument;
                var _fileArray;
                var _fileType;
                var _subjectUpload = new Array();
                var _subjectUploadDetail = new Array();
                var _section;
                var _idContent;
                var _i = 0;

                _subjectUpload[0] = UDSUtil.subjectSectionProfilePicture;
                _subjectUpload[1] = UDSUtil.subjectSectionIdentityCard;
                _subjectUpload[2] = UDSUtil.subjectSectionTranscriptFrontside;
                _subjectUpload[3] = UDSUtil.subjectSectionTranscriptBackside;

                Util.dialogMessageClose();
                Util.gotoTopElement();
            
                Util.resetForm(this.idSectionAddUpdate + "-form");

                for (_i = 0; _i < _subjectUpload.length; _i++)
                {
                    _section = _subjectUpload[_i];;
                    _subjectUploadDetail[0] = (_section + "InstituteNameTH");
                    _subjectUploadDetail[1] = (_section + "InstituteNameEN");
                    _subjectUploadDetail[2] = (_section + "InstituteCountryNameTH");
                    _subjectUploadDetail[3] = (_section + "InstituteCountryNameEN");
                    _subjectUploadDetail[4] = (_section + "InstituteProvinceNameTH");
                    _subjectUploadDetail[5] = (_section + "InstituteProvinceNameEN");
                    _subjectUploadDetail[6] = (_section + "FileName");
                    _subjectUploadDetail[7] = (_section + "FullPath");
                    _subjectUploadDetail[8] = (_section + "FileType");
                    _subjectUploadDetail[9] = (_section + "FileSize");
                    _subjectUploadDetail[10] = (_section + "SavedDate");
                    _subjectUploadDetail[11] = (_section + "SubmittedStatus");
                    _subjectUploadDetail[12] = (_section + "ApprovalStatus");
                    _subjectUploadDetail[13] = (_section + "ApprovalDate");
                    _subjectUploadDetail[14] = (_section + "Message");

                    if ($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[7].toLowerCase() + "-hidden").val().length > 0)
                    {
                        $("#" + this.idSectionAddUpdate + "-" + _section.toLowerCase() + "-form ." + _section.toLowerCase() + "-content .picture-watermark").show();
                        $("#" + this.idSectionAddUpdate + "-" + _section.toLowerCase() + "-form ." + _section.toLowerCase() + "-content img").attr({ "src": $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[7].toLowerCase() + "-hidden").val() }).show();
                    }

                    if (_section == UDSUtil.subjectSectionTranscriptFrontside || _section == UDSUtil.subjectSectionTranscriptBackside)
                    {
                        $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[0].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[0].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[1].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[1].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[2].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[2].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[3].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[3].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[4].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[4].toLowerCase() + "-hidden").val());
                        $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[5].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[5].toLowerCase() + "-hidden").val());
                    }

                    $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[6].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[6].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[8].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[8].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[9].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[9].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[10].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[10].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[11].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[11].toLowerCase() + "-hidden").val());
                    $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[12].toLowerCase()).addClass(_this.getIconApprovalStatus($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[12].toLowerCase() + "-hidden").val()));
                    $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[13].toLowerCase()).html($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[13].toLowerCase() + "-hidden").val());

                    if ($("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[14].toLowerCase() + "-hidden").val().length > 0)
                    {                    
                        $("#" + this.idSectionAddUpdate + "-" + _subjectUploadDetail[14].toLowerCase()).html("<a class='th-label' href='javascript:void(0)' onclick=UDSUploadDocument.getFrmMessageDocumentApproval('" + _section + "')>Click to Read Message</a>");
                    }
                }
            },
        },
    
        //ฟังก์ชั่นสำหรับแสดงฟอร์มข้อความสำหรับคำแนะนำการอัพโหลดเอกสารของนักศึกษาตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _recommend     รับค่าชื่อคำแนะนำ
        //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        getFrmRecommend: function (_recommend, _callBackFunc) {
            UDSUtil.loadForm(1, _recommend, true, "", "", "", true, false, "", function (_result, _e) {
                $("#" + Util.dialogLoading).dialog("close");
                _callBackFunc(_result, _e);
            });
        },

        //ฟังก์ชั่นสำหรับแสดงข้อความแนะนำการอัพโหลดเอกสารของนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _action    รับค่าการกระทำ
        getMsgRecommend: function (_action, _callBackFunc) {
            var _msg = new Array();
            var _msgTH;
            var _msgEN;

            if (_action == "browse")
            {        
                _msgTH = "คลิก \"BROWSE\" เพื่อเลือกไฟล์";
                _msgEN = "&nbsp;&nbsp;: Click \"BROWSE\" to select a file";
            }

            if (_action == "save")
            {
                _msgTH = "คลิกลากรูปเพื่อปรับตำแหน่ง";
                _msgEN = "&nbsp;&nbsp;: Drag the image to adjust position";
            }

            if (_action == "submit")
            {
                _msgTH = "คลิก \"SUBMIT\" เพื่อส่งเอกสารให้เจ้าหน้าที่พิจารณาอนุมัติ";
                _msgEN = "&nbsp;&nbsp;: Click \"SUBMIT\" to send document to the authorities for approval";
            }

            _msg[0] = _msgTH;
            _msg[1] = _msgEN;

            return _msg;
        },

        //ฟังก์ชั่นสำหรับกำหนดสถานะการอัพโหลดเอกสารของนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section           รับค่าชื่อหัวข้อที่ต้องการ
        //2. _savedStatus       รับค่าสถานะการบันทึกการอัพโหลดเอกสารของนักศึกษา
        //3. _submittedStatus   รับค่าสถานะการยืนยันการส่งเอกสารที่นักศึกษาอัพโหลด
        //4. _approvalStatus    รับค่าสถานะการอนุมัตืเอกสารที่นักศึกษาอัพโหลด
        setStatusUploadDocument: function (_section, _savedStatus, _submittedStatus, _approvalStatus) {
            var _this = UDSUploadDocument;
            var _idContent = (_this.idSectionAddUpdate + _section).toLowerCase();

            $("#" + _idContent + "-savedstatus-hidden").val(_savedStatus);
            $("#" + _idContent + "-submittedstatus-hidden").val(_submittedStatus);
            $("#" + _idContent + "-approvalstatus-hidden").val(_approvalStatus);
        },

        //ฟังก์ชั่นสำหรับกำหนดการแสดงผลฟอร์มการอัพโหลดเอกสารของนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section       รับค่าชื่อหัวข้อที่ต้องการ
        //2. _valueUpload   รับค่าสถานะการอัพโหลดเอกสารของนักศึกษา
        setFrmUploadFile: function (_section, _valueUpload) {
            var _this = UDSUploadDocument;
            var _idContent = (_this.idSectionAddUpdate + _section).toLowerCase();
            var _valueFileDir = $("#" + _idContent + "-filedir-hidden").val();
            var _valueFileName = $("#" + _idContent + "-filename-hidden").val();
            var _valueWidth = $("#" + _idContent + "-width-hidden").val();
            var _valueHeight = $("#" + _idContent + "-height-hidden").val();
            var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
            var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
            var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
            var _valueDocumentStatus = (_valueSavedStatus + _valueSubmittedStatus + _valueApprovalStatus);
            var _msgRecommend;
            var _objImage = $("#" + _idContent + "-image");
            var _objRecommend = $("#" + _idContent + "-recommend");
            var _objUploadFileForm = $("#uploadfile-" + _section.toLowerCase() + "-form");
            var _objUploadFileLabel = $("#uploadfile-" + _section.toLowerCase() + "-label");        
            var _objInputUploadFile = $("#" + _section.toLowerCase() + "-browse-uploadfile");
            var _objBrowseUploadFile = $("#browse-uploadfile-" + _section.toLowerCase());
            var _objClearUploadFile = $("#clear-uploadfile-" + _section.toLowerCase());
            var _objUploadUploadFile = $("#upload-uploadfile-" + _section.toLowerCase());
            var _objSaveUploadFile = $("#save-uploadfile-" + _section.toLowerCase());
            var _objDeleteUploadFile = $("#delete-uploadfile-" + _section.toLowerCase());
            var _objSubmitUploadFile = $("#submit-uploadfile-" + _section.toLowerCase());

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

            if ((_valueUpload.length == 0 || _valueUpload == "N") && (_valueDocumentStatus.length == 0 || _valueDocumentStatus == "NNS"))
            {
                _msgRecommend = this.getMsgRecommend("browse");

                _objRecommend.show();
                _objUploadFileLabel.html(_msgRecommend[0] + _msgRecommend[1]).show();
                _objInputUploadFile.show();
                _objBrowseUploadFile.removeClass("disable");
                _objClearUploadFile.removeClass("disable");
                _objUploadUploadFile.removeClass("disable");
            }
        
            if (_valueUpload == "Y" && _valueDocumentStatus == "NNS")
            {            
                _msgRecommend = this.getMsgRecommend("save");

                if (_valueFileDir.length > 0 && _valueFileName.length > 0) _objImage.attr({ "src": (_valueFileDir + "/" + _valueFileName), "width": (_valueWidth + "px"), "height": (_valueHeight + "px") }).show();
                $(".jwc_image").css({ "cursor": "move" });
                _objUploadFileLabel.html(_msgRecommend[0] + _msgRecommend[1]).show();
                _objSaveUploadFile.removeClass("disable");
                _objDeleteUploadFile.removeClass("disable");
            }

            if (_valueUpload == "Y" && _valueDocumentStatus == "YNS")
            {
                _msgRecommend = this.getMsgRecommend("submit");

                if (_valueFileDir.length > 0 && _valueFileName.length > 0) _objImage.attr({ "src": (_valueFileDir + "/" + _valueFileName), "width": (_valueWidth + "px"), "height": (_valueHeight + "px") }).show();
                _objUploadFileLabel.html(_msgRecommend[0] + _msgRecommend[1]).show();
                _objDeleteUploadFile.removeClass("disable");
                _objSubmitUploadFile.removeClass("disable");
            }
        
            if (_valueUpload == "Y" && (_valueDocumentStatus == "YYS" || _valueDocumentStatus == "YYW" || _valueDocumentStatus == "YYY" || _valueDocumentStatus == "YYN"))
            {
                if (_valueFileDir.length > 0 && _valueFileName.length > 0) _objImage.attr({ "src": (_valueFileDir + "/" + _valueFileName), "width": (_valueWidth + "px"), "height": (_valueHeight + "px") }).show();
                if (_valueApprovalStatus == "N") _objDeleteUploadFile.removeClass("disable");
            }
        },

        profilepicture: {
            idSectionAddUpdate: UDSUtil.idSectionUploadDocumentProfilePictureAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับเตรียมแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาและสร้างเหตุการณ์ต่าง ๆ ในแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดรูปภาพประจำตัว
            initMain: function () {
                var _this = UDSUploadDocument.sectionAddUpdate;

                _this.initUploadFile();

                $("." + UDSUtil.subjectSectionProfilePicture.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this.getFrmRecommend(UDSUtil.pageRecommendUploadProfilePictureMain, function () { });
                });

                this.resetMain();
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดรูปภาพประจำตัว
            resetMain: function () {
                var _this = UDSUploadDocument.sectionAddUpdate;
                var _idProfilePictureExample = $("#" + this.idSectionAddUpdate + "-form .profilepicture-example");
                var _valueGender = $("#" + _this.studentrecords.idSectionAddUpdate + "-gender-hidden").val();
                var _valueUpload = $("#" + this.idSectionAddUpdate + "-savedstatus-hidden").val();

                Util.dialogMessageClose();
                Util.gotoTopElement();

                Util.resetForm(this.idSectionAddUpdate + "-form");
                if (_valueGender == "M") _idProfilePictureExample.css({"background-position": "0px -501px"});
                if (_valueGender == "F") _idProfilePictureExample.css({"background-position": "-230px -501px"});
           
                _this.setFrmUploadFile(UDSUtil.subjectSectionProfilePicture, _valueUpload);
            },
        },
    
        identitycard: {
            idSectionAddUpdate: UDSUtil.idSectionUploadDocumentIdentityCardAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับเตรียมแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาและสร้างเหตุการณ์ต่าง ๆ ในแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดบัตรประจำตัวประชาชน
            initMain: function () {
                var _this = UDSUploadDocument.sectionAddUpdate;

                _this.initUploadFile();

                $("." + UDSUtil.subjectSectionIdentityCard.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this.getFrmRecommend(UDSUtil.pageRecommendUploadIdentityCardMain, function () { });
                });

                this.resetMain();
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดบัตรประจำตัวประชาชน
            resetMain: function () {
                var _this = UDSUploadDocument.sectionAddUpdate;
                var _valueUpload = $("#" + this.idSectionAddUpdate + "-savedstatus-hidden").val();

                Util.dialogMessageClose();
                Util.gotoTopElement();

                Util.resetForm(this.idSectionAddUpdate + "-form");
                _this.setFrmUploadFile(UDSUtil.subjectSectionIdentityCard, _valueUpload);
            },
        },
    
        transcript: {
            idSectionAddUpdate: UDSUtil.idSectionUploadDocumentTranscriptAddUpdate.toLowerCase(),
            idSectionTranscriptInstituteAddUpdate: UDSUtil.idSectionUploadDocumentTranscriptInstituteAddUpdate.toLowerCase(),
            idSectionTranscriptFrontsideAddUpdate: UDSUtil.idSectionUploadDocumentTranscriptFrontsideAddUpdate.toLowerCase(),
            idSectionTranscriptBacksideAddUpdate: UDSUtil.idSectionUploadDocumentTranscriptBacksideAddUpdate.toLowerCase(),

            //ฟังก์ชั่นสำหรับเตรียมแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาและสร้างเหตุการณ์ต่าง ๆ ในแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดระเบียนแสดงผลการเรียน
            initMain: function () {
                var _this = UDSUploadDocument.sectionAddUpdate;

                Util.initCombobox(("#" + this.idSectionTranscriptInstituteAddUpdate + "-institutecountry"), 463, 29);
                _this.initUploadFile();

                $("." + UDSUtil.subjectSectionTranscriptFrontside.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this.getFrmRecommend(UDSUtil.pageRecommendUploadTranscriptFrontsideMain, function () { });
                });

                $("." + UDSUtil.subjectSectionTranscriptBackside.toLowerCase() + "-content .uploaddocument-recommend").click(function () {
                    _this.getFrmRecommend(UDSUtil.pageRecommendUploadTranscriptBacksideMain, function () { });
                });
            
                this.resetMain();
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดระเบียนแสดงผลการเรียน
            resetMain: function () {
                var _this = UDSUploadDocument.sectionAddUpdate;
                var _valueUploadTranscriptFrontside = $("#" + this.idSectionTranscriptFrontsideAddUpdate + "-savedstatus-hidden").val();
                var _valueUploadTranscriptBackside = $("#" + this.idSectionTranscriptBacksideAddUpdate + "-savedstatus-hidden").val();

                Util.dialogMessageClose();
                Util.gotoTopElement();

                Util.resetForm(this.idSectionTranscript + "-form");                
                Util.comboboxSetValue(("#" + this.idSectionTranscriptInstituteAddUpdate + "-institutecountry"), ($("#" + this.idSectionTranscriptInstituteAddUpdate + "-institutecountry-hidden").val()));
                UDSUtil.setSelectDefaultCombobox(("#" + this.idSectionTranscriptInstituteAddUpdate + "-instituteprovince"), ($("#" + this.idSectionTranscriptInstituteAddUpdate + "-instituteprovince-hidden").val()), function () {
                    UDSUtil.setSelectDefaultCombobox(("#" + _this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute"), ($("#" + _this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute-hidden").val()), function () { })
                });
                _this.setFrmUploadFile(UDSUtil.subjectSectionTranscriptFrontside, _valueUploadTranscriptFrontside);
                _this.setFrmUploadFile(UDSUtil.subjectSectionTranscriptBackside, _valueUploadTranscriptBackside);
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตแบบฟอร์มการอัพโหลดเอกสารของนักศึกษาในส่วนของการอัพโหลดระเบียนแสดงผลการเรียนด้านหน้า
            //โดยมีพารามิเตอร์ดังนี้
            //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
            resetMainSection: function (_section) {
                var _this1 = UDSUploadDocument;
                var _this2 = UDSUploadDocument.sectionAddUpdate;
                var _idContent = (_this1.idSectionAddUpdate + _section).toLowerCase();
                var _idSection;
                var _valueUpload = $("#" + _idContent + "-savedstatus-hidden").val();

                Util.dialogMessageClose();
                if (_section == UDSUtil.subjectSectionTranscriptFrontside)
                {                
                    _idSection = this.idSectionTranscriptFrontsideAddUpdate;
                    Util.gotoTopElement();                
                }
                if (_section == UDSUtil.subjectSectionTranscriptBackside)
                {
                    _idSection = this.idSectionTranscriptBacksideAddUpdate;
                    Util.gotoElement(("#" + _idSection + "-form"), "", (UDSUtil.offsetTop + 10));
                }

                Util.resetForm(_idSection + "-form");
                _this2.setFrmUploadFile(_section, _valueUpload);
            },
        },

        //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการอัพโหลดเอกสารของนักศึกษาตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        confirmUploadFile: function (_section) {
            var _this = this;

            Util.dialogMessageConfirm("<div class='th-label'>ต้องการอัพโหลดไฟล์นี้หรือไม่</div><div class='en-label'>Do you want to upload this file ?</div>", false);
            $("#" + Util.dialogConfirm).dialog({
                buttons: {
                    "OK": function () {
                        $(this).dialog("close");

                        if (_this.validateUploadFile(_section) == true)
                        {                        
                            $("#uploadfile-" + _section.toLowerCase() + "-form #uploadfile-personid").val($("#" + _this.studentrecords.idSectionAddUpdate + "-personid-hidden").val());
                            $("#uploadfile-" + _section.toLowerCase() + "-form").attr("method", "POST");
                            $("#uploadfile-" + _section.toLowerCase() + "-form").submit();
                        }
                    },
                    "CANCEL": function () {
                        $(this).dialog("close");
                    }
                }
            });
        },

        //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องในการอัพโหลดเอกสารของนักศึกษาตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        validateUploadFile: function (_section) {
            var _error = false;
            var _msgTH;
            var _msgEN;
            var _valueBrowseUploadFile = $("#uploadfile-" + _section.toLowerCase() + "-label").html();
            var _fileArray = _valueBrowseUploadFile.split(".");
            var _fileType;

            if (_error == false && _fileArray.length < 2) { _error = true; _msgTH = "กรุณาเลือกไฟล์"; _msgEN = "Please browse to select a file."; }
            if (_error == false && UDSUtil.supportFileType.indexOf(_fileArray[_fileArray.length - 1]) < 0) { _error = true; _msgTH = "นามสกุลของไฟล์ไม่ถูกต้อง"; _msgEN = "Invalid file type."; }

            if (_error == true)
            {
                Util.dialogMessageError(("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>"), "", false);
                return false;
            }

            return true;
        },

        //ฟังก์ชั่นสำหรับหยุดการอัพโหลดเอกสารของนักศึกษา แล้วรับค่าจากการอัพโหลดใน C# มาทำงาน
        //โดยมีพารามิเตอร์ดังนี้
        //1. _result        รับค่าผลการอัพโหลดเอกสารของนักศึกษา
        //2. _section       รับค่าชื่อหัวข้อที่ต้องการ
        //3. _fileDir       รับค่าชื่อ Directory ที่เก็บไฟล์ที่ได้อัพโหลดเอกสารของนักศึกษา
        //4. _fileName      รับค่าชื่อ File ที่ได้จากการอัพโหลดเอกสารของนักศึกษา
        //5. _width         รับค่าชื่อความกว้างของเอกสารที่นักศึกษาอัพโหลด
        //6. _height        รับค่าชื่อความสูงของเอกสารที่นักศึกษาอัพโหลด
        //7. _widthShow     รับค่าชื่อความกว้างของเอกสารที่นักศึกษาอัพโหลดสำหรับแสดง
        //8. _heightShow    รับค่าชื่อความสูงของเอกสารที่นักศึกษาอัพโหลดสำหรับแสดง
        stopUploadFile: function (_result, _section, _fileDir, _fileName, _width, _height, _widthShow, _heightShow) {
            var _this = UDSUploadDocument;
            var _idContent = (_this.idSectionAddUpdate + _section).toLowerCase();
            var _idImage = ("#" + _idContent + "-image");

            $("#" + Util.dialogLoading).dialog("close");

            if (_result == 0)
            {
                Util.dialogMessageBox("<div class='th-label'>อัพโหลดไฟล์เรียบร้อย</div><div class='en-label'>Upload file complete</div>", false);            
                Util.initDragAndCropImage(_idImage, _widthShow, _heightShow, function (_result) {
                    $("#" + _idContent + "-cropx-hidden").val(_result.CropX);
                    $("#" + _idContent + "-cropy-hidden").val(_result.CropY);
                });            

                $("#" + _idContent + "-filedir-hidden").val(_fileDir);
                $("#" + _idContent + "-filename-hidden").val(_fileName);
                $("#" + _idContent + "-width-hidden").val(_width);
                $("#" + _idContent + "-height-hidden").val(_height);
                this.setStatusUploadDocument(_section, "N", "N", "S");
                this.setFrmUploadFile(_section, "Y");
            }
            else
                {
                    var _error = false;
                    var _msgTH;
                    var _msgEN;

                    if (_error == false && _result == 1) { _error = true; _msgTH = "อัพโหลดไฟล์ไม่สำเร็จ"; _msgEN = "Upload file was not successful."; }
                    if (_error == false && _result == 2) { _error = true; _msgTH = "ขนาดของไฟล์ไม่ถูกต้อง"; _msgEN = "Invalid file size."; }

                    if (_error == true)
                        Util.dialogMessageError(("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>"), "", false);
                }
        },

        //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการบันทึกเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        confirmSaveFile: function (_section) {
            var _this = this;

            Util.dialogMessageConfirm("<div class='th-label'>ต้องการบันทึกไฟล์นี้หรือไม่</div><div class='en-label'>Do you want to save this file ?</div>", false);
            $("#" + Util.dialogConfirm).dialog({
                buttons: {
                    "OK": function () {
                        $(this).dialog("close");

                        _this.actionSaveFile(_section);
                    },
                    "CANCEL": function () {
                        $(this).dialog("close");
                    }
                }
            });
        },

        //ฟังก์ชั่นสำหรับบันทึกเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        actionSaveFile: function (_section) {
            var _this1 = UDSUploadDocument;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _section).toLowerCase();
            var _send = {};
            _send["action"]     = "savefile";
            _send["personid"]   = $("#" + _this2.studentrecords.idSectionAddUpdate + "-personid-hidden").val();
            _send["section"]    = _section;
            _send["filedir"]    = $("#" + _idContent + "-filedir-hidden").val();
            _send["filename"]   = $("#" + _idContent + "-filename-hidden").val();
            _send["cropx"]      = $("#" + _idContent + "-cropx-hidden").val();
            _send["cropy"]      = $("#" + _idContent + "-cropy-hidden").val();
        
            this.savefile(_section, _send, function (_resultSave, _resultValueSave) {
                if (_resultSave == false)
                {
                    Util.dialogMessageError(("<div class='th-label'>บันทึกไฟล์ไม่สำเร็จ</div><div class='en-label'>Save file was not successful.</div>"), "", false);
                    $("#" + _idContent + "-filedir-hidden").val("");
                    $("#" + _idContent + "-filename-hidden").val("");
                    $("#" + _idContent + "-width-hidden").val("");
                    $("#" + _idContent + "-height-hidden").val("");
                    _this2.setStatusUploadDocument(_section, "N", "N", "S");
                    _this2.setFrmUploadFile(_section, "N");
                }
                else
                    {
                        Util.dialogMessageBox("<div class='th-label'>บันทึกไฟล์เรียบร้อย</div><div class='en-label'>Save file complete.</div>", false);
                        _this2.setFrmUploadFile(_section, "Y");
                    }
            });
        },

        //ฟังก์ชั่นสำหรับบันทึกเอกสารที่นักศึกษาอัพโหลด
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section       รับค่าชื่อหัวข้อที่ต้องการ
        //2. _send          รับค่าต่าง ๆ ที่ต้องการ
        //3. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        savefile: function (_section, _send, _callBackFunc) {
            var _this1 = UDSUploadDocument;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _section).toLowerCase();
            var _error = false;

            Util.msgLoading = "Saving...";

            Util.loadAjax(_send, UDSUtil.urlHandler, "POST", false, "", function (_result) {
                if (_result.Error == 0)
                {
                    $("#" + _idContent + "-filedir-hidden").val(_result.FileDir);
                    $("#" + _idContent + "-filename-hidden").val(_result.FileName);
                    $("#" + _idContent + "-width-hidden").val(_result.WidthShow);
                    $("#" + _idContent + "-height-hidden").val(_result.HeightShow);
                    _this2.setStatusUploadDocument(_section, "Y", "N", "S");

                    _this2.save(_section, "save", function (_resultSave, _resultValueSave) {
                        if (_resultSave == true)
                        {
                            if (_resultValueSave.SaveError != 0) _error = true;                            
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

        //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการลบเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        confirmRemoveFile: function (_section) {
            var _this = this;

            Util.dialogMessageConfirm("<div class='th-label'>ต้องการลบไฟล์นี้หรือไม่</div><div class='en-label'>Do you want to remove this file ?</div>", false);
            $("#" + Util.dialogConfirm).dialog({
                buttons: {
                    "OK": function () {
                        $(this).dialog("close");

                        _this.actionRemoveFile(_section);
                    },
                    "CANCEL": function () {
                        $(this).dialog("close");
                    }
                }
            });
        },

        //ฟังก์ชั่นสำหรับลบเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        actionRemoveFile: function (_section) {
            var _this1 = UDSUploadDocument;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _section).toLowerCase();
            var _error = false;
            var _send = {};
            _send["action"]     = "removefile";
            _send["section"]    = _section;
            _send["filedir"]    = $("#" + _idContent + "-filedir-hidden").val();
            _send["filename"]   = $("#" + _idContent + "-filename-hidden").val();

            this.removefile(_section, _send, function (_resultSave, _resultValueSave) {
                if (_resultSave == false)
                {
                    if (_error == false && _resultValueSave.Error == 1) { _error = true; _msgTH = "ลบไฟล์ไม่สำเร็จ"; _msgEN = "Remove file was not successful."; }
                    if (_error == false && _resultValueSave.Error == 2) { _error = true; _msgTH = "ไม่พบไฟล์ที่ต้องการลบ"; _msgEN = "File not found."; }

                    if (_error == true)
                        Util.dialogMessageError(("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>"), "", false);

                    $("#" + _idContent + "-filedir-hidden").val("");
                    $("#" + _idContent + "-filename-hidden").val("");
                    $("#" + _idContent + "-width-hidden").val("");
                    $("#" + _idContent + "height-hidden").val("");
                    _this2.setStatusUploadDocument(_section, "N", "N", "S");
                    _this2.setFrmUploadFile(_section, "N");
                }
                else
                    {
                        Util.dialogMessageBox("<div class='th-label'>ลบไฟล์เรียบร้อย</div><div class='en-label'>Remove file complete.</div>", false);
                        _this2.setFrmUploadFile(_section, "N");
                    }
            });
        },

        //ฟังก์ชั่นสำหรับลบเอกสารที่นักศึกษาอัพโหลด
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section       รับค่าชื่อหัวข้อที่ต้องการ
        //2. _send          รับค่าต่าง ๆ ที่ต้องการ
        //3. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        removefile: function (_section, _send, _callBackFunc) {
            var _this1 = UDSUploadDocument;
            var _this2 = this;
            var _idContent = (_this1.idSectionAddUpdate + _section).toLowerCase();
            var _error = false;

            Util.msgLoading = "Removing...";

            Util.loadAjax(_send, UDSUtil.urlHandler, "POST", false, "", function (_result) {
                if (_result.Error == 0)
                {
                    $("#" + _idContent + "-filedir-hidden").val("");
                    $("#" + _idContent + "-filename-hidden").val("");
                    $("#" + _idContent + "-width-hidden").val("");
                    $("#" + _idContent + "-height-hidden").val("");
                    _this2.setStatusUploadDocument(_section, "N", "N", "S");

                    _this2.save(_section, "save", function (_resultSave, _resultValueSave) {
                        if (_resultSave == true)
                        {
                            if (_resultValueSave.SaveError != 0) _error = true;
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

        //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการส่งเอกสารที่นักศึกษาอัพโหลดให้เจ้าหน้าที่ตรวจสอบตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        confirmSubmitFile: function (_section) {
            var _this = this;

            Util.dialogMessageConfirm("<div class='th-label'>ต้องการส่งไฟล์นี้หรือไม่</div><div class='en-label'>Do you want to submit these files ?</div>", false);
            $("#" + Util.dialogConfirm).dialog({
                buttons: {
                    "OK": function () {
                        $(this).dialog("close");

                        if (_this.validateSubmitFile(_section) == true)
                            _this.actionSubmitFile(_section);
                    },
                    "CANCEL": function () {
                        $(this).dialog("close");
                    }
                }
            });
        },

        //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องในการส่งเอกสารที่นักศึกษาอัพโหลดให้เจ้าหน้าที่ตรวจสอบตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        validateSubmitFile: function (_section) {        
            var _this = UDSUploadDocument;
            var _error = false;
            var _idContent = (_this.idSectionAddUpdate + _section).toLowerCase();
            var _valueSave = ($("#" + _idContent + "-savedstatus-hidden").val());
            var _i = 0;

            if (_error == false && _valueSave == "N") { _error = true; _msgTH = "กรุณาบันทึกไฟล์"; _msgEN = "Please save file."; }
            if (_error == false && _valueSave == "Y" && (_section == UDSUtil.subjectSectionTranscriptFrontside || _section == UDSUtil.subjectSectionTranscriptBackside) && Util.comboboxGetValue("#" + this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute") == "0") { _error = true; _msgTH = "กรุณาเลือกโรงเรียน / สถาบัน"; _msgEN = "Please select institute."; }

            if (_error == true)
            {
                Util.dialogMessageError(("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>"), "", false);
                return false;
            }

            return true;
        },

        //ฟังก์ชั่นสำหรับส่งเอกสารที่นักศึกษาอัพโหลดให้เจ้าหน้าที่ตรวจสอบตามหัวข้อ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section   รับค่าชื่อหัวข้อที่ต้องการ
        actionSubmitFile: function (_section) {
            var _this = this;

            this.submitfile(_section, null, function (_resultSave) {
                if (_resultSave == false)
                {
                    Util.dialogMessageError(("<div class='th-label'>ส่งไฟล์ไม่สำเร็จ</div><div class='en-label'>Submit these files was not successful.</div>"), "", false);
                    _this.setStatusUploadDocument(_section, "Y", "N", "S");
                    _this.setFrmUploadFile(_section, "Y");
                }
                else
                    {
                        Util.dialogMessageBox("<div class='th-label'>ส่งไฟล์เรียบร้อย</div><div class='en-label'>Remove file complete.</div>", false);            
                        _this.setFrmUploadFile(_section, "Y");
                    }
            });
        },

        //ฟังก์ชั่นสำหรับส่งเอกสารที่นักศึกษาอัพโหลดให้เจ้าหน้าที่ตรวจสอบ
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section       รับค่าชื่อหัวข้อที่ต้องการ
        //2. _send          รับค่าต่าง ๆ ที่ต้องการ
        //3. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
        submitfile: function (_section, _send, _callBackFunc) {
            var _error = false;

            Util.msgLoading = "Submitting...";

            this.setStatusUploadDocument(_section, "Y", "Y", "W");

            this.save(_section, "submit", function (_resultSave, _resultValueSave) {
                if (_resultSave == true)
                {
                    if (_resultValueSave.SaveError != 0) _error = true;
                }
                else
                    _error = true;

                _callBackFunc(_error == false ? true : false);
            });
        },

        //ฟังก์ชั่นสำหรับบันทึกข้อมูลการอัพโหลดเอกสารของนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _section       รับค่าชื่อหัวข้อที่ต้องการ
        //2. _sectionAction รับค่าการกระทำที่เกิดขึ้นกับหัวข้อที่อัพโหลด
        save: function (_section, _sectionAction, _callBackFunc) {
            var _idContent = (UDSUtil.idSectionUploadDocumentAddUpdate + _section).toLowerCase();
            var _error = false;
            var _signinYN = "Y";
            var _transcriptInstitute = (_section == UDSUtil.subjectSectionTranscriptFrontside || _section == UDSUtil.subjectSectionTranscriptBackside ? Util.getSelectionIsSelect(("#" + this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute"), "select", Util.comboboxGetValue("#" + this.transcript.idSectionTranscriptInstituteAddUpdate + "-institute"), "") : "");
            var _fileName = $("#" + _idContent + "-filename-hidden").val();
            var _valueSavedStatus = $("#" + _idContent + "-savedstatus-hidden").val();
            var _valueSubmittedStatus = $("#" + _idContent + "-submittedstatus-hidden").val();
            var _valueApprovalStatus = $("#" + _idContent + "-approvalstatus-hidden").val();
            var _send = {};
            _send["signinyn"]               = _signinYN;
            _send["section"]                = _section;
            _send["sectionaction"]          = _sectionAction;
            _send["transcriptinstitute"]    = _transcriptInstitute;
            _send["filename"]               = _fileName;
            _send["savedstatus"]            = _valueSavedStatus;
            _send["submittedstatus"]        = _valueSubmittedStatus;
            _send["approvalstatus"]         = _valueApprovalStatus;

            UDSUtil.actionSave("save", UDSUtil.pageUploadDocumentAddUpdate, _send, false, function (_result) {
                _error = UDSUtil.errorMsg("0", _signinYN, _result.CookieError, _result.UserError, "0");

                _callBackFunc((_error == false ? true : false), _result);
            });
        },
    }
    */
}