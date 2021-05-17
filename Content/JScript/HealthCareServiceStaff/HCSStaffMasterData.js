/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๒๑/๐๗/๒๕๕๘>
Modify date : <๒๙/๐๕/๒๕๖๒>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการจัดการข้อมูลหลัก>
=============================================
*/

var HCSStaffMasterData = {
    hospitalofhealthcareservice: {
        idSectionMain: HCSStaffUtil.idSectionMasterDataHospitalOfHealthCareServiceMain.toLowerCase(),
        idSectionNew: HCSStaffUtil.idSectionMasterDataHospitalOfHealthCareServiceNew.toLowerCase(),
        idSectionEdit: HCSStaffUtil.idSectionMasterDataHospitalOfHealthCareServiceEdit.toLowerCase(),        
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.hospitalofhealthcareservice;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.hospitalofhealthcareservice;
                
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
                    var _this2 = _this1.hospitalofhealthcareservice;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionNew;
                    _this3.initMain({
                        page: Util.tut.pageMasterDataHospitalOfHealthCareServiceNew
                    });
                },
            },
            sectionEdit: {
                initMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.hospitalofhealthcareservice;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionEdit;
                    _this3.initMain({
                        page: Util.tut.pageMasterDataHospitalOfHealthCareServiceEdit
                    });

                    this.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.hospitalofhealthcareservice;
                    var _this3 = _this2.sectionAddUpdate;
                    
                    Util.textboxDisable("#" + _this3.idSectionAddUpdate + "-id");
                }
            },
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tmd;
                var _this2 = _this1.hospitalofhealthcareservice;
                var _this3 = _this2.sectionAddUpdate;

                $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(525);
                $("#" + _this3.idSectionAddUpdate + "-id").css("width", "178px").attr("maxlength", "15");
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus")
                });
                
                $("input:text").keypress(function (_e) {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-id"))
                        return Util.blockNonEnglishAndNumeric(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-hospitalnameth"))
                        return Util.blockEnglish(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-hospitalnameen"))
                        return Util.blockNonEnglishAndNumeric(this, _e);
                });
                
                $("input:text").focusout(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-id"))
                        $(this).val($(this).val().toUpperCase());

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-hospitalnameen"))
                        $(this).val(Util.toUpperCaseFirst($(this).val()));
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
                var _this2 = _this1.hospitalofhealthcareservice;
                var _this3 = _this2.sectionAddUpdate;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });

                $("#" + _this3.idSectionAddUpdate + "-id").val($("#" + _this3.idSectionAddUpdate + "-id-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-hospitalnameth").val($("#" + _this3.idSectionAddUpdate + "-hospitalnameth-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-hospitalnameen").val($("#" + _this3.idSectionAddUpdate + "-hospitalnameen-hidden").val());
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-cancelledstatus-hidden").val()
                });
            },
            validateSave: function () {
                var _this1 = Util.tut.tmd;
                var _this2 = _this1.hospitalofhealthcareservice;
                var _this3 = _this2.sectionAddUpdate;
                var _error = new Array();
                var _i = 0;

                if ($("#" + _this3.idSectionAddUpdate + "-id").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รหัส;Please enter id.;" + _this3.idSectionAddUpdate + "-id-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-hospitalnameth").val().length == 0) {
                    _error[_i] = ("กรุณาใส่ชื่อหน่วยบริการสุขภาพ;Please enter hospital name.;" + _this3.idSectionAddUpdate + "-hospitalnameth-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
        },
    },    
    registrationform: {
        idSectionMain: HCSStaffUtil.idSectionMasterDataRegistrationFormMain.toLowerCase(),
        idSectionNew: HCSStaffUtil.idSectionMasterDataRegistrationFormNew.toLowerCase(),
        idSectionEdit: HCSStaffUtil.idSectionMasterDataRegistrationFormEdit.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.registrationform;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.registrationform;

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
                    var _this2 = _this1.registrationform;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionNew;
                    _this3.initMain({
                        page: Util.tut.pageMasterDataRegistrationFormNew
                    });
                },
            },
            sectionEdit: {
                initMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.registrationform;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionEdit;
                    _this3.initMain({
                        page: Util.tut.pageMasterDataRegistrationFormEdit
                    });

                    this.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.registrationform;
                    var _this3 = _this2.sectionAddUpdate;
                    
                    Util.textboxDisable("#" + _this3.idSectionAddUpdate + "-id");
                }
            },
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tmd;
                var _this2 = _this1.registrationform;
                var _this3 = _this2.sectionAddUpdate;

                $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(525);
                $("#" + _this3.idSectionAddUpdate + "-id").css("width", "178px").attr("maxlength", "20");
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-forpublicservant")
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-orderform"),
                    width: 186,
                    height: 29
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus")
                });

                $("input:text").keypress(function (_e) {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-id"))
                        return Util.blockNonEnglishAndNumeric(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-formnameth"))
                        return Util.blockEnglish(this, _e);

                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-formnameen"))
                        return Util.blockNonEnglishAndNumeric(this, _e);
                });

                $("input:text").focusout(function () {
                    if ($(this).attr("id") == (_this3.idSectionAddUpdate + "-formnameen"))
                        $(this).val(Util.toUpperCaseFirst($(this).val()));
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
                var _this2 = _this1.registrationform;
                var _this3 = _this2.sectionAddUpdate;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });

                $("#" + _this3.idSectionAddUpdate + "-id").val($("#" + _this3.idSectionAddUpdate + "-id-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-formnameth").val($("#" + _this3.idSectionAddUpdate + "-formnameth-hidden").val());
                $("#" + _this3.idSectionAddUpdate + "-formnameen").val($("#" + _this3.idSectionAddUpdate + "-formnameen-hidden").val());
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-forpublicservant"),
                    value: $("#" + _this3.idSectionAddUpdate + "-forpublicservant-hidden").val()
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-orderform"),
                    value: $("#" + _this3.idSectionAddUpdate + "-orderform-hidden").val()
                });
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-cancelledstatus-hidden").val()
                });
            },
            validateSave: function () {
                var _this1 = Util.tut.tmd;
                var _this2 = _this1.registrationform;
                var _this3 = _this2.sectionAddUpdate;
                var _error = new Array();
                var _i = 0;

                if ($("#" + _this3.idSectionAddUpdate + "-id").val().length == 0) {
                    _error[_i] = ("กรุณาใส่รหัส;Please enter id.;" + _this3.idSectionAddUpdate + "-id-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-formnameth").val().length == 0) {
                    _error[_i] = ("กรุณาใส่ชื่อแบบฟอร์มบริการสุขภาพ;Please enter form name.;" + _this3.idSectionAddUpdate + "-formnameth-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
        }
    },    
    agencyregistered: {
        idSectionMain: HCSStaffUtil.idSectionMasterDataAgencyRegisteredMain.toLowerCase(),
        idSectionNew: HCSStaffUtil.idSectionMasterDataAgencyRegisteredNew.toLowerCase(),
        idSectionEdit: HCSStaffUtil.idSectionMasterDataAgencyRegisteredEdit.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tmd.agencyregistered;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tmd.agencyregistered;

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
                    var _this2 = _this1.agencyregistered;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionNew;
                    _this3.initMain({
                        page: Util.tut.pageMasterDataAgencyRegisteredNew
                    });
                },
            },
            sectionEdit: {
                initMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.agencyregistered;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionEdit;
                    _this3.initMain({
                        page: Util.tut.pageMasterDataAgencyRegisteredEdit
                    });

                    this.resetMain();
                },
                resetMain: function () {
                    var _this1 = Util.tut.tmd;
                    var _this2 = _this1.agencyregistered;
                    var _this3 = _this2.sectionAddUpdate;
                    
                    Util.comboboxDisable("#" + _this3.idSectionAddUpdate + "-yearattended");
                    Util.comboboxDisable("#" + _this3.idSectionAddUpdate + "-degreelevel");
                    Util.comboboxDisable("#" + _this3.idSectionAddUpdate + "-faculty");
                }
            },
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tmd;
                var _this2 = _this1.agencyregistered;
                var _this3 = _this2.sectionAddUpdate;

                $("#" + _this3.idSectionAddUpdate + "-form .form-content .inputbox").width(525);
                $("#" + _this3.idSectionAddUpdate + "-form .form-content .textareabox").width(525).height(154);
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-yearattended"),
                    width: 533,
                    height: 29
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-degreelevel"),
                    width: 533,
                    height: 29
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-faculty"),
                    width: 533,
                    height: 29
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-hospital"),
                    width: 533,
                    height: 29
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-registrationform")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus")
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
                var _this2 = _this1.agencyregistered;
                var _this3 = _this2.sectionAddUpdate;
                var _value;
                var _valueArray;
                var _i;

                Util.dialogMessageClose();
                Util.gotoTopElement();
                Util.resetForm({
                    id: (_this3.idSectionAddUpdate + "-form")
                });

                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-yearattended"),
                    value: $("#" + _this3.idSectionAddUpdate + "-yearattended-hidden").val()
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-degreelevel"),
                    value: $("#" + _this3.idSectionAddUpdate + "-degreelevel-hidden").val()
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-faculty"),
                    value: $("#" + _this3.idSectionAddUpdate + "-faculty-hidden").val()
                });
                Util.tut.setSelectDefaultCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-program"),
                    value: $("#" + _this3.idSectionAddUpdate + "-program-hidden").val()
                }, function () {
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-program"),
                        value: $("#" + _this3.idSectionAddUpdate + "-program-hidden").val()
                    });
                    $("input[name=" + _this3.idSectionAddUpdate + "-program]").iCheck("disable");
                });
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-hospital"),
                    value: $("#" + _this3.idSectionAddUpdate + "-hospital-hidden").val()
                });

                _value = $("#" + _this3.idSectionAddUpdate + "-registrationform-hidden").val();
                _valueArray = _value.split(",");

                for (_i = 0; _i < _valueArray.length; _i++) {
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-registrationform"),
                        value: _valueArray[_i]
                    });
                }

                $("#" + _this3.idSectionAddUpdate + "-programaddress").val($("#" + _this3.idSectionAddUpdate + "-programaddress-hidden").val().replace(/&/g, "\n"));
                $("#" + _this3.idSectionAddUpdate + "-programtelephone").val($("#" + _this3.idSectionAddUpdate + "-programtelephone-hidden").val());
                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-cancelledstatus-hidden").val()
                });
            },            
            validateSave: function () {
                var _this1 = Util.tut.tmd;
                var _this2 = _this1.agencyregistered;
                var _this3 = _this2.sectionAddUpdate;
                var _error = new Array();
                var _i = 0;

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-yearattended") == "0") {
                    _error[_i] = ("กรุณาเลือกปีที่เข้าศึกษา;Please select year attended.;" + _this3.idSectionAddUpdate + "-yearattended-content");
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-faculty") == "0") {
                    _error[_i] = ("กรุณาเลือกคณะ;Please select faculty.;" + _this3.idSectionAddUpdate + "-faculty-content");
                    _i++;
                }

                if ($("input[name=" + _this3.idSectionAddUpdate + "-program]:checked").length == 0) {
                    _error[_i] = ("กรุณาเลือกหลักสูตร;Please select program.;" + _this3.idSectionAddUpdate + "-program-content");
                    _i++;
                }

                if (Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-hospital") == "0") {
                    _error[_i] = ("กรุณาเลือกหน่วยบริการสุขภาพ;Please select hospital of health care service.;" + _this3.idSectionAddUpdate + "-hospital-content");
                    _i++;
                }

                if ($("input[name=" + _this3.idSectionAddUpdate + "-registrationform]:checked").length == 0) {
                    _error[_i] = ("กรุณาเลือกแบบฟอร์มบริการสุขภาพ;Please select registration form.;" + _this3.idSectionAddUpdate + "-registrationform-content");
                    _i++;
                }

                if ($("#" + _this3.idSectionAddUpdate + "-programaddress").val().length == 0) {
                    _error[_i] = ("กรุณาใส่ที่อยู่สำหรับจัดส่งเอกสาร;Please enter address for delivery.;" + _this3.idSectionAddUpdate + "-programaddress-content");
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
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

        if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceNew)
            _this = this.hospitalofhealthcareservice.sectionAddUpdate;

        if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceEdit)
            _this = this.hospitalofhealthcareservice.sectionAddUpdate;

        if (_param["page"] == Util.tut.pageMasterDataRegistrationFormNew)
            _this = this.registrationform.sectionAddUpdate;

        if (_param["page"] == Util.tut.pageMasterDataRegistrationFormEdit)
            _this = this.registrationform.sectionAddUpdate;

        if (_param["page"] == Util.tut.pageMasterDataAgencyRegisteredNew)
            _this = this.agencyregistered.sectionAddUpdate;

        if (_param["page"] == Util.tut.pageMasterDataAgencyRegisteredEdit)
            _this = this.agencyregistered.sectionAddUpdate;

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

        if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceNew) {
            _this1 = _this2.hospitalofhealthcareservice.sectionAddUpdate;

            _valueSave["id"] = $("#" + _this1.idSectionAddUpdate + "-id").val();
            _valueSave["hospitalnameth"] = $("#" + _this1.idSectionAddUpdate + "-hospitalnameth").val();
            _valueSave["hospitalnameen"] = $("#" + _this1.idSectionAddUpdate + "-hospitalnameen").val();
            _valueSave["cancelledstatus"] = Util.getSelectionIsSelect({
                id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                type: "checkbox",
                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                valueFalse: "N"
            });
        }
        
        if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceEdit) {
            _this1 = _this2.hospitalofhealthcareservice.sectionAddUpdate;

            _valueSave["id"] = $("#" + _this1.idSectionAddUpdate + "-id").val();
            _valueSave["hospitalnameth"] = $("#" + _this1.idSectionAddUpdate + "-hospitalnameth").val();
            _valueSave["hospitalnameen"] = $("#" + _this1.idSectionAddUpdate + "-hospitalnameen").val();
            _valueSave["cancelledstatus"] = Util.getSelectionIsSelect({
                id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                type: "checkbox",
                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                valueFalse: "N"
            });
        }
        
        if (_param["page"] == Util.tut.pageMasterDataRegistrationFormNew) {
            _this1 = _this2.registrationform.sectionAddUpdate;

            _valueSave["id"] = $("#" + _this1.idSectionAddUpdate + "-id").val();
            _valueSave["formnameth"] = $("#" + _this1.idSectionAddUpdate + "-formnameth").val();
            _valueSave["formnameen"] = $("#" + _this1.idSectionAddUpdate + "-formnameen").val();
            _valueSave["forpublicservant"] = Util.getSelectionIsSelect({
                id: (_this1.idSectionAddUpdate + "-forpublicservant"),
                type: "checkbox",
                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-forpublicservant"),
                valueFalse: "N"
            });
            _valueSave["orderform"] = Util.getSelectionIsSelect({
                id: ("#" + _this1.idSectionAddUpdate + "-orderform"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-orderform")
            });
            _valueSave["cancelledstatus"] = Util.getSelectionIsSelect({
                id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                type: "checkbox",
                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                valueFalse: "N"
            });
        }
        
        if (_param["page"] == Util.tut.pageMasterDataRegistrationFormEdit) {
            _this1 = _this2.registrationform.sectionAddUpdate;

            _valueSave["id"] = $("#" + _this1.idSectionAddUpdate + "-id").val();
            _valueSave["formnameth"] = $("#" + _this1.idSectionAddUpdate + "-formnameth").val();
            _valueSave["formnameen"] = $("#" + _this1.idSectionAddUpdate + "-formnameen").val();
            _valueSave["forpublicservant"] = Util.getSelectionIsSelect({
                id: (_this1.idSectionAddUpdate + "-forpublicservant"),
                type: "checkbox",
                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-forpublicservant"),
                valueFalse: "N"
            });
            _valueSave["orderform"] = Util.getSelectionIsSelect({
                id: ("#" + _this1.idSectionAddUpdate + "-orderform"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-orderform")
            });
            _valueSave["cancelledstatus"] = Util.getSelectionIsSelect({
                id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                type: "checkbox",
                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                valueFalse: "N"
            });
        }

        if (_param["page"] == Util.tut.pageMasterDataAgencyRegisteredNew) {
            _this1 = _this2.agencyregistered.sectionAddUpdate;

            _valueSave["id"] = $("#" + _this1.idSectionAddUpdate + "-id-hidden").val();
            _valueSave["yearentry"] = Util.getSelectionIsSelect({
                id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended")
            });
            _valueSave["program"] = Util.getValueSelectCheck({
                id: (_this1.idSectionAddUpdate + "-program")
            }).join(",");
            _valueSave["hospital"] = Util.getSelectionIsSelect({
                id: ("#" + _this1.idSectionAddUpdate + "-hospital"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-hospital")
            });
            _valueSave["registrationform"] = Util.getValueSelectCheck({
                id: (_this1.idSectionAddUpdate + "-registrationform")
            }).join(",");
            _valueSave["programaddress"] = $("#" + _this1.idSectionAddUpdate + "-programaddress").val().replace(/\n/g, "&");
            _valueSave["programtelephone"] = $("#" + _this1.idSectionAddUpdate + "-programtelephone").val();
            _valueSave["cancelledstatus"] = Util.getSelectionIsSelect({
                id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                type: "checkbox",
                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                valueFalse: "N"
            });
        }
        
        if (_param["page"] == Util.tut.pageMasterDataAgencyRegisteredEdit) {
            _this1 = _this2.agencyregistered.sectionAddUpdate;

            _valueSave["id"] = $("#" + _this1.idSectionAddUpdate + "-id-hidden").val();
            _valueSave["yearentry"] = Util.getSelectionIsSelect({
                id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended")
            });
            _valueSave["program"] = Util.getValueSelectCheck({
                id: (_this1.idSectionAddUpdate + "-program")
            }).join(",");
            _valueSave["hospital"] = Util.getSelectionIsSelect({
                id: ("#" + _this1.idSectionAddUpdate + "-hospital"),
                type: "select",
                valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-hospital")
            });
            _valueSave["registrationform"] = Util.getValueSelectCheck({
                id: (_this1.idSectionAddUpdate + "-registrationform")
            }).join(",");
            _valueSave["programaddress"] = $("#" + _this1.idSectionAddUpdate + "-programaddress").val().replace(/\n/g, "&");
            _valueSave["programtelephone"] = $("#" + _this1.idSectionAddUpdate + "-programtelephone").val();
            _valueSave["cancelledstatus"] = Util.getSelectionIsSelect({
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
                if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceNew ||
                    _param["page"] == Util.tut.pageMasterDataRegistrationFormNew ||
                    _param["page"] == Util.tut.pageMasterDataAgencyRegisteredNew)
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

        if (_param["page"] == Util.tut.pageMasterDataHospitalOfHealthCareServiceEdit) {
            _this1 = _this2.hospitalofhealthcareservice.sectionAddUpdate;

            $("#" + _this1.idSectionAddUpdate + "-id-hidden").val($("#" + _this1.idSectionAddUpdate + "-id").val());
            $("#" + _this1.idSectionAddUpdate + "-hospitalnameth-hidden").val($("#" + _this1.idSectionAddUpdate + "-hospitalnameth").val());
            $("#" + _this1.idSectionAddUpdate + "-hospitalnameen-hidden").val($("#" + _this1.idSectionAddUpdate + "-hospitalnameen").val());
            $("#" + _this1.idSectionAddUpdate + "-cancelledstatus-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                    valueFalse: "N"
                })
            );
        }
        
        if (_param["page"] == Util.tut.pageMasterDataRegistrationFormEdit) {
            _this1 = _this2.registrationform.sectionAddUpdate;

            $("#" + _this1.idSectionAddUpdate + "-id-hidden").val($("#" + _this1.idSectionAddUpdate + "-id").val());
            $("#" + _this1.idSectionAddUpdate + "-formnameth-hidden").val($("#" + _this1.idSectionAddUpdate + "-formnameth").val());
            $("#" + _this1.idSectionAddUpdate + "-formnameen-hidden").val($("#" + _this1.idSectionAddUpdate + "-formnameen").val());
            $("#" + _this1.idSectionAddUpdate + "-forpublicservant-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-forpublicservant"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-forpublicservant"),
                    valueFalse: "N"
                })
            );
            $("#" + _this1.idSectionAddUpdate + "-orderform-hidden").val(
                Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-orderform"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-orderform"),
                    valueFalse: "0"
                })
            );
            $("#" + _this1.idSectionAddUpdate + "-cancelledstatus-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                    valueFalse: "N"
                })
            );
        }
        
        if (_param["page"] == Util.tut.pageMasterDataAgencyRegisteredEdit)
        {
            _this1 = _this2.agencyregistered.sectionAddUpdate;

            $("#" + _this1.idSectionAddUpdate + "-id-hidden").val($("#" + _this1.idSectionAddUpdate + "-id-hidden").val());
            $("#" + _this1.idSectionAddUpdate + "-yearattended-hidden").val(
                Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-yearattended"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-yearattended"),
                    valueFalse: "0"
                })
            );
            $("#" + _this1.idSectionAddUpdate + "-degreelevel-hidden").val(
                Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-degreelevel"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-degreelevel"),
                    valueFalse: "0"
                })
            );
            $("#" + _this1.idSectionAddUpdate + "-faculty-hidden").val(
                Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-faculty"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-faculty"),
                    valueFalse: "0"
                })
            );
            $("#" + _this1.idSectionAddUpdate + "-program-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-program"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-program")
                })
            );
            $("#" + _this1.idSectionAddUpdate + "-hospital-hidden").val(
                Util.getSelectionIsSelect({
                    id: ("#" + _this1.idSectionAddUpdate + "-hospital"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-hospital"),
                    valueFalse: "0"
                })
            );
            $("#" + _this1.idSectionAddUpdate + "-registrationform-hidden").val(
                Util.getValueSelectCheck({
                    id: (_this1.idSectionAddUpdate + "-registrationform")
                }).join(",")
            );
            $("#" + _this1.idSectionAddUpdate + "-programaddress-hidden").val($("#" + _this1.idSectionAddUpdate + "-programaddress").val().replace(/\n/g, "&"));
            $("#" + _this1.idSectionAddUpdate + "-programtelephone-hidden").val($("#" + _this1.idSectionAddUpdate + "-programtelephone").val());
            $("#" + _this1.idSectionAddUpdate + "-cancelledstatus-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus"),
                    valueFalse: "N"
                })
            );
        }
    }
}