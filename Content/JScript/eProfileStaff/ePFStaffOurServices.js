/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๙/๐๖/๒๕๕๙>
Modify date : <๑๒/๐๕/๒๕๖๔>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของบริการอื่น>
=============================================
*/

var ePFStaffOurServices = {
    exportstudentrecordsinformation: {
        idSectionMain: ePFStaffUtil.idSectionOurServicesExportStudentRecordsInformationMain.toLowerCase(),        
        idSectionProgress: ePFStaffUtil.idSectionOurServicesExportStudentRecordsInformationProgress.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.exportstudentrecordsinformation;
                
                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });
                Util.initCheck({
                    id: "select-root"
                });
                    
                $("#" + _this.idSectionMain + "-table .button .click-button").click(function () {
                    if ($(this).hasClass("button-exportselected") == true || $(this).hasClass("button-exportall") == true)
                        Util.tut.tpd.getProgress({
                            action: Util.tut.subjectSectionExport,
                            pageProgress: Util.tut.pageOurServicesExportStudentRecordsInformationProgress,
                            thisProgress: _this.sectionProgress,
                            idMain: _this.idSectionMain,
                            idProgress: _this.idSectionProgress,
                            option: $(this).attr("alt")
                        });
                });
                    
                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.exportstudentrecordsinformation;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            },
            initTable: function () {
                Util.tut.getDialogFormOnClick();
            }
        },
        sectionProgress: {
            initMain: function () {
                var _this1 = Util.tut.tos.exportstudentrecordsinformation;
                var _this2 = this;
            },
            resetMain: function () {
                var _this1 = Util.tut.tos.exportstudentrecordsinformation;
                var _this2 = this;
                
                Util.dialogMessageClose();
                Util.resetForm({
                    id: (_this1.idSectionProgress + "-form")
                });
            },
            validateProcess: function () {
                var _this1 = Util.tut.tos.exportstudentrecordsinformation;
                var _this2 = this;
                var _error = new Array();
                var _i = 0;

                return (_i > 0 ? false : true);
            },
            getValueProcess: function () {
                var _this1 = Util.tut.tos.exportstudentrecordsinformation;
                var _this2 = this;
                var _valueParamSearch = {}
                var _valueProcessResult = {};

                _valueParamSearch = JSON.stringify(Util.tut.tse.ourservices.exportstudentrecordsinformation.valueSearch());

                _valueProcessResult["paramsearch"] = _valueParamSearch;

                return _valueProcessResult;
            },
            getResultProcess: function (_param) {
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                var _this1 = Util.tut.tos.exportstudentrecordsinformation;
                var _this2 = this;
            }
        }
    },
    updatestudentmedicalscholarsprogram: {
        idSectionMain: ePFStaffUtil.idSectionOurServicesUpdateStudentMedicalScholarsProgramMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.updatestudentmedicalscholarsprogram;

                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });
                Util.initCheck({
                    id: "select-root"
                });
                
                $("#" + _this.idSectionMain + "-table .button .click-button").click(function () {
                    if ($(this).hasClass("button-updateselected") == true)
                        Util.tut.tpd.getProgress({
                            action: Util.tut.subjectSectionUpdate,
                            pageProgress: Util.tut.pageOurServicesUpdateStudentMedicalScholarsProgramProgress,
                            pagePreview: Util.tut.pageOurServicesUpdateStudentMedicalScholarsProgramPreview,
                            thisProgress: _this.sectionProgress,
                            thisPreview: _this.sectionPreview,
                            idMain: _this.idSectionMain,
                            idProgress: _this.sectionProgress.idSectionProgress,
                            idPreview: _this.sectionPreview.idSectionPreview,
                            option: $(this).attr("alt")
                        });
                });

                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.updatestudentmedicalscholarsprogram;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            },
            initTable: function () {
                Util.tut.getDialogFormOnClick();
            }
        },
        sectionProgress: {
            idSectionProgress: ePFStaffUtil.idSectionOurServicesUpdateStudentMedicalScholarsProgramProgress.toLowerCase(),
            initMain: function () {
                var _this1 = Util.tut.tos.updatestudentmedicalscholarsprogram;
                var _this2 = this;

                Util.initCheck({
                    id: (_this2.idSectionProgress + "-joinprogramstatus")
                });
                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-startsemester"),
                    width: 190,
                    height: 29
                });
                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-startyear"),
                    width: 190,
                    height: 29
                });
                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-endsemester"),
                    width: 190,
                    height: 29
                });
                Util.initCombobox({
                    id: ("#" + _this2.idSectionProgress + "-endyear"),
                    width: 190,
                    height: 29
                });
                Util.initCalendar({
                    id: ("#" + _this2.idSectionProgress + "-resigndate"),
                    yearRange: "-7:+7"
                });

                $(".checkbox").on("ifChecked ifUnchecked", function () {
                    if ($(this).attr("name") == (_this2.idSectionProgress + "-joinprogramstatus"))
                        Util.setInputOtherOnCheck({
                            id: (_this2.idSectionProgress + "-joinprogramstatus"),
                            value: "Y",
                            idComboboxOther: ("#" + _this2.idSectionProgress + "-startsemester, #" + _this2.idSectionProgress + "-startyear, #" + _this2.idSectionProgress + "-endsemester, #" + _this2.idSectionProgress + "-endyear"),
                            idTextboxOther: ("#" + _this2.idSectionProgress + "-resigndate")
                        });
                });
            },
            resetMain: function () {
                var _this1 = Util.tut.tos.updatestudentmedicalscholarsprogram;
                var _this2 = this;
                var _idTable = (_this1.idSectionMain + "-table");
                var _valueSelected = "";
                var _dr = "";
                var _html = "";
                var _studentId;
                var _fullNameTH;
                var _program;
                var _joinProgramStatus;
                var _startSemester;
                var _startYear;
                var _endSemester;
                var _endYear;
                var _resignDate;
                var _reset = true;
                var _i = 0;

                Util.dialogMessageClose();
                Util.resetForm({
                    id: (_this2.idSectionProgress + "-form")
                });
                
                _valueSelected = Util.getValueSelectCheck({
                    id: "select-child",
                    idParent: ("#" + _idTable)
                }).join("|");

                _dr = _valueSelected.split("|");
                _reset = (_dr.length > 1 ? true : false);

                _html += "<div class='list-row'>";

                for (_i = 0; _i < _dr.length; _i++) {
                    _studentId = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col3 .table-col-msg div").html();
                    _fullNameTH = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col4 .table-col-msg div").html();
                    _program = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col5 .table-col-msg div").html();
                    _joinProgramStatus = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col10 .table-col-msg div").html();
                    _startSemester = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col11 .table-col-msg div").html().substring(0, 1);
                    _startYear = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col11 .table-col-msg div").html().substring(4, 8);
                    _endSemester = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col12 .table-col-msg div").html().substring(0, 1);
                    _endYear = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col12 .table-col-msg div").html().substring(4, 8);
                    _resignDate = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col13 .table-col-msg div").html();

                    _html += "<div class='list-col'>" +
                             "  <div class='th-label'>" + _studentId + " " + _fullNameTH + " ( " + _program + " )" + "</div>" +
                             "</div>";
                }

                _html += "</div>";

                $("#" + _this2.idSectionProgress + "-student-content .list .list-content").html(_html);

                Util.checkSetValue({
                    id: (_this2.idSectionProgress + "-joinprogramstatus"),
                    value: (_reset == true ? "N" : _joinProgramStatus)
                });
                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-startsemester"),
                    value: (_reset == true ? "0" : _startSemester)
                });
                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-startyear"),
                    value: (_reset == true ? "0" : _startYear)
                });
                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-endsemester"),
                    value: (_reset == true ? "0" : _endSemester)
                });
                Util.comboboxSetValue({
                    id: ("#" + _this2.idSectionProgress + "-endyear"),
                    value: (_reset == true ? "0" : _endYear)
                });
                $("#" + _this2.idSectionProgress + "-resigndate").val(_reset == true ? "" : _resignDate);

                Util.setInputOtherOnCheck({
                    id: (_this2.idSectionProgress + "-joinprogramstatus"),
                    value: "Y",
                    idComboboxOther: ("#" + _this2.idSectionProgress + "-startsemester, #" + _this2.idSectionProgress + "-startyear, #" + _this2.idSectionProgress + "-endsemester, #" + _this2.idSectionProgress + "-endyear"),
                    idTextboxOther: ("#" + _this2.idSectionProgress + "-resigndate")
                });
            },
            validateProcess: function () {
                var _this1 = Util.tut.tos.updatestudentmedicalscholarsprogram;
                var _this2 = this;
                var _error = new Array();
                var _idTable = (_this1.idSectionMain + "-table");
                var _valueSelected = "";
                var _dr = "";
                var _yearEntry;
                var _valueJoinProgramStatus;
                var _valueStartSemester;
                var _valueStartYear;
                var _valueEndSemester;
                var _valueEndYear;
                var _i = 0;
                var _j = 0;
                var _exit = false;

                _valueJoinProgramStatus = Util.checkGetValue(_this2.idSectionProgress + "-joinprogramstatus");
                _valueStartSemester = Util.comboboxGetValue("#" + _this2.idSectionProgress + "-startsemester");
                _valueStartYear = Util.comboboxGetValue("#" + _this2.idSectionProgress + "-startyear");
                _valueEndSemester = Util.comboboxGetValue("#" + _this2.idSectionProgress + "-endsemester");
                _valueEndYear = Util.comboboxGetValue("#" + _this2.idSectionProgress + "-endyear");

                if (_valueJoinProgramStatus == "Y" && _valueStartSemester == "0" && _valueStartYear != "0") {
                    _error[_i] = "กรุณาเลือกภาคเรียนที่ไป;Please select start semester.;";
                    _i++;
                }

                if (_valueJoinProgramStatus == "Y" && _valueStartSemester != "0" && _valueStartYear == "0") {
                    _error[_i] = "กรุณาเลือกปีที่ไป;Please select start year.;";
                    _i++;
                }

                if (_valueJoinProgramStatus == "Y" && _valueEndSemester == "0" && _valueEndYear != "0") {
                    _error[_i] = "กรุณาเลือกภาคเรียนที่กลับ;Please select end semester.;";
                    _i++;
                }

                if (_valueJoinProgramStatus == "Y" && _valueEndSemester != "0" && _valueEndYear == "0") {
                    _error[_i] = "กรุณาเลือกปีที่กลับ;Please select end year.;";
                    _i++;
                }

                if (_valueJoinProgramStatus == "Y" && _valueStartSemester == "0" && _valueStartYear == "0" && _valueEndSemester != "0" && _valueEndYear != "0") {
                    _error[_i] = "กรุณาเลือกภาค / ปีที่ไป;Please select start semester / year.;";
                    _i++;
                }

                if (_valueJoinProgramStatus == "Y" && _valueStartYear != "0") {
                    _valueSelected = Util.getValueSelectCheck({
                        id: "select-child",
                        idParent: ("#" + _idTable)
                    }).join("|");

                    _dr = _valueSelected.split("|");

                    for (_j = 0; _j < _dr.length; _j++) {
                        _yearEntry = $("#" + _idTable + " #table-row-id-" + _dr[_j] + " .table-col6 .table-col-msg div").html();

                        if (_valueStartYear < _yearEntry) {
                            _exit = true;
                            _error[_i] = "กรุณาเลือกปีที่ไปให้มากกว่าหรือเท่ากับปีที่เข้าศึกษา;Please select start year greater than or equal year attended.;";
                            _i++;
                        }

                        if (_exit == true)
                            break;
                    }
                }

                if (_valueJoinProgramStatus == "Y" && _valueStartYear != "0" && _valueEndYear != "0" && _valueStartYear > _valueEndYear) {
                    _error[_i] = "กรุณาเลือกปีที่ไปให้น้อยกว่าหรือเท่ากับปีที่กลับ;Please select start year less than or equal end year.;";
                    _i++;
                }

                if (_valueJoinProgramStatus == "Y" && _valueStartSemester != "0" && _valueStartYear != "0" && _valueEndSemester != "0" && _valueEndYear != "0" && _valueStartYear == _valueEndYear && _valueStartSemester > _valueEndSemester) {
                    _error[_i] = "กรุณาเลือกภาคเรียนที่ไปให้น้อยกว่าหรือเท่ากับภาคเรียนที่กลับ;Please select start semester less than or equal end semester.;";
                    _i++;
                }

                Util.dialogListMessageError({
                    content: _error
                });

                return (_i > 0 ? false : true);
            },
            getValueProcess: function () {
                var _this1 = Util.tut.tos.updatestudentmedicalscholarsprogram;
                var _this2 = this;
                var _valueParamSearch = {}
                var _valueJoinProgramStatus = "";
                var _valueStartSemester = "";
                var _valueStartYear = "";
                var _valueEndSemester = "";
                var _valueEndYear = "";
                var _valueResignDate = "";
                var _valueProcessResult = {};

                _valueParamSearch = JSON.stringify(Util.tut.tse.ourservices.updatestudentmedicalscholarsprogram.valueSearch());
                _valueJoinProgramStatus = Util.getSelectionIsSelect({
                    id: (_this2.idSectionProgress + "-joinprogramstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_this2.idSectionProgress + "-joinprogramstatus"),
                    valueFalse: "N"
                });
                _valueStartSemester = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-startsemester"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-startsemester")
                });
                _valueStartYear = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-startyear"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-startyear")
                });
                _valueEndSemester = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-endsemester"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-endsemester")
                });
                _valueEndYear = Util.getSelectionIsSelect({
                    id: ("#" + _this2.idSectionProgress + "-endyear"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _this2.idSectionProgress + "-endyear")
                });
                _valueResignDate = $("#" + _this2.idSectionProgress + "-resigndate").val();
                _valueUpdateReason = (_valueJoinProgramStatus == "Y" ? "นักศึกษาเข้าโครงการผลิตอาจารย์แพทย์" : "");
                
                _valueProcessResult["paramsearch"] = _valueParamSearch;
                _valueProcessResult["valuejoinprogramstatus"] = _valueJoinProgramStatus;
                _valueProcessResult["valuestartsemester"] = _valueStartSemester;
                _valueProcessResult["valuestartyear"] = _valueStartYear;
                _valueProcessResult["valueendsemester"] = _valueEndSemester;
                _valueProcessResult["valueendyear"] = _valueEndYear;
                _valueProcessResult["valueresigndate"] = _valueResignDate;
                _valueProcessResult["valueupdatereason"] = _valueUpdateReason;

                return _valueProcessResult;
            },
            getResultProcess: function (_param) {
                _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                var _this1 = Util.tut.tos.updatestudentmedicalscholarsprogram;
                var _this2 = this;
                var _detailComplete = _param["resultValueProcess"].DetailComplete;
                var _idTable = (_this1.idSectionMain + "-table");
                var _idTableRow;
                var _valueArray = _detailComplete.split(",");
                var _i;

                for (_i = 0; _i < _valueArray.length; _i++) {
                    _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueArray[_i]);

                    if ($("#" + _idTableRow).length > 0) {
                        $("#" + _idTableRow + " .table-col-joinprogramstatus").html(_param["dataProcess"]["valuejoinprogramstatus"]);
                        $("#" + _idTableRow + " .table-col-startsemesteryear").html(_param["dataProcess"]["valuestartsemester"].length > 0 && _param["dataProcess"]["valuestartyear"].length > 0 ? (_param["dataProcess"]["valuestartsemester"] + " / " + _param["dataProcess"]["valuestartyear"]) : "");
                        $("#" + _idTableRow + " .table-col-endsemesteryear").html(_param["dataProcess"]["valueendsemester"].length > 0 && _param["dataProcess"]["valueendyear"].length > 0 ? (_param["dataProcess"]["valueendsemester"] + " / " + _param["dataProcess"]["valueendyear"]) : "");
                        $("#" + _idTableRow + " .table-col-resigndate").html(_param["dataProcess"]["valueresigndate"]);
                    }
                }
            }
        },
        sectionPreview: {
            idSectionPreview: ePFStaffUtil.idSectionOurServicesUpdateStudentMedicalScholarsProgramPreview.toLowerCase(),
            getList: function (_param) {
                _param["idProgress"] = (_param["idProgress"] == undefined ? null : _param["idProgress"]);
                _param["idPreview"] = (_param["idPreview"] == undefined ? null : _param["idPreview"]);
                _param["valueSelected"] = (_param["valueSelected"] == undefined ? "" : _param["valueSelected"]);

                var _this1 = Util.tut.tos.updatestudentmedicalscholarsprogram;
                var _this2 = this;
                var _idTable = (_this1.idSectionMain + "-table");
                var _dr = _param["valueSelected"].split("|")
                var _html = "";
                var _highlight;
                var _no;
                var _studentId;
                var _fullNameTH;
                var _joinProgramStatusOld;
                var _joinProgramStatusNew;
                var _startSemesterOld;
                var _startSemesterNew;
                var _startYearOld;
                var _startYearNew;
                var _endSemesterOld;
                var _endSemesterNew;
                var _endYearOld;
                var _endYearNew;
                var _resignDateOld;
                var _resignDateNew;
                var _i = 0;

                _joinProgramStatusNew = Util.getSelectionIsSelect({
                    id: (_param["idProgress"] + "-joinprogramstatus"),
                    type: "checkbox",
                    valueTrue: Util.checkGetValue(_param["idProgress"] + "-joinprogramstatus"),
                    valueFalse: "N"
                });
                _startSemesterNew = Util.getSelectionIsSelect({
                    id: ("#" + _param["idProgress"] + "-startsemester"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-startsemester")
                });
                _startYearNew = Util.getSelectionIsSelect({
                    id: ("#" + _param["idProgress"] + "-startyear"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-startyear")
                });
                _endSemesterNew = Util.getSelectionIsSelect({
                    id: ("#" + _param["idProgress"] + "-endsemester"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-endsemester")
                });
                _endYearNew = Util.getSelectionIsSelect({
                    id: ("#" + _param["idProgress"] + "-endyear"),
                    type: "select",
                    valueTrue: Util.comboboxGetValue("#" + _param["idProgress"] + "-endyear")
                });
                _resignDateNew = $("#" + _param["idProgress"] + "-resigndate").val();

                $("#" + _param["idPreview"] + "-table .table-recordcount .recordcount-search").html(_dr.length);

                for (_i = 0; _i < _dr.length; _i++) {
                    _highlight = ((_i % 2) == 0 ? " highlight-style1" : " highlight-style2");
                    _no = (_i + 1);
                    _studentId = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col3 .table-col-msg div").html();
                    _fullNameTH = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col4 .table-col-msg div").html();
                    _joinProgramStatusOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col10 .table-col-msg div").html();
                    _startSemesterOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col11 .table-col-msg div").html().substring(0, 1);
                    _startYearOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col11 .table-col-msg div").html().substring(4, 8);
                    _endSemesterOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col12 .table-col-msg div").html().substring(0, 1);
                    _endYearOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col12 .table-col-msg div").html().substring(4, 8);
                    _resignDateOld = $("#" + _idTable + " #table-row-id-" + _dr[_i] + " .table-col13 .table-col-msg div").html();

                    _html += "<div class='table-row" + _highlight + "'>" +
                             "  <div class='table-col table-col-width-fixed table-col1'><div class='table-col-msg'><div class='th-label'>" + _no + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col2'><div class='table-col-msg'><div class='th-label'>" + _studentId + "</div></div></div>" +
                             "  <div class='table-col table-col-width-dynamic table-col3'><div class='table-col-msg'><div class='th-label'>" + _fullNameTH + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col4'><div class='table-col-msg'><div class='th-label'>" + _joinProgramStatusNew + " ( " + _joinProgramStatusOld + " )" + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col5'><div class='table-col-msg'><div class='th-label'>" + (_startSemesterNew.length > 0 && _startYearNew.length > 0 ? (_startSemesterNew + " / " + _startYearNew) : "") + " ( " + (_startSemesterOld.length > 0 && _startYearOld.length > 0 ? (_startSemesterOld + " / " + _startYearOld) : "") + " )" + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col6'><div class='table-col-msg'><div class='th-label'>" + (_endSemesterNew.length > 0 && _endYearNew.length > 0 ? (_endSemesterNew + " / " + _endYearNew) : "") + " ( " + (_endSemesterOld.length > 0 && _endYearOld.length > 0 ? (_endSemesterOld + " / " + _endYearOld) : "") + " )" + "</div></div></div>" +
                             "  <div class='table-col table-col-width-fixed table-col7'><div class='table-col-msg'><div class='th-label'>" + _resignDateNew + " ( " + _resignDateOld + " )" + "</div></div></div>" +
                             "</div>"
                }

                $("#" + _param["idPreview"] + "-table .table-list .table-grid").html(_html);
            }
        }
    },
    summarynumberofstudent: {
        idSectionMain: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentMain.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.summarynumberofstudent;

                Util.initTabChartTable({
                    this: _this,
                    section: Util.tut.subjectSectionOurServices
                }, function (_result) {
                });
            }
        },
        viewchart: {
            idSectionMain: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentViewChartMain.toLowerCase(),
            sectionMain: {
                initMain: function () {
                }
            }
        },
        viewtable: {
            idSectionMain: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentViewTableMain.toLowerCase(),
            idSectionLevel1Main: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentLevel1ViewTableMain.toLowerCase(),
            idSectionLevel2Main: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentLevel2ViewTableMain.toLowerCase(),
            subjectLevel: "",
            orderLevel: "",
            gender: "",
            studentStatusGroup: "",
            degreeLevel: "",
            yearEntry: "",
            entranceType: "",
            class: "",
            nationality: "",
            faculty: "",
            program: "",
            sectionMain: {
                initMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain : _param["page"]);

                    var _this1 = Util.tut.tos.summarynumberofstudent;
                    var _this2 = _this1.viewtable;
                    var _action;
                    var _pageProgress;
                    var _thisProgress;
                    var _idMain;
                    var _idProgress;

                    if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain) {
                        _action = Util.tut.subjectSectionExport;
                        _pageProgress = Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableProgress;
                        _thisProgress = _this2.sectionProgress.level1;
                        _idMain = _this2.idSectionLevel1Main;
                        _idProgress = _this2.sectionProgress.level1.idSectionProgress;                        
                    }

                    if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel2ViewTableMain) {                        
                        _action = Util.tut.subjectSectionExport;
                        _pageProgress = Util.tut.pageOurServicesSummaryNumberOfStudentLevel2ViewTableProgress;
                        _thisProgress = _this2.sectionProgress.level2;
                        _idMain = _this2.idSectionLevel2Main;
                        _idProgress = _this2.sectionProgress.level2.idSectionProgress;
                    }
                    
                    $("#" + _idMain + "-table .button .click-button").click(function () {
                        if ($(this).hasClass("button-exportall") == true)
                            Util.tut.tpd.getProgress({
                                action: _action,
                                pageProgress: _pageProgress,
                                thisProgress: _thisProgress,
                                idMain: _idMain,
                                idProgress: _idProgress,
                                option: $(this).attr("alt")
                            });
                    });
                    
                    this.resetMain({
                        page: _param["page"]
                    });                    
                },
                resetMain: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain : _param["page"]);

                    var _this1 = Util.tut.tos.summarynumberofstudent;
                    var _this2 = _this1.viewtable;
                    var _idSectionOld;
                    var _idSectionNew;
                    var _objTableOld;
                    var _objTableNew;
                    var _subject;

                    if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain) {
                        _idSectionOld = "";
                        _idSectionNew = _this2.idSectionLevel1Main;
                        _subject = "";
                    }
                    
                    if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel2ViewTableMain) {
                        _idSectionOld = _this2.idSectionLevel1Main;
                        _idSectionNew = _this2.idSectionLevel2Main;
                        _subject = _this2.subjectLevel;
                    }

                    _objTableOld = ("#" + _idSectionOld + "-table");
                    _objTableNew = ("#" + _idSectionNew + "-table");

                    if (_idSectionOld.length > 0) {
                        $(_objTableOld).hide();
                        $(_objTableNew + " .table-subject").html(_subject);
                        $(_objTableNew).show();

                        $(_objTableNew + " .link-goback").click(function () {
                            $(_objTableNew + " .table-subject").html("");
                            $(_objTableNew + " .table-recordcount .recordcountprimary-search").html("");
                            $(_objTableNew + " .table-recordcount .recordcountsecondary-search").html("");
                            $(_objTableNew + " .table-recordcount .recordcountprimary-all").html("");
                            $(_objTableNew + " .table-recordcount .recordcountsecondary-all").html("");
                            $(_objTableNew + " .table-title .contentbody-left").hide();
                            $(_objTableNew + " .table-list").html("");
                            $(_objTableNew + " .table-navpage").html("");
                            $(_objTableNew).hide();
                            $(_objTableOld).show();

                            Util.setTableLayout();
                        });
                    }
                    else
                        $(_objTableNew + " .link-goback").hide();
                },
                initTable: function (_param) {
                    _param["page"] = (_param["page"] == undefined ? Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain : _param["page"]);                                        
                    
                    var _this1 = Util.tut.tos.summarynumberofstudent;
                    var _this2 = _this1.viewtable;
                    var _idSection;
                    var _page;
                    var _orderLevel;
                    var _valueArray;

                    if (_param["page"] == Util.tut.pageOurServicesSummaryNumberOfStudentLevel1ViewTableMain) {
                        _idSection = _this2.idSectionLevel1Main;

                        $("#" + _idSection + "-table .table-grid .second-level, " +
                          "#" + _idSection + "-table .table-grid .third-level, " +
                          "#" + _idSection + "-table .table-grid .last-level").hide();
                        
                        $("#" + _idSection + "-table .table-grid .first-level .table-col1, " +
                          "#" + _idSection + "-table .table-grid .second-level .table-col1, " +
                          "#" + _idSection + "-table .table-grid .third-level .table-col1").click(function () {
                            var _idContent = $(this).attr("id");
                            var _objCollapse = ("#" + _idContent + ".table-col .collapse");
                            var _objTableRow = ("#" + _idSection + "-table .table-grid .table-row." + _idContent);

                            if ($(_objCollapse).html() == "+") {
                                $(_objCollapse).html("-");
                                $(_objTableRow).show();
                            }
                            else {
                                $(_objCollapse).html("+");
                                $(_objTableRow).hide();
                                $("#" + _idSection + "-table .table-grid .table-row." + $(this).attr("alt") + " .table-col .collapse").html("+");
                                $("#" + _idSection + "-table .table-grid .table-row." + $(this).attr("alt") + " .table-col .last-collapse").html("-");
                                $("#" + _idSection + "-table .table-grid .table-row." + $(this).attr("alt")).hide();
                            }
                        });

                        $("#" + _idSection + "-table .table-grid .link-click").click(function () {
                            if ($(this).hasClass("link-" + Util.tut.subjectSectionSummaryNumberOfStudentLevel2ViewTable.toLowerCase()) == true) {
                                _valueArray = ($(this).attr("alt")).split(",");
                                _page = _valueArray[0];
                                _this2.subjectLevel = "<div class='th-label'>นักศึกษา{th}</div><div class='en-label'>Student {en}</div>"
                                _orderLevel = _valueArray[1];
                                _this2.orderLevel = _valueArray[2];
                                _this2.gender = _valueArray[3];
                                _this2.studentStatusGroup = "";
                                _this2.degreeLevel = "";
                                _this2.yearEntry = "";
                                _this2.entranceType = "";
                                _this2.class = "";
                                _this2.nationality = "";
                                _this2.faculty = "";
                                _this2.program = "";

                                if (_this2.orderLevel == "StudentStatus" ||
                                    _this2.orderLevel == "StudentStatus->YearAttended" ||
                                    _this2.orderLevel == "StudentStatus->YearAttended->Faculty" ||
                                    _this2.orderLevel == "StudentStatus->YearAttended->Faculty->Program")
                                    _this2.studentStatusGroup = _valueArray[4];

                                if (_this2.orderLevel == "Degree" ||
                                    _this2.orderLevel == "Degree->YearAttended" ||
                                    _this2.orderLevel == "Degree->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Degree->YearAttended->Faculty->Program")
                                    _this2.degreeLevel = _valueArray[4];

                                if (_this2.orderLevel == "YearAttended" ||
                                    _this2.orderLevel == "YearAttended->Faculty" ||
                                    _this2.orderLevel == "YearAttended->Faculty->Program")
                                    _this2.yearEntry = _valueArray[4];

                                if (_this2.orderLevel == "AdmissionType" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended->Faculty" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended->Faculty->Program")
                                    _this2.entranceType = _valueArray[4];
                                
                                if (_this2.orderLevel == "Class" ||
                                    _this2.orderLevel == "Class->YearAttended" ||
                                    _this2.orderLevel == "Class->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Class->YearAttended->Faculty->Program")
                                    _this2.class = _valueArray[4];

                                if (_this2.orderLevel == "Nationality" ||
                                    _this2.orderLevel == "Nationality->YearAttended" ||
                                    _this2.orderLevel == "Nationality->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Nationality->YearAttended->Faculty->Program") 
                                    _this2.nationality = _valueArray[4];
                                
                                if (_this2.orderLevel == "StudentStatus->YearAttended" ||
                                    _this2.orderLevel == "StudentStatus->YearAttended->Faculty" ||
                                    _this2.orderLevel == "StudentStatus->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Degree->YearAttended" ||
                                    _this2.orderLevel == "Degree->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Degree->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended->Faculty" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Class->YearAttended" ||
                                    _this2.orderLevel == "Class->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Class->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Nationality->YearAttended" ||
                                    _this2.orderLevel == "Nationality->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Nationality->YearAttended->Faculty->Program")
                                    _this2.yearEntry = _valueArray[7];
                            
                                if (_this2.orderLevel == "YearAttended->Faculty" ||
                                    _this2.orderLevel == "YearAttended->Faculty->Program")
                                    _this2.faculty = _valueArray[7];

                                if (_this2.orderLevel == "StudentStatus->YearAttended->Faculty" ||
                                    _this2.orderLevel == "StudentStatus->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Degree->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Degree->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended->Faculty" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Class->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Class->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Nationality->YearAttended->Faculty" ||
                                    _this2.orderLevel == "Nationality->YearAttended->Faculty->Program")
                                    _this2.faculty = _valueArray[10];

                                if (_this2.orderLevel == "YearAttended->Faculty->Program")
                                    _this2.program = _valueArray[10];

                                if (_this2.orderLevel == "StudentStatus->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Degree->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "AdmissionType->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Class->YearAttended->Faculty->Program" ||
                                    _this2.orderLevel == "Nationality->YearAttended->Faculty->Program")
                                    _this2.program = _valueArray[13];

                                if (_this2.gender == "M") {
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{th}", "ชาย{th}");
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{en}", "Male{en}");
                                }

                                if (_this2.gender == "F") {
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{th}", "หญิง{th}");
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{en}", "Female{en}");
                                }
                                
                                if (_orderLevel == "ZeroLevel") {
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{th}", "");
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{en}", "");
                                }

                                if (_orderLevel == "FirstLevel") {
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{th}", (", " + _valueArray[5]));
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{en}", (", " + _valueArray[6]));
                                }

                                if (_orderLevel == "SecondLevel") {
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{th}", (", " + _valueArray[5] + ", " + _valueArray[8]));
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{en}", (", " + _valueArray[6] + ", " + _valueArray[9]));
                                }

                                if (_orderLevel == "ThirdLevel") {
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{th}", (", " + _valueArray[5] + ", " + _valueArray[8] + ", " + _valueArray[11]));
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{en}", (", " + _valueArray[6] + ", " + _valueArray[9] + ", " + _valueArray[12]));                                    
                                }

                                if (_orderLevel == "LastLevel") {
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{th}",
                                        ((_valueArray[5]  != undefined && _valueArray[5]  != "" ? (", " + _valueArray[5]) : "") +
                                         (_valueArray[8]  != undefined && _valueArray[8]  != "" ? (", " + _valueArray[8]) : "") +
                                         (_valueArray[11] != undefined && _valueArray[11] != "" ? (", " + _valueArray[11]) : "") +
                                         (_valueArray[14] != undefined && _valueArray[14] != "" ? (", " + _valueArray[14]) : "")));
                                    _this2.subjectLevel = _this2.subjectLevel.replace("{en}",
                                        ((_valueArray[6]  != undefined && _valueArray[6]  != "" ? (", " + _valueArray[6]) : "") +
                                         (_valueArray[9]  != undefined && _valueArray[9]  != "" ? (", " + _valueArray[9]) : "") +
                                         (_valueArray[12] != undefined && _valueArray[12] != "" ? (", " + _valueArray[12]) : "") +
                                         (_valueArray[15] != undefined && _valueArray[15] != "" ? (", " + _valueArray[15]) : "")));
                                }

                                Util.tut.tse.getSearch({
                                    page: _page
                                });
                            }
                        });
                    }

                    Util.tut.getDialogFormOnClick();
                }
            },
            sectionProgress: {
                level1: {
                    idSectionProgress: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentLevel1ViewTableProgress.toLowerCase(),
                    initMain: function () {
                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = this;
                    },
                    resetMain: function () {
                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = _this1.viewtable;
                        var _this3 = this;

                        $("#" + _this3.idSectionProgress + "-total").html($("#" + _this2.idSectionLevel1Main + "-table .table-grid .table-row").length.toLocaleString());
                    },
                    validateProcess: function () {
                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = this;
                        var _error = new Array();
                        var _i = 0;

                        return (_i > 0 ? false : true);
                    },
                    getValueProcess: function () {
                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = this;
                        var _valueParamSearch = {}
                        var _valueProcessResult = {};

                        _valueParamSearch = JSON.stringify(Util.tut.tse.ourservices.summarynumberofstudent.valueSearch());

                        _valueProcessResult["paramsearch"] = _valueParamSearch;

                        return _valueProcessResult;
                    },
                    getResultProcess: function (_param) {
                        _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                        _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = this;
                    }
                },
                level2: {
                    idSectionProgress: ePFStaffUtil.idSectionOurServicesSummaryNumberOfStudentLevel2ViewTableProgress.toLowerCase(),
                    initMain: function () {
                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = this;
                    },
                    resetMain: function () {
                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = _this1.viewtable;
                        var _this3 = this;

                        $("#" + _this3.idSectionProgress + "-byitems-content .progresstext .th-label").html($("#" + _this2.idSectionLevel2Main + "-table .table-title .table-subject .th-label").html());
                        $("#" + _this3.idSectionProgress + "-byitems-content .progresstext .en-label").html($("#" + _this2.idSectionLevel2Main + "-table .table-title .table-subject .en-label").html());
                    },
                    validateProcess: function () {
                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = this;
                        var _error = new Array();
                        var _i = 0;

                        return (_i > 0 ? false : true);
                    },
                    getValueProcess: function () {
                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = _this1.viewtable;
                        var _this3 = this;
                        var _valueParamSearch = {}
                        var _valueProcessResult = {};

                        _valueParamSearch = Util.tut.tse.ourservices.summarynumberofstudent.valueSearch();
                        _valueParamSearch["gender"] = _this2.gender;
                        _valueParamSearch["studentstatusgroup"] = _this2.studentStatusGroup
                        _valueParamSearch["degreelevel"] = (_this2.degreeLevel.length > 0 ? _this2.degreeLevel : _valueParamSearch["degreelevel"]);
                        _valueParamSearch["yearentry"] = (_this2.yearEntry.length > 0 ? _this2.yearEntry : _valueParamSearch["yearentry"]);
                        _valueParamSearch["entrancetype"] = (_this2.entranceType.length > 0 ? _this2.entranceType : _valueParamSearch["entrancetype"]);
                        _valueParamSearch["class"] = (_this2.class.length > 0 ? _this2.class : _valueParamSearch["class"]);
                        _valueParamSearch["nationality"] = _this2.nationality;
                        _valueParamSearch["faculty"] = (_this2.faculty.length > 0 ? _this2.faculty : _valueParamSearch["faculty"]);
                        _valueParamSearch["program"] = (_this2.program.length > 0 ? _this2.program : _valueParamSearch["program"]);
                        _valueParamSearch = JSON.stringify(_valueParamSearch);
                        _valueProcessResult["paramsearch"] = _valueParamSearch;

                        return _valueProcessResult;
                    },
                    getResultProcess: function (_param) {
                        _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);
                        _param["dataProcess"] = (_param["dataProcess"] == undefined || _param["dataProcess"] == "" ? null : _param["dataProcess"]);

                        var _this1 = Util.tut.tos.summarynumberofstudent;
                        var _this2 = this;
                    }
                }
            }
        }
    },
    transactionlogstudentrecords: {
        idSectionMain: ePFStaffUtil.idSectionOurServicesTransactionLogStudentRecordsMain.toLowerCase(),
        idSectionView: ePFStaffUtil.idSectionOurServicesTransactionLogStudentRecordsView.toLowerCase(),
        sectionMain: {
            initMain: function () {
                var _this = Util.tut.tos.transactionlogstudentrecords;
                
                Util.initCombobox({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    width: 103,
                    height: 25
                });
                    
                this.resetMain();
            },
            resetMain: function () {
                var _this = Util.tut.tos.transactionlogstudentrecords;

                Util.comboboxSetValue({
                    id: ("#" + _this.idSectionMain + "-rowperpage"),
                    value: $("#" + _this.idSectionMain + "-rowperpage-hidden").val()
                });
            },
            initTable: function () {
                Util.tut.getDialogFormOnClick();
            }
        },
        sectionView: {
            getFrm: function (_param) {
                _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);

                var _this1 = Util.tut.tos.transactionlogstudentrecords;
                var _this2 = this;
                var _data = "";
                var _idActive = "table-row-id-" + _param["id"];

                Util.loadForm({
                    index: 1,
                    name: Util.tut.pageOurServicesTransactionLogStudentRecordsView,
                    dialog: true,
                    data: _param["id"],
                    idActive: _idActive
                }, function (_result, _e) {
                    if (_e != "close") {                        
                        $("#" + Util.dialogForm + "1").height($(window).height() - 60);
                        $("#" + Util.dialogForm + "1").dialog("option", "position", {
                            my: "center",
                            at: "center",
                            of: window
                        });
                        _this2.initMain();
                        _this2.initTable({
                            id: (_this1.idSectionView + Util.tut.subjectSectionStudentRecords.toLowerCase())
                        });
                    }
                });
            },
            initMain: function () {
                var _this1 = Util.tut.tos.transactionlogstudentrecords;
                var _this2 = _this1.sectionView;

                Util.initTab({
                    id: ("#" + _this1.idSectionView + "-form .tabbar-content"),
                    idContent: ("#" + _this1.idSectionView + "-form .tabbar-form-content"),
                    classActive: "tab-active",
                    classNoActive: "tab-noactive"
                }, function (_result) {
                    $("#" + _result).html("");
                    
                    Util.loadForm({
                        name: $("#" + _result).attr("alt"),
                        data: $("#" + _this1.idSectionView + "-personid-hidden").val(),
                        showPreloadingInline: true,
                        idPreloadingInline: _result,
                        id: _result
                    }, function () {
                        _this2.resetMain({
                            id: _result
                        });
                        _this2.initTable({
                            id: _result
                        });
                    });
                });

                this.resetMain({
                    id: (_this1.idSectionView + Util.tut.subjectSectionStudentRecords.toLowerCase())
                })
            },
            resetMain: function (_param) {
                _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);

                var _this = Util.tut.tos.transactionlogstudentrecords;

                $("#" + _param["id"] + " .table .table-list").css({
                    "height": (($("#" + Util.dialogForm + "1").height() -
                                $("#" + _this.idSectionView + "-form .form-layout").height() -
                                $("#" + _this.idSectionView + "-form .tabbar .tabbar-layout").height() -
                                $("#" + _param["id"] + " .table .table-freeze").height()) + "px")
                });

                Util.setTableLayoutWidthDynamic({
                    id: (_param["id"] + " .table")
                });
            },
            initTable: function (_param) {
                _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);

                var _this = Util.tut.tos.transactionlogstudentrecords;

                Util.initTableLayoutWidthDynamic({
                    id: (_param["id"] + " .table")
                });
                Util.tut.getDialogFormOnClick();
            }   
        }
    }
}