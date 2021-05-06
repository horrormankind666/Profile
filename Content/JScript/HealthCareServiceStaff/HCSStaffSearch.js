// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๖/๐๗/๒๕๕๘>
// Modify date  : <๑๔/๐๒/๒๕๖๓>
// Description  : <รวมรวบฟังก์ชั่นใช้งานในส่วนของการค้นหาข้อมูล>
// =============================================

var HCSStaffSearch = {
    //ฟังก์ชั่นสำหรับกำหนดการแสดงผลให้กับฟอร์มค้นหาข้อมูล
    setSearchLayout: function () {
        var _width = (($(".search").width($(".form.search .search-layout").is(":visible") ? $(".form.search .search-layout").width() : 0)).width() - 10);

        $("#bodysearch").css({
            "top": ((Util.offsetTop - 3) + "px")
        });
        $(".form.search .form-content .form-inputcol .form-input .inputbox").width(_width - 8);
        Util.comboboxSetSize({
            id: ".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox",
            width: _width,
            height: 25
        });
        $(".form.search .search-layout, .form.search .button-toggle a").height($(window).height() - Util.offsetTop);
        $(".form.search .button-toggle").css({
            "left": (($(".form.search .search-layout").is(":visible") ? $(".form.search .search-layout").width() : 0) + "px")
        });
        $(".form.search .button-toggle a").css({
            "padding-top": (($(".form.search .button-toggle a").height() / 3) + "px")
        });
        $(".form.search .form-content .button .button-content ul li div").css({
            "width": ((_width / 2) - 3 + "px"),
            "height": "30px",
            "line-height": "30px"
        });
    },

    //ฟังก์ชั่นสำหรับลบเนื้อหาในตารางแสดงรายการ
    clearTable: function () {
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
        var _valueParam = {};
        var _idChart;
        var _idTable;
        var _valueSearchResult = {};

        if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceMain)
        {
            _pageMain                       = Util.tut.pageMasterDataHospitalOfHealthCareServiceMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.masterdata.hospitalofhealthcareservice.valueSearch();
            _idChart                        = "";
            _idTable                        = (Util.tut.tmd.hospitalofhealthcareservice.idSectionMain + "-table");
        }
        
        if (_param["page"] == Util.tut.pageMasterDataRegistrationFormMain)
        {
            _pageMain                       = Util.tut.pageMasterDataRegistrationFormMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.masterdata.registrationform.valueSearch();
            _idChart                        = "";
            _idTable                        = (Util.tut.tmd.registrationform.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataAgencyRegisteredMain)
        {
            _pageMain                       = Util.tut.pageMasterDataAgencyRegisteredMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.masterdata.agencyregistered.valueSearch();
            _idChart                        = "";
            _idTable                        = (Util.tut.tmd.agencyregistered.idSectionMain + "-table");
        }
        
        if (_param["page"] == Util.tut.pageDownloadRegistrationFormMain)
        {
            _pageMain                       = Util.tut.pageDownloadRegistrationFormMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.downloadregistrationform.valueSearch();
            _idChart                        = "";
            _idTable                        = (Util.tut.tdf.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesHealthInformationMain)
        {
            _pageMain                       = Util.tut.pageOurServicesHealthInformationMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.ourservices.healthinformation.valueSearch();
            _idChart                        = "";
            _idTable                        = (Util.tut.tos.healthinformation.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormViewChartMain)
        {
            _pageMain                       = Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.ourservices.statisticsdownloadhealthcareserviceform.valueSearch();
            _idChart                        = (Util.tut.tos.statisticsdownloadhealthcareserviceform.viewchart.idSectionMain + "-chart");
            _idTable                        = "";
        }

        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain)
        {
            _pageMain                       = Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.ourservices.statisticsdownloadhealthcareserviceform.valueSearch();
            _idChart                        = "";
            _idTable                        = (Util.tut.tos.statisticsdownloadhealthcareserviceform.viewtable.idSectionLevel1Main + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain)
        {            
            _pageMain                       = Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.ourservices.statisticsdownloadhealthcareserviceform.valueSearch();
            _valueParam["registrationform"] = Util.tut.tos.statisticsdownloadhealthcareserviceform.viewtable.registrationForm;
            _valueParam["yearentry"]        = Util.tut.tos.statisticsdownloadhealthcareserviceform.viewtable.yearEntry;
            _valueParam["rowperpage"]       = 100;
            _idChart                        = "";
            _idTable                        = (Util.tut.tos.statisticsdownloadhealthcareserviceform.viewtable.idSectionLevel2Main + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentRegistrationMain ||
            _param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentOOCAMain)
        {
            _pageMain                       = HCSStaffOurServices.termservicehcsconsent.pageMain;
            _pageSearch                     = _param["page"];
            _valueParam                     = this.ourservices.termservicehcsconsent.valueSearch();
            _idChart                        = "";
            _idTable                        = (Util.tut.tos.termservicehcsconsent.idSectionMain + "-table");
        }

        _valueSearchResult["pagemain"]      = _pageMain;
        _valueSearchResult["pagesearch"]    = _pageSearch;
        _valueSearchResult["paramsearch"]   = _valueParam;
        _valueSearchResult["chart"]         = _idChart;
        _valueSearchResult["table"]         = _idTable;        

        return _valueSearchResult
    },
    
    //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้า
    resetSearch: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this = null;

        if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceMain)               _this = this.masterdata.hospitalofhealthcareservice;
        if (_param["page"] == Util.tut.pageMasterDataRegistrationFormMain)                          _this = this.masterdata.registrationform;
        if (_param["page"] == Util.tut.pageMasterDataAgencyRegisteredMain)                          _this = this.masterdata.agencyregistered;
        if (_param["page"] == Util.tut.pageDownloadRegistrationFormMain)                            _this = this.downloadregistrationform;
        if (_param["page"] == Util.tut.pageOurServicesHealthInformationMain)                        _this = this.ourservices.healthinformation;
        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormMain)  _this = this.ourservices.statisticsdownloadhealthcareserviceform;
        if (_param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentRegistrationMain)        _this = this.ourservices.termservicehcsconsent;
        if (_param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentOOCAMain)                _this = this.ourservices.termservicehcsconsent;


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

        if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceMain)               _this = this.masterdata.hospitalofhealthcareservice;
        if (_param["page"] == Util.tut.pageMasterDataRegistrationFormMain)                          _this = this.masterdata.registrationform;
        if (_param["page"] == Util.tut.pageMasterDataAgencyRegisteredMain)                          _this = this.masterdata.agencyregistered;
        if (_param["page"] == Util.tut.pageDownloadRegistrationFormMain)                            _this = this.downloadregistrationform;
        if (_param["page"] == Util.tut.pageOurServicesHealthInformationMain)                        _this = this.ourservices.healthinformation;
        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormMain)  _this = this.ourservices.statisticsdownloadhealthcareserviceform;
        if (_param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentRegistrationMain)        _this = this.ourservices.termservicehcsconsent;
        if (_param["page"] == Util.tut.pageOurServicesTermServiceHCSConsentOOCAMain)                _this = this.ourservices.termservicehcsconsent;

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

        var _reset = true;
        var _idContent;

        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormMain)
        {
            _idContent      = Util.getTabActiveOnTabbar({
                                id: (Util.tut.tos.statisticsdownloadhealthcareserviceform.idSectionMain + "-viewsdisplay")
                              });
            _param["page"]  = $("#" + _idContent).attr("alt");

            if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormViewTableMain)
                _param["page"] = Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain;
        }

        if (_param["page"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain) _reset = false;

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
            if (_param["pageSearch"] == Util.tut.pageDownloadRegistrationFormMain) Util.tut.tdf.sectionMain.initTable();
            if (_param["pageSearch"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain)
            {
                Util.tut.tos.statisticsdownloadhealthcareserviceform.viewtable.sectionMain.initMain({
                    page: _param["pageSearch"]
                });
                Util.tut.tos.statisticsdownloadhealthcareserviceform.viewtable.sectionMain.initTable({
                    page: _param["pageSearch"]
                });
            }
            if (_param["pageSearch"] == Util.tut.pageOurServicesTermServiceHCSConsentRegistrationMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesTermServiceHCSConsentOOCAMain)
                Util.tut.tos.termservicehcsconsent.sectionMain.initTable();

            Util.setChartLayout();
            Util.setTableLayout();
            Util.initTable();
            Util.gotoTopElement();
        });
    },

    masterdata: {
        hospitalofhealthcareservice: {
            idSectionMain: HCSStaffUtil.idSectionMasterDataHospitalOfHealthCareServiceMain.toLowerCase(),
            idSectionSearch: HCSStaffUtil.idSectionMasterDataHospitalOfHealthCareServiceSearch.toLowerCase(),            
            
            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข่้อมูลหน่วยบริการสุขภาพ
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 188,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 188,
                    height: 25
                });

                _this.setSearchLayout();
                this.resetSearch({});
            },
            
            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ
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
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-cancelledstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            
            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ
            valueSearch: function () {
                var _send = {};
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"]    = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
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
        
        registrationform: {
            idSectionMain: HCSStaffUtil.idSectionMasterDataRegistrationFormMain.toLowerCase(),
            idSectionSearch: HCSStaffUtil.idSectionMasterDataRegistrationFormSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-forpublicservant"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 188,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 188,
                    height: 25
                });

                _this.setSearchLayout();
                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ
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
                    id: ("#" + this.idSectionSearch + "-forpublicservant"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-forpublicservant-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-cancelledstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Order Form" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลแบบฟอร์มบริการสุขภาพ
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยบริการสุขภาพ
            valueSearch: function () {
                var _send = {};
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["forpublicservant"]   = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-forpublicservant"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-forpublicservant")
                                              });
                _send["cancelledstatus"]    = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
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
        
        agencyregistered: {
            idSectionMain: HCSStaffUtil.idSectionMasterDataAgencyRegisteredMain.toLowerCase(),
            idSectionSearch: HCSStaffUtil.idSectionMasterDataAgencyRegisteredSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-hospital"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-registrationform"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 188,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 188,
                    height: 25
                });
                
                _this.setSearchLayout();
                this.resetSearch({});
            },
            
            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล
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
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
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
                    id: ("#" + this.idSectionSearch + "-hospital"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-hospital-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-registrationform"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-registrationform-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-cancelledstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Program" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },
            
            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการจัดการข้อมูลหลัก-ข้อมูลหน่วยงานที่ขึ้นทะเบียนสิทธิรักษาพยาบาล
            valueSearch: function () {
                var _send = {};
                _send["yearentry"]          = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-yearattended"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
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
                _send["hospital"]           = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-hospital"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-hospital")
                                              });
                _send["registrationform"]   = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-registrationform"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-registrationform")
                                              });
                _send["cancelledstatus"]    = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
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
        }
    },
    
    downloadregistrationform: {
        idSectionMain: HCSStaffUtil.idSectionDownloadRegistrationFormMain.toLowerCase(),
        idSectionSearch: HCSStaffUtil.idSectionDownloadRegistrationFormSearch.toLowerCase(),

        //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของการขึ้นทะเบียนสิทธิรักษาพยาบาล
        initSearch: function () {
            var _this = Util.tut.tse;

            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-registrationform"),
                width: 0,
                height: 25
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-yearattended"),
                width: 0,
                height: 25
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-entrancetype"),
                width: 0,
                height: 25
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-downloadstatus"),
                width: 0,
                height: 25
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-sortorderby"),
                width: 188,
                height: 25
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-sortexpression"),
                width: 188,
                height: 25
            });

            _this.setSearchLayout();
            this.resetSearch({});
        },
        
        //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของการขึ้นทะเบียนสิทธิรักษาพยาบาล
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

            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-registrationform"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-registrationform-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-yearattended"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
            });
            Util.tut.setSelectDefaultCombobox({
                id: ("#" + this.idSectionSearch + "-program"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-program-hidden").val())
            }, function () { });
            $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-entrancetype"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-downloadstatus"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-downloadstatus-hidden").val())
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
        
        //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการขึ้นทะเบียนสิทธิรักษาพยาบาล
        validateSearch: function () {
            var _error = new Array();
            var _i = 0;

            if (Util.comboboxGetValue("#" + this.idSectionSearch + "-registrationform") == "0") { _error[_i] = "กรุณาเลือกแบบฟอร์มบริการสุขภาพ;Please select health care service form.;"; _i++; }

            Util.dialogListMessageError({
                content: _error
            });

            return (_i > 0 ? false : true);
        },
        
        //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของการขึ้นทะเบียนสิทธิรักษาพยาบาล
        valueSearch: function () {
            var _send = {};
            _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
            _send["degreelevel"]        = "";
            _send["faculty"]            = "";
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
            _send["studentstatus"]      = "";
            _send["hcsjoin"]            = "Y";
            _send["registrationform"]   = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-registrationform"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-registrationform")
                                          });           
            _send["downloadstatus"]     = Util.getSelectionIsSelect({
                                            id: ("#" + this.idSectionSearch + "-downloadstatus"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-downloadstatus")
                                          });
            _send["termservicetype"]    = "";
            _send["consentstatus"]      = "";
            _send["termservicenote"]    = "";
            _send["consentdatestart"]   = "";
            _send["consentdateend"]     = "";
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
        healthinformation: {
            idSectionMain: HCSStaffUtil.idSectionOurServicesHealthInformationMain.toLowerCase(),
            idSectionSearch: HCSStaffUtil.idSectionOurServicesHealthInformationSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของประวัติสุขภาพนักศึกษา
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-hcsjoin"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 188,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 188,
                    height: 25
                });

                _this.setSearchLayout();
                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของประวัติสุขภาพนักศึกษา
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
                    id: ("#" + this.idSectionSearch + "-hcsjoin"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-hcsjoin-hidden").val())
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

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของประวัติสุขภาพนักศึกษา
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของประวัติสุขภาพนักศึกษา
            valueSearch: function () {
                var _send = {};
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = "";
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
                _send["studentstatus"]      = "";
                _send["hcsjoin"]            = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-hcsjoin"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-hcsjoin")
                                              });
                _send["registrationform"]   = "";
                _send["downloadstatus"]     = "";
                _send["termservicetype"]    = "";
                _send["consentstatus"]      = "";
                _send["termservicenote"]    = "";
                _send["consentdatestart"]   = "";
                _send["consentdateend"]     = "";
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

        statisticsdownloadhealthcareserviceform: {
            idSectionMain: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormMain.toLowerCase(),
            idSectionSearch: HCSStaffUtil.idSectionOurServicesStatisticsDownloadHealthCareServiceFormSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของสถิติการดาวน์โหลดแบบฟอร์มบริการสุขภาพ
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 188,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 188,
                    height: 25
                });

                _this.setSearchLayout();
                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของสถิติการดาวน์โหลดแบบฟอร์มบริการสุขภาพ
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

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของสถิติการดาวน์โหลดแบบฟอร์มบริการสุขภาพ
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของสถิติการดาวน์โหลดแบบฟอร์มบริการสุขภาพ
            valueSearch: function () {
                var _send = {};
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = "";
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
                _send["hcsjoin"]            = "";
                _send["registrationform"]   = "";
                _send["downloadstatus"]     = "";
                _send["termservicetype"]    = "";
                _send["consentstatus"]      = "";
                _send["termservicenote"]    = "";
                _send["consentdatestart"]   = "";
                _send["consentdateend"]     = "";
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

        termservicehcsconsent: {
            idSectionMain: HCSStaffUtil.idSectionOurServicesTermServiceHCSConsentMain.toLowerCase(),
            idSectionSearch: HCSStaffUtil.idSectionOurServicesTermServiceHCSConsentSearch.toLowerCase(),

            //ฟังก์ชั่นสำหรับกำหนดการกระทำต่าง ๆ ที่เกิดขึ้นบนฟอร์มค้นหาข้อมูลในส่วนของจัดการข้อมูลการแสดงความยินยอมให้ข้อมูล
            initSearch: function () {
                var _this = Util.tut.tse;
                
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    width: 0,
                    height: 25
                });
                /*
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    width: 0,
                    height: 25
                });
                */
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    width: 0,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-consentstatus"),
                    width: 0,
                    height: 25
                });

                if (HCSStaffOurServices.termservicehcsconsent.pageMain == HCSStaffUtil.pageOurServicesTermServiceHCSConsentRegistrationMain)
                    Util.initCombobox({
                        id: ("#" + this.idSectionSearch + "-hospital"),
                        width: 0,
                        height: 25
                    });

                Util.initCalendarFromTo({
                    idFrom: ("#" + this.idSectionSearch + "-consentdatestart"),
                    idTo: ("#" + this.idSectionSearch + "-consentdateend")
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    width: 188,
                    height: 25
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    width: 188,
                    height: 25
                });

                _this.setSearchLayout();
                this.resetSearch({});
            },

            //ฟังก์ชั่นสำหรับรีเซ็ตฟอร์มค้นหาข้อมูลในส่วนของจัดการข้อมูลการแสดงความยินยอมให้ข้อมูล
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
                /*
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-entrancetype-hidden").val())
                });
                */
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-consentstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-consentstatus-hidden").val())
                });

                if (HCSStaffOurServices.termservicehcsconsent.pageMain == HCSStaffUtil.pageOurServicesTermServiceHCSConsentRegistrationMain)
                    Util.comboboxSetValue({
                        id: ("#" + this.idSectionSearch + "-hospital"),
                        value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-termservicenote-hidden").val())
                    });

                $("#" + this.idSectionSearch + "-consentdatestart").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-consentdatestart-hidden").val());
                $("#" + this.idSectionSearch + "-consentdateend").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-consentdateend-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    value: (_param["reset"] == true ? "Student ID" : $("#" + this.idSectionSearch + "-sortorderby-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    value: (_param["reset"] == true ? "Ascending" : $("#" + this.idSectionSearch + "-sortexpression-hidden").val())
                });
            },

            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องของพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของจัดการข้อมูลการแสดงความยินยอมให้ข้อมูล
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                if ($("#" + this.idSectionSearch + "-consentdatestart").val().length > 0 && $("#" + this.idSectionSearch + "-consentdateend").val().length == 0) { _error[_i] = "กรุณาใส่วันที่แสดงความยินยอมให้ครบถ้วน;Please enter date of consent in the form completely.;"; _i++; }
                if ($("#" + this.idSectionSearch + "-consentdatestart").val().length == 0 && $("#" + this.idSectionSearch + "-consentdateend").val().length > 0) { _error[_i] = "กรุณาใส่วันที่แสดงความยินยอมให้ครบถ้วน;Please enter date of consent in the form completely.;"; _i++; }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั้นสำหรับกำหนดพารามิเตอร์ที่ใช้ค้นหาข้อมูลในส่วนของจัดการข้อมูลการแสดงความยินยอมให้ข้อมูล
            valueSearch: function () {
                var _termServiceType;
                var _termServiceNote;

                if (HCSStaffOurServices.termservicehcsconsent.pageMain == HCSStaffUtil.pageOurServicesTermServiceHCSConsentRegistrationMain)
                {
                    _termServiceType = "HCS_CONSENT_REGISTRATION";
                    _termServiceNote = Util.getSelectionIsSelect({
                                        id: ("#" + this.idSectionSearch + "-hospital"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-hospital")
                                       });
                }
                if (HCSStaffOurServices.termservicehcsconsent.pageMain == HCSStaffUtil.pageOurServicesTermServiceHCSConsentOOCAMain)
                {
                    _termServiceType = "HCS_CONSENT_OOCA";
                    _termServiceNote = "";
                }

                var _send = {};
                _send["keyword"]            = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"]        = "";
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
                /*
                _send["entrancetype"]       = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-entrancetype"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                                              });
                */
                _send["entrancetype"]       = "";
                _send["studentstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-studentstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                                              });
                _send["hcsjoin"]            = "";
                _send["registrationform"]   = "";
                _send["downloadstatus"]     = "";
                _send["termservicetype"]    = _termServiceType;
                _send["consentstatus"]      = Util.getSelectionIsSelect({
                                                id: ("#" + this.idSectionSearch + "-consentstatus"),
                                                type: "select",
                                                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-consentstatus")
                });
                _send["termservicenote"]    = _termServiceNote;
                _send["consentdatestart"]   = $("#" + this.idSectionSearch + "-consentdatestart").val();
                _send["consentdateend"]     = $("#" + this.idSectionSearch + "-consentdateend").val();
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