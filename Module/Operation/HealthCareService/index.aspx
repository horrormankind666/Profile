<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />    
    <meta http-equiv="X-UA-Compatible" content="IE=edge" /> 
    <title>ระบบขึ้นทะเบียนสิทธิรักษาพยาบาลของนักศึกษา : System of Health Care Service</title>
    <link rel="icon" type="image/png" href= "../../../Content/Image/HealthCareService/MUIcon.png" />
    <link rel="stylesheet" type="text/css" href="../../../Content/jQuery/HealthCareService/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../../../Content/CSS/HealthCareService/CSS.css" />
    <script type="text/javascript" src="../../../Content/jQuery/HealthCareService/external/jquery/jquery.js"></script>
    <script type="text/javascript" src="../../../Content/jQuery/HealthCareService/jquery-ui.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/BrowserDetect.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/Util.js"></script>
    <script type="text/javascript" src="../../../Content/JScript/HealthCareService/HCSUtil.js"></script>
</head>
<body>
<div id="bodymain">
    <div id="mainbody" align="center">
        <div id="contentbody">
            <div id="contentbody-layout">
                <div id="contentbody-content"></div>  
            </div>
        </div>
    </div>
</div>
<iframe class="frame-util hidden" id="frame-util" name="frame-util"></iframe>
<div class="hidden" id="page"><% Response.Write(Request.QueryString["p"]); %></div>
<div class="hidden" id="dialog-preloading"></div>
<div class="hidden" id="dialog-box"></div>
<div class="hidden" id="dialog-error"></div>
<div class="hidden" id="dialog-confirm"></div>
</body>
<script type="text/javascript">
    $(window).resize(function () {
        try {
            if ($("#" + Util.dialogPreloading).is(":visible"))
                $("#" + Util.dialogPreloading).dialog("option", "position", {
                    my: "center",
                    at: "center",
                    of: window
                });

            if ($("#" + Util.dialogBox).is(":visible"))
                $("#" + Util.dialogBox).dialog("option", "position", {
                    my: "bottom",
                    at: "bottom",
                    of: window
                });

            if ($("#" + Util.dialogError).is(":visible"))
                $("#" + Util.dialogError).dialog("option", "position", {
                    my: "bottom",
                    at: "bottom",
                    of: window
                });

            if ($("#" + Util.dialogConfirm).is(":visible"))
                $("#" + Util.dialogConfirm).dialog("option", "position", {
                    my: "bottom",
                    at: "bottom",
                    of: window
                });
        }
        catch (_e) {
        }
    });

    try {
        Util.tut = HCSUtil;
        Util.tut.tdf = HCSDownloadRegistrationForm;
        Util.getPage();
    }
    catch (_e) {
        Util.dialogMessageError({
            content: "<div class='th-label'>ประมวลผลไม่สำเร็จ</div><div class='en-label'>Processing was not successful</div>",
        });
    }
</script>
</html>
