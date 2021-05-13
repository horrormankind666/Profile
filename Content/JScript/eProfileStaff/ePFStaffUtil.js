/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๔/๑๒/๒๕๕๗>
Modify date : <๑๒/๐๕/๒๕๖๔>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปของระบบ>
=============================================
*/

var ePFStaffUtil = {
    tse: null,
    tst: null,
    tmd: null,
    tsr: null,
    tos: null,
    tpd: null,
    parentWidth: 1008,
    pathProject: "eProfileStaff",
    urlHandler: "../../../Content/Handler/eProfileStaff/ePFStaffHandler.ashx",

    subjectSectionMeaningofAdmissionType: "MeaningOfAdmissionType",
    subjectSectionMeaningofStudentStatus: "MeaningOfStudentStatus",
    subjectSectionViewMessage: "ViewMessage",
    subjectSectionTopicsStudentRecordsStatusNotComplete: "TopicsStudentRecordsStatusNotComplete",
    subjectSectionStudentRecords: "StudentRecords",
    subjectSectionHelpFillInformationStudentRecords: "HelpFillInformationStudentRecords",
    subjectSectionSettingAccesstotheSystem: "SettingAccesstotheSystem",
    subjectSectionMasterDataTitlePrefix: "MasterDataTitlePrefix",
    subjectSectionMasterDataGender: "MasterDataGender",
    subjectSectionMasterDataNationalityRace: "MasterDataNationalityRace",
    subjectSectionMasterDataReligion: "MasterDataReligion",
    subjectSectionMasterDataBloodGroup: "MasterDataBloodGroup",
    subjectSectionMasterDataMaritalStatus: "MasterDataMaritalStatus",
    subjectSectionMasterDataFamilyRelationships: "MasterDataFamilyRelationships",
    subjectSectionMasterDataAgency: "MasterDataAgency",
    subjectSectionMasterDataEducationalLevel: "MasterDataEducationalLevel",
    subjectSectionMasterDataEducationalBackground: "MasterDataEducationalBackground",
    subjectSectionMasterDataEducationalMajor: "MasterDataEducationalMajor",
    subjectSectionMasterDataAdmissionType: "MasterDataAdmissionType",
    subjectSectionMasterDataStudentStatus: "MasterDataStudentStatus",
    subjectSectionMasterDataCountry: "MasterDataCountry",
    subjectSectionMasterDataProvince: "MasterDataProvince",
    subjectSectionMasterDataDistrict: "MasterDataDistrict",
    subjectSectionMasterDataSubdistrict: "MasterDataSubdistrict",
    subjectSectionMasterDataInstitute: "MasterDataInstitute",
    subjectSectionMasterDataDiseases: "MasterDataDiseases",
    subjectSectionMasterDataHealthImpairments: "MasterDataHealthImpairments",
    subjectSectionAdministrationStudentRecords: "AdministrationStudentRecords",
    subjectSectionAdministrationStudentRecordsStudentRecords: "AdministrationStudentRecordsStudentRecords",
    subjectSectionAdministrationStudentRecordsPersonal: "AdministrationStudentRecordsPersonal",
    subjectSectionAdministrationStudentRecordsAddress: "AdministrationStudentRecordsAddress",
    subjectSectionAdministrationStudentRecordsAddressPermanent: "AdministrationStudentRecordsAddressPermanent",
    subjectSectionAdministrationStudentRecordsAddressCurrent: "AdministrationStudentRecordsAddressCurrent",
    subjectSectionAdministrationStudentRecordsEducation: "AdministrationStudentRecordsEducation",
    subjectSectionAdministrationStudentRecordsEducationPrimarySchool: "AdministrationStudentRecordsEducationPrimarySchool",
    subjectSectionAdministrationStudentRecordsEducationJuniorHighSchool: "AdministrationStudentRecordsEducationJuniorHighSchool",
    subjectSectionAdministrationStudentRecordsEducationHighSchool: "AdministrationStudentRecordsEducationHighSchool",
    subjectSectionAdministrationStudentRecordsEducationUniversity: "AdministrationStudentRecordsEducationUniversity",
    subjectSectionAdministrationStudentRecordsEducationAdmissionScores: "AdministrationStudentRecordsEducationAdmissionScores",
    subjectSectionAdministrationStudentRecordsTalent: "AdministrationStudentRecordsTalent",
    subjectSectionAdministrationStudentRecordsHealthy: "AdministrationStudentRecordsHealthy",
    subjectSectionAdministrationStudentRecordsBodyMassIndex: "AdministrationStudentRecordsBodyMassIndex",
    subjectSectionAdministrationStudentRecordsTravelAbroad: "AdministrationStudentRecordsTravelAbroad",
    subjectSectionAdministrationStudentRecordsWork: "AdministrationStudentRecordsWork",
    subjectSectionAdministrationStudentRecordsFinancial: "AdministrationStudentRecordsFinancial",
    subjectSectionAdministrationStudentRecordsFamily: "AdministrationStudentRecordsFamily",
    subjectSectionAdministrationStudentRecordsFamilyPersonal: "AdministrationStudentRecordsFamilyPersonal",
    subjectSectionAdministrationStudentRecordsFamilyAddressPermanent: "AdministrationStudentRecordsFamilyAddressPermanent",
    subjectSectionAdministrationStudentRecordsFamilyAddressCurrent: "AdministrationStudentRecordsFamilyAddressCurrent",
    subjectSectionAdministrationStudentRecordsFamilyWork: "AdministrationStudentRecordsFamilyWork",
    subjectSectionOurServices: "OurServices",
    subjectSectionOurServicesExportStudentRecordsInformation: "OurServicesExportStudentRecordsInformation",
    subjectSectionOurServicesUpdateStudentMedicalScholarsProgram: "OurServicesUpdateStudentMedicalScholarsProgram",
    subjectSectionSummaryNumberOfStudentLevel1ViewTable: "SummaryNumberOfStudentLevel1ViewTable",
    subjectSectionSummaryNumberOfStudentLevel2ViewTable: "SummaryNumberOfStudentLevel2ViewTable",
    subjectSectionOurServicesSummaryNumberOfStudent: "OurServicesSummaryNumberOfStudent",
    subjectSectionOurServicesTransactionLogStudentRecords: "OurServicesTransactionLogStudentRecords",
    subjectFamilyFather: "Father",
    subjectFamilyMother: "Mother",
    subjectFamilyParent: "Parent",
    subjectSectionUpdate: "Update",
    subjectSectionExport: "Export",

    idSectionSettingAccesstotheSystemEdit: "Edit-SettingAccesstotheSystem",
    idSectionMasterDataTitlePrefixMain: "Main-MasterDataTitlePrefix",
    idSectionMasterDataTitlePrefixSearch: "Search-MasterDataTitlePrefix",
    idSectionMasterDataGenderMain: "Main-MasterDataGender",
    idSectionMasterDataGenderSearch: "Search-MasterDataGender",
    idSectionMasterDataNationalityRaceMain: "Main-MasterDataNationalityRace",
    idSectionMasterDataNationalityRaceSearch: "Search-MasterDataNationalityRace",
    idSectionMasterDataReligionMain: "Main-MasterDataReligion",
    idSectionMasterDataReligionSearch: "Search-MasterDataReligion",
    idSectionMasterDataBloodGroupMain: "Main-MasterDataBloodGroup",
    idSectionMasterDataBloodGroupSearch: "Search-MasterDataBloodGroup",
    idSectionMasterDataMaritalStatusMain: "Main-MasterDataMaritalStatus",
    idSectionMasterDataMaritalStatusSearch: "Search-MasterDataMaritalStatus",
    idSectionMasterDataFamilyRelationshipsMain: "Main-MasterDataFamilyRelationships",
    idSectionMasterDataFamilyRelationshipsSearch: "Search-MasterDataFamilyRelationships",
    idSectionMasterDataAgencyMain: "Main-MasterDataAgency",
    idSectionMasterDataAgencySearch: "Search-MasterDataAgency",
    idSectionMasterDataEducationalLevelMain: "Main-MasterDataEducationalLevel",
    idSectionMasterDataEducationalLevelSearch: "Search-MasterDataEducationalLevel",
    idSectionMasterDataEducationalBackgroundMain: "Main-MasterDataEducationalBackground",
    idSectionMasterDataEducationalBackgroundSearch: "Search-MasterDataEducationalBackground",
    idSectionMasterDataEducationalMajorMain: "Main-MasterDataEducationalMajor",
    idSectionMasterDataEducationalMajorSearch: "Search-MasterDataEducationalMajor",
    idSectionMasterDataAdmissionTypeMain: "Main-MasterDataAdmissionType",
    idSectionMasterDataAdmissionTypeSearch: "Search-MasterDataAdmissionType",
    idSectionMasterDataStudentStatusMain: "Main-MasterDataStudentStatus",
    idSectionMasterDataStudentStatusSearch: "Search-MasterDataStudentStatus",
    idSectionMasterDataCountryMain: "Main-MasterDataCountry",
    idSectionMasterDataCountrySearch: "Search-MasterDataCountry",
    idSectionMasterDataProvinceMain: "Main-MasterDataProvince",
    idSectionMasterDataProvinceSearch: "Search-MasterDataProvince",
    idSectionMasterDataDistrictMain: "Main-MasterDataDistrict",
    idSectionMasterDataDistrictSearch: "Search-MasterDataDistrict",
    idSectionMasterDataSubdistrictMain: "Main-MasterDataSubdistrict",
    idSectionMasterDataSubdistrictSearch: "Search-MasterDataSubdistrict",
    idSectionMasterDataInstituteMain: "Main-MasterDataInstitute",
    idSectionMasterDataInstituteSearch: "Search-MasterDataInstitute",
    idSectionMasterDataInstituteNew: "New-MasterDataInstitute",
    idSectionMasterDataInstituteEdit: "Edit-MasterDataInstitute",
    idSectionMasterDataDiseasesMain: "Main-MasterDataDiseases",
    idSectionMasterDataDiseasesSearch: "Search-MasterDataDiseases",
    idSectionMasterDataHealthImpairmentsMain: "Main-MasterDataHealthImpairments",
    idSectionMasterDataHealthImpairmentssSearch: "Search-MasterDataHealthImpairments",
    idSectionAdministrationStudentRecordsMain: "Main-AdministrationStudentRecords",
    idSectionAdministrationStudentRecordsSearch: "Search-AdministrationStudentRecords",
    idSectionAdministrationStudentRecordsAddUpdate: "AddUpdate-AdministrationStudentRecords",
    idSectionAdministrationStudentRecordsStudentRecordsAddUpdate: "AddUpdate-AdministrationStudentRecordsStudentRecords",
    idSectionAdministrationStudentRecordsPersonalAddUpdate: "AddUpdate-AdministrationStudentRecordsPersonal",
    idSectionAdministrationStudentRecordsAddressAddUpdate: "AddUpdate-AdministrationStudentRecordsAddress",
    idSectionAdministrationStudentRecordsAddressPermanentAddUpdate: "AddUpdate-AdministrationStudentRecordsAddressPermanent",
    idSectionAdministrationStudentRecordsAddressCurrentAddUpdate: "AddUpdate-AdministrationStudentRecordsAddressCurrent",
    idSectionAdministrationStudentRecordsEducationAddUpdate: "AddUpdate-AdministrationStudentRecordsEducation",
    idSectionAdministrationStudentRecordsEducationPrimarySchoolAddUpdate: "AddUpdate-AdministrationStudentRecordsEducationPrimarySchool",
    idSectionAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate: "AddUpdate-AdministrationStudentRecordsEducationJuniorHighSchool",
    idSectionAdministrationStudentRecordsEducationHighSchoolAddUpdate: "AddUpdate-AdministrationStudentRecordsEducationHighSchool",
    idSectionAdministrationStudentRecordsEducationUniversityAddUpdate: "AddUpdate-AdministrationStudentRecordsEducationUniversity",
    idSectionAdministrationStudentRecordsEducationAdmissionScoresAddUpdate: "AddUpdate-AdministrationStudentRecordsEducationAdmissionScores",
    idSectionAdministrationStudentRecordsTalentAddUpdate: "AddUpdate-AdministrationStudentRecordsTalent",
    idSectionAdministrationStudentRecordsHealthyAddUpdate: "AddUpdate-AdministrationStudentRecordsHealthy",
    idSectionAdministrationStudentRecordsWorkAddUpdate: "AddUpdate-AdministrationStudentRecordsWork",
    idSectionAdministrationStudentRecordsFinancialAddUpdate: "AddUpdate-AdministrationStudentRecordsFinancial",
    idSectionAdministrationStudentRecordsFamilyAddUpdate: "AddUpdate-AdministrationStudentRecordsFamily",
    idSectionAdministrationStudentRecordsFamilyPersonalAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyPersonal",
    idSectionAdministrationStudentRecordsFamilyAddressPermanentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyAddressPermanent",
    idSectionAdministrationStudentRecordsFamilyAddressCurrentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyAddressCurrent",
    idSectionAdministrationStudentRecordsFamilyWorkAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyWork",
    idSectionAdministrationStudentRecordsFamilyFatherAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyFather",
    idSectionAdministrationStudentRecordsFamilyFatherPersonalAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyFatherPersonal",
    idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyFatherAddressPermanent",
    idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyFatherAddressCurrent",
    idSectionAdministrationStudentRecordsFamilyFatherWorkAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyFatherWork",
    idSectionAdministrationStudentRecordsFamilyMotherAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyMother",
    idSectionAdministrationStudentRecordsFamilyMotherPersonalAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyMotherPersonal",
    idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyMotherAddressPermanent",
    idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyMotherAddressCurrent",
    idSectionAdministrationStudentRecordsFamilyMotherWorkAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyMotherWork",    
    idSectionAdministrationStudentRecordsFamilyParentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyParent",
    idSectionAdministrationStudentRecordsFamilyParentPersonalAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyParentPersonal",
    idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyParentAddressPermanent",
    idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyParentAddressCurrent",
    idSectionAdministrationStudentRecordsFamilyParentWorkAddUpdate: "AddUpdate-AdministrationStudentRecordsFamilyParentWork",
    idSectionAdministrationStudentRecordsUpdateFacultyProgramProgress: "Progress-AdministrationStudentRecordsUpdateFacultyProgram",
    idSectionAdministrationStudentRecordsUpdateFacultyProgramPreview: "Preview-AdministrationStudentRecordsUpdateFacultyProgram",
    idSectionAdministrationStudentRecordsUpdateClassYearProgress: "Progress-AdministrationStudentRecordsUpdateClassYear",
    idSectionAdministrationStudentRecordsUpdateClassYearPreview: "Preview-AdministrationStudentRecordsUpdateClassYear",
    idSectionAdministrationStudentRecordsUpdateEntranceTypeProgress: "Progress-AdministrationStudentRecordsUpdateEntranceType",
    idSectionAdministrationStudentRecordsUpdateEntranceTypePreview: "Preview-AdministrationStudentRecordsUpdateEntranceType",
    idSectionAdministrationStudentRecordsUpdateStudentStatusProgress: "Progress-AdministrationStudentRecordsUpdateStudentStatus",
    idSectionAdministrationStudentRecordsUpdateStudentStatusPreview: "Preview-AdministrationStudentRecordsUpdateStudentStatus",
    idSectionAdministrationStudentRecordsUpdateAdmissionDateProgress: "Progress-AdministrationStudentRecordsUpdateAdmissionDate",
    idSectionAdministrationStudentRecordsUpdateAdmissionDatePreview: "Preview-AdministrationStudentRecordsUpdateAdmissionDate",
    idSectionAdministrationStudentRecordsUpdateDatatoOldDBProgress: "Progress-AdministrationStudentRecordsUpdateDatatoOldDB",
    idSectionOurServicesExportStudentRecordsInformationMain: "Main-OurServicesExportStudentRecordsInformation",
    idSectionOurServicesExportStudentRecordsInformationSearch: "Search-OurServicesExportStudentRecordsInformation",
    idSectionOurServicesExportStudentRecordsInformationProgress: "Progress-OurServicesExportStudentRecordsInformation",
    idSectionOurServicesUpdateStudentMedicalScholarsProgramMain: "Main-OurServicesUpdateStudentMedicalScholarsProgram",
    idSectionOurServicesUpdateStudentMedicalScholarsProgramSearch: "Search-OurServicesUpdateStudentMedicalScholarsProgram",
    idSectionOurServicesUpdateStudentMedicalScholarsProgramProgress: "Progress-OurServicesUpdateStudentMedicalScholarsProgram",
    idSectionOurServicesUpdateStudentMedicalScholarsProgramPreview: "Preview-OurServicesUpdateStudentMedicalScholarsProgram",
    idSectionOurServicesSummaryNumberOfStudentMain: "Main-OurServicesSummaryNumberOfStudent",
    idSectionOurServicesSummaryNumberOfStudentSearch: "Search-OurServicesSummaryNumberOfStudent",
    idSectionOurServicesSummaryNumberOfStudentViewChartMain: "Main-OurServicesSummaryNumberOfStudentViewChart",
    idSectionOurServicesSummaryNumberOfStudentViewTableMain: "Main-OurServicesSummaryNumberOfStudentViewTable",
    idSectionOurServicesSummaryNumberOfStudentLevel1ViewTableMain: "Main-OurServicesSummaryNumberOfStudentLevel1ViewTable",
    idSectionOurServicesSummaryNumberOfStudentLevel1ViewTableProgress: "Progress-OurServicesSummaryNumberOfStudentLevel1ViewTable",
    idSectionOurServicesSummaryNumberOfStudentLevel2ViewTableMain: "Main-OurServicesSummaryNumberOfStudentLevel2ViewTable",
    idSectionOurServicesSummaryNumberOfStudentLevel2ViewTableProgress: "Progress-OurServicesSummaryNumberOfStudentLevel2ViewTable",
    idSectionOurServicesTransactionLogStudentRecordsMain: "Main-OurServicesTransactionLogStudentRecords",
    idSectionOurServicesTransactionLogStudentRecordsSearch: "Search-OurServicesTransactionLogStudentRecords",
    idSectionOurServicesTransactionLogStudentRecordsView: "View-OurServicesTransactionLogStudentRecords",

    pageMain: "Main",
    pageMeaningofAdmissionTypeMain: "MeaningOfAdmissionTypeMain",
    pageMeaningOfStudentStatusMain: "MeaningOfStudentStatusMain",
    pageViewMessageMain: "ViewMessageMain",
    pageTopicsStudentRecordsStatusNotCompleteMain: "TopicsStudentRecordsStatusNotCompleteMain",
    pageStudentRecordsStudentCVMain: "StudentRecordsStudentCVMain",
    pageSettingAccesstotheSystemEdit: "SettingAccesstotheSystemEdit",
    pageHelpFillInformationStudentRecordsMain: "HelpFillInformationStudentRecordsMain",
    pageMasterDataTitlePrefixMain: "MasterDataTitlePrefixMain",
    pageMasterDataGenderMain: "MasterDataGenderMain",
    pageMasterDataNationalityRaceMain: "MasterDataNationalityRaceMain",
    pageMasterDataReligionMain: "MasterDataReligionMain",
    pageMasterDataBloodGroupMain: "MasterDataBloodGroupMain",
    pageMasterDataMaritalStatusMain: "MasterDataMaritalStatusMain",
    pageMasterDataFamilyRelationshipsMain: "MasterDataFamilyRelationshipsMain",
    pageMasterDataAgencyMain: "MasterDataAgencyMain",
    pageMasterDataEducationalLevelMain: "MasterDataEducationalLevelMain",
    pageMasterDataEducationalBackgroundMain: "MasterDataEducationalBackgroundMain",
    pageMasterDataEducationalMajorMain: "MasterDataEducationalMajorMain",
    pageMasterDataAdmissionTypeMain: "MasterDataAdmissionTypeMain",
    pageMasterDataStudentStatusMain: "MasterDataStudentStatusMain",
    pageMasterDataCountryMain: "MasterDataCountryMain",
    pageMasterDataProvinceMain: "MasterDataProvinceMain",
    pageMasterDataDistrictMain: "MasterDataDistrictMain",
    pageMasterDataSubdistrictMain: "MasterDataSubdistrictMain",
    pageMasterDataInstituteMain: "MasterDataInstituteMain",
    pageMasterDataInstituteNew: "MasterDataInstituteNew",
    pageMasterDataInstituteEdit: "MasterDataInstituteEdit",
    pageMasterDataDiseasesMain: "MasterDataDiseasesMain",
    pageMasterDataHealthImpairmentsMain: "MasterDataHealthImpairmentsMain",
    pageAdministrationStudentRecordsMain: "AdministrationStudentRecordsMain",
    pageAdministrationStudentRecordsAddUpdate: "AdministrationStudentRecordsAddUpdate",    
    pageAdministrationStudentRecordsStudentRecordsAddUpdate: "AdministrationStudentRecordsStudentRecordsAddUpdate",
    pageAdministrationStudentRecordsPersonalAddUpdate: "AdministrationStudentRecordsPersonalAddUpdate",
    pageAdministrationStudentRecordsAddressAddUpdate: "AdministrationStudentRecordsAddressAddUpdate",
    pageAdministrationStudentRecordsAddressPermanentAddUpdate: "AdministrationStudentRecordsAddressPermanentAddUpdate",
    pageAdministrationStudentRecordsAddressCurrentAddUpdate: "AdministrationStudentRecordsAddressCurrentAddUpdate",
    pageAdministrationStudentRecordsEducationAddUpdate: "AdministrationStudentRecordsEducationAddUpdate",
    pageAdministrationStudentRecordsEducationPrimarySchoolAddUpdate: "AdministrationStudentRecordsEducationPrimarySchoolAddUpdate",
    pageAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate: "AdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate",
    pageAdministrationStudentRecordsEducationHighSchoolAddUpdate: "AdministrationStudentRecordsEducationHighSchoolAddUpdate",
    pageAdministrationStudentRecordsEducationUniversityAddUpdate: "AdministrationStudentRecordsEducationUniversityAddUpdate",
    pageAdministrationStudentRecordsEducationAdmissionScoresAddUpdate: "AdministrationStudentRecordsEducationAdmissionScoresAddUpdate",
    pageAdministrationStudentRecordsTalentAddUpdate: "AdministrationStudentRecordsTalentAddUpdate",
    pageAdministrationStudentRecordsHealthyAddUpdate: "AdministrationStudentRecordsHealthyAddUpdate",
    pageAdministrationStudentRecordsWorkAddUpdate: "AdministrationStudentRecordsWorkAddUpdate",
    pageAdministrationStudentRecordsFinancialAddUpdate: "AdministrationStudentRecordsFinancialAddUpdate",
    pageAdministrationStudentRecordsFamilyAddUpdate: "AdministrationStudentRecordsFamilyAddUpdate",
    pageAdministrationStudentRecordsFamilyFatherAddUpdate: "AdministrationStudentRecordsFamilyFatherAddUpdate",
    pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate: "AdministrationStudentRecordsFamilyFatherPersonalAddUpdate",
    pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate: "AdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate",
    pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate: "AdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate",
    pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate: "AdministrationStudentRecordsFamilyFatherWorkAddUpdate",
    pageAdministrationStudentRecordsFamilyMotherAddUpdate: "AdministrationStudentRecordsFamilyMotherAddUpdate",
    pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate: "AdministrationStudentRecordsFamilyMotherPersonalAddUpdate",
    pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate: "AdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate",
    pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate: "AdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate",
    pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate: "AdministrationStudentRecordsFamilyMotherWorkAddUpdate",
    pageAdministrationStudentRecordsFamilyParentAddUpdate: "AdministrationStudentRecordsFamilyParentAddUpdate",
    pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate: "AdministrationStudentRecordsFamilyParentPersonalAddUpdate",
    pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate: "AdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate",
    pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate: "AdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate",
    pageAdministrationStudentRecordsFamilyParentWorkAddUpdate: "AdministrationStudentRecordsFamilyParentWorkAddUpdate",
    pageAdministrationStudentRecordsUpdateFacultyProgramProgress: "AdministrationStudentRecordsUpdateFacultyProgramProgress",
    pageAdministrationStudentRecordsUpdateFacultyProgramPreview: "AdministrationStudentRecordsUpdateFacultyProgramPreview",
    pageAdministrationStudentRecordsUpdateClassYearProgress: "AdministrationStudentRecordsUpdateClassYearProgress",
    pageAdministrationStudentRecordsUpdateClassYearPreview: "AdministrationStudentRecordsUpdateClassYearPreview",
    pageAdministrationStudentRecordsUpdateEntranceTypeProgress: "AdministrationStudentRecordsUpdateEntranceTypeProgress",
    pageAdministrationStudentRecordsUpdateEntranceTypePreview: "AdministrationStudentRecordsUpdateEntranceTypePreview",
    pageAdministrationStudentRecordsUpdateStudentStatusProgress: "AdministrationStudentRecordsUpdateStudentStatusProgress",
    pageAdministrationStudentRecordsUpdateStudentStatusPreview: "AdministrationStudentRecordsUpdateStudentStatusPreview",
    pageAdministrationStudentRecordsUpdateAdmissionDateProgress: "AdministrationStudentRecordsUpdateAdmissionDateProgress",
    pageAdministrationStudentRecordsUpdateAdmissionDatePreview: "AdministrationStudentRecordsUpdateAdmissionDatePreview",
    pageAdministrationStudentRecordsUpdateDatatoOldDBProgress: "AdministrationStudentRecordsUpdateDatatoOldDBProgress",
    pageOurServicesExportStudentRecordsInformationMain: "OurServicesExportStudentRecordsInformationMain",
    pageOurServicesExportStudentRecordsInformationProgress: "OurServicesExportStudentRecordsInformationProgress",
    pageOurServicesUpdateStudentMedicalScholarsProgramMain: "OurServicesUpdateStudentMedicalScholarsProgramMain",
    pageOurServicesUpdateStudentMedicalScholarsProgramProgress: "OurServicesUpdateStudentMedicalScholarsProgramProgress",
    pageOurServicesUpdateStudentMedicalScholarsProgramPreview: "OurServicesUpdateStudentMedicalScholarsProgramPreview",
    pageOurServicesSummaryNumberOfStudentMain: "OurServicesSummaryNumberOfStudentMain",
    pageOurServicesSummaryNumberOfStudentViewChartMain: "OurServicesSummaryNumberOfStudentViewChartMain",
    pageOurServicesSummaryNumberOfStudentViewTableMain: "OurServicesSummaryNumberOfStudentViewTableMain",
    pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain: "OurServicesSummaryNumberOfStudentLevel1ViewTableMain",
    pageOurServicesSummaryNumberOfStudentLevel1ViewTableProgress: "OurServicesSummaryNumberOfStudentLevel1ViewTableProgress",
    pageOurServicesSummaryNumberOfStudentLevel2ViewTableMain: "OurServicesSummaryNumberOfStudentLevel2ViewTableMain",
    pageOurServicesSummaryNumberOfStudentLevel2ViewTableProgress: "OurServicesSummaryNumberOfStudentLevel2ViewTableProgress",
    pageOurServicesTransactionLogStudentRecordsMain: "OurServicesTransactionLogStudentRecordsMain",
    pageOurServicesTransactionLogStudentRecordsView: "OurServicesTransactionLogStudentRecordsView",
    
    //ฟังก์ชั่นสำหรับกำหนดให้ทำงานตามเหตุการณ์ต่าง ๆ ที่เกิดขึ้นบน Menu Bar
    initMenuBar: function () {
        var _this = this;

        $(function () {
            $(".menubar .link-click").click(function () {
                var _idLink = $(this).attr("id");

                Util.dialogMessageClose();

                if (_idLink == ("link-" + _this.subjectSectionSettingAccesstotheSystem.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageSettingAccesstotheSystemEdit)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataTitlePrefix.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataTitlePrefixMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataGender.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataGenderMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataNationalityRace.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataNationalityRaceMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataReligion.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataReligionMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataBloodGroup.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataBloodGroupMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataMaritalStatus.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataMaritalStatusMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataFamilyRelationships.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataFamilyRelationshipsMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataAgency.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataAgencyMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataEducationalLevel.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataEducationalLevelMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataEducationalBackground.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataEducationalBackgroundMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataEducationalMajor.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataEducationalMajorMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataAdmissionType.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataAdmissionTypeMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataStudentStatus.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataStudentStatusMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataCountry.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataCountryMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataProvince.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataProvinceMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataDistrict.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataDistrictMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataSubdistrict.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataSubdistrictMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataInstitute.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataInstituteMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataDiseases.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataDiseasesMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionMasterDataHealthImpairments.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataHealthImpairmentsMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionAdministrationStudentRecords.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageAdministrationStudentRecordsMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionHelpFillInformationStudentRecords.toLowerCase()))
                    Util.loadForm({
                        index: 1, name: _this.pageHelpFillInformationStudentRecordsMain, dialog: true
                    }, function () {
                    });

                if (_idLink == ("link-" + _this.subjectSectionOurServicesExportStudentRecordsInformation.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageOurServicesExportStudentRecordsInformationMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionOurServicesUpdateStudentMedicalScholarsProgram.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageOurServicesUpdateStudentMedicalScholarsProgramMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionOurServicesSummaryNumberOfStudent.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageOurServicesSummaryNumberOfStudentMain)
                    });

                if (_idLink == ("link-" + _this.subjectSectionOurServicesTransactionLogStudentRecords.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageOurServicesTransactionLogStudentRecordsMain)
                    });

                if (_idLink == "link-signout")
                    Util.confirmeSignOut();
            });
        });
    },
    initInfoBar: function () {
        var _this = this;
        var _page;

        $(function () {
            $(".infobar .link-click").click(function () {
                var _idLink = $(this).attr("id");

                Util.dialogMessageClose();
                
                if ($("#page").html() == _this.pageAdministrationStudentRecordsAddUpdate)
                    _page = Util.getPageActive({
                        id: (_this.idSectionAdministrationStudentRecordsAddUpdate.toLowerCase() + "-content")
                    });

                if (_idLink == ("save-" + _this.pageSettingAccesstotheSystemEdit.toLowerCase()))
                    Util.tut.tst.confirmSave({ page: _this.pageSettingAccesstotheSystemEdit });

                if (_idLink == ("undo-" + _this.pageSettingAccesstotheSystemEdit.toLowerCase()))
                    Util.tut.tst.accesstothesystem.sectionAddUpdate.resetMain();

                if (_idLink == ("search-" + _this.pageMasterDataTitlePrefixMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataGenderMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataNationalityRaceMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataReligionMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataBloodGroupMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataMaritalStatusMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataFamilyRelationshipsMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataAgencyMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataEducationalLevelMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataEducationalBackgroundMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataEducationalMajorMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataAdmissionTypeMain.toLowerCase()))
                    Util.setSearchShow();
                    
                if (_idLink == ("search-" + _this.pageMasterDataStudentStatusMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataCountryMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataProvinceMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataDistrictMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataSubdistrictMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("new-" + _this.pageMasterDataInstituteMain.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataInstituteNew)
                    });

                if (_idLink == ("search-" + _this.pageMasterDataInstituteMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("save-" + _this.pageMasterDataInstituteNew.toLowerCase()))
                    Util.tut.tmd.confirmSave({
                        page: _this.pageMasterDataInstituteNew
                    });

                if (_idLink == ("undo-" + _this.pageMasterDataInstituteNew.toLowerCase()))
                    Util.tut.tmd.institute.sectionAddUpdate.resetMain();

                if (_idLink == ("close-" + _this.pageMasterDataInstituteNew.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataInstituteMain)
                    });

                if (_idLink == ("save-" + _this.pageMasterDataInstituteEdit.toLowerCase()))
                    Util.tut.tmd.confirmSave({
                        page: _this.pageMasterDataInstituteEdit
                    });

                if (_idLink == ("undo-" + _this.pageMasterDataInstituteEdit.toLowerCase()))
                    Util.tut.tmd.institute.sectionAddUpdate.resetMain();

                if (_idLink == ("close-" + _this.pageMasterDataInstituteEdit.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageMasterDataInstituteMain)
                    });

                if (_idLink == ("search-" + _this.pageMasterDataDiseasesMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageMasterDataHealthImpairmentsMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageAdministrationStudentRecordsMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("home-" + _this.pageAdministrationStudentRecordsAddUpdate.toLowerCase()))
                    Util.getPage();

                if (_idLink == ("save-" + _this.pageAdministrationStudentRecordsAddUpdate.toLowerCase()))
                    Util.tut.tsr.sectionAddUpdate.confirmSave({
                        page: _page
                    });

                if (_idLink == ("undo-" + _this.pageAdministrationStudentRecordsAddUpdate.toLowerCase()))
                    Util.tut.tsr.sectionAddUpdate.resetMainSection({
                        page: _page
                    });

                if (_idLink == ("profile-" + _this.pageAdministrationStudentRecordsAddUpdate.toLowerCase()))
                    Util.getStudentCV({
                        data: $("#" + Util.tut.tsr.sectionAddUpdate.studentrecords.idSectionAddUpdate + "-personid-hidden").val()
                    });

                if (_idLink == ("close-" + _this.pageAdministrationStudentRecordsAddUpdate.toLowerCase()))
                    Util.gotoPage({
                        page: ("index.aspx?p=" + _this.pageAdministrationStudentRecordsMain)
                    });

                if (_idLink == ("search-" + _this.pageOurServicesExportStudentRecordsInformationMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageOurServicesUpdateStudentMedicalScholarsProgramMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageOurServicesSummaryNumberOfStudentMain.toLowerCase()))
                    Util.setSearchShow();

                if (_idLink == ("search-" + _this.pageOurServicesTransactionLogStudentRecordsMain.toLowerCase()))
                    Util.setSearchShow();
            });
        });
    },
    getErrorMsg: function (_param) {
        _param["signinYN"] = (_param["signinYN"] == undefined || _param["signinYN"] == "" ? "N" : _param["signinYN"]);
        _param["pageError"] = (_param["pageError"] == undefined || _param["pageError"] == "" ? 0 : _param["pageError"]);
        _param["cookieError"] = (_param["cookieError"] == undefined || _param["cookieError"] == "" ? 0 : _param["cookieError"]);
        _param["userError"] = (_param["userError"] == undefined || _param["userError"] == "" ? 0 : _param["userError"]);
        _param["saveError"] = (_param["saveError"] == undefined || _param["saveError"] == "" ? 0 : _param["saveError"]);

        var _error = false;
        var _msgTH;
        var _msgEN;
        var _status = (_param["signinYN"] + _param["cookieError"] + _param["userError"] + _param["saveError"]);

        if (_error == false && _param["pageError"] == 1) {
            _error = true;
            _msgTH = "ไม่พบหน้านี้";
            _msgEN = "Page not found.";
        }

        if (_error == false && _param["pageError"] == 2) {
            _error = true;
            _msgTH = "ไม่พบข้อมูล";
            _msgEN = "Data not found.";
        }

        if (_error == false && _status == "Y100") {
            _error = true;
            _msgTH = "กรุณาเข้าระบบนักศึกษา";
            _msgEN = "Please sign in student portal.";
        }

        if (_error == false && _status == "Y010") {
            _error = true;
            _msgTH = "ไม่พบสิทธิ์ผู้ใช้งาน";
            _msgEN = "No permission user.";
        }

        if (_error == false && _status == "Y020") {
            _error = true;
            _msgTH = "ไม่พบนักศึกษา";
            _msgEN = "Student not found.";
        }

        if (_error == false && _status == "Y030") {
            _error = true;
            _msgTH = "ไม่พบข้อมูล";
            _msgEN = "Data not found.";
        }

        if (_error == false && _status == "Y001") {
            _error = true;
            _msgTH = "บันทึกข้อมูลไม่สำเร็จ";
            _msgEN = "Save was not successful.";
        }

        if (_error == false && _status == "Y002") {
            _error = true;
            _msgTH = "บันทึกข้อมูลไม่สำเร็จ เนื่องจากมีข้อมูลนี้อยู่แล้ว";
            _msgEN = "Save was not successful, duplicate data.";
        }

        if (_error == false && _status == "Y003") {
            _error = true;
            _msgTH = "บันทึกข้อมูลไม่สำเร็จ เนื่องจากไม่พบข้อมูล";
            _msgEN = "Save was not successful, data not found.";
        }

        if (_error == true && _msgTH.length > 0 && _msgEN.length > 0)
            Util.dialogMessageError({
                content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>")
            });

        return _error;
    },
    loadPage: function (_callBackFunc) {
        var _this = this;
        var _error;
        var _page = ($("#page").html().length > 0 ? $("#page").html() : this.pageMain);
        var _send = {};
        _send["action"] = "page";
        _send["page"] = _page;
        _send["id"] = $("#id").html();

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

            if (_error == false) {
                if (_page == _this.pageStudentRecordsStudentCVMain)
                    $("#bodymain #mainbody .sticky").html("");

                if (_result.SearchContent.length > 0)
                    $("#bodysearch").html(_result.SearchContent);

                $("#contentbody-content").html(_result.MainContent).show();

                Util.setMenuBarLayout();
                Util.setInfoBarLayout();
                Util.setStickyTop(0);
                Util.setChartLayout();
                Util.setTableLayout();
			    Util.setFooterLayout();

                /*
			    if (_page == _this.pageMain) {
				    var _label = "<span style='color: #FFFFFF'>ขอรบกวนผู้ใช้งานทุกท่านตอบ <a href='https://docs.google.com/forms/d/e/1FAIpQLSdIfvO7b-9vW9yVWkuUIx7IiYUhlzEyTmEBdMq-_kkoAP_qNQ/viewform?usp=pp_url&entry.1320515055=%E0%B8%A3%E0%B8%B0%E0%B8%9A%E0%B8%9A%E0%B8%97%E0%B8%B0%E0%B9%80%E0%B8%9A%E0%B8%B5%E0%B8%A2%E0%B8%99%E0%B8%9B%E0%B8%A3%E0%B8%B0%E0%B8%A7%E0%B8%B1%E0%B8%95%E0%B8%B4%E0%B8%99%E0%B8%B1%E0%B8%81%E0%B8%A8%E0%B8%B6%E0%B8%81%E0%B8%A9%E0%B8%B2' target='_blank' style='text-decoration: underline; color: #000000'>แบบประเมินความพึ่งพอใจในการใช้งาน</a> เพื่อไปปรับปรุงระบบให้ดียิ่ง<div style='text-align: right; margin-top: 15px'>ขอขอบคุณผู้ใช้งานทุกท่าน<br />ผู้พัฒนาระบบ</div></span>";

				    Util.dialogMessageBox({
					    content: ("<div class='th-label'>" + _label + "</div>")
				    });
			    }
                */

                if (_page == _this.pageSettingAccesstotheSystemEdit)
                    Util.tut.tst.accesstothesystem.sectionAddUpdate.sectionEdit.initMain();

                if (_page == _this.pageMasterDataTitlePrefixMain) {                    
                    Util.tut.tse.masterdata.titleprefix.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.titleprefix.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataGenderMain) { 
                    Util.tut.tse.masterdata.gender.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.gender.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataNationalityRaceMain) {
                    Util.tut.tse.masterdata.nationalityrace.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.nationalityrace.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataReligionMain) {  
                    Util.tut.tse.masterdata.religion.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.religion.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataBloodGroupMain) {
                    Util.tut.tse.masterdata.bloodgroup.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.bloodgroup.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataMaritalStatusMain) {
                    Util.tut.tse.masterdata.maritalstatus.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.maritalstatus.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataFamilyRelationshipsMain) {
                    Util.tut.tse.masterdata.familyrelationships.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.familyrelationships.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataAgencyMain) {
                    Util.tut.tse.masterdata.agency.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.agency.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataEducationalLevelMain) {
                    Util.tut.tse.masterdata.educationallevel.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.educationallevel.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataEducationalBackgroundMain) {
                    Util.tut.tse.masterdata.educationalbackground.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.educationalbackground.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataEducationalMajorMain) {
                    Util.tut.tse.masterdata.educationalmajor.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.educationalmajor.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataAdmissionTypeMain) {
                    Util.tut.tse.masterdata.admissiontype.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.admissiontype.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataStudentStatusMain) {
                    Util.tut.tse.masterdata.studentstatus.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.studentstatus.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataCountryMain) {
                    Util.tut.tse.masterdata.country.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.country.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataProvinceMain) {
                    Util.tut.tse.masterdata.province.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.province.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataDistrictMain) {
                    Util.tut.tse.masterdata.district.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.district.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataSubdistrictMain) {
                    Util.tut.tse.masterdata.subdistrict.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.subdistrict.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataInstituteMain) {
                    Util.tut.tse.masterdata.institute.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.institute.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataInstituteNew)
                    Util.tut.tmd.institute.sectionAddUpdate.sectionNew.initMain();

                if (_page == _this.pageMasterDataInstituteEdit)
                    Util.tut.tmd.institute.sectionAddUpdate.sectionEdit.initMain();

                if (_page == _this.pageMasterDataDiseasesMain) {
                    Util.tut.tse.masterdata.diseases.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.diseases.sectionMain.initMain();
                }

                if (_page == _this.pageMasterDataHealthImpairmentsMain) {
                    Util.tut.tse.masterdata.healthimpairments.initSearch();
                    Util.initSearch();
                    Util.tut.tmd.healthimpairments.sectionMain.initMain();
                }

                if (_page == _this.pageAdministrationStudentRecordsMain) {
                    Util.tut.tse.studentrecords.initSearch();
                    Util.initSearch();
                    Util.tut.tsr.sectionMain.initMain();
                    Util.tut.tsr.sectionMain.initTable();
                }

                if (_page == _this.pageAdministrationStudentRecordsAddUpdate)
                    Util.tut.tsr.sectionAddUpdate.initMain();

                if (_page == _this.pageOurServicesExportStudentRecordsInformationMain) {
                    Util.tut.tse.ourservices.exportstudentrecordsinformation.initSearch();
                    Util.initSearch();
                    Util.tut.tos.exportstudentrecordsinformation.sectionMain.initMain();
                    Util.tut.tos.exportstudentrecordsinformation.sectionMain.initTable();
                }
                
                if (_page == _this.pageOurServicesUpdateStudentMedicalScholarsProgramMain) {
                    Util.tut.tse.ourservices.updatestudentmedicalscholarsprogram.initSearch();
                    Util.initSearch();
                    Util.tut.tos.updatestudentmedicalscholarsprogram.sectionMain.initMain();
                    Util.tut.tos.updatestudentmedicalscholarsprogram.sectionMain.initTable();
                }

                if (_page == _this.pageOurServicesSummaryNumberOfStudentMain) {
                    Util.tut.tse.ourservices.summarynumberofstudent.initSearch();
                    Util.initSearch();
                    Util.tut.tos.summarynumberofstudent.sectionMain.initMain();
                }

                if (_page == _this.pageOurServicesTransactionLogStudentRecordsMain) {
                    Util.tut.tse.ourservices.transactionlogstudentrecords.initSearch();
                    Util.initSearch();
                    Util.tut.tos.transactionlogstudentrecords.sectionMain.initMain();
                    Util.tut.tos.transactionlogstudentrecords.sectionMain.initTable();
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
    setSelectCombobox: function (_param) {
        _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);
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
        var _valueCountry = "";
        var _valueProvince = "";
        var _valueDistrict = "";
        var _valuePostalCode = "";
        var _valueDegreeLevel = "";
        var _valueFaculty = "";
        var _valueProgram = "";
        var _valueFamilyRelation = "";
        var _valueGender = "";
        var _valueAction = "";
        var _valueJoinProgram = "";
        var _widthInput;
        var _heightInput;
        var _idContent;
        var _page;
        var _familyRelation;

        if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsPersonalAddUpdate.toLowerCase() + "-titleprefix")) {
            _idContent = this.idSectionAdministrationStudentRecordsPersonalAddUpdate.toLowerCase();

            Util.tut.tsr.sectionAddUpdate.setGenderByTitlePrefix({
                idTitlePrefix: ("#" + _idContent + "-titleprefix"),
                idGender: (_idContent + "-gender")
            });
        }            

        if (_param["id"] == ("#" + this.idSectionMasterDataDistrictSearch.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionMasterDataInstituteSearch.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionMasterDataInstituteNew.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionMasterDataInstituteEdit.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationHighSchoolAddUpdate.toLowerCase() + "-institutecountry") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-relationship") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-country") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsUpdateFacultyProgramProgress.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesUpdateStudentMedicalScholarsProgramSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesUpdateStudentMedicalScholarsProgramSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesSummaryNumberOfStudentSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesSummaryNumberOfStudentSearch.toLowerCase() + "-faculty") ||
            _param["id"] == ("#" + this.idSectionOurServicesTransactionLogStudentRecordsSearch.toLowerCase() + "-degreelevel") ||
            _param["id"] == ("#" + this.idSectionOurServicesTransactionLogStudentRecordsSearch.toLowerCase() + "-faculty")) {
            if (_param["id"] == ("#" + this.idSectionMasterDataDistrictSearch.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionMasterDataInstituteSearch.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionMasterDataInstituteNew.toLowerCase() + "-country")) {
                _idContent = _param["id"].replace("#", "").replace("-country", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = _param["value"];
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-province")) {
                _idContent = _param["id"].replace("#", "").replace("-province", "");
                _cmd = "getdistrict";
                _idCombobox = (_idContent + "-district");
                _idContainer = (_idContent + "-district-combobox");
                _valueProvince = _param["value"];
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesSummaryNumberOfStudentSearch.toLowerCase() + "-degreelevel") ||
                _param["id"] == ("#" + this.idSectionOurServicesTransactionLogStudentRecordsSearch.toLowerCase() + "-degreelevel")) {
                _idContent = _param["id"].replace("#", "").replace("-degreelevel", "");
                _cmd = "getprogram";
                _idCombobox = (_idContent + "-program");
                _idContainer = (_idContent + "-program-combobox");
                _valueDegreeLevel = (_param["value"] != "0" ? _param["value"] : "");
                _valueFaculty = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty")
                });
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesSummaryNumberOfStudentSearch.toLowerCase() + "-faculty") ||
                _param["id"] == ("#" + this.idSectionOurServicesTransactionLogStudentRecordsSearch.toLowerCase() + "-faculty")) {
                _idContent = _param["id"].replace("#", "").replace("-faculty", "");
                _cmd = "getprogram";
                _idCombobox = (_idContent + "-program");
                _idContainer = (_idContent + "-program-combobox");
                _valueDegreeLevel = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel")
                });
                _valueFaculty = _param["value"];
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesUpdateStudentMedicalScholarsProgramSearch.toLowerCase() + "-degreelevel")) {
                _idContent = _param["id"].replace("#", "").replace("-degreelevel", "");
                _cmd = "getprogrambyjoinprogram";
                _idCombobox = (_idContent + "-program");
                _idContainer = (_idContent + "-program-combobox");
                _valueDegreeLevel = (_param["value"] != "0" ? _param["value"] : "");
                _valueFaculty = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty")
                });
                _valueJoinProgram = "MedicalScholarsProgram";
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesUpdateStudentMedicalScholarsProgramSearch.toLowerCase() + "-faculty")) {
                _idContent = _param["id"].replace("#", "").replace("-faculty", "");
                _cmd = "getprogrambyjoinprogram";
                _idCombobox = (_idContent + "-program");
                _idContainer = (_idContent + "-program-combobox");
                _valueDegreeLevel = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel")
                });
                _valueFaculty = _param["value"];
                _valueJoinProgram = "MedicalScholarsProgram";
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionMasterDataInstituteNew.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionMasterDataInstituteEdit.toLowerCase() + "-country")) {
                _idContent = _param["id"].replace("#", "").replace("-country", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = _param["value"];
                _widthInput = 533;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-country")) {                
                _idContent = _param["id"].replace("#", "").replace("-country", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = _param["value"];
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province")) {
                _idContent = _param["id"].replace("#", "").replace("-province", "");
                _cmd = "getdistrict";
                _idCombobox = (_idContent + "-district");
                _idContainer = (_idContent + "-district-combobox");
                _valueProvince = _param["value"];
                _widthInput = 426;
                _heightInput = 29;
            }
                       
            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district")) {
                _idContent = _param["id"].replace("#", "").replace("-district", "");
                _cmd = "getsubdistrict";
                _idCombobox = (_idContent + "-subdistrict");
                _idContainer = (_idContent + "-subdistrict-combobox");
                _valueDistrict = _param["value"];
                _widthInput = 426;
                _heightInput = 29;
            }
                                              
            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase() + "-institutecountry") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase() + "-institutecountry") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationHighSchoolAddUpdate.toLowerCase() + "-institutecountry")) {                
                _idContent = _param["id"].replace("#", "").replace("-institutecountry", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-instituteprovince");
                _idContainer = (_idContent + "-instituteprovince-combobox");
                _valueCountry = _param["value"];
                _widthInput = 426;
                _heightInput = 29;
            }
                                   
            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-relationship")) {
                if (_param["value"].length > 0) {
                    _valueArray = _param["value"].split(";");
        
                    if (_valueArray.length == 4) {
                        _valueFamilyRelation = _valueArray[1];
                        _valueGender = _valueArray[3];
                    }
        
                    _idContent = _param["id"].replace("#", "").replace("-relationship", "");
                    _cmd = "gettitleprefix";
                    _idCombobox = (_idContent + "-titleprefix");
                    _idContainer = (_idContent + "-titleprefix-combobox");
                    _valueGender = _valueGender;
                    _widthInput = 426;
                    _heightInput = 29;
                }
            }

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsUpdateFacultyProgramProgress.toLowerCase() + "-faculty")) {
                _idContent = _param["id"].replace("#", "").replace("-faculty", "");
                _cmd = "getprogram";
                _idCombobox = (_idContent + "-program");
                _idContainer = (_idContent + "-program-combobox");
                _valueFaculty = _param["value"];
                _widthInput = 500;
                _heightInput = 29;
            }

            if (_valueDistrict.length > 0 && _valueDistrict != "0") {
                _valueArray = _valueDistrict.split(";");

                if (_valueArray.length == 2) {
                    _valueDistrict = _valueArray[0];
                    _valuePostalCode = _valueArray[1];
                }
            }

            _cmd = _cmd;
            _idCombobox = _idCombobox;
            _idContainer = _idContainer;
            _valueParam["id"] = _idCombobox;
            _valueParam["country"] = _valueCountry;
            _valueParam["province"] = _valueProvince;
            _valueParam["district"] = _valueDistrict;
            _valueParam["degreelevel"] = _valueDegreeLevel;
            _valueParam["faculty"] = _valueFaculty;
            _valueParam["gender"] = _valueGender;
            _valueParam["joinprogram"] = _valueJoinProgram;
            _valueDefault = "0";
            _widthInput = _widthInput;
            _heightInput = _heightInput;

            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () {                
                if (_param["id"] == ("#" + _this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-country")) {
                    _this.setSelectDefaultCombobox({
                        id: ("#" + _idContent + "-district"),
                        value: "0"
                    }, function () {
                        if (_param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-country") ||
                            _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-country")) {
                            _this.setSelectDefaultCombobox({
                                id: ("#" + _idContent + "-subdistrict"),
                                value: "0"
                            }, function () {
                            });
                            $("#" + (_idContent + "-postalcode")).val("");
                        }
                    });
                }

                if (_param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province")) {
                    _this.setSelectDefaultCombobox({
                        id: ("#" + _idContent + "-subdistrict"),
                        value: "0"
                    }, function () {
                    });
                    $("#" + (_idContent + "-postalcode")).val("");
                }

                if (_param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                    _param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district"))
                    $("#" + (_idContent + "-postalcode")).val(_valuePostalCode);

                if (_param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-relationship")) {
                    Util.tut.tsr.sectionAddUpdate.setGenderByTitlePrefix({
                        idTitlePrefix: ("#" + _idCombobox),
                        idGender: (_idContent + "-gender"),
                        valueGender: _valueGender
                    });
                    Util.tut.tsr.sectionAddUpdate.family.setParentOnRelationship({
                        page: _this.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate,
                        this: Util.tut.tsr.sectionAddUpdate.family.personal
                    });
                }
            });
        }

        if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsWorkAddUpdate.toLowerCase() + "-agency") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherWorkAddUpdate.toLowerCase() + "-agency") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherWorkAddUpdate.toLowerCase() + "-agency") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentWorkAddUpdate.toLowerCase() + "-agency")) {
            _idContent = _param["id"].replace("#", "").replace("-agency", "")
            _idRadiobox = (_idContent + "-agencyother");
            _idTextbox = (_idContent + "-agencyotherdetail");

            $("input[name=" + _idRadiobox + "]").iCheck("uncheck");            
            $("#" + _idTextbox).val("");
            Util.textboxDisable("#" + _idTextbox);
        }

        if (_param["id"] == ("#" + this.idSectionMasterDataTitlePrefixMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataGenderMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataNationalityRaceMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataReligionMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataBloodGroupMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataMaritalStatusMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataFamilyRelationshipsMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataAgencyMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataEducationalLevelMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataEducationalBackgroundMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataEducationalMajorMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataAdmissionTypeMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataStudentStatusMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataCountryMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataProvinceMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataDistrictMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataSubdistrictMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataInstituteMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataDiseasesMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionMasterDataHealthImpairmentsMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesUpdateStudentMedicalScholarsProgramMain.toLowerCase() + "-rowperpage") ||
            _param["id"] == ("#" + this.idSectionOurServicesTransactionLogStudentRecordsMain.toLowerCase() + "-rowperpage")) {
            if (_param["id"] == ("#" + this.idSectionMasterDataTitlePrefixMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataTitlePrefixMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataGenderMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataGenderMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataNationalityRaceMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataNationalityRaceMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataReligionMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataReligionMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataBloodGroupMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataBloodGroupMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataMaritalStatusMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataMaritalStatusMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataFamilyRelationshipsMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataFamilyRelationshipsMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataAgencyMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataAgencyMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataEducationalLevelMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataEducationalLevelMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataEducationalBackgroundMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataEducationalBackgroundMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataEducationalMajorMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataEducationalMajorMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataAdmissionTypeMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataAdmissionTypeMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataStudentStatusMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataStudentStatusMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataCountryMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataCountryMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataProvinceMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataProvinceMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataDistrictMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataDistrictMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataSubdistrictMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataSubdistrictMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataInstituteMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataInstituteMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataDiseasesMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataDiseasesMain;

            if (_param["id"] == ("#" + this.idSectionMasterDataHealthImpairmentsMain.toLowerCase() + "-rowperpage"))
                _page = this.pageMasterDataHealthImpairmentsMain;

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsMain.toLowerCase() + "-rowperpage"))
                _page = this.pageAdministrationStudentRecordsMain;

            if (_param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationMain.toLowerCase() + "-rowperpage"))
                _page = this.pageOurServicesExportStudentRecordsInformationMain;

            if (_param["id"] == ("#" + this.idSectionOurServicesUpdateStudentMedicalScholarsProgramMain.toLowerCase() + "-rowperpage"))
                _page = this.pageOurServicesUpdateStudentMedicalScholarsProgramMain;

            if (_param["id"] == ("#" + this.idSectionOurServicesTransactionLogStudentRecordsMain.toLowerCase() + "-rowperpage"))
                _page = this.pageOurServicesTransactionLogStudentRecordsMain;
            
            if (Util.tut.tse.validateSearch({
                page: _page
            }))
                Util.tut.tse.getSearch({
                    page: _page
                });
        }

        if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsUpdateFacultyProgramProgress.toLowerCase() + "-program")) {
            _idContent = this.idSectionAdministrationStudentRecordsUpdateFacultyProgramProgress.toLowerCase();

            Util.getProgramCode({
                program: _param["value"]
            }, function (_result) {
                $("#" + _idContent + "-program-hidden").val(_result);
            });
        }

        if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsUpdateStudentStatusProgress.toLowerCase() + "-studentstatus")) {
            _idContent = this.idSectionAdministrationStudentRecordsUpdateStudentStatusProgress.toLowerCase();

            if (_param["value"] != "0" && _param["value"].substring(0, 2) != "00")
                Util.calendarEnable("#" + _idContent + "-graduationdate");
            else {
                $("#" + _idContent + "-graduationdate").val("");
                Util.calendarDisable("#" + _idContent + "-graduationdate");
            }
        }
    },
    setSelectDefaultCombobox: function (_param, _callBackFunc) {
        _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);
        _param["value"] = (_param["value"] == undefined ? "" : _param["value"]);

        var _this = this;
        var _cmd;
        var _idCombobox;
        var _idCheckbox;
        var _idContainer;
        var _valueParam = {};
        var _valueDefault;
        var _valueArray;
        var _valueCountry = "";
        var _valueProvince = "";
        var _valueDistrict = "";
        var _valueDegreeLevel = "";
        var _valueFaculty = "";
        var _valueFamilyRelation = "";
        var _valueGender = "";
        var _valueJoinProgram = "";
        var _widthInput;
        var _heightInput;
        var _idContent;
        var _familyRelation;

        if (_param["id"] == ("#" + this.idSectionMasterDataDistrictSearch.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionMasterDataInstituteSearch.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionMasterDataInstituteNew.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionMasterDataInstituteEdit.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationHighSchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-titleprefix") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
            _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsUpdateFacultyProgramProgress.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesUpdateStudentMedicalScholarsProgramSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesSummaryNumberOfStudentSearch.toLowerCase() + "-program") ||
            _param["id"] == ("#" + this.idSectionOurServicesTransactionLogStudentRecordsSearch.toLowerCase() + "-program")) {
            if (_param["id"] == ("#" + this.idSectionMasterDataDistrictSearch.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-province")) {
                _idContent = _param["id"].replace("#", "").replace("-province", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-country"),
                    valueFalse: "0"
                });
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionMasterDataSubdistrictSearch.toLowerCase() + "-district")) {
                _idContent = _param["id"].replace("#", "").replace("-district", "");
                _cmd = "getdistrict";
                _idCombobox = (_idContent + "-district");
                _idContainer = (_idContent + "-district-combobox");
                _valueProvince = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-province"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-province"),
                    valueFalse: "0"
                });
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionMasterDataInstituteSearch.toLowerCase() + "-province")) {
                _idContent = _param["id"].replace("#", "").replace("-province", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-country"),
                    valueFalse: "0"
                });
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionMasterDataInstituteNew.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionMasterDataInstituteEdit.toLowerCase() + "-province")) {
                _idContent = _param["id"].replace("#", "").replace("-province", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-country"),
                    valueFalse: "0"
                });
                _widthInput = 533;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesExportStudentRecordsInformationSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesSummaryNumberOfStudentSearch.toLowerCase() + "-program") ||
                _param["id"] == ("#" + this.idSectionOurServicesTransactionLogStudentRecordsSearch.toLowerCase() + "-program")) {
                _idContent = _param["id"].replace("#", "").replace("-program", "");
                _cmd = "getprogram";
                _idCombobox = (_idContent + "-program");
                _idContainer = (_idContent + "-program-combobox");
                _valueDegreeLevel = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel")
                });
                _valueFaculty = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                    valueFalse: "0"
                });
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionOurServicesUpdateStudentMedicalScholarsProgramSearch.toLowerCase() + "-program")) {
                _idContent = _param["id"].replace("#", "").replace("-program", "");
                _cmd = "getprogrambyjoinprogram";
                _idCombobox = (_idContent + "-program");
                _idContainer = (_idContent + "-program-combobox");
                _valueDegreeLevel = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-degreelevel")
                });
                _valueFaculty = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                    valueFalse: "0"
                });
                _valueJoinProgram = "MedicalScholarsProgram";
                _widthInput = $(".form.search .form-content .form-inputcol .form-input .combobox-width-dynamic .combobox").width();
                _heightInput = 27;
            }

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-province") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-province")) {
                _idContent = _param["id"].replace("#", "").replace("-province", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-province");
                _idContainer = (_idContent + "-province-combobox");
                _valueCountry = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-country"),
                    valueFalse: "0"
                });
                _widthInput = 426;
                _heightInput = 29;
            }
           
            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-district") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-district")) {
                _idContent = _param["id"].replace("#", "").replace("-district", "");
                _cmd = "getdistrict";
                _idCombobox = (_idContent + "-district");
                _idContainer = (_idContent + "-district-combobox");
                _valueProvince = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-province"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-province"),
                    valueFalse: "0"
                });
                _widthInput = 426;
                _heightInput = 29;
            }
           
            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase() + "-subdistrict") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase() + "-subdistrict")) {
                _idContent = _param["id"].replace("#", "").replace("-subdistrict", "");
                _cmd = "getsubdistrict";
                _idCombobox = (_idContent + "-subdistrict");
                _idContainer = (_idContent + "-subdistrict-combobox");
                _valueDistrict = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-district"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-district"),
                    valueFalse: "0"
                });
                _widthInput = 426;
                _heightInput = 29;
            }
                                              
            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase() + "-instituteprovince") ||
                _param["id"] == ("#" + this.idSectionAdministrationStudentRecordsEducationHighSchoolAddUpdate.toLowerCase() + "-instituteprovince")) {
                _idContent = _param["id"].replace("#", "").replace("-instituteprovince", "");
                _cmd = "getprovince";
                _idCombobox = (_idContent + "-instituteprovince");
                _idContainer = (_idContent + "-instituteprovince-combobox");
                _valueCountry = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-institutecountry"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-institutecountry"),
                    valueFalse: "0"
                });
                _widthInput = 426;
                _heightInput = 29;
            }
                                  
            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-titleprefix")) {
                _idContent = _param["id"].replace("#", "").replace("-titleprefix", "");
                _valueFamilyRelation = Util.comboboxGetValue("#" + _idContent + "-relationship");

                if (_valueFamilyRelation != "0") {
                    _valueArray = _valueFamilyRelation.split(";");

                    if (_valueArray.length == 4)
                        _valueGender = _valueArray[3];
                }

                _cmd = "gettitleprefix";
                _idCombobox = (_idContent + "-titleprefix");
                _idContainer = (_idContent + "-titleprefix-combobox");
                _valueGender = _valueGender;
                _widthInput = 426;
                _heightInput = 29;
            }

            if (_param["id"] == ("#" + this.idSectionAdministrationStudentRecordsUpdateFacultyProgramProgress.toLowerCase() + "-program")) {
                _idContent = _param["id"].replace("#", "").replace("-program", "");
                _cmd = "getprogram";
                _idCombobox = (_idContent + "-program");
                _idContainer = (_idContent + "-program-combobox");
                _valueFaculty = Util.getSelectionIsSelect({
                    id: ("#" + _idContent + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _idContent + "-faculty"),
                    valueFalse: "0"
                });
                _widthInput = 500;
                _heightInput = 29;
            }

            if (_valueDistrict.length > 0 && _valueDistrict != "0") {
                _valueArray = _valueDistrict.split(";");

                if (_valueArray.length == 2)
                    _valueDistrict = _valueArray[0];
            }

            _cmd = _cmd;
            _idCombobox = _idCombobox;
            _idContainer = _idContainer;
            _valueParam["id"] = _idCombobox;
            _valueParam["country"] = _valueCountry;
            _valueParam["province"] = _valueProvince;
            _valueParam["district"] = _valueDistrict;
            _valueParam["degreelevel"] = _valueDegreeLevel;
            _valueParam["faculty"] = _valueFaculty;
            _valueParam["gender"] = _valueGender;
            _valueParam["joinprogram"] = _valueJoinProgram;
            _valueDefault = _param["value"];
            _widthInput = _widthInput;
            _heightInput = _heightInput;

            Util.loadCombobox({
                cmd: _cmd,
                id: _idCombobox,
                idContainer: _idContainer,
                data: _valueParam,
                valueDefault: _valueDefault,
                width: _widthInput,
                height: _heightInput
            }, function () {
                if (_param["id"] == ("#" + _this.idSectionAdministrationStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase() + "-titleprefix"))
                    Util.tut.tsr.sectionAddUpdate.setGenderByTitlePrefix({
                        idTitlePrefix: ("#" + _idCombobox),
                        idGender: (_idContent + "-gender"),
                        valueGender: _valueGender
                    });

                _callBackFunc();
            });
        }
    },
    getDialogFormOnClick: function () {
        var _this = this;
        var _page;
        var _data = "";
        var _idActive ;

        $(".link-" + _this.subjectSectionMeaningofAdmissionType.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionMeaningofStudentStatus.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionTopicsStudentRecordsStatusNotComplete.toLowerCase() + ", " +
          ".link-" + _this.subjectSectionViewMessage.toLowerCase()).click(function () {
            if ($(this).hasClass("link-" + _this.subjectSectionMeaningofAdmissionType.toLowerCase()) == true)
                _page = _this.pageMeaningofAdmissionTypeMain;

            if ($(this).hasClass("link-" + _this.subjectSectionMeaningofStudentStatus.toLowerCase()) == true)
                 _page = _this.pageMeaningOfStudentStatusMain;

            if ($(this).hasClass("link-" + _this.subjectSectionTopicsStudentRecordsStatusNotComplete.toLowerCase()) == true)
                _page = _this.pageTopicsStudentRecordsStatusNotCompleteMain;

            if ($(this).hasClass("link-" + _this.subjectSectionViewMessage.toLowerCase()) == true)
                _page = _this.pageViewMessageMain;

            _idActive = "";

            if (_page == _this.pageTopicsStudentRecordsStatusNotCompleteMain ||
                _page == _this.pageViewMessageMain) {
                _idActive = $(this).closest(".table-row").attr("id");
                _data = $(this).attr("alt");
            }
            
            Util.loadForm({
                index: ($("#" + Util.dialogForm + "1").is(":visible") ? 2 : 1),
                name: _page,
                dialog: true, 
                data: _data,
                idActive: _idActive
            }, function () {
            });
        });
    }
}