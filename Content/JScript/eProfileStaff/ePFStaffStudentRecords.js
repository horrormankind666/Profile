/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๙/๐๑/๒๕๕๘>
Modify date : <๑๐/๐๓/๒๕๖๔>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการจัดการข้อมูลระเบียนประวัตินักศึกษา>
=============================================
*/

var ePFStaffStudentRecords = {
    isProgramContract: false,
    idSectionMain: ePFStaffUtil.idSectionAdministrationStudentRecordsMain.toLowerCase(),
    idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsAddUpdate.toLowerCase(),
    sectionMain: {    
        initMain: function () {
            var _this = Util.tut.tsr;
            var _thisProgress = null;
            var _thisPreview = null;
            var _pageProgress;
            var _pagePreview;

            Util.initCombobox({
                id: ("#" + _this.idSectionMain + "-rowperpage"),
                width: 103,
                height: 25
            });
            Util.initCombobox({
                id: ("#" + _this.idSectionMain + "-updateoption"),
                width: 300,
                height: 25
            });
            Util.initCheck({
                id: "select-root"
            });

            $("#" + _this.idSectionMain + "-table .button .click-button").click(function () {
                if ($(this).hasClass("button-updateselected") == true) {
                    _pageProgress = Util.getSelectionIsSelect({
                        id: ("#" + _this.idSectionMain + "-updateoption"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this.idSectionMain + "-updateoption")
                    });                    

                    if (_pageProgress == Util.tut.pageAdministrationStudentRecordsUpdateFacultyProgramProgress) {
                        _pagePreview = Util.tut.pageAdministrationStudentRecordsUpdateFacultyProgramPreview;
                        _thisProgress = _this.sectionProgress.updatefacultyprogram;
                        _thisPreview = _this.sectionPreview.updatefacultyprogram;
                    }

                    if (_pageProgress == Util.tut.pageAdministrationStudentRecordsUpdateClassYearProgress) {
                        _pagePreview = Util.tut.pageAdministrationStudentRecordsUpdateClassYearPreview;
                        _thisProgress = _this.sectionProgress.updateclassyear;
                        _thisPreview = _this.sectionPreview.updateclassyear;
                    }

                    if (_pageProgress == Util.tut.pageAdministrationStudentRecordsUpdateEntranceTypeProgress) {
                        _pagePreview = Util.tut.pageAdministrationStudentRecordsUpdateEntranceTypePreview;
                        _thisProgress = _this.sectionProgress.updateentrancetype;
                        _thisPreview = _this.sectionPreview.updateentrancetype;
                    }

                    if (_pageProgress == Util.tut.pageAdministrationStudentRecordsUpdateStudentStatusProgress) {
                        _pagePreview = Util.tut.pageAdministrationStudentRecordsUpdateStudentStatusPreview;
                        _thisProgress = _this.sectionProgress.updatestudentstatus;
                        _thisPreview = _this.sectionPreview.updatestudentstatus;
                    }

                    if (_pageProgress == Util.tut.pageAdministrationStudentRecordsUpdateAdmissionDateProgress) {
                        _pagePreview = Util.tut.pageAdministrationStudentRecordsUpdateAdmissionDatePreview;
                        _thisProgress = _this.sectionProgress.updateadmissiondate;
                        _thisPreview = _this.sectionPreview.updateadmissiondate;
                    }

                    if (_pageProgress == Util.tut.pageAdministrationStudentRecordsUpdateDatatoOldDBProgress) {
                        _pagePreview = "";
                        _thisProgress = _this.sectionProgress.updatedatatoolddb;
                        _thisPreview = null;
                    }
                                            
                    Util.tut.tpd.getProgress({
                        action: Util.tut.subjectSectionUpdate,
                        pageProgress: _pageProgress,
                        pagePreview: _pagePreview,
                        thisProgress: _thisProgress,
                        thisPreview: _thisPreview,
                        idMain: _this.idSectionMain,
                        idProgress: (_thisProgress != null ? _thisProgress.idSectionProgress : ""),
                        idPreview: (_thisPreview != null ? _thisPreview.idSectionPreview : ""),
                        option: $(this).attr("alt")
                    });
                }
            });

            this.resetMain();
        },
        resetMain: function () {
            var _this = Util.tut.tsr;

            Util.comboboxSetValue({
                id: ("#" + _this.idSectionMain + "-rowperpage"),
                value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
            });
            Util.comboboxSetValue({
                id: ("#" + _this.idSectionMain + "-updateoption"),
                value: "0"
            });
        },
        initTable: function () {
            Util.tut.getDialogFormOnClick();
        },
    },
    sectionAddUpdate: {
        initMain: function () {
            var _this = Util.tut.tsr;

            this.setMenuLayout();
            this.initMenu({
                id: ("#" + _this.idSectionAddUpdate + "-menu-content"),
                idContent: ("#" + _this.idSectionAddUpdate + "-content"),
                classActive: "menu-active",
                classNoActive: "menu-noactive"
            });
            this.initMainSection({
                page: Util.tut.pageAdministrationStudentRecordsStudentRecordsAddUpdate
            });
        },
        setMenuLayout: function () {
            var _this = Util.tut.tsr;
            
            if ($("#" + _this.idSectionAddUpdate + "-menu").length > 0) {
                $("#" + _this.idSectionAddUpdate + "-menu").css("top", Util.offsetTop);
                $("#" + _this.idSectionAddUpdate + "-menu").height($(window).height() - Util.offsetTop);
            }
        },
        setMenuByStudentRecordsStatus: function (_param) {
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this = this.studentrecords;
            var _personal = $("#" + _this.idSectionAddUpdate + "-studentrecordspersonalstatus-hidden").val();
            var _addressPermanent = $("#" + _this.idSectionAddUpdate + "-studentrecordsaddresspermanentstatus-hidden").val();
            var _addressCurrent = $("#" + _this.idSectionAddUpdate + "-studentrecordsaddresscurrentstatus-hidden").val();
            var _educationPrimarySchool = $("#" + _this.idSectionAddUpdate + "-studentrecordseducationprimaryschoolstatus-hidden").val();
            var _educationJuniorHighSchool = $("#" + _this.idSectionAddUpdate + "-studentrecordseducationjuniorhighschoolstatus-hidden").val();
            var _educationHighSchool = $("#" + _this.idSectionAddUpdate + "-studentrecordseducationhighschoolstatus-hidden").val();
            var _educationUniversity = $("#" + _this.idSectionAddUpdate + "-studentrecordseducationuniversitystatus-hidden").val();
            var _educationAdmissionScores = $("#" + _this.idSectionAddUpdate + "-studentrecordseducationadmissionscoresstatus-hidden").val();
            var _talent = $("#" + _this.idSectionAddUpdate + "-studentrecordstalentstatus-hidden").val();
            var _healthy = $("#" + _this.idSectionAddUpdate + "-studentrecordshealthystatus-hidden").val();
            var _work = $("#" + _this.idSectionAddUpdate + "-studentrecordsworkstatus-hidden").val();
            var _financial = $("#" + _this.idSectionAddUpdate + "-studentrecordsfinancialstatus-hidden").val();
            var _familyFatherPersonal = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilyfatherpersonalstatus-hidden").val();
            var _familyMotherPersonal = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilymotherpersonalstatus-hidden").val();
            var _familyParentPersonal = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilyparentpersonalstatus-hidden").val();
            var _familyFatherAddressPermanent = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilyfatheraddresspermanentstatus-hidden").val();
            var _familyMotherAddressPermanent = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilymotheraddresspermanentstatus-hidden").val();
            var _familyParentAddressPermanent = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilyparentaddresspermanentstatus-hidden").val();
            var _familyFatherAddressCurrent = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilyfatheraddresscurrentstatus-hidden").val();
            var _familyMotherAddressCurrent = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilymotheraddresscurrentstatus-hidden").val();
            var _familyParentAddressCurrent = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilyparentaddresscurrentstatus-hidden").val();
            var _familyFatherWork = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilyfatherworkstatus-hidden").val();
            var _familyMotherWork = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilymotherworkstatus-hidden").val();
            var _familyparentwork = $("#" + _this.idSectionAddUpdate + "-studentrecordsfamilyparentworkstatus-hidden").val();            
            var _valueStudentRecordsStatus;
            var _idContent;

            if (_param["section"] == Util.tut.subjectSectionAdministrationStudentRecordsPersonal) {
                _valueStudentRecordsStatus = _personal;
                _idContent = ("#link-" + this.personal.idSectionAddUpdate);
            }

            if (_param["section"] == Util.tut.subjectSectionAdministrationStudentRecordsAddress) {
                _valueStudentRecordsStatus = (_addressPermanent == "N" || _addressCurrent == "N" ? "N" : "Y");
                _idContent = ("#link-" + this.address.idSectionAddUpdate);
            }

            if (_param["section"] == Util.tut.subjectSectionAdministrationStudentRecordsEducation) {
                _valueStudentRecordsStatus = (_educationPrimarySchool == "N" || _educationJuniorHighSchool == "N" || _educationHighSchool == "N" || _educationUniversity == "N" || _educationAdmissionScores == "N" ? "N" : "Y");
                _idContent = ("#link-" + this.education.idSectionAddUpdate);
            }

            if (_param["section"] == Util.tut.subjectSectionAdministrationStudentRecordsTalent) {
                _valueStudentRecordsStatus = _talent;
                _idContent = ("#link-" + this.talent.idSectionAddUpdate);
            }

            if (_param["section"] == Util.tut.subjectSectionAdministrationStudentRecordsHealthy) {
                _valueStudentRecordsStatus = _healthy;
                _idContent = ("#link-" + this.healthy.idSectionAddUpdate);
            }
            
            if (_param["section"] == Util.tut.subjectSectionAdministrationStudentRecordsWork) {
                _valueStudentRecordsStatus = _work;
                _idContent = ("#link-" + this.work.idSectionAddUpdate);
            }

            if (_param["section"] == Util.tut.subjectSectionAdministrationStudentRecordsFinancial) {
                _valueStudentRecordsStatus = _financial
                _idContent = ("#link-" + this.financial.idSectionAddUpdate);
            }

            if (_param["section"] == Util.tut.subjectSectionAdministrationStudentRecordsFamily) {
                _valueStudentRecordsStatus = (_familyFatherPersonal == "N" || _familyMotherPersonal == "N" || _familyParentPersonal == "N" ||
                                              _familyFatherAddressPermanent == "N" || _familyMotherAddressPermanent == "N" || _familyParentAddressPermanent == "N" ||
                                              _familyFatherAddressCurrent == "N" || _familyMotherAddressCurrent == "N" || _familyParentAddressCurrent == "N" ||
                                              _familyFatherWork == "N" || _familyMotherWork == "N" || _familyparentwork == "N" ? "N" : "Y");
                _idContent = ("#link-" + this.family.idSectionAddUpdate);
            }

            if (_valueStudentRecordsStatus.length > 0 && _idContent.length > 0) {
                if (_valueStudentRecordsStatus == "Y") {
                    if ($(_idContent).hasClass("menu-incomplete") == true)
                        $(_idContent).removeClass("menu-incomplete");
                }

                if (_valueStudentRecordsStatus == "N") {
                    if ($(_idContent).hasClass("menu-incomplete") == false)
                        $(_idContent).addClass("menu-incomplete");
                }
            }
        },
        initMenu: function (_param) {
            _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);
            _param["idContent"] = (_param["idContent"] == undefined ? "" : _param["idContent"]);
            _param["classActive"] = (_param["classActive"] == undefined || _param["classActive"] == "" ? "active" : _param["classActive"]);
            _param["classNoActive"] = (_param["classNoActive"] == undefined || _param["classNoActive"] == "" ? "noactive" : _param["classNoActive"]);

            var _this1 = Util.tut.tsr;
            var _this2 = this;
            var _this3 = null;
            
            Util.initTab({
                id: _param["id"],
                idContent: _param["idContent"],
                classActive: _param["classActive"],
                classNoActive: _param["classNoActive"],
            }, function (_result) {
                var _idLink = _result;
                var _page = $("#" + _idLink).attr("alt")
                
                Util.getTabOnClick({
                    idLink: _idLink,
                    data: $("#" + _this2.studentrecords.idSectionAddUpdate + "-personid-hidden").val()
                }, function (_result) {
                    if (_page == Util.tut.pageAdministrationStudentRecordsAddressAddUpdate ||
                        _page == Util.tut.pageAdministrationStudentRecordsAddressPermanentAddUpdate ||
                        _page == Util.tut.pageAdministrationStudentRecordsAddressCurrentAddUpdate) {
                        var _idTabActive = Util.getTabActiveOnTabbar({
                            id: (_this2.address.idSectionAddUpdate + "-menu")
                        });

                        if (_idTabActive == _this2.address.permanentaddress.idSectionAddUpdate)
                            _this3 = _this2.address.permanentaddress;

                        if (_idTabActive == _this2.address.currentaddress.idSectionAddUpdate)
                            _this3 = _this2.address.currentaddress;

                        if (_this2.studentrecords.nationality == "ไทย") {
                            $("#" + _this3.idSectionAddUpdate + "-district-label .th-label .icon-fieldmarkblank").removeClass("icon-fieldmarkblank").addClass("icon-fieldmark");
                            $("#" + _this3.idSectionAddUpdate + "-subdistrict-label .th-label .icon-fieldmarkblank").removeClass("icon-fieldmarkblank").addClass("icon-fieldmark");
                            $("#" + _this3.idSectionAddUpdate + "-postalcode-label .th-label .icon-fieldmarkblank").removeClass("icon-fieldmarkblank").addClass("icon-fieldmark");
                        }
                        else {
                            $("#" + _this3.idSectionAddUpdate + "-district-label .th-label .icon-fieldmark").removeClass("icon-fieldmark").addClass("icon-fieldmarkblank");
                            $("#" + _this3.idSectionAddUpdate + "-subdistrict-label .th-label .icon-fieldmark").removeClass("icon-fieldmark").addClass("icon-fieldmarkblank");
                            $("#" + _this3.idSectionAddUpdate + "-postalcode-label .th-label .icon-fieldmark").removeClass("icon-fieldmark").addClass("icon-fieldmarkblank");
                        }
                    }

                    if (_result == true) {
                        $("#infobar-" + Util.tut.subjectSectionAdministrationStudentRecords.toLowerCase() + " .operator-save").show();
                        _this2.setMenuLayout();
                        _this2.initMainSection({
                            page: _page
                        });
                    }
                    else {
                        if (_page == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate ||
                            _page == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate ||
                            _page == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate ||
                            _page == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate) {                                
                            if (_page == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate)
                                _this3 = _this2.family.personal; 

                            if (_page == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate)
                                _this3 = _this2.family.address.permanentaddress;

                            if (_page == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate)
                                _this3 = _this2.family.address.currentaddress;

                            if (_page == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate)
                                _this3 = _this2.family.work;            
                                
                            _this2.family.setParentOnRelationship({
                                page: _page,
                                this: _this3
                            });
                        }
                    }
                });
            });
        },
        initMainSection: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);
            
            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsStudentRecordsAddUpdate) {
                this.studentrecords.initMain();
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsPersonalAddUpdate) {
                this.personal.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressAddUpdate) {
                this.address.initMain();
                this.address.permanentaddress.initMain({
                    page: Util.tut.pageAdministrationStudentRecordsAddressPermanentAddUpdate
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressPermanentAddUpdate) {
                this.address.permanentaddress.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressCurrentAddUpdate) {
                this.address.currentaddress.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationAddUpdate) {
                this.education.initMain();
                this.education.highschool.initMain({
                    page: Util.tut.pageAdministrationStudentRecordsEducationHighSchoolAddUpdate
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationPrimarySchoolAddUpdate) {
                this.education.primaryschool.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate) {
                this.education.juniorhighschool.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationHighSchoolAddUpdate) {
                this.education.highschool.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationUniversityAddUpdate) {
                this.education.university.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationAdmissionScoresAddUpdate) {
                this.education.admissionscores.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsTalentAddUpdate) {
                this.talent.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsHealthyAddUpdate) {
                this.healthy.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsWorkAddUpdate) {
                this.work.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFinancialAddUpdate) {
                this.financial.initMain({
                    page: _param["page"]
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyAddUpdate) {
                this.family.initMain();
                this.family.initSubMain({
                    familyRelation: Util.tut.subjectFamilyFather
                });
                this.family.personal.initMain({
                    page: Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate,
                    familyRelation: Util.tut.subjectFamilyFather
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddUpdate) {
                this.family.initSubMain({
                    familyRelation: Util.tut.subjectFamilyFather
                });
                this.family.personal.initMain({
                    page: Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate,
                    familyRelation: Util.tut.subjectFamilyFather
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddUpdate) {
                this.family.initSubMain({
                    familyRelation: Util.tut.subjectFamilyMother
                });
                this.family.personal.initMain({
                    page: Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate,
                    familyRelation: Util.tut.subjectFamilyMother
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddUpdate) {
                this.family.initSubMain({
                    familyRelation: Util.tut.subjectFamilyParent
                });
                this.family.personal.initMain({
                    page: Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate,
                    familyRelation: Util.tut.subjectFamilyParent
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate) {
                this.family.personal.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyFather
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate) {
                this.family.personal.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyMother
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate) {
                this.family.personal.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyParent
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate) {
                this.family.address.permanentaddress.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyFather
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate) {
                this.family.address.permanentaddress.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyMother
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate) {
                this.family.address.permanentaddress.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyParent
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate) {
                this.family.address.currentaddress.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyFather
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate) {
                this.family.address.currentaddress.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyMother
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate) {
                this.family.address.currentaddress.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyParent
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate) {
                this.family.work.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyFather
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate) {
                this.family.work.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyMother
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate) {
                this.family.work.initMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyParent
                });
            }
        },
        resetMainSection: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["section"] = (_param["section"] == undefined ? "" : _param["section"]);

            var _this = null;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsStudentRecordsAddUpdate)
                _this = this.studentrecords;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsPersonalAddUpdate)
                _this = this.personal;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressPermanentAddUpdate)
                this.address.resetMain({
                    this: this.address.permanentaddress
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressCurrentAddUpdate)
                this.address.resetMain({
                    this: this.address.currentaddress
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationPrimarySchoolAddUpdate)
                _this = this.education.primaryschool;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate)
                _this = this.education.juniorhighschool;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationHighSchoolAddUpdate)
                _this = this.education.highschool;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationUniversityAddUpdate)
                _this = this.education.university;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationAdmissionScoresAddUpdate)
                _this = this.education.admissionscores;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsTalentAddUpdate)
                _this = this.talent;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsHealthyAddUpdate)
                _this = this.healthy;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsWorkAddUpdate)
                _this = this.work;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFinancialAddUpdate)
                _this = this.financial;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate)
                this.family.personal.resetMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyFather
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate)
                this.family.personal.resetMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyMother
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate)
                this.family.personal.resetMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyParent
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate)
                this.family.address.resetMain({
                    page: _param["page"],
                    this: this.family.address.permanentaddress,
                    familyRelation: Util.tut.subjectFamilyFather
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate)
                this.family.address.resetMain({
                    page: _param["page"],
                    this: this.family.address.permanentaddress,
                    familyRelation: Util.tut.subjectFamilyMother
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate)
                this.family.address.resetMain({
                    page: _param["page"],
                    this: this.family.address.permanentaddress,
                    familyRelation: Util.tut.subjectFamilyParent
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate)
                this.family.address.resetMain({
                    page: _param["page"],
                    this: this.family.address.currentaddress,
                    familyRelation: Util.tut.subjectFamilyFather
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate)
                this.family.address.resetMain({
                    page: _param["page"],
                    this: this.family.address.currentaddress,
                    familyRelation: Util.tut.subjectFamilyMother
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate)
                this.family.address.resetMain({
                    page: _param["page"],
                    this: this.family.address.currentaddress,
                    familyRelation: Util.tut.subjectFamilyParent
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate)
                this.family.work.resetMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyFather
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate)
                this.family.work.resetMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyMother
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate)
                this.family.work.resetMain({
                    page: _param["page"],
                    familyRelation: Util.tut.subjectFamilyParent
                });

            if (_this != null)
                _this.resetMain({});
        },
        setGenderByTitlePrefix: function (_param) {
            _param["idTitlePrefix"] = (_param["idTitlePrefix"] == undefined ? "" : _param["idTitlePrefix"]);
            _param["idGender"] = (_param["idGender"] == undefined ? "" : _param["idGender"]);
            _param["valueGender"] = (_param["valueGender"] == undefined ? "" : _param["valueGender"]);

            var _value = Util.comboboxGetValue(_param["idTitlePrefix"]);
            var _valueArray = _value.split(";");

            $("input[name=" + _param["idGender"] + "]").iCheck("uncheck");

            Util.checkSetValue({
                id: _param["idGender"],
                value: _param["valueGender"]
            });

            if ($("input[name=" + _param["idGender"] + "]").is(":checked") == false) {
                if (_valueArray.length == 2 && _valueArray[1].length > 0) {
                    Util.checkSetValue({
                        id: _param["idGender"],
                        value: _valueArray[1]
                    });
                    $("input[name=" + _param["idGender"] + "]").iCheck("disable");
                }
                else {
                    $("input[name=" + _param["idGender"] + "]").iCheck("uncheck");
                    $("input[name=" + _param["idGender"] + "]").iCheck("enable");
                }
            }
            else
                $("input[name=" + _param["idGender"] + "]").iCheck("disable");
        },
        copyPersonal: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["copy"] = (_param["copy"] == undefined || _param["copy"] == "" ? false : _param["copy"]);
            _param["idSrc"] = (_param["idSrc"] == undefined ? "" : _param["idSrc"]);
            _param["idDes"] = (_param["idDes"] == undefined ? "" : _param["idDes"]);

            var _valueRelationship;
            var _valueRelationshipArray;
            var _familyRelation = ""
            var _idSection;
            
            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate) {
                _valueRelationship = Util.comboboxGetValue("#" + this.family.personal.idSectionParentAddUpdate + "-relationship");

                if (_valueRelationship != "0") {
                    _valueRelationshipArray = _valueRelationship.split(";");
                    _familyRelation = (_valueRelationshipArray.length == 4 ? _valueRelationshipArray[1] : "");
                }

                if (_familyRelation != Util.tut.subjectFamilyFather && _familyRelation != Util.tut.subjectFamilyMother)
                    _familyRelation = Util.tut.subjectFamilyParent;
            }

            $("#" + _param["idDes"] + "-personid-hidden").val(_param["copy"] == true ? (_familyRelation == Util.tut.subjectFamilyParent ? $("#" + this.family.personal.idSectionParentAddUpdate + "-defaultpersonid-hidden").val() : $("#" + _param["idSrc"] + "-personid-hidden").val()) : $("#" + this.family.personal.idSectionParentAddUpdate + "-defaultpersonid-hidden").val());
            $("#" + _param["idDes"] + "-idcard").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-idcard-hidden").val() : "");
            Util.tut.setSelectDefaultCombobox({
                id: ("#" + _param["idDes"] + "-titleprefix"),
                value: (_param["copy"] == true ? ($("#" + _param["idSrc"] + "-titleprefix-hidden").val() != "0" ? ($("#" + _param["idSrc"] + "-titleprefix-hidden").val() + ";" + $("#" + _param["idSrc"] + "-gendertitleprefix-hidden").val()) : "0") : "0")
            }, function () {
            });
            $("#" + _param["idDes"] + "-firstname").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-firstname-hidden").val() : "");
            $("#" + _param["idDes"] + "-middlename").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-middlename-hidden").val() : "");
            $("#" + _param["idDes"] + "-lastname").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-lastname-hidden").val() : "");
            $("#" + _param["idDes"] + "-firstnameen").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-firstnameen-hidden").val() : "");
            $("#" + _param["idDes"] + "-middlenameen").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-middlenameen-hidden").val() : "");
            $("#" + _param["idDes"] + "-lastnameen").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-lastnameen-hidden").val() : "");
            Util.checkSetValue({
                id: (_param["idDes"] + "-alive"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-alive-hidden").val() : "")
            });
            $("#" + _param["idDes"] + "-birthdate").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-birthdate-hidden").val() : "");
            $("#" + _param["idDes"] + "-age").html(_param["copy"] == true ? $("#" + _param["idSrc"] + "-age-hidden").val() : "");
            Util.comboboxSetValue({
                id: ("#" + _param["idDes"] + "-birthplace"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-birthplace-hidden").val() : "0")
            });
            Util.comboboxSetValue({
                id: ("#" + _param["idDes"] + "-nationality"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-nationality-hidden").val() : "0")
            });
            Util.comboboxSetValue({
                id: ("#" + _param["idDes"] + "-race"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-race-hidden").val() : "0")
            });
            Util.comboboxSetValue({
                id: ("#" + _param["idDes"] + "-religion"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-religion-hidden").val() : "0")
            });
            Util.checkSetValue({
                id: (_param["idDes"] + "-bloodgroup"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-bloodgroup-hidden").val() : "")
            });
            Util.checkSetValue({
                id: (_param["idDes"] + "-maritalstatus"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-maritalstatus-hidden").val() : "")
            });
            Util.checkSetValue({
                id: (_param["idDes"] + "-educationalbackgroundperson"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-educationalbackgroundperson-hidden").val() : "")
            });
        },
        copyAddress: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["copy"] = (_param["copy"] == undefined || _param["copy"] == "" ? false : _param["copy"]);
            _param["idSrc"] = (_param["idSrc"] == undefined ? "" : _param["idSrc"]);
            _param["idDes"] = (_param["idDes"] == undefined ? "" : _param["idDes"]);

            Util.comboboxSetValue({
                id: ("#" + _param["idDes"] + "-country"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-country-hidden").val() : "0")
            });
            Util.tut.setSelectDefaultCombobox({
                id: ("#" + _param["idDes"] + "-province"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-province-hidden").val() : "0")
            }, function () {
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + _param["idDes"] + "-district"),
                    value: (_param["copy"] == true ? ($("#" + _param["idSrc"] + "-district-hidden").val() != "0" ? ($("#" + _param["idSrc"] + "-district-hidden").val() + ";" + $("#" + _param["idSrc"] + "-postalcodedistrict-hidden").val()) : "0") : "0")
                }, function () {
                    Util.tut.setSelectDefaultCombobox({
                        id: ("#" + _param["idDes"] + "-subdistrict"),
                        value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-subdistrict-hidden").val() : "0")
                    }, function () {
                        $("#" + _param["idDes"] + "-postalcode").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-postalcode-hidden").val() : "");
                    });
                });
            });

            $("#" + _param["idDes"] + "-village").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-village-hidden").val() : "");
            $("#" + _param["idDes"] + "-addressnumber").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-addressnumber-hidden").val() : "");
            $("#" + _param["idDes"] + "-villageno").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-villageno-hidden").val() : "");
            $("#" + _param["idDes"] + "-lanealley").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-lanealley-hidden").val() : "");
            $("#" + _param["idDes"] + "-road").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-road-hidden").val() : "");
            $("#" + _param["idDes"] + "-phonenumber").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-phonenumber-hidden").val() : "");
            $("#" + _param["idDes"] + "-mobilenumber").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-mobilenumber-hidden").val() : "");
            $("#" + _param["idDes"] + "-faxnumber").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-faxnumber-hidden").val() : "");
        },
        copyWork: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["copy"] = (_param["copy"] == undefined || _param["copy"] == "" ? false : _param["copy"]);
            _param["idSrc"] = (_param["idSrc"] == undefined ? "" : _param["idSrc"]);
            _param["idDes"] = (_param["idDes"] == undefined ? "" : _param["idDes"]);

            Util.comboboxSetValue({
                id: ("#" + _param["idDes"] + "-occupation"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-occupation-hidden").val() : "0")
            });
            Util.comboboxSetValue({
                id: ("#" + _param["idDes"] + "-agency"),
                value: (_param["copy"] == true ? $("#" + _param["idSrc"] + "-agency-hidden").val() : "0")
            });
            Util.checkSetValue({
                id: (_param["idDes"] + "-agencyother"),
                value: (_param["copy"] == true ? ($("#" + _param["idSrc"] + "-agencyother-hidden").val().length > 0 ? "0" : "") : "")
            });
            $("#" + _param["idDes"] + "-agencyotherdetail").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-agencyother-hidden").val() : "");
            Util.setInputOtherOnCheck({
                id: (_param["idDes"] + "-agencyother"),
                value: "0",
                idCombobox: ("#" + _param["idDes"] + "-agency"),
                idTextboxOther: ("#" + _param["idDes"] + "-agencyotherdetail")
            });
            $("#" + _param["idDes"] + "-workplace").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-workplace-hidden").val() : "");
            $("#" + _param["idDes"] + "-workplaceposition").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-workplaceposition-hidden").val() : "");
            $("#" + _param["idDes"] + "-workplacetelephone").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-workplacetelephone-hidden").val() : "");
            $("#" + _param["idDes"] + "-workplacesalary").val(_param["copy"] == true ? $("#" + _param["idSrc"] + "-workplacesalary-hidden").val() : "");
        },
        studentrecords: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsStudentRecordsAddUpdate.toLowerCase(),
            nationality: "",
            initMain: function () {
                var _this = Util.tut.tsr;

                $("#" + _this.idSectionAddUpdate + "-studentcode").html($("#" + this.idSectionAddUpdate + "-studentcode-hidden").val());
                $("#infobar-" + Util.tut.subjectSectionAdministrationStudentRecords.toLowerCase() + " .operator-save").hide();        

                MSent.consentField.religion.isConsent = ($("#" + this.idSectionAddUpdate + "-consentfield").val().length > 0 ? (MSent.consentField.religion.name.indexOf($("#" + this.idSectionAddUpdate + "-consentfield").val()) >= 0 ? true : false) : false);
                if ($("#" + this.idSectionAddUpdate + "-isprogramcontract").val() == "Y")
                    _this.isProgramContract = true;

                this.resetMain();
            },
            resetMain: function () {
                Util.dialogMessageClose();
                Util.gotoTopElement();

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _idContent = new Array();
                var _i = 0;

                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsPersonal
                });
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsAddress
                });
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsEducation
                });
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsTalent
                });
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsHealthy
                });
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsWork
                });
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsFinancial
                });
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsFamily
                });

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

                this.nationality = $("#" + this.idSectionAddUpdate + "-nationality-hidden").val();
            }
        },
        personal: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsPersonalAddUpdate.toLowerCase(),
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _widthCombobox = 426;
                var _heightCombobox = 29;
                
                $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(418);
                $("#" + _this3.idSectionAddUpdate + "-idcard").attr("maxlength", "20");
                //$("#" + _this3.idSectionAddUpdate + "-brotherhood, #" + _this3.idSectionAddUpdate + "-childhood, #" + _this3.idSectionAddUpdate + "-studyhood").width(50).attr("maxlength", "2");
                Util.initCalendarFromTo({
                    idFrom: ("#" + _this3.idSectionAddUpdate + "-idcardissuedate"),
                    idTo: ("#" + _this3.idSectionAddUpdate + "-idcardexpirydate"),
                    yearRange: "-10:+10"
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-titleprefix"),
                    width: _widthCombobox,
                    height: _heightCombobox
                });               
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-birthplace"),
                    width: _widthCombobox,
                    height: _heightCombobox
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-nationality"),
                    width: _widthCombobox,
                    height: _heightCombobox
                });
                /*
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-race"),
                    width: _widthCombobox,
                    height: _heightCombobox
                });       
                */
                $("#" + _this3.idSectionAddUpdate + "-race-content").addClass("hidden");

                if (MSent.consentField.religion.isConsent) {
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-religion"),
                        width: _widthCombobox,
                        height: _heightCombobox
                    });
                }
                else
                    $("#" + _this3.idSectionAddUpdate + "-religion-content").addClass("hidden");

                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-brotherhood"),
                    width: 185,
                    height: _heightCombobox
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-childhood"),
                    width: 185,
                    height: _heightCombobox
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-studyhood"),
                    width: 185,
                    height: _heightCombobox
                });
                Util.initCalendar({
                    id: ("#" + _this3.idSectionAddUpdate + "-birthdate"),
                    yearRange: "-70:-0"
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-gender")
                });
                /*
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-bloodgroup")
                });
                */
                $("#" + _this3.idSectionAddUpdate + "-bloodgroup-content").addClass("hidden");
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-maritalstatus")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-educationalbackgroundperson")
                });                

                $("input:text").keypress(function (_e) {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-idcard"))
                        return Util.blockNonEnglishAndNumeric(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-firstname"))
                        return Util.blockEnglish(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-middlename"))
                        return Util.blockEnglish(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-lastname"))
                        return Util.blockEnglish(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-firstnameen"))
                        return Util.blockNonEnglish(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-middlenameen"))
                        return Util.blockNonEnglish(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-lastnameen"))
                        return Util.blockNonEnglish(this, _e);

                    /*
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-brotherhood"))
                        return Util.blockNonNumbers(this, _e, false, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-childhood"))
                        return Util.blockNonNumbers(this, _e, false, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-studyhood"))
                        return Util.blockNonNumbers(this, _e, false, false);
                    */
                });
                
                $("input:text").focusout(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-idcard")) {
                        $(this).val($(this).val().toUpperCase());
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-firstnameen")) {
                        $(this).val($(this).val().toUpperCase());
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-middlenameen")) {
                        $(this).val($(this).val().toUpperCase());
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-lastnameen")) {
                        $(this).val($(this).val().toUpperCase());
                    }

                    /*
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-brotherhood")) {
                        Util.addCommas($(this).attr("id"), 0);
                        $(this).val(Util.delCommas($(this).attr("id")));
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-childhood")) {
                        Util.addCommas($(this).attr("id"), 0);
                        $(this).val(Util.delCommas($(this).attr("id")));
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-studyhood")) {
                        Util.addCommas($(this).attr("id"), 0);
                        $(this).val(Util.delCommas($(this).attr("id")));
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                     }
                    */
                });
                
                $("input:text").change(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-birthdate"))
                        Util.calAge({
                            birthdate: $(this).val()
                        }, function (_result) {
                            $("#" + _this3.idSectionAddUpdate + "-age").html(_result);
                        });
                });

                $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                    if ($(this).hasClass("button-save") == true)
                        _this2.confirmSave({
                            page: _param["page"]
                        });

                    if ($(this).hasClass("button-undo") == true)
                        _this3.resetMain();
                });

                _this3.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _value;
                var _valueArray;
                var _valueSubArray;
                var _valueSubSubArray;
                var _i = 0;
                var _j = 0;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });

                $("#" + _this3.idSectionAddUpdate + "-idcard").val($("#" + _this3.idSectionAddUpdate + "-idcard-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-idcardissuedate").val($("#" + _this3.idSectionAddUpdate + "-idcardissuedate-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-idcardexpirydate").val($("#" + _this3.idSectionAddUpdate + "-idcardexpirydate-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-titleprefix"),
                    value: ($("#" + _this3.idSectionAddUpdate + "-titleprefix-hidden").val() != "0" ? ($("#" + _this3.idSectionAddUpdate + "-titleprefix-hidden").val() + ";" + $("#" + _this3.idSectionAddUpdate + "-gendertitleprefix-hidden").val()) : "0")
                });
                $("#" + _this3.idSectionAddUpdate + "-firstname").val($("#" + _this3.idSectionAddUpdate + "-firstname-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-middlename").val($("#" + _this3.idSectionAddUpdate + "-middlename-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-lastname").val($("#" + _this3.idSectionAddUpdate + "-lastname-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-firstnameen").val($("#" + _this3.idSectionAddUpdate + "-firstnameen-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-middlenameen").val($("#" + _this3.idSectionAddUpdate + "-middlenameen-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-lastnameen").val($("#" + _this3.idSectionAddUpdate + "-lastnameen-hidden").val());
                _this2.setGenderByTitlePrefix({
                    idTitlePrefix: ("#" + _this3.idSectionAddUpdate + "-titleprefix"),
                    idGender: (_this3.idSectionAddUpdate + "-gender"),
                    valueGender: $("#" + _this3.idSectionAddUpdate + "-gender-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-birthdate").val($("#" + _this3.idSectionAddUpdate + "-birthdate-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-age").html($("#" + _this3.idSectionAddUpdate + "-age-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-birthplace"),
                    value: $("#" + _this3.idSectionAddUpdate + "-birthplace-hidden").val()
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-nationality"),
                    value: $("#" + _this3.idSectionAddUpdate + "-nationality-hidden").val()
                });
                /*
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-race"),
                    value: $("#" + _this3.idSectionAddUpdate + "-race-hidden").val()
                });
                */
                if (MSent.consentField.religion.isConsent) {
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-religion"),
                        value: $("#" + _this3.idSectionAddUpdate + "-religion-hidden").val()
                    });
                }
                /*
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-bloodgroup"),
                    value: $("#" + _this3.idSectionAddUpdate + "-bloodgroup-hidden").val()
                });
                */
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-maritalstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-maritalstatus-hidden").val()
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-educationalbackgroundperson"),
                    value: $("#" + _this3.idSectionAddUpdate + "-educationalbackgroundperson-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-email").val($("#" + _this3.idSectionAddUpdate + "-email-hidden").val());
                //$("#" + _this3.idSectionAddUpdate + "-brotherhood").val($("#" + _this3.idSectionAddUpdate + "-brotherhood-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-brotherhood"),
                    value: ($("#" + _this3.idSectionAddUpdate + "-brotherhood-hidden").val()).replace(".00", "")
                });
                //$("#" + _this3.idSectionAddUpdate + "-childhood").val($("#" + _this3.idSectionAddUpdate + "-childhood-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-childhood"),
                    value: ($("#" + _this3.idSectionAddUpdate + "-childhood-hidden").val()).replace(".00", "")
                });
                //$("#" + _this3.idSectionAddUpdate + "-studyhood").val($("#" + _this3.idSectionAddUpdate + "-studyhood-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-studyhood"),
                    value: ($("#" + _this3.idSectionAddUpdate + "-studyhood-hidden").val()).replace(".00", "")
                }); 
            },
            validateSave: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _error = new Array();
                var _i = 0;

                if ($("#" + _this3.idSectionAddUpdate + "-idcard").val().length == 0) {
                    _error[_i] = ("กรุณาใส่เลขประจำตัวประชาชนหรือเลขหนังสือเดินทาง;Please enter identification number or passport no.;" + _this3.idSectionAddUpdate + "-idcard-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-idcardissuedate").val().length == 0) {
                    _error[_i] = ("กรุณาใส่วันออกบัตรประจำตัวประชาชนหรือหนังสือเดินทาง;Please enter date of issue id card or passport.;" + _this3.idSectionAddUpdate + "-idcard-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-idcardexpirydate").val().length == 0) {
                    _error[_i] = ("กรุณาใส่วันหมดอายุบัตรประจำตัวประชาชนหรือหนังสือเดินทาง;Please enter date of expiry id card or passport.;" + _this3.idSectionAddUpdate + "-idcard-content");
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-titleprefix") == "0") {
                    _error[_i] = ("กรุณาเลือกคำนำหน้า;Please select title.;" + _this3.idSectionAddUpdate + "-titleprefix-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-firstname").val().length == 0) {
                    _error[_i] = ("กรุณาใส่ชื่อ;Please enter first name.;" + _this3.idSectionAddUpdate + "-firstname-content");
                    _i++;
                }

                /*
                if ($("#" + _this3.idSectionAddUpdate + "-lastname").val().length == 0) {
                    _error[_i] = ("กรุณาใส่นามสกุล;Please enter last name.;" + _this3.idSectionAddUpdate + "-lastname-content");
                    _i++;
                }
                */

                if ($("#" + _this3.idSectionAddUpdate + "-firstnameen").val().length == 0) {
                    _error[_i] = ("กรุณาใส่ชื่อ ( ภาษาอังกฤษเท่านั้น );Please enter first name ( english only ).;" + _this3.idSectionAddUpdate + "-firstnameen-content");
                    _i++;
                }

                /*
                if ($("#" + _this3.idSectionAddUpdate + "-lastnameen").val().length == 0) {
                    _error[_i] = ("กรุณาใส่นามสกุล ( ภาษาอังกฤษเท่านั้น );Please enter last name ( english only ).;" + _this3.idSectionAddUpdate + "-lastnameen-content");
                    _i++;
                }
                */

                if ($("input[name=" + _this3.idSectionAddUpdate + "-gender]:radio").is(":checked") == false) {
                    _error[_i] = ("กรุณาเลือกเพศ;Please select gender.;" + _this3.idSectionAddUpdate + "-gender-content");
                    _i++;
                }
                
                if ($("#" + _this3.idSectionAddUpdate + "-birthdate").val().length == 0) {
                    _error[_i] = ("กรุณาใส่วันเดือนปีเกิด;Please enter birthdate.;" + _this3.idSectionAddUpdate + "-birthdate-content");
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-birthplace") == "0") {
                    _error[_i] = ("กรุณาเลือกประเทศบ้านเกิด;Please select country of birthplace.;" + _this3.idSectionAddUpdate + "-birthplace-content");
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-nationality") == "0") {
                    _error[_i] = ("กรุณาเลือกสัญชาติ;Please select nationality.;" + _this3.idSectionAddUpdate + "-nationality-content");
                    _i++;
                }

                /*
                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-race") == "0") {
                    _error[_i] = ("กรุณาเลือกเชื้อชาติ;Please select race.;" + _this3.idSectionAddUpdate + "-race-content");
                    _i++; }
                */

                if (MSent.consentField.religion.isConsent) {
                    if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-religion") == "0") {
                        _error[_i] = ("กรุณาเลือกศาสนา;Please select religion.;" + _this3.idSectionAddUpdate + "-religion-content");
                        _i++;
                    }
                }

                if ($("input[name=" + _this3.idSectionAddUpdate + "-maritalstatus]:radio").is(":checked") == false) {
                    _error[_i] = ("กรุณาเลือกสถานภาพทางการสมรส;Please select marital status.;" + _this3.idSectionAddUpdate + "-maritalstatus-content");
                    _i++;
                }

                if ($("input[name=" + _this3.idSectionAddUpdate + "-educationalbackgroundperson]:radio").is(":checked") == false) {
                    _error[_i] = ("กรุณาเลือกวุฒิการศึกษา;Please select educational background.;" + _this3.idSectionAddUpdate + "-educationalbackgroundperson-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-email").val().length == 0) {
                    _error[_i] = ("กรุณาใส่อีเมล์;Please enter email address.;" + _this3.idSectionAddUpdate + "-email-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-email").val().length > 0 && Util.isEmail($("#" + _this3.idSectionAddUpdate + "-email").val()) == false) {
                    _error[_i] = ("กรุณาใส่อีเมล์ให้ถูกต้อง;Invalid email address format specified.;" + _this3.idSectionAddUpdate + "-email-content");
                    _i++;
                }

                /*
                if ($("#" + _this3.idSectionAddUpdate + "-brotherhood").val().length == 0 && ($("#" + _this3.idSectionAddUpdate + "-childhood").val().length > 0 || $("#" + _this3.idSectionAddUpdate + "-studyhood").val().length > 0)) {
                    _error[_i] = ("กรุณาใส่จำนวนพี่น้องทั้งหมด ( รวมตัวเอง );Please enter number of siblings ( including myself ).;" + _this3.idSectionAddUpdate + "-brotherhood-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-brotherhood").val().length > 0 && $("#" + _this3.idSectionAddUpdate + "-childhood").val().length > 0 && parseInt($("#" + _this3.idSectionAddUpdate + "-childhood").val()) > parseInt($("#" + _this3.idSectionAddUpdate + "-brotherhood").val())) {
                    _error[_i] = ("กรุณาใส่นักศึกษาเป็นบุตรคนที่ให้ถูกต้อง;Invalid sequence child.;" + _this3.idSectionAddUpdate + "-childhood-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-brotherhood").val().length > 0 && $("#" + _this3.idSectionAddUpdate + "-studyhood").val().length > 0 && parseInt($("#" + _this3.idSectionAddUpdate + "-studyhood").val()) > parseInt($("#" + _this3.idSectionAddUpdate + "-brotherhood").val())) {
                    _error[_i] = ("กรุณาใส่จำนวนพี่น้องที่กำลังศึกษาอยู่ ( รวมตัวเอง ) ให้ถูกต้อง;Invalid number of siblings still studying ( including myself ).;" + _this3.idSectionAddUpdate + "-studyhood-content");
                    _i++;
                }
                */

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-brotherhood") == "0" && (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-childhood") != "0" || Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-studyhood") != 0)) {
                    _error[_i] = ("กรุณาใส่จำนวนพี่น้องทั้งหมด ( รวมตัวเอง );Please enter number of siblings ( including myself ).;" + _this3.idSectionAddUpdate + "-brotherhood-content");
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-brotherhood") != "0" && Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-childhood") != "0" && parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-childhood")) > parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-brotherhood"))) {
                    _error[_i] = ("กรุณาใส่นักศึกษาเป็นบุตรคนที่ให้ถูกต้อง;Invalid sequence child.;" + _this3.idSectionAddUpdate + "-childhood-content");
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-brotherhood") != "0" && Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-studyhood") != "0" && parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-studyhood")) > parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-brotherhood"))) {
                    _error[_i] = ("กรุณาใส่จำนวนพี่น้องที่กำลังศึกษาอยู่ ( รวมตัวเอง ) ให้ถูกต้อง;Invalid number of siblings still studying ( including myself ).;" + _this3.idSectionAddUpdate + "-studyhood-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
        },
        address: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsAddressAddUpdate.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                
                $("#" + _this3.idSectionAddUpdate + "-content").css({
                    "padding-top": $("#" + _this3.idSectionAddUpdate + "-menu.tabbar").outerHeight()
                });
                _this2.initMenu({
                    id: ("#" + _this3.idSectionAddUpdate + "-menu-content"),
                    idContent: ("#" + _this3.idSectionAddUpdate + "-content"),
                    classActive: "tab-active",
                    classNoActive: "tab-noactive"
                });
            },
            permanentaddress: {
                idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsAddressPermanentAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate.address;

                    _this2.initMainSection({
                        page: _param["page"],
                        this: this
                    });
                }
            },                
            currentaddress: {
                idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsAddressCurrentAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate.address;

                    _this2.initMainSection({
                        page: _param["page"],
                        this: this
                    });
                }
            },
            initMainSection: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                $("#" + _param["this"].idSectionAddUpdate + "-form .form-content .inputbox").width(418);
                $("#" + _param["this"].idSectionAddUpdate + "-postalcode").attr("maxlength", "10");
                Util.initCombobox({
                    id: ("#" + _param["this"].idSectionAddUpdate + "-country"),
                    width: 426,
                    height: 29
                });                

                $("input:text").keypress(function (_e) {
                    if ($(this).attr("id") == (_param["this"].idSectionAddUpdate + "-postalcode"))
                        return Util.blockNonZipPostalCode(this, _e);

                    if ($(this).attr("id") == (_param["this"].idSectionAddUpdate + "-phonenumber"))
                        return Util.blockNonPhoneNumber(this, _e, false, false);

                    if ($(this).attr("id") == (_param["this"].idSectionAddUpdate + "-mobilenumber"))
                        return Util.blockNonPhoneNumber(this, _e, false, false);

                    if ($(this).attr("id") == (_param["this"].idSectionAddUpdate + "-faxnumber"))
                        return Util.blockNonPhoneNumber(this, _e, false, false);
                });

                $("input:text").focusout(function () {
                    if ($(this).attr("id") == (_param["this"].idSectionAddUpdate + "-postalcode")) {
                        $(this).val($(this).val().toUpperCase());
                    }
                });
                
                $("#" + _param["this"].idSectionAddUpdate + "-form .button .click-button").click(function () {
                    if ($(this).hasClass("button-copy") == true)
                        _this2.copyAddress({
                            copy: true,
                            idSrc: _this3.permanentaddress.idSectionAddUpdate,
                            idDes: _param["this"].idSectionAddUpdate
                        });

                    if ($(this).hasClass("button-save") == true)
                        _this2.confirmSave({
                            page: _param["page"]
                        });

                    if ($(this).hasClass("button-undo") == true)
                        _this3.resetMain({
                            this: _param["this"]
                        });
                });
                
                _this3.resetMain({
                    this: _param["this"]
                });
            },
            resetMain: function (_param) {
                _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_param["this"].idSectionAddUpdate + "-form")
                });

                _this2.copyAddress({
                    copy: true,
                    idSrc: _param["this"].idSectionAddUpdate,
                    idDes: _param["this"].idSectionAddUpdate
                });
            },
            validateSave: function (_param) {
                _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _error = new Array();
                var _i = 0;

                if (Util.comboboxGetValue("#" + _param["this"].idSectionAddUpdate + "-country") == "0") {
                    _error[_i] = ("กรุณาเลือกประเทศ;Please select country.;" + _param["this"].idSectionAddUpdate + "-country-content");
                    _i++;
                }

                if (_this2.studentrecords.nationality == "ไทย") {
                    if (Util.comboboxGetValue("#" + _param["this"].idSectionAddUpdate + "-province") == "0") {
                        _error[_i] = ("กรุณาเลือกจังหวัด;Please select province.;" + _param["this"].idSectionAddUpdate + "-province-content");
                        _i++;
                    }

                    if (Util.comboboxGetValue("#" + _param["this"].idSectionAddUpdate + "-district") == "0") {
                        _error[_i] = ("กรุณาเลือกอำเภอ / เขต;Please select district.;" + _param["this"].idSectionAddUpdate + "-district-content");
                        _i++;
                    }

                    if (Util.comboboxGetValue("#" + _param["this"].idSectionAddUpdate + "-subdistrict") == "0") {
                        _error[_i] = ("กรุณาเลือกตำบล / แขวง;Please select sub-district.;" + _param["this"].idSectionAddUpdate + "-subdistrict-content");
                        _i++;
                    }

                    if ($("#" + _param["this"].idSectionAddUpdate + "-postalcode").val().length == 0) {
                        _error[_i] = ("กรุณาใส่รหัสไปรษณีย์;Please enter postal code.;" + _param["this"].idSectionAddUpdate + "-postalcode-content");
                        _i++;
                    }
                }

                if ($("#" + _param["this"].idSectionAddUpdate + "-addressnumber").val().length == 0) {
                    _error[_i] = ("กรุณาใส่บ้านเลขที่;Please enter address number.;" + _param["this"].idSectionAddUpdate + "-addressnumber-content");
                    _i++;
                }

                if ($("#" + _param["this"].idSectionAddUpdate + "-phonenumber").val().length == 0 && $("#" + _param["this"].idSectionAddUpdate + "-mobilenumber").val().length == 0) {
                    _error[_i] = ("กรุณาใส่เบอร์โทรศัพท์บ้านหรือเบอร์โทรศัพท์มือถือ;Please enter phone number or mobile number.;" + _param["this"].idSectionAddUpdate + "-phonenumber-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            }
        },
        education: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsEducationAddUpdate.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                $("#" + _this3.idSectionAddUpdate + "-content").css({
                    "padding-top": $("#" + _this3.idSectionAddUpdate + "-menu.tabbar").outerHeight()
                });
                _this2.initMenu({
                    id: ("#" + _this3.idSectionAddUpdate + "-menu-content"),
                    idContent: ("#" + _this3.idSectionAddUpdate + "-content"),
                    classActive: "tab-active",
                    classNoActive: "tab-noactive"
                });
            },
            primaryschool: {
                idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsEducationPrimarySchoolAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;
                    
                    $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(418);
                    //$("#" + _this3.idSectionAddUpdate + "-yearattended, #" + _this3.idSectionAddUpdate + "-yeargraduate, #" + _this3.idSectionAddUpdate + "-gpa").width(50).attr("maxlength", "4");
                    $("#" + _this3.idSectionAddUpdate + "-gpa").width(50).attr("maxlength", "4");
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-institutecountry"),
                        width: 426,
                        height: 29
                    });
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-yearattended"),
                        width: 185,
                        height: 29
                    });
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-yeargraduate"),
                        width: 185,
                        height: 29
                    });
                        
                    $("input:text").keyup(function () {
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa"))
                            return Util.extractNumber(this, 2, false);
                    });
                        
                    $("input:text").keypress(function (_e) {
                        /*
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yearattended"))
                            return Util.blockNonNumbers(this, _e, false, false);

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yeargraduate"))
                            return Util.blockNonNumbers(this, _e, false, false);
                        */

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa"))
                            return Util.blockNonNumbers(this, _e, true, false);
                    });
                        
                    $("input:text").focusout(function () {
                        /*
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yearattended")) {
                            Util.addCommas($(this).attr("id"), 0);
                            $(this).val(Util.delCommas($(this).attr("id")));
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                        
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yeargraduate")) {
                            Util.addCommas($(this).attr("id"), 0);
                            $(this).val(Util.delCommas($(this).attr("id")));
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                        */

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa")) {
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val($(this).val().length > 4 ? $(this).val().substring($(this).val().length, $(this).val().length - 4) : $(this).val());
                            $(this).val(Util.delCommas($(this).attr("id")));
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                    });
                    
                    $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-save") == true)
                            _this2.confirmSave({
                                page: _param["page"]
                            });

                        if ($(this).hasClass("button-undo") == true)
                            _this3.resetMain();
                    });

                    _this3.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    Util.dialogMessageClose();
                    Util.gotoTopElement();
                    Util.resetForm({
                        id: (_this3.idSectionAddUpdate + "-form")
                    });
                        
                    $("#" + _this3.idSectionAddUpdate + "-institutename").val($("#" + _this3.idSectionAddUpdate + "-institutename-hidden").val());
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-institutecountry"),
                        value: $("#" + _this3.idSectionAddUpdate + "-institutecountry-hidden").val()
                    });
                    Util.tut.setSelectDefaultCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-instituteprovince"),
                        value: $("#" + _this3.idSectionAddUpdate + "-instituteprovince-hidden").val()
                    }, function () {
                    });
                    /*
                    $("#" + _this3.idSectionAddUpdate + "-yearattended").val($("#" + _this3.idSectionAddUpdate + "-yearattended-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-yeargraduate").val($("#" + _this3.idSectionAddUpdate + "-yeargraduate-hidden").val());
                    */
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-yearattended"),
                        value: $("#" + _this3.idSectionAddUpdate + "-yearattended-hidden").val()
                    });
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-yeargraduate"),
                        value: $("#" + _this3.idSectionAddUpdate + "-yeargraduate-hidden").val()
                    });
                    $("#" + _this3.idSectionAddUpdate + "-gpa").val($("#" + _this3.idSectionAddUpdate + "-gpa-hidden").val());
                },
                validateSave: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;
                    var _error = new Array();
                    var _i = 0;

                    return (_i > 0 ? false : true);
                }
            },
            juniorhighschool: {
                idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(418);
                    //$("#" + _this3.idSectionAddUpdate + "-yearattended, #" + _this3.idSectionAddUpdate + "-yeargraduate, #" + _this3.idSectionAddUpdate + "-gpa").width(50).attr("maxlength", "4");
                    $("#" + _this3.idSectionAddUpdate + "-gpa").width(50).attr("maxlength", "4");
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-institutecountry"),
                        width: 426,
                        height: 29
                    });                    
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-yearattended"),
                        width: 185,
                        height: 29
                    });
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-yeargraduate"),
                        width: 185,
                        height: 29
                    });

                    $("input:text").keyup(function () {
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa"))
                            return Util.extractNumber(this, 2, false);
                    });
                        
                    $("input:text").keypress(function (_e) {
                        /*
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yearattended"))
                            return Util.blockNonNumbers(this, _e, false, false);

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yeargraduate"))
                            return Util.blockNonNumbers(this, _e, false, false);
                        */

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa"))
                            return Util.blockNonNumbers(this, _e, true, false);
                    });
                        
                    $("input:text").focusout(function () {
                        /*
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yearattended"))  {
                            Util.addCommas($(this).attr("id"), 0);
                            $(this).val(Util.delCommas($(this).attr("id")));
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yeargraduate")) {
                            Util.addCommas($(this).attr("id"), 0);
                            $(this).val(Util.delCommas($(this).attr("id")));
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                        */

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa")) {
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val($(this).val().length > 4 ? $(this).val().substring($(this).val().length, $(this).val().length - 4) : $(this).val());
                            $(this).val(Util.delCommas($(this).attr("id")));
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                    });

                    $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-save") == true)
                            _this2.confirmSave({
                                page: _param["page"]
                            });

                        if ($(this).hasClass("button-undo") == true)
                            _this3.resetMain();
                    });

                    _this3.resetMain();  
                },
                resetMain: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    Util.dialogMessageClose();
                    Util.gotoTopElement();
                    Util.resetForm({
                        id: (_this3.idSectionAddUpdate + "-form")
                    });
                        
                    $("#" + _this3.idSectionAddUpdate + "-institutename").val($("#" + _this3.idSectionAddUpdate + "-institutename-hidden").val());
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-institutecountry"),
                        value: $("#" + _this3.idSectionAddUpdate + "-institutecountry-hidden").val()
                    });
                    Util.tut.setSelectDefaultCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-instituteprovince"),
                        value: $("#" + _this3.idSectionAddUpdate + "-instituteprovince-hidden").val()
                    }, function () {
                    });
                    //$("#" + _this3.idSectionAddUpdate + "-yearattended").val($("#" + _this3.idSectionAddUpdate + "-yearattended-hidden").val());
                    //$("#" + _this3.idSectionAddUpdate + "-yeargraduate").val($("#" + _this3.idSectionAddUpdate + "-yeargraduate-hidden").val());
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-yearattended"),
                        value: $("#" + _this3.idSectionAddUpdate + "-yearattended-hidden").val()
                    });
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-yeargraduate"),
                        value: $("#" + _this3.idSectionAddUpdate + "-yeargraduate-hidden").val()
                    });
                    $("#" + _this3.idSectionAddUpdate + "-gpa").val($("#" + _this3.idSectionAddUpdate + "-gpa-hidden").val());
                },
                validateSave: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;
                    var _error = new Array();
                    var _i = 0;

                    return (_i > 0 ? false : true);
                }
            },
            highschool: {
                idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsEducationHighSchoolAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(418);
                    $("#" + _this3.idSectionAddUpdate + "-form .form-subcontent .inputbox").width(395);
                    $("#" + _this3.idSectionAddUpdate + "-studentid").width(200);
                    //$("#" + _this3.idSectionAddUpdate + "-yearattended, #" + _this3.idSectionAddUpdate + "-yeargraduate, #" + _this3.idSectionAddUpdate + "-gpa").width(50).attr("maxlength", "4");
                    $("#" + _this3.idSectionAddUpdate + "-gpa").width(50).attr("maxlength", "4");
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-institutecountry"),
                        width: 426,
                        height: 29
                    });
                    Util.initCheck({
                        id: (_this3.idSectionAddUpdate + "-educationalmajor")
                    });
                    Util.initCheck({
                        id: (_this3.idSectionAddUpdate + "-educationalbackground")
                    });
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-yearattended"),
                        width: 185,
                        height: 29
                    });
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-yeargraduate"),
                        width: 185,
                        height: 29
                    });
                    
                    $("input:text").keyup(function () {
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa"))
                            return Util.extractNumber(this, 2, false);
                    });

                    $("input:text").keypress(function (_e) {
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-studentid"))
                            return Util.blockNonEnglishAndNumeric(this, _e);

                        /*
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yearattended"))
                            return Util.blockNonNumbers(this, _e, false, false);

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yeargraduate"))
                            return Util.blockNonNumbers(this, _e, false, false);
                        */

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa"))
                            return Util.blockNonNumbers(this, _e, true, false);
                    });

                    $("input:text").focusout(function () {
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-studentid")) {
                            $(this).val($(this).val().toUpperCase());
                        }

                        /*
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yearattended")) {
                            Util.addCommas($(this).attr("id"), 0);
                            $(this).val(Util.delCommas($(this).attr("id")));
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-yeargraduate")) {
                            Util.addCommas($(this).attr("id"), 0);
                            $(this).val(Util.delCommas($(this).attr("id")));
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                        */

                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gpa")) {
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val($(this).val().length > 4 ? $(this).val().substring($(this).val().length, $(this).val().length - 4) : $(this).val());
                            $(this).val(Util.delCommas($(this).attr("id")));
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                    });

                    $(".radio").on("ifChecked", function () {
                        if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-educationalmajor"))
                            Util.setInputOtherOnCheck({
                                id: $(this).attr("name"), 
                                value: "0",
                                idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-educationalmajorother")
                            });
                    });

                    $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-save") == true)
                            _this2.confirmSave({
                                page: _param["page"]
                            });

                        if ($(this).hasClass("button-undo") == true)
                            _this3.resetMain();
                    });

                    _this3.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    Util.dialogMessageClose();
                    Util.gotoTopElement();
                    Util.resetForm({
                        id: (_this3.idSectionAddUpdate + "-form")
                    });

                    $("#" + _this3.idSectionAddUpdate + "-institutename").val($("#" + _this3.idSectionAddUpdate + "-institutename-hidden").val());
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-institutecountry"),
                        value: $("#" + _this3.idSectionAddUpdate + "-institutecountry-hidden").val()
                    });
                    Util.tut.setSelectDefaultCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-instituteprovince"),
                        value: $("#" + _this3.idSectionAddUpdate + "-instituteprovince-hidden").val()
                    }, function () { });
                    $("#" + _this3.idSectionAddUpdate + "-studentid").val($("#" + _this3.idSectionAddUpdate + "-studentid-hidden").val());
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-educationalmajor"),
                        value: ($("#" + _this3.idSectionAddUpdate + "-educationalmajor-hidden").val().length > 0 || $("#" + _this3.idSectionAddUpdate + "-educationalmajorother-hidden").val().length == 0 ? $("#" + _this3.idSectionAddUpdate + "-educationalmajor-hidden").val() : "0")
                    });
                    $("#" + _this3.idSectionAddUpdate + "-educationalmajorother").val($("#" + _this3.idSectionAddUpdate + "-educationalmajorother-hidden").val());
                    Util.setInputOtherOnCheck({
                        id: (_this3.idSectionAddUpdate + "-educationalmajor"),
                        value: "0",
                        idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-educationalmajorother")
                    });
                    //$("#" + _this3.idSectionAddUpdate + "-yearattended").val($("#" + _this3.idSectionAddUpdate + "-yearattended-hidden").val());
                    //$("#" + _this3.idSectionAddUpdate + "-yeargraduate").val($("#" + _this3.idSectionAddUpdate + "-yeargraduate-hidden").val());
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-yearattended"),
                        value: $("#" + _this3.idSectionAddUpdate + "-yearattended-hidden").val()
                    });
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-yeargraduate"),
                        value: $("#" + _this3.idSectionAddUpdate + "-yeargraduate-hidden").val()
                    });
                    $("#" + _this3.idSectionAddUpdate + "-gpa").val($("#" + _this3.idSectionAddUpdate + "-gpa-hidden").val());
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-educationalbackground"),
                        value: $("#" + _this3.idSectionAddUpdate + "-educationalbackground-hidden").val()
                    });
                },
                validateSave: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;
                    var _error = new Array();
                    var _i = 0;

                    if ($("#" + _this3.idSectionAddUpdate + "-institutename").val().length == 0) {
                        _error[_i] = ("กรุณาใส่ชื่อสถานศึกษาระดับมัธยมปลาย;Please enter high school name.;" + _this3.idSectionAddUpdate + "-institutename-content");
                        _i++;
                    }

                    if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-institutecountry") == "0") {
                        _error[_i] = ("กรุณาเลือกประเทศของสถานศึกษา;Please select country high school.;" + _this3.idSectionAddUpdate + "-institutecountry-content");
                        _i++;
                    }

                    if ($("input[name=" + _this3.idSectionAddUpdate + "-educationalmajor]:radio").is(":checked") == false) {
                        _error[_i] = ("กรุณาเลือกสายการเรียน;Please select major.;" + _this3.idSectionAddUpdate + "-educationalmajor-content");
                        _i++;
                    }

                    if (Util.checkGetValue(_this3.idSectionAddUpdate + "-educationalmajor") == "0" && $("#" + _this3.idSectionAddUpdate + "-educationalmajorother").val().length == 0) {
                        _error[_i] = ("กรุณาใส่สายการเรียน;Please enter other major.;" + _this3.idSectionAddUpdate + "-educationalmajor-content");
                        _i++;
                    }

                    if ($("input[name=" + _this3.idSectionAddUpdate + "-educationalbackground]:radio").is(":checked") == false) {
                        _error[_i] = ("กรุณาเลือกวุฒิการศึกษา;Please select educational background.;" + _this3.idSectionAddUpdate + "-educationalbackground-content");
                        _i++;
                    }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                }
            },
            university: {
                idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsEducationUniversityAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(418);
                    $("#" + _this3.idSectionAddUpdate + "-form .form-subcontent .inputbox").width(395);
                    //$("#" + _this3.idSectionAddUpdate + "-admissionranking").width(50).attr("maxlength", "2");
                    Util.initCheck({
                        id: (_this3.idSectionAddUpdate + "-educationalbackground")
                    });
                    Util.initCheck({
                        id: (_this3.idSectionAddUpdate + "-graduateby")
                    });
                    Util.initCheck({
                        id: (_this3.idSectionAddUpdate + "-entrancetime")
                    });
                    Util.initCheck({
                        id: (_this3.idSectionAddUpdate + "-studentis")
                    });
                    Util.initCheck({
                        id: (_this3.idSectionAddUpdate + "-entrancetype")
                    });
                    Util.initCheck({
                        id: (_this3.idSectionAddUpdate + "-entrancetype")
                    });
                    Util.initCombobox({
                        id: ("#" + _this3.idSectionAddUpdate + "-admissionranking"),
                        width: 185,
                        height: 29
                    });

                    $("input:text").keypress(function (_e) {
                        /*
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-admissionranking"))
                            return Util.blockNonNumbers(this, _e, false, false);
                        */
                    });

                    $("input:text").focusout(function () {
                        /*
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-admissionranking")) {
                            Util.addCommas($(this).attr("id"), 0);
                            $(this).val(Util.delCommas($(this).attr("id")));
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                        */
                    });

                    $(".radio").on("ifChecked", function () {
                        if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-graduateby"))
                            Util.setInputOtherOnCheck({
                                id: $(this).attr("name"),
                                value: "02",
                                idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-graduatebyinstitutename")
                            });

                        if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-studentis"))
                            Util.setInputOtherOnCheck({
                                id: $(this).attr("name"),
                                value: "02",
                                idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-studentisuniversity, #" + _this3.idSectionAddUpdate + "-studentisfaculty, #" + _this3.idSectionAddUpdate + "-studentisprogram")
                            });
                    });
                    
                    $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-save") == true)
                            _this2.confirmSave({
                                page: _param["page"]
                            });

                        if ($(this).hasClass("button-undo") == true)
                            _this3.resetMain();
                    });

                    _this3.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    Util.dialogMessageClose();
                    Util.gotoTopElement();
                    Util.resetForm({
                        id: (_this3.idSectionAddUpdate + "-form")
                    });

                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-educationalbackground"),
                        value: $("#" + _this3.idSectionAddUpdate + "-educationalbackground-hidden").val()
                    });
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-graduateby"),
                        value: $("#" + _this3.idSectionAddUpdate + "-graduateby-hidden").val()
                    });
                    $("#" + _this3.idSectionAddUpdate + "-graduatebyinstitutename").val($("#" + _this3.idSectionAddUpdate + "-graduatebyinstitutename-hidden").val());
                    Util.setInputOtherOnCheck({
                        id: (_this3.idSectionAddUpdate + "-graduateby"),
                        value: "02",
                        idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-graduatebyinstitutename")
                    });
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-entrancetime"),
                        value: $("#" + _this3.idSectionAddUpdate + "-entrancetime-hidden").val()
                    });
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-studentis"),
                        value: $("#" + _this3.idSectionAddUpdate + "-studentis-hidden").val()
                    });
                    $("#" + _this3.idSectionAddUpdate + "-studentisuniversity").val($("#" + _this3.idSectionAddUpdate + "-studentisuniversity-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-studentisfaculty").val($("#" + _this3.idSectionAddUpdate + "-studentisfaculty-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-studentisprogram").val($("#" + _this3.idSectionAddUpdate + "-studentisprogram-hidden").val());
                    Util.setInputOtherOnCheck({
                        id: (_this3.idSectionAddUpdate + "-studentis"),
                        value: "02",
                        idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-studentisuniversity, #" + _this3.idSectionAddUpdate + "-studentisfaculty, #" + _this3.idSectionAddUpdate + "-studentisprogram")
                    });
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-entrancetype"),
                        value: $("#" + _this3.idSectionAddUpdate + "-entrancetype-hidden").val()
                    });
                    //$("#" + _this3.idSectionAddUpdate + "-admissionranking").val($("#" + _this3.idSectionAddUpdate + "-admissionranking-hidden").val());
                    Util.comboboxSetValue({
                        id: ("#" + _this3.idSectionAddUpdate + "-admissionranking"),
                        value: $("#" + _this3.idSectionAddUpdate + "-admissionranking-hidden").val()
                    });
                },
                validateSave: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;
                    var _error = new Array();
                    var _i = 0;

                    if ($("input[name=" + _this3.idSectionAddUpdate + "-educationalbackground]:radio").is(":checked") == false) {
                        _error[_i] = ("กรุณาเลือกวุฒิการศึกษาขั้นสูงสุดก่อนเข้าม.มหิดล;Please select highest education prior to entering Mahidol University.;" + _this3.idSectionAddUpdate + "-educationalbackground-content");
                        _i++;
                    }

                    if ($("input[name=" + _this3.idSectionAddUpdate + "-graduateby]:radio").is(":checked") == false) {
                        _error[_i] = ("กรุณาเลือกวิธีที่สำเร็จการศึกษาขั้นสูงสุด;Please select how to graduated.;" + _this3.idSectionAddUpdate + "-graduateby-content");
                        _i++;
                    }

                    if (Util.checkGetValue(_this3.idSectionAddUpdate + "-graduateby") == "02" && $("#" + _this3.idSectionAddUpdate + "-graduatebyinstitutename").val().length == 0) {
                        _error[_i] = ("กรุณาใส่ชื่อสถานศึกษาที่สอบเทียบ;Please enter school name of informal education.;" + _this3.idSectionAddUpdate + "-graduateby-content");
                        _i++;
                    }

                    if ($("input[name=" + _this3.idSectionAddUpdate + "-entrancetime]:radio").is(":checked") == false) {
                        _error[_i] = ("กรุณาเลือกจำนวนครั้งที่สอบเข้าในระดับมหาวิทยาลัย;Please select number of university entrance exams.;" + _this3.idSectionAddUpdate + "-entrancetime-content");
                        _i++;
                    }

                    if ($("input[name=" + _this3.idSectionAddUpdate + "-studentis]:radio").is(":checked") == false) {
                        _error[_i] = ("กรุณาเลือกการเข้าเป็นนักศึกษามหาวิทยาลัย;Please select being a university student.;" + _this3.idSectionAddUpdate + "-studentis-content");
                        _i++;
                    }

                    if (Util.checkGetValue(_this3.idSectionAddUpdate + "-studentis") == "02" && ($("#" + _this3.idSectionAddUpdate + "-studentisuniversity").val().length == 0 && $("#" + _this3.idSectionAddUpdate + "-studentisfaculty").val().length == 0 && $("#" + _this3.idSectionAddUpdate + "-studentisprogram").val().length == 0)) {
                        _error[_i] = ("กรุณาใส่รายละเอียดกรณีเคยเป็นนักศึกษามหาวิทยาลัย;Please enter details in case was a student.;" + _this3.idSectionAddUpdate + "-studentis-content");
                        _i++;
                    }

                    if ($("input[name=" + _this3.idSectionAddUpdate + "-entrancetype]:radio").is(":checked") == false) {
                        _error[_i] = ("กรุณาเลือกระบบการสอบเข้า;Please select entrance examination system.;" + _this3.idSectionAddUpdate + "-entrancetype-content");
                        _i++;
                    }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                }
            },
            admissionscores: {
                idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsEducationAdmissionScoresAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    $("#" + _this3.idSectionAddUpdate + "-form .form-content .admissionscores .inputbox").width(50).attr("maxlength", "6");

                    $("input:text").keyup(function () {
                        if ($(this).attr("class") == "inputbox textbox-numeric")
                            return Util.extractNumber(this, 2, false);
                    });

                    $("input:text").keypress(function (_e) {
                        if ($(this).attr("class") == "inputbox textbox-numeric")
                            return Util.blockNonNumbers(this, _e, true, false);
                    });

                    $("input:text").focusout(function () {
                        if ($(this).attr("class") == "inputbox textbox-numeric") {
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val($(this).val().length > 6 ? $(this).val().substring($(this).val().length, $(this).val().length - 6) : $(this).val());
                            $(this).val(Util.delCommas($(this).attr("id")));
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                    });
                    
                    $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-save") == true)
                            _this2.confirmSave({
                                page: _param["page"]
                            });

                        if ($(this).hasClass("button-undo") == true)
                            _this3.resetMain();
                    });

                    _this3.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;

                    Util.dialogMessageClose();
                    Util.gotoTopElement();
                    Util.resetForm({
                        id: (_this3.idSectionAddUpdate + "-form")
                    });

                    $("#" + _this3.idSectionAddUpdate + "-scoresonetthai").val($("#" + _this3.idSectionAddUpdate + "-scoresonetthai-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresonetsocialscience").val($("#" + _this3.idSectionAddUpdate + "-scoresonetsocialscience-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresonetenglish").val($("#" + _this3.idSectionAddUpdate + "-scoresonetenglish-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresonetmathematics").val($("#" + _this3.idSectionAddUpdate + "-scoresonetmathematics-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresonetscience").val($("#" + _this3.idSectionAddUpdate + "-scoresonetscience-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresonethealthphysical").val($("#" + _this3.idSectionAddUpdate + "-scoresonethealthphysical-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresonetarts").val($("#" + _this3.idSectionAddUpdate + "-scoresonetarts-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresonetoccupationtechnology").val($("#" + _this3.idSectionAddUpdate + "-scoresonetoccupationtechnology-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresanetthai2").val($("#" + _this3.idSectionAddUpdate + "-scoresanetthai2-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresanetsocialscience2").val($("#" + _this3.idSectionAddUpdate + "-scoresanetsocialscience2-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresanetenglish3").val($("#" + _this3.idSectionAddUpdate + "-scoresanetenglish3-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresanetmathematics2").val($("#" + _this3.idSectionAddUpdate + "-scoresanetmathematics2-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresanetscience2").val($("#" + _this3.idSectionAddUpdate + "-scoresanetscience2-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scoresgatgenaralaptitudetest").val($("#" + _this3.idSectionAddUpdate + "-scoresgatgenaralaptitudetest-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat1").val($("#" + _this3.idSectionAddUpdate + "-scorespat1-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat2").val($("#" + _this3.idSectionAddUpdate + "-scorespat2-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat3").val($("#" + _this3.idSectionAddUpdate + "-scorespat3-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat4").val($("#" + _this3.idSectionAddUpdate + "-scorespat4-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat5").val($("#" + _this3.idSectionAddUpdate + "-scorespat5-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat6").val($("#" + _this3.idSectionAddUpdate + "-scorespat6-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat7").val($("#" + _this3.idSectionAddUpdate + "-scorespat7-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat8").val($("#" + _this3.idSectionAddUpdate + "-scorespat8-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat9").val($("#" + _this3.idSectionAddUpdate + "-scorespat9-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat10").val($("#" + _this3.idSectionAddUpdate + "-scorespat10-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat11").val($("#" + _this3.idSectionAddUpdate + "-scorespat11-hidden").val());
                    $("#" + _this3.idSectionAddUpdate + "-scorespat12").val($("#" + _this3.idSectionAddUpdate + "-scorespat12-hidden").val());
                },
                validateSave: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = this;
                    var _error = new Array();
                    var _i = 0;

                    return (_i > 0 ? false : true);
                }
            }
        },
        talent: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsTalentAddUpdate.toLowerCase(),
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                $("#" + _this3.idSectionAddUpdate + "-form .form-subcontent .textareabox").width(395).height(110);
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-sportsmanstatus")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-specialiststatus")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-specialistsportstatus")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-specialistartstatus")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-specialisttechnicalstatus")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-specialistotherstatus")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-activitystatus")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-rewardstatus")
                });

                $(".radio").on("ifChecked", function () {
                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-sportsmanstatus"))                                                
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-sportsmandetail")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-specialiststatus")) {
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idCheckboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistsportstatus, #" + _this3.idSectionAddUpdate + "-specialistartstatus, #" + _this3.idSectionAddUpdate + "-specialisttechnicalstatus, #" + _this3.idSectionAddUpdate + "-specialistotherstatus")
                        });
                        Util.setInputOtherOnCheck({
                            id: (_this3.idSectionAddUpdate + "-specialistsportstatus"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistsportdetail")
                        });
                        Util.setInputOtherOnCheck({
                            id: (_this3.idSectionAddUpdate + "-specialistartstatus"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistartdetail")
                        });
                        Util.setInputOtherOnCheck({
                            id: (_this3.idSectionAddUpdate + "-specialisttechnicalstatus"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialisttechnicaldetail")
                        });
                        Util.setInputOtherOnCheck({
                            id: (_this3.idSectionAddUpdate + "-specialistotherstatus"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistotherdetail")
                        });
                    }

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-activitystatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-activitydetail")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-rewardstatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-rewarddetail")
                        });
                });

                $(".checkbox").on("ifChecked ifUnchecked", function () {
                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-specialistsportstatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistsportdetail")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-specialistartstatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistartdetail")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-specialisttechnicalstatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialisttechnicaldetail")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-specialistotherstatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistotherdetail")
                        });
                });

                $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                    if ($(this).hasClass("button-save") == true)
                        _this2.confirmSave({
                            page: _param["page"]
                        });

                    if ($(this).hasClass("button-undo") == true)
                        _this3.resetMain();
                });

                _this3.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });

                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-sportsmanstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-sportsmanstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-sportsmandetail").val($("#" + _this3.idSectionAddUpdate + "-sportsmandetail-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-sportsmanstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-sportsmandetail")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-specialiststatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-specialiststatus-hidden").val()
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-specialistsportstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-specialistsportstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-specialistsportdetail").val($("#" + _this3.idSectionAddUpdate + "-specialistsportdetail-hidden").val());
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-specialistartstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-specialistartstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-specialistartdetail").val($("#" + _this3.idSectionAddUpdate + "-specialistartdetail-hidden").val());
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-specialisttechnicalstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-specialisttechnicalstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-specialisttechnicaldetail").val($("#" + _this3.idSectionAddUpdate + "-specialisttechnicaldetail-hidden").val());
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-specialistotherstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-specialistotherstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-specialistotherdetail").val($("#" + _this3.idSectionAddUpdate + "-specialistotherdetail-hidden").val())
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-specialiststatus"),
                    value: "Y",
                    idCheckboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistsportstatus, #" + _this3.idSectionAddUpdate + "-specialistartstatus, #" + _this3.idSectionAddUpdate + "-specialisttechnicalstatus, #" + _this3.idSectionAddUpdate + "-specialistotherstatus")
                });
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-specialistsportstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistsportdetail")
                });
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-specialistartstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistartdetail")
                });
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-specialisttechnicalstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialisttechnicaldetail")
                });
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-specialistotherstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-specialistotherdetail")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-activitystatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-activitystatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-activitydetail").val($("#" + _this3.idSectionAddUpdate + "-activitydetail-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-activitystatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-activitydetail")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-rewardstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-rewardstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-rewarddetail").val($("#" + _this3.idSectionAddUpdate + "-rewarddetail-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-rewardstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-rewarddetail")
                });
            },
            validateSave: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _error = new Array();
                var _i = 0;

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-sportsmanstatus") == "Y" && $("#" + _this3.idSectionAddUpdate + "-sportsmandetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีเคยเป็นนักกีฬา;Please enter details in case ever sportsman.;" + _this3.idSectionAddUpdate + "-sportsman-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-specialiststatus") == "Y" && ($("input[name=" + _this3.idSectionAddUpdate + "-specialistsportstatus]:checkbox").is(":checked") == false && $("input[name=" + _this3.idSectionAddUpdate + "-specialistartstatus]:checkbox").is(":checked") == false && $("input[name=" + _this3.idSectionAddUpdate + "-specialisttechnicalstatus]:checkbox").is(":checked") == false && $("input[name=" + _this3.idSectionAddUpdate + "-specialistotherstatus]:checkbox").is(":checked") == false)) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีมีความสามารถพิเศษ;Please enter details in case have talent.;" + _this3.idSectionAddUpdate + "-specialist-content");
                    _i++;
                }

                if ($("input[name=" + _this3.idSectionAddUpdate + "-specialistsportstatus]:checkbox").is(":checked") == true && $("#" + _this3.idSectionAddUpdate + "-specialistsportdetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีมีความสามารถพิเศษด้านกีฬา;Please enter details in case have sport talent.;" + _this3.idSectionAddUpdate + "-specialistsport-content");
                    _i++;
                }

                if ($("input[name=" + _this3.idSectionAddUpdate + "-specialistartstatus]:checkbox").is(":checked") == true && $("#" + _this3.idSectionAddUpdate + "-specialistartdetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีมีความสามารถพิเศษด้านศิลปะ;Please enter details in case have art talent.;" + _this3.idSectionAddUpdate + "-specialistart-content");
                    _i++;
                }

                if ($("input[name=" + _this3.idSectionAddUpdate + "-specialisttechnicalstatus]:checkbox").is(":checked") == true && $("#" + _this3.idSectionAddUpdate + "-specialisttechnicaldetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีมีความสามารถพิเศษด้านวิชาการ;Please enter details in case have academic talent.;" + _this3.idSectionAddUpdate + "-specialisttechnical-content");
                    _i++;
                }

                if ($("input[name=" + _this3.idSectionAddUpdate + "-specialistotherstatus]:checkbox").is(":checked") == true && $("#" + _this3.idSectionAddUpdate + "-specialistotherdetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีมีความสามารถพิเศษด้านอื่น ๆ;Please enter details in case have other talent.;" + _this3.idSectionAddUpdate + "-specialistother-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-activitystatus") == "Y" && $("#" + _this3.idSectionAddUpdate + "-activitydetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีเคยร่วมกิจกรรมของโรงเรียน;Please enter details in case ever school activities involvement.;" + _this3.idSectionAddUpdate + "-activity-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-rewardstatus") == "Y" && $("#" + _this3.idSectionAddUpdate + "-rewarddetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีเคยได้รับทุน / รางวัล;Please enter details in case ever awards.;" + _this3.idSectionAddUpdate + "-reward-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            }
        },
        healthy: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsHealthyAddUpdate.toLowerCase(),
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                
                $("#" + _this3.idSectionAddUpdate + "-form .form-subcontent .inputbox").width(395);
                /*
                $("#" + _this3.idSectionAddUpdate + "-form .form-subcontent .textareabox").width(395).height(110);
                $("#" + _this3.idSectionAddUpdate + "-form .form-subcontent .list").width(403);
                $("#" + _this3.idSectionAddUpdate + "-form .form-inputlist .form-inputlist-input .textbox-numeric").width(75).attr("maxlength", "6");
                $("#" + _this3.idSectionAddUpdate + "-bodymassdetailbmi").width(82);
                */
                $("#" + _this3.idSectionAddUpdate + "-bodymassindex-content").addClass("hidden");
                $("#" + _this3.idSectionAddUpdate + "-idcardpwd").attr("maxlength", "20");
                /*
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetailcountry"),
                    width: 241,
                    height: 29
                });
                */
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-impairmentsdetail"),
                    width: 403,
                    height: 29
                });
                /*
                Util.initCalendar({
                    id: ("#" + _this3.idSectionAddUpdate + "-bodymassdetaildate"),
                    yearRange: "-70:-0"
                });
                Util.initCalendar({
                    id: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetaildate"),
                    yearRange: "-70:-0"
                });
                */
                Util.initCalendarFromTo({
                    idFrom: ("#" + _this3.idSectionAddUpdate + "-idcardpwdissuedate"),
                    idTo: ("#" + _this3.idSectionAddUpdate + "-idcardpwdexpirydate"),
                    yearRange: "-10:+10"
                });
                /*
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-intolerancestatus")
                });
                */
                $("#" + _this3.idSectionAddUpdate + "-intolerance-content").addClass("hidden");
                /*
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-diseasesstatus")
                });
                */
                $("#" + _this3.idSectionAddUpdate + "-diseases-content").addClass("hidden");
                /*
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-familyhistoryofillnessstatus")
                });
                */
                $("#" + _this3.idSectionAddUpdate + "-familyhistoryofillness-content").addClass("hidden");
                /*
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-travelabroadstatus")
                });
                */
                $("#" + _this3.idSectionAddUpdate + "-travelabroad-content").addClass("hidden");
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-impairmentsstatus")
                });
                /*
                $("input:text").keyup(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-bodymassdetailweight"))    return Util.extractNumber(this, 2, false);
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-bodymassdetailheight"))    return Util.extractNumber(this, 2, false);
                });
                */
                $("input:text").keypress(function (_e) {
                    /*
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-bodymassdetailweight") || $(this).attr("id") == (_this3.idSectionAddUpdate + "-bodymassdetailheight")) {
                        $("#" + _this3.idSectionAddUpdate + "-bodymassdetailbmi").val("");
                        
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-bodymassdetailweight"))
                            return Util.blockNonNumbers(this, _e, true, false);
                        
                        if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-bodymassdetailheight"))
                            return Util.blockNonNumbers(this, _e, true, false);
                    }
                    */

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-idcardpwd"))
                        return Util.blockNonEnglishAndNumeric(this, _e);
                });

                $("input:text").focusout(function () {
                    /*
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-bodymassdetailweight")) {
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val($(this).val().length > 6 ? $(this).val().substring($(this).val().length, $(this).val().length - 6) : $(this).val());
                        $(this).val(Util.delCommas($(this).attr("id")));
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-bodymassdetailheight")) {
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val($(this).val().length > 6 ? $(this).val().substring($(this).val().length, $(this).val().length - 6) : $(this).val());
                        $(this).val(Util.delCommas($(this).attr("id")));
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }
                    */

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-idcardpwd")) {
                        $(this).val($(this).val().toUpperCase());
                    }
                });

                $(".radio").on("ifChecked", function () {
                    /*
                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-intolerancestatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-intolerancedetail")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-diseasesstatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-diseasesdetail")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-familyhistoryofillnessstatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessdetail"),
                            idContainerOther: ("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessdetail-content") 
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-travelabroadstatus"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetaildate, #" + _this3.idSectionAddUpdate + "-travelabroaddetail"),
                            idComboboxOther: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetailcountry"),
                            idContainerOther: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetail-content")
                        });
                    */

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-impairmentsstatus")) {
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-impairmentsequipment, #" + _this3.idSectionAddUpdate + "-idcardpwdissuedate, #" + _this3.idSectionAddUpdate + "-idcardpwdexpirydate"),
                            idComboboxOther: ("#" + _this3.idSectionAddUpdate + "-impairmentsdetail"),
                            idContainerOther: ("#" + _this3.idSectionAddUpdate + "-impairmentsdetail-content")
                        });

                        if ($(this).val() == "Y")
                            $("#" + _this3.idSectionAddUpdate + "-idcardpwd").val($("#" + _this3.idSectionAddUpdate + "-idcardpwd-hidden").val());
                    }
                });

                /*
                $("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessdetail-content .list .list-content .list-row").click(function () {
                    var _idLink = $(this).attr("id");
                    var _idContent = (_this3.idSectionAddUpdate + "-familyhistoryofillnessdetail");

                    $("#" + _idContent).val(($("#" + _idContent).val().length > 0 ? ($("#" + _idContent).val() + "\n") : "") + $("#" + _idLink + " .list-col").html());
                });

                $("#" + _this3.idSectionAddUpdate + "-form .link .click-button").click(function () {
                    var _idLink = $(this).attr("id");

                    if (_idLink == "add-bodymassdetail") {
                        if (_this3.bodymassindex.validateSave())
                            _this3.bodymassindex.setList({
                                action: "add"
                            });
                    }
                        
                    if (_idLink == "add-travelabroaddetail") {
                        if (_this3.travelabroad.validateSave())
                            _this3.travelabroad.setList({
                                action: "add"
                            });
                    }
                });
                */
                
                $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                    /*
                    if ($(this).hasClass("button-calculate") == true) {
                        Util.dialogMessageClose();

                        var _weight = $("#" + _this3.idSectionAddUpdate + "-bodymassdetailweight").val();
                        var _height = $("#" + _this3.idSectionAddUpdate + "-bodymassdetailheight").val();

                        $("#" + _this3.idSectionAddUpdate + "-bodymassdetailcalcultebmi").show();
                        $("#" + _this3.idSectionAddUpdate + "-bodymassdetail-content .contentbody-left:nth-child(3) .button").hide();

                        Util.calBMI({
                            idContainer: (_this3.idSectionAddUpdate + "-bodymassdetailcalcultebmi"),
                            weight: _weight,
                            height: _height
                        }, function (_result) {
                            $("#" + _this3.idSectionAddUpdate + "-bodymassdetailcalcultebmi").hide();
                            $("#" + _this3.idSectionAddUpdate + "-bodymassdetail-content .contentbody-left:nth-child(3) .button").show();
                            $("#" + _this3.idSectionAddUpdate + "-bodymassdetailbmi").val(Util.blockCharNotWanted(_result.BMI));
                        });
                    }
                    */

                    if ($(this).hasClass("button-save") == true)
                        _this2.confirmSave({
                            page: _param["page"]
                        });

                    if ($(this).hasClass("button-undo") == true)
                        _this3.resetMain();
                });

                _this3.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });
                /*
                $("#" + _this3.idSectionAddUpdate + "-bodymassdetail").val($("#" + _this3.idSectionAddUpdate + "-bodymassdetail-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-bodymassdetaildate").val($.datepicker.formatDate("dd/mm/yy", new Date()));
                Util.textboxDisable("#" + _this3.idSectionAddUpdate + "-bodymassdetailbmi");
                _this3.bodymassindex.setList({
                    action: "show"
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-intolerancestatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-intolerancestatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-intolerancedetail").val($("#" + _this3.idSectionAddUpdate + "-intolerancedetail-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-intolerancestatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-intolerancedetail")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-diseasesstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-diseasesstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-diseasesdetail").val($("#" + _this3.idSectionAddUpdate + "-diseasesdetail-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-diseasesstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-diseasesdetail")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-familyhistoryofillnessstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessdetail").val($("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessdetail-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-familyhistoryofillnessstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessdetail"),
                    idContainerOther: ("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessdetail-content")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-travelabroadstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-travelabroadstatus-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-travelabroaddetail").val($("#" + _this3.idSectionAddUpdate + "-travelabroaddetail-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-travelabroadstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetaildate, #" + _this3.idSectionAddUpdate + "-travelabroaddetail"),
                    idComboboxOther: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetailcountry"),
                    idContainerOther: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetail-content")
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-travelabroaddetailcountry"),
                    value: "0"
                });
                _this3.travelabroad.setList({
                    action: "show"
                });
                */
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-impairmentsstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-impairmentsstatus-hidden").val()
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-impairmentsdetail"),
                    value: $("#" + _this3.idSectionAddUpdate + "-impairmentsdetail-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-impairmentsequipment").val($("#" + _this3.idSectionAddUpdate + "-impairmentsequipment-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-impairmentsstatus"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-impairmentsequipment"),
                    idComboboxOther: ("#" + _this3.idSectionAddUpdate + "-impairmentsdetail"),
                    idContainerOther: ("#" + _this3.idSectionAddUpdate + "-impairmentsdetail-content")
                });
                $("#" + _this3.idSectionAddUpdate + "-idcardpwd").val($("#" + _this3.idSectionAddUpdate + "-idcardpwd-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-idcardpwdissuedate").val($("#" + _this3.idSectionAddUpdate + "-idcardpwdissuedate-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-idcardpwdexpirydate").val($("#" + _this3.idSectionAddUpdate + "-idcardpwdexpirydate-hidden").val());
            },
            validateSave: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _error = new Array();
                var _i = 0;

                /*
                if ($("#" + _this3.idSectionAddUpdate + "-bodymassdetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่ดัชนีมวลกาย;Please enter body mass index.;" + _this3.idSectionAddUpdate + "-bodymassindex-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-intolerancestatus") == "Y" && $("#" + _this3.idSectionAddUpdate + "-intolerancedetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีมีประวัติการแพ้ยา;Please enter details in case have drug allergy history.;" + _this3.idSectionAddUpdate + "-intolerance-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-diseasesstatus") == "Y" && $("#" + _this3.idSectionAddUpdate + "-diseasesdetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีมีโรคประจำตัว;Please enter details in case have diseases.;" + _this3.idSectionAddUpdate + "-diseases-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-familyhistoryofillnessstatus") == "Y" && $("#" + _this3.idSectionAddUpdate + "-familyhistoryofillnessdetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีในครอบครัวมีประวัติการเจ็บป่วย;Please enter details in case family have history of illness.;" + _this3.idSectionAddUpdate + "-familyhistoryofillness-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-travelabroadstatus") == "Y" && $("#" + _this3.idSectionAddUpdate + "-travelabroaddetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีเคยเดินทางไปต่างประเทศ;Please enter details in case ever travel abroad.;" + _this3.idSectionAddUpdate + "-travelabroad-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-impairmentsstatus") == "Y" && Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-impairmentsdetail") == "0" && $("#" + _this3.idSectionAddUpdate + "-impairmentsequipment").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีมีความบกพร่องทางสุขภาพ;Please enter details in case have health impairments.;" + _this3.idSectionAddUpdate + "-impairments-content");
                    _i++;
                }
                */

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-impairmentsstatus") == "Y" && Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-impairmentsdetail") == "0") {
                    _error[_i] = ("กรุณาเลือกประเภทความพิการ;Please select type of disability.;" + _this3.idSectionAddUpdate + "-impairments-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-impairmentsstatus") == "Y" && Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-impairmentsdetail") != "0" && ($("#" + _this3.idSectionAddUpdate + "-idcardpwd").val().length == 0 || $("#" + _this3.idSectionAddUpdate + "-idcardpwdissuedate").val().length == 0 || $("#" + _this3.idSectionAddUpdate + "-idcardpwdexpirydate").val().length == 0)) {
                    _error[_i] = ("กรุณาใส่รายละเอียดบัตรประจำตัวคนพิการให้ครบถ้วน;Please enter ID Card for Person with Disabilities ( PWD ).;" + _this3.idSectionAddUpdate + "-impairments-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
            bodymassindex: {
                setList: function (_param) {
                    _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
                    _param["row"] = (_param["row"] == undefined ? "" : _param["row"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.healthy;
                    var _this4 = this;
                    var _cmd = "getbodymassdetail";
                    var _valueArray = new Array();
                    var _separatorCol = ":";
                    var _idInputList = (_this3.idSectionAddUpdate + "-bodymassdetail");
                    var _idList = (_this3.idSectionAddUpdate + "-bodymassindex-content .form-inputlist .form-inputlist-list");
                    var _idListRow = (_this3.idSectionAddUpdate + "-bodymassdetail-list-row");

                    if (_param["action"] == "add") {
                        _valueArray[0] = $("#" + _this3.idSectionAddUpdate + "-bodymassdetailweight").val();
                        _valueArray[1] = $("#" + _this3.idSectionAddUpdate + "-bodymassdetailheight").val();
                        _valueArray[2] = $("#" + _this3.idSectionAddUpdate + "-bodymassdetailbmi").val();
                        _valueArray[3] = $("#" + _this3.idSectionAddUpdate + "-bodymassdetaildate").val();

                        Util.setList({
                            add: true,
                            data: _valueArray,
                            separatorCol: _separatorCol,
                            idInputList: _idInputList,
                            idList: _idList,
                            idListRow: _idListRow
                        });
                        Util.getList({
                            cmd: _cmd,
                            id: _idList,
                            data: $("#" + _idInputList).val()
                        }, function () {
                            Util.setList({
                                add: false,
                                separatorCol: _separatorCol,
                                idInputList: _idInputList,
                                idList: _idList,
                                idListRow: _idListRow
                            });
                        });
                    }

                    if (_param["action"] == "delete") {
                        $("#" + _idListRow + _param["row"]).hide();
                        Util.setList({
                            add: false,
                            separatorCol: _separatorCol,
                            idInputList: _idInputList,
                            idList: _idList,
                            idListRow: _idListRow
                        });

                        _param["action"] = "show";
                    }

                    if (_param["action"] == "show")
                        Util.getList({
                            cmd: _cmd,
                            id: _idList,
                            data: $("#" + _idInputList).val()
                        }, function () {
                        });
                },
                validateSave: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.healthy;
                    var _this4 = this;
                    var _error = new Array();
                    var _i = 0;

                    if ($("#" + _this3.idSectionAddUpdate + "-bodymassdetailweight").val().length == 0) {
                        _error[_i] = ("กรุณาใส่น้ำหนัก;Please enter weight.;" + _this3.idSectionAddUpdate + "-bodymassindex-content");
                        _i++;
                    }

                    if ($("#" + _this3.idSectionAddUpdate + "-bodymassdetailheight").val().length == 0) {
                        _error[_i] = ("กรุณาใส่ส่วนสูง;Please enter height.;" + _this3.idSectionAddUpdate + "-bodymassindex-content");
                        _i++;
                    }

                    if ($("#" + _this3.idSectionAddUpdate + "-bodymassdetailbmi").val().length == 0) {
                        _error[_i] = ("กรุณาคำนวณค่าดัชนีมวลกาย;Please calculate body mass index.;" + _this3.idSectionAddUpdate + "-bodymassindex-content");
                        _i++;
                    }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                }
            },           
            travelabroad: {
                setList: function (_param) {
                    _param["action"] = (_param["action"] == undefined ? "" : _param["action"]);
                    _param["row"] = (_param["row"] == undefined ? "" : _param["row"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.healthy;
                    var _this4 = this;
                    var _cmd = "gettravelabroaddetail";
                    var _valueArray = new Array();
                    var _separatorCol = ",";
                    var _idInputList = (_this3.idSectionAddUpdate + "-travelabroaddetail");
                    var _idList = (_this3.idSectionAddUpdate + "-travelabroad-content .form-inputlist .form-inputlist-list");
                    var _idListRow = (_this3.idSectionAddUpdate + "-travelabroaddetail-list-row");

                    if (_param["action"] == "add") {
                        var _valueCountry = $("#" + _this3.idSectionAddUpdate + "-travelabroaddetailcountry option:selected").text();
                        var _valueCountryArray = _valueCountry.split(":");
                        var _countryTH = (_valueCountryArray.length >= 1 ? $.trim(_valueCountryArray[0]) : "");
                        var _countryEN = (_valueCountryArray.length == 2 ? $.trim(_valueCountryArray[1]) : "");

                        _valueArray[0] = (_countryTH + ":" + _countryEN);
                        _valueArray[1] = $("#" + _this3.idSectionAddUpdate + "-travelabroaddetaildate").val();

                        Util.setList({
                            add: true,
                            data: _valueArray,
                            separatorCol: _separatorCol,
                            idInputList: _idInputList,
                            idList: _idList,
                            idListRow: _idListRow
                        });
                        Util.getList({
                            cmd: _cmd,
                            id: _idList,
                            data: $("#" + _idInputList).val()
                        }, function () {
                            Util.setList({
                                add: false,
                                separatorCol: _separatorCol,
                                idInputList: _idInputList,
                                idList: _idList,
                                idListRow: _idListRow
                            });
                        });
                    }

                    if (_param["action"] == "delete") {
                        $("#" + _idListRow + _param["row"]).hide();
                        Util.setList({
                            add: false,
                            separatorCol: _separatorCol,
                            idInputList: _idInputList,
                            idList: _idList,
                            idListRow: _idListRow
                        });

                        _param["action"] = "show";
                    }

                    if (_param["action"] == "show")
                        Util.getList({
                            cmd: _cmd,
                            id: _idList,
                            data: $("#" + _idInputList).val()
                        }, function () {
                        });
                },
                validateSave: function () {
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.healthy;
                    var _this4 = this;
                    var _error = new Array();
                    var _i = 0;

                    if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-travelabroaddetailcountry") == "0") {
                        _error[_i] = ("กรุณาเลือกประเทศที่เดินทางไป;Please select country of travel.;" + _this3.idSectionAddUpdate + "-travelabroad-content");
                        _i++;
                    }

                    if ($("#" + _this3.idSectionAddUpdate + "-travelabroaddetaildate").val().length == 0) {
                        _error[_i] = ("กรุณาใส่วันเดือนปีที่เดินทางไป;Please enter date of travel.;" + _this3.idSectionAddUpdate + "-travelabroad-content");
                        _i++;
                    }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                }
            }
        },
        work: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsWorkAddUpdate.toLowerCase(),
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _widthCombobox = 426;
                var _heightCombobox = 29;

                $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(418);
                $("#" + _this3.idSectionAddUpdate + "-form .form-subcontent .inputbox").width(395);
                $("#" + _this3.idSectionAddUpdate + "-workplacesalary").width(120).attr("maxlength", "10");
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-occupation"),
                    width: _widthCombobox,
                    height: _heightCombobox
                });                
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-agency"), 
                    width: _widthCombobox,
                    height: _heightCombobox
                });                
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-agencyother")
                });

                $("input:text").keyup(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-workplacesalary"))
                        return Util.extractNumber(this, 2, false);
                });

                $("input:text").keypress(function (_e) {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-workplacetelephone"))
                        return Util.blockNonPhoneNumber(this, _e, false, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-workplacesalary"))
                        return Util.blockNonNumbers(this, _e, true, false);
                });

                $("input:text").focusout(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-workplacesalary")) {
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val($(this).val().length > 10 ? $(this).val().substring($(this).val().length, $(this).val().length - 10) : $(this).val());
                        $(this).val(Util.delCommas($(this).attr("id")));
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }
                });

                $(".radio").on("ifChecked", function () {
                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-agencyother"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "0",
                            idCombobox: ("#" + _this3.idSectionAddUpdate + "-agency"),
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-agencyotherdetail")
                        });
                });

                $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                    if ($(this).hasClass("button-save") == true)
                        _this2.confirmSave({
                            page: _param["page"]
                        });

                    if ($(this).hasClass("button-undo") == true)
                        _this3.resetMain();
                });

                _this3.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });

                _this2.copyWork({
                    copy: true,
                    idSrc: _this3.idSectionAddUpdate,
                    idDes: _this3.idSectionAddUpdate
                });
            },
            validateSave: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _error = new Array();
                var _i = 0;

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-agencyother") == "0" && $("#" + _this3.idSectionAddUpdate + "-agencyotherdetail").val().length == 0) {
                    _error[_i] = ("กรุณาใส่ต้นสังกัด;Please enter other agency.;" + _this3.idSectionAddUpdate + "-agency-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            }
        },
        financial: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFinancialAddUpdate.toLowerCase(),
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _widthCombobox = 403;
                var _heightCombobox = 29;

                $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(418);
                $("#" + _this3.idSectionAddUpdate + "-form .form-subcontent .inputbox").width(395);
                $("#" + _this3.idSectionAddUpdate + "-form .form-content .textbox-numeric").width(120).attr("maxlength", "10");
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorfrom"),
                    width: _widthCombobox,
                    height: _heightCombobox
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorfrom"),
                    width: _widthCombobox,
                    height: _heightCombobox
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-scholarshipfirstbachelor")
                });    
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-scholarshipbachelor")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-worked")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-gotmoneyfrom")
                });

                $("input:text").keyup(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-scholarshipfirstbachelormoney"))
                        return Util.extractNumber(this, 2, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-scholarshipbachelormoney"))
                        return Util.extractNumber(this, 2, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-salary"))
                        return Util.extractNumber(this, 2, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gotmoneypermonth"))
                        return Util.extractNumber(this, 2, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-costpermonth"))
                        return Util.extractNumber(this, 2, false);
                });

                $("input:text").keypress(function (_e) {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-scholarshipfirstbachelormoney"))
                        return Util.blockNonNumbers(this, _e, true, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-scholarshipbachelormoney"))
                        return Util.blockNonNumbers(this, _e, true, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-salary"))
                        return Util.blockNonNumbers(this, _e, true, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gotmoneypermonth"))
                        return Util.blockNonNumbers(this, _e, true, false);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-costpermonth"))
                        return Util.blockNonNumbers(this, _e, true, false);
                });

                $("input:text").focusout(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-scholarshipfirstbachelormoney")) {
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val($(this).val().length > 10 ? $(this).val().substring($(this).val().length, $(this).val().length - 10) : $(this).val());
                        $(this).val(Util.delCommas($(this).attr("id")));
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-scholarshipbachelormoney")) {
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val($(this).val().length > 10 ? $(this).val().substring($(this).val().length, $(this).val().length - 10) : $(this).val());
                        $(this).val(Util.delCommas($(this).attr("id")));
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-salary")) {
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val($(this).val().length > 10 ? $(this).val().substring($(this).val().length, $(this).val().length - 10) : $(this).val());
                        $(this).val(Util.delCommas($(this).attr("id")));
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-gotmoneypermonth")) {
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val($(this).val().length > 10 ? $(this).val().substring($(this).val().length, $(this).val().length - 10) : $(this).val());
                        $(this).val(Util.delCommas($(this).attr("id")));
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-costpermonth")) {
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val($(this).val().length > 10 ? $(this).val().substring($(this).val().length, $(this).val().length - 10) : $(this).val());
                        $(this).val(Util.delCommas($(this).attr("id")));
                        Util.addCommas($(this).attr("id"), 2);
                        $(this).val(Util.blockCharNotWanted($(this).val()));
                    }
                });

                $(".radio").on("ifChecked", function () {
                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-scholarshipfirstbachelor"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorname, #" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelormoney"),
                            idComboboxOther: ("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorfrom")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-scholarshipbachelor"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorname, #" + _this3.idSectionAddUpdate + "-scholarshipbachelormoney"),
                            idComboboxOther: ("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorfrom")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-worked"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "Y",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-salary, #" + _this3.idSectionAddUpdate + "-workplace")
                        });

                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-gotmoneyfrom"))
                        Util.setInputOtherOnCheck({
                            id: $(this).attr("name"),
                            value: "0",
                            idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-gotmoneyfromother")
                        });
                });

                $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                    if ($(this).hasClass("button-save") == true)
                        _this2.confirmSave({
                            page: _param["page"]
                        });

                    if ($(this).hasClass("button-undo") == true)
                        _this3.resetMain();
                });
                    
                _this3.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });

                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-scholarshipfirstbachelor"),
                    value: $("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelor-hidden").val()
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorfrom"),
                    value: $("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorfrom-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorname").val($("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorname-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelormoney").val($("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelormoney-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-scholarshipfirstbachelor"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorname, #" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelormoney"),
                    idComboboxOther: ("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorfrom")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-scholarshipbachelor"),
                    value: $("#" + _this3.idSectionAddUpdate + "-scholarshipbachelor-hidden").val()
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorfrom"),
                    value: $("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorfrom-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorname").val($("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorname-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-scholarshipbachelormoney").val($("#" + _this3.idSectionAddUpdate + "-scholarshipbachelormoney-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-scholarshipbachelor"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorname, #" + _this3.idSectionAddUpdate + "-scholarshipbachelormoney"),
                    idComboboxOther: ("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorfrom")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-worked"),
                    value: $("#" + _this3.idSectionAddUpdate + "-worked-hidden").val()
                });
                $("#" + _this3.idSectionAddUpdate + "-salary").val($("#" + _this3.idSectionAddUpdate + "-salary-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-workplace").val($("#" + _this3.idSectionAddUpdate + "-workplace-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-worked"),
                    value: "Y",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-salary, #" + _this3.idSectionAddUpdate + "-workplace")
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-gotmoneyfrom"),
                    value: ($("#" + _this3.idSectionAddUpdate + "-gotmoneyfrom-hidden").val().length > 0 || $("#" + _this3.idSectionAddUpdate + "-gotmoneyfromother-hidden").val().length == 0 ? $("#" + _this3.idSectionAddUpdate + "-gotmoneyfrom-hidden").val() : "0")
                });
                $("#" + _this3.idSectionAddUpdate + "-gotmoneyfromother").val($("#" + _this3.idSectionAddUpdate + "-gotmoneyfromother-hidden").val());
                Util.setInputOtherOnCheck({
                    id: (_this3.idSectionAddUpdate + "-gotmoneyfrom"),
                    value: "0",
                    idTextboxOther: ("#" + _this3.idSectionAddUpdate + "-gotmoneyfromother")
                });
                $("#" + _this3.idSectionAddUpdate + "-gotmoneypermonth").val($("#" + _this3.idSectionAddUpdate + "-gotmoneypermonth-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-costpermonth").val($("#" + _this3.idSectionAddUpdate + "-costpermonth-hidden").val());
            },
            validateSave: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _error = new Array();
                var _i = 0;

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-scholarshipfirstbachelor") == "Y" && (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorfrom") == "0" && $("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelorname").val().length == 0 && $("#" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelormoney").val().length == 0)) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีเคยได้รับทุนการศึกษาก่อนศึกษาระดับป.ตรี;Please enter details in case ever scholarship received.;" + _this3.idSectionAddUpdate + "-scholarshipfirstbachelor-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-scholarshipbachelor") == "Y" && (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorfrom") == "0" && $("#" + _this3.idSectionAddUpdate + "-scholarshipbachelorname").val().length == 0 && $("#" + _this3.idSectionAddUpdate + "-scholarshipbachelormoney").val().length == 0)) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีเคยได้รับทุนการศึกษาระหว่างศึกษาระดับป.ตรี;Please enter details in case ever scholarship received.;" + _this3.idSectionAddUpdate + "-scholarshipbachelor-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-worked") == "Y" && ($("#" + _this3.idSectionAddUpdate + "-salary").val().length == 0 && $("#" + _this3.idSectionAddUpdate + "-workplace").val().length == 0)) {
                    _error[_i] = ("กรุณาใส่รายละเอียดกรณีทำงานระหว่างศึกษา;Please enter details in case work during study.;" + _this3.idSectionAddUpdate + "-worked-content");
                    _i++;
                }

                if (Util.checkGetValue(_this3.idSectionAddUpdate + "-gotmoneyfrom") == "0" && $("#" + _this3.idSectionAddUpdate + "-gotmoneyfromother").val().length == 0) {
                    _error[_i] = ("กรุณาใส่การได้รับอุปการะเงินค่าใช้จ่ายส่วนใหญ่จาก;Please enter financial support from other.;" + _this3.idSectionAddUpdate + "-gotmoneyfrom-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            }
        },
        family: {
            idSectionAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyAddUpdate.toLowerCase(),
            idSectionFatherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyFatherAddUpdate.toLowerCase(),
            idSectionMotherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyMotherAddUpdate.toLowerCase(),
            idSectionParentAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyParentAddUpdate.toLowerCase(),
            getSectionByFamilyRelation: function (_param) {
                _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);
                _param["idFather"] = (_param["idFather"] == undefined ? "" : _param["idFather"]);
                _param["idMother"] = (_param["idMother"] == undefined ? "" : _param["idMother"]);
                _param["idParent"] = (_param["idParent"] == undefined ? "" : _param["idParent"]);

                var _idSection = "";
                
                if (_param["familyRelation"] == Util.tut.subjectFamilyFather)
                    _idSection = _param["idFather"];

                if (_param["familyRelation"] == Util.tut.subjectFamilyMother)
                    _idSection = _param["idMother"];

                if (_param["familyRelation"] == Util.tut.subjectFamilyParent)
                    _idSection = _param["idParent"];

                return _idSection;
            },
            setParentOnRelationship: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
                _param["reset"] = (_param["reset"] == undefined || _param["reset"] == "" ? false : _param["reset"]);                    

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _valueRelationship;
                var _valueRelationshipArray;
                var _valueFamilyRelation = "";
                var _familyRelation = "";
                var _relationshipTH = "";
                var _relationshipEN = "";
                var _inputParent = true;
                var _copy = false;
                var _copyData;
                var _idSection;
                var _idSrc = "";

                _valueRelationship = Util.comboboxGetValue("#" + _this3.personal.idSectionParentAddUpdate + "-relationship");
                _idSection = _param["this"].idSectionParentAddUpdate;                

                if (_valueRelationship != "0") {
                    _valueRelationshipArray = _valueRelationship.split(";");

                    if (_valueRelationshipArray.length == 4) {
                        _valueFamilyRelation = _valueRelationshipArray[0];
                        _relationshipEN = _valueRelationshipArray[1];
                        _relationshipTH = _valueRelationshipArray[2];
                        _familyRelation = _relationshipEN;
                    }
                }
                
                if (_familyRelation.length == 0 || _familyRelation == Util.tut.subjectFamilyFather || _familyRelation == Util.tut.subjectFamilyMother) {
                    if (_familyRelation.length == 0)
                        _inputParent = true;

                    if (_familyRelation == Util.tut.subjectFamilyFather || _familyRelation == Util.tut.subjectFamilyMother)
                        _inputParent = false;
                }
                
                $("#" + _idSection + "-relationship-content .form-subcontent .form-labelcol .th-label").html(_relationshipTH);
                $("#" + _idSection + "-relationship-content .form-subcontent .form-labelcol .en-label").html(Util.toUpperCaseFirst(_relationshipEN));
                
                if (_inputParent == false) {
                    _idSrc = _this2.family.getSectionByFamilyRelation({
                        familyRelation: _familyRelation,
                        idFather: _param["this"].idSectionFatherAddUpdate, 
                        idMother: _param["this"].idSectionMotherAddUpdate,
                        idParent: _param["this"].idSectionParentAddUpdate
                    });
                    
                    $("#" + _idSection + "-form-content").hide();
                    $("#" + _idSection + "-defaultrelationship-hidden").val(_valueFamilyRelation);

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate)
                        _this2.copyPersonal({
                            page: _param["page"],
                            copy: true,
                            idSrc: _idSrc,
                            idDes: _idSection
                        });

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate)
                        _this2.copyAddress({
                            page: _param["page"],
                            copy: true,
                            idSrc: _idSrc,
                            idDes: _idSection
                        });

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate)
                        _this2.copyAddress({
                            page: _param["page"],
                            copy: true,
                            idSrc: _idSrc,
                            idDes: _idSection
                        });

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate)
                        _this2.copyWork({
                            page: _param["page"],
                            copy: true,
                            idSrc: _idSrc,
                            idDes: _idSection
                        });
                }
                
                if (_inputParent == true) {
                    $("#" + _idSection + "-form-content").show();

                    if (_valueFamilyRelation != $("#" + _this3.personal.idSectionParentAddUpdate + "-relationship-hidden").val())
                        _copy = true;

                    if (_param["reset"] == true) {
                        $("#" + _idSection + "-defaultrelationship-hidden").val(_valueFamilyRelation);

                        if (_copy == true) {
                            _copyData = (_inputParent == false ? true : false);
                            _familyRelation = _familyRelation;
                        }

                        if (_copy == false) {
                            _copyData = true;
                            _familyRelation = Util.tut.subjectFamilyParent;
                        }
                        
                        _idSrc = _this2.family.getSectionByFamilyRelation({
                            familyRelation: _familyRelation,
                            idFather: _param["this"].idSectionFatherAddUpdate, 
                            idMother: _param["this"].idSectionMotherAddUpdate,
                            idParent: _param["this"].idSectionParentAddUpdate
                        });
                        
                        if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate)
                            _this2.copyPersonal({
                                page: _param["page"],
                                copy: _copyData,
                                idSrc: _idSrc,
                                idDes: _idSection
                            });

                        if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate)
                            _this2.copyAddress({
                                page: _param["page"],
                                copy: _copyData,
                                idSrc: _idSrc,
                                idDes: _idSection
                            });

                        if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate)
                            _this2.copyAddress({
                                page: _param["page"],
                                copy: _copyData,
                                idSrc: _idSrc,
                                idDes: _idSection
                            });

                        if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate)
                            _this2.copyWork({
                                page: _param["page"],
                                copy: _copyData,
                                idSrc: _idSrc,
                                idDes: _idSection
                            });
                    }
                    
                    if (_param["reset"] == false) {
                        _idSrc = _this2.family.getSectionByFamilyRelation({
                            familyRelation: _familyRelation,
                            idFather: _param["this"].idSectionFatherAddUpdate, 
                            idMother: _param["this"].idSectionMotherAddUpdate,
                            idParent: _param["this"].idSectionParentAddUpdate
                        });
                                                
                        if (_valueFamilyRelation != $("#" + _idSection + "-defaultrelationship-hidden").val()) {
                            $("#" + _idSection + "-defaultrelationship-hidden").val(_valueFamilyRelation);

                            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate) {
                                if (_copy == true)
                                    _this2.copyPersonal({
                                        page: _param["page"],                                        
                                        copy: (_inputParent == false ? true : false),
                                        idSrc: _idSrc,
                                        idDes: _idSection
                                    });

                                if (_copy == false)
                                    _this2.copyPersonal({
                                        page: _param["page"],
                                        copy: true,
                                        idSrc: _idSection,
                                        idDes: _idSection
                                    });
                            }

                            if (_familyRelation != Util.tut.subjectFamilyFather && _familyRelation != Util.tut.subjectFamilyMother) {
                                if ($("#" + _this3.personal.idSectionParentAddUpdate + "-defaultpersonid-hidden").val() == $("#" + _this3.personal.idSectionFatherAddUpdate + "-personid-hidden").val() ||
                                    $("#" + _this3.personal.idSectionParentAddUpdate + "-defaultpersonid-hidden").val() == $("#" + _this3.personal.idSectionMotherAddUpdate + "-personid-hidden").val())
                                    $("#" + _this3.personal.idSectionParentAddUpdate + "-personid-hidden").val("");
                            }
                        }
                    }
                }
            },
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;

                $("#" + _this3.idSectionAddUpdate + "-content").css({
                    "padding-top": $("#" + _this3.idSectionAddUpdate + "-menu.tabbar").outerHeight()
                });
                _this2.initMenu({
                    id: ("#" + _this3.idSectionAddUpdate + "-menu-content"),
                    idContent: ("#" + _this3.idSectionAddUpdate + "-content"),
                    classActive: "tab-active",
                    classNoActive: "tab-noactive"
                });
            },
            initSubMain: function (_param) {
                _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                var _this1 = Util.tut.tsr;
                var _this2 = _this1.sectionAddUpdate;
                var _this3 = this;
                var _idSection;

                _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                _idSection = _this3.getSectionByFamilyRelation({
                    familyRelation: _param["familyRelation"],
                    idFather: _this3.idSectionFatherAddUpdate,
                    idMother: _this3.idSectionMotherAddUpdate,
                    idParent: _this3.idSectionParentAddUpdate
                });

                $("#" + _idSection + "-content").css({
                    "padding-top": $("#" + _idSection + "-menu.subtabbar").outerHeight()
                });                
                _this2.initMenu({
                    id: ("#" + _idSection + "-menu-content"),
                    idContent: ("#" + _idSection + "-content"),
                    classActive: "subtab-active",
                    classNoActive: "subtab-noactive"
                });                
            },
            personal: {
                idSectionFatherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyFatherPersonalAddUpdate.toLowerCase(),
                idSectionMotherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyMotherPersonalAddUpdate.toLowerCase(),
                idSectionParentAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyParentPersonalAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _idSection;
                    var _widthCombobox = 426;
                    var _heightCombobox = 29;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _this4.idSectionFatherAddUpdate,
                        idMother: _this4.idSectionMotherAddUpdate,
                        idParent: _this4.idSectionParentAddUpdate
                    });

                    $("#" + _idSection + "-form .form-content .inputbox").width(418);

                    if (_this1.isProgramContract)
                        $("#" + _idSection + "-idcard").attr("maxlength", "20");
                    else                    
                        $("#" + _idSection + "-idcard-content").addClass("hidden");

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent)
                        Util.initCombobox({
                            id: ("#" + _idSection + "-relationship"),
                            width: _widthCombobox,
                            height: _heightCombobox
                        });

                    Util.initCombobox({
                        id: ("#" + _idSection + "-titleprefix"),
                        width: _widthCombobox,
                        height: _heightCombobox
                    });
                    Util.initCombobox({
                        id: ("#" + _idSection + "-birthplace"),
                        width: _widthCombobox,
                        height: _heightCombobox
                    });
                    Util.initCombobox({
                        id: ("#" + _idSection + "-nationality"),
                        width: _widthCombobox,
                        height: _heightCombobox
                    });
                    /*
                    Util.initCombobox({
                        id: ("#" + _idSection + "-race"),
                        width: _widthCombobox,
                        height: _heightCombobox
                    });
                    */
                    $("#" + _idSection + "-race-content").addClass("hidden");

                    if (MSent.consentField.religion.isConsent) {
                        Util.initCombobox({
                            id: ("#" + _idSection + "-religion"),
                            width: _widthCombobox,
                            height: _heightCombobox
                        });
                    }
                    else
                        $("#" + _idSection + "-religion-content").addClass("hidden");

                    if (_this1.isProgramContract) {
                        Util.initCalendar({
                            id: ("#" + _idSection + "-birthdate"),
                            yearRange: "-100:-0"
                        });
                    }
                    else
                        $("#" + _idSection + "-birthdate-content").addClass("hidden");

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent)
                        Util.initCheck({
                            id: (_idSection + "-gender")
                        });

                    Util.initCheck({
                        id: (_idSection + "-alive")
                    });
                    /*
                    Util.initCheck({
                        id: (_idSection + "-bloodgroup")
                    });
                    */
                    $("#" + _idSection + "-bloodgroup-content").addClass("hidden");
                    Util.initCheck({
                        id: (_idSection + "-maritalstatus")
                    });
                    Util.initCheck({
                        id: (_idSection + "-educationalbackgroundperson")
                    });

                    $("input:text").keypress(function (_e) {
                        if ($(this).attr("id") == (_idSection + "-idcard"))
                            return Util.blockNonEnglishAndNumeric(this, _e);

                        if ($(this).attr("id") == (_idSection + "-firstname"))
                            return Util.blockEnglish(this, _e);

                        if ($(this).attr("id") == (_idSection + "-middlename"))
                            return Util.blockEnglish(this, _e);

                        if ($(this).attr("id") == (_idSection + "-lastname"))
                            return Util.blockEnglish(this, _e);

                        if ($(this).attr("id") == (_idSection + "-firstnameen"))
                            return Util.blockNonEnglish(this, _e);

                        if ($(this).attr("id") == (_idSection + "-middlenameen"))
                            return Util.blockNonEnglish(this, _e);

                        if ($(this).attr("id") == (_idSection + "-lastnameen"))
                            return Util.blockNonEnglish(this, _e);
                    });
                
                    $("input:text").focusout(function () {
                        if ($(this).attr("id") == (_idSection + "-idcard")) {
                            $(this).val($(this).val().toUpperCase());
                        }

                        if ($(this).attr("id") == (_idSection + "-firstnameen")) {
                            $(this).val($(this).val().toUpperCase());
                        }

                        if ($(this).attr("id") == (_idSection + "-middlenameen")) {
                            $(this).val($(this).val().toUpperCase());
                        }

                        if ($(this).attr("id") == (_idSection + "-lastnameen")) {
                            $(this).val($(this).val().toUpperCase());
                        }
                    });
                
                    $("input:text").change(function () {
                        if ($(this).attr("id") == (_idSection + "-birthdate"))
                            Util.calAge({
                                birthdate: $(this).val()
                            }, function (_result) {
                                $("#" + _idSection + "-age").html(_result);
                            });
                    });

                    $("#" + _idSection + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-save") == true)
                            _this2.confirmSave({
                                page: _param["page"]
                            });

                        if ($(this).hasClass("button-undo") == true)
                            _this4.resetMain({
                                page: _param["page"],
                                familyRelation: _param["familyRelation"]
                            });
                    });
                        
                    _this4.resetMain({
                        page: _param["page"],
                        familyRelation: _param["familyRelation"]
                    });
                },
                resetMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _idSection;
                    var _value;
                    var _valueArray;
                    var _valueSubArray;
                    var _valueSubSubArray;
                    var _i = 0;
                    var _j = 0;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _this4.idSectionFatherAddUpdate,
                        idMother: _this4.idSectionMotherAddUpdate,
                        idParent: _this4.idSectionParentAddUpdate
                    });
                        
                    Util.dialogMessageClose();
                    Util.gotoTopElement();
                    Util.resetForm({
                        id: (_idSection + "-form")
                    });

                    if (_param["familyRelation"] == Util.tut.subjectFamilyFather || _param["familyRelation"] == Util.tut.subjectFamilyMother) {           
                        if (_this1.isProgramContract)
                            $("#" + _idSection + "-idcard").val($("#" + _idSection + "-idcard-hidden").val());

                        Util.comboboxSetValue({
                            id: ("#" + _idSection + "-titleprefix"),
                            value: ($("#" + _idSection + "-titleprefix-hidden").val() != "0" ? ($("#" + _idSection + "-titleprefix-hidden").val() + ";" + $("#" + _idSection + "-gendertitleprefix-hidden").val()) : "0")
                        });
                        $("#" + _idSection + "-firstname").val($("#" + _idSection + "-firstname-hidden").val());
                        $("#" + _idSection + "-middlename").val($("#" + _idSection + "-middlename-hidden").val());
                        $("#" + _idSection + "-lastname").val($("#" + _idSection + "-lastname-hidden").val());
                        $("#" + _idSection + "-firstnameen").val($("#" + _idSection + "-firstnameen-hidden").val());
                        $("#" + _idSection + "-middlenameen").val($("#" + _idSection + "-middlenameen-hidden").val());
                        $("#" + _idSection + "-lastnameen").val($("#" + _idSection + "-lastnameen-hidden").val());
                        Util.checkSetValue({
                            id: (_idSection + "-alive"),
                            value: $("#" + _idSection + "-alive-hidden").val()
                        });

                        if (_this1.isProgramContract)
                            $("#" + _idSection + "-birthdate").val($("#" + _idSection + "-birthdate-hidden").val());

                        $("#" + _idSection + "-age").html($("#" + _idSection + "-age-hidden").val());
                        Util.comboboxSetValue({
                            id: ("#" + _idSection + "-birthplace"),
                            value: $("#" + _idSection + "-birthplace-hidden").val()
                        });
                        Util.comboboxSetValue({
                            id: ("#" + _idSection + "-nationality"),
                            value: $("#" + _idSection + "-nationality-hidden").val()
                        });
                        /*
                        Util.comboboxSetValue({
                            id: ("#" + _idSection + "-race"),
                            value: $("#" + _idSection + "-race-hidden").val()
                        });
                        */
                        if (MSent.consentField.religion.isConsent) {
                            Util.comboboxSetValue({
                                id: ("#" + _idSection + "-religion"),
                                value: $("#" + _idSection + "-religion-hidden").val()
                            });
                        }
                        /*
                        Util.checkSetValue({
                            id: (_idSection + "-bloodgroup"),
                            value: $("#" + _idSection + "-bloodgroup-hidden").val()
                        });
                        */
                        Util.checkSetValue({
                            id: (_idSection + "-maritalstatus"),
                            value: $("#" + _idSection + "-maritalstatus-hidden").val()
                        });
                        Util.checkSetValue({
                            id: (_idSection + "-educationalbackgroundperson"),
                            value: $("#" + _idSection + "-educationalbackgroundperson-hidden").val()
                        });
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent) {
                        Util.comboboxSetValue({
                            id: ("#" + _idSection + "-relationship"),
                            value: ($("#" + _idSection + "-relationship-hidden").val() != "0" ? ($("#" + _idSection + "-relationship-hidden").val() + ";" + $("#" + _idSection + "-relationshipnameen-hidden").val() + ";" + $("#" + _idSection + "-relationshipnameth-hidden").val() + ";" + $("#" + _idSection + "-genderrelationship-hidden").val()) : "0")
                        });
                        _this3.setParentOnRelationship({
                            page: _param["page"],
                            this: this,
                            reset: true
                        });
                    }
                },
                validateSave: function (_param) {
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _error = new Array();
                    var _idSection;
                    var _valueRelationship;
                    var _valueRelationshipArray;
                    var _relationshipEN = "";
                    var _i = 0;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _this4.idSectionFatherAddUpdate,
                        idMother: _this4.idSectionMotherAddUpdate,
                        idParent: _this4.idSectionParentAddUpdate
                    });
                    
                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent) {
                        _valueRelationship = Util.comboboxGetValue("#" + _idSection + "-relationship");

                        if (_valueRelationship != "0") {
                            _valueRelationshipArray = _valueRelationship.split(";");
                            _relationshipEN = (_valueRelationshipArray.length == 4 ? _valueRelationshipArray[1] : "");
                        }
                    }
                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent && Util.comboboxGetValue("#" + _idSection + "-relationship") == "0") {
                        _error[_i] = ("กรุณาเลือกความสัมพันธ์ของผู้ปกครอง;Please select relationship of parent.;" + _idSection + "-relationship-content");
                        _i++;
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent && _relationshipEN == Util.tut.subjectFamilyFather && $("#" + _idSection + "-personid-hidden").val().length == 0) {
                        _error[_i] = ("กรุณาบันทึกข้อมูลส่วนตัวของบิดา;Please enter father personal data.;" + _idSection + "-relationship-content");
                        _i++;
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent && _relationshipEN == Util.tut.subjectFamilyMother && $("#" + _idSection + "-personid-hidden").val().length == 0) {
                        _error[_i] = ("กรุณาบันทึกข้อมูลส่วนตัวของมารดา;Please enter mother personal data.;" + _idSection + "-relationship-content");
                        _i++;
                    }

                    if (_this1.isProgramContract) {
                        if ($("#" + _idSection + "-idcard").val().length == 0) {
                            _error[_i] = ("กรุณาใส่เลขประจำตัวประชาชนหรือเลขหนังสือเดินทาง;Please enter identification number or passport no.;" + _idSection + "-idcard-content");
                            _i++;
                        }
                    }

                    if (Util.comboboxGetValue("#" + _idSection + "-titleprefix") == "0") {
                        _error[_i] = ("กรุณาเลือกคำนำหน้า;Please select title.;" + _idSection + "-titleprefix-content");
                        _i++;
                    }

                    if ($("#" + _idSection + "-firstname").val().length == 0) {
                        _error[_i] = ("กรุณาใส่ชื่อ;Please enter first name.;" + _idSection + "-firstname-content");
                        _i++;
                    }

                    if ($("#" + _idSection + "-lastname").val().length == 0) {
                        _error[_i] = ("กรุณาใส่นามสกุล;Please enter last name.;" + _idSection + "-lastname-content");
                        _i++;
                    }

                    if ($("input[name=" + _idSection + "-maritalstatus]:radio").is(":checked") == false) {
                        _error[_i] = ("กรุณาเลือกสถานภาพทางการสมรส;Please select marital status.;" + _idSection + "-maritalstatus-content");
                        _i++;
                    }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                },
            },
            address: {
                permanentaddress: {
                    idSectionFatherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate.toLowerCase(),
                    idSectionMotherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate.toLowerCase(),
                    idSectionParentAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate.toLowerCase(),
                    initMain: function (_param) {
                        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                        _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                        var _this1 = Util.tut.tsr;
                        var _this2 = _this1.sectionAddUpdate;
                        var _this3 = _this2.family.address;

                        _this3.initMainSection({
                            page: _param["page"],
                            this: this,
                            familyRelation: _param["familyRelation"]
                        });
                    },
                },
                currentaddress: {
                    idSectionFatherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate.toLowerCase(),
                    idSectionMotherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate.toLowerCase(),
                    idSectionParentAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate.toLowerCase(),
                    initMain: function (_param) {
                        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                        _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                        var _this1 = Util.tut.tsr;
                        var _this2 = _this1.sectionAddUpdate;
                        var _this3 = _this2.family.address;

                        _this3.initMainSection({
                            page: _param["page"],
                            this: this,
                            familyRelation: _param["familyRelation"]
                        });
                    },
                },
                initMainSection: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                    _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);
                    
                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _idSection;
                    var _idSrc;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _param["this"].idSectionFatherAddUpdate,
                        idMother: _param["this"].idSectionMotherAddUpdate,
                        idParent: _param["this"].idSectionParentAddUpdate
                    });
                    _idSrc = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _this4.permanentaddress.idSectionFatherAddUpdate,
                        idMother: _this4.permanentaddress.idSectionMotherAddUpdate,
                        idParent: _this4.permanentaddress.idSectionParentAddUpdate
                    });

                    $("#" + _idSection + "-form .form-content .inputbox").width(418);
                    $("#" + _idSection + "-postalcode").attr("maxlength", "10");
                    Util.initCombobox({
                        id: ("#" + _idSection + "-country"),
                        width: 426,
                        height: 29
                    });                

                    $("input:text").keypress(function (_e) {
                        if ($(this).attr("id") == (_idSection + "-postalcode"))
                            return Util.blockNonZipPostalCode(this, _e);

                        if ($(this).attr("id") == (_idSection + "-phonenumber"))
                            return Util.blockNonPhoneNumber(this, _e, false, false);

                        if ($(this).attr("id") == (_idSection + "-mobilenumber"))
                            return Util.blockNonPhoneNumber(this, _e, false, false);

                        if ($(this).attr("id") == (_idSection + "-faxnumber"))
                            return Util.blockNonPhoneNumber(this, _e, false, false);
                    });

                    $("input:text").focusout(function () {
                        if ($(this).attr("id") == (_idSection + "-postalcode")) {
                            $(this).val($(this).val().toUpperCase());
                        }
                    });

                    $("#" + _idSection + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-copy") == true)
                            _this2.copyAddress({
                                copy: true,
                                idSrc: _idSrc,
                                idDes: _idSection,
                            });

                        if ($(this).hasClass("button-save") == true)
                            _this2.confirmSave({
                                page: _param["page"]
                            });

                        if ($(this).hasClass("button-undo") == true)
                            _this4.resetMain({
                                page: _param["page"],
                                this: _param["this"],
                                familyRelation: _param["familyRelation"]
                            });
                    });
                        
                    _this4.resetMain({
                        page: _param["page"],
                        this: _param["this"],
                        familyRelation: _param["familyRelation"]
                    });
                },
                resetMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                    _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _idSection;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _param["this"].idSectionFatherAddUpdate,
                        idMother: _param["this"].idSectionMotherAddUpdate,
                        idParent: _param["this"].idSectionParentAddUpdate
                    });
                    
                    Util.dialogMessageClose();
                    Util.gotoTopElement();
                    Util.resetForm({
                        id: (_idSection + "-form")
                    });

                    if (_param["familyRelation"] == Util.tut.subjectFamilyFather || _param["familyRelation"] == Util.tut.subjectFamilyMother)
                        _this2.copyAddress({
                            copy: true,
                            idSrc: _idSection,
                            idDes: _idSection
                        });

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent)
                        _this3.setParentOnRelationship({
                            page: _param["page"],
                            this: _param["this"],
                            reset: true
                        });
                },
                validateSave: function (_param) {
                    _param["this"] = (_param["this"] == undefined || _param["this"] == "" ? null : _param["this"]);
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _error = new Array();
                    var _idSection;                    
                    var _i = 0;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _param["this"].idSectionFatherAddUpdate,
                        idMother: _param["this"].idSectionMotherAddUpdate,
                        idParent: _param["this"].idSectionParentAddUpdate
                    });
                    
                    if (_param["familyRelation"] == Util.tut.subjectFamilyFather && $("#" + _this3.personal.idSectionFatherAddUpdate + "-personid-hidden").val().length == 0) {
                        _error[_i] = "กรุณาบันทึกข้อมูลส่วนตัวของบิดา;Please enter father personal data.;";
                        _i++;
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyMother && $("#" + _this3.personal.idSectionMotherAddUpdate + "-personid-hidden").val().length == 0) {
                        _error[_i] = "กรุณาบันทึกข้อมูลส่วนตัวของมารดา;Please enter mother personal data.;";
                        _i++;
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent && $("#" + _this3.personal.idSectionParentAddUpdate + "-relationship-hidden").val() == "0") {
                        _error[_i] = "กรุณาบันทึกข้อมูลส่วนตัวของผู้ปกครอง;Please enter parent personal data.;";
                        _i++;
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent && $("#" + _this3.personal.idSectionParentAddUpdate + "-relationship-hidden").val() != "0" && $("#" + _this3.personal.idSectionParentAddUpdate + "-relationship-hidden").val() != $("#" + _idSection + "-defaultrelationship-hidden").val()) {
                        _error[_i] = "กรุณาบันทึกข้อมูลส่วนตัวของผู้ปกครอง;Please enter parent personal data.;";
                        _i++;
                    }

                    if (Util.comboboxGetValue("#" + _idSection + "-country") == "0") {
                        _error[_i] = ("กรุณาเลือกประเทศ;Please select country.;" + _idSection + "-country-content");
                        _i++;
                    }

                    if ($("#" + _idSection + "-addressnumber").val().length == 0) {
                        _error[_i] = ("กรุณาใส่บ้านเลขที่;Please enter address number.;" + _idSection + "-addressnumber-content");
                        _i++;
                    }

                    if ($("#" + _idSection + "-phonenumber").val().length == 0 && $("#" + _idSection + "-mobilenumber").val().length == 0) {
                        _error[_i] = ("กรุณาใส่เบอร์โทรศัพท์บ้านหรือเบอร์โทรศัพท์มือถือ;Please enter phone number or mobile number.;" + _idSection + "-phonenumber-content");
                        _i++;
                    }

                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                }
            },
            work: {
                idSectionFatherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyFatherWorkAddUpdate.toLowerCase(),
                idSectionMotherAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyMotherWorkAddUpdate.toLowerCase(),
                idSectionParentAddUpdate: ePFStaffUtil.idSectionAdministrationStudentRecordsFamilyParentWorkAddUpdate.toLowerCase(),
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _idSection;
                    var _widthCombobox = 426;
                    var _heightCombobox = 29;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _this4.idSectionFatherAddUpdate,
                        idMother: _this4.idSectionMotherAddUpdate,
                        idParent: _this4.idSectionParentAddUpdate
                    });

                    $("#" + _idSection + "-form .form-content .inputbox").width(418);
                    $("#" + _idSection + "-form .form-subcontent .inputbox").width(395);
                    $("#" + _idSection + "-workplacesalary").width(120).attr("maxlength", "10");
                    Util.initCombobox({
                        id: ("#" + _idSection + "-occupation"),
                        width: _widthCombobox,
                        height: _heightCombobox
                    });
                    Util.initCombobox({
                        id: ("#" + _idSection + "-agency"),
                        width: _widthCombobox,
                        height: _heightCombobox
                    });
                    Util.initCheck({
                        id: (_idSection + "-agencyother")
                    });

                    $("input:text").keyup(function () {
                        if ($(this).attr("id") == (_idSection + "-workplacesalary"))
                            return Util.extractNumber(this, 2, false);
                    });

                    $("input:text").keypress(function (_e) {
                        if ($(this).attr("id") == (_idSection + "-workplacetelephone"))
                            return Util.blockNonPhoneNumber(this, _e, false, false);

                        if ($(this).attr("id") == (_idSection + "-workplacesalary"))
                            return Util.blockNonNumbers(this, _e, true, false);
                    });

                    $("input:text").focusout(function () {
                        if ($(this).attr("id") == (_idSection + "-workplacesalary")) {
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val($(this).val().length > 10 ? $(this).val().substring($(this).val().length, $(this).val().length - 10) : $(this).val());
                            $(this).val(Util.delCommas($(this).attr("id")));
                            Util.addCommas($(this).attr("id"), 2);
                            $(this).val(Util.blockCharNotWanted($(this).val()));
                        }
                    });

                    $(".radio").on("ifChecked", function () {
                        if ($(this).attr("name") == (_idSection + "-agencyother"))
                            Util.setInputOtherOnCheck({
                                id: $(this).attr("name"),
                                value: "0",
                                idCombobox: ("#" + _idSection + "-agency"),
                                idTextboxOther: ("#" + _idSection + "-agencyotherdetail")
                            });
                    });

                    $("#" + _idSection + "-form .button .click-button").click(function () {
                        if ($(this).hasClass("button-save") == true)
                            _this2.confirmSave({
                                page: _param["page"]
                            });

                        if ($(this).hasClass("button-undo") == true)
                            _this4.resetMain({
                                page: _param["page"],
                                familyRelation: _param["familyRelation"]
                            });
                    });

                    _this4.resetMain({
                        page: _param["page"],
                        familyRelation: _param["familyRelation"]
                    });
                },
                resetMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _idSection;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _this4.idSectionFatherAddUpdate,
                        idMother: _this4.idSectionMotherAddUpdate,
                        idParent: _this4.idSectionParentAddUpdate
                    });
                        
                    Util.dialogMessageClose();
                    Util.gotoTopElement();
                    Util.resetForm({
                        id: (_idSection + "-form")
                    });

                    if (_param["familyRelation"] == Util.tut.subjectFamilyFather || _param["familyRelation"] == Util.tut.subjectFamilyMother)
                        _this2.copyWork({
                            copy: true,
                            idSrc: _idSection,
                            idDes: _idSection
                        });

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent)
                        _this3.setParentOnRelationship({
                            page: _param["page"],
                            this: this,
                            reset: true
                        });
                },
                validateSave: function (_param) {
                    _param["familyRelation"] = (_param["familyRelation"] == undefined ? "" : _param["familyRelation"]);

                    var _this1 = Util.tut.tsr;
                    var _this2 = _this1.sectionAddUpdate;
                    var _this3 = _this2.family;
                    var _this4 = this;
                    var _error = new Array();
                    var _idSection;
                    var _i = 0;

                    _param["familyRelation"] = Util.toUpperCaseFirst(_param["familyRelation"]);
                    _idSection = _this3.getSectionByFamilyRelation({
                        familyRelation: _param["familyRelation"],
                        idFather: _this4.idSectionFatherAddUpdate,
                        idMother: _this4.idSectionMotherAddUpdate,
                        idParent: _this4.idSectionParentAddUpdate
                    });
                   
                    if (_param["familyRelation"] == Util.tut.subjectFamilyFather && $("#" + _this3.personal.idSectionFatherAddUpdate + "-personid-hidden").val().length == 0) {
                        _error[_i] = "กรุณาบันทึกข้อมูลส่วนตัวของบิดา;Please enter father personal data.;";
                        _i++;
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyMother && $("#" + _this3.personal.idSectionMotherAddUpdate + "-personid-hidden").val().length == 0) {
                        _error[_i] = "กรุณาบันทึกข้อมูลส่วนตัวของมารดา;Please enter mother personal data.;";
                        _i++;
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent && $("#" + _this3.personal.idSectionParentAddUpdate + "-relationship-hidden").val() == "0") {
                        _error[_i] = "กรุณาบันทึกข้อมูลส่วนตัวของผู้ปกครอง;Please enter parent personal data.;";
                        _i++;
                    }

                    if (_param["familyRelation"] == Util.tut.subjectFamilyParent && $("#" + _this3.personal.idSectionParentAddUpdate + "-relationship-hidden").val() != "0" && $("#" + _this3.personal.idSectionParentAddUpdate + "-relationship-hidden").val() != $("#" + _idSection + "-defaultrelationship-hidden").val()) {
                        _error[_i] = "กรุณาบันทึกข้อมูลส่วนตัวของผู้ปกครอง;Please enter parent personal data.;";
                        _i++;
                    }

                    if (Util.comboboxGetValue("#" + _idSection + "-occupation") == "0") {
                        _error[_i] = ("กรุณาเลือกอาชีพ;Please select occupation.;" + _idSection + "-occupation-content");
                        _i++;
                    }

                    if (Util.checkGetValue(_idSection + "-agencyother") == "0" && $("#" + _idSection + "-agencyotherdetail").val().length == 0) {
                        _error[_i] = ("กรุณาใส่ต้นสังกัด;Please enter other agency.;" + _idSection + "-agency-content");
                        _i++;
                    }
                        
                    Util.dialogListMessageError({
                        content: _error
                    });

                    return (_i > 0 ? false : true);
                }
            }
        },        
        confirmSave: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

            var _this = this;
            
            Util.dialogMessageConfirm({
                content: "<div class='th-label'>ต้องการบันทึกข้อมูลนี้หรือไม่</div><div class='en-label'>Do you want to save changes ?</div>",
                button: {
                    msgYes: "OK",
                    msgNo: "CANCEL"
                }
            }, function (_result) {                
                if (_result == "Y") {
                    if (_this.validateSave({
                        page: _param["page"]
                    }))
                        _this.getSave({
                            page: _param["page"]
                        });
                }
            });
        },
        validateSave: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

            var _this = null;
            var _validateResult = true;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsPersonalAddUpdate)
                _this = this.personal;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressPermanentAddUpdate)
                _validateResult = this.address.validateSave({
                    this: this.address.permanentaddress
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressCurrentAddUpdate)
                _validateResult = this.address.validateSave({
                    this: this.address.currentaddress
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationPrimarySchoolAddUpdate)
                _this = this.education.primaryschool;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate)
                _this = this.education.juniorhighschool;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationHighSchoolAddUpdate)
                _this = this.education.highschool;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationUniversityAddUpdate)
                _this = this.education.university;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationAdmissionScoresAddUpdate)
                _this = this.education.admissionscores;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsTalentAddUpdate)
                _this = this.talent;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsHealthyAddUpdate)
                _this = this.healthy;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsWorkAddUpdate)
                _this = this.work;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFinancialAddUpdate)
                _this = this.financial;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate)
                _validateResult = this.family.personal.validateSave({
                    familyRelation: Util.tut.subjectFamilyFather
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate)
                _validateResult = this.family.personal.validateSave({
                    familyRelation: Util.tut.subjectFamilyMother
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate)
                _validateResult = this.family.personal.validateSave({
                    familyRelation: Util.tut.subjectFamilyParent
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate)
                _validateResult = this.family.address.validateSave({
                    this: this.family.address.permanentaddress,
                    familyRelation: Util.tut.subjectFamilyFather
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate)
                _validateResult = this.family.address.validateSave({
                    this: this.family.address.permanentaddress,
                    familyRelation: Util.tut.subjectFamilyMother
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate)
                _validateResult = this.family.address.validateSave({
                    this: this.family.address.permanentaddress,
                    familyRelation: Util.tut.subjectFamilyParent
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate)
                _validateResult = this.family.address.validateSave({
                    this: this.family.address.currentaddress,
                    familyRelation: Util.tut.subjectFamilyFather
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate)
                _validateResult = this.family.address.validateSave({
                    this: this.family.address.currentaddress,
                    familyRelation: Util.tut.subjectFamilyMother
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate)
                _validateResult = this.family.address.validateSave({
                    this: this.family.address.currentaddress,
                    familyRelation: Util.tut.subjectFamilyParent
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate)
                _validateResult = this.family.work.validateSave({
                    familyRelation: Util.tut.subjectFamilyFather
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate)
                _validateResult = this.family.work.validateSave({
                    familyRelation: Util.tut.subjectFamilyMother
                });

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate)
                _validateResult = this.family.work.validateSave({
                    familyRelation: Util.tut.subjectFamilyParent
                });

            if (_this != null)
                _validateResult = _this.validateSave();

            return _validateResult;
        },
        getSave: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

            var _this1;
            var _this2 = this;
            var _this3 = Util.tut.tsr;
            var _error;
            var _msg;
            var _i;
            var _value;
            var _valueArray;
            var _valueSave = {};
            var _valueTitlePrefix = "";
            var _valueGender = "";
            var _valueDistrict = "";
            var _valueRelationship;
            var _valueRelationshipArray;
            var _valueFamilyRelation = "";
            var _familyRelation;
            var _idSection;

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsPersonalAddUpdate) {           
                _this1 = _this2.personal;
                _value = Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-titleprefix");

                if (_value != "0") {
                    _valueArray = _value.split(";");
                    _valueTitlePrefix = _valueArray[0];
                }

                _valueSave["idcard"] = $("#" + _this1.idSectionAddUpdate + "-idcard").val();
                _valueSave["idcardissuedate"] = $("#" + _this1.idSectionAddUpdate + "-idcardissuedate").val();
                _valueSave["idcardexpirydate"] = $("#" + _this1.idSectionAddUpdate + "-idcardexpirydate").val();
                _valueSave["titleprefix"] = _valueTitlePrefix;
                _valueSave["firstname"] = $("#" + _this1.idSectionAddUpdate + "-firstname").val();
                _valueSave["middlename"] = $("#" + _this1.idSectionAddUpdate + "-middlename").val();
                _valueSave["lastname"] = $("#" + _this1.idSectionAddUpdate + "-lastname").val();
                _valueSave["firstnameen"] = $("#" + _this1.idSectionAddUpdate + "-firstnameen").val();
                _valueSave["middlenameen"] = $("#" + _this1.idSectionAddUpdate + "-middlenameen").val();
                _valueSave["lastnameen"] = $("#" + _this1.idSectionAddUpdate + "-lastnameen").val();
                _valueSave["gender"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-gender"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-gender")
                });
                _valueSave["alive"] = "Y";
                _valueSave["birthdate"] = $("#" + _this1.idSectionAddUpdate + "-birthdate").val();
                _valueSave["country"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-birthplace"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-birthplace")
                });
                _valueSave["nationality"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-nationality"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-nationality")
                });
                /*
                _valueSave["origin"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-race"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-race")
                });
                */
                _valueSave["origin"] = $("#" + _this1.idSectionAddUpdate + "-race-hidden").val();

                if (MSent.consentField.religion.isConsent) {
                    _valueSave["religion"] = Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-religion"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-religion")
                    });
                }
                else
                    _valueSave["religion"] = $("#" + _this1.idSectionAddUpdate + "-religion-hidden").val();

                /*
                _valueSave["bloodtype"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-bloodgroup"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-bloodgroup")
                });
                */
                _valueSave["bloodtype"] = $("#" + _this1.idSectionAddUpdate + "-bloodgroup-hidden").val();
                _valueSave["maritalstatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-maritalstatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-maritalstatus")
                });
                _valueSave["educationalbackground"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-educationalbackgroundperson"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-educationalbackgroundperson")
                });
                _valueSave["email"] = $("#" + _this1.idSectionAddUpdate + "-email").val();
                _valueSave["brotherhoodnumber"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-brotherhood"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-brotherhood")
                });  
                //$("#" + _this1.idSectionAddUpdate + "-brotherhood").val();
                //Util.delCommas(_this1.idSectionAddUpdate + "-brotherhood");
                _valueSave["childhoodnumber"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-childhood"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-childhood")
                }); 
                //$("#" + _this1.idSectionAddUpdate + "-childhood").val();
                //Util.delCommas(_this1.idSectionAddUpdate + "-childhood");
                _valueSave["studyhoodnumber"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-studyhood"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-studyhood")
                }); 
                //$("#" + _this1.idSectionAddUpdate + "-studyhood").val();
                //Util.delCommas(_this1.idSectionAddUpdate + "-studyhood");
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressPermanentAddUpdate) {
                _this1 = _this2.address.permanentaddress;
                _value = Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-district");

                if (_value != "0") {
                    _valueArray = _value.split(";");
                    _valueDistrict = _valueArray[0];
                }

                _valueSave["countrypermanent"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-country")
                });
                _valueSave["provincepermanent"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-province"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-province")
                });
                _valueSave["districtpermanent"] = _valueDistrict;
                _valueSave["subdistrictpermanent"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-subdistrict"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-subdistrict")
                });
                _valueSave["zipcodepermanent"] = $("#" + _this1.idSectionAddUpdate + "-postalcode").val();
                _valueSave["villagepermanent"] = $("#" + _this1.idSectionAddUpdate + "-village").val();
                _valueSave["nopermanent"] = $("#" + _this1.idSectionAddUpdate + "-addressnumber").val();
                _valueSave["moopermanent"] = $("#" + _this1.idSectionAddUpdate + "-villageno").val();
                _valueSave["soipermanent"] = $("#" + _this1.idSectionAddUpdate + "-lanealley").val();
                _valueSave["roadpermanent"] = $("#" + _this1.idSectionAddUpdate + "-road").val();
                _valueSave["phonenumberpermanent"] = $("#" + _this1.idSectionAddUpdate + "-phonenumber").val();
                _valueSave["mobilenumberpermanent"] = $("#" + _this1.idSectionAddUpdate + "-mobilenumber").val();
                _valueSave["faxnumberpermanent"] = $("#" + _this1.idSectionAddUpdate + "-faxnumber").val();
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressCurrentAddUpdate) {
                _this1 = _this2.address.currentaddress;
                _value = Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-district");

                if (_value != "0") {
                    _valueArray = _value.split(";");
                    _valueDistrict = _valueArray[0];
                }

                _valueSave["countrycurrent"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-country"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-country")
                });
                _valueSave["provincecurrent"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-province"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-province")
                });
                _valueSave["districtcurrent"] = _valueDistrict;
                _valueSave["subdistrictcurrent"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-subdistrict"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-subdistrict")
                });
                _valueSave["zipcodecurrent"] = $("#" + _this1.idSectionAddUpdate + "-postalcode").val();
                _valueSave["villagecurrent"] = $("#" + _this1.idSectionAddUpdate + "-village").val();
                _valueSave["nocurrent"] = $("#" + _this1.idSectionAddUpdate + "-addressnumber").val();
                _valueSave["moocurrent"] = $("#" + _this1.idSectionAddUpdate + "-villageno").val();
                _valueSave["soicurrent"] = $("#" + _this1.idSectionAddUpdate + "-lanealley").val();
                _valueSave["roadcurrent"] = $("#" + _this1.idSectionAddUpdate + "-road").val();
                _valueSave["phonenumbercurrent"] = $("#" + _this1.idSectionAddUpdate + "-phonenumber").val();
                _valueSave["mobilenumbercurrent"] = $("#" + _this1.idSectionAddUpdate + "-mobilenumber").val();
                _valueSave["faxnumbercurrent"] = $("#" + _this1.idSectionAddUpdate + "-faxnumber").val();
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationPrimarySchoolAddUpdate) {
                _this1 = _this2.education.primaryschool;
            
                _valueSave["primaryschoolname"] = $("#" + _this1.idSectionAddUpdate + "-institutename").val();
                _valueSave["countryprimaryschool"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-institutecountry")
                });
                _valueSave["provinceprimaryschool"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-instituteprovince")
                });
                _valueSave["primaryschoolyearattended"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended")
                });
                //Util.delCommas(_this1.idSectionAddUpdate + "-yearattended");
                _valueSave["primaryschoolyeargraduate"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yeargraduate")
                });
                //Util.delCommas(_this1.idSectionAddUpdate + "-yeargraduate");
                _valueSave["primarySchoolgpa"] = Util.delCommas(_this1.idSectionAddUpdate + "-gpa");
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate) {
                _this1 = _this2.education.juniorhighschool;

                _valueSave["juniorhighschoolname"] = $("#" + _this1.idSectionAddUpdate + "-institutename").val();
                _valueSave["countryjuniorhighschool"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-institutecountry")
                });
                _valueSave["provincejuniorhighschool"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-instituteprovince")
                });
                _valueSave["juniorhighschoolyearattended"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended")
                });
                //Util.delCommas(_this1.idSectionAddUpdate + "-yearattended");
                _valueSave["juniorhighschoolyeargraduate"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yeargraduate")
                });
                //Util.delCommas(_this1.idSectionAddUpdate + "-yeargraduate");
                _valueSave["juniorhighschoolgpa"] = Util.delCommas(_this1.idSectionAddUpdate + "-gpa");
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationHighSchoolAddUpdate) {
                _this1 = _this2.education.highschool;
            
                _valueSave["highschoolname"] = $("#" + _this1.idSectionAddUpdate + "-institutename").val();
                _valueSave["countryhighschool"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-institutecountry")
                });
                _valueSave["provincehighschool"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-instituteprovince")
                });
                _valueSave["highschoolstudentid"] = $("#" + _this1.idSectionAddUpdate + "-studentid").val();
                _valueSave["educationalmajorhighschool"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-educationalmajor"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-educationalmajor")
                });
                _valueSave["educationalmajorotherhighschool"] = $("#" + _this1.idSectionAddUpdate + "-educationalmajorother").val();
                _valueSave["highschoolyearattended"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended")
                });
                //Util.delCommas(_this1.idSectionAddUpdate + "-yearattended");
                _valueSave["highschoolyeargraduate"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yeargraduate")
                });
                //Util.delCommas(_this1.idSectionAddUpdate + "-yeargraduate");
                _valueSave["highschoolgpa"] = Util.delCommas(_this1.idSectionAddUpdate + "-gpa");
                _valueSave["educationalbackgroundhighschool"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-educationalbackground"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-educationalbackground")
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationUniversityAddUpdate) {
                _this1 = _this2.education.university;

                _valueSave["educationalbackground"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-educationalbackground"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-educationalbackground")
                });
                _valueSave["graduateby"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-graduateby"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-graduateby")
                });
                _valueSave["graduatebyschoolname"] = $("#" + _this1.idSectionAddUpdate + "-graduatebyinstitutename").val();
                _valueSave["entrancetime"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-entrancetime"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-entrancetime")
                });
                _valueSave["studentis"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-studentis"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-studentis")
                });
                _valueSave["studentisuniversity"] = $("#" + _this1.idSectionAddUpdate + "-studentisuniversity").val();
                _valueSave["studentisfaculty"] = $("#" + _this1.idSectionAddUpdate + "-studentisfaculty").val();
                _valueSave["studentisprogram"] = $("#" + _this1.idSectionAddUpdate + "-studentisprogram").val();
                _valueSave["entrancetype"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-entrancetype"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-entrancetype")
                });
                _valueSave["admissionranking"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-admissionranking"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-admissionranking")
                });
                //Util.delCommas(_this1.idSectionAddUpdate + "-admissionranking");
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationAdmissionScoresAddUpdate) {
                _this1 = _this2.education.admissionscores;

                _valueSave["scoreonet01"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresonetthai");
                _valueSave["scoreonet02"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresonetsocialscience");
                _valueSave["scoreonet03"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresonetenglish");
                _valueSave["scoreonet04"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresonetmathematics");
                _valueSave["scoreonet05"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresonetscience");
                _valueSave["scoreonet06"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresonethealthphysical");
                _valueSave["scoreonet07"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresonetarts");
                _valueSave["scoreonet08"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresonetoccupationtechnology");
                _valueSave["scoreanet11"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresanetthai2");
                _valueSave["scoreanet12"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresanetsocialscience2");
                _valueSave["scoreanet13"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresanetenglish3");
                _valueSave["scoreanet14"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresanetmathematics2");
                _valueSave["scoreanet15"] = Util.delCommas(_this1.idSectionAddUpdate + "-scoresanetscience2");
                _valueSave["scoregat85"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scoresgatgenaralaptitudetest");
                _valueSave["scorepat71"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat1");
                _valueSave["scorepat72"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat2");
                _valueSave["scorepat73"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat3");
                _valueSave["scorepat74"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat4");
                _valueSave["scorepat75"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat5");
                _valueSave["scorepat76"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat6");
                _valueSave["scorepat77"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat7");
                _valueSave["scorepat78"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat8");
                _valueSave["scorepat79"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat9");
                _valueSave["scorepat80"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat10");
                _valueSave["scorepat81"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat11");
                _valueSave["scorepat82"]  = Util.delCommas(_this1.idSectionAddUpdate + "-scorespat12");
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsTalentAddUpdate) {
                _this1 = _this2.talent;
            
                _valueSave["sportsmanstatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-sportsmanstatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-sportsmanstatus")
                });
                _valueSave["sportsmandetail"] = $("#" + _this1.idSectionAddUpdate + "-sportsmandetail").val();
                _valueSave["specialiststatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-specialiststatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialiststatus")
                });
                _valueSave["specialistsportstatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-specialistsportstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialistsportstatus")
                });
                _valueSave["specialistsportdetail"] = $("#" + _this1.idSectionAddUpdate + "-specialistsportdetail").val();
                _valueSave["specialistartstatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-specialistartstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialistartstatus")
                });
                _valueSave["specialistartdetail"] = $("#" + _this1.idSectionAddUpdate + "-specialistartdetail").val();
                _valueSave["specialisttechnicalstatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-specialisttechnicalstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialisttechnicalstatus")
                });
                _valueSave["specialisttechnicaldetail"] = $("#" + _this1.idSectionAddUpdate + "-specialisttechnicaldetail").val();
                _valueSave["specialistotherstatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-specialistotherstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialistotherstatus")
                });
                _valueSave["specialistotherdetail"] = $("#" + _this1.idSectionAddUpdate + "-specialistotherdetail").val();
                _valueSave["activitystatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-activitystatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-activitystatus")
                });
                _valueSave["activitydetail"] = $("#" + _this1.idSectionAddUpdate + "-activitydetail").val();
                _valueSave["rewardstatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-rewardstatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-rewardstatus")
                });
                _valueSave["rewarddetail"] = $("#" + _this1.idSectionAddUpdate + "-rewarddetail").val();
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsHealthyAddUpdate) {
                _this1 = _this2.healthy;

                _valueSave["bodymassdetail"] = $("#" + _this1.idSectionAddUpdate + "-bodymassdetail-hidden").val();
                //$("#" + _this1.idSectionAddUpdate + "-bodymassdetail").val();
                _valueSave["intolerancestatus"] = $("#" + _this1.idSectionAddUpdate + "-intolerancestatus-hidden").val();
                /*
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-intolerancestatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-intolerancestatus")
                });
                */
                _valueSave["intolerancedetail"] = $("#" + _this1.idSectionAddUpdate + "-intolerancedetail-hidden").val();
                //$("#" + _this1.idSectionAddUpdate + "-intolerancedetail").val();
                _valueSave["diseasesstatus"] = $("#" + _this1.idSectionAddUpdate + "-diseasesstatus-hidden").val();
                /*
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-diseasesstatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-diseasesstatus")
                });
                */
                _valueSave["diseasesdetail"] = $("#" + _this1.idSectionAddUpdate + "-diseasesdetail-hidden").val();
                //$("#" + _this1.idSectionAddUpdate + "-diseasesdetail").val();
                _valueSave["ailhistoryfamilystatus"] = $("#" + _this1.idSectionAddUpdate + "-familyhistoryofillnessstatus-hidden").val();
                /*
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-familyhistoryofillnessstatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-familyhistoryofillnessstatus")
                });
                */
                _valueSave["ailhistoryfamilydetail"] = $("#" + _this1.idSectionAddUpdate + "-familyhistoryofillnessdetail-hidden").val();
                //$("#" + _this1.idSectionAddUpdate + "-familyhistoryofillnessdetail").val();
                _valueSave["travelabroadstatus"]  = $("#" + _this1.idSectionAddUpdate + "-travelabroadstatus-hidden").val();
                /*  
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-travelabroadstatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-travelabroadstatus")
                });
                */
                _valueSave["travelabroaddetail"] = $("#" + _this1.idSectionAddUpdate + "-travelabroaddetail-hidden").val();
                //$("#" + _this1.idSectionAddUpdate + "-travelabroaddetail").val();
                _valueSave["impairmentsstatus"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-impairmentsstatus"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-impairmentsstatus")
                });
                _valueSave["impairments"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-impairmentsdetail"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-impairmentsdetail")
                });
                _valueSave["impairmentsequipment"] = $("#" + _this1.idSectionAddUpdate + "-impairmentsequipment").val();
                _valueSave["idcardpwd"] = (_valueSave["impairmentsstatus"] == 'Y' ? $("#" + _this1.idSectionAddUpdate + "-idcardpwd").val() : "");
                _valueSave["idcardpwdissuedate"] = $("#" + _this1.idSectionAddUpdate + "-idcardpwdissuedate").val();
                _valueSave["idcardpwdexpirydate"] = $("#" + _this1.idSectionAddUpdate + "-idcardpwdexpirydate").val();
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsWorkAddUpdate) {
                _this1 = _this2.work;

                _valueSave["occupation"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-occupation"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-occupation")
                });
                _valueSave["agency"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-agency"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-agency")
                });
                _valueSave["agencyother"] = $("#" + _this1.idSectionAddUpdate + "-agencyotherdetail").val();
                _valueSave["workplace"] = $("#" + _this1.idSectionAddUpdate + "-workplace").val();
                _valueSave["position"] = $("#" + _this1.idSectionAddUpdate + "-workplaceposition").val();
                _valueSave["telephone"] = $("#" + _this1.idSectionAddUpdate + "-workplacetelephone").val();
                _valueSave["salary"] = Util.delCommas(_this1.idSectionAddUpdate + "-workplacesalary");
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFinancialAddUpdate) {
                _this1 = _this2.financial;

                _valueSave["scholarshipfirstbachelor"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-scholarshipfirstbachelor"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-scholarshipfirstbachelor")
                });
                _valueSave["scholarshipfirstbachelorfrom"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelorfrom"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelorfrom")
                });
                _valueSave["scholarshipfirstbachelorname"] = $("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelorname").val();
                _valueSave["scholarshipfirstbachelormoney"] = Util.delCommas(_this1.idSectionAddUpdate + "-scholarshipfirstbachelormoney");
                _valueSave["scholarshipbachelor"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-scholarshipbachelor"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-scholarshipbachelor")
                });
                _valueSave["scholarshipbachelorfrom"] = Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-scholarshipbachelorfrom"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-scholarshipbachelorfrom")
                });
                _valueSave["scholarshipbachelorname"] = $("#" + _this1.idSectionAddUpdate + "-scholarshipbachelorname").val();
                _valueSave["scholarshipbachelormoney"] = Util.delCommas(_this1.idSectionAddUpdate + "-scholarshipbachelormoney");
                _valueSave["worked"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-worked"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-worked")
                });
                _valueSave["salary"] = Util.delCommas(_this1.idSectionAddUpdate + "-salary");
                _valueSave["workplace"] = $("#" + _this1.idSectionAddUpdate + "-workplace").val();
                _valueSave["gotmoneyfrom"] = Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-gotmoneyfrom"),
                    type: "radio",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-gotmoneyfrom")
                });
                _valueSave["gotmoneyfromother"] = $("#" + _this1.idSectionAddUpdate + "-gotmoneyfromother").val();
                _valueSave["gotmoneypermonth"] = Util.delCommas(_this1.idSectionAddUpdate + "-gotmoneypermonth");
                _valueSave["costpermonth"] = Util.delCommas(_this1.idSectionAddUpdate + "-costpermonth");
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate) {
                _familyRelation = _param["page"].replace(Util.tut.subjectSectionAdministrationStudentRecordsFamily, "")

                _valueSave["personidfather"] = $("#" + _this2.family.personal.idSectionFatherAddUpdate + "-personid-hidden").val();
                _valueSave["personidmother"] = $("#" + _this2.family.personal.idSectionMotherAddUpdate + "-personid-hidden").val();
                _valueSave["personidparent"] = $("#" + _this2.family.personal.idSectionParentAddUpdate + "-personid-hidden").val();

                if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate) {
                    _familyRelation = Util.toUpperCaseFirst(_familyRelation.replace("PersonalAddUpdate", ""));
                    _this1 = _this2.family.personal;
                    _idSection = _this2.family.getSectionByFamilyRelation({
                        familyRelation: _familyRelation,
                        idFather: _this1.idSectionFatherAddUpdate,
                        idMother: _this1.idSectionMotherAddUpdate,
                        idParent: _this1.idSectionParentAddUpdate
                    });

                    if (_familyRelation == Util.tut.subjectFamilyParent) {
                        _valueRelationship = Util.comboboxGetValue("#" + _idSection + "-relationship");

                        if (_valueRelationship != "0") {
                            _valueRelationshipArray = _valueRelationship.split(";");
                            _valueFamilyRelation = (_valueRelationshipArray.length == 4 ? _valueRelationshipArray[0] : "");
                        }

                        _valueGender = Util.getSelectionIsSelect({
                            id: (_idSection + "-gender"),
                            type: "radio",
                            valueTrue: Util.checkGetValue(_idSection + "-gender")
                        });
                    }
                    else
                        _valueGender = $("#" + _idSection + "-gender-hidden").val();

                    _value = Util.comboboxGetValue("#" + _idSection + "-titleprefix");

                    if (_value != "0") {
                        _valueArray = _value.split(";");
                        _valueTitlePrefix = _valueArray[0];
                    }

                    _valueSave["relationship"]  = _valueFamilyRelation;

                    if (_this3.isProgramContract)
                        _valueSave["idcard"] = $("#" + _idSection + "-idcard").val();
                    else
                        _valueSave["idcard"] = $("#" + _idSection + "-idcard-hidden").val();

                    _valueSave["titleprefix"] = _valueTitlePrefix;
                    _valueSave["firstname"] = $("#" + _idSection + "-firstname").val();
                    _valueSave["middlename"] = $("#" + _idSection + "-middlename").val();
                    _valueSave["lastname"] = $("#" + _idSection + "-lastname").val();
                    _valueSave["firstnameen"] = $("#" + _idSection + "-firstnameen").val();
                    _valueSave["middlenameen"] = $("#" + _idSection + "-middlenameen").val();
                    _valueSave["lastnameen"] = $("#" + _idSection + "-lastnameen").val();
                    _valueSave["gender"] = _valueGender;
                    _valueSave["alive"] = Util.getSelectionIsSelect({
                        id: (_idSection + "-alive"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_idSection + "-alive")
                    });

                    if (_this3.isProgramContract)
                        _valueSave["birthdate"] = $("#" + _idSection + "-birthdate").val();
                    else
                        _valueSave["birthdate"] = $("#" + _idSection + "-birthdate-hidden").val();

                    _valueSave["country"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-birthplace"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-birthplace")
                    });
                    _valueSave["nationality"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-nationality"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-nationality")
                    });
                    /*
                    _valueSave["origin"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-race"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-race")
                    });
                    */
                    _valueSave["origin"] = $("#" + _idSection + "-race-hidden").val();

                    if (MSent.consentField.religion.isConsent) {
                        _valueSave["religion"] = Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-religion"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-religion")
                        });
                    }
                    else
                        _valueSave["religion"] = $("#" + _idSection + "-religion-hidden").val();

                    /*
                    _valueSave["bloodtype"] = Util.getSelectionIsSelect({
                        id: (_idSection + "-bloodgroup"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_idSection + "-bloodgroup")
                    });
                    */
                    _valueSave["bloodtype"] = $("#" + _idSection + "-bloodgroup-hidden").val();
                    _valueSave["maritalstatus"] = Util.getSelectionIsSelect({
                        id: (_idSection + "-maritalstatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_idSection + "-maritalstatus")
                    });
                    _valueSave["educationalbackground"] = Util.getSelectionIsSelect({
                        id: (_idSection + "-educationalbackgroundperson"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_idSection + "-educationalbackgroundperson")
                    });
                }

                if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate) {
                    _familyRelation = Util.toUpperCaseFirst(_familyRelation.replace("AddressPermanentAddUpdate", ""));
                    _this1 = _this2.family.address.permanentaddress;
                    _idSection = _this2.family.getSectionByFamilyRelation({
                        familyRelation: _familyRelation,
                        idFather: _this1.idSectionFatherAddUpdate,
                        idMother: _this1.idSectionMotherAddUpdate,
                        idParent: _this1.idSectionParentAddUpdate
                    });

                    _value = Util.comboboxGetValue("#" + _idSection + "-district");

                    if (_value != "0") {
                        _valueArray = _value.split(";");
                        _valueDistrict = _valueArray[0];
                    }

                    _valueSave["countrypermanent"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-country"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-country")
                    });
                    _valueSave["provincepermanent"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-province"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-province")
                    });
                    _valueSave["districtpermanent"] = _valueDistrict;
                    _valueSave["subdistrictpermanent"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-subdistrict"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-subdistrict")
                    });
                    _valueSave["zipcodepermanent"] = $("#" + _idSection + "-postalcode").val();
                    _valueSave["villagepermanent"] = $("#" + _idSection + "-village").val();
                    _valueSave["nopermanent"] = $("#" + _idSection + "-addressnumber").val();
                    _valueSave["moopermanent"] = $("#" + _idSection + "-villageno").val();
                    _valueSave["soipermanent"] = $("#" + _idSection + "-lanealley").val();
                    _valueSave["roadpermanent"] = $("#" + _idSection + "-road").val();
                    _valueSave["phonenumberpermanent"] = $("#" + _idSection + "-phonenumber").val();
                    _valueSave["mobilenumberpermanent"] = $("#" + _idSection + "-mobilenumber").val();
                    _valueSave["faxnumberpermanent"] = $("#" + _idSection + "-faxnumber").val();
                }

                if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate) {
                    _familyRelation = Util.toUpperCaseFirst(_familyRelation.replace("AddressCurrentAddUpdate", ""));
                    _this1 = _this2.family.address.currentaddress;
                    _idSection = _this2.family.getSectionByFamilyRelation({
                        familyRelation: _familyRelation,
                        idFather: _this1.idSectionFatherAddUpdate,
                        idMother: _this1.idSectionMotherAddUpdate,
                        idParent: _this1.idSectionParentAddUpdate
                    });

                    _value = Util.comboboxGetValue("#" + _idSection + "-district");

                    if (_value != "0") {
                        _valueArray = _value.split(";");
                        _valueDistrict = _valueArray[0];
                    }

                    _valueSave["countrycurrent"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-country"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-country")
                    });
                    _valueSave["provincecurrent"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-province"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-province")
                    });
                    _valueSave["districtcurrent"] = _valueDistrict;
                    _valueSave["subdistrictcurrent"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-subdistrict"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-subdistrict")
                    });
                    _valueSave["zipcodecurrent"] = $("#" + _idSection + "-postalcode").val();
                    _valueSave["villagecurrent"] = $("#" + _idSection + "-village").val();
                    _valueSave["nocurrent"] = $("#" + _idSection + "-addressnumber").val();
                    _valueSave["moocurrent"] = $("#" + _idSection + "-villageno").val();
                    _valueSave["soicurrent"] = $("#" + _idSection + "-lanealley").val();
                    _valueSave["roadcurrent"] = $("#" + _idSection + "-road").val();
                    _valueSave["phonenumbercurrent"] = $("#" + _idSection + "-phonenumber").val();
                    _valueSave["mobilenumbercurrent"] = $("#" + _idSection + "-mobilenumber").val();
                    _valueSave["faxnumbercurrent"] = $("#" + _idSection + "-faxnumber").val();
                }

                if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate) {
                    _familyRelation = Util.toUpperCaseFirst(_familyRelation.replace("WorkAddUpdate", ""));
                    _this1 = _this2.family.work;
                    _idSection = _this2.family.getSectionByFamilyRelation({
                        familyRelation: _familyRelation,
                        idFather: _this1.idSectionFatherAddUpdate,
                        idMother: _this1.idSectionMotherAddUpdate,
                        idParent: _this1.idSectionParentAddUpdate
                    });

                    _valueSave["occupation"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-occupation"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-occupation")
                    });
                    _valueSave["agency"] = Util.getSelectionIsSelect({
                        id: ("#" + _idSection + "-agency"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _idSection + "-agency")
                    });
                    _valueSave["agencyother"] = $("#" + _idSection + "-agencyotherdetail").val();
                    _valueSave["workplace"] = $("#" + _idSection + "-workplace").val();
                    _valueSave["position"] = $("#" + _idSection + "-workplaceposition").val();
                    _valueSave["telephone"] = $("#" + _idSection + "-workplacetelephone").val();
                    _valueSave["salary"] = Util.delCommas(_idSection + "-workplacesalary");
                }
            }
            
            this.actionSave({
                page: _param["page"],
                data: _valueSave
            }, function (_resultSave, _resultValueSave) {
                if (_resultSave == true) {
                    _this2.setValueDataRecorded({
                        page: _param["page"],
                        data: _resultValueSave
                    });

                    Util.dialogMessageBox({
                        content: "<div class='th-label'>บันทึกข้อมูลเรียบร้อย</div><div class='en-label'>Save complete.</div>"
                    });
                    Util.gotoTopElement();
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
            _send["id"] = $("#" + this.studentrecords.idSectionAddUpdate + "-personid-hidden").val();

            Util.msgPreloading = "Saving...";

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
        setValueDataRecorded: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["data"] = (_param["data"] == undefined ? "" : _param["data"]);

            var _this1;
            var _this2 = this;
            var _this3 = _this2.studentrecords;
            var _this4 = Util.tut.tsr;
            var _value;
            var _valueArray;
            var _valueTitlePrefix = "";
            var _valueGender = "";
            var _valueDistrict = "";
            var _valuePostalCode = "";
            var _valueRelationship;
            var _valueRelationshipArray;
            var _valueFamilyRelation = "";
            var _relationshipTH = "";
            var _relationshipEN = "";
            var _familyRelation;
            var _idSection;
            
            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsPersonalAddUpdate) {                
                _this1 = _this2.personal;
                _value = Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-titleprefix");

                if (_value != "0") {
                    _valueArray = _value.split(";");
                    _valueTitlePrefix = _valueArray[0];
                    _valueGender = _valueArray[1];
                }

                $("#" + _this1.idSectionAddUpdate + "-idcard-hidden").val($("#" + _this1.idSectionAddUpdate + "-idcard").val());
                $("#" + _this1.idSectionAddUpdate + "-idcardissuedate-hidden").val($("#" + _this1.idSectionAddUpdate + "-idcardissuedate").val());
                $("#" + _this1.idSectionAddUpdate + "-idcardexpirydate-hidden").val($("#" + _this1.idSectionAddUpdate + "-idcardexpirydate").val());
                $("#" + _this1.idSectionAddUpdate + "-titleprefix-hidden").val(_valueTitlePrefix);
                $("#" + _this1.idSectionAddUpdate + "-gendertitleprefix-hidden").val(_valueGender);
                $("#" + _this1.idSectionAddUpdate + "-firstname-hidden").val($("#" + _this1.idSectionAddUpdate + "-firstname").val());
                $("#" + _this1.idSectionAddUpdate + "-middlename-hidden").val($("#" + _this1.idSectionAddUpdate + "-middlename").val());
                $("#" + _this1.idSectionAddUpdate + "-lastname-hidden").val($("#" + _this1.idSectionAddUpdate + "-lastname").val());
                $("#" + _this1.idSectionAddUpdate + "-firstnameen-hidden").val($("#" + _this1.idSectionAddUpdate + "-firstnameen").val());
                $("#" + _this1.idSectionAddUpdate + "-middlenameen-hidden").val($("#" + _this1.idSectionAddUpdate + "-middlenameen").val());
                $("#" + _this1.idSectionAddUpdate + "-lastnameen-hidden").val($("#" + _this1.idSectionAddUpdate + "-lastnameen").val());
                $("#" + _this1.idSectionAddUpdate + "-gender-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-gender"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-gender")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-birthdate-hidden").val($("#" + _this1.idSectionAddUpdate + "-birthdate").val());
                $("#" + _this1.idSectionAddUpdate + "-age-hidden").val($("#" + _this1.idSectionAddUpdate + "-age").html());
                $("#" + _this1.idSectionAddUpdate + "-birthplace-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-birthplace"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-birthplace"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-nationality-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-nationality"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-nationality"),
                        valueFalse: "0"
                    })
                );

                if (Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-nationality") != "0") {
                    _value = $("#" + _this1.idSectionAddUpdate + "-nationality .select2-selection .select2-selection__rendered").attr("title");
                    _valueArray = _value.split(" : ");
                    _this3.nationality = _valueArray[0];
                }
                else
                    _this3.nationality = "";

                /*
                $("#" + _this1.idSectionAddUpdate + "-race-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-race"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-race"),
                        valueFalse: "0"
                    })
                );
                */
                if (MSent.consentField.religion.isConsent) {
                    $("#" + _this1.idSectionAddUpdate + "-religion-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _this1.idSectionAddUpdate + "-religion"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-religion"),
                            valueFalse: "0"
                        })
                    );
                }
                /*
                $("#" + _this1.idSectionAddUpdate + "-bloodgroup-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-bloodgroup"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-bloodgroup")
                    })
                );
                */
                $("#" + _this1.idSectionAddUpdate + "-maritalstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-maritalstatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-maritalstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-educationalbackgroundperson-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-educationalbackgroundperson"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-educationalbackgroundperson")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-email-hidden").val($("#" + _this1.idSectionAddUpdate + "-email").val());
                //$("#" + _this1.idSectionAddUpdate + "-brotherhood-hidden").val($("#" + _this1.idSectionAddUpdate + "-brotherhood").val());
                $("#" + _this1.idSectionAddUpdate + "-brotherhood-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-brotherhood"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-brotherhood"),
                        valueFalse: "0"
                    })
                );
                //$("#" + _this1.idSectionAddUpdate + "-childhood-hidden").val($("#" + _this1.idSectionAddUpdate + "-childhood").val());
                $("#" + _this1.idSectionAddUpdate + "-childhood-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-childhood"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-childhood"),
                        valueFalse: "0"
                    })
                );
                //$("#" + _this1.idSectionAddUpdate + "-studyhood-hidden").val($("#" + _this1.idSectionAddUpdate + "-studyhood").val());
                $("#" + _this1.idSectionAddUpdate + "-studyhood-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-studyhood"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-studyhood"),
                        valueFalse: "0"
                    })
                );        

                $("#" + _this3.idSectionAddUpdate + "-studentrecordspersonalstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsPersonal
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressPermanentAddUpdate) {
                _this1 = _this2.address.permanentaddress;
                _value = Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-district");
                
                if (_value != "0") {
                    _valueArray = _value.split(";");
                    _valueDistrict = _valueArray[0];
                    _valuePostalCode = _valueArray[1];
                }

                $("#" + _this1.idSectionAddUpdate + "-country-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-country"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-country"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-province-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-province"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-province"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-district-hidden").val(_valueDistrict.length > 0 ? _valueDistrict : "0");
                $("#" + _this1.idSectionAddUpdate + "-postalcodedistrict-hidden").val(_valuePostalCode);
                $("#" + _this1.idSectionAddUpdate + "-subdistrict-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-subdistrict"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-subdistrict"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-postalcode-hidden").val($("#" + _this1.idSectionAddUpdate + "-postalcode").val());
                $("#" + _this1.idSectionAddUpdate + "-village-hidden").val($("#" + _this1.idSectionAddUpdate + "-village").val());
                $("#" + _this1.idSectionAddUpdate + "-addressnumber-hidden").val($("#" + _this1.idSectionAddUpdate + "-addressnumber").val());
                $("#" + _this1.idSectionAddUpdate + "-villageno-hidden").val($("#" + _this1.idSectionAddUpdate + "-villageno").val());
                $("#" + _this1.idSectionAddUpdate + "-lanealley-hidden").val($("#" + _this1.idSectionAddUpdate + "-lanealley").val());
                $("#" + _this1.idSectionAddUpdate + "-road-hidden").val($("#" + _this1.idSectionAddUpdate + "-road").val());
                $("#" + _this1.idSectionAddUpdate + "-phonenumber-hidden").val($("#" + _this1.idSectionAddUpdate + "-phonenumber").val());
                $("#" + _this1.idSectionAddUpdate + "-mobilenumber-hidden").val($("#" + _this1.idSectionAddUpdate + "-mobilenumber").val());
                $("#" + _this1.idSectionAddUpdate + "-faxnumber-hidden").val($("#" + _this1.idSectionAddUpdate + "-faxnumber").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordsaddresspermanentstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsAddress
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsAddressCurrentAddUpdate) {
                _this1 = _this2.address.currentaddress;
                _value = Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-district");

                if (_value != "0") {
                    _valueArray = _value.split(";");
                    _valueDistrict = _valueArray[0];
                    _valuePostalCode = _valueArray[1];
                }

                $("#" + _this1.idSectionAddUpdate + "-country-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-country"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-country"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-province-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-province"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-province"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-district-hidden").val(_valueDistrict.length > 0 ? _valueDistrict : "0");
                $("#" + _this1.idSectionAddUpdate + "-postalcodedistrict-hidden").val(_valuePostalCode);
                $("#" + _this1.idSectionAddUpdate + "-subdistrict-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-subdistrict"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-subdistrict"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-postalcode-hidden").val($("#" + _this1.idSectionAddUpdate + "-postalcode").val());
                $("#" + _this1.idSectionAddUpdate + "-village-hidden").val($("#" + _this1.idSectionAddUpdate + "-village").val());
                $("#" + _this1.idSectionAddUpdate + "-addressnumber-hidden").val($("#" + _this1.idSectionAddUpdate + "-addressnumber").val());
                $("#" + _this1.idSectionAddUpdate + "-villageno-hidden").val($("#" + _this1.idSectionAddUpdate + "-villageno").val());
                $("#" + _this1.idSectionAddUpdate + "-lanealley-hidden").val($("#" + _this1.idSectionAddUpdate + "-lanealley").val());
                $("#" + _this1.idSectionAddUpdate + "-road-hidden").val($("#" + _this1.idSectionAddUpdate + "-road").val());
                $("#" + _this1.idSectionAddUpdate + "-phonenumber-hidden").val($("#" + _this1.idSectionAddUpdate + "-phonenumber").val());
                $("#" + _this1.idSectionAddUpdate + "-mobilenumber-hidden").val($("#" + _this1.idSectionAddUpdate + "-mobilenumber").val());
                $("#" + _this1.idSectionAddUpdate + "-faxnumber-hidden").val($("#" + _this1.idSectionAddUpdate + "-faxnumber").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordsaddresscurrentstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsAddress
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationPrimarySchoolAddUpdate) {
                _this1 = _this2.education.primaryschool;
            
                $("#" + _this1.idSectionAddUpdate + "-institutename-hidden").val($("#" + _this1.idSectionAddUpdate + "-institutename").val());
                $("#" + _this1.idSectionAddUpdate + "-institutecountry-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-instituteprovince-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                        valueFalse: "0"
                    })
                );
                //$("#" + _this1.idSectionAddUpdate + "-yearattended-hidden").val($("#" + _this1.idSectionAddUpdate + "-yearattended").val());
                //$("#" + _this1.idSectionAddUpdate + "-yeargraduate-hidden").val($("#" + _this1.idSectionAddUpdate + "-yeargraduate").val());
                $("#" + _this1.idSectionAddUpdate + "-yearattended-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-yeargraduate-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-gpa-hidden").val($("#" + _this1.idSectionAddUpdate + "-gpa").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordseducationprimaryschoolstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsEducation
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationJuniorHighSchoolAddUpdate) {
                _this1 = _this2.education.juniorhighschool;
            
                $("#" + _this1.idSectionAddUpdate + "-institutename-hidden").val($("#" + _this1.idSectionAddUpdate + "-institutename").val());
                $("#" + _this1.idSectionAddUpdate + "-institutecountry-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-instituteprovince-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                        valueFalse: "0"
                    })
                );
                //$("#" + _this1.idSectionAddUpdate + "-yearattended-hidden").val($("#" + _this1.idSectionAddUpdate + "-yearattended").val());
                //$("#" + _this1.idSectionAddUpdate + "-yeargraduate-hidden").val($("#" + _this1.idSectionAddUpdate + "-yeargraduate").val());
                $("#" + _this1.idSectionAddUpdate + "-yearattended-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-yeargraduate-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-gpa-hidden").val($("#" + _this1.idSectionAddUpdate + "-gpa").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordseducationjuniorhighschoolstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsEducation
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationHighSchoolAddUpdate) {
                _this1 = _this2.education.highschool;

                $("#" + _this1.idSectionAddUpdate + "-institutename-hidden").val($("#" + _this1.idSectionAddUpdate + "-institutename").val());
                $("#" + _this1.idSectionAddUpdate + "-institutecountry-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-institutecountry"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-instituteprovince-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-instituteprovince"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-studentid-hidden").val($("#" + _this1.idSectionAddUpdate + "-studentid").val());
                $("#" + _this1.idSectionAddUpdate + "-educationalmajor-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-educationalmajor"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-educationalmajor")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-educationalmajorother-hidden").val($("#" + _this1.idSectionAddUpdate + "-educationalmajorother").val());
                //$("#" + _this1.idSectionAddUpdate + "-yearattended-hidden").val($("#" + _this1.idSectionAddUpdate + "-yearattended").val());
                //$("#" + _this1.idSectionAddUpdate + "-yeargraduate-hidden").val($("#" + _this1.idSectionAddUpdate + "-yeargraduate").val());
                $("#" + _this1.idSectionAddUpdate + "-yearattended-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-yeargraduate-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yeargraduate"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-gpa-hidden").val($("#" + _this1.idSectionAddUpdate + "-gpa").val());
                $("#" + _this1.idSectionAddUpdate + "-educationalbackground-hidden").val(
                        Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-educationalbackground"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-educationalbackground")
                    })
                );

                $("#" + _this3.idSectionAddUpdate + "-studentrecordseducationhighschoolstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsEducation
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationUniversityAddUpdate) {
                _this1 = _this2.education.university;

                $("#" + _this1.idSectionAddUpdate + "-educationalbackground-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-educationalbackground"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-educationalbackground")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-graduateby-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-graduateby"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-graduateby")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-graduatebyinstitutename-hidden").val($("#" + _this1.idSectionAddUpdate + "-graduatebyinstitutename").val());
                $("#" + _this1.idSectionAddUpdate + "-entrancetime-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-entrancetime"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-entrancetime")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-studentis-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-studentis"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-studentis")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-studentisuniversity-hidden").val($("#" + _this1.idSectionAddUpdate + "-studentisuniversity").val());
                $("#" + _this1.idSectionAddUpdate + "-studentisfaculty-hidden").val($("#" + _this1.idSectionAddUpdate + "-studentisfaculty").val());
                $("#" + _this1.idSectionAddUpdate + "-studentisprogram-hidden").val($("#" + _this1.idSectionAddUpdate + "-studentisprogram").val());
                $("#" + _this1.idSectionAddUpdate + "-entrancetype-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-entrancetype"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-entrancetype")
                    })
                );
                //$("#" + _this1.idSectionAddUpdate + "-admissionranking-hidden").val($("#" + _this1.idSectionAddUpdate + "-admissionranking").val());
                $("#" + _this1.idSectionAddUpdate + "-admissionranking-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-admissionranking"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-admissionranking"),
                        valueFalse: "0"
                    })
                );

                $("#" + _this3.idSectionAddUpdate + "-studentrecordseducationuniversitystatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsEducation
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsEducationAdmissionScoresAddUpdate) {
                _this1 = _this2.education.admissionscores;

                $("#" + _this1.idSectionAddUpdate + "-scoresonetthai-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresonetthai").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresonetsocialscience-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresonetsocialscience").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresonetenglish-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresonetenglish").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresonetmathematics-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresonetmathematics").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresonetscience-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresonetscience").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresonethealthphysical-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresonethealthphysical").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresonetarts-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresonetarts").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresonetoccupationtechnology-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresonetoccupationtechnology").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresanetthai2-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresanetthai2").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresanetsocialscience2-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresanetsocialscience2").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresanetenglish3-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresanetenglish3").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresanetmathematics2-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresanetmathematics2").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresanetscience2-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresanetscience2").val());
                $("#" + _this1.idSectionAddUpdate + "-scoresgatgenaralaptitudetest-hidden").val($("#" + _this1.idSectionAddUpdate + "-scoresgatgenaralaptitudetest").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat1-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat1").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat2-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat2").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat3-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat3").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat4-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat4").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat5-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat5").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat6-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat6").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat7-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat7").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat8-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat8").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat9-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat9").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat10-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat10").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat11-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat11").val());
                $("#" + _this1.idSectionAddUpdate + "-scorespat12-hidden").val($("#" + _this1.idSectionAddUpdate + "-scorespat12").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordseducationadmissionscoresstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsEducation
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsTalentAddUpdate) {
                _this1 = _this2.talent;

                $("#" + _this1.idSectionAddUpdate + "-sportsmanstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-sportsmanstatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-sportsmanstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-sportsmandetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-sportsmandetail").val());
                $("#" + _this1.idSectionAddUpdate + "-specialiststatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-specialiststatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialiststatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-specialistsportstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-specialistsportstatus"),
                        type: "checkbox",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialistsportstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-specialistsportdetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-specialistsportdetail").val());
                $("#" + _this1.idSectionAddUpdate + "-specialistartstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-specialistartstatus"),
                        type: "checkbox",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialistartstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-specialistartdetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-specialistartdetail").val());
                $("#" + _this1.idSectionAddUpdate + "-specialisttechnicalstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-specialisttechnicalstatus"),
                        type: "checkbox",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialisttechnicalstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-specialisttechnicaldetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-specialisttechnicaldetail").val());
                $("#" + _this1.idSectionAddUpdate + "-specialistotherstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-specialistotherstatus"),
                        type: "checkbox",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-specialistotherstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-specialistotherdetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-specialistotherdetail").val());
                $("#" + _this1.idSectionAddUpdate + "-activitystatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-activitystatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-activitystatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-activitydetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-activitydetail").val());
                $("#" + _this1.idSectionAddUpdate + "-rewardstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-rewardstatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-rewardstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-rewarddetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-rewarddetail").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordstalentstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsTalent
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsHealthyAddUpdate) {
                _this1 = _this2.healthy;
                /*
                $("#" + _this1.idSectionAddUpdate + "-bodymassdetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-bodymassdetail").val());
                $("#" + _this1.idSectionAddUpdate + "-intolerancestatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-intolerancestatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-intolerancestatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-intolerancedetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-intolerancedetail").val());
                $("#" + _this1.idSectionAddUpdate + "-diseasesstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-diseasesstatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-diseasesstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-diseasesdetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-diseasesdetail").val());
                $("#" + _this1.idSectionAddUpdate + "-familyhistoryofillnessstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-familyhistoryofillnessstatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-familyhistoryofillnessstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-familyhistoryofillnessdetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-familyhistoryofillnessdetail").val());
                $("#" + _this1.idSectionAddUpdate + "-travelabroadstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-travelabroadstatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-travelabroadstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-travelabroaddetail-hidden").val($("#" + _this1.idSectionAddUpdate + "-travelabroaddetail").val());
                */
                $("#" + _this1.idSectionAddUpdate + "-impairmentsstatus-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-impairmentsstatus"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-impairmentsstatus")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-impairmentsdetail-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-impairmentsdetail"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-impairmentsdetail"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-impairmentsequipment-hidden").val($("#" + _this1.idSectionAddUpdate + "-impairmentsequipment").val());
                $("#" + _this1.idSectionAddUpdate + "-idcardpwd-hidden").val($("#" + _this1.idSectionAddUpdate + "-idcardpwd").val());
                $("#" + _this1.idSectionAddUpdate + "-idcardpwdissuedate-hidden").val($("#" + _this1.idSectionAddUpdate + "-idcardpwdissuedate").val());
                $("#" + _this1.idSectionAddUpdate + "-idcardpwdexpirydate-hidden").val($("#" + _this1.idSectionAddUpdate + "-idcardpwdexpirydate").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordshealthystatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsHealthy
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsWorkAddUpdate) {
                _this1 = _this2.work;

                $("#" + _this1.idSectionAddUpdate + "-occupation-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-occupation"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-occupation"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-agency-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-agency"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-agency"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-agencyother-hidden").val($("#" + _this1.idSectionAddUpdate + "-agencyotherdetail").val());
                $("#" + _this1.idSectionAddUpdate + "-workplace-hidden").val($("#" + _this1.idSectionAddUpdate + "-workplace").val());
                $("#" + _this1.idSectionAddUpdate + "-workplaceposition-hidden").val($("#" + _this1.idSectionAddUpdate + "-workplaceposition").val());
                $("#" + _this1.idSectionAddUpdate + "-workplacetelephone-hidden").val($("#" + _this1.idSectionAddUpdate + "-workplacetelephone").val());
                $("#" + _this1.idSectionAddUpdate + "-workplacesalary-hidden").val($("#" + _this1.idSectionAddUpdate + "-workplacesalary").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordsworkstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsWork
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFinancialAddUpdate) {
                _this1 = _this2.financial;

                $("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelor-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-scholarshipfirstbachelor"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-scholarshipfirstbachelor")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelorfrom-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelorfrom"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelorfrom"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelorname-hidden").val($("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelorname").val());
                $("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelormoney-hidden").val($("#" + _this1.idSectionAddUpdate + "-scholarshipfirstbachelormoney").val());
                $("#" + _this1.idSectionAddUpdate + "-scholarshipbachelor-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-scholarshipbachelor"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-scholarshipbachelor")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-scholarshipbachelorfrom-hidden").val(
                    Util.getSelectionIsSelect({
                        id: ("#" + _this1.idSectionAddUpdate + "-scholarshipbachelorfrom"),
                        type: "select",
                        valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-scholarshipbachelorfrom"),
                        valueFalse: "0"
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-scholarshipbachelorname-hidden").val($("#" + _this1.idSectionAddUpdate + "-scholarshipbachelorname").val());
                $("#" + _this1.idSectionAddUpdate + "-scholarshipbachelormoney-hidden").val($("#" + _this1.idSectionAddUpdate + "-scholarshipbachelormoney").val());
                $("#" + _this1.idSectionAddUpdate + "-worked-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-worked"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-worked")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-salary-hidden").val($("#" + _this1.idSectionAddUpdate + "-salary").val());
                $("#" + _this1.idSectionAddUpdate + "-workplace-hidden").val($("#" + _this1.idSectionAddUpdate + "-workplace").val());
                $("#" + _this1.idSectionAddUpdate + "-gotmoneyfrom-hidden").val(
                    Util.getSelectionIsSelect({
                        id: (_this1.idSectionAddUpdate + "-gotmoneyfrom"),
                        type: "radio",
                        valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-gotmoneyfrom")
                    })
                );
                $("#" + _this1.idSectionAddUpdate + "-gotmoneyfromother-hidden").val($("#" + _this1.idSectionAddUpdate + "-gotmoneyfromother").val());
                $("#" + _this1.idSectionAddUpdate + "-gotmoneypermonth-hidden").val($("#" + _this1.idSectionAddUpdate + "-gotmoneypermonth").val());
                $("#" + _this1.idSectionAddUpdate + "-costpermonth-hidden").val($("#" + _this1.idSectionAddUpdate + "-costpermonth").val());

                $("#" + _this3.idSectionAddUpdate + "-studentrecordsfinancialstatus-hidden").val("Y");
                _this2.setMenuByStudentRecordsStatus({
                    section: Util.tut.subjectSectionAdministrationStudentRecordsFinancial
                });
            }

            if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate ||
                _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate) {
                _familyRelation = _param["page"].replace(Util.tut.subjectSectionAdministrationStudentRecordsFamily, "")

                if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate) {
                    _familyRelation = Util.toUpperCaseFirst(_familyRelation.replace("PersonalAddUpdate", ""));
                    _this1 = _this2.family.personal;
                    _idSection = _this2.family.getSectionByFamilyRelation({
                        familyRelation: _familyRelation,
                        idFather: _this1.idSectionFatherAddUpdate,
                        idMother: _this1.idSectionMotherAddUpdate,
                        idParent: _this1.idSectionParentAddUpdate
                    });
                    
                    if (_familyRelation == Util.tut.subjectFamilyParent) {
                        _valueRelationship = Util.comboboxGetValue("#" + _idSection + "-relationship");

                        if (_valueRelationship != "0") {
                            _valueRelationshipArray = _valueRelationship.split(";");
                            _valueFamilyRelation = _valueRelationshipArray[0];
                            _relationshipEN = _valueRelationshipArray[1];
                            _relationshipTH = _valueRelationshipArray[2];
                            _valueGender = _valueRelationshipArray[3];
                        }

                        $("#" + _idSection + "-defaultpersonid-hidden").val(_param["data"].PersonId);
                        $("#" + _idSection + "-relationship-hidden").val(_valueFamilyRelation);
                        $("#" + _idSection + "-relationshipnameen-hidden").val(_relationshipEN);
                        $("#" + _idSection + "-relationshipnameth-hidden").val(_relationshipTH);
                        $("#" + _idSection + "-genderrelationship-hidden").val(_valueGender);
                    }

                    _value = Util.comboboxGetValue("#" + _idSection + "-titleprefix");

                    if (_value != "0") {
                        _valueArray = _value.split(";");
                        _valueTitlePrefix = _valueArray[0];
                        _valueGender = _valueArray[1];
                    }

                    $("#" + _idSection + "-personid-hidden").val(_param["data"].PersonId);

                    if (_this4.isProgramContract)
                        $("#" + _idSection + "-idcard-hidden").val($("#" + _idSection + "-idcard").val());

                    $("#" + _idSection + "-titleprefix-hidden").val(_valueTitlePrefix);
                    $("#" + _idSection + "-gendertitleprefix-hidden").val(_valueGender);
                    $("#" + _idSection + "-firstname-hidden").val($("#" + _idSection + "-firstname").val());
                    $("#" + _idSection + "-middlename-hidden").val($("#" + _idSection + "-middlename").val());
                    $("#" + _idSection + "-lastname-hidden").val($("#" + _idSection + "-lastname").val());
                    $("#" + _idSection + "-firstnameen-hidden").val($("#" + _idSection + "-firstnameen").val());
                    $("#" + _idSection + "-middlenameen-hidden").val($("#" + _idSection + "-middlenameen").val());
                    $("#" + _idSection + "-lastnameen-hidden").val($("#" + _idSection + "-lastnameen").val());

                    if (_familyRelation == Util.tut.subjectFamilyParent)
                        $("#" + _idSection + "-gender-hidden").val(
                            Util.getSelectionIsSelect({
                                id: (_idSection + "-gender"),
                                type: "radio",
                                valueTrue: Util.checkGetValue(_idSection + "-gender")
                            })
                        );

                    $("#" + _idSection + "-alive-hidden").val(
                        Util.getSelectionIsSelect({
                            id: (_idSection + "-alive"),
                            type: "radio",
                            valueTrue: Util.checkGetValue(_idSection + "-alive")
                        })
                    );

                    if (_this4.isProgramContract)
                        $("#" + _idSection + "-birthdate-hidden").val($("#" + _idSection + "-birthdate").val());

                    $("#" + _idSection + "-age-hidden").val($("#" + _idSection + "-age").html());
                    $("#" + _idSection + "-birthplace-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-birthplace"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-birthplace"),
                            valueFalse: "0"
                        })
                    );
                    $("#" + _idSection + "-nationality-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-nationality"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-nationality"),
                            valueFalse: "0"
                        })
                    );
                    /*
                    $("#" + _idSection + "-race-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-race"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-race"),
                            valueFalse: "0"
                        })
                    );
                    */
                    if (MSent.consentField.religion.isConsent) {
                        $("#" + _idSection + "-religion-hidden").val(
                            Util.getSelectionIsSelect({
                                id: ("#" + _idSection + "-religion"),
                                type: "select",
                                valueTrue: Util.comboboxGetValue("#" + _idSection + "-religion"),
                            })
                        );
                    }
                    /*
                    $("#" + _idSection + "-bloodgroup-hidden").val(
                        Util.getSelectionIsSelect({
                            id: (_idSection + "-bloodgroup"),
                            type: "radio",
                            valueTrue: Util.checkGetValue(_idSection + "-bloodgroup")
                        })
                    );
                    */
                    $("#" + _idSection + "-maritalstatus-hidden").val(
                        Util.getSelectionIsSelect({
                            id: (_idSection + "-maritalstatus"),
                            type: "radio",
                            valueTrue: Util.checkGetValue(_idSection + "-maritalstatus")
                        })
                    );
                    $("#" + _idSection + "-educationalbackgroundperson-hidden").val(
                        Util.getSelectionIsSelect({
                            id: (_idSection + "-educationalbackgroundperson"),
                            type: "radio",
                            valueTrue: Util.checkGetValue(_idSection + "-educationalbackgroundperson")
                        })
                    );
                    
                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherPersonalAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyfatherpersonalstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherPersonalAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilymotherpersonalstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentPersonalAddUpdate) {
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyparentpersonalstatus-hidden").val("Y");

                        if (_relationshipEN == Util.tut.subjectFamilyFather || _relationshipEN == Util.tut.subjectFamilyMother) {
                            $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyparentaddresspermanentstatus-hidden").val($("#" + _this3.idSectionAddUpdate + "-studentrecordsfamily" + _relationshipEN.toLowerCase() + "addresspermanentstatus-hidden").val());
                            $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyparentaddresscurrentstatus-hidden").val($("#" + _this3.idSectionAddUpdate + "-studentrecordsfamily" + _relationshipEN.toLowerCase() + "addresscurrentstatus-hidden").val());
                            $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyparentworkstatus-hidden").val($("#" + _this3.idSectionAddUpdate + "-studentrecordsfamily" + _relationshipEN.toLowerCase() + "workstatus-hidden").val());
                        }
                    }                                                                      
                    _this2.setMenuByStudentRecordsStatus({
                        section: Util.tut.subjectSectionAdministrationStudentRecordsFamily
                    });
                }

                if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate) {
                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate ||
                        _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate ||
                        _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate) {
                        _familyRelation = Util.toUpperCaseFirst(_familyRelation.replace("AddressPermanentAddUpdate", ""));
                        _this1 = _this2.family.address.permanentaddress;
                    }
                 
                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate ||
                        _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate ||
                        _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate) {
                        _familyRelation = Util.toUpperCaseFirst(_familyRelation.replace("AddressCurrentAddUpdate", ""));
                        _this1 = _this2.family.address.currentaddress;
                    }
                                        
                    _idSection = _this2.family.getSectionByFamilyRelation({
                        familyRelation: _familyRelation,
                        idFather: _this1.idSectionFatherAddUpdate,
                        idMother: _this1.idSectionMotherAddUpdate,
                        idParent: _this1.idSectionParentAddUpdate
                    });
                    _value = Util.comboboxGetValue("#" + _idSection + "-district");

                    if (_value != "0") {
                        _valueArray = _value.split(";");
                        _valueDistrict = _valueArray[0];
                        _valuePostalCode = _valueArray[1];
                    }

                    $("#" + _idSection + "-country-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-country"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-country"),
                            valueFalse: "0"
                        })
                    );
                    $("#" + _idSection + "-province-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-province"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-province"),
                            valueFalse: "0"
                        })
                    );
                    $("#" + _idSection + "-district-hidden").val(_valueDistrict.length > 0 ? _valueDistrict : "0");
                    $("#" + _idSection + "-postalcodedistrict-hidden").val(_valuePostalCode);
                    $("#" + _idSection + "-subdistrict-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-subdistrict"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-subdistrict"),
                            valueFalse: "0"
                        })
                    );
                    $("#" + _idSection + "-postalcode-hidden").val($("#" + _idSection + "-postalcode").val());
                    $("#" + _idSection + "-village-hidden").val($("#" + _idSection + "-village").val());
                    $("#" + _idSection + "-addressnumber-hidden").val($("#" + _idSection + "-addressnumber").val());
                    $("#" + _idSection + "-villageno-hidden").val($("#" + _idSection + "-villageno").val());
                    $("#" + _idSection + "-lanealley-hidden").val($("#" + _idSection + "-lanealley").val());
                    $("#" + _idSection + "-road-hidden").val($("#" + _idSection + "-road").val());
                    $("#" + _idSection + "-phonenumber-hidden").val($("#" + _idSection + "-phonenumber").val());
                    $("#" + _idSection + "-mobilenumber-hidden").val($("#" + _idSection + "-mobilenumber").val());
                    $("#" + _idSection + "-faxnumber-hidden").val($("#" + _idSection + "-faxnumber").val());

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressPermanentAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyfatheraddresspermanentstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressPermanentAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilymotheraddresspermanentstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressPermanentAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyparentaddresspermanentstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherAddressCurrentAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyfatheraddresscurrentstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherAddressCurrentAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilymotheraddresscurrentstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentAddressCurrentAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyparentaddresscurrentstatus-hidden").val("Y");

                    _this2.setMenuByStudentRecordsStatus({
                        section: Util.tut.subjectSectionAdministrationStudentRecordsFamily
                    });
                }

                if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate ||
                    _param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate) {
                    _familyRelation = Util.toUpperCaseFirst(_familyRelation.replace("WorkAddUpdate", ""));
                    _this1 = _this2.family.work;
                    _idSection = _this2.family.getSectionByFamilyRelation({
                        familyRelation: _familyRelation,
                        idFather: _this1.idSectionFatherAddUpdate,
                        idMother: _this1.idSectionMotherAddUpdate,
                        idParent: _this1.idSectionParentAddUpdate
                    });

                    $("#" + _idSection + "-occupation-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-occupation"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-occupation"),
                            valueFalse: "0"
                        })
                    );
                    $("#" + _idSection + "-agency-hidden").val(
                        Util.getSelectionIsSelect({
                            id: ("#" + _idSection + "-agency"),
                            type: "select",
                            valueTrue: Util.comboboxGetValue("#" + _idSection + "-agency"),
                            valueFalse: "0"
                        })
                    );
                    $("#" + _idSection + "-agencyother-hidden").val($("#" + _idSection + "-agencyotherdetail").val());
                    $("#" + _idSection + "-workplace-hidden").val($("#" + _idSection + "-workplace").val());
                    $("#" + _idSection + "-workplaceposition-hidden").val($("#" + _idSection + "-workplaceposition").val());
                    $("#" + _idSection + "-workplacetelephone-hidden").val($("#" + _idSection + "-workplacetelephone").val());
                    $("#" + _idSection + "-workplacesalary-hidden").val($("#" + _idSection + "-workplacesalary").val());

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyFatherWorkAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyfatherworkstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyMotherWorkAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilymotherworkstatus-hidden").val("Y");

                    if (_param["page"] == Util.tut.pageAdministrationStudentRecordsFamilyParentWorkAddUpdate)
                        $("#" + _this3.idSectionAddUpdate + "-studentrecordsfamilyparentworkstatus-hidden").val("Y");

                    _this2.setMenuByStudentRecordsStatus({
                        section: Util.tut.subjectSectionAdministrationStudentRecordsFamily
                    });
                }
            }
        }
    },
    sectionProgress: {
        updatefacultyprogram: {
            idSectionProgress: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateFacultyProgramProgress.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-faculty"),
                    width: 500,
                    height: 29
                });
                $("#" + _this2.idSectionProgress + "-updatereason").width(492).height(45);
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.dialogMessageClose();
                Util.resetForm({
                    id: (_this2.idSectionProgress + "-form")
                });

                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-faculty"),
                    value: "0"
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + _this2.idSectionProgress + "-program"),
                    value: "0"
                }, function () {
                });
                $("#" + _this2.idSectionProgress + "-updatereason").val("");
            },
            validateProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _error = new Array();
                var _i = 0;

                if (Util.comboboxGetValue("#" + _this2.idSectionProgress + "-faculty") == "0") {
                    _error[_i] = "กรุณาเลือกคณะ;Please select faculty.;";
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this2.idSectionProgress + "-program") == "0") {
                    _error[_i] = "กรุณาเลือกหลักสูตร;Please select program.;";
                    _i++;
                }

                if ($("#" + _this2.idSectionProgress + "-updatereason").val().length == 0) {
                    _error[_i] = "กรุณาใส่เหตุผลที่ปรับปรุง;Please enter update reason.;";
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
            getValueProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _valueParamSearch = {}
                var _valueFaculty = "";
                var _valueProgram = "";
                var _valueUpdateReason = "";
                var _valueProcessResult = {};

                _valueParamSearch = JSON.stringify(Util.tut.tse.studentrecords.valueSearch());
                _valueFaculty = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-faculty")
                });
                _valueProgram = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-program"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-program")
                });
                _valueUpdateReason = $("#" + _this2.idSectionProgress + "-updatereason").val();

                _valueProcessResult["paramsearch"] = _valueParamSearch;
                _valueProcessResult["valuefaculty"] = _valueFaculty;
                _valueProcessResult["valueprogram"] = _valueProgram;
                _valueProcessResult["valueupdatereason"] = _valueUpdateReason;

                return _valueProcessResult;
            },
            getResultProcess: function (_param) {
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _detailComplete = _param["resultValueProcess"].DetailComplete;
                var _idTable = (_this1.idSectionMain + "-table");
                var _idTableRow;
                var _valueArray = _detailComplete.split(",");
                var _i;

                for (_i = 0; _i < _valueArray.length; _i++) {
                    _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueArray[_i]);

                    if ($("#" + _idTableRow).length > 0)
                        $("#" + _idTableRow + " .table-col-program").html($("#" + _this2.idSectionProgress + "-program-hidden").val());
                }
            }
        },
        updateclassyear: {
            idSectionProgress: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateClassYearProgress.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-class"),
                    width: 500,
                    height: 29
                });
                $("#" + _this2.idSectionProgress + "-updatereason").width(492).height(45);
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.dialogMessageClose();
                Util.resetForm({
                    id: (_this2.idSectionProgress + "-form")
                });

                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-class"),
                    value: "0"
                });
                $("#" + _this2.idSectionProgress + "-updatereason").val("");
            },
            validateProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _error = new Array();
                var _i = 0;

                if (Util.comboboxGetValue("#" + _this2.idSectionProgress + "-class") == "0") {
                    _error[_i] = "กรุณาเลือกชั้นปี;Please select class.;";
                    _i++;
                }

                if ($("#" + _this2.idSectionProgress + "-updatereason").val().length == 0) {
                    _error[_i] = "กรุณาใส่เหตุผลที่ปรับปรุง;Please enter update reason.;";
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
            getValueProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _valueParamSearch = {}
                var _valueClassYear = "";
                var _valueUpdateReason = "";
                var _valueProcessResult = {};

                _valueParamSearch = JSON.stringify(Util.tut.tse.studentrecords.valueSearch());
                _valueClassYear = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-class"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-class")
                });
                _valueUpdateReason = $("#" + _this2.idSectionProgress + "-updatereason").val();

                _valueProcessResult["paramsearch"] = _valueParamSearch;
                _valueProcessResult["valueclassyear"] = _valueClassYear;
                _valueProcessResult["valueupdatereason"] = _valueUpdateReason;

                return _valueProcessResult;
            },
            getResultProcess: function (_param) {
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _detailComplete = _param["resultValueProcess"].DetailComplete;
                var _idTable = (_this1.idSectionMain + "-table");
                var _idTableRow;
                var _valueArray = _detailComplete.split(",");
                var _i;

                for (_i = 0; _i < _valueArray.length; _i++) {
                    _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueArray[_i]);

                    if ($("#" + _idTableRow).length > 0)
                        $("#" + _idTableRow + " .table-col-classyear").html(_param["dataProcess"]["valueclassyear"]);
                }
            }
        },
        updateentrancetype: {
            idSectionProgress: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateEntranceTypeProgress.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-entrancetype"),
                    width: 500,
                    height: 29
                });
                $("#" + _this2.idSectionProgress + "-updatereason").width(492).height(45);
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.dialogMessageClose();
                Util.resetForm({
                    id: (_this2.idSectionProgress + "-form")
                });

                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-entrancetype"),
                    value: "0"
                });
                $("#" + _this2.idSectionProgress + "-updatereason").val("");
            },
            validateProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _error = new Array();
                var _i = 0;

                if (Util.comboboxGetValue("#" + _this2.idSectionProgress + "-entrancetype") == "0") {
                    _error[_i] = "กรุณาเลือกระบบการสอบเข้า;Please select admission type.;";
                    _i++;
                }

                if ($("#" + _this2.idSectionProgress + "-updatereason").val().length == 0) {
                    _error[_i] = "กรุณาใส่เหตุผลที่ปรับปรุง;Please enter update reason.;";
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
            getValueProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _valueParamSearch = {}
                var _valueEntranceType = "";
                var _valueUpdateReason = "";
                var _valueProcessResult = {};

                _valueParamSearch = JSON.stringify(Util.tut.tse.studentrecords.valueSearch());
                _valueEntranceType = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-entrancetype"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-entrancetype")
                });
                _valueUpdateReason = $("#" + _this2.idSectionProgress + "-updatereason").val();

                _valueProcessResult["paramsearch"] = _valueParamSearch;
                _valueProcessResult["valueentrancetype"] = _valueEntranceType;
                _valueProcessResult["valueupdatereason"] = _valueUpdateReason;

                return _valueProcessResult;
            },
            getResultProcess: function (_param) {
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _detailComplete = _param["resultValueProcess"].DetailComplete;
                var _idTable = (_this1.idSectionMain + "-table");
                var _idTableRow;
                var _valueArray = _detailComplete.split(",");
                var _i;

                for (_i = 0; _i < _valueArray.length; _i++) {
                    _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueArray[_i]);

                    if ($("#" + _idTableRow).length > 0)
                        $("#" + _idTableRow + " .table-col-entrancetype").html(_param["dataProcess"]["valueentrancetype"]);
                }
            }
        },
        updatestudentstatus: {
            idSectionProgress: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateStudentStatusProgress.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-studentstatus"),
                    width: 500,
                    height: 29
                });
                Util.initCalendar({
                    id: ("#" + _this2.idSectionProgress + "-graduationdate"),
                    yearRange: "-12:+5"
                });
                $("#" + _this2.idSectionProgress + "-updatereason").width(492).height(45);
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.dialogMessageClose();
                Util.resetForm({
                    id: (_this2.idSectionProgress + "-form")
                });

                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-studentstatus"),
                    value: "0"
                });
                $("#" + _this2.idSectionProgress + "-graduationdate, #" + _this2.idSectionProgress + "-updatereason").val("");

                Util.calendarDisable("#" + _this2.idSectionProgress + "-graduationdate");
            },
            validateProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _error = new Array();
                var _i = 0;

                if (Util.comboboxGetValue("#" + _this2.idSectionProgress + "-studentstatus") == "0") {
                    _error[_i] = "กรุณาเลือกสถานภาพการเป็นนักศึกษา;Please select student status.;";
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this2.idSectionProgress + "-studentstatus") != "0" && Util.comboboxGetValue("#" + _this2.idSectionProgress + "-studentstatus").substring(0, 2) != "00" && $("#" + _this2.idSectionProgress + "-graduationdate").val().length == 0) {
                    _error[_i] = "กรุณาใส่วันที่สำเร็จการศึกษาหรือวันที่ออกจากการศึกษา;Please enter graduation date.;";
                    _i++;
                }

                if ($("#" + _this2.idSectionProgress + "-updatereason").val().length == 0) {
                    _error[_i] = "กรุณาใส่เหตุผลที่ปรับปรุง;Please enter update reason.;";
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
            getValueProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _valueParamSearch = {}
                var _valueStudentStatus = "";
                var _valueGraduationDate = "";
                var _valueUpdateReason = "";
                var _valueProcessResult = {};

                _valueParamSearch = JSON.stringify(Util.tut.tse.studentrecords.valueSearch());
                _valueStudentStatus = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-studentstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-studentstatus")
                });
                _valueGraduationDate = $("#" + _this2.idSectionProgress + "-graduationdate").val();
                _valueUpdateReason = $("#" + _this2.idSectionProgress + "-updatereason").val();

                _valueProcessResult["paramsearch"] = _valueParamSearch;
                _valueProcessResult["valuestudentstatus"] = _valueStudentStatus;
                _valueProcessResult["valuegraduationdate"] = _valueGraduationDate;
                _valueProcessResult["valueupdatereason"] = _valueUpdateReason;

                return _valueProcessResult;
            },
            getResultProcess: function (_param) {
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _detailComplete = _param["resultValueProcess"].DetailComplete;
                var _idTable = (_this1.idSectionMain + "-table");
                var _idTableRow;                
                var _valueArray = _detailComplete.split(",");
                var _obj;
                var _i;

                for (_i = 0; _i < _valueArray.length; _i++) {
                    _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueArray[_i]);

                    if ($("#" + _idTableRow).length > 0) {
                        $("#" + _idTableRow + " .table-col-studentstatus").html(_param["dataProcess"]["valuestudentstatus"]);
                        $("#" + _idTableRow + " .table-col-graduatedate").html(_param["dataProcess"]["valuegraduationdate"]);
                        $("#" + _idTableRow + " .table-col-reasonofgraduation").removeClass("link-click link-" + Util.tut.subjectSectionViewMessage.toLowerCase());
                        $("#" + _idTableRow + " .table-col-reasonofgraduation").attr("alt", "");
                        $("#" + _idTableRow + " .table-col-reasonofgraduation").html("");

                        if (("103|104|105|106|107|108").search(_param["dataProcess"]["valuestudentstatus"]) != -1) {
                            $("#" + _idTableRow + " .table-col-reasonofgraduation").addClass("link-click link-" + Util.tut.subjectSectionViewMessage.toLowerCase());
                            $("#" + _idTableRow + " .table-col-reasonofgraduation").attr("alt", _param["dataProcess"]["valueupdatereason"]);
                            $("#" + _idTableRow + " .table-col-reasonofgraduation").html("Message");

                            _this1.sectionMain.initTable();
                        }
                    }
                }
            }
        },
        updateadmissiondate: {
            idSectionProgress: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateAdmissionDateProgress.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-yearattended"),
                    width: 500,
                    height: 29
                });
                Util.initCalendar({
                    id: ("#" + _this2.idSectionProgress + "-admissiondate"),
                    yearRange: "-6:-0"
                });
                $("#" + _this2.idSectionProgress + "-updatereason").width(492).height(45);
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.dialogMessageClose();
                Util.resetForm({
                    id: (_this2.idSectionProgress + "-form")
                });

                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-yearattended"),
                    value: "0"
                });
                $("#" + _this2.idSectionProgress + "-admissiondate, #" + _this2.idSectionProgress + "-updatereason").val("");
            },
            validateProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _error = new Array();
                var _i = 0;
                
                if ($("#" + _this2.idSectionProgress + "-admissiondate").val().length == 0) {
                    _error[_i] = "กรุณาใส่วันที่เข้าศึกษา;Please enter admission date.;";
                    _i++;
                }

                if ($("#" + _this2.idSectionProgress + "-updatereason").val().length == 0) {
                    _error[_i] = "กรุณาใส่เหตุผลที่ปรับปรุง;Please enter update reason.;";
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
            getValueProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _valueParamSearch = {}
                var _valueYearAttended = "";
                var _valueAdmissionDate = "";
                var _valueUpdateReason = "";
                var _valueProcessResult = {};

                _valueParamSearch = JSON.stringify(Util.tut.tse.studentrecords.valueSearch());
                _valueYearAttended = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-yearattended")
                });
                _valueAdmissionDate = $("#" + _this2.idSectionProgress + "-admissiondate").val();
                _valueUpdateReason = $("#" + _this2.idSectionProgress + "-updatereason").val();

                _valueProcessResult["paramsearch"] = _valueParamSearch;
                _valueProcessResult["valueyearattended"] = _valueYearAttended;
                _valueProcessResult["valueadmissiondate"] = _valueAdmissionDate;
                _valueProcessResult["valueupdatereason"] = _valueUpdateReason;

                return _valueProcessResult;
            },
            getResultProcess: function (_param) {
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _detailComplete = _param["resultValueProcess"].DetailComplete;
                var _idTable = (_this1.idSectionMain + "-table");
                var _idTableRow;
                var _valueArray = _detailComplete.split(",");
                var _i;

                for (_i = 0; _i < _valueArray.length; _i++) {
                    _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueArray[_i]);

                    if ($("#" + _idTableRow).length > 0) {
                        if (_param["dataProcess"]["valueyearattended"].length > 0)
                            $("#" + _idTableRow + " .table-col-year").html(_param["dataProcess"]["valueyearattended"]);

                        $("#" + _idTableRow + " .table-col-admissiondate").html(_param["dataProcess"]["valueadmissiondate"]);
                    }
                }
            }
        },
        updatedatatoolddb: {
            idSectionProgress: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateDatatoOldDBProgress.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
            },
            resetMain: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;

                Util.dialogMessageClose();
                Util.resetForm({
                    id: (_this2.idSectionProgress + "-form")
                });
            },
            validateProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            getValueProcess: function () {
                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _valueParamSearch = {}
                var _valueProcessResult = {};

                _valueParamSearch = JSON.stringify(Util.tut.tse.studentrecords.valueSearch());

                _valueProcessResult["paramsearch"] = _valueParamSearch;

                return _valueProcessResult;
            },
            getResultProcess: function (_param) {
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
            }
        }
    },
    sectionPreview: {
        updatefacultyprogram: {
            idSectionPreview: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateFacultyProgramPreview.toLowerCase(),
            getList: function (_param) {
                _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
                _param["idPreview"] = (_param["idPreview"] == undefined ? null : _param["idPreview"]);
                _param["valueSelected"] = (_param["valueSelected"] == undefined ? "" : _param["valueSelected"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _idTable = (_this1.idSectionMain + "-table");
                var _dr = _param["valueSelected"].split("|")
                var _html = "";
                var _highlight;
                var _no;
                var _studentId;
                var _fullNameTH;
                var _programOld;
                var _programNew = $("#" + _param["idProgress"] + "-program-hidden").val();
                var _i = 0;

                $("#" + _param["idPreview"] + "-table .table-recordcount .recordcount-search").html(_dr.length);

                for (_i = 0; _i < _dr.length; _i++)
                {
                    _highlight = (_i % 2) == 0 ? " highlight-style1" : " highlight-style2";
                    _no = (_i + 1);
                    _studentId = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col3 .table-col-msg div").html();
                    _fullNameTH = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col4 .table-col-msg div").html();
                    _programOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col6 .table-col-msg div").html();

                    _html += "<div class='table-row" + _highlight + "'>" +
                             "  <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>" + _no + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>" + _studentId + "</div></div></div>" +
                             "  <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>" + _fullNameTH + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>" + _programOld + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>" + _programNew + "</div></div></div>" +
                             "</div>"
                }

                $("#" + _param["idPreview"] + "-table .table-list .table-grid").html(_html);
            }
        },
        updateclassyear: {
            idSectionPreview: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateClassYearPreview.toLowerCase(),
            getList: function (_param) {
                _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
                _param["idPreview"] = (_param["idPreview"] == undefined ? null : _param["idPreview"]);
                _param["valueSelected"] = (_param["valueSelected"] == undefined ? "" : _param["valueSelected"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _idTable = (_this1.idSectionMain + "-table");
                var _dr = _param["valueSelected"].split("|")
                var _html = "";
                var _highlight;
                var _no;
                var _studentId;
                var _fullNameTH;
                var _classOld;
                var _classNew = Util.getSelectionIsSelect({
                    id: ("#" + _param["idProgress"] + "-class"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-class")
                });
                var _i = 0;

                $("#" + _param["idPreview"] + "-table .table-recordcount .recordcount-search").html(_dr.length);
         
                for (_i = 0; _i < _dr.length; _i++) {
                    _highlight = (_i % 2) == 0 ? " highlight-style1" : " highlight-style2";
                    _no = (_i + 1);
                    _studentId = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col3 .table-col-msg div").html();
                    _fullNameTH = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col4 .table-col-msg div").html();
                    _classOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col8 .table-col-msg div").html();

                    _html += "<div class='table-row" + _highlight + "'>" +
                             "  <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>" + _no + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>" + _studentId + "</div></div></div>" +
                             "  <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>" + _fullNameTH + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>" + _classOld + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>" + _classNew + "</div></div></div>" +
                             "</div>"
                }

                $("#" + _param["idPreview"] + "-table .table-list .table-grid").html(_html);
            }
        },
        updateentrancetype: {
            idSectionPreview: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateEntranceTypePreview.toLowerCase(),
            getList: function (_param) {
                _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
                _param["idPreview"] = (_param["idPreview"] == undefined ? null : _param["idPreview"]);
                _param["valueSelected"] = (_param["valueSelected"] == undefined ? "" : _param["valueSelected"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _idTable = (_this1.idSectionMain + "-table");
                var _dr = _param["valueSelected"].split("|")
                var _html = "";
                var _highlight;
                var _no;
                var _studentId;
                var _fullNameTH;
                var _entranceTypeOld;
                var _entranceTypeNew = Util.getSelectionIsSelect({
                    id: ("#" + _param["idProgress"] + "-entrancetype"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-entrancetype")
                });
                var _i = 0;

                $("#" + _param["idPreview"] + "-table .table-recordcount .recordcount-search").html(_dr.length);

                for (_i = 0; _i < _dr.length; _i++) {
                    _highlight = (_i % 2) == 0 ? " highlight-style1" : " highlight-style2";
                    _no = (_i + 1);
                    _studentId = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col3 .table-col-msg div").html();
                    _fullNameTH = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col4 .table-col-msg div").html();
                    _entranceTypeOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col9 .table-col-msg div").html();

                    _html += "<div class='table-row" + _highlight + "'>" +
                             "  <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>" + _no + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>" + _studentId + "</div></div></div>" +
                             "  <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>" + _fullNameTH + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>" + _entranceTypeOld + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>" + _entranceTypeNew + "</div></div></div>" +
                             "</div>"
                }

                $("#" + _param["idPreview"] + "-table .table-list .table-grid").html(_html);
            }
        },
        updatestudentstatus: {
            idSectionPreview: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateStudentStatusPreview.toLowerCase(),
            getList: function (_param) {
                _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
                _param["idPreview"] = (_param["idPreview"] == undefined ? null : _param["idPreview"]);
                _param["valueSelected"] = (_param["valueSelected"] == undefined ? "" : _param["valueSelected"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _idTable = (_this1.idSectionMain + "-table");
                var _dr = _param["valueSelected"].split("|")
                var _html = "";
                var _highlight;
                var _no;
                var _studentId;
                var _fullNameTH;
                var _studentStatusOld;
                var _graduationDateOld;
                var _studentStatusNew = Util.getSelectionIsSelect({
                    id: ("#" + _param["idProgress"] + "-studentstatus"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-studentstatus")
                });
                var _graduationDateNew = $("#" + _param["idProgress"] + "-graduationdate").val();
                var _i = 0;

                $("#" + _param["idPreview"] + "-table .table-recordcount .recordcount-search").html(_dr.length);

                for (_i = 0; _i < _dr.length; _i++) {
                    _highlight = (_i % 2) == 0 ? " highlight-style1" : " highlight-style2";
                    _no = (_i + 1);
                    _studentId = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col3 .table-col-msg div").html();
                    _fullNameTH = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col4 .table-col-msg div").html();
                    _studentStatusOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col10 .table-col-msg div").html();
                    _graduationDateOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col12 .table-col-msg div").html();

                    _html += "<div class='table-row" + _highlight + "'>" +
                             "  <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>" + _no + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>" + _studentId + "</div></div></div>" +
                             "  <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>" + _fullNameTH + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>" + _studentStatusOld + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>" + _graduationDateOld + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>" + _studentStatusNew + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>" + _graduationDateNew + "</div></div></div>" +
                             "</div>"
                }

                $("#" + _param["idPreview"] + "-table .table-list .table-grid").html(_html);
            }
        },
        updateadmissiondate: {
            idSectionPreview: ePFStaffUtil.idSectionAdministrationStudentRecordsUpdateAdmissionDatePreview.toLowerCase(),
            getList: function (_param) {
                _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
                _param["idPreview"] = (_param["idPreview"] == undefined ? null : _param["idPreview"]);
                _param["valueSelected"] = (_param["valueSelected"] == undefined ? "" : _param["valueSelected"]);

                var _this1 = Util.tut.tsr;
                var _this2 = this;
                var _idTable = (_this1.idSectionMain + "-table");
                var _dr = _param["valueSelected"].split("|")
                var _html = "";
                var _highlight;
                var _no;
                var _studentId;
                var _fullNameTH;
                var _yearAttendedOld;
                var _admissionDateOld;
                var _yearAttendedNew = Util.getSelectionIsSelect({
                    id: ("#" + _param["idProgress"] + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-yearattended")
                });
                var _admissionDateNew = $("#" + _param["idProgress"] + "-admissiondate").val();
                var _i = 0;

                $("#" + _param["idPreview"] + "-table .table-recordcount .recordcount-search").html(_dr.length);

                for (_i = 0; _i < _dr.length; _i++) {
                    _highlight = (_i % 2) == 0 ? " highlight-style1" : " highlight-style2";
                    _no = (_i + 1);
                    _studentId = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col3 .table-col-msg div").html();
                    _fullNameTH = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col4 .table-col-msg div").html();
                    _yearAttendedOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col7 .table-col-msg div").html();
                    _admissionDateOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col11 .table-col-msg div").html();

                    _html += "<div class='table-row" + _highlight + "'>" +
                             "  <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>" + _no + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>" + _studentId + "</div></div></div>" +
                             "  <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>" + _fullNameTH + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>" + _yearAttendedOld + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>" + _admissionDateOld + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>" + _yearAttendedNew + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>" + _admissionDateNew + "</div></div></div>" +
                             "</div>"
                }

                $("#" + _param["idPreview"] + "-table .table-list .table-grid").html(_html);
            }
        }
    }
}