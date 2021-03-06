<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>ระบบจัดการข้อมูลระเบียนประวัตินักศึกษา : System of Administration Student Records</title>
    <link rel="icon" type="image/png" href= "../../../Content/Image/eProfileStaff/MUIcon.png" />
    <link rel="stylesheet" type="text/css" href="../../../Content/jQuery/eProfileStaff/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../../Content/Select/dist/css/select2.css" />
    <link rel="stylesheet" type="text/css" href="../../../Content/iCheck/skins/all.css" />
    <link rel="stylesheet" type="text/css" href="../../../Content/CSS/eProfileStaff/CSS.css" />
    <script type="text/javascript" src="../../../Content/jQuery/eProfileStaff/external/jquery/jquery.js"></script>
    <script type="text/javascript" src="../../../Content/jQuery/eProfileStaff/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Content/Select/dist/js/select2.js"></script>
    <script type="text/javascript" src="../../../Content/Select/dist/js/idselect.autocomplete.js"></script>
    <script type="text/javascript" src="../../../Content/iCheck/icheck.js"></script>
    <script type="text/javascript" src="../../../Content/Highcharts/js/highcharts.js"></script>
    <script type="text/javascript" src="../../../Content/Highcharts/js/modules/data.js"></script>
    <script type="text/javascript" src="../../../Content/Highcharts/js/modules/drilldown.js"></script>
    <script type="text/javascript" src="../../../Content/Highcharts/js/modules/exporting.js"></script>
    <script type="text/javascript" src="../../../Content/Highcharts/js/modules/offline-exporting.js"></script>  
    <script type="text/javascript" src="../../../Content/JScript/BrowserDetect.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/Util.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/MSent.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/eProfileStaff/ePFStaffUtil.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/eProfileStaff/ePFStaffSearch.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/eProfileStaff/ePFStaffProgressData.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/eProfileStaff/ePFStaffSetting.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/eProfileStaff/ePFStaffMasterData.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/eProfileStaff/ePFStaffStudentRecords.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/eProfileStaff/ePFStaffOurServices.js"></script>
</head>
<body>
<div id="bodymain">
    <div id="mainbody">
        <div class="sticky">
            <div id="headbody">
                <div id="headbody-layout">
                    <div id="headbody-content">
                        <div class="contentbody-left" id="headbody-content-left"></div>
                        <div class="contentbody-right" id="headbody-content-right"></div>
                    </div>
                    <div class="clear"></div>
                </div>                
                <div id="menubar-layout">
                    <div id="menubar-content"></div>
                </div>
                <div class="box"></div>
            </div>
        </div>
        <div id="contentbody">
            <div id="contentbody-layout">
                <div id="contentbody-content"></div>  
            </div>
        </div>
    </div>
</div>
<div id="bodysearch"></div>
<div id="bodyfooter">
    <div id="footerbody">
        <div class="box"></div>
        <div id="footerbody-layout">
            <div id="footerbody-content">
                <div class="th-label">พัฒนาโดย กองเทคโนโลยีสารสนเทศ สำนักงานอธิการบดี มหาวิทยาลัยมหิดล ศาลายา</div>
                <div class="en-label">Developed By : Division of Information Technology. Copyright @ 2014 Mahidol University. All rights reserved.</div>
            </div>
        </div>
    </div>
</div>    
<iframe class="frame-util hidden" id="frame-util" name="frame-util"></iframe>
<div class="hidden" id="page"><% Response.Write(Request.QueryString["p"]); %></div>
<div class="hidden" id="id"><% Response.Write(Request["id"]); %></div>
<div class="hidden" id="dialog-preloading"></div>
<div class="hidden" id="dialog-box"></div>
<div class="hidden" id="dialog-error"></div>
<div class="hidden" id="dialog-confirm"></div>
<div class="hidden" id="dialog-form1"></div>
<div class="hidden" id="dialog-form2"></div></body>
<script type="text/javascript">
    $(window).resize(function () {
        try {
            if ($("#" + Util.dialogPreloading).is(":visible"))
                $("#" + Util.dialogLoading).dialog("option", "position", { my: "center", at: "center", of: window });
            /*
            if ($("#" + Util.dialogBox).is(":visible"))
                $("#" + Util.dialogBox).dialog("option", "position", { my: "bottom", at: "bottom", of: window });

            if ($("#" + Util.dialogError).is(":visible"))
                $("#" + Util.dialogError).dialog("option", "position", { my: "bottom", at: "bottom", of: window });

            if ($("#" + Util.dialogConfirm).is(":visible"))
                $("#" + Util.dialogConfirm).dialog("option", "position", { my: "bottom", at: "bottom", of: window });
            */
            if ($("#" + Util.dialogBox).is(":visible"))
                $("#" + Util.dialogBox).dialog("option", "position", { my: "center", at: "center", of: window });

            if ($("#" + Util.dialogError).is(":visible"))
                $("#" + Util.dialogError).dialog("option", "position", { my: "center", at: "center", of: window });

            if ($("#" + Util.dialogConfirm).is(":visible"))
                $("#" + Util.dialogConfirm).dialog("option", "position", { my: "center", at: "center", of: window });

            if ($("#" + Util.dialogForm + "1").is(":visible"))
                $("#" + Util.dialogForm + "1").dialog("option", "position", { my: "center", at: "center", of: window });

            if ($("#" + Util.dialogForm + "2").is(":visible"))
                $("#" + Util.dialogForm + "2").dialog("option", "position", { my: "center", at: "center", of: window });

            if ($(".select2-dropdown").is(":visible"))
                $("select").select2("close");

            if ($(".ui-datepicker").is(":visible"))
                $(".ui-datepicker").hide();
        }
        catch (_e) {
        }

        Util.setStickyTop(0);
        Util.setMenuBarLayout();
        Util.setInfoBarLayout();
        Util.tut.tse.setSearchLayout();
        Util.tut.tsr.sectionAddUpdate.setMenuLayout();
        Util.setChartLayout();
        Util.setTableLayout();
        Util.setFooterLayout();
    });

    $(window).scroll(function () {
        try {
            if ($(".select2-dropdown").is(":visible"))
                $("select").select2("close");

            if ($(".ui-datepicker").is(":visible"))
                $(".ui-datepicker").hide();
        }
        catch (_e) {
        }
    });

    try {
        Util.tut = ePFStaffUtil;
        Util.tut.tse = ePFStaffSearch;
        Util.tut.tst = ePFStaffSetting;
        Util.tut.tmd = ePFStaffMasterData;
        Util.tut.tsr = ePFStaffStudentRecords;
        Util.tut.tos = ePFStaffOurServices;
        Util.tut.tpd = ePFStaffProgressData;
        Util.getPage();
    }
    catch (_e) {
        Util.dialogMessageError({
            content: "<div class='th-label'>ประมวลผลไม่สำเร็จ</div><div class='en-label'>Processing was not successful</div>",
        });
    }
</script>
</html>
