/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๐๕/๐๘/๒๕๕๘>
Modify date : <๐๓/๐๖/๒๕๕๙>
Description : <รวมรวบฟังก์ชั่นใช้งานทั่วไปในส่วนของการขึ้นทะเบียนสิทธิรักษาพยาบาล>
=============================================
*/

var HCSStaffDownloadRegistrationForm = {
    idSectionMain: HCSStaffUtil.idSectionDownloadRegistrationFormMain.toLowerCase(),
    idSectionSearch: HCSStaffUtil.idSectionDownloadRegistrationFormSearch.toLowerCase(),
    idSectionProgress: HCSStaffUtil.idSectionDownloadRegistrationFormProgress.toLowerCase(),
    sectionMain: {
        initMain: function () {
            var _this = Util.tut.tdf;

            Util.initCombobox({
                id: ("#" + _this.idSectionMain + "-rowperpage"),
                width: 103,
                height: 25
            });
            Util.initCheck({
                id: "select-root"
            });

            $("#" + _this.idSectionMain + "-table .button .click-button").click(function () {
                if ($(this).hasClass("button-downloadselected") == true || $(this).hasClass("button-downloadall") == true)
                    Util.tut.tpd.getProgress({
                        action: Util.tut.subjectSectionDownload,
                        page: Util.tut.pageDownloadRegistrationFormProgress,
                        this: _this,
                        idMain: _this.idSectionMain,
                        idProgress: _this.idSectionProgress,
                        option: $(this).attr("alt")
                    });
            });

            this.resetMain();
        },
        resetMain: function () {
            var _this = Util.tut.tdf;

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
        resetMain: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

            var _this = Util.tut.tdf;
            var _idTable = (_this.idSectionMain + "-table");
            var _valueRegistrationForm = ($("#" + _this.idSectionSearch + "-registrationform option:selected").text().split("-"));
            
            $("#" + _this.idSectionProgress + "-registrationformnameth").html($.trim(_valueRegistrationForm[_valueRegistrationForm.length - 1]));
            $("#" + _this.idSectionProgress + "-registrationformnameen").html(Util.comboboxGetValue("#" + _this.idSectionSearch + "-registrationform"));
        },
        validateProcess: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);

            var _this = Util.tut.tdf;
            var _error = new Array();
            var _i = 0;

            return (_i > 0 ? false : true);
        },
        getResultProcess: function (_param) {
            _param["page"] = (_param["page"] == undefined ? "" : _param["page"]);
            _param["resultValueProcess"] = (_param["resultValueProcess"] == undefined || _param["resultValueProcess"] == "" ? null : _param["resultValueProcess"]);

            var _this = Util.tut.tdf;
            var _detailComplete = _param["resultValueProcess"].DetailComplete;
            var _idTable = (_this.idSectionMain + "-table");
            var _idTableRow;

            var _valueArray1 = _detailComplete.split(",");
            var _valueArray2;
            var _i;
                
            for (_i = 0; _i < _valueArray1.length; _i++) {
                _valueArray2 = _valueArray1[_i].split(";")
                _idTableRow = (_idTable + " .table-grid #table-row-id-" + _valueArray2[0]);

                if ($("#" + _idTableRow).length > 0) {
                    $("#" + _idTableRow + " .table-col-latestdatedownload").html(_valueArray2[1]);
                    $("#" + _idTableRow + " .table-col-countdownload").html(_valueArray2[2]);
                }
            }
        }
    }
}