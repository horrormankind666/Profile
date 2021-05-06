// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๒๓/๐๖/๒๕๕๘>
// Modify date  : <๒๙/๐๕/๒๕๖๒>
// Description  : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการจัดการระบบ>
// =============================================

var UDSStaffSetting = {
    accesstothesystem: {
        idSectionEdit: UDSStaffUtil.idSectionSettingAccesstotheSystemEdit.toLowerCase(),

        sectionAddUpdate: {
            idSectionAddUpdate: "",

            sectionEdit: {
                //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการแก้ไขในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ
                initMain: function () {
                    var _this1 = Util.tut.tst;
                    var _this2 = _this1.accesstothesystem;
                    var _this3 = _this2.sectionAddUpdate;

                    _this3.idSectionAddUpdate = _this2.idSectionEdit;
                    _this3.initMain({
                        page: Util.tut.pageSettingAccesstotheSystemEdit
                    });

                    this.resetMain();
                },
                
                //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานของการแก้ไขในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ
                resetMain: function () {
                    var _this1 = Util.tut.tst;
                    var _this2 = _this1.accesstothesystem;
                    var _this3 = _this2.sectionAddUpdate;
                }
            },

            //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานให้กับการเพิ่มหรือแก้ไขในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //page      รับค่าชื่อหน้า
            initMain: function (_param) {
                _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

                var _this1 = Util.tut.tst;
                var _this2 = _this1.accesstothesystem;
                var _this3 = _this2.sectionAddUpdate;

                Util.initCalendarFromTo({
                    idFrom: ("#" + _this3.idSectionAddUpdate + "-startdate"),
                    idTo: ("#" + _this3.idSectionAddUpdate + "-enddate")
                });
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-starthour"),
                    width: 52,
                    height: 29
                });                                       
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-startminute"),
                    width: 52,
                    height: 29
                });                    
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-startsecond"),
                    width: 52,
                    height: 29
                });                    
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-endhour"),
                    width: 52,
                    height: 29 
                });                    
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-endminute"),
                    width: 52,
                    height: 29 
                });                    
                Util.initCombobox({
                    id: ("#" + _this3.idSectionAddUpdate + "-endsecond"),
                    width: 52,
                    height: 29                     
                });                    
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-yearattended")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-entrancetype")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-faculty")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-program")
                });
                Util.initCheck({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus")
                });

                $(".checkbox").on("ifChecked ifUnchecked", function () {
                    if ($(this).attr("name") == (_this3.idSectionAddUpdate + "-faculty"))
                        _this3.setProgramOnCheckFaculty({
                            faculty: $(this).val()
                        });
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

            //ฟังก์ชั่นสำหรับรีเซ็ตการทำงานของการเพิ่มหรือแก้ไขในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ
            resetMain: function () {
                var _this1 = Util.tut.tst;
                var _this2 = _this1.accesstothesystem;
                var _this3 = _this2.sectionAddUpdate;
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

                $("#" + _this3.idSectionAddUpdate + "-startdate").val($("#" + _this3.idSectionAddUpdate + "-startdate-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-starthour"),
                    value: $("#" + _this3.idSectionAddUpdate + "-starthour-hidden").val()
                });                    
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-startminute"),
                    value: $("#" + _this3.idSectionAddUpdate + "-startminute-hidden").val()
                });                    
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-startsecond"),
                    value: $("#" + _this3.idSectionAddUpdate + "-startsecond-hidden").val()
                });                    
                $("#" + _this3.idSectionAddUpdate + "-enddate").val($("#" + _this3.idSectionAddUpdate + "-enddate-hidden").val());
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-endhour"),
                    value: $("#" + _this3.idSectionAddUpdate + "-endhour-hidden").val()
                });                        
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-endminute"),
                    value: $("#" + _this3.idSectionAddUpdate + "-endminute-hidden").val()
                });                    
                Util.comboboxSetValue({
                    id: ("#" + _this3.idSectionAddUpdate + "-endsecond"),
                    value: $("#" + _this3.idSectionAddUpdate + "-endsecond-hidden").val()
                });                        
                
                _value = $("#" + _this3.idSectionAddUpdate + "-yearattended-hidden").val();
                _valueArray = _value.split(",");

                for (_i = 0; _i < _valueArray.length; _i++)
                {
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-yearattended"),
                        value: _valueArray[_i]
                    });
                }
               
                _value = $("#" + _this3.idSectionAddUpdate + "-entrancetype-hidden").val();
                _valueArray = _value.split(",");

                for (_i = 0; _i < _valueArray.length; _i++)
                {
                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-entrancetype"),
                        value: _valueArray[_i]
                    });
                }            
                
                $(".program-list-row").hide();
            
                _value = $("#" + _this3.idSectionAddUpdate + "-facultyprogram-hidden").val();
                _valueArray = _value.split(";");

                for (_i = 0; _i < _valueArray.length; _i++)
                {
                    _valueSubArray = _valueArray[_i].split(":");

                    Util.checkSetValue({
                        id: (_this3.idSectionAddUpdate + "-faculty"),
                        value: _valueSubArray[0]
                    });                   
                    _this3.setProgramOnCheckFaculty({ 
                        faculty: _valueSubArray[0]
                    });

                    if (_valueSubArray.length == 2)
                    {
                        _valueSubSubArray = _valueSubArray[1].split(",");

                        for (_j = 0; _j < _valueSubSubArray.length; _j++)
                        {
                            Util.checkSetValue({
                                id: (_this3.idSectionAddUpdate + "-program"),
                                value: _valueSubSubArray[_j]
                            });
                        }
                    }
                }

                Util.checkSetValue({
                    id: (_this3.idSectionAddUpdate + "-cancelledstatus"),
                    value: $("#" + _this3.idSectionAddUpdate + "-cancelledstatus-hidden").val()
                });
            },
            
            //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องในการบันทึกข้อมูลในส่วนของการจัดการระบบ-การเข้าใช้งานระบบ
            validateSave: function () {
                var _this1 = Util.tut.tst;
                var _this2 = _this1.accesstothesystem;
                var _this3 = _this2.sectionAddUpdate;
                var _error = new Array();
                var _i = 0;

                if ($("#" + _this3.idSectionAddUpdate + "-startdate").val().length == 0) { _error[_i] = "กรุณาใส่วันทำการเริ่มต้น;Please enter office hour start date.;" + _this3.idSectionAddUpdate + "-startdatetime-content"; _i++; }
                if ($("#" + _this3.idSectionAddUpdate + "-enddate").val().length == 0) { _error[_i] = "กรุณาใส่วันทำการสิ้นสุด;Please enter office hour end date.;" + _this3.idSectionAddUpdate + "-enddatetime-content"; _i++; }
                if (($("#" + _this3.idSectionAddUpdate + "-startdate").val() == $("#" + _this3.idSectionAddUpdate + "-enddate").val()))
                {
                    var _startHour      = parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-starthour"));
                    var _startMinute    = parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-startminute"));
                    var _startSecond    = parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-startsecond"));
                    var _endHour        = parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-endhour"));
                    var _endMinute      = parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-endminute"));
                    var _endSecond      = parseInt(Util.comboboxGetValue("#" + _this3.idSectionAddUpdate + "-endsecond"));

                    if ((_startHour > _endHour) || (_startHour == _endHour && _startMinute > _endMinute) || (_startHour == _endHour && _startMinute == _endMinute && _startSecond > _endSecond))
                    {
                        _error[_i] = "กรุณาใส่เวลาทำการให้ถูกต้อง;Invalid office hour.;" + _this3.idSectionAddUpdate + "-startdatetime-content"; _i++;
                    }
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },

            //ฟังก์ชั่นสำหรับเซ็ตการแสดงหลักสูตรตามคณะกรณีที่เลือกคณะ
            //โดยมีพารามิเตอร์ดังนี้
            //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
            //faculty   รับค่ารหัสคณะ
            setProgramOnCheckFaculty: function (_param) {
                _param["faculty"] = (_param["faculty"] == undefined ? "" : _param["faculty"]);

                var _this1 = Util.tut.tst;
                var _this2 = _this1.accesstothesystem;
                var _this3 = _this2.sectionAddUpdate;
                var _idFaculty = (_this3.idSectionAddUpdate + "-faculty" + _param["faculty"]);
                var _disable = ($("#" + _idFaculty).is(":checked") ? "enable" : "disable");

                $(".faculty-" + _param["faculty"] + " input[name=" + _this3.idSectionAddUpdate + "-program]").iCheck("uncheck");
                $(".faculty-" + _param["faculty"] + " input[name=" + _this3.idSectionAddUpdate + "-program]").iCheck(_disable);

                if (_disable == "disable")
                    $(".faculty-" + _param["faculty"]).hide();
                else
                    $(".faculty-" + _param["faculty"]).show();
            },
        },
    },
    
    //ฟังก์ชั่นสำหรับแสดงไดอะล็อกยืนยันการบันทึกข้อมูลในส่วนของการจัดการระบบ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้าหลัก
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
            if (_result == "Y")
            {
                if (_this.validateSave({
                        page: _param["page"]
                    }))
                    _this.getSave({
                        page: _param["page"]
                    });
            }
        });
    },

    //ฟังก์ชั่นสำหรับตรวจสอบความถูกต้องในการบันทึกข้อมูลในส่วนของการจัดการระบบ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้าหลัก
    validateSave: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this = null;
        var _validateResult = true;

        if (_param["page"] == Util.tut.pageSettingAccesstotheSystemEdit)    _this = this.accesstothesystem.sectionAddUpdate;

        if (_this != null)
            _validateResult = _this.validateSave();

        return _validateResult;
    },

    //ฟังก์ชั่นสำหรับนำข้อมูลในฟอร์มข้อมูลในส่วนของการจัดการระบบมาเตรียมสำหรับบันทึกข้อมูลลงฐานข้อมูล
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้าหลัก
    getSave: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

        var _this1;
        var _this2 = this;
        var _error;
        var _msg;
        var _i;
        var _value;
        var _valueSave = {};

        if (_param["page"] == Util.tut.pageSettingAccesstotheSystemEdit)
        {
            _this1 = _this2.accesstothesystem.sectionAddUpdate;

            var _startHour      = Util.getSelectionIsSelect({
                                    id: (_this1.idSectionAddUpdate + "-starthour"),
                                    type: "select",
                                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-starthour")
                                  });
            var _startMinute    =  Util.getSelectionIsSelect({
                                    id: (_this1.idSectionAddUpdate + "-startminute"),
                                    type: "select",
                                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-startminute")
                                  });
            var _startSecond    = Util.getSelectionIsSelect({
                                    id: (_this1.idSectionAddUpdate + "-startsecond"),
                                    type: "select",
                                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-startsecond")
                                  });
            var _endHour        = Util.getSelectionIsSelect({
                                    id: (_this1.idSectionAddUpdate + "-endhour"),
                                    type: "select",
                                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-endhour")
                                  });
            var _endMinute      = Util.getSelectionIsSelect({
                                    id: (_this1.idSectionAddUpdate + "-endminute"),
                                    type: "select",
                                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-endminute")
                                  });
            var _endSecond      = Util.getSelectionIsSelect({
                                    id: (_this1.idSectionAddUpdate + "-endsecond"),
                                    type: "select",
                                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-endsecond")
                                  });
            var _valueProgram;
            var _valueFacultyProgram = new Array;

            _value = Util.getValueSelectCheck({
                        id: (_this1.idSectionAddUpdate + "-faculty")
                     })
            
            for (_i = 0; _i < _value.length; _i++)
            {
                _valueProgram               = Util.getValueSelectCheck({
                                                id: (_this1.idSectionAddUpdate + "-program"),
                                                idParent: (".faculty-" + _value[_i])
                                              });
                _valueFacultyProgram[_i]    = (_value[_i] + (_valueProgram.length > 0 ? (":" + _valueProgram.join(",")) : ""));
            }
            
            _valueSave["startdate"]         = $("#" + _this1.idSectionAddUpdate + "-startdate").val();
            _valueSave["starttime"]         = (_startHour + ":" + _startMinute + ":" + _startSecond);
            _valueSave["enddate"]           = $("#" + _this1.idSectionAddUpdate + "-enddate").val();
            _valueSave["endtime"]           = (_endHour + ":" + _endMinute + ":" + _endSecond);
            _valueSave["yearentry"]         = (Util.getValueSelectCheck({
                                                id: (_this1.idSectionAddUpdate + "-yearattended")
                                               })).join(",");
            _valueSave["entrancetype"]      = (Util.getValueSelectCheck({
                                                id: (_this1.idSectionAddUpdate + "-entrancetype")
                                               })).join(",");
            _valueSave["facultyprogram"]    = _valueFacultyProgram.join(";");
            _valueSave["cancelledstatus"]   = Util.getSelectionIsSelect({
                                                id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                                                type:"checkbox",
                                                valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus")
                                              });
        }

        this.actionSave({
            page: _param["page"],
            data: _valueSave
        }, function (_resultSave, _resultValueSave) {
            if (_resultSave == true)
            {
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

    //ฟังก์ชั่นสำหรับบันทึกข้อมูลในส่วนของการจัดการระบบ
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

    //ฟังก์ชั่นสำหรับคัดลอกข้อมูลจากฟอร์มบันทึกข้อมูลไปที่ input type hidden ในส่วนของการจัดการข้อมูลหลัก
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //page      รับค่าชื่อหน้าหลัก
    //data      รับค่าข้อมูลหลังจากการบันทึกข้อมูล
    setValueDataRecorded: function (_param) {
        _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
        _param["data"] = (_param["data"] == undefined ? "" : _param["data"]);

        var _this1;
        var _this2 = this;
        var _value;

        if (_param["page"] == Util.tut.pageSettingAccesstotheSystemEdit)
        {
            _this1 = _this2.accesstothesystem.sectionAddUpdate;

            $("#" + _this1.idSectionAddUpdate + "-startdate-hidden").val($("#" + _this1.idSectionAddUpdate + "-startdate").val());
            $("#" + _this1.idSectionAddUpdate + "-starthour-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-starthour"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-starthour"),
                    valueFalse: "0"
                }));
            $("#" + _this1.idSectionAddUpdate + "-startminute-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-startminute"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-startminute"),
                    valueFalse: "0"
                }));
            $("#" + _this1.idSectionAddUpdate + "-startsecond-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-startsecond"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-startsecond"),
                    valueFalse: "0"
                }));
            $("#" + _this1.idSectionAddUpdate + "-enddate-hidden").val($("#" + _this1.idSectionAddUpdate + "-enddate").val());
            $("#" + _this1.idSectionAddUpdate + "-endhour-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-endhour"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-endhour"),
                    valueFalse: "0"
                }));
            $("#" + _this1.idSectionAddUpdate + "-endminute-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-endminute"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-endminute"),
                    valueFalse: "0"
                }));
            $("#" + _this1.idSectionAddUpdate + "-endsecond-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-endsecond"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this1.idSectionAddUpdate + "-endsecond"),
                    valueFalse: "0"
                }));
            $("#" + _this1.idSectionAddUpdate + "-yearattended-hidden").val(
                Util.getValueSelectCheck({
                    id: (_this1.idSectionAddUpdate + "-yearattended")
                }).join(","));
            $("#" + _this1.idSectionAddUpdate + "-entrancetype-hidden").val(
                Util.getValueSelectCheck({
                    id: (_this1.idSectionAddUpdate + "-entrancetype")
                }).join(","));

            var _valueProgram;
            var _valueFacultyProgram = new Array;

            _value = Util.getValueSelectCheck({
                        id: (_this1.idSectionAddUpdate + "-faculty")
                     });

            for (_i = 0; _i < _value.length; _i++)
            {
                _valueProgram               = Util.getValueSelectCheck({
                                                id: (_this1.idSectionAddUpdate + "-program"),
                                                idParent: (".faculty-" + _value[_i])
                                              });
                _valueFacultyProgram[_i]    = (_value[_i] + (_valueProgram.length > 0 ? (":" + _valueProgram.join(",")) : ""));
            }
            $("#" + _this1.idSectionAddUpdate + "-facultyprogram-hidden").val(_valueFacultyProgram.join(";"));
            $("#" + _this1.idSectionAddUpdate + "-cancelledstatus-hidden").val(
                Util.getSelectionIsSelect({
                    id: (_this1.idSectionAddUpdate + "-cancelledstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this1.idSectionAddUpdate + "-cancelledstatus")
                }));
        } 
    }
}
