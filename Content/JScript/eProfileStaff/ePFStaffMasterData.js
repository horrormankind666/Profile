/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๑/๐๙/๒๕๕๘>
Modify date : <๐๕/๐๓/๒๕๖๔>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการจัดการข้อมูลหลัก>
=============================================
*/

var ePFStaffMasterData = {
    titleprefix: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataTitlePrefixMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.titleprefix;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.titleprefix;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },    
    gender: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataGenderMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.gender;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.gender;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    nationalityrace: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataNationalityRaceMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.nationalityrace;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.nationalityrace;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    religion: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataReligionMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.religion;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.religion;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    bloodgroup: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataBloodGroupMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.bloodgroup;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.bloodgroup;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    maritalstatus: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataMaritalStatusMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.maritalstatus;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.maritalstatus;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    familyrelationships: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataFamilyRelationshipsMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.familyrelationships;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.familyrelationships;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    agency: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataAgencyMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.agency;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.agency;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    educationallevel: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataEducationalLevelMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.educationallevel;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.educationallevel;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    educationalbackground: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataEducationalBackgroundMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.educationalbackground;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.educationalbackground;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    educationalmajor: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataEducationalMajorMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.educationalmajor;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.educationalmajor;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    admissiontype: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataAdmissionTypeMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.admissiontype;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.admissiontype;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    studentstatus: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataStudentStatusMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.studentstatus;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.studentstatus;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    country: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataCountryMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.country;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.country;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    province: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataProvinceMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.province;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.province;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    district: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataDistrictMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.district;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.district;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    subdistrict: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataSubdistrictMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.subdistrict;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.subdistrict;
                
                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    institute: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataInstituteMain.toLowerCase(),
        idSectionNew: ePFStaffUtil.idSectionMasterDataInstituteNew.toLowerCase(),
        idSectionEdit: ePFStaffUtil.idSectionMasterDataInstituteEdit.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.institute;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.institute;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        },
        sectionAddUpdate: {
            idSectionAddUpdate: "",
            sectionNew: {
                initMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.institute;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionNew;
                    _this3.initMain({
                        page: Util.tut.pageMasterDataInstituteNew
                    });
                }
            },
            sectionEdit: {
                initMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.institute;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionEdit;
                    _this3.initMain({
                        page: Util.tut.pageMasterDataInstituteEdit
                    });

                    this.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.institute;
                    var _this3 = _this2.sectionAddUpdate;
                }
            },
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tmd;
                var _this2 = _this1.institute;
                var _this3 = _this2.sectionAddUpdate;

                $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(525);
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-country"),
                    width: 533,
                    height: 29
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus")
                });

                $("input:text").keypress(function (_e) {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-institutenameth"))
                        return Util.blockEnglish(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-institutenameen"))
                        return Util.blockNonEnglishAndNumeric(this, _e);
                });

                $("input:text").focusout(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-institutenameen"))
                        $(this).val($(this).val().toUpperCase());
                });

                $("#" + _this3.idSectionAddUpdate + "-form .button .click-button").click(function () {
                    if ($(this).hasClass("button-save") == true)
                        _this1.confirmSave({
                            page: _param["page"]
                        });

                    if ($(this).hasClass("button-undo") == true)
                        _this3.resetMain();
                });

                _this3.resetMain();
            },
            resetMain: function () {
                var _this1 = Util.tut.tmd;
                var _this2 = _this1.institute;
                var _this3 = _this2.sectionAddUpdate;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });

                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-country"),
                    value: $("#" + _this3.idSectionAddUpdate + "-country-hidden").val()
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-province"),
                    value: $("#" + _this3.idSectionAddUpdate + "-province-hidden").val()
                }, function () {
                });
                $("#" + _this3.idSectionAddUpdate + "-institutenameth").val($("#" + _this3.idSectionAddUpdate + "-institutenameth-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-institutenameen").val($("#" + _this3.idSectionAddUpdate + "-institutenameen-hidden").val());
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-cancelledstatus-hidden").val()
                });
            },            
            validateSave: function () {
                var _this1 = Util.tut.tmd;
                var _this2 = _this1.institute;
                var _this3 = _this2.sectionAddUpdate;
                var _error = new Array();
                var _i = 0;

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-country") == "0") {
                    _error[_i] = ("กรุณาเลือกประเทศ;Please select country.;" + _this3.idSectionAddUpdate + "-country-content");
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-province") == "0") {
                    _error[_i] = ("กรุณาเลือกจังหวัด;Please select province.;" + _this3.idSectionAddUpdate + "-province-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-institutenameth").val().length == 0 && $("#" + _this3.idSectionAddUpdate + "-institutenameen").val().length == 0) {
                    _error[_i] = ("กรุณาใส่ชื่อโรงเรียน / สถาบัน;Please enter name of institution.;" + _this3.idSectionAddUpdate + "-institutenameth-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            }
        }
    },
    diseases: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataDiseasesMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.diseases;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.diseases;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            }
        }
    },
    healthimpairments: {
        idSectionMain: ePFStaffUtil.idSectionMasterDataHealthImpairmentsMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.healthimpairments;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.healthimpairments;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
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

        if (_param["page"] == Util.tut.pageMasterDataInstituteNew)
            _this = this.institute.sectionAddUpdate;

        if (_param["page"] == Util.tut.pageMasterDataInstituteEdit)
            _this = this.institute.sectionAddUpdate;

        if (_this != null)
            _validateResult = _this.validateSave();

        return _validateResult;
    },
    getSave: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this1;
        var _this2 = this;
        var _error;
        var _msg;
        var _i;
        var _value;
        var _valueSave = {};

        if (_param["page"] == Util.tut.pageMasterDataInstituteNew ||
            _param["page"] == Util.tut.pageMasterDataInstituteEdit) {           
            _this1 = _this2.institute.sectionAddUpdate;

            _valueSave["id"]                = $("#" + _this1.idSectionAddUpdate + "-id-hidden").val();
            _valueSave["province"]          = Util.getSelectionIsSelect({
                                                  id: ("#" + _this1.idSectionAddUpdate + "-province"),
                                                  type: "select",
                                                  valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-province")
                                              });
            _valueSave["institutenameth"]   = $("#" + _this1.idSectionAddUpdate + "-institutenameth").val();
            _valueSave["institutenameen"]   = $("#" + _this1.idSectionAddUpdate + "-institutenameen").val();
            _valueSave["cancelledstatus"]   = Util.getSelectionIsSelect({
                                                  id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                                                  type: "checkbox",
                                                  valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                                                  valueFalse: "N"
                                              });
        }

        this.actionSave({
            page: _param["page"],
            data: _valueSave
        }, function (_resultSave, _resultValueSave) {
            if (_resultSave == true) {
                if (_param["page"] == Util.tut.pageMasterDataInstituteNew)
                    _this1.resetMain();
                else
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

        if (_param["page"] == Util.tut.pageMasterDataInstituteEdit) {
            _this1 = _this2.institute.sectionAddUpdate;

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
            $("#" + _this1.idSectionAddUpdate + "-institutenameth-hidden").val($("#" + _this1.idSectionAddUpdate + "-institutenameth").val());
            $("#" + _this1.idSectionAddUpdate + "-institutenameen-hidden").val($("#" + _this1.idSectionAddUpdate + "-institutenameen").val());
            $("#" + _this1.idSectionAddUpdate + "-cancelledstatus-hidden").val(
            Util.getSelectionIsSelect({
                id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                type: "checkbox",
                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                valueFalse: "N"
            }));
        }
    }
}