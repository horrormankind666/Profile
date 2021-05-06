// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๕/๐๖/๒๕๕๘>
// Modify date  : <๒๙/๐๕/๒๕๖๒>
// Description  : <รวมรวบฟังก์ชั่นใช้งานในส่วนของการค้นหาข้อมูล>
// =============================================

var UDSStaffSearch = {
    //ฟังก์ชั่นสำหรับกำหนดการแสดงผลให้กับฟอร์มค้นหาข้อมูล
    setSearchLayout: function () {
        var _widthParent = Util.getParentWidth();
        var _width;
        var _col;
        var _i;

        $("#bodysearch, .form.search").width(_widthParent);
        $("#bodysearch").css({
            "top": (Util.offsetTop + "px")
        });
        $(".form.search .form-content .search-section3").width(123);

        _widthParent = (($(".form.search").width() - $(".form.search .form-content .search-section3").width() - 42) / 2);
        
        $(".form.search .form-content .search-section1, .form.search .form-content .search-section2").width(_widthParent);
        $(".form.search .form-content .form-labelcol, .form.search .form-content .form-inputcol").width(_widthParent);
        $(".form.search .form-content .form-inputcol .form-input .inputbox").width(_widthParent - 8);
        Util.comboboxSetSize({
            id: ".form.search .form-content .combobox-width-dynamic .combobox",
            width: _widthParent,
            height: 27
        });

        for(_i = 1; _i <= $(".form.search .form-content .search-floatcol").length; _i++)
        {
            _col = $(".form.search .form-content .search-floatcol" + _i + " .contentbody-left").length;

            if (_col > 0)
            {
                _width = ((_widthParent / _col) - 3);
            
                $(".form.search .form-content .search-floatcol" + _i + " .contentbody-left:first-child, .form.search .form-content .search-floatcol" + _i + " .contentbody-left:last-child").css({
                    "width": _width
                });
                Util.comboboxSetSize({
                    id: (".form.search .form-content .search-floatcol" + _i + " .contentbody-left .combobox"),
                    width: _width,
                    height: 27
                });
            }
        }

        $(".form.search .form-content .button .button-content ul li div").css({
            "width": ($(".form.search .form-content .search-section3").width() + "px"),
            "height": (($("#bodysearch").outerHeight() - 31) / 2 + "px"),
            "line-height": (($("#bodysearch").outerHeight() - 33) / 2 + "px")
        });
    },

    //ฟังก์ชั่นสำหรับลบเนื้อหาในตารางแสดงรายการ
    clearTable: function () {
        var _this1;
        var _this2;
        var _this3;
        var _page = $("#page").html();
        var _idContent;
        var _idChart;
        var _idTable;

        if (_page == Util.tut.pageUploadSubmitDocumentMain)
            Util.tut.resetPreviewDocument({
                idMain: Util.tut.tus.idSectionMain,
                idPreview: Util.tut.tus.idSectionPreview
            });

        if (_page == Util.tut.pageApproveDocumentMain)
            Util.tut.resetPreviewDocument({
                idMain: Util.tut.tap.idSectionMain,
                idPreview: Util.tut.tap.idSectionEdit
            });

        if (_page == Util.tut.pageOurServicesDocumentStatusStudentMain)
        {
            _idContent  = Util.getTabActiveOnTabbar({
                            id: (Util.tut.tos.documentstatusstudent.idSectionMain + "-viewsdisplay")
                          });
            _page       = $("#" + _idContent).attr("alt");

            if (_page == Util.tut.pageOurServicesDocumentStatusStudentViewTableMain) _page = Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain;

            if (_page == Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain)
                Util.tut.resetPreviewDocument({
                    idMain: Util.tut.tos.documentstatusstudent.viewtable.idSectionLevel1Main,
                    idPreview: Util.tut.tos.documentstatusstudent.viewtable.idSectionLevel1Preview
                });
        }

        if (_page == Util.tut.pageOurServicesExportProfilePictureApprovedMain)
            Util.tut.resetPreviewDocument({
                idMain: Util.tut.tos.exportprofilepictureapproved.idSectionMain,
                idPreview: Util.tut.tos.exportprofilepictureapproved.idSectionPreview
            });

        if (_page == Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardMain)
            Util.tut.resetPreviewDocument({
                idMain: Util.tut.tos.exportstudentrecordsinformationforsmartcard.idSectionMain,
                idPreview: Util.tut.tos.exportstudentrecordsinformationforsmartcard.idSectionPreview
            });

        if (_page == Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreMain)
            Util.tut.resetPreviewDocument({
                idMain: Util.tut.tos.copyprofilepictureapprovedtothestore.idSectionMain,
                idPreview: Util.tut.tos.copyprofilepictureapprovedtothestore.idSectionPreview
            });

        if (_page == Util.tut.pageOurServicesExportSaveAuditTranscriptApprovedMain)
            Util.tut.resetPreviewDocument({
                idMain: Util.tut.tos.exportsaveaudittranscriptapproved.idSectionMain,
                idPreview: Util.tut.tos.exportsaveaudittranscriptapproved.idSectionPreview
            });
    },

    //ฟังก์ชั่นสำหรับกำหนดชื่อและค่าที่ให้แสดงผลการค้นหา
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้า
    getValueSearch: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _cmd;
        var _pageMain;
        var _pageSearch;
        var _valueParam = {}
        var _idChart;
        var _idTable;
        var _valueSearchResult = {};

        if (_param["page"] == Util.tut.pageUploadSubmitDocumentMain)
        {
            _pageMain                   = Util.tut.pageUploadSubmitDocumentMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.uploadsubmitdocument.valueSearch();
            _idChart                    = "";
            _idTable                    = (Util.tut.tus.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageApproveDocumentMain)
        {
            _pageMain                   = Util.tut.pageApproveDocumentMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.approvedocument.valueSearch();
            _idChart                    = "";
            _idTable                    = (Util.tut.tap.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentViewChartMain)
        {
            _pageMain                   = Util.tut.pageOurServicesDocumentStatusStudentMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.documentstatusstudent.valueSearch();
            _idChart                    = (Util.tut.tos.documentstatusstudent.viewchart.idSectionMain + "-chart");
            _idTable                    = "";
        }

        if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain)
        {
            _pageMain                   = Util.tut.pageOurServicesDocumentStatusStudentMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.documentstatusstudent.valueSearch();
            _idChart                    = "";
            _idTable                    = (Util.tut.tos.documentstatusstudent.viewtable.idSectionLevel1Main + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesExportProfilePictureApprovedMain)
        {
            _pageMain                   = Util.tut.pageOurServicesExportProfilePictureApprovedMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.exportprofilepictureapproved.valueSearch();
            _idChart                    = "";
            _idTable                    = (Util.tut.tos.exportprofilepictureapproved.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardMain)
        {
            _pageMain                   = Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.exportstudentrecordsinformationforsmartcard.valueSearch();
            _idChart                    = "";
            _idTable                    = (Util.tut.tos.exportstudentrecordsinformationforsmartcard.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreMain)
        {
            _pageMain                   = Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.copyprofilepictureapprovedtothestore.valueSearch();
            _idChart                    = "";
            _idTable                    = (Util.tut.tos.copyprofilepictureapprovedtothestore.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedViewChartMain)
        {
            _pageMain                   = Util.tut.pageOurServicesAuditTranscriptApprovedMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.audittranscriptapproved.valueSearch();
            _idChart                    = (Util.tut.tos.audittranscriptapproved.viewchart.idSectionMain + "-chart");
            _idTable                    = "";
        }

        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain)
        {
            _pageMain                   = Util.tut.pageOurServicesAuditTranscriptApprovedMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.audittranscriptapproved.valueSearch();
            _idChart                    = "";
            _idTable                    = (Util.tut.tos.audittranscriptapproved.viewtable.idSectionLevel1Main + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveMain)
        {
            _pageMain                   = Util.tut.pageOurServicesAuditTranscriptApprovedMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.audittranscriptapproved.valueSearch();
            _valueParam["yearentry"]    = Util.tut.tos.audittranscriptapproved.viewtable.yearEntry;
            _valueParam["rowperpage"]   = 100;
            _idChart                    = "";
            _idTable                    = (Util.tut.tos.audittranscriptapproved.viewtable.idSectionLevel21Main + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveMain)
        {
            _pageMain                   = Util.tut.pageOurServicesAuditTranscriptApprovedMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.audittranscriptapproved.valueSearch();
            _valueParam["yearentry"]    = Util.tut.tos.audittranscriptapproved.viewtable.yearEntry;
            _valueParam["rowperpage"]   = 100;
            _idChart                    = "";
            _idTable                    = (Util.tut.tos.audittranscriptapproved.viewtable.idSectionLevel22Main + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesExportSaveAuditTranscriptApprovedMain)
        {
            _pageMain                   = Util.tut.pageOurServicesExportSaveAuditTranscriptApprovedMain;
            _pageSearch                 = _param["page"];
            _valueParam                 = this.ourservices.exportsaveaudittranscriptapproved.valueSearch();
            _idChart                    = "";
            _idTable                    = (Util.tut.tos.exportsaveaudittranscriptapproved.idSectionMain + "-table");
        }           

        _valueSearchResult["pagemain"]      = _pageMain;
        _valueSearchResult["pagesearch"]    = _pageSearch;
        _valueSearchResult["paramsearch"]   = _valueParam
        _valueSearchResult["chart"]         = _idChart;
        _valueSearchResult["table"]         = _idTable;        

        return _valueSearchResult;
    },

    //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้า
    resetSearch: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this = null;

        if (_param["page"] == Util.tut.pageUploadSubmitDocumentMain)                                    _this = this.uploadsubmitdocument;
        if (_param["page"] == Util.tut.pageApproveDocumentMain)                                         _this = this.approvedocument;
        if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentMain)                        _this = this.ourservices.documentstatusstudent;
        if (_param["page"] == Util.tut.pageOurServicesExportProfilePictureApprovedMain)                 _this = this.ourservices.exportprofilepictureapproved;
        if (_param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardMain)  _this = this.ourservices.exportstudentrecordsinformationforsmartcard;
        if (_param["page"] == Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreMain)         _this = this.ourservices.copyprofilepictureapprovedtothestore;
        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedMain)                      _this = this.ourservices.audittranscriptapproved;
        if (_param["page"] == Util.tut.pageOurServicesExportSaveAuditTranscriptApprovedMain)            _this = this.ourservices.exportsaveaudittranscriptapproved;

        if (_this != null)
            _this.resetSearch({
                reset: true
            });
    },

    //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้า
    validateSearch: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this = null;
        var _validateResult = false;

        if (_param["page"] == Util.tut.pageUploadSubmitDocumentMain)                                    _this = this.uploadsubmitdocument;
        if (_param["page"] == Util.tut.pageApproveDocumentMain)                                         _this = this.approvedocument;
        if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentMain)                        _this = this.ourservices.documentstatusstudent;
        if (_param["page"] == Util.tut.pageOurServicesExportProfilePictureApprovedMain)                 _this = this.ourservices.exportprofilepictureapproved;
        if (_param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardMain)  _this = this.ourservices.exportstudentrecordsinformationforsmartcard;
        if (_param["page"] == Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreMain)         _this = this.ourservices.copyprofilepictureapprovedtothestore;
        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedMain)                      _this = this.ourservices.audittranscriptapproved;
        if (_param["page"] == Util.tut.pageOurServicesExportSaveAuditTranscriptApprovedMain)            _this = this.ourservices.exportsaveaudittranscriptapproved;

        if (_this != null)
            _validateResult = _this.validateSearch();

        return _validateResult;
    },

    //ฟังก์ชั่นสำหรับค้นหาข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page          รับค่าชื่อหน้า
    //setSearchShow รับค่าต้องการให้ทำการกำหนดการแสดงผลฟอร์มค้นหาข้อมูลหรือไม่
    getSearch: function(_param) {
        _param["page"]          = (_param["page"] == undefined ? "" : _param["page"]);
        _param["setSearchShow"] = (_param["setSearchShow"] == undefined || _param["setSearchShow"] == "" ? false : _param["setSearchShow"]);
        
        var _this;
        var _reset = true;
        var _idContent;
        
        if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedMain)
        {
            if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentMain)    _this = Util.tut.tos.documentstatusstudent;
            if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedMain)  _this = Util.tut.tos.audittranscriptapproved;

            _idContent      = Util.getTabActiveOnTabbar({ id: (_this.idSectionMain + "-viewsdisplay") });
            _param["page"]  = $("#" + _idContent).attr("alt");

            if (_param["page"] == Util.tut.pageOurServicesDocumentStatusStudentViewTableMain)   _param["page"] = Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain;
            if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedViewTableMain) _param["page"] = Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain;
        }

        if (_param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveMain ||
            _param["page"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveMain)
            _reset = false;

        if (_reset == true)
        {
            Util.clearTable();
            this.clearTable();
        }

        var _valueSearch = this.getValueSearch({
                                page: _param["page"]
                           });

        Util.msgPreloading = "Searching...";
                
        this.actionSearch({        
            pageMain: _valueSearch["pagemain"],
            pageSearch: _valueSearch["pagesearch"],
            data: _valueSearch["paramsearch"],
            idChart: _valueSearch["chart"],
            idTable: _valueSearch["table"],
            setSearchShow: _param["setSearchShow"]
        });
    },

    //ฟังก์ชั่นสำหรับค้นหาข้อมูลตามคำสั่ง
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param     รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //pageMain      รับค่าชื่อหน้าหลัก
    //pageSearch    รับค่าชื่อหน้าค้นหา
    //data          รับค่าข้อมูลที่ต้องการส่ง
    //idChart       รับค่าชื่อของส่วนแสดงรายการมุมมองแผนภูมิ
    //idTable       รับค่าชื่อของส่วนแสดงรายการมุมมองตาราง    
    //pressNavPage  รับค่าว่าเป็นส่วนแสดงหน้าถัดไปหรือไม่
    //setSearchShow รับค่าต้องการให้ทำการกำหนดการแสดงผลฟอร์มค้นหาข้อมูลหรือไม่
    actionSearch: function (_param) {
        _param["pageMain"]      = (_param["pageMain"] == undefined ? "" : _param["pageMain"]);
        _param["pageSearch"]    = (_param["pageSearch"] == undefined ? "" : _param["pageSearch"]);
        _param["data"]          = (_param["data"] == undefined || _param["data"] == "" ? {} : _param["data"]);
        _param["idChart"]       = (_param["idChart"] == undefined ? "" : _param["idChart"]);
        _param["idTable"]       = (_param["idTable"] == undefined ? "" : _param["idTable"]);
        _param["pressNavPage"]  = (_param["pressNavPage"] == undefined || _param["pressNavPage"] == "" ? false : _param["pressNavPage"]);
        _param["setSearchShow"] = (_param["setSearchShow"] == undefined || _param["setSearchShow"] == "" ? false : _param["setSearchShow"]);
        
        Util.actionSearch({
            pageMain: _param["pageMain"],
            pageSearch: _param["pageSearch"],
            data: _param["data"],
            idChart: _param["idChart"],
            idTable: _param["idTable"]
        }, function (_result) {            
            if (_param["pageSearch"] == Util.tut.pageUploadSubmitDocumentMain)                                      Util.tut.tus.sectionMain.initTable();
            if (_param["pageSearch"] == Util.tut.pageApproveDocumentMain)                                           Util.tut.tap.sectionMain.initTable();
            if (_param["pageSearch"] == Util.tut.pageOurServicesDocumentStatusStudentLevel1ViewTableMain)           Util.tut.tos.documentstatusstudent.viewtable.sectionMain.initTable({ page: _param["pageSearch"] });
            if (_param["pageSearch"] == Util.tut.pageOurServicesExportProfilePictureApprovedMain)                   Util.tut.tos.exportprofilepictureapproved.sectionMain.initTable();
            if (_param["pageSearch"] == Util.tut.pageOurServicesExportStudentRecordsInformationForSmartCardMain)    Util.tut.tos.exportstudentrecordsinformationforsmartcard.sectionMain.initTable();
            if (_param["pageSearch"] == Util.tut.pageOurServicesCopyProfilePictureApprovedtotheStoreMain)           Util.tut.tos.copyprofilepictureapprovedtothestore.sectionMain.initTable();
            if (_param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveMain)
            {
                Util.tut.tos.audittranscriptapproved.viewtable.sectionMain.initMain({
                    page: _param["pageSearch"]
                });
                Util.tut.tos.audittranscriptapproved.viewtable.sectionMain.initTable({
                    page: _param["pageSearch"]
                });
            }
            if (_param["pageSearch"] == Util.tut.pageOurServicesExportSaveAuditTranscriptApprovedMain)              Util.tut.tos.exportsaveaudittranscriptapproved.sectionMain.initTable();

            if (_param["setSearchShow"] == true) Util.setSearchShow();
            Util.setChartLayout();
            Util.setTableLayout();
            Util.initTable();
            Util.gotoTopElement();
        });
    },

    uploadsubmitdocument: {
        idSectionMain: UDSStaffUtil.idSectionUploadSubmitDocumentMain.toLowerCase(),
        idSectionSearch: UDSStaffUtil.idSectionUploadSubmitDocumentSearch.toLowerCase(),            

        //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา
        initSearch: function () {
            var _this = Util.tut.tse;

            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-degreelevel"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-faculty"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-yearattended"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-entrancetype"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-studentstatus"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-documentupload"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-submittedstatus"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-sortorderby"),
                width: 206,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-sortexpression"),
                width: 206,
                height: 27
            });

            this.resetSearch({});
        },
            
        //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //reset     รับค่าสถานะการรีเซ็ต
        resetSearch: function (_param) {
            _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

            Util.dialogMessageClose();
            Util.gotoTopElement();
            Util.resetForm({
                id: (this.idSectionSearch + "-form")
            });

            $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-degreelevel"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-degreelevel-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-faculty"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-faculty-hidden").val())
            });
            Util.tut.setSelectDefaultCombobox({
                id: ("#" + this.idSectionSearch + "-program"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
            }, function () { });            
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-yearattended"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-entrancetype"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-studentstatus"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-documentupload"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-documentupload-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-submittedstatus"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-submittedstatus-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-sortorderby"),
                value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-sortexpression"),
                value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
            });           
        },

        //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา
        validateSearch: function () {
            var _error = new Array();
            var _i = 0;

            if (Util.comboboxGetValue("#" + this.idSectionSearch + "-documentupload") == "0") { _error[_i] = "กรุณาเลือกเอกสารอัพโหลด;Please select document upload.;"; _i++; }

            Util.dialogListMessageError({
                content: _error
            });

            return (_i > 0 ? false : true);
        },
            
        //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการอัพโหลดและส่งเอกสารให้กับนักศึกษา
        valueSearch: function () {
            var _send = {};
            _send["sectionaction"]      = "submit";
            _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
            _send["degreelevel"]        = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-degreelevel"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                                          });
            _send["faculty"]            = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-faculty"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                                          });
            _send["program"]            = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-program"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                                          }); 
            _send["yearentry"]          = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-yearattended"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                                          });
            _send["entrancetype"]       = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-entrancetype"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                          });
            _send["studentstatus"]      = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-studentstatus"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                          });
            _send["documentupload"]     = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-documentupload"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-documentupload")
                                          });
            _send["submittedstatus"]    = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-submittedstatus"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-submittedstatus")
                                          });           
            _send["approvalstatus"]     = "";
            _send["institutecountry"]   = "";
            _send["instituteprovince"]  = "";
            _send["institute"]          = "";
            _send["sentdatestartaudit"] = "";
            _send["sentdateendaudit"]   = "";
            _send["auditedstatus"]      = "";
            _send["exportstatus"]       = "";
            _send["sortorderby"]        = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-sortorderby"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                                          });
            _send["sortexpression"]     = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-sortexpression"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                                          });
            _send["rowperpage"]         = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionMain + "-rowperpage"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                                          });

            return _send;
        }
    },

    approvedocument: {
        idSectionMain: UDSStaffUtil.idSectionApproveDocumentMain.toLowerCase(),
        idSectionSearch: UDSStaffUtil.idSectionApproveDocumentSearch.toLowerCase(),

        //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการอนุมัติเอกสาร
        initSearch: function () {
            var _this = Util.tut.tse;

            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-degreelevel"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-faculty"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-yearattended"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-entrancetype"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-studentstatus"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-documentupload"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-approvalstatus"),
                width: 0,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-sortorderby"),
                width: 206,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-sortexpression"),
                width: 206,
                height: 27
            });

            this.resetSearch({});
        },

        //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการการอนุมัติเอกสาร
        //โดยมีพารามิเตอร์ดังนี้
        //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
        //reset     รับค่าสถานะการรีเซ็ต
        resetSearch: function (_param) {
            _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

            Util.dialogMessageClose();
            Util.gotoTopElement();
            Util.resetForm({
                id: (this.idSectionSearch + "-form")
            });

            $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-degreelevel"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-degreelevel-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-faculty"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-faculty-hidden").val())
            });
            Util.tut.setSelectDefaultCombobox({
                id: ("#" + this.idSectionSearch + "-program"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
            }, function () { });            
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-yearattended"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-entrancetype"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-studentstatus"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-documentupload"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-documentupload-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-approvalstatus"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-approvalstatus-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-sortorderby"),
                value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-sortexpression"),
                value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
            });
        },

        //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการอนุมัติเอกสาร
        validateSearch: function () {
            var _error = new Array();
            var _i = 0;

            if (Util.comboboxGetValue("#" + this.idSectionSearch + "-documentupload") == "0") { _error[_i] = "กรุณาเลือกเอกสารอัพโหลด;Please select document upload.;"; _i++; }

            Util.dialogListMessageError({
                content: _error
            });

            return (_i > 0 ? false : true);
        },

        //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการอนุมัติเอกสาร
        valueSearch: function () {
            var _send = {};
            _send["sectionaction"]      = "approve";
            _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
            _send["degreelevel"]        = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-degreelevel"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                                          });
            _send["faculty"]            = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-faculty"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                                          });
            _send["program"]            = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-program"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                                          }); 
            _send["yearentry"]          = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-yearattended"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                                          });
            _send["entrancetype"]       = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-entrancetype"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                          });
            _send["studentstatus"]      = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-studentstatus"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                          });
            _send["documentupload"]     = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-documentupload"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-documentupload")
                                          });
            _send["submittedstatus"]    = ""           
            _send["approvalstatus"]     = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-approvalstatus"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-approvalstatus")
                                          });
            _send["institutecountry"]   = "";
            _send["instituteprovince"]  = "";
            _send["institute"]          = "";
            _send["sentdatestartaudit"] = "";
            _send["sentdateendaudit"]   = "";
            _send["auditedstatus"]      = "";
            _send["exportstatus"]       = "";
            _send["sortorderby"]        = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-sortorderby"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                                          });
            _send["sortexpression"]     = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-sortexpression"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                                          });
            _send["rowperpage"]         = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionMain + "-rowperpage"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                                          });

            return _send;
        }
    },

    ourservices: {
        documentstatusstudent: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentMain.toLowerCase(),
            idSectionLevel1Main: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentLevel1ViewTableMain.toLowerCase(),
            idSectionSearch: UDSStaffUtil.idSectionOurServicesDocumentStatusStudentSearch.toLowerCase(),
            
            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของสถานะเอกสารของนักศึกษา
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-documentupload"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-approvalstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 206,
                    height: 27
                });

                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของสถานะเอกสารของนักศึกษา
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //reset     รับค่าสถานะการรีเซ็ต
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-degreelevel-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-faculty-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-program"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
                }, function () { });            
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-documentupload"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-documentupload-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-approvalstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-approvalstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของสถานะเอกสารของนักศึกษา
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของสถานะเอกสารของนักศึกษา
            valueSearch: function () {
                var _send = {};
                _send["sectionaction"]      = "submitapprove";
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-degreelevel"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                                              });
                _send["faculty"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-faculty"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                                              });
                _send["program"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-program"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                                              }); 
                _send["yearentry"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-yearattended"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                                              });
                _send["entrancetype"]       = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-entrancetype"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                              });
                _send["studentstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-studentstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                              });
                _send["documentupload"]     = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-documentupload"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-documentupload")
                                              });
                _send["submittedstatus"]    = ""           
                _send["approvalstatus"]     = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-approvalstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-approvalstatus")
                                              });
                _send["institutecountry"]   = "";
                _send["instituteprovince"]  = "";
                _send["institute"]          = "";
                _send["sentdatestartaudit"] = "";
                _send["sentdateendaudit"]   = "";
                _send["auditedstatus"]      = "";
                _send["exportstatus"]       = "";
                _send["sortorderby"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortorderby"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                                              });
                _send["sortexpression"]     = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortexpression"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                                              });
                _send["rowperpage"]         = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionLevel1Main + "-rowperpage"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionLevel1Main + "-rowperpage")
                                              });

                return _send;
            }
        },
        
        exportprofilepictureapproved: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesExportProfilePictureApprovedMain.toLowerCase(),
            idSectionSearch: UDSStaffUtil.idSectionOurServicesExportProfilePictureApprovedSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการส่งออกรูปภาพประจำตัวที่ผ่านการอนุมัติ
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-exportstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 206,
                    height: 27
                });
                
                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการส่งออกรูปภาพประจำตัวที่ผ่านการอนุมัติ
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //reset     รับค่าสถานะการรีเซ็ต
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-degreelevel-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-faculty-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-program"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
                }, function () { });            
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-exportstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-exportstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการส่งออกรูปภาพประจำตัวที่ผ่านการอนุมัติ
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการส่งออกรูปภาพประจำตัวที่ผ่านการอนุมัติ
            valueSearch: function () {
                var _send = {};
                _send["sectionaction"]      = "approve";
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-degreelevel"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                                              });
                _send["faculty"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-faculty"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                                              });
                _send["program"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-program"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                                              }); 
                _send["yearentry"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-yearattended"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                                              });
                _send["entrancetype"]       = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-entrancetype"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                              });
                _send["studentstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-studentstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                              });
                _send["documentupload"]     = "ProfilePictureIdentityCard";
                _send["submittedstatus"]    = "";
                _send["approvalstatus"]     = "Y";
                _send["institutecountry"]   = "";
                _send["instituteprovince"]  = "";
                _send["institute"]          = "";
                _send["sentdatestartaudit"] = "";
                _send["sentdateendaudit"]   = "";
                _send["auditedstatus"]      = "";
                _send["exportstatus"]       = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-exportstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-exportstatus")
                                              });
                _send["sortorderby"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortorderby"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                                              });
                _send["sortexpression"]     = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortexpression"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                                              });
                _send["rowperpage"]         = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionMain + "-rowperpage"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                                              });

                return _send;
            }
        },

        exportstudentrecordsinformationforsmartcard: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesExportStudentRecordsInformationForSmartCardMain.toLowerCase(),
            idSectionSearch: UDSStaffUtil.idSectionOurServicesExportStudentRecordsInformationForSmartCardSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการส่งออกข้อมูลนักศึกษาสำหรับทำบัตรนักศึกษา
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 206,
                    height: 27
                });
                
                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการส่งออกข้อมูลนักศึกษาสำหรับทำบัตรนักศึกษา
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //reset     รับค่าสถานะการรีเซ็ต
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-degreelevel-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-faculty-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-program"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
                }, function () { });            
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการส่งออกข้อมูลนักศึกษาสำหรับทำบัตรนักศึกษา
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการส่งออกข้อมูลนักศึกษาสำหรับทำบัตรนักศึกษา
            valueSearch: function () {
                var _send = {};                
                _send["sectionaction"]      = "submitapprove";
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-degreelevel"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                                              });
                _send["faculty"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-faculty"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                                              });
                _send["program"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-program"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                                              }); 
                _send["yearentry"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-yearattended"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                                              });
                _send["entrancetype"]       = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-entrancetype"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                              });
                _send["studentstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-studentstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                              });
                _send["documentupload"]     = "ProfilePicture"
                _send["submittedstatus"]    = "";           
                _send["approvalstatus"]     = "";
                _send["institutecountry"]   = "";
                _send["instituteprovince"]  = "";
                _send["institute"]          = "";
                _send["sentdatestartaudit"] = "";
                _send["sentdateendaudit"]   = "";
                _send["auditedstatus"]      = "";
                _send["exportstatus"]       = "";
                _send["sortorderby"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortorderby"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                                              });
                _send["sortexpression"]     = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortexpression"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                                              });
                _send["rowperpage"]         = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionMain + "-rowperpage"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                                              });

                return _send;
            }
        },

        copyprofilepictureapprovedtothestore: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesCopyProfilePictureApprovedtotheStoreMain.toLowerCase(),
            idSectionSearch: UDSStaffUtil.idSectionOurServicesCopyProfilePictureApprovedtotheStoreSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการคัดลอกรูปภาพประจำตัวที่ผ่านการอนุมัติไปยังที่เก็บรูป
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 206,
                    height: 27
                });
              
                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการคัดลอกรูปภาพประจำตัวที่ผ่านการอนุมัติไปยังที่เก็บรูป
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //reset     รับค่าสถานะการรีเซ็ต
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-degreelevel-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-faculty-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-program"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
                }, function () { });            
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการคัดลอกรูปภาพประจำตัวที่ผ่านการอนุมัติไปยังที่เก็บรูป
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการคัดลอกรูปภาพประจำตัวที่ผ่านการอนุมัติไปยังที่เก็บรูป
            valueSearch: function () {
                var _send = {};
                _send["sectionaction"]      = "approve";
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-degreelevel"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                                              });
                _send["faculty"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-faculty"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                                              });
                _send["program"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-program"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                                              }); 
                _send["yearentry"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-yearattended"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                                              });
                _send["entrancetype"]       = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-entrancetype"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                              });
                _send["studentstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-studentstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                              });
                _send["documentupload"]     = "ProfilePictureIdentityCard";
                _send["submittedstatus"]    = "";
                _send["approvalstatus"]     = "Y";
                _send["institutecountry"]   = "";
                _send["instituteprovince"]  = "";
                _send["institute"]          = "";
                _send["sentdatestartaudit"] = "";
                _send["sentdateendaudit"]   = "";
                _send["auditedstatus"]      = "";
                _send["exportstatus"]       = "";
                _send["sortorderby"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortorderby"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                                              });
                _send["sortexpression"]     = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortexpression"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                                              });
                _send["rowperpage"]         = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionMain + "-rowperpage"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                                              });

                return _send;
            }
        },

        audittranscriptapproved: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedMain.toLowerCase(),
            idSectionSearch: UDSStaffUtil.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการตรวจสอบวุฒิการศึกษาจากระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติกับสถานศึกษาตันสังกัด
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-institutecountry"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 206,
                    height: 27
                });

                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการตรวจสอบวุฒิการศึกษาจากระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติกับสถานศึกษาตันสังกัด
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //reset     รับค่าสถานะการรีเซ็ต
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                var _this = this;
                
                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-degreelevel-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-faculty-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-program"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
                }, function () { });            
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-institutecountry"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-institutecountry-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-instituteprovince"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-instituteprovince-hidden").val())
                }, function () {
                    Util.tut.setSelectDefaultCombobox({
                        id: ("#" + _this.idSectionSearch + "-institute"),
                        value: (_param["reset"] == true ? "0" : $("#" + _this.idSectionSearch + "-institute-hidden").val())
                    }, function () { });
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการตรวจสอบวุฒิการศึกษาจากระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติกับสถานศึกษาตันสังกัด
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการตรวจสอบวุฒิการศึกษาจากระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติกับสถานศึกษาตันสังกัด
            valueSearch: function () {
                var _send = {};
                _send["sectionaction"]      = "submitapprove";
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-degreelevel"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                                              });
                _send["faculty"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-faculty"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                                              });
                _send["program"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-program"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                                              }); 
                _send["yearentry"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-yearattended"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                                              });
                _send["entrancetype"]       = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-entrancetype"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                              });
                _send["studentstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-studentstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                              });
                _send["documentupload"]     = "TranscriptFrontsideTranscriptBackside";
                _send["submittedstatus"]    = ""           
                _send["approvalstatus"]     = "";
                _send["institutecountry"]   = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-institutecountry"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-institutecountry")
                                              });
                _send["instituteprovince"]  = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-instituteprovince"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-instituteprovince")
                                              });
                _send["institute"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-institute"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-institute")
                                              });
                _send["sentdatestartaudit"] = "";
                _send["sentdateendaudit"]   = "";
                _send["auditedstatus"]      = "";
                _send["exportstatus"]       = "";
                _send["sortorderby"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortorderby"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                                              });
                _send["sortexpression"]     = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortexpression"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                                              });
                _send["rowperpage"]         = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionMain + "-rowperpage"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                                              });

                return _send;
            }
        },

        exportsaveaudittranscriptapproved: {
            idSectionMain: UDSStaffUtil.idSectionOurServicesExportSaveAuditTranscriptApprovedMain.toLowerCase(),
            idSectionSearch: UDSStaffUtil.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการส่งออกระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติและบันทึกการตรวจสอบวุฒิการศึกษากับสถานศึกษาต้นสังกัด
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-institutecountry"),
                    width: 0,
                    height: 27
                });
                Util.initCalendarFromTo({
                    idFrom: ("#" + this.idSectionSearch + "-sentdatestartaudit"),
                    idTo: ("#" + this.idSectionSearch + "-sentdateendaudit")
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-auditedstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 206,
                    height: 27
                });

                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการส่งออกระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติและบันทึกการตรวจสอบวุฒิการศึกษากับสถานศึกษาต้นสังกัด
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //reset     รับค่าสถานะการรีเซ็ต
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                var _this = this;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-degreelevel-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-faculty-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-program"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
                }, function () { });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-institutecountry"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-institutecountry-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-instituteprovince"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-instituteprovince-hidden").val())
                }, function () {
                    Util.tut.setSelectDefaultCombobox({
                        id: ("#" + _this.idSectionSearch + "-institute"),
                        value: (_param["reset"] == true ? "0" : $("#" + _this.idSectionSearch + "-institute-hidden").val())
                    }, function () { });
                });
                $("#" + this.idSectionSearch + "-sentdatestartaudit").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-sentdatestartaudit-hidden").val());
                $("#" + this.idSectionSearch + "-sentdateendaudit").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-sentdateendaudit-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-auditedstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-auditedstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการส่งออกระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติและบันทึกการตรวจสอบวุฒิการศึกษากับสถานศึกษาต้นสังกัด
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                if ($("#" + this.idSectionSearch + "-sentdatestartaudit").val().length > 0 && $("#" + this.idSectionSearch + "-sentdateendaudit").val().length == 0) { _error[_i] = "กรุณาใส่วันที่ส่งระเบียนแสดงผลการเรียนตรวจสอบให้ครบถ้วน;Please enter sent date transcript audit in the form completely.;"; _i++; }
                if ($("#" + this.idSectionSearch + "-sentdatestartaudit").val().length == 0 && $("#" + this.idSectionSearch + "-sentdateendaudit").val().length > 0) { _error[_i] = "กรุณาใส่วันที่ส่งระเบียนแสดงผลการเรียนตรวจสอบให้ครบถ้วน;Please enter sent date transcript audit in the form completely.;"; _i++; }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการส่งออกระเบียนแสดงผลการเรียนที่ผ่านการอนุมัติและบันทึกการตรวจสอบวุฒิการศึกษากับสถานศึกษาต้นสังกัด
            valueSearch: function () {
                var _send = {};
                _send["sectionaction"]      = "approve";
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-degreelevel"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                                              });
                _send["faculty"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-faculty"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                                              });
                _send["program"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-program"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                                              }); 
                _send["yearentry"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-yearattended"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                                              });
                _send["entrancetype"]       = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-entrancetype"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                              });
                _send["studentstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-studentstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                              });
                _send["documentupload"]     = "TranscriptFrontsideTranscriptBackside";
                _send["submittedstatus"]    = ""           
                _send["approvalstatus"]     = "Y";
                _send["institutecountry"]   = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-institutecountry"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-institutecountry")
                                              });
                _send["instituteprovince"]  = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-instituteprovince"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-instituteprovince")
                                              });
                _send["institute"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-institute"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-institute")
                                              });
                _send["sentdatestartaudit"] = $("#" + this.idSectionSearch + "-sentdatestartaudit").val();
                _send["sentdateendaudit"]   = $("#" + this.idSectionSearch + "-sentdateendaudit").val();
                _send["auditedstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-auditedstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-auditedstatus")
                                              });
                _send["exportstatus"]       = "";
                _send["sortorderby"]        = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortorderby"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                                              });
                _send["sortexpression"]     = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-sortexpression"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                                              });
                _send["rowperpage"]         = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionMain + "-rowperpage"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                                              });

                return _send;
            }
        }    
    }    
}