// =============================================
// Author       : <ยุทธภูมิ ตวันนา>
// Create date  : <๑๖/๑๒/๒๕๕๗>
// Modify date  : <๐๗/๐๔/๒๕๕๙>
// Description  : <รวมรวบฟังก์ชั่นใช้งานทั่วไปของระบบ>
// =============================================

var HCSUtil = {
    tdf: null,
    pathProject: "HealthCareService",
    urlHandler: "../../../Content/Handler/HealthCareService/HCSHandler.ashx",

    subjectSectionDownloadRegistrationForm: "DownloadRegistrationForm",

    idSectionDownloadRegistrationFormMain: "Main-DownloadRegistrationForm",

    pageDownloadRegistrationFormMain: "DownloadRegistrationFormMain",

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
        if (_error == false && _status == "Y100")           { _error = true; _msgTH = "กรุณาเข้าระบบระเบียนประวัตินักศึกษา"; _msgEN = "Please sign in student records."; }
        if (_error == false && _status == "Y010")           { _error = true; _msgTH = "ไม่พบนักศึกษา"; _msgEN = "Students not found."; }
        if (_error == false && _status == "Y020")           { _error = true; _msgTH = "นักศึกษาไม่ได้สังกัดในส่วนงานที่ขึ้นทะเบียน"; _msgEN = "Student not be under agency registered."; }
        if (_error == false && _status == "Y030")           { _error = true; _msgTH = "นักศึกษาไม่ได้เข้าระบบระเบียนประวัตินักศึกษา"; _msgEN = "Student not logged in student records."; }
        if (_error == false && _status == "Y040")           { _error = true; _msgTH = "ระบบยังไม่เปิดทำการ"; _msgEN = "The system is not open."; }
        if (_error == false && _status == "Y050")           { _error = true; _msgTH = "ระบบปิดทำการ"; _msgEN = "Close system."; }
        if (_error == false && _status == "Y060")           { _error = true; _msgTH = "นักศึกษาไม่มีสิทธิ์เข้าใช้ระบบ"; _msgEN = "No permission students."; }
        if (_error == false && _status == "Y001")           { _error = true; _msgTH = "บันทึกข้อมูลไม่สำเร็จ"; _msgEN = "Save was not successful."; }

        if (_error == true && _msgTH.length > 0 && _msgEN.length > 0)
            Util.dialogMessageError({
                content: ("<div class='th-label'>" + _msgTH + "</div><div class='en-label'>" + _msgEN + "</div>"),
                modal: false
            });

        return _error;
    },

    //ฟังก์ชั่นสำหรับโหลดหน้าที่ต้องการมาแสดง
    //โดยมีพารามิเตอร์ดังนี้
    //1. _callBackFunc  รับค่าสำหรับให้ส่งค่าที่ต้องการในฟังก์ชั่นกลับ
    loadPage: function (_callBackFunc) {
        var _this = this;
        var _error;
        var _page = ($("#page").html().length > 0 ? $("#page").html() : this.pageDownloadRegistrationFormMain);
        var _send = {};
        _send["action"] = "page";
        _send["page"]   = _page;       

        Util.msgPreloading = "Loading...";

        Util.loadAjax({
            url: this.urlHandler,
            method: "POST",
            data: _send,
            showPreloadingInline: false
        }, function (_result) {
            Util.clearPage();

            $("#page").html(_result.Page);

            _error = _this.getErrorMsg({
                        signinYN: _result.SignInYN,
                        pageError: _result.PageError,
                        cookieError: _result.CookieError,
                        userError: _result.UserError
                     });

            if (_error == false)
            {
                $("#contentbody-content").html(_result.MainContent).show();

                if (_page == _this.pageDownloadRegistrationFormMain)
                    Util.tut.tdf.sectionMain.initMain();
            }

            Util.initTextSelect();
            Util.gotoTopElement();

            _callBackFunc();
        });
    },

    //ฟังก์ชั่นสำหรับสลับรูปภาพ
    //โดยมีพารามิเตอร์ดังนี้
    //1. _param รับค่าพารามิเตอร์ต่าง ๆ ที่ต้องการ
    //id        รับค่าสำหรับชื่อกลุ่มของรูปภาพ
    swapImages: function (_param) {
        _param["id"] = (_param["id"] == undefined ? "" : _param["id"]);

        var $active = $("#" + _param["id"] + " .active");
        var $next   = ($("#" + _param["id"] + " .active").next().length > 0) ? $("#" + _param["id"] + " .active").next() : $("#" + _param["id"] + " div:first");

        $active.fadeOut(0, function () {
            $active.removeClass("active");
            $next.fadeIn(0).addClass("active");
        });
    },
}
    
var HCSDownloadRegistrationForm = {
    idSectionMain: HCSUtil.idSectionDownloadRegistrationFormMain.toLowerCase(),

    sectionMain: {     
        //ฟังก์ชั่นสำหรับเริ่มต้นการทำงานใหักับการขึ้นทะเบียนสิทธิรักษาพยาบาลของนักศึกษา
        initMain: function () {
            var _this = Util.tut.tdf;

            if ($("#" + _this.idSectionMain + "-slide").length > 0) setInterval("Util.tut.swapImages({ id: '" + _this.idSectionMain + "-slide' })", 1000);
            
            $("#" + _this.idSectionMain + "-form .button .click-button").click(function () {
                if ($(this).hasClass("button-download") == true)
                {
                    Util.clearContentIFrame("#frame-util");
                    window.open("HCSDownloadFile.aspx", "frame-util");

                    Util.msgPreloading = "Downloading...";
                    Util.dialogMessagePreloading();

                    Util.timer = setInterval(function () { _this.listenProgressData() }, 1000);
                }
            });
        },
    },
    
    //ฟังก์ชั่นสำหรับตรวจสอบความคืบหน้าของการส่งข้อมูลไปประมวลผล
    listenProgressData: function () {
        var _error = false;
        var _idSection;
        var _success;
        var _cookieError;
        var _userError;

        _idSection      = Util.tut.subjectSectionDownloadRegistrationForm.toLowerCase();
        _success        = $("#frame-util").contents().find("#" + _idSection + "success");
        _cookieError    = $("#frame-util").contents().find("#" + _idSection + "cookieerror");
        _userError      = $("#frame-util").contents().find("#" + _idSection + "usererror");
       
        if (_success.val() == "Y" || _success.val() == "N" || _success.val() === undefined)
        {
            $("#" + Util.dialogPreloading).dialog("close");
            clearInterval(Util.timer);

            _error = Util.tut.getErrorMsg({
                        signinYN: "Y",
                        pageError: 0,
                        cookieError:_cookieError.val(),
                        userError: _userError.val()
                     });


            if (_success.val() == "N" || _error == true)
                Util.clearPage();
        } 
    },
}