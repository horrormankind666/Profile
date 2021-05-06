// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๒/๐๖/๒๕๕๘>
// Modify date  : <๒๙/๐๕/๒๕๖๒>
// Description  : <รวมรวบฟังก์ชั่นใช้งานทั่วไปของระบบ>
// =============================================

var UDSStaffUtil = {
    tse: null,
    tst: null,
    tus: null,
    tap: null,
    tos: null,
    tpd: null,
    parentWidth: 1008,
    pathProject: "UploadDocumentStaff",
    urlHandler: "../../../Content/Handler/UploadDocumentStaff/UDSStaffHandler.ashx",
    supportFileType: "jpg, jpeg",
    
    subjectSectionMeaningofAdmissionType: "MeaningOfAdmissionType",
    subjectSectionMeaningofStudentStatus: "MeaningOfStudentStatus",
    subjectSectionMeaningOfSubmittedStatus: "MeaningOfSubmittedStatus",
    subjectSectionMeaningOfApprovalStatus: "MeaningOfApprovalStatus",
    subjectSectionMeaningOfAuditedStatus: "MeaningOfAuditedStatus",  
    subjectSectionStudentRecords: "StudentRecords",
    subjectSectionOverview: "Overview",
    subjectSectionProfilePicture: "ProfilePicture",
    subjectSectionIdentityCard: "IdentityCard",
    subjectSectionProfilePictureIdentityCard: "ProfilePictureIdentityCard",
    subjectSectionTranscript: "Transcript",
    subjectSectionTranscriptInstitute: "TranscriptInstitute",
    subjectSectionTranscriptFrontside: "TranscriptFrontside",
    subjectSectionTranscriptBackside: "TranscriptBackside",
    subjectSectionExport: "Export",
    subjectSectionCopy: "Copy",
    subjectSectionSave: "Save",
    subjectSectionViewChart: "ViewChart",
    subjectSectionViewTable: "ViewTable",
    subjectSectionSettingAccesstotheSystem: "SettingAccesstotheSystem",
    subjectSectionUploadSubmitDocument: "UploadSubmitDocument",
    subjectSectionApproveDocument: "ApproveDocument",
    subjectSectionOurServices: "OurServices",
    subjectSectionOurServicesDocumentStatusStudent: "OurServicesDocumentStatusStudent",
    subjectSectionOurServicesExportProfilePictureApproved: "OurServicesExportProfilePictureApproved",
    subjectSectionOurServicesExportStudentRecordsInformationForSmartCard: "OurServicesExportStudentRecordsInformationForSmartCard",
    subjectSectionOurServicesCopyProfilePictureApprovedtotheStore: "OurServicesCopyProfilePictureApprovedtotheStore",
    subjectSectionAuditTranscriptApprovedLevel1ViewTable: "AuditTranscriptApprovedLevel1ViewTable",
    subjectSectionAuditTranscriptApprovedLevel21ViewTable: "AuditTranscriptApprovedLevel21ViewTable",
    subjectSectionAuditTranscriptApprovedLevel22ViewTable: "AuditTranscriptApprovedLevel22ViewTable",
    subjectSectionOurServicesAuditTranscriptApproved: "OurServicesAuditTranscriptApproved",
    subjectSectionOurServicesExportSaveAuditTranscriptApproved: "OurServicesExportSaveAuditTranscriptApproved",

    idSectionViewMessageMain: "Main-ViewMessage",
    idSectionSettingAccesstotheSystemEdit: "Edit-SettingAccesstotheSystem",
    idSectionUploadSubmitDocumentMain: "Main-UploadSubmitDocument",
    idSectionUploadSubmitDocumentSearch: "Search-UploadSubmitDocument",    
    idSectionUploadSubmitDocumentPreview: "Preview-UploadSubmitDocument",
    idSectionUploadSubmitDocumentProfilePictureIdentityCardPreview: "Preview-UploadSubmitDocumentProfilePictureIdentityCard",
    idSectionUploadSubmitDocumentProfilePicturePreview: "Preview-UploadSubmitDocumentProfilePicture",
    idSectionUploadSubmitDocumentIdentityCardPreview: "Preview-UploadSubmitDocumentIdentityCard",
    idSectionUploadSubmitDocumentTranscriptPreview: "Preview-UploadSubmitDocumentTranscript",
    idSectionUploadSubmitDocumentTranscriptInstitutePreview: "Preview-UploadSubmitDocumentTranscriptInstitute",
    idSectionUploadSubmitDocumentTranscriptFrontsidePreview: "Preview-UploadSubmitDocumentTranscriptFrontside",
    idSectionUploadSubmitDocumentTranscriptBacksidePreview: "Preview-UploadSubmitDocumentTranscriptBackside",
    idSectionUploadSubmitDocumentAddUpdate: "AddUpdate-UploadSubmitDocument",
    idSectionUploadSubmitDocumentStudentRecordsAddUpdate: "AddUpdate-UploadSubmitDocumentStudentRecords",
    idSectionUploadSubmitDocumentOverviewAddUpdate: "AddUpdate-UploadSubmitDocumentOverview",
    idSectionUploadSubmitDocumentProfilePictureAddUpdate: "AddUpdate-UploadSubmitDocumentProfilePicture",
    idSectionUploadSubmitDocumentIdentityCardAddUpdate: "AddUpdate-UploadSubmitDocumentIdentityCard",
    idSectionUploadSubmitDocumentTranscriptAddUpdate: "AddUpdate-UploadSubmitDocumentTranscript",
    idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate: "AddUpdate-UploadSubmitDocumentTranscriptInstitute",
    idSectionUploadSubmitDocumentTranscriptFrontsideAddUpdate: "AddUpdate-UploadSubmitDocumentTranscriptFrontside",
    idSectionUploadSubmitDocumentTranscriptBacksideAddUpdate: "AddUpdate-UploadSubmitDocumentTranscriptBackside",
    idSectionApproveDocumentMain: "Main-ApproveDocument",
    idSectionApproveDocumentSearch: "Search-ApproveDocument",
    idSectionApproveDocumentEdit: "Edit-ApproveDocument",
    idSectionApproveDocumentProfilePictureIdentityCardEdit: "Edit-ApproveDocumentProfilePictureIdentityCard",
    idSectionApproveDocumentProfilePictureEdit: "Edit-ApproveDocumentProfilePicture",
    idSectionApproveDocumentIdentityCardEdit: "Edit-ApproveDocumentIdentityCard",
    idSectionApproveDocumentTranscriptEdit: "Edit-ApproveDocumentTranscript",
    idSectionApproveDocumentTranscriptInstituteEdit: "Edit-ApproveDocumentTranscriptInstitute",
    idSectionApproveDocumentTranscriptFrontsideEdit: "Edit-ApproveDocumentTranscriptFrontside",
    idSectionApproveDocumentTranscriptBacksideEdit: "Edit-ApproveDocumentTranscriptBackside",
    idSectionApproveDocumentMessageAddUpdate: "AddUpdate-ApproveDocumentMessage",
    idSectionOurServicesDocumentStatusStudentMain: "Main-OurServicesDocumentStatusStudent",
    idSectionOurServicesDocumentStatusStudentSearch: "Search-OurServicesDocumentStatusStudent",
    idSectionOurServicesDocumentStatusStudentViewChartMain: "Main-OurServicesDocumentStatusStudentViewChart",
    idSectionOurServicesDocumentStatusStudentViewTableMain: "Main-OurServicesDocumentStatusStudentViewTable",
    idSectionOurServicesDocumentStatusStudentLevel1ViewTableMain: "Main-OurServicesDocumentStatusStudentLevel1ViewTable",
    idSectionOurServicesDocumentStatusStudentLevel1ViewTablePreview: "Preview-OurServicesDocumentStatusStudentLevel1ViewTable",
    idSectionOurServicesDocumentStatusStudentLevel1ViewTableProgress: "Progress-OurServicesDocumentStatusStudentLevel1ViewTable",
    idSectionOurServicesExportProfilePictureApprovedMain: "Main-OurServicesExportProfilePictureApproved",
    idSectionOurServicesExportProfilePictureApprovedSearch: "Search-OurServicesExportProfilePictureApproved",
    idSectionOurServicesExportProfilePictureApprovedPreview: "Preview-OurServicesExportProfilePictureApproved",
    idSectionOurServicesExportProfilePictureApprovedProfilePicturePreview: "Preview-OurServicesExportProfilePictureApprovedProfilePicture",
    idSectionOurServicesExportProfilePictureApprovedProgress: "Progress-OurServicesExportProfilePictureApproved",
    idSectionOurServicesExportStudentRecordsInformationForSmartCardMain: "Main-OurServicesExportStudentRecordsInformationForSmartCard",
    idSectionOurServicesExportStudentRecordsInformationForSmartCardSearch: "Search-OurServicesExportStudentRecordsInformationForSmartCard",
    idSectionOurServicesExportStudentRecordsInformationForSmartCardPreview: "Preview-OurServicesExportStudentRecordsInformationForSmartCard",
    idSectionOurServicesExportStudentRecordsInformationForSmartCardProgress: "Progress-OurServicesExportStudentRecordsInformationForSmartCard",
    idSectionOurServicesCopyProfilePictureApprovedtotheStoreMain: "Main-OurServicesCopyProfilePictureApprovedtotheStore",
    idSectionOurServicesCopyProfilePictureApprovedtotheStoreSearch: "Search-OurServicesCopyProfilePictureApprovedtotheStore",
    idSectionOurServicesCopyProfilePictureApprovedtotheStorePreview: "Preview-OurServicesCopyProfilePictureApprovedtotheStore",
    idSectionOurServicesCopyProfilePictureApprovedtotheStoreProfilePicturePreview: "Preview-OurServicesCopyProfilePictureApprovedtotheStoreProfilePicture",
    idSectionOurServicesCopyProfilePictureApprovedtotheStoreProgress: "Progress-OurServicesCopyProfilePictureApprovedtotheStore",
    idSectionOurServicesAuditTranscriptApprovedMain: "Main-OurServicesAuditTranscriptApproved",
    idSectionOurServicesAuditTranscriptApprovedSearch: "Search-OurServicesAuditTranscriptApproved",
    idSectionOurServicesAuditTranscriptApprovedViewChartMain: "Main-OurServicesAuditTranscriptApprovedViewChart",
    idSectionOurServicesAuditTranscriptApprovedViewTableMain: "Main-OurServicesAuditTranscriptApprovedViewTable",
    idSectionOurServicesAuditTranscriptApprovedLevel1ViewTableMain: "Main-OurServicesAuditTranscriptApprovedLevel1ViewTable",
    idSectionOurServicesAuditTranscriptApprovedLevel1ViewTableProgress: "Progress-OurServicesAuditTranscriptApprovedLevel1ViewTable",
    idSectionOurServicesAuditTranscriptApprovedLevel21ViewTableMain: "Main-OurServicesAuditTranscriptApprovedLevel21ViewTable",
    idSectionOurServicesAuditTranscriptApprovedLevel21ViewTableProgress: "Progress-OurServicesAuditTranscriptApprovedLevel21ViewTable",
    idSectionOurServicesAuditTranscriptApprovedLevel22ViewTableMain: "Main-OurServicesAuditTranscriptApprovedLevel22ViewTable",
    idSectionOurServicesAuditTranscriptApprovedLevel22ViewTableProgress: "Progress-OurServicesAuditTranscriptApprovedLevel22ViewTable",
    idSectionOurServicesExportSaveAuditTranscriptApprovedMain: "Main-OurServicesExportSaveAuditTranscriptApproved",
    idSectionOurServicesExportSaveAuditTranscriptApprovedSearch: "Search-OurServicesExportSaveAuditTranscriptApproved",
    idSectionOurServicesExportSaveAuditTranscriptApprovedPreview: "Preview-OurServicesExportSaveAuditTranscriptApproved",
    idSectionOurServicesExportTranscriptApprovedProgress: "Progress-OurServicesExportTranscriptApproved",
    idSectionOurServicesSaveAuditTranscriptApprovedProgress: "Progress-OurServicesSaveAuditTranscriptApproved",

    pageMain: "Main",
    pageMeaningofAdmissionTypeMain: "MeaningOfAdmissionTypeMain",
    pageMeaningOfStudentStatusMain: "MeaningOfStudentStatusMain",
    pageMeaningOfSubmittedStatusMain: "MeaningOfSubmittedStatusMain",
    pageMeaningOfApprovalStatusMain: "MeaningOfApprovalStatusMain",
    pageMeaningOfAuditedStatusMain: "MeaningOfAuditedStatusMain",
    pageViewProfilePictureMain: "ViewProfilePictureMain",
    pageViewIdentityCardMain: "ViewIdentityCardMain",
    pageViewTranscriptFrontsideMain: "ViewTranscriptFrontsideMain",
    pageViewTranscriptBacksideMain: "ViewTranscriptBacksideMain",
    pageViewMessageMain: "ViewMessageMain",
    pageRecommendUploadProfilePictureMain: "RecommendUploadProfilePictureMain",
    pageRecommendUploadIdentityCardMain: "RecommendUploadIdentityCardMain",
    pageRecommendUploadTranscriptMain: "RecommendUploadTranscriptMain",
    pageRecommendUploadTranscriptFrontsideMain: "RecommendUploadTranscriptFrontsideMain",
    pageRecommendUploadTranscriptBacksideMain: "RecommendUploadTranscriptBacksideMain",
    pageRecommendSubmitMain: "RecommendSubmitMain",
    pageStudentRecordsStudentCVMain: "StudentRecordsStudentCVMain",
    pageSettingAccesstotheSystemEdit: "SettingAccesstotheSystemEdit",
    pageUploadSubmitDocumentMain: "UploadSubmitDocumentMain",    
    pageUploadSubmitDocumentProfilePictureIdentityCardPreview: "UploadSubmitDocumentProfilePictureIdentityCardPreview",
    pageUploadSubmitDocumentTranscriptPreview: "UploadSubmitDocumentTranscriptPreview",
    pageUploadSubmitDocumentAddUpdate: "UploadSubmitDocumentAddUpdate",
    pageUploadSubmitDocumentStudentRecordsAddUpdate: "UploadSubmitDocumentStudentRecordsAddUpdate",
    pageUploadSubmitDocumentOverviewAddUpdate: "UploadSubmitDocumentOverviewAddUpdate",
    pageUploadSubmitDocumentProfilePictureAddUpdate: "UploadSubmitDocumentProfilePictureAddUpdate",
    pageUploadSubmitDocumentIdentityCardAddUpdate: "UploadSubmitDocumentIdentityCardAddUpdate",
    pageUploadSubmitDocumentTranscriptAddUpdate: "UploadSubmitDocumentTranscriptAddUpdate",    
    pageApproveDocumentMain: "ApproveDocumentMain",
    pageApproveDocumentEdit: "ApproveDocumentEdit",    
    pageApproveDocumentProfilePictureIdentityCardEdit: "ApproveDocumentProfilePictureIdentityCardEdit",
    pageApproveDocumentTranscriptEdit: "ApproveDocumentTranscriptEdit",
    pageApproveDocumentMessageAddUpdate: "ApproveDocumentMessageAddUpdate",
    pageOurServicesDocumentStatusStudentMain: "OurServicesDocumentStatusStudentMain",
    pageOurServicesDocumentStatusStudentViewChartMain: "OurServicesDocumentStatusStudentViewChartMain",
    pageOurServicesDocumentStatusStudentViewTableMain: "OurServicesDocumentStatusStudentViewTableMain",
    pageOurServicesDocumentStatusStudentLevel1ViewTableMain: "OurServicesDocumentStatusStudentLevel1ViewTableMain",
    pageOurServicesDocumentStatusStudentLevel1ViewTablePreview: "OurServicesDocumentStatusStudentLevel1ViewTablePreview",
    pageOurServicesDocumentStatusStudentLevel1ViewTableProfilePictureIdentityCardPreview: "OurServicesDocumentStatusStudentLevel1ViewTableProfilePictureIdentityCardPreview",
    pageOurServicesDocumentStatusStudentLevel1ViewTableTranscriptPreview: "OurServicesDocumentStatusStudentLevel1ViewTableTranscriptPreview",
    pageOurServicesDocumentStatusStudentLevel1ViewTableProgress: "OurServicesDocumentStatusStudentLevel1ViewTableProgress",
    pageOurServicesExportProfilePictureApprovedMain: "OurServicesExportProfilePictureApprovedMain",
    pageOurServicesExportProfilePictureApprovedProfilePicturePreview: "OurServicesExportProfilePictureApprovedProfilePicturePreview",
    pageOurServicesExportProfilePictureApprovedProgress: "OurServicesExportProfilePictureApprovedProgress",
    pageOurServicesExportStudentRecordsInformationForSmartCardMain: "OurServicesExportStudentRecordsInformationForSmartCardMain",
    pageOurServicesExportStudentRecordsInformationForSmartCardProfilePicturePreview: "OurServicesExportStudentRecordsInformationForSmartCardProfilePicturePreview",
    pageOurServicesExportStudentRecordsInformationForSmartCardProgress: "OurServicesExportStudentRecordsInformationForSmartCardProgress",
    pageOurServicesCopyProfilePictureApprovedtotheStoreMain: "OurServicesCopyProfilePictureApprovedtotheStoreMain",
    pageOurServicesCopyProfilePictureApprovedtotheStoreProfilePicturePreview: "OurServicesCopyProfilePictureApprovedtotheStoreProfilePicturePreview",    
    pageOurServicesCopyProfilePictureApprovedtotheStoreProgress: "OurServicesCopyProfilePictureApprovedtotheStoreProgress",
    pageOurServicesAuditTranscriptApprovedMain: "OurServicesAuditTranscriptApprovedMain",
    pageOurServicesAuditTranscriptApprovedViewChartMain: "OurServicesAuditTranscriptApprovedViewChartMain",
    pageOurServicesAuditTranscriptApprovedViewTableMain: "OurServicesAuditTranscriptApprovedViewTableMain",
    pageOurServicesAuditTranscriptApprovedLevel1ViewTableMain: "OurServicesAuditTranscriptApprovedLevel1ViewTableMain",
    pageOurServicesAuditTranscriptApprovedLevel1ViewTableProgress: "OurServicesAuditTranscriptApprovedLevel1ViewTableProgress",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendMain: "OurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendMain",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendProgress: "OurServicesAuditTranscriptApprovedLevel21ViewTableNeedSendProgress",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendMain: "OurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendMain",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendProgress: "OurServicesAuditTranscriptApprovedLevel22ViewTableNeedSendProgress",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendMain: "OurServicesAuditTranscriptApprovedLevel21ViewTableSendMain",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendProgress: "OurServicesAuditTranscriptApprovedLevel21ViewTableSendProgress",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendMain: "OurServicesAuditTranscriptApprovedLevel22ViewTableSendMain",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendProgress: "OurServicesAuditTranscriptApprovedLevel22ViewTableSendProgress",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendMain: "OurServicesAuditTranscriptApprovedLevel21ViewTableNotSendMain",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableNotSendProgress: "OurServicesAuditTranscriptApprovedLevel21ViewTableNotSendProgress",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendMain: "OurServicesAuditTranscriptApprovedLevel22ViewTableNotSendMain",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableNotSendProgress: "OurServicesAuditTranscriptApprovedLevel22ViewTableNotSendProgress",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveMain: "OurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveMain",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveProgress: "OurServicesAuditTranscriptApprovedLevel21ViewTableSendReceiveProgress",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveMain: "OurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveMain",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveProgress: "OurServicesAuditTranscriptApprovedLevel22ViewTableSendReceiveProgress",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveMain: "OurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveMain",
    pageOurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveProgress: "OurServicesAuditTranscriptApprovedLevel21ViewTableSendNotReceiveProgress",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveMain: "OurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveMain",
    pageOurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveProgress: "OurServicesAuditTranscriptApprovedLevel22ViewTableSendNotReceiveProgress",    
    pageOurServicesExportSaveAuditTranscriptApprovedMain: "OurServicesExportSaveAuditTranscriptApprovedMain",
    pageOurServicesExportSaveAuditTranscriptApprovedTranscriptPreview: "OurServicesExportSaveAuditTranscriptApprovedTranscriptPreview",
    pageOurServicesExportTranscriptApprovedProgress: "OurServicesExportTranscriptApprovedProgress",
    pageOurServicesSaveAuditTranscriptApprovedProgress: "OurServicesSaveAuditTranscriptApprovedProgress",

    //ฟังก์ชั่นสำหรับกำหนดให้ทำงานตามเหตุการณ์ต่าง ๆ ที่เกิดขึ้นบน Menu Bar
    initMenuBar: function () {
        var _this = this;

        $(function () {
            $(".menubar .link-click").click(function () {
                var _idLink = $(this).attr("id");
                
                Util.dialogMessageClose();

                if (_idLink == ("link-" + _this.subjectSectionSettingAccesstotheSystem.toLowerCase()))                                  Util.gotoPage({ page: ("index.aspx?p=" + _this.pageSettingAccesstotheSystemEdit) });
                if (_idLink == ("link-" + _this.subjectSectionUploadSubmitDocument.toLowerCase()))                                      Util.gotoPage({ page: ("index.aspx?p=" + _this.pageUploadSubmitDocumentMain) });                
                if (_idLink == ("link-" + _this.subjectSectionApproveDocument.toLowerCase()))                                           Util.gotoPage({ page: ("index.aspx?p=" + _this.pageApproveDocumentMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesDocumentStatusStudent.toLowerCase()))                          Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesDocumentStatusStudentMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesExportProfilePictureApproved.toLowerCase()))                   Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesExportProfilePictureApprovedMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesExportStudentRecordsInformationForSmartCard.toLowerCase()))    Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesExportStudentRecordsInformationForSmartCardMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesCopyProfilePictureApprovedtotheStore.toLowerCase()))           Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesCopyProfilePictureApprovedtotheStoreMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesAuditTranscriptApproved.toLowerCase()))                        Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesAuditTranscriptApprovedMain) });
                if (_idLink == ("link-" + _this.subjectSectionOurServicesExportSaveAuditTranscriptApproved.toLowerCase()))              Util.gotoPage({ page: ("index.aspx?p=" + _this.pageOurServicesExportSaveAuditTranscriptApprovedMain) });
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
                
                if (_idLink == ("save-"     + _this.pageSettingAccesstotheSystemEdit.toLowerCase()))                                Util.tut.tst.confirmSave({ page: _this.pageSettingAccesstotheSystemEdit });
                if (_idLink == ("undo-"     + _this.pageSettingAccesstotheSystemEdit.toLowerCase()))                                Util.tut.tst.accesstothesystem.sectionAddUpdate.resetMain();

                if (_idLink == ("search-"   + _this.pageUploadSubmitDocumentMain.toLowerCase()))                                    Util.setSearchShow();
                if (_idLink == ("upload-"   + _this.pageUploadSubmitDocumentMain.toLowerCase()))                                    _this.getUploadSubmitDocument({ data: $("#" + Util.tut.tus.idSectionPreview + "-personid-hidden").val() });
                if (_idLink == ("profile-"  + _this.pageUploadSubmitDocumentMain.toLowerCase()))                                    Util.getStudentCV({ data: $("#" + Util.tut.tus.idSectionPreview + "-personid-hidden").val() });

                if (_idLink == ("home-"     + _this.pageUploadSubmitDocumentAddUpdate.toLowerCase()))                               Util.getPage();
                if (_idLink == ("profile-"  + _this.pageUploadSubmitDocumentAddUpdate.toLowerCase()))                               Util.getStudentCV({ data: $("#" + Util.tut.tus.sectionAddUpdate.studentrecords.idSectionAddUpdate + "-personid-hidden").val() });
                if (_idLink == ("close-"    + _this.pageUploadSubmitDocumentAddUpdate.toLowerCase()))                               Util.gotoPage({ page: ("index.aspx?p=" + _this.pageUploadSubmitDocumentMain) });

                if (_idLink == ("search-"   + _this.pageApproveDocumentMain.toLowerCase()))                                         Util.setSearchShow();
                if (_idLink == ("profile-"  + _this.pageApproveDocumentMain.toLowerCase()))                                         Util.getStudentCV({ data: $("#" + Util.tut.tap.idSectionEdit + "-personid-hidden").val() });

                if (_idLink == ("search-"   + _this.pageOurServicesDocumentStatusStudentMain.toLowerCase()))                        Util.setSearchShow();
                if (_idLink == ("profile-"  + _this.pageOurServicesDocumentStatusStudentMain.toLowerCase()))                        Util.getStudentCV({ data: $("#" + Util.tut.tos.documentstatusstudent.viewtable.idSectionLevel1Preview+ "-personid-hidden").val() });

                if (_idLink == ("search-"   + _this.pageOurServicesExportProfilePictureApprovedMain.toLowerCase()))                 Util.setSearchShow();
                if (_idLink == ("profile-"  + _this.pageOurServicesExportProfilePictureApprovedMain.toLowerCase()))                 Util.getStudentCV({ data: $("#" + Util.tut.tos.exportprofilepictureapproved.idSectionPreview + "-personid-hidden").val() });

                if (_idLink == ("search-"   + _this.pageOurServicesExportStudentRecordsInformationForSmartCardMain.toLowerCase()))  Util.setSearchShow();
                if (_idLink == ("profile-"  + _this.pageOurServicesExportStudentRecordsInformationForSmartCardMain.toLowerCase()))  Util.getStudentCV({ data: $("#" + Util.tut.tos.exportstudentrecordsinformationforsmartcard.idSectionPreview + "-personid-hidden").val() });

                if (_idLink == ("search-"   + _this.pageOurServicesCopyProfilePictureApprovedtotheStoreMain.toLowerCase()))         Util.setSearchShow();
                if (_idLink == ("profile-"  + _this.pageOurServicesCopyProfilePictureApprovedtotheStoreMain.toLowerCase()))         Util.getStudentCV({ data: $("#" + Util.tut.tos.copyprofilepictureapprovedtothestore.idSectionPreview + "-personid-hidden").val() });

                if (_idLink == ("search-"   + _this.pageOurServicesAuditTranscriptApprovedMain.toLowerCase()))                      Util.setSearchShow();

                if (_idLink == ("search-"   + _this.pageOurServicesExportSaveAuditTranscriptApprovedMain.toLowerCase()))            Util.setSearchShow();
                if (_idLink == ("profile-"  + _this.pageOurServicesExportSaveAuditTranscriptApprovedMain.toLowerCase()))            Util.getStudentCV({ data: $("#" + Util.tut.tos.exportsaveaudittranscriptapproved.idSectionPreview + "-personid-hidden").val() });
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
        if (_error == false && _status == "Y002")           { _error = true; _msgTH = "เชื่อมต่อเครื่องแม่ข่ายไม่สำเร็จ"; _msgEN = "Not connect server."; }

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
                    $("#bodysearch").html(_result.SearchContent);

                $("#contentbody-content").html(_result.MainContent).show();

                Util.setMenuBarLayout();
                Util.setInfoBarLayout();
                Util.setMainLayout();
                Util.setStickyTop(0);
                Util.setChartLayout();
                Util.setTableLayout();
                Util.setFooterLayout();

                if (_page == _this.pageSettingAccesstotheSystemEdit)
                    Util.tut.tst.accesstothesystem.sectionAddUpdate.sectionEdit.initMain();

                if (_page == _this.pageUploadSubmitDocumentMain)
                {
                    Util.tut.tse.uploadsubmitdocument.initSearch();
                    Util.initSearch();
                    Util.tut.tus.sectionMain.initMain();
                    Util.tut.tus.sectionMain.initTable();
                    _this.initPreviewDocument({
                        idMain: Util.tut.tus.idSectionMain,
                        idPreview: Util.tut.tus.idSectionPreview
                    });
                }

                if (_page == _this.pageUploadSubmitDocumentAddUpdate)
                    Util.tut.tus.sectionAddUpdate.initMain();

                if (_page == _this.pageApproveDocumentMain)
                { 
                    Util.tut.tse.approvedocument.initSearch();
                    Util.initSearch();
                    Util.tut.tap.sectionMain.initMain();
                    Util.tut.tap.sectionMain.initTable();
                    _this.initPreviewDocument({
                        idMain: Util.tut.tap.idSectionMain,
                        idPreview: Util.tut.tap.idSectionEdit
                    });
                }

                if (_page == _this.pageOurServicesDocumentStatusStudentMain)
                {
                    Util.tut.tse.ourservices.documentstatusstudent.initSearch();
                    Util.initSearch();
                    Util.tut.tos.documentstatusstudent.sectionMain.initMain();
                }
                
                if (_page == _this.pageOurServicesExportProfilePictureApprovedMain)
                {
                    Util.tut.tse.ourservices.exportprofilepictureapproved.initSearch();
                    Util.initSearch();
                    Util.tut.tos.exportprofilepictureapproved.sectionMain.initMain();
                    Util.tut.tos.exportprofilepictureapproved.sectionMain.initTable();
                    Util.tut.initPreviewDocument({
                        idMain: Util.tut.tos.exportprofilepictureapproved.idSectionMain,
                        idPreview: Util.tut.tos.exportprofilepictureapproved.idSectionPreview
                    });
                }

                if (_page == _this.pageOurServicesExportStudentRecordsInformationForSmartCardMain)
                {
                    Util.tut.tse.ourservices.exportstudentrecordsinformationforsmartcard.initSearch();
                    Util.initSearch();
                    Util.tut.tos.exportstudentrecordsinformationforsmartcard.sectionMain.initMain();
                    Util.tut.tos.exportstudentrecordsinformationforsmartcard.sectionMain.initTable();
                    Util.tut.initPreviewDocument({
                        idMain: Util.tut.tos.exportstudentrecordsinformationforsmartcard.idSectionMain,
                        idPreview: Util.tut.tos.exportstudentrecordsinformationforsmartcard.idSectionPreview
                    });
                }

                if (_page == _this.pageOurServicesCopyProfilePictureApprovedtotheStoreMain)
                {
                    Util.tut.tse.ourservices.copyprofilepictureapprovedtothestore.initSearch();   
                    Util.initSearch();
                    Util.tut.tos.copyprofilepictureapprovedtothestore.sectionMain.initMain();
                    Util.tut.tos.copyprofilepictureapprovedtothestore.sectionMain.initTable();
                    Util.tut.initPreviewDocument({
                        idMain: Util.tut.tos.copyprofilepictureapprovedtothestore.idSectionMain,
                        idPreview: Util.tut.tos.copyprofilepictureapprovedtothestore.idSectionPreview
                    });
                }

                if (_page == _this.pageOurServicesAuditTranscriptApprovedMain)
                {                    
                    Util.tut.tse.ourservices.audittranscriptapproved.initSearch();
                    Util.initSearch();
                    Util.tut.tos.audittranscriptapproved.sectionMain.initMain();
                }

                if (_page == _this.pageOurServicesExportSaveAuditTranscriptApprovedMain)
                {
                    Util.tut.tse.ourservices.exportsaveaudittranscriptapproved.initSearch();
                    Util.initSearch();
                    Util.tut.tos.exportsaveaudittranscriptapproved.sectionMain.initMain();
                    Util.tut.tos.exportsaveaudittranscriptapproved.sectionMain.initTable();
                    Util.tut.initPreviewDocument({
                        idMain: Util.tut.tos.exportsaveaudittranscriptapproved.idSectionMain,
                        idPreview: Util.tut.tos.exportsaveaudittranscriptapproved.idSectionPreview
                    });
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
        var _valueCountry = "";
        var _valueProvince = "";
        var _widthInput;
        var _heightInput;
        var _idContent;
        var _page;

        if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionUploadSubmitDocumentSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionApproveDocumentSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionApproveDocumentSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesDocumentStatusStudentSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesDocumentStatusStudentSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportProfilePictureApprovedSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportProfilePictureApprovedSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationForSmartCardSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationForSmartCardSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesCopyProfilePictureApprovedtotheStoreSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesCopyProfilePictureApprovedtotheStoreSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-instituteprovince"))
        {
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionApproveDocumentSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesDocumentStatusStudentSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportProfilePictureApprovedSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationForSmartCardSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesCopyProfilePictureApprovedtotheStoreSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-degreelevel"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-degreelevel", "");
                _cmd                = "getprogram";
                _idCombobox         = (_idContent + "-program");
                _idContainer        = (_idContent + "-program-combobox");
                _valueDegreeLevel   = (_param["value"] != "0" ? _param["value"] : "");
                _valueFaculty       = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-faculty"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty")
                                      });
                _widthInput         = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput        = 27;
            }

            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionApproveDocumentSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesDocumentStatusStudentSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportProfilePictureApprovedSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationForSmartCardSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesCopyProfilePictureApprovedtotheStoreSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-faculty"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-faculty", "");
                _cmd                = "getprogram";
                _idCombobox         = (_idContent + "-program");
                _idContainer        = (_idContent + "-program-combobox");
                _valueDegreeLevel   = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-degreelevel"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel")
                                      });
                _valueFaculty       = _param["value"];
                _widthInput         = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput        = 27;
            }
            
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institutecountry"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-institutecountry", "");
                _cmd                = "getprovince";
                _idCombobox         = (_idContent + "-instituteprovince");
                _idContainer        = (_idContent + "-instituteprovince-combobox");
                _valueCountry       = _param["value"];
                _widthInput         = 463;
                _heightInput        = 29;
            }
            
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-instituteprovince"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-instituteprovince", "");
                _cmd                = "getinstitute";
                _idCombobox         = (_idContent + "-institute");
                _idContainer        = (_idContent + "-institute-combobox");
                _valueProvince      = _param["value"];
                _widthInput         = 463;
                _heightInput        = 29;
            }           
                                                                        
            if (_param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-institutecountry") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-institutecountry"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-institutecountry", "");
                _cmd                = "getudsprovince";
                _idCombobox         = (_idContent + "-instituteprovince");
                _idContainer        = (_idContent + "-instituteprovince-combobox");
                _valueCountry       = _param["value"];
                _widthInput         = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput        = 27;
            }
            
            if (_param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-instituteprovince") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-instituteprovince"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-instituteprovince", "");
                _cmd                = "getudsinstitute";
                _idCombobox         = (_idContent + "-institute");
                _idContainer        = (_idContent + "-institute-combobox");
                _valueProvince      = _param["value"];
                _widthInput         = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput        = 27;
            }
            
            _cmd                        = _cmd;
            _idCombobox                 = _idCombobox;
            _idContainer                = _idContainer;
            _valueParam["id"]           = _idCombobox;
            _valueParam["degreelevel"]  = _valueDegreeLevel;
            _valueParam["faculty"]      = _valueFaculty;
            _valueParam["country"]      = _valueCountry;
            _valueParam["province"]     = _valueProvince;
            _valueDefault               = "0";
            _widthInput                 = _widthInput;
            _heightInput                = _heightInput;
            
            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () {
                if (_param["id"] == ("#" + _this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institutecountry") ||
                    _param["id"] == ("#" + _this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-institutecountry") ||
                    _param["id"] == ("#" + _this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-institutecountry"))
                {                    
                    _this.setSelectDefaultCombobox({
                        id: ("#" + _idContent + "-institute"),
                        value: "0"
                    }, function () { });
                }
            });
        }
        
        if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionApproveDocumentMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesDocumentStatusStudentLevel1ViewTableMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportProfilePictureApprovedMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationForSmartCardMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesCopyProfilePictureApprovedtotheStoreMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedMain.toLowerCase() + "-rowperpage"))
        {
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentMain.toLowerCase() + "-rowperpage"))                                   _page = this.pageUploadSubmitDocumentMain;
            if (_param["id"] == ("#" + this.idSectionApproveDocumentMain.toLowerCase() + "-rowperpage"))                                        _page = this.pageApproveDocumentMain;
            if (_param["id"] == ("#" + this.idSectionOurServicesDocumentStatusStudentLevel1ViewTableMain.toLowerCase() + "-rowperpage"))        _page = this.pageOurServicesDocumentStatusStudentMain;
            if (_param["id"] == ("#" + this.idSectionOurServicesExportProfilePictureApprovedMain.toLowerCase() + "-rowperpage"))                _page = this.pageOurServicesExportProfilePictureApprovedMain; 
            if (_param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationForSmartCardMain.toLowerCase() + "-rowperpage")) _page = this.pageOurServicesExportStudentRecordsInformationForSmartCardMain
            if (_param["id"] == ("#" + this.idSectionOurServicesCopyProfilePictureApprovedtotheStoreMain.toLowerCase() + "-rowperpage"))        _page = this.pageOurServicesCopyProfilePictureApprovedtotheStoreMain;
            if (_param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedMain.toLowerCase() + "-rowperpage"))           _page = this.pageOurServicesExportSaveAuditTranscriptApprovedMain;

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
        var _valueCountry = "";
        var _valueProvince = "";
        var _widthInput;
        var _heightInput;
        var _idContent;

        if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institute") ||
            _param["id"] == ("#" + this.idSectionApproveDocumentSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesDocumentStatusStudentSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportProfilePictureApprovedSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationForSmartCardSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesCopyProfilePictureApprovedtotheStoreSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-institute") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-institute"))
        {
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionApproveDocumentSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesDocumentStatusStudentSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportProfilePictureApprovedSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationForSmartCardSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesCopyProfilePictureApprovedtotheStoreSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-program"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-program", "");
                _cmd                = "getprogram";
                _idCombobox         = (_idContent + "-program");
                _idContainer        = (_idContent + "-program-combobox");
                _valueDegreeLevel   = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-degreelevel"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel")
                                      });
                _valueFaculty       = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-faculty"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                                        valueFalse: "0"
                                      });
                _widthInput         = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput        = 27;
            }

            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-instituteprovince"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-instituteprovince", "");
                _cmd                = "getprovince";
                _idCombobox         = (_idContent + "-instituteprovince");
                _idContainer        = (_idContent + "-instituteprovince-combobox");
                _valueCountry       = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-institutecountry"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-institutecountry"),
                                        valueFalse: "0"
                                      });
                _widthInput         = 463;
                _heightInput        = 29;
            }
            
            if (_param["id"] == ("#" + this.idSectionUploadSubmitDocumentTranscriptInstituteAddUpdate.toLowerCase() + "-institute"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-institute", "");
                _cmd                = "getinstitute";
                _idCombobox         = (_idContent + "-institute");
                _idContainer        = (_idContent + "-institute-combobox");
                _valueProvince      = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-instituteprovince"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-instituteprovince"),
                                        valueFalse: "0"
                                      });
                _widthInput         = 463;
                _heightInput        = 29;
            }
          
            if (_param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-instituteprovince") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-instituteprovince"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-instituteprovince", "");
                _cmd                = "getudsprovince";
                _idCombobox         = (_idContent + "-instituteprovince");
                _idContainer        = (_idContent + "-instituteprovince-combobox");
                _valueCountry       = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-institutecountry"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-institutecountry"),
                                        valueFalse: "0"
                                      });
                _widthInput         = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput        = 27;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesAuditTranscriptApprovedSearch.toLowerCase() + "-institute") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportSaveAuditTranscriptApprovedSearch.toLowerCase() + "-institute"))
            {
                _idContent          = _param["id"].replace("#", "").replace("-institute", "");
                _cmd                = "getudsinstitute";
                _idCombobox         = (_idContent + "-institute");
                _idContainer        = (_idContent + "-institute-combobox");
                _valueProvince      = Util.getSelectionIsSelect({
                                        id: ("#" + _idContent + "-instituteprovince"),
                                        type: "select",
                                        valueTrue: Util.comboboxGetValue("#" + _idContent + "-instituteprovince"),
                                        valueFalse: "0"
                                      });
                _widthInput         = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput        = 27;
            }           
            
            _cmd                        = _cmd;
            _idCombobox                 = _idCombobox;
            _idContainer                = _idContainer;
            _valueParam["id"]           = _idCombobox;
            _valueParam["degreelevel"]  = _valueDegreeLevel;
            _valueParam["faculty"]      = _valueFaculty;
            _valueParam["country"]      = _valueCountry;
            _valueParam["province"]     = _valueProvince;
            _valueDefault               = _param["value"];
            _widthInput                 = _widthInput;
            _heightInput                = _heightInput;

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
    },

    //ฟังก์ชั่นสำหรับดึงชื่อเอกสารอัพโหลด
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //section   รับค่าชื่อหัวข้อที่ต้องการ
    getSubjectDocumentUpload: function (_param) {
        _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

        var _msgTH;
        var _msgEN;
        var _valueSubject = {};

        if (_param["section"] == Util.tut.subjectSectionProfilePicture)
        {
            _msgTH = "รูปภาพประจำตัว";
            _msgEN = "Profile Picture";
        }

        if (_param["section"] == Util.tut.subjectSectionIdentityCard)
        {
            _msgTH = "บัตรประจำตัวประชาชน";
            _msgEN = "Identity Card";
        }

        if (_param["section"] == Util.tut.subjectSectionTranscript)
        {
            _msgTH = "ระเบียนแสดงผลการเรียน";
            _msgEN = "Transcript";
        }

        if (_param["section"] == Util.tut.subjectSectionTranscriptFrontside)
        {
            _msgTH = "ระเบียนแสดงผลการเรียน ( ด้านหน้า ) ";
            _msgEN = "Transcript ( Frontside )";
        }

        if (_param["section"] == Util.tut.subjectSectionTranscriptBackside)
        {
            _msgTH = "ระเบียนแสดงผลการเรียน ( ด้านหลัง ) ";
            _msgEN = "Transcript ( Backside )";
        }

        _valueSubject["subjectth"]  = _msgTH;
        _valueSubject["subjecten"]  = _msgEN;

        return _valueSubject;
    },

    //ฟังก์ชั่นสำหรับแสดงสัญลักษณ์สถานะการอนุมัติเอกสารที่นักศึกษาอัพโหลด
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //status    รับค่าสถานะการอนุมัติเอกสาร
    getIconApprovalStatus: function (_param) {
        _param["status"] = (_param["status"] == undefined || _param["status"] == "" ? "S" : _param["status"]);

        var _icon;

        switch (_param["status"].toUpperCase())
        {
            case "S"    : { _icon = "uploaddocument-approvalstatus-s"; break; }
            case "W"    : { _icon = "uploaddocument-approvalstatus-w"; break; }
            case "Y"    : { _icon = "uploaddocument-approvalstatus-y"; break; }
            case "N"    : { _icon = "uploaddocument-approvalstatus-n"; break; }
            default     : { _icon = "uploaddocument-approvalstatus-s"; break; }            
        }

        return _icon;
    },

    //ฟังก์ชั่นสำหรับแสดงเอกสารที่นักศึกษาอัพโหลดตามหัวข้อ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้า
    //fileDir   รับค่าโฟล์เดอร์ที่เก็บเอกสาร
    //fileName  รับค่าชื่อเอกสาร
    getFrmViewDocument: function (_param) {
        _param["page"]      = (_param["page"] == undefined ? "" : _param["page"]);
        _param["fileDir"]   = (_param["fileDir"] == undefined ? "" : _param["fileDir"]);
        _param["fileName"]  = (_param["fileName"] == undefined ? "" : _param["fileName"]);

        var _width;
        var _height;

        Util.loadForm({
            index: "picture",
            name: _param["page"],
            dialog: true,
            data: (_param["fileDir"] + "/" + _param["fileName"])
        }, function (_result, _e) {
            if (_result.Content.length > 0 && _e != "close")
            {
                _width  = $(".dialogpicture-form .picture-content img").width();
                _height = $(".dialogpicture-form .picture-content img").height();

                $(".dialogpicture-form .picture-content").css({
                    "width": (_width + "px"),
                    "height": (_height + "px")
                });
            }
        });
    },

    //ฟังก์ชั่นสำหรับแสดงหน้าตัวอย่างเอกสาร
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param         รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page              รับค่าชื่อหน้า
    //idMain            รับค่าชื่อสวนหลัก
    //idPreview         รับค่่าชื่อส่วนแสดงตัวอย่าง    
    //data              รับค่าข้อมูลที่ต้องการส่ง
    //2. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
    getFrmPreviewDocument: function (_param, _callBackFunc) {
        _param["page"]      = (_param["page"] == undefined ? "" : _param["page"]);
        _param["idMain"]    = (_param["idMain"] == undefined ? "" : _param["idMain"]);
        _param["idPreview"] = (_param["idPreview"] == undefined ? "" : _param["idPreview"]);
        _param["data"]      = (_param["data"] == undefined ? "" : _param["data"]);

        var _this = this;
        var _idTitleBarTH = (_param["idMain"] + "-form .titlebar .th-label");
        var _idTitleBarEN = (_param["idMain"] + "-form .titlebar .en-label");
        var _documentUploadTH;
        var _documentUploadEN;
        var _valueSubject;

        if (_param["data"].length > 0)
        {
            $(".table-row").removeClass("active");
            $("#table-row-id-" + _param["data"]).addClass("active");
            
            this.resetPreviewDocument({
                idMain: _param["idMain"],
                idPreview: _param["idPreview"]
            });

            if ($("#" + _param["idPreview"] + "-personid-hidden").length > 0) $("#" + _param["idPreview"] + "-personid-hidden").val(_param["data"]);

            Util.loadForm({
                name: _param["page"],
                data: _param["data"],
                showPreloadingInline: true,
                idPreloadingInline: (_param["idPreview"] + "-form"),
                id: (_param["idPreview"] + "-form")
            }, function (_result) {
                if (_result.Content.length > 0)
                {
                    if ($("#link-" + _param["page"].toLowerCase()).length > 0)
                    {
                        _documentUploadTH = $("#link-" + _param["page"].toLowerCase() + " .menu-itemtext .th-label").html();
                        _documentUploadEN = $("#link-" + _param["page"].toLowerCase() + " .menu-itemtext .en-label").html();
                    }
                    else
                        {
                            if (_param["page"] == _this.pageOurServicesExportProfilePictureApprovedProfilePicturePreview ||
                                _param["page"] == _this.pageOurServicesExportStudentRecordsInformationForSmartCardProfilePicturePreview ||
                                _param["page"] == _this.pageOurServicesCopyProfilePictureApprovedtotheStoreProfilePicturePreview)                                
                                _valueSubject = _this.getSubjectDocumentUpload({
                                                    section: _this.subjectSectionProfilePicture
                                                });

                            if (_param["page"] == _this.pageOurServicesExportSaveAuditTranscriptApprovedTranscriptPreview)
                                _valueSubject = _this.getSubjectDocumentUpload({
                                                    section: _this.subjectSectionTranscript
                                                });

                            _documentUploadTH = _valueSubject["subjectth"];
                            _documentUploadEN = _valueSubject["subjecten"];
                        }

                    if (_param["page"] == _this.pageUploadSubmitDocumentProfilePictureIdentityCardPreview ||
                        _param["page"] == _this.pageUploadSubmitDocumentTranscriptPreview ||
                        _param["page"] == _this.pageApproveDocumentProfilePictureIdentityCardEdit ||
                        _param["page"] == _this.pageApproveDocumentTranscriptEdit ||
                        _param["page"] == _this.pageOurServicesDocumentStatusStudentLevel1ViewTableProfilePictureIdentityCardPreview ||
                        _param["page"] == _this.pageOurServicesDocumentStatusStudentLevel1ViewTableTranscriptPreview ||
                        _param["page"] == _this.pageOurServicesExportProfilePictureApprovedProfilePicturePreview ||
                        _param["page"] == _this.pageOurServicesExportStudentRecordsInformationForSmartCardProfilePicturePreview ||
                        _param["page"] == _this.pageOurServicesCopyProfilePictureApprovedtotheStoreProfilePicturePreview ||
                        _param["page"] == _this.pageOurServicesExportSaveAuditTranscriptApprovedTranscriptPreview)
                    {                   
                        if (_param["page"] == _this.pageUploadSubmitDocumentProfilePictureIdentityCardPreview ||
                            _param["page"] == _this.pageUploadSubmitDocumentTranscriptPreview ||
                            _param["page"] == _this.pageOurServicesDocumentStatusStudentLevel1ViewTableProfilePictureIdentityCardPreview ||
                            _param["page"] == _this.pageOurServicesDocumentStatusStudentLevel1ViewTableTranscriptPreview ||
                            _param["page"] == _this.pageOurServicesExportProfilePictureApprovedProfilePicturePreview ||
                            _param["page"] == _this.pageOurServicesExportStudentRecordsInformationForSmartCardProfilePicturePreview ||
                            _param["page"] == _this.pageOurServicesCopyProfilePictureApprovedtotheStoreProfilePicturePreview ||
                            _param["page"] == _this.pageOurServicesExportSaveAuditTranscriptApprovedTranscriptPreview)
                        {
                            _documentUploadTH = ("ดู" + _documentUploadTH);
                            _documentUploadEN = ("Preview " + _documentUploadEN);
                        }
                   
                        if (_param["page"] == _this.pageApproveDocumentProfilePictureIdentityCardEdit ||
                            _param["page"] == _this.pageApproveDocumentTranscriptEdit)
                        {
                            _documentUploadTH = ("ดูและอนุมัติ" + _documentUploadTH);
                            _documentUploadEN = ("Preview and Approve " + _documentUploadEN);
                        }
                    
                        $("#" + _idTitleBarTH).html(_documentUploadTH);
                        $("#" + _idTitleBarEN).html(_documentUploadEN);

                        if (_param["page"] == _this.pageUploadSubmitDocumentProfilePictureIdentityCardPreview)
                        {                        
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionProfilePicture,
                                page: _this.pageViewProfilePictureMain
                            });
                            Util.tut.tus.sectionPreview.resetMain({
                                section: _this.subjectSectionProfilePicture
                            });

                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionIdentityCard,
                                page: _this.pageViewIdentityCardMain
                            });
                            Util.tut.tus.sectionPreview.resetMain({
                                section: _this.subjectSectionIdentityCard
                            });
                        }
                    
                        if (_param["page"] == _this.pageUploadSubmitDocumentTranscriptPreview)
                        {                        
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionTranscriptFrontside,
                                page: _this.pageViewTranscriptFrontsideMain
                            });
                            Util.tut.tus.sectionPreview.resetMain({
                                section: _this.subjectSectionTranscriptFrontside
                            });

                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionTranscriptBackside,
                                page: _this.pageViewTranscriptBacksideMain
                            });
                            Util.tut.tus.sectionPreview.resetMain({
                                section: _this.subjectSectionTranscriptBackside
                            });
                        }

                        if (_param["page"] == _this.pageApproveDocumentProfilePictureIdentityCardEdit)
                        {
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionProfilePicture,
                                page: _this.pageViewProfilePictureMain
                            });
                            Util.tut.tap.sectionAddUpdate.sectionEdit.initMain({
                                section: _this.subjectSectionProfilePicture
                            });
                            Util.tut.tap.sectionAddUpdate.resetMain({
                                section: _this.subjectSectionProfilePicture
                            });

                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionIdentityCard,
                                page: _this.pageViewIdentityCardMain
                            });
                            Util.tut.tap.sectionAddUpdate.sectionEdit.initMain({
                                section: _this.subjectSectionIdentityCard
                            });
                            Util.tut.tap.sectionAddUpdate.resetMain({
                                section: _this.subjectSectionIdentityCard
                            });
                        }

                        if (_param["page"] == _this.pageApproveDocumentTranscriptEdit)
                        {                        
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionTranscriptFrontside,
                                page: _this.pageViewTranscriptFrontsideMain
                            });
                            Util.tut.tap.sectionAddUpdate.sectionEdit.initMain({
                                section: _this.subjectSectionTranscriptFrontside
                            });
                            Util.tut.tap.sectionAddUpdate.resetMain({
                                section: _this.subjectSectionTranscriptFrontside
                            });

                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionTranscriptBackside,
                                page: _this.pageViewTranscriptBacksideMain
                            });
                            Util.tut.tap.sectionAddUpdate.sectionEdit.initMain({
                                section: _this.subjectSectionTranscriptBackside
                            });
                            Util.tut.tap.sectionAddUpdate.resetMain({
                                section: _this.subjectSectionTranscriptBackside
                            });
                        }

                        if (_param["page"] == _this.pageOurServicesDocumentStatusStudentLevel1ViewTableProfilePictureIdentityCardPreview)
                        {                        
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionProfilePicture,
                                page: _this.pageViewProfilePictureMain
                            });                        
                            Util.tut.tos.documentstatusstudent.viewtable.sectionPreview.resetMain({
                                page: _this.pageOurServicesDocumentStatusStudentLevel1ViewTableMain,
                                section: _this.subjectSectionProfilePicture
                            });                        

                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionIdentityCard,
                                page: _this.pageViewIdentityCardMain
                            });
                            Util.tut.tos.documentstatusstudent.viewtable.sectionPreview.resetMain({
                                page: _this.pageOurServicesDocumentStatusStudentLevel1ViewTableMain,
                                section: _this.subjectSectionIdentityCard
                            });
                        }

                        if (_param["page"] == _this.pageOurServicesDocumentStatusStudentLevel1ViewTableTranscriptPreview)
                        {
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionTranscriptFrontside,
                                page: _this.pageViewTranscriptFrontsideMain
                            });                        
                            Util.tut.tos.documentstatusstudent.viewtable.sectionPreview.resetMain({
                                page: _this.pageOurServicesDocumentStatusStudentLevel1ViewTableMain,
                                section: _this.subjectSectionTranscriptFrontside
                            });
                        
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionTranscriptBackside,
                                page: _this.pageViewTranscriptBacksideMain
                            });
                            Util.tut.tos.documentstatusstudent.viewtable.sectionPreview.resetMain({
                                page: _this.pageOurServicesDocumentStatusStudentLevel1ViewTableMain,
                                section: _this.subjectSectionTranscriptBackside
                            });
                        }

                        if (_param["page"] == _this.pageOurServicesExportProfilePictureApprovedProfilePicturePreview)
                        {
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionProfilePicture,
                                page: _this.pageViewProfilePictureMain
                            });
                            Util.tut.tos.exportprofilepictureapproved.sectionPreview.resetMain({
                                section: _this.subjectSectionProfilePicture
                            });
                        }
                        
                        if (_param["page"] == _this.pageOurServicesExportStudentRecordsInformationForSmartCardProfilePicturePreview)
                        {
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionProfilePicture,
                                page: _this.pageViewProfilePictureMain
                            });
                            Util.tut.tos.exportstudentrecordsinformationforsmartcard.sectionPreview.resetMain({
                                section: _this.subjectSectionProfilePicture
                            });
                        }

                        if (_param["page"] == _this.pageOurServicesCopyProfilePictureApprovedtotheStoreProfilePicturePreview)
                        {
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionProfilePicture,
                                page: _this.pageViewProfilePictureMain
                            });
                            Util.tut.tos.copyprofilepictureapprovedtothestore.sectionPreview.resetMain({
                                section: _this.subjectSectionProfilePicture
                            });
                        }

                        if (_param["page"] == _this.pageOurServicesExportSaveAuditTranscriptApprovedTranscriptPreview)
                        {                        
                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionTranscriptFrontside,
                                page: _this.pageViewTranscriptFrontsideMain
                            });
                            Util.tut.tos.exportsaveaudittranscriptapproved.sectionPreview.resetMain({
                                section: _this.subjectSectionTranscriptFrontside
                            });

                            _this.initViewDocument({
                                id: _param["idPreview"],
                                section: _this.subjectSectionTranscriptBackside,
                                page: _this.pageViewTranscriptBacksideMain
                            });
                            Util.tut.tos.exportsaveaudittranscriptapproved.sectionPreview.resetMain({
                                section: _this.subjectSectionTranscriptBackside
                            });
                        }
                    }
                
                    $(".preview-transcriptinstitute .button-toggle a").click(function () {
                        var _objContent = $(".preview-transcriptinstitute .form-content");

                        if (_objContent.is(":visible"))
                            _objContent.hide();
                        else
                            _objContent.show();
                    });                        
                }
            });
        }
        else
            Util.dialogMessageError({
                content: "<div class='th-label'>กรุณาเลือกนักศึกษา</div><div class='en-label'>Please select student.</div>"
            });
    },

    //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการแสดงตัวอย่างเอกสาร
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้า
    //idMain    รับค่าชื่อสวนหลัก
    //idPreview รับค่่าชื่อส่วนแสดงตัวอย่าง
    initPreviewDocument: function (_param) {
        _param["idMain"]    = (_param["idMain"] == undefined ? "" : _param["idMain"]);
        _param["idPreview"] = (_param["idPreview"] == undefined ? "" : _param["idPreview"]);

        var _this = this;

        $(".menulist .link-click").click(function () {
            _this.getFrmPreviewDocument({
                page: $(this).attr("alt"),
                idMain: _param["idMain"],
                idPreview: _param["idPreview"],
                data: $("#" + _param["idPreview"] + "-personid-hidden").val()
            }, function () { });
        });

        $(".menulist .button-toggle a").click(function () {
            var _objMenu = $(".menulist .menulist-content");

            if (_objMenu.is(":visible"))
                _objMenu.hide();
            else
                _objMenu.show();
        });

        this.resetPreviewDocument({
            idMain: _param["idMain"],
            idPreview: _param["idPreview"]
        });
    },

    //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานให้กับการแสดงตัวอย่างเอกสาร
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //idMain    รับค่าชื่อสวนหลัก
    //idPreview รับค่่าชื่อส่วนแสดงตัวอย่าง    
    resetPreviewDocument: function (_param) {
        _param["idMain"]    = (_param["idMain"] == undefined ? "" : _param["idMain"]);
        _param["idPreview"] = (_param["idPreview"] == undefined ? "" : _param["idPreview"]);

        var _idTitleBarTH = (_param["idMain"] + "-form .titlebar .th-label:eq(0)");
        var _idTitleBarEN = (_param["idMain"] + "-form .titlebar .en-label:eq(0)");
        var _objMenu = $("#" + _param["idMain"] + "-form .menulist-content");
        
        Util.dialogMessageClose();

        if ($("#" + _param["idMain"] + "-form").length > 0 && $("#" + _param["idPreview"] + "-form").length > 0)
        {
            $("#" + _param["idPreview"] + "-personid-hidden").val("");
            $("#" + _idTitleBarTH).html("ดูเอกสาร");
            $("#" + _idTitleBarEN).html("Preview Document");
            $("#" + _param["idPreview"] + "-form").html("");

            if (_objMenu.length > 0) _objMenu.hide();
        }
    },

    //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการแสดงตัวอย่างเอกสาร
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //id        รับค่่าชื่อส่วนที่ต้องการแสดง
    //section   รับค่าชื่อหัวข้อที่ต้องการ    
    initViewDocument: function (_param) {
        _param["id"]        = (_param["id"] == undefined ? "" : _param["id"]);
        _param["section"]   = (_param["section"] == undefined ? "" : _param["section"]);
        _param["page"]      = (_param["page"] == undefined ? "" : _param["page"]);

        var _this = this;
        var _idContent = (_param["id"] + _param["section"].toLowerCase());
        var _hasClass;

        $("#" + _idContent + "-form .picture-content").hover(
            function () {
                _hasClass = ($(this).hasClass(_param["section"].toLowerCase() + "-content") ? true : _hasClass);

                if (_hasClass == true && $("#" + _idContent + "-form img").is(":visible")) $("#" + _idContent + "-form .picture-zoom").show();
            },
            function () {
                _hasClass = ($(this).hasClass(_param["section"].toLowerCase() + "-content") ? true : _hasClass);

                if (_hasClass == true && $("#" + _idContent + "-form img").is(":visible")) $("#" + _idContent + "-form .picture-zoom").hide();
            }
        );

        $("#" + _idContent + "-form .picture-zoom").click(function () {
            var _valueFileDir = $("#" + _idContent + "-filedir-hidden").val();
            var _valueFileName = $("#" + _idContent + "-filename-hidden").val();

            _this.getFrmViewDocument({
                page: _param["page"],
                fileDir: _valueFileDir,
                fileName: _valueFileName
            });
        });
    },

    //ฟังก์ชั่นสำหรับแสดงไดอะล็อคฟอร์มเมื่อมีการกดลิงค์
    getDialogFormOnClick: function () {
        var _this = this;
        var _page;

        $(".link-" + _this.subjectSectionMeaningofAdmissionType.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionMeaningofStudentStatus.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionMeaningOfSubmittedStatus.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionMeaningOfApprovalStatus.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionMeaningOfAuditedStatus.toLowerCase()).click(function () {
              if ($(this).hasClass("link-" + _this.subjectSectionMeaningofAdmissionType.toLowerCase()) == true)     _page = _this.pageMeaningofAdmissionTypeMain;
              if ($(this).hasClass("link-" + _this.subjectSectionMeaningofStudentStatus.toLowerCase()) == true)     _page = _this.pageMeaningOfStudentStatusMain;
              if ($(this).hasClass("link-" + _this.subjectSectionMeaningOfSubmittedStatus.toLowerCase()) == true)   _page = _this.pageMeaningOfSubmittedStatusMain;
              if ($(this).hasClass("link-" + _this.subjectSectionMeaningOfApprovalStatus.toLowerCase()) == true)    _page = _this.pageMeaningOfApprovalStatusMain;
              if ($(this).hasClass("link-" + _this.subjectSectionMeaningOfAuditedStatus.toLowerCase()) == true)     _page = _this.pageMeaningOfAuditedStatusMain;

              Util.loadForm({
                  index: 1,
                  name: _page,
                  dialog: true
              }, function () { });
          });
    },

    //ฟังก์ชั่นสำหรับตรวจสอบและไปหน้าอัพโหลดและส่งเอกสารของนักศึกษา
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //data      รับค่าข้อมูลที่ต้องการส่ง
    getUploadSubmitDocument: function (_param) {
        _param["data"] = (_param["data"] == undefined ? "" : _param["data"]);

        if (_param["data"].length > 0)
            Util.gotoPage({
                page: ("index.aspx?p=" + this.pageUploadSubmitDocumentAddUpdate + "&id=" + _param["data"])
            });
        else
            Util.dialogMessageError({
               content: "<div class='th-label'>กรุณาเลือกนักศึกษา</div><div class='en-label'>Please select student.</div>"
            });
    },
}