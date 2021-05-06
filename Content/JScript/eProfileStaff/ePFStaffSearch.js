/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๖/๐๑/๒๕๕๘>
Modify date : <๐๕/๐๓/๒๕๖๔>
Description : <รวมรวบฟังก์ชั่นใช้งานในส่วนของการค้นหาข้อมูล>
=============================================
*/

var ePFStaffSearch = {
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
        $(".form.search .form-content .form-labelcol, .form.search .form-content .form-labelcol .form-label, .form.search .form-content .form-inputcol").width(_widthParent);
        $(".form.search .form-content .form-inputcol .form-input .inputbox").width(_widthParent - 8);
        Util.comboboxSetSize({
            id: ".form.search .form-content .combobox-width-dynamic .combobox",
            width: _widthParent,
            height: 27
        });

        for(_i = 1; _i <= $(".form.search .form-content .search-floatcol").length; _i++) {
            _col = $(".form.search .form-content .search-floatcol" + _i + " .contentbody-left").length;

            if (_col > 0) {
                _width = ((_widthParent / _col) - 3);
            
                $(".form.search .form-content .search-floatcol" + _i + " .contentbody-left:first-child, " +
                  ".form.search .form-content .search-floatcol" + _i + " .contentbody-left:last-child, " +
                  ".form.search .form-content .search-floatcol .form-labelcol .form-label").width(_width);
                
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
    clearTable: function () {
        var _this1;
        var _this2;
        var _this3;
        var _page = $("#page").html();
        var _idContent;
        var _idChart;
        var _idTable;
    },
    getValueSearch: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this;
        var _cmd;
        var _pageMain;
        var _pageSearch;
        var _valueParam = {}
        var _idChart;
        var _idTable;
        var _valueSearchResult = {};
        
        if (_param["page"] == Util.tut.pageMasterDataTitlePrefixMain) {
            _pageMain = Util.tut.pageMasterDataTitlePrefixMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.titleprefix.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.titleprefix.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataGenderMain) {
            _pageMain = Util.tut.pageMasterDataGenderMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.gender.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.gender.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataNationalityRaceMain) {
            _pageMain = Util.tut.pageMasterDataNationalityRaceMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.nationalityrace.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.nationalityrace.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataReligionMain) {
            _pageMain = Util.tut.pageMasterDataReligionMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.religion.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.religion.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataBloodGroupMain) {
            _pageMain = Util.tut.pageMasterDataBloodGroupMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.bloodgroup.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.bloodgroup.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataMaritalStatusMain) {
            _pageMain = Util.tut.pageMasterDataMaritalStatusMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.maritalstatus.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.maritalstatus.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataFamilyRelationshipsMain) {
            _pageMain = Util.tut.pageMasterDataFamilyRelationshipsMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.familyrelationships.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.familyrelationships.idSectionMain + "-table");
        }
        
        if (_param["page"] == Util.tut.pageMasterDataAgencyMain) {
            _pageMain = Util.tut.pageMasterDataAgencyMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.agency.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.agency.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataEducationalLevelMain) {
            _pageMain = Util.tut.pageMasterDataEducationalLevelMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.educationallevel.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.educationallevel.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataEducationalBackgroundMain) {
            _pageMain = Util.tut.pageMasterDataEducationalBackgroundMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.educationalbackground.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.educationalbackground.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataEducationalMajorMain) {
            _pageMain = Util.tut.pageMasterDataEducationalMajorMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.educationalmajor.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.educationalmajor.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataAdmissionTypeMain) {
            _pageMain = Util.tut.pageMasterDataAdmissionTypeMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.admissiontype.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.admissiontype.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataStudentStatusMain) {
            _pageMain = Util.tut.pageMasterDataStudentStatusMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.studentstatus.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.studentstatus.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataCountryMain) {
            _pageMain = Util.tut.pageMasterDataCountryMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.country.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.country.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataProvinceMain) {
            _pageMain = Util.tut.pageMasterDataProvinceMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.province.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.province.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataDistrictMain) {
            _pageMain = Util.tut.pageMasterDataDistrictMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.district.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.district.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataSubdistrictMain) {
            _pageMain = Util.tut.pageMasterDataSubdistrictMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.subdistrict.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.subdistrict.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataInstituteMain) {
            _pageMain = Util.tut.pageMasterDataInstituteMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.institute.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.institute.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataDiseasesMain) {
            _pageMain = Util.tut.pageMasterDataDiseasesMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.diseases.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.diseases.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageMasterDataHealthImpairmentsMain) {
            _pageMain = Util.tut.pageMasterDataHealthImpairmentsMain;
            _pageSearch = _param["page"];
            _valueParam = this.masterdata.healthimpairments.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tmd.healthimpairments.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageAdministrationStudentRecordsMain) {
            _pageMain = Util.tut.pageAdministrationStudentRecordsMain;
            _pageSearch = _param["page"];
            _valueParam = this.studentrecords.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tsr.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationMain) {
            _pageMain = Util.tut.pageOurServicesExportStudentRecordsInformationMain;
            _pageSearch = _param["page"];
            _valueParam = this.ourservices.exportstudentrecordsinformation.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tos.exportstudentrecordsinformation.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesUpdateStudentDistinctionProgramMain) {
            _pageMain = Util.tut.pageOurServicesUpdateStudentDistinctionProgramMain;
            _pageSearch = _param["page"];
            _valueParam = this.ourservices.updatestudentdistinctionprogram.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tos.updatestudentdistinctionprogram.idSectionMain + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentViewChartMain) {
            _pageMain = Util.tut.pageOurServicesSummaryNumberOfStudentMain;
            _pageSearch = _param["page"];
            _valueParam = this.ourservices.summarynumberofstudent.valueSearch();
            _idChart = (Util.tut.tos.summarynumberofstudent.viewchart.idSectionMain + "-chart");
            _idTable = "";
        }

        if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain) {
            _pageMain = Util.tut.pageOurServicesSummaryNumberOfStudentMain;
            _pageSearch = _param["page"];
            _valueParam = this.ourservices.summarynumberofstudent.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tos.summarynumberofstudent.viewtable.idSectionLevel1Main + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel2ViewTableMain) {            
            _this = Util.tut.tos.summarynumberofstudent.viewtable;
            _pageMain = Util.tut.pageOurServicesSummaryNumberOfStudentMain;
            _pageSearch = _param["page"];
            _valueParam = this.ourservices.summarynumberofstudent.valueSearch();
            _valueParam["gender"] = _this.gender;
            _valueParam["studentstatusgroup"] = _this.studentStatusGroup
            _valueParam["degreelevel"] = (_this.degreeLevel.length > 0 ? _this.degreeLevel : _valueParam["degreelevel"]);
            _valueParam["yearentry"] = (_this.yearEntry.length > 0 ? _this.yearEntry : _valueParam["yearentry"]);
            _valueParam["entrancetype"] = (_this.entranceType.length > 0 ? _this.entranceType : _valueParam["entrancetype"]);
            _valueParam["class"] = (_this.class.length > 0 ? _this.class : _valueParam["class"]);
            _valueParam["nationality"] = _this.nationality;
            _valueParam["faculty"] = (_this.faculty.length > 0 ? _this.faculty : _valueParam["faculty"]);
            _valueParam["program"] = (_this.program.length > 0 ? _this.program : _valueParam["program"]);
            _valueParam["rowperpage"] = 100;
            _idChart = "";
            _idTable = (Util.tut.tos.summarynumberofstudent.viewtable.idSectionLevel2Main + "-table");
        }

        if (_param["page"] == Util.tut.pageOurServicesTransactionLogStudentRecordsMain) {
            _pageMain = Util.tut.pageOurServicesTransactionLogStudentRecordsMain;
            _pageSearch = _param["page"];
            _valueParam = this.ourservices.transactionlogstudentrecords.valueSearch();
            _idChart = "";
            _idTable = (Util.tut.tos.transactionlogstudentrecords.idSectionMain + "-table");
        }

        _valueSearchResult["pagemain"] = _pageMain;
        _valueSearchResult["pagesearch"] = _pageSearch;
        _valueSearchResult["paramsearch"] = _valueParam
        _valueSearchResult["chart"] = _idChart;
        _valueSearchResult["table"] = _idTable;        

        return _valueSearchResult;
    },
    resetSearch: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this = null;

        if (_param["page"] == Util.tut.pageMasterDataTitlePrefixMain)
            _this = this.masterdata.titleprefix;

        if (_param["page"] == Util.tut.pageMasterDataGenderMain)
            _this = this.masterdata.gender;

        if (_param["page"] == Util.tut.pageMasterDataNationalityRaceMain)
            _this = this.masterdata.nationalityrace;

        if (_param["page"] == Util.tut.pageMasterDataReligionMain)
            _this = this.masterdata.religion;

        if (_param["page"] == Util.tut.pageMasterDataBloodGroupMain)
            _this = this.masterdata.bloodgroup;

        if (_param["page"] == Util.tut.pageMasterDataMaritalStatusMain)
            _this = this.masterdata.maritalstatus;

        if (_param["page"] == Util.tut.pageMasterDataFamilyRelationshipsMain)
            _this = this.masterdata.familyrelationships;

        if (_param["page"] == Util.tut.pageMasterDataAgencyMain)
            _this = this.masterdata.agency;

        if (_param["page"] == Util.tut.pageMasterDataEducationalLevelMain)
            _this = this.masterdata.educationallevel;

        if (_param["page"] == Util.tut.pageMasterDataEducationalBackgroundMain)
            _this = this.masterdata.educationalbackground;

        if (_param["page"] == Util.tut.pageMasterDataEducationalMajorMain)
            _this = this.masterdata.educationalmajor;

        if (_param["page"] == Util.tut.pageMasterDataAdmissionTypeMain)
            _this = this.masterdata.admissiontype;

        if (_param["page"] == Util.tut.pageMasterDataStudentStatusMain)
            _this = this.masterdata.studentstatus;

        if (_param["page"] == Util.tut.pageMasterDataCountryMain)
            _this = this.masterdata.country;

        if (_param["page"] == Util.tut.pageMasterDataProvinceMain)
            _this = this.masterdata.province;

        if (_param["page"] == Util.tut.pageMasterDataDistrictMain)
            _this = this.masterdata.district;

        if (_param["page"] == Util.tut.pageMasterDataSubdistrictMain)
            _this = this.masterdata.subdistrict;

        if (_param["page"] == Util.tut.pageMasterDataInstituteMain)
            _this = this.masterdata.institute;

        if (_param["page"] == Util.tut.pageMasterDataDiseasesMain)
            _this = this.masterdata.diseases;

        if (_param["page"] == Util.tut.pageMasterDataHealthImpairmentsMain)
            _this = this.masterdata.healthimpairments;

        if (_param["page"] == Util.tut.pageAdministrationStudentRecordsMain)
            _this = this.studentrecords;

        if (_param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationMain)
            _this = this.ourservices.exportstudentrecordsinformation;

        if (_param["page"] == Util.tut.pageOurServicesUpdateStudentDistinctionProgramMain)
            _this = this.ourservices.updatestudentdistinctionprogram;

        if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentMain)
            _this = this.ourservices.summarynumberofstudent;

        if (_param["page"] == Util.tut.pageOurServicesTransactionLogStudentRecordsMain)
            _this = this.ourservices.transactionlogstudentrecords;
        
        if (_this != null)
            _this.resetSearch({
                reset: true
            });
    },
    validateSearch: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this = null;
        var _validateResult = false;

        if (_param["page"] == Util.tut.pageMasterDataTitlePrefixMain)
            _this = this.masterdata.titleprefix;

        if (_param["page"] == Util.tut.pageMasterDataGenderMain)
            _this = this.masterdata.gender;

        if (_param["page"] == Util.tut.pageMasterDataNationalityRaceMain)
            _this = this.masterdata.nationalityrace;

        if (_param["page"] == Util.tut.pageMasterDataReligionMain)
            _this = this.masterdata.religion;

        if (_param["page"] == Util.tut.pageMasterDataBloodGroupMain)
            _this = this.masterdata.bloodgroup;

        if (_param["page"] == Util.tut.pageMasterDataMaritalStatusMain)
            _this = this.masterdata.maritalstatus;

        if (_param["page"] == Util.tut.pageMasterDataFamilyRelationshipsMain)
            _this = this.masterdata.familyrelationships;

        if (_param["page"] == Util.tut.pageMasterDataAgencyMain)
            _this = this.masterdata.agency;

        if (_param["page"] == Util.tut.pageMasterDataEducationalLevelMain)
            _this = this.masterdata.educationallevel;

        if (_param["page"] == Util.tut.pageMasterDataEducationalBackgroundMain)
            _this = this.masterdata.educationalbackground;

        if (_param["page"] == Util.tut.pageMasterDataEducationalMajorMain)
            _this = this.masterdata.educationalmajor;

        if (_param["page"] == Util.tut.pageMasterDataAdmissionTypeMain)
            _this = this.masterdata.admissiontype;

        if (_param["page"] == Util.tut.pageMasterDataStudentStatusMain)
            _this = this.masterdata.studentstatus;

        if (_param["page"] == Util.tut.pageMasterDataCountryMain)
            _this = this.masterdata.country;

        if (_param["page"] == Util.tut.pageMasterDataProvinceMain)
            _this = this.masterdata.province;

        if (_param["page"] == Util.tut.pageMasterDataDistrictMain)
            _this = this.masterdata.district;

        if (_param["page"] == Util.tut.pageMasterDataSubdistrictMain)
            _this = this.masterdata.subdistrict;

        if (_param["page"] == Util.tut.pageMasterDataInstituteMain)
            _this = this.masterdata.institute;

        if (_param["page"] == Util.tut.pageMasterDataDiseasesMain)
            _this = this.masterdata.diseases;

        if (_param["page"] == Util.tut.pageMasterDataHealthImpairmentsMain)
            _this = this.masterdata.healthimpairments;

        if (_param["page"] == Util.tut.pageAdministrationStudentRecordsMain)
            _this = this.studentrecords;

        if (_param["page"] == Util.tut.pageOurServicesExportStudentRecordsInformationMain)
            _this = this.ourservices.exportstudentrecordsinformation;

        if (_param["page"] == Util.tut.pageOurServicesUpdateStudentDistinctionProgramMain)
            _this = this.ourservices.updatestudentdistinctionprogram;

        if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentMain)
            _this = this.ourservices.summarynumberofstudent;

        if (_param["page"] == Util.tut.pageOurServicesTransactionLogStudentRecordsMain)
            _this = this.ourservices.transactionlogstudentrecords;

        if (_this != null)
            _validateResult = _this.validateSearch();

        return _validateResult;
    },
    getSearch: function(_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["setSearchShow"] = (_param["setSearchShow"] == undefined || _param["setSearchShow"] == "" ? false : _param["setSearchShow"]);
        
        var _this;
        var _reset = true;
        var _idContent;
        
        if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentMain) {
            _this = Util.tut.tos.summarynumberofstudent;
            _idContent = Util.getTabActiveOnTabbar({ id: (_this.idSectionMain + "-viewsdisplay") });
            _param["page"] = $("#" + _idContent).attr("alt");

            if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentViewTableMain)
                _param["page"] = Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain;
        }

        if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel2ViewTableMain)
            _reset = false;

        if (_reset == true) {
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
    actionSearch: function (_param) {
        _param["pageMain"] = (_param["pageMain"] == undefined ? "" : _param["pageMain"]);
        _param["pageSearch"] = (_param["pageSearch"] == undefined ? "" : _param["pageSearch"]);
        _param["data"] = (_param["data"] == undefined || _param["data"] == "" ? {} : _param["data"]);
        _param["idChart"] = (_param["idChart"] == undefined ? "" : _param["idChart"]);
        _param["idTable"] = (_param["idTable"] == undefined ? "" : _param["idTable"]);
        _param["pressNavPage"] = (_param["pressNavPage"] == undefined || _param["pressNavPage"] == "" ? false : _param["pressNavPage"]);
        _param["setSearchShow"] = (_param["setSearchShow"] == undefined || _param["setSearchShow"] == "" ? false : _param["setSearchShow"]);
        
        Util.actionSearch({
            pageMain: _param["pageMain"],
            pageSearch: _param["pageSearch"],
            data: _param["data"],
            idChart: _param["idChart"],
            idTable: _param["idTable"]
        }, function (_result) {
            if (_param["pageSearch"] == Util.tut.pageAdministrationStudentRecordsMain)
                Util.tut.tsr.sectionMain.initTable();

            if (_param["pageSearch"] == Util.tut.pageOurServicesExportStudentRecordsInformationMain)
                    Util.tut.tos.exportstudentrecordsinformation.sectionMain.initTable();

            if (_param["pageSearch"] == Util.tut.pageOurServicesUpdateStudentDistinctionProgramMain)
                Util.tut.tos.updatestudentdistinctionprogram.sectionMain.initTable();

            if (_param["pageSearch"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain ||
                _param["pageSearch"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel2ViewTableMain) {
                Util.tut.tos.summarynumberofstudent.viewtable.sectionMain.initMain({
                    page: _param["pageSearch"]
                });
                Util.tut.tos.summarynumberofstudent.viewtable.sectionMain.initTable({
                    page: _param["pageSearch"]
                });
            }

            if (_param["pageSearch"] == Util.tut.pageOurServicesTransactionLogStudentRecordsMain)
                Util.tut.tos.transactionlogstudentrecords.sectionMain.initTable();

            if (_param["setSearchShow"] == true)
                Util.setSearchShow();

            Util.setChartLayout();
            Util.setTableLayout();
            Util.initTable();
            Util.gotoTopElement();
        });
    },
    masterdata: {
        titleprefix: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataTitlePrefixMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataTitlePrefixSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-gender"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-gender"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-gender-hidden").val())
                });
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["gender"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-gender"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-gender")
                });
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        gender: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataGenderMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataGenderSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        nationalityrace: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataNationalityRaceMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataNationalityRaceSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        religion: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataReligionMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataReligionSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        bloodgroup: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataBloodGroupMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataBloodGroupSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },

        maritalstatus: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataMaritalStatusMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataMaritalStatusSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        familyrelationships: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataFamilyRelationshipsMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataFamilyRelationshipsSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-gender"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-gender"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-gender-hidden").val())
                });
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["gender"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-gender"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-gender")
                });
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        agency: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataAgencyMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataAgencySearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        educationallevel: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataEducationalLevelMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataEducationalLevelSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        educationalbackground: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataEducationalBackgroundMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataEducationalBackgroundSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                });
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        educationalmajor: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataEducationalMajorMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataEducationalMajorSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        admissiontype: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataAdmissionTypeMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataAdmissionTypeSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        studentstatus: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataStudentStatusMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataStudentStatusSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        country: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataCountryMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataCountrySearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        province: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataProvinceMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataProvinceSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-country"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-country"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-country-hidden").val())
                });
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["country"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-country")
                });
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        district: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataDistrictMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataDistrictSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-country"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            resetSearch: function (_param) {
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (this.idSectionSearch + "-form")
                });

                $("#" + this.idSectionSearch + "-keyword").val(_param["reset"] == true ? "" : $("#" + this.idSectionSearch + "-keyword-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-country"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-country-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-province"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-province-hidden").val())
                }, function () { });
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["country"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-country")
                });
                _send["province"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-province"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-province")
                });
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        subdistrict: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataSubdistrictMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataSubdistrictSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-country"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
                    id: ("#" + this.idSectionSearch + "-country"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-country-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-province"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-province-hidden").val())
                }, function () {
                    Util.tut.setSelectDefaultCombobox({
                        id: ("#" + _this.idSectionSearch + "-district"),
                        value: (_param["reset"] == true ? "0" : ($("#" + _this.idSectionSearch + "-district-hidden").val() != "0" ? ($("#" + _this.idSectionSearch + "-district-hidden").val() + ";" + $("#" + _this.idSectionSearch + "-postalcode-hidden").val()) : "0"))
                    }, function () { });
                });
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _value = ($("#" + this.idSectionSearch + "-district").length > 0 ? Util.comboboxGetValue("#" + this.idSectionSearch + "-district") : $("#" + this.idSectionSearch + "-district-hidden").val());
                var _valueArray;
                var _valueDistrict = "";
                var _valuePostalCode = "";

                if (_value != "0") {
                    _valueArray = _value.split(";");
                    _valueDistrict = _valueArray[0];
                    _valuePostalCode = _valueArray[1];
                }

                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["country"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-country")
                });
                _send["province"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-province"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-province")
                });
                _send["district"] = _valueDistrict;
                _send["postalcode"] = _valuePostalCode;
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        institute: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataInstituteMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataInstituteSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-country"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
                    id: ("#" + this.idSectionSearch + "-country"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-country-hidden").val())
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + this.idSectionSearch + "-province"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-province-hidden").val())
                }, function () { });
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["country"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-country")
                });
                _send["province"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-province"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-province")
                });
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        diseases: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataDiseasesMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataDiseasesSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        healthimpairments: {
            idSectionMain: ePFStaffUtil.idSectionMasterDataHealthImpairmentsMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionMasterDataHealthImpairmentssSearch.toLowerCase(),
            initSearch: function () {
                var _this = Util.tut.tse;

                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["cancelledstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-cancelledstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-cancelledstatus")
                });
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        }
    },    
    studentrecords: {
        idSectionMain: ePFStaffUtil.idSectionAdministrationStudentRecordsMain.toLowerCase(),
        idSectionSearch: ePFStaffUtil.idSectionAdministrationStudentRecordsSearch.toLowerCase(),
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
                id: ("#" + this.idSectionSearch + "-yearattended"),
                width: 206,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-yeargraduate"),
                width: 207,
                height: 27
            });
            Util.initCombobox({
                id: ("#" + this.idSectionSearch + "-class"),
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
                id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
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
                id: ("#" + this.idSectionSearch + "-yeargraduate"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yeargraduate-hidden").val())
            });
            Util.comboboxSetValue({
                id: ("#" + this.idSectionSearch + "-class"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-class-hidden").val())
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
                id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentrecordsstatus-hidden").val())
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
        validateSearch: function () {
            var _error = new Array();
            var _i = 0;

            return (_i > 0 ? false : true);
        },
        valueSearch: function () {
            var _send = {};
            _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
            _send["degreelevel"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-degreelevel"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
            });
            _send["faculty"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-faculty"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
            });
            _send["program"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-program"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
            });
            _send["yearentry"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-yearattended"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
            });
            _send["yeargraduate"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-yeargraduate"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yeargraduate")
            });
            _send["class"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-class"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-class")
            });
            _send["entrancetype"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-entrancetype"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
            });
            _send["studentstatus"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-studentstatus"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
            });
            _send["studentrecordsstatus"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentrecordsstatus")
            });
            _send["distinction"] = "";
            _send["distinctionstatus"] = "";
            _send["startacademicyear"] = "";
            _send["endacademicyear"] = "";
            _send["gender"] = "";
            _send["studentstatusgroup"] = "";
            _send["nationality"] = "";
            _send["sortorderby"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-sortorderby"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
            });
            _send["sortexpression"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionSearch + "-sortexpression"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
            });
            _send["rowperpage"] = Util.getSelectionIsSelect({
                id: ("#" + this.idSectionMain + "-rowperpage"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
            });
            
            return _send;
        }
    },
    ourservices: {
        exportstudentrecordsinformation: {
            idSectionMain: ePFStaffUtil.idSectionOurServicesExportStudentRecordsInformationMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionOurServicesExportStudentRecordsInformationSearch.toLowerCase(),
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
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    width: 207,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-class"),
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
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
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
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yeargraduate-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-class"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-class-hidden").val())
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
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentrecordsstatus-hidden").val())
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                });
                _send["faculty"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                });
                _send["program"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-program"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                });
                _send["yearentry"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                });
                _send["yeargraduate"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yeargraduate")
                });
                _send["class"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-class"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-class")
                });
                _send["entrancetype"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                });
                _send["studentstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                });
                _send["studentrecordsstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentrecordsstatus")
                });
                _send["distinction"] = "";
                _send["distinctionstatus"] = "";
                _send["startacademicyear"] = "";
                _send["endacademicyear"] = "";
                _send["gender"] = "";
                _send["studentstatusgroup"] = "";
                _send["nationality"] = "";
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        
        },
        updatestudentdistinctionprogram: {
            idSectionMain: ePFStaffUtil.idSectionOurServicesUpdateStudentDistinctionProgramMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionOurServicesUpdateStudentDistinctionProgramSearch.toLowerCase(),
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
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-class"),
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
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-distinctionstatus"),
                    width: 0,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-startacademicyear"),
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-endacademicyear"),
                    width: 206,
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
                }, function () {
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yearattended-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-class"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-class-hidden").val())
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
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentrecordsstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-distinctionstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-distinctionstatus-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-startacademicyear"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-startacademicyear-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-endacademicyear"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-endacademicyear-hidden").val())
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                });
                _send["faculty"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                });
                _send["program"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-program"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                });
                _send["yearentry"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                });
                _send["yeargraduate"] = "";
                _send["class"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-class"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-class")
                });
                _send["entrancetype"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                });
                _send["studentstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                });
                _send["studentrecordsstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentrecordsstatus")
                });
                _send["distinction"] = "Y";
                _send["distinctionstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-distinctionstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-distinctionstatus")
                });
                _send["startacademicyear"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-startacademicyear"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-startacademicyear")
                });
                _send["endacademicyear"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-endacademicyear"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-endacademicyear")
                });
                _send["gender"] = "";
                _send["studentstatusgroup"] = "";
                _send["nationality"] = "";
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        summarynumberofstudent: {
            idSectionMain: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentSearch.toLowerCase(),
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
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    width: 207,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-class"),
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
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
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
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yeargraduate-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-class"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-class-hidden").val())
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
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentrecordsstatus-hidden").val())
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                });
                _send["faculty"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                });
                _send["program"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-program"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                });
                _send["yearentry"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                });
                _send["yeargraduate"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yeargraduate")
                });
                _send["class"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-class"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-class")
                });
                _send["entrancetype"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                });
                _send["studentstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                });
                _send["studentrecordsstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentrecordsstatus")
                });
                _send["distinction"] = "";
                _send["distinctionstatus"] = "";
                _send["startacademicyear"] = "";
                _send["endacademicyear"] = "";
                _send["gender"] = "";
                _send["studentstatusgroup"] = "";
                _send["nationality"] = "";
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        },
        transactionlogstudentrecords: {
            idSectionMain: ePFStaffUtil.idSectionOurServicesTransactionLogStudentRecordsMain.toLowerCase(),
            idSectionSearch: ePFStaffUtil.idSectionOurServicesTransactionLogStudentRecordsSearch.toLowerCase(),
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
                    width: 206,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    width: 207,
                    height: 27
                });
                Util.initCombobox({
                    id: ("#" + this.idSectionSearch + "-class"),
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
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
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
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-yeargraduate-hidden").val())
                });
                Util.comboboxSetValue({
                    id: ("#" + this.idSectionSearch + "-class"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-class-hidden").val())
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
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    value: (_param["reset"] == true ? "0" : $("#" + this.idSectionSearch + "-studentrecordsstatus-hidden").val())
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
            validateSearch: function () {
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            valueSearch: function () {
                var _send = {};
                _send["keyword"] = $("#" + this.idSectionSearch + "-keyword").val();
                _send["degreelevel"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-degreelevel")
                });
                _send["faculty"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-faculty")
                });
                _send["program"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-program"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-program")
                });
                _send["yearentry"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yearattended")
                });
                _send["yeargraduate"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-yeargraduate"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-yeargraduate")
                });
                _send["class"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-class"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-class")
                });
                _send["entrancetype"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-entrancetype"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-entrancetype")
                });
                _send["studentstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-studentstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentstatus")
                });
                _send["studentrecordsstatus"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-studentrecordsstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-studentrecordsstatus")
                });
                _send["distinction"] = "";
                _send["distinctionstatus"] = "";
                _send["startacademicyear"] = "";
                _send["endacademicyear"] = "";
                _send["gender"] = "";
                _send["studentstatusgroup"] = "";
                _send["nationality"] = "";
                _send["sortorderby"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortorderby"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortorderby")
                });
                _send["sortexpression"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionSearch + "-sortexpression"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionSearch + "-sortexpression")
                });
                _send["rowperpage"] = Util.getSelectionIsSelect({
                    id: ("#" + this.idSectionMain + "-rowperpage"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + this.idSectionMain + "-rowperpage")
                });

                return _send;
            }
        }
    }
};