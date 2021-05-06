/*
=============================================
Author      : <ยุทธภูมิ ตวันนา>
Create date : <๑๖/๐๒/๒๕๖๔>
Modify date : <๐๘/๐๓/๒๕๖๔>
Description : <>
=============================================
*/

var MSent = {
    userCode: "",
    isConsent: false,
    url: {
        header: {
            lang: "TH",
            /*
            clientid: "SIT_KEY_EPROFILE",
            clientsecret: "d0d96380-aae2-4ebf-9f5b-d771395dfaf8"
            */
            clientid: "PRD_KEY_EPROFILE",      
            clientsecret: "7c845c36-70f6-473b-b7b8-792053d21250"
        },
        api: {
            domain: "https://smartedu.mahidol.ac.th/Infinity/MSent/Profile/API/Accepted/",
            route: {
                version: "Version",
                termsAndCond: "TermsAndConditions",
                privacyPolicy: "PrivacyPolicy",
                consent: "Consent"
            }
        },
        page: {
            /*
            termsAndConditions: "https://privacy-qas.mahidol.ac.th/Msent/Pages/termsAndConditions.html",
            consent: "https://privacy-qas.mahidol.ac.th/Msent/Pages/consents.html",
            redirect: "http://localhost:32561/Module/Operation/eProfile/"
            */
            termsAndConditions: "https://privacy.mahidol.ac.th/Msent/Pages/termsAndConditions.html",
            consent: "https://privacy.mahidol.ac.th/Msent/Pages/consents.html",
            redirect: "https://smartedu.mahidol.ac.th/eProfile/Module/Operation/eProfile/index.aspx"
        }
    },
    currentVersion: {
        versionNumber: null,
        versionName: null,
        termsAndCondId: null,
        privacyPolicyId: null,
        consentId: null
    },
    acceptedVersion: {
        versionNumber: null,
        versionName: null,
        termsAndCondId: null,
        privacyPolicyId: null,
        consentId: null
    },
    consentField: {    
        religion: {
            id: 7,
            name: "religion",
            isConsent: false
        }
    },
    getIsConsent: function (userCode, callBackFunc) {
        var that = this;
        var isError = false;

        this.userCode = userCode;
        this.isConsent = false;

        if (this.userCode.length > 0) {
            $.ajax({
                beforeSend: function () {
                    Util.dialogMessagePreloading();
                },
                async: true,
                type: "GET",
                headers: this.url.header,
                url: (this.url.api.domain + "?route=" + this.url.api.route.version + "&userCode=" + this.userCode),
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    var data = result.data;
                    var isValidData = (data != undefined && data != null ? true : false)
          
                    if (isValidData) {
                        if (data.resultDescription.toLowerCase() == "success")
                            isError = false;
                        else
                            isError = true;
                    }
                    else
                        isError = true;
          
                    if (!isError) {
                        that.currentVersion = data.data.currentVersion;
                        that.acceptedVersion = data.data.acceptedVersion;

                        if (that.currentVersion.versionNumber != null && that.acceptedVersion.versionNumber != null) {
                            that.isConsent = ((that.currentVersion.termsAndCondId == that.acceptedVersion.termsAndCondId) &&
                                              (that.currentVersion.privacyPolicyId == that.acceptedVersion.privacyPolicyId) &&
                                              (that.currentVersion.consentId == that.acceptedVersion.consentId) ? true : false);

                            if (that.isConsent) {
                                that.getAccepted("consent", function (data) {
                                    if (data != null) {
                                        that.consentField.religion.isConsent = (data.consentChoiceIds.indexOf(that.consentField.religion.id) >= 0 ? true : false);                      
                                    }
                                    else
                                        that.isConsent = false;

                                    callBackFunc();
                                });
                            }
                            else
                                callBackFunc();
                        }
                        else
                            callBackFunc();
                    }
                    else
                        callBackFunc();
                }
            });
        }
        else
            callBackFunc();
    },
    getAccepted: function (route, callBackFunc) {
        var id = "";
        var isError = false;

        if (route == "termsAndCond")
            id = this.acceptedVersion.termsAndCondId;

        if (route == "privacyPolicy")
            id = this.acceptedVersion.privacyPolicyId;

        if (route == "consent")
            id = this.acceptedVersion.consentId;

        if (this.url.api.route[route] != undefined && id != null && this.userCode.length > 0) {
            $.ajax({
                beforeSend: function () {
                    Util.dialogMessagePreloading();
                },
                async: true,
                type: "GET",
                headers: this.url.header,
                url: (this.url.api.domain + "?route=" + this.url.api.route[route] + "&id=" + id + "&userCode=" + this.userCode),
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    var data = result.data;
                    var isValidData = (data != undefined && data != null ? true : false)

                    if (isValidData) {
                        if (data.resultDescription.toLowerCase() == "success")
                            isError = false;
                        else
                            isError = true;
                    }
                    else
                        isError = true;

                    callBackFunc(!isError ? data.data : null);
                }
            });
        }
        else
            callBackFunc(null);
    },
    getPage: {    
        termsAndConditions: function () {
            var param = ("lang=" + MSent.url.header.lang + "&clientid=" + MSent.url.header.clientid + "&clientsecret=" + MSent.url.header.clientsecret + "&userid=" + MSent.userCode + "&url=" + MSent.url.page.redirect);

            return (MSent.url.page.termsAndConditions + "?" + param);
        },

        consent: function () {
            var param = ("lang=" + MSent.url.header.lang + "&clientid=" + MSent.url.header.clientid + "&clientsecret=" + MSent.url.header.clientsecret + "&userid=" + MSent.userCode + "&url=" + MSent.url.page.redirect);

            return (MSent.url.page.consent + "?" + param);
        }
    }
};