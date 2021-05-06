// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๖/๐๗/๒๕๕๘>
// Modify date  : <๑๖/๐๒/๒๕๖๓>
// Description  : <รวมรวบฟังก์ชั่นใช้งานทั่วไปของระบบ>
// =============================================

var HCSStaffUtil = {
    tse: null,
    tmd: null,
    tdf: null,
    tos: null,
    tpd: null,
    parentWidth: 1008,
    pathProject: "HealthCareServiceStaff",
    urlHandler: "../../../Content/Handler/HealthCareServiceStaff/HCSStaffHandler.ashx",

    subjectSectionMeaningofAdmissionType: "MeaningOfAdmissionType",
    subjectSectionMeaningofStudentStatus: "MeaningOfStudentStatus",
    subjectSectionMeaningofHealthCareServiceForm: "MeaningOfHealthCareServiceForm",
    subjectSectionMasterDataHospitalOfHealthCareService: "MasterDataHospitalOfHealthCareService",
    subjectSectionMasterDataRegistrationForm: "MasterDataRegistrationForm",
    subjectSectionMasterDataAgencyRegistered: "MasterDataAgencyRegistered",
    subjectSectionDownloadRegistrationForm: "DownloadRegistrationForm",
    subjectSectionDownloadFile: "DownloadFile",
    subjectSectionDownload: "Download",
    subjectSectionExport: "Export",
    subjectSectionOurServices: "OurServices",
    subjectSectionOurServicesHealthInformation: "OurServicesHealthInformation",
    subjectSectionStatisticsDownloadHealthCareServiceFormLevel1ViewTable: "StatisticsDownloadHealthCareServiceFormLevel1ViewTable",
    subjectSectionStatisticsDownloadHealthCareServiceFormLevel2ViewTable: "StatisticsDownloadHealthCareServiceFormLevel2ViewTable",
    subjectSectionOurServicesStatisticsDownloadHealthCareServiceForm: "OurServicesStatisticsDownloadHealthCareServiceForm",
    subjectSectionOurServicesTermServiceHCSConsentRegistration: "OurServicesTermServiceHCSConsentRegistration",
    subjectSectionOurServicesTermServiceHCSConsentOOCA: "OurServicesTermServiceHCSConsentOOCA",

    idSectionMasterDataHospitalOfHealthCareServiceMain: "Main-MasterDataHospitalOfHealthCareService",
    idSectionMasterDataHospitalOfHealthCareServiceSearch: "Search-MasterDataHospitalOfHealthCareService",
    idSectionMasterDataHospitalOfHealthCareServiceNew: "New-MasterDataHospitalOfHealthCareService",
    idSectionMasterDataHospitalOfHealthCareServiceEdit: "Edit-MasterDataHospitalOfHealthCareService",
    idSectionMasterDataRegistrationFormMain: "Main-MasterDataRegistrationForm",
    idSectionMasterDataRegistrationFormSearch: "Search-MasterDataRegistrationForm",
    idSectionMasterDataRegistrationFormNew: "New-MasterDataRegistrationForm",
    idSectionMasterDataRegistrationFormEdit: "Edit-MasterDataRegistrationForm",
    idSectionMasterDataAgencyRegisteredMain: "Main-MasterDataAgencyRegistered",
    idSectionMasterDataAgencyRegisteredSearch: "Search-MasterDataAgencyRegistered",
    idSectionMasterDataAgencyRegisteredNew: "New-MasterDataAgencyRegistered",
    idSectionMasterDataAgencyRegisteredEdit: "Edit-MasterDataAgencyRegistered",
    idSectionDownloadRegistrationFormMain: "Main-DownloadRegistrationForm",
    idSectionDownloadRegistrationFormSearch: "Search-DownloadRegistrationForm",
    idSectionDownloadRegistrationFormProgress: "Progress-DownloadRegistrationForm",
    idSectionOurServicesHealthInformationMain: "Main-OurServicesHealthInformation",
    idSectionOurServicesHealthInformationSearch: "Search-OurServicesHealthInformation",
    idSectionOurServicesHealthInformationProgress: "Progress-OurServicesHealthInformation",
    idSectionOurServicesStatisticsDownloadHealthCareServiceFormMain: "Main-OurServicesStatisticsDownloadHealthCareServiceForm",
    idSectionOurServicesStatisticsDownloadHealthCareServiceFormSearch: "Search-OurServicesStatisticsDownloadHealthCareServiceForm",
    idSectionOurServicesStatisticsDownloadHealthCareServiceFormViewChartMain: "Main-OurServicesStatisticsDownloadHealthCareServiceFormViewChart",
    idSectionOurServicesStatisticsDownloadHealthCareServiceFormViewTableMain: "Main-OurServicesStatisticsDownloadHealthCareServiceFormViewTable",
    idSectionOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain: "Main-OurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTable",
    idSectionOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableProgress: "Progress-OurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTable",
    idSectionOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain: "Main-OurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTable",
    idSectionOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableProgress: "Progress-OurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTable",
    idSectionOurServicesTermServiceHCSConsentMain: "Main-OurServicesTermServiceHCSConsent",
    idSectionOurServicesTermServiceHCSConsentSearch: "Search-OurServicesTermServiceHCSConsent",
    idSectionOurServicesTermServiceHCSConsentSelectHospitalDialog: "Dialog-OurServicesTermServiceHCSConsentSelectHospital",
    idSectionOurServicesTermServiceHCSConsentProgress: "Progress-OurServicesTermServiceHCSConsent",

    pageMain: "Main",
    pageMeaningofAdmissionTypeMain: "MeaningOfAdmissionTypeMain",
    pageMeaningofStudentStatusMain: "MeaningOfStudentStatusMain",
    pageMeaningofHealthCareServiceForm: "MeaningOfHealthCareServiceFormMain",
    pageMasterDataHospitalOfHealthCareServiceMain: "MasterDataHospitalOfHealthCareServiceMain",
    pageMasterDataHospitalOfHealthCareServiceNew: "MasterDataHospitalOfHealthCareServiceNew",
    pageMasterDataHospitalOfHealthCareServiceEdit: "MasterDataHospitalOfHealthCareServiceEdit",
    pageMasterDataRegistrationFormMain: "MasterDataRegistrationFormMain",
    pageMasterDataRegistrationFormNew: "MasterDataRegistrationFormNew",
    pageMasterDataRegistrationFormEdit: "MasterDataRegistrationFormEdit",
    pageMasterDataAgencyRegisteredMain: "MasterDataAgencyRegisteredMain",
    pageMasterDataAgencyRegisteredNew: "MasterDataAgencyRegisteredNew",
    pageMasterDataAgencyRegisteredEdit: "MasterDataAgencyRegisteredEdit",
    pageStudentRecordsStudentCVMain: "StudentRecordsStudentCVMain",
    pageDownloadRegistrationFormMain: "DownloadRegistrationFormMain",
    pageDownloadRegistrationFormProgress: "DownloadRegistrationFormProgress",
    pageOurServicesHealthInformationMain: "OurServicesHealthInformationMain",
    pageOurServicesHealthInformationProgress: "OurServicesHealthInformationProgress",
    pageOurServicesStatisticsDownloadHealthCareServiceFormMain: "OurServicesStatisticsDownloadHealthCareServiceFormMain",
    pageOurServicesStatisticsDownloadHealthCareServiceFormViewChartMain: "OurServicesStatisticsDownloadHealthCareServiceFormViewChartMain",
    pageOurServicesStatisticsDownloadHealthCareServiceFormViewTableMain: "OurServicesStatisticsDownloadHealthCareServiceFormViewTableMain",
    pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain: "OurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableMain",
    pageOurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableProgress: "OurServicesStatisticsDownloadHealthCareServiceFormLevel1ViewTableProgress",
    pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain: "OurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableMain",
    pageOurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableProgress: "OurServicesStatisticsDownloadHealthCareServiceFormLevel2ViewTableProgress",
    pageOurServicesTermServiceHCSConsentSelectHospitalDialog: "OurServicesTermServiceHCSConsentSelectHospitalDialog",
    pageOurServicesTermServiceHCSConsentRegistrationMain: "OurServicesTermServiceHCSConsentRegistrationMain",    
    pageOurServicesTermServiceHCSConsentRegistrationEdit: "OurServicesTermServiceHCSConsentRegistrationEdit",
    pageOurServicesTermServiceHCSConsentRegistrationProgress: "OurServicesTermServiceHCSConsentRegistrationProgress",    
    pageOurServicesTermServiceHCSConsentOOCAMain: "OurServicesTermServiceHCSConsentOOCAMain",
    pageOurServicesTermServiceHCSConsentOOCAEdit: "OurServicesTermServiceHCSConsentOOCAEdit",
    pageOurServicesTermServiceHCSConsentOOCAProgress: "OurServicesTermServiceHCSConsentOOCAProgress",
   
    //ฟังก์ชั่นสำหรับกำหนดให้ทำงานตามเหตุการณ์ต่าง ๆ ที่เกิดขึ้นบน Menu Bar
    initMenuBar: function () {
        var _this = this;

        $(function () {
            $(".menubar .link-click").click(function () {
                var _idLink = $(this).attr("id");

                Util.dialogMessageClose();

                if (_idLink == ("link-" + _this.subjectSectionMasterDataHospitalOfHealthCareService.toLowerCase()))                 Util.gotoPage({ page: ("index.aspx?p=" + _this.pageMasterDataHospitalOfHealthCareServiceMain) });
                if (_idLink == ("link-" + _this.subjectSectionMasterDataRegistrationForm.toLowerCase()))                            Util.gotoPage({ page: ("index.aspx?p=" + _this.pageMasterDataRegistrationFormMain) });
                if (_idLink == ("link-" + _this.subjectSectionMasterDataAgencyRegistered.toLowerCase()))                            Util.gotoPage({ page: ("index.aspx?p=" + _this.pageMasterDataAgencyRegisteredMain) });
                if (_idLink == ("link-" + _this.subjectSectionDownloadRegistrationForm.toLowerCase()))                              Util.gotoPage({ page: ("index.aspx?p=" + _this.pageDownloadRegistrationFormMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesHealthInformation.toLowerCase()))                          Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesHealthInformationMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesStatisticsDownloadHealthCareServiceForm.toLowerCase()))    Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesStatisticsDownloadHealthCareServiceFormMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesTermServiceHCSConsentRegistration.toLowerCase()))          Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesTermServiceHCSConsentRegistrationMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesTermServiceHCSConsentOOCA.toLowerCase()))                  Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesTermServiceHCSConsentOOCAMain) });
                if (_idLink == "link-signout") Util.confirmeSignOut();
            });
        });
    },

    //ฟังก์ชั่นสำหรับกำหนดให้ทำงานตามเหตุการณ์ต่าง ๆ ที่เกิดขึ้นบน Info Bar
    initInfoBar: function () {
        var _this = this;

        $(function () {
            $(".infobar .link-click").click(function () {
                var _idLink = $(this).attr("id");

                Util.dialogMessageClose();

                if (_idLink == ("new-"   + _this.pageMasterDataHospitalOfHealthCareServiceMain.toLowerCase()))  Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataHospitalOfHealthCareServiceNew });

                if (_idLink == ("save-"  + _this.pageMasterDataHospitalOfHealthCareServiceNew.toLowerCase()))   Util.tut.tmd.confirmSave({ page: _this.pageMasterDataHospitalOfHealthCareServiceNew });
                if (_idLink == ("undo-"  + _this.pageMasterDataHospitalOfHealthCareServiceNew.toLowerCase()))   Util.tut.tmd.hospitalofhealthcareservice.sectionAddUpdate.resetMain();
                if (_idLink == ("close-" + _this.pageMasterDataHospitalOfHealthCareServiceNew.toLowerCase()))   Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataHospitalOfHealthCareServiceMain });

                if (_idLink == ("save-"  + _this.pageMasterDataHospitalOfHealthCareServiceEdit.toLowerCase()))  Util.tut.tmd.confirmSave({ page: _this.pageMasterDataHospitalOfHealthCareServiceEdit });
                if (_idLink == ("undo-"  + _this.pageMasterDataHospitalOfHealthCareServiceEdit.toLowerCase()))  Util.tut.tmd.hospitalofhealthcareservice.sectionAddUpdate.resetMain();
                if (_idLink == ("close-" + _this.pageMasterDataHospitalOfHealthCareServiceEdit.toLowerCase()))  Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataHospitalOfHealthCareServiceMain });

                if (_idLink == ("new-"   + _this.pageMasterDataRegistrationFormMain.toLowerCase()))             Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataRegistrationFormNew });

                if (_idLink == ("save-"  + _this.pageMasterDataRegistrationFormNew.toLowerCase()))              Util.tut.tmd.confirmSave({ page: _this.pageMasterDataRegistrationFormNew });
                if (_idLink == ("undo-"  + _this.pageMasterDataRegistrationFormNew.toLowerCase()))              Util.tut.tmd.registrationform.sectionAddUpdate.resetMain();
                if (_idLink == ("close-" + _this.pageMasterDataRegistrationFormNew.toLowerCase()))              Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataRegistrationFormMain });

                if (_idLink == ("save-"  + _this.pageMasterDataRegistrationFormEdit.toLowerCase()))             Util.tut.tmd.confirmSave({ page: _this.pageMasterDataRegistrationFormEdit });
                if (_idLink == ("undo-"  + _this.pageMasterDataRegistrationFormEdit.toLowerCase()))             Util.tut.tmd.registrationform.sectionAddUpdate.resetMain();
                if (_idLink == ("close-" + _this.pageMasterDataRegistrationFormEdit.toLowerCase()))             Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataRegistrationFormMain });

                if (_idLink == ("new-"   + _this.pageMasterDataAgencyRegisteredMain.toLowerCase()))             Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataAgencyRegisteredNew });

                if (_idLink == ("save-"  + _this.pageMasterDataAgencyRegisteredNew.toLowerCase()))              Util.tut.tmd.confirmSave({ page: _this.pageMasterDataAgencyRegisteredNew });
                if (_idLink == ("undo-"  + _this.pageMasterDataAgencyRegisteredNew.toLowerCase()))              Util.tut.tmd.agencyregistered.sectionAddUpdate.resetMain();
                if (_idLink == ("close-" + _this.pageMasterDataAgencyRegisteredNew.toLowerCase()))              Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataAgencyRegisteredMain });

                if (_idLink == ("save-"  + _this.pageMasterDataAgencyRegisteredEdit.toLowerCase()))             Util.tut.tmd.confirmSave({ page: _this.pageMasterDataAgencyRegisteredEdit });
                if (_idLink == ("undo-"  + _this.pageMasterDataAgencyRegisteredEdit.toLowerCase()))             Util.tut.tmd.agencyregistered.sectionAddUpdate.resetMain();
                if (_idLink == ("close-" + _this.pageMasterDataAgencyRegisteredEdit.toLowerCase()))             Util.gotoPage({ page: "index.aspx?p=" + _this.pageMasterDataAgencyRegisteredMain });
            });
        });
    },
       
    //ฟังก์ชั่นสำหรับแสดงข้อความผิดพลาดเมื่อมีการเปลี่ยนหน้าใหม่หรือความผิดพลาดของผู้ใช้่งานหรือความผิดพลาดของใบสมัคร
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //signinYN      รับค่าความต้องการเข้าสู่ระบบ
    //pageError     รับค่าผลของการตรวจสอบหน้าที่แสดง
    //cookieError   รับค่าผลของการตรวจสอบ Cookie
    //userError     รับค่าผลของการตรวจสอบ User
    //saveError     รับค่าผลของการบันทึกข้อมูล
    getErrorMsg: function (_param) {
        _param["signinYN"]      = (_param["signinYN"] == undefined || _param["signinYN"] == "" ? "N" : _param["signinYN"]);
        _param["pageError"]     = (_param["pageError"] == undefined || _param["pageError"] == "" ? 0 : _param["pageError"]);
        _param["cookieError"]   = (_param["cookieError"] == undefined || _param["cookieError"] == "" ? 0 : _param["cookieError"]);
        _param["userError"]     = (_param["userError"] == undefined || _param["userError"] == "" ? 0 : _param["userError"]);
        _param["saveError"]     = (_param["saveError"] == undefined || _param["saveError"] == "" ? 0 : _param["saveError"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _status = (_param["signinYN"] + _param["cookieError"] + _param["userError"] + _param["saveError"]);

        if (_error == false && _param["pageError"] == 1)    { _error = true; _msgTH = "ไม่พบหน้านี้"; _msgEN = "Page not found."; }
        if (_error == false && _param["pageError"] == 2)    { _error = true; _msgTH = "ไม่พบข้อมูล"; _msgEN = "Data not found."; }
        if (_error == false && _status == "Y100")           { _error = true; _msgTH = "กรุณาเข้าระบบนักศึกษา"; _msgEN = "Please sign in student portal."; }
        if (_error == false && _status == "Y010")           { _error = true; _msgTH = "ไม่พบสิทธิ์ผู้ใช้งาน"; _msgEN = "No permission user."; }
        if (_error == false && _status == "Y020")           { _error = true; _msgTH = "ไม่พบนักศึกษา"; _msgEN = "Student not found."; }
        if (_error == false && _status == "Y030")           { _error = true; _msgTH = "ไม่พบข้อมูล"; _msgEN = "Data not found."; }
        if (_error == false && _status == "Y001")           { _error = true; _msgTH = "บันทึกข้อมูลไม่สำเร็จ"; _msgEN = "Save was not successful."; }
        if (_error == false && _status == "Y002")           { _error = true; _msgTH = "บันทึกข้อมูลไม่สำเร็จ เนื่องจากมีข้อมูลนี้อยู่แล้ว"; _msgEN = "Save was not successful, duplicate data."; }
        if (_error == false && _status == "Y003")           { _error = true; _msgTH = "บันทึกข้อมูลไม่สำเร็จ เนื่องจากไม่พบข้อมูล"; _msgEN = "Save was not successful, data not found."; }
        if (_error == false && _status == "Y004")           { _error = true; _msgTH = "บันทึกข้อมูลไม่สำเร็จ เนื่องจากข้อมูลบางส่วนมีอยู่แล้ว"; _msgEN = "Save was not successful, duplicate data."; }
        if (_error == false && _status == "Y005")           { _error = true; _msgTH = "บันทึกข้อมูลไม่สำเร็จ เนื่องจากไม่พบข้อมูล"; _msgEN = "Save was not successful, data not found."; }

        if (_error == true && _msgTH.length > 0 && _msgEN.length > 0)
            Util.dialogMessageError({
                content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
            });

        return _error;
    },
          
    //ฟังก์ชั่นสำหรับโหลดหน้าที่ต้องการมาแสดง
    //โดยมีพารามิเตอร์ดังนี้
    //1. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
    loadPage: function (_callBackFunc) {
        var _this = this;
        var _error;
        var _page = ($("#page").html().length > 0 ? $("#page").html() : this.pageMain);
        var _send = {};
        _send["action"] = "page";
        _send["page"]   = _page;
        _send["id"]     = $("#id").html();      
        
        Util.msgPreloading = "Loading...";

        Util.loadAjax({
            url: this.urlHandler,
            method: "POST",
            data: _send,
            showPreloadingInline: false
        }, function (_result) {
            Util.clearPage();

            $("#page").html(_result.Page);
            $("#menubar-content").html(_result.MenuBarContent);

            _error = _this.getErrorMsg({
                        signinYN: _result.SignInYN,
                        pageError: _result.PageError,
                        cookieError: _result.CookieError,
                        userError: _result.UserError
                     });

            if (_error == false)
            {
                if (_page == _this.pageStudentRecordsStudentCVMain)
                    $("#bodymain #mainbody .sticky").html("");

                if (_result.SearchContent.length > 0)
                    $("#bodysearch").html(_result.SearchContent).show();

                $("#contentbody-content").html(_result.MainContent).show();

                Util.setMenuBarLayout();
                Util.setInfoBarLayout();
                Util.setMainLayout();
                Util.setStickyTop(0);
                Util.setChartLayout();
                Util.setTableLayout();
                Util.setFooterLayout();

                /*
								if (_page == _this.pageMain)
								{
										var _label = "<span style='color: #FFFFFF'>ขอรบกวนผู้ใช้งานทุกท่านตอบ <a href='https://docs.google.com/forms/d/e/1FAIpQLSdIfvO7b-9vW9yVWkuUIx7IiYUhlzEyTmEBdMq-_kkoAP_qNQ/viewform?usp=pp_url&entry.1320515055=%E0%B8%A3%E0%B8%B0%E0%B8%9A%E0%B8%9A%E0%B8%88%E0%B8%B1%E0%B8%94%E0%B8%81%E0%B8%B2%E0%B8%A3%E0%B8%82%E0%B9%89%E0%B8%AD%E0%B8%A1%E0%B8%B9%E0%B8%A5%E0%B8%82%E0%B8%B6%E0%B9%89%E0%B8%99%E0%B8%97%E0%B8%B0%E0%B9%80%E0%B8%9A%E0%B8%B5%E0%B8%A2%E0%B8%99%E0%B8%AA%E0%B8%B4%E0%B8%97%E0%B8%98%E0%B8%B4%E0%B8%A3%E0%B8%B1%E0%B8%81%E0%B8%A9%E0%B8%B2%E0%B8%9E%E0%B8%A2%E0%B8%B2%E0%B8%9A%E0%B8%B2%E0%B8%A5' target='_blank' style='text-decoration: underline; color: #000000'>แบบประเมินความพึ่งพอใจในการใช้งาน</a> เพื่อไปปรับปรุงระบบให้ดียิ่ง<div style='text-align: right; margin-top: 15px'>ขอขอบคุณผู้ใช้งานทุกท่าน<br />ผู้พัฒนาระบบ</div></span>";

										Util.dialogMessageBox({
												content: ("<div class='th-label'>" + _label + "</div>")
										});
								}
                */

                if (_page == _this.pageMasterDataHospitalOfHealthCareServiceMain)
                {                    
                    Util.tut.tse.masterdata.hospitalofhealthcareservice.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.hospitalofhealthcareservice.sectionMain.initMain();
                }
                    
                if (_page == _this.pageMasterDataHospitalOfHealthCareServiceNew)
                    Util.tut.tmd.hospitalofhealthcareservice.sectionAddUpdate.sectionNew.initMain();

                if (_page == _this.pageMasterDataHospitalOfHealthCareServiceEdit)
                    Util.tut.tmd.hospitalofhealthcareservice.sectionAddUpdate.sectionEdit.initMain();

                if (_page == _this.pageMasterDataRegistrationFormMain)
                {                    
                    Util.tut.tse.masterdata.registrationform.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.registrationform.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataRegistrationFormNew)
                    Util.tut.tmd.registrationform.sectionAddUpdate.sectionNew.initMain();

                if (_page == _this.pageMasterDataRegistrationFormEdit)
                    Util.tut.tmd.registrationform.sectionAddUpdate.sectionEdit.initMain();

                if (_page == _this.pageMasterDataAgencyRegisteredMain)
                {                    
                    Util.tut.tse.masterdata.agencyregistered.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.agencyregistered.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataAgencyRegisteredNew)
                    Util.tut.tmd.agencyregistered.sectionAddUpdate.sectionNew.initMain();

                if (_page == _this.pageMasterDataAgencyRegisteredEdit)
                    Util.tut.tmd.agencyregistered.sectionAddUpdate.sectionEdit.initMain();

                if (_page == _this.pageDownloadRegistrationFormMain)
                {
                    Util.tut.tse.downloadregistrationform.initSearch();
                    Util.initSearch();
                    Util.tut.tdf.sectionMain.initMain();
                    Util.tut.tdf.sectionMain.initTable();
                }

                if (_page == _this.pageOurServicesHealthInformationMain)
                {                    
                    Util.tut.tse.ourservices.healthinformation.initSearch();
                    Util.initSearch();
                    Util.tut.tos.healthinformation.sectionMain.initMain();
                }

                if (_page == _this.pageOurServicesStatisticsDownloadHealthCareServiceFormMain)
                {
                    Util.tut.tse.ourservices.statisticsdownloadhealthcareserviceform.initSearch();
                    Util.initSearch();
                    Util.tut.tos.statisticsdownloadhealthcareserviceform.sectionMain.initMain();
                }

                if (_page == _this.pageOurServicesTermServiceHCSConsentRegistrationMain ||
                    _page == _this.pageOurServicesTermServiceHCSConsentOOCAMain)
                {                        
                    var _pageEdit;
                    var _pageProgress;
                    
                    if (_page == _this.pageOurServicesTermServiceHCSConsentRegistrationMain)
                    {
                        _pageEdit       = _this.pageOurServicesTermServiceHCSConsentRegistrationEdit;
                        _pageProgress   = _this.pageOurServicesTermServiceHCSConsentRegistrationProgress;
                    }
                    if (_page == _this.pageOurServicesTermServiceHCSConsentOOCAMain)
										{
												_pageEdit = _this.pageOurServicesTermServiceHCSConsentOOCAEdit;
                        _pageProgress   = _this.pageOurServicesTermServiceHCSConsentOOCAProgress;
                    }

                    Util.tut.tos.termservicehcsconsent.pageMain     = _page;
                    Util.tut.tos.termservicehcsconsent.pageEdit     = _pageEdit;
                    Util.tut.tos.termservicehcsconsent.pageProgress = _pageProgress;

                    Util.tut.tse.ourservices.termservicehcsconsent.initSearch();
                    Util.initSearch();                    
                    Util.tut.tos.termservicehcsconsent.sectionMain.initMain();
                    Util.tut.tos.termservicehcsconsent.sectionMain.initTable();
                }
            }

            _this.initMenuBar();
            _this.initInfoBar();

            Util.initTable();
            Util.initTextSelect();
            Util.gotoTopElement();

            _callBackFunc();
        });
    },
               
    //ฟังก์ชั่นสำหรับกำหนดให้มีการทำงานอย่างใดอย่างหนึ่งเมื่อมีการเลือกรายการใน Combobox
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //id        รับค่าชื่อของ Combobox
    //value     รับค่าค่าของ Combobox
    setSelectCombobox: function (_param) {
        _param["id"]    = (_param["id"] == undefined ? "" : _param["id"]);
        _param["value"] = (_param["value"] == undefined ? "" : _param["value"]);

        var _this = this;
        var _cmd;
        var _idCombobox;
        var _idContainer;
        var _idRadiobox;
        var _idCheckbox;
        var _idTextbox;
        var _valueParam = {};
        var _valueDefault;
        var _valueArray;
        var _valueDegreeLevel = "";
        var _valueFaculty = "";
        var _valueRegistrationForm = "";
        var _valueYearEntry = "";
        var _widthInput;
        var _heightInput;
        var _idContent;
        var _page;

        if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredEdit.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionDownloadRegistrationFormSearch.toLowerCase() + "-registrationform") ||
            _param["id"] == ("#" + this.idSectionDownloadRegistrationFormSearch.toLowerCase() + "-yearattended") ||
            _param["id"] == ("#" + this.idSectionOurServicesHealthInformationSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesStatisticsDownloadHealthCareServiceFormSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesTermServiceHCSConsentSearch.toLowerCase() + "-faculty"))
        {
            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredSearch.toLowerCase() + "-faculty"))
            {
                _idContent              = this.idSectionMasterDataAgencyRegisteredSearch.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueDegreeLevel       = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-degreelevel"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel"),
                                            valueFalse: ""
                                          });
                _valueFaculty           = _param["value"];
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredEdit.toLowerCase() + "-faculty"))
            {
                _idContent              = this.idSectionMasterDataAgencyRegisteredEdit.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueFaculty           = _param["value"];
                _widthInput             = 533;
                _heightInput            = 29;
            }

            if (_param["id"] == ("#" + this.idSectionDownloadRegistrationFormSearch.toLowerCase() + "-registrationform"))
            {
                _idContent              = this.idSectionDownloadRegistrationFormSearch.toLowerCase();
                _cmd                    = "getagencyregistered";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueRegistrationForm  = (_param["value"] != "0" ? _param["value"] : "n/a");
                _valueYearEntry         = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-yearattended"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-yearattended"),
                                            valueFalse: "0"
                                          });
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionDownloadRegistrationFormSearch.toLowerCase() + "-yearattended"))
            {
                _idContent              = this.idSectionDownloadRegistrationFormSearch.toLowerCase();
                _cmd                    = "getagencyregistered";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueRegistrationForm  = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-registrationform"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-registrationform"),
                                            valueFalse: "n/a"
                                          });
                _valueYearEntry         = _param["value"];
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesHealthInformationSearch.toLowerCase() + "-faculty"))
            {
                _idContent              = this.idSectionOurServicesHealthInformationSearch.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueFaculty           = _param["value"];
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesStatisticsDownloadHealthCareServiceFormSearch.toLowerCase() + "-faculty"))
            {
                _idContent              = this.idSectionOurServicesStatisticsDownloadHealthCareServiceFormSearch.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueFaculty           = _param["value"];
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesTermServiceHCSConsentSearch.toLowerCase() + "-faculty"))
            {
                _idContent              = this.idSectionOurServicesTermServiceHCSConsentSearch.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueFaculty           = _param["value"];
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            _cmd                            = _cmd;
            _idCombobox                     = _idCombobox;
            _idContainer                    = _idContainer;
            _valueParam["id"]               = _idCombobox;
            _valueParam["degreelevel"]      = _valueDegreeLevel;
            _valueParam["faculty"]          = _valueFaculty;
            _valueParam["registrationform"] = _valueRegistrationForm;
            _valueParam["yearentry"]        = _valueYearEntry;
            _valueDefault                   = "0";
            _widthInput                     = _widthInput;
            _heightInput                    = _heightInput;
            
            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () { });
        }

        if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredNew.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredNew.toLowerCase() + "-faculty"))
        {
            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredNew.toLowerCase() + "-degreelevel"))
            {
                _idContent          =  this.idSectionMasterDataAgencyRegisteredNew.toLowerCase();
                _cmd                = "getprogram";
                _idCheckbox         = (_idContent + "-program");;
                _idContainer        = (_idContent + "-program-list");
                _valueDegreeLevel   = (_param["value"] != "0" ? _param["value"] : "");
                _valueFaculty       = Util.getSelectionIsSelect({
                                        id: ("#" +_idContent + "-faculty"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                                        valueFalse: ""
                                      });
            }

            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredNew.toLowerCase() + "-faculty"))
            {
                _idContent          = this.idSectionMasterDataAgencyRegisteredNew.toLowerCase();
                _cmd                = "getprogram";
                _idCheckbox         = (_idContent + "-program");;
                _idContainer        = (_idContent + "-program-list");
                _valueDegreeLevel   = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-degreelevel"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel"),
                                        valueFalse: ""
                                    });
                _valueFaculty       = _param["value"];
            }
            
            _cmd                        = _cmd;
            _idCheckbox                 = _idCheckbox;
            _idContainer                = _idContainer;
            _valueParam["idcheckbox"]   = _idCheckbox;
            _valueParam["degreelevel"]  = _valueDegreeLevel;
            _valueParam["faculty"]      = _valueFaculty;

            Util.loadList({
                cmd: _cmd,
                idCheckbox: _idCheckbox,
                idContainer: _idContainer,
                data: _valueParam
            }, function () { });            
        }

        if (_param["id"] == ("#" + this.idSectionDownloadRegistrationFormSearch.toLowerCase() + "-program"))
        {
            Util.clearTable();
            Util.tut.tse.clearTable();
            Util.dialogMessageClose();
        }

        if (_param["id"] == ("#" + this.idSectionMasterDataHospitalOfHealthCareServiceMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataRegistrationFormMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionDownloadRegistrationFormMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesHealthInformationMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesTermServiceHCSConsentMain.toLowerCase() + "-rowperpage"))
        {
            if (_param["id"] == ("#" + this.idSectionMasterDataHospitalOfHealthCareServiceMain.toLowerCase() + "-rowperpage"))  _page = this.pageMasterDataHospitalOfHealthCareServiceMain;
            if (_param["id"] == ("#" + this.idSectionMasterDataRegistrationFormMain.toLowerCase() + "-rowperpage"))             _page = this.pageMasterDataRegistrationFormMain;
            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredMain.toLowerCase() + "-rowperpage"))             _page = this.pageMasterDataAgencyRegisteredMain;
            if (_param["id"] == ("#" + this.idSectionDownloadRegistrationFormMain.toLowerCase() + "-rowperpage"))               _page = this.pageDownloadRegistrationFormMain;
            if (_param["id"] == ("#" + this.idSectionOurServicesHealthInformationMain.toLowerCase() + "-rowperpage"))           _page = this.pageOurServicesHealthInformationMain;
            if (_param["id"] == ("#" + this.idSectionOurServicesTermServiceHCSConsentMain.toLowerCase() + "-rowperpage"))       _page = HCSStaffOurServices.termservicehcsconsent.pageMain;

            if (Util.tut.tse.validateSearch({
                    page: _page
                }))
                Util.tut.tse.getSearch({
                    page: _page
                });
        }
    },
    
    //ฟังก์ชั่นสำหรับกำหนดค่าตามที่ต้องการให้กับ Combobox
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //id                รับค่าชื่อของ Combobox
    //value             รับค่าค่าของ Combobox 
    //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
    setSelectDefaultCombobox: function (_param, _callBackFunc) {
        _param["id"]    = (_param["id"] == undefined ? "" : _param["id"]);
        _param["value"] = (_param["value"] == undefined ? "" : _param["value"]);

        var _cmd;
        var _idCombobox;
        var _idCheckbox;
        var _idContainer;
        var _valueParam = {};
        var _valueDefault;
        var _valueArray;
        var _valueDegreeLevel = "";
        var _valueFaculty = "";
        var _valueRegistrationForm = "";
        var _valueYearEntry = "";
        var _widthInput;
        var _heightInput;
        var _idContent;

        if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionDownloadRegistrationFormSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesHealthInformationSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesStatisticsDownloadHealthCareServiceFormSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesTermServiceHCSConsentSearch.toLowerCase() + "-program"))
        {
            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredSearch.toLowerCase() + "-program"))
            {
                _idContent              = this.idSectionMasterDataAgencyRegisteredSearch.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueFaculty           = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-faculty"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                                            valueFalse: "0"
                                          });
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionDownloadRegistrationFormSearch.toLowerCase() + "-program"))
            {
                _idContent              = this.idSectionDownloadRegistrationFormSearch.toLowerCase();
                _cmd                    = "getagencyregistered";
                _idCombobox             = (_idContent + "-program")
                _idContainer            = (_idContent + "-program-combobox");
                _valueRegistrationForm  = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-registrationform"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-registrationform"),
                                            valueFalse: "n/a"
                                          });
                _valueYearEntry         = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-yearattended"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-yearattended"),
                                            valueFalse: "0"
                                          });
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();;
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesHealthInformationSearch.toLowerCase() + "-program"))
            {
                _idContent              = this.idSectionOurServicesHealthInformationSearch.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueFaculty           = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-faculty"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                                            valueFalse: "0"
                                          });
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesStatisticsDownloadHealthCareServiceFormSearch.toLowerCase() + "-program"))
            {
                _idContent              = this.idSectionOurServicesStatisticsDownloadHealthCareServiceFormSearch.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueFaculty           = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-faculty"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                                            valueFalse: "0"
                                          });
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesTermServiceHCSConsentSearch.toLowerCase() + "-program"))
            {
                _idContent              = this.idSectionOurServicesTermServiceHCSConsentSearch.toLowerCase();
                _cmd                    = "getprogram";
                _idCombobox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-combobox");
                _valueFaculty           = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-faculty"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                                            valueFalse: "0"
                                          });
                _widthInput             = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput            = 25;
            }

            _cmd                            = _cmd;
            _idCombobox                     = _idCombobox;
            _idContainer                    = _idContainer;
            _valueParam["id"]               = _idCombobox;
            _valueParam["degreelevel"]      = _valueDegreeLevel;
            _valueParam["faculty"]          = _valueFaculty;
            _valueParam["registrationform"] = _valueRegistrationForm;
            _valueParam["yearentry"]        = _valueYearEntry;
            _valueDefault                   = _param["value"];
            _widthInput                     = _widthInput;
            _heightInput                    = _heightInput;

            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () { _callBackFunc(); });
        }

        if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredNew.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredEdit.toLowerCase() + "-program"))
        {
            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredNew.toLowerCase() + "-program"))
            {
                _idContent              = this.idSectionMasterDataAgencyRegisteredNew.toLowerCase();
                _cmd                    = "getprogram";
                _idCheckbox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-list");
                _valueDegreeLevel       = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-degreelevel"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel"),
                                            valueFalse: "0"
                                          });
                _valueFaculty           = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-faculty"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                                            valueFalse: "0"
                                          });
            }

            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyRegisteredEdit.toLowerCase() + "-program"))
            {
                _idContent              = this.idSectionMasterDataAgencyRegisteredEdit.toLowerCase();
                _cmd                    = "getprogram";
                _idCheckbox             = (_idContent + "-program");
                _idContainer            = (_idContent + "-program-list");
                _valueDegreeLevel       = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-degreelevel"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel"),
                                            valueFalse: "0"
                                          });
                _valueFaculty           = Util.getSelectionIsSelect({
                                            id: ("#" + _idContent + "-faculty"),
                                            type: "select",
                                            valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                                            valueFalse: "0"
                                          });
            }

            _cmd                        = _cmd;
            _idCheckbox                 = _idCheckbox;
            _idContainer                = _idContainer;
            _valueParam["idcheckbox"]   = _idCheckbox;
            _valueParam["degreelevel"]  = _valueDegreeLevel;
            _valueParam["faculty"]      = _valueFaculty;
            _valueParam["program"]      = _param["value"];

            Util.loadList({
                cmd: _cmd,
                idCheckbox: _idCheckbox,
                idContainer: _idContainer,
                data: _valueParam
            }, function () { _callBackFunc(); });
        }
    },

    //ฟังก์ชั่นสำหรับแสดงไดอะล็อคฟอร์มเมื่อมีการกดลิงค์
    getDialogFormOnClick: function () {
        var _this = this;
        var _page;

        $(".link-" + _this.subjectSectionMeaningofAdmissionType.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionMeaningofStudentStatus.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionMeaningofHealthCareServiceForm.toLowerCase()).click(function () {
            if ($(this).hasClass("link-" + _this.subjectSectionMeaningofAdmissionType.toLowerCase()) == true)           _page = _this.pageMeaningofAdmissionTypeMain;
            if ($(this).hasClass("link-" + _this.subjectSectionMeaningofStudentStatus.toLowerCase()) == true)           _page = _this.pageMeaningofStudentStatusMain;
            if ($(this).hasClass("link-" + _this.subjectSectionMeaningofHealthCareServiceForm.toLowerCase()) == true)   _page = _this.pageMeaningofHealthCareServiceForm;            

            Util.loadForm({
                index: 1,
                name: _page,
                dialog: true
            }, function () { });
        });
    },
}