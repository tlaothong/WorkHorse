<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script src="../../../../Scripts/jquery-ui-1.8.6.custom.min.js" type="text/javascript"></script>
<script src="../../../../Scripts/JCore.js" type="text/javascript"></script>
<link href="../../../../Content/jquery-ui-1.8.6.custom.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        $("#New_Video").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 600,
            title: "Upload Video",
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        $("#Popup").click(function () {
            $("#New_Video").dialog("open");
        });
    });
</script>
<script type="text/javascript">
    var nonMSDOMBrowser = (window.navigator.appName.toLowerCase().indexOf('explorer') == -1);

    // Referense to bug fix: http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=705049&SiteID=1
    function ICallbackEventHandlerFix() {
        if (typeof (WebForm_CallbackComplete) == "function") {
            // set the original version with fixed version
            WebForm_CallbackComplete = WebForm_CallbackComplete_SyncFixed;

        }
    }

    function WebForm_CallbackComplete_SyncFixed() {

        // SyncFix: the original version uses "i" as global thereby resulting in javascript errors when "i" is used elsewhere in consuming pages
        for (var i = 0; i < __pendingCallbacks.length; i++) {
            callbackObject = __pendingCallbacks[i];
            //alert(callbackObject + " : " + callbackObject.xmlRequest + " : " + callbackObject.xmlRequest.readyState + " : " + callbackObject.xmlRequest.responseText);
            if (callbackObject && callbackObject.xmlRequest && (callbackObject.xmlRequest.readyState == 4)) {
                if (!__pendingCallbacks[i].async) {
                    __synchronousCallBackIndex = -1;
                }
                __pendingCallbacks[i] = null;

                var callbackFrameID = "__CALLBACKFRAME" + i;
                var xmlRequestFrame = document.getElementById(callbackFrameID);
                if (xmlRequestFrame) {
                    xmlRequestFrame.parentNode.removeChild(xmlRequestFrame);
                }

                // Trick for FireFox. Sometimes the first response is empty.
                // So, we check that the current async request is upload request and if so call the server again.
                if (nonMSDOMBrowser && isUploadRequest && callbackObject.xmlRequest.responseText == "" && UploadId != "") {
                    CallServer(UploadId);
                    return;
                }

                // SyncFix: the following statement has been moved down from above;
                WebForm_ExecuteCallback(callbackObject);

            }
        }
    }
    var UploadId;
    var isUploadRequest;
    var isUploadCanceled = false;

    function doUpload() {
        UploadId = GetUploadId(); // GetUploadId() defined in JSCore.js

        var Form = document.getElementById("Form1");
        Form.action = RefreshQueryString(Form.action, UploadId);
        isUploadRequest = true;
        isUploadCanceled = false
        document.getElementById(responseLabelID).innerHTML = "";

        // Recieve a status information through asynchronous request.
        CallServer(UploadId);

        document.getElementById("cancelButton").style.display = "block";
        document.getElementById(uploadButtonID).style.display = "none";

        return true;

    }

    // Terminates an upload process
    function cancelUpload() {
        isUploadCanceled = true;

        if (window.stop) {
            window.stop();
        }
        else {
            window.document.execCommand("Stop");
        }

        CallServer("DELETE--sep--" + UploadId);

        isUploadRequest = false;
        UploadId = "";

        document.getElementById("StatusInfo").style.display = "none";
        document.getElementById("FileList").style.display = "block";

        document.getElementById("cancelButton").style.display = "none";
        document.getElementById(uploadButtonID).style.display = "block";

    }

    // Handles an event that is occurred when a status information is received
    // and refreshes a status information on the page.            
    // "response" - a string response from a web server
    function OnResponseLoaded(response) {
        if (isUploadCanceled) {
            return;
        }

        var StatusInfoOutput = document.getElementById("StatusInfo");

        if (response && response != "") {
            if (response == "DELETED") {
                return;
            }
            if (response.indexOf("FAILED") != -1) {
                var args = response.split("--sep--");

                alert(args[1]);

                cancelUpload();

                return;
            }

            if (StatusInfoOutput.style.display == 'none') {
                document.getElementById("FileList").style.display = "none";
                StatusInfoOutput.style.display = 'block';
            }
            var StatusInfo = JSONtoJSObject(response);

            if (typeof (StatusInfo.PercentsDone) != 'undefined') // Checking that the response is converted to the JavaScript object correct.
            {
                document.getElementById('progressBar').style.width = StatusInfo.PercentsDone + '%';
                document.getElementById('progressPercentsDone').innerHTML = StatusInfo.PercentsDone + '%';

                var htmlString = 'Uploaded ' + Math.round(StatusInfo.UploadedBytes / 1024) + ' KB of ' + Math.round(StatusInfo.TotalBytes / 1024) + ' KB<br/>';
                htmlString += 'Time left: ' + StatusInfo.RemainingTime + ' sec<br/>';
                htmlString += 'Transfer rate: ' + Math.round((StatusInfo.BytesPerSecondAvg / 1024) * 100) / 100 + ' KB/s<br/>';
                htmlString += 'Current uploading file: ' + StatusInfo.CurrentFileName + '<br/><br/>';

                document.getElementById('progressTextInfo').innerHTML = htmlString;

                if (StatusInfo.State == 'Complete') {
                    isUploadRequest = false;
                    UploadId = "";

                    return;
                }

            }
            else {
                StatusInfoOutput.innerHTML = response;
                return;
            }
        }
        else {
            return;
        }

        // Set timeout for the next server call.
        setTimeout('CallServer(' + StatusInfo.UploadID + ', "")', 500);

    }        
           
</script>
<script type="text/javascript">
</script>
<div id="New_Video">
    <div>
        <fieldset style="border: 1px solid #A49F9F; padding: 10">
            <legend align="left" style="font-size: small; height: 30px;"><font color=" #A49F9F">
                Agreement</font> </legend>
            <div style='padding-left: 80px'>
                <br />
                <p>
                    <br />
                    1. Agreement<br />
                    2. Agreement<br />
                    3. Agreement<br />
                    4. Agreement<br />
                    5. Agreement<br />
                    6. Agreement<br />
                    7. Agreement<br />
                    8. Agreement<br />
                    9. Agreement<br />
                    10. Agreement<br />
                </p>
                <br />
                <input type="checkbox" /><label>I Agree</label><br />
                <input type="checkbox" /><label>I Disagree</label>
            </div>
        </fieldset>
    </div>
    <br />
    <table style="text-align: center">
        <tr>
            <td align="left">
                Back
            </td>
            <td align="right">
                Next
            </td>
        </tr>
        <br />
        <tr>
            <td align="left">
                <button type="button">
                    Step 1</button>
                <button type="button">
                    Step 2</button>
                <button type="button">
                    Step 3</button>
            </td>
        </tr>
    </table>
    <fieldset>
        <legend>Upload details</legend>
        <table id="FileList">
            <tr>
                <td>
                    Location:
                </td>
                <td>
                    <input type="file" name="File_1" size="40" />
                </td>
                <td>
                    <div style="float: left;">
                        Tags<input type="text" value="Tag1; Tag2; Tag3;" /></div>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <div>
                        Video name<input type="text" /></div>
                    <div>
                        Group<select><option>Please select</option>
                        </select></div>
                    <div>
                        Sub Group<select><option>Please select</option>
                        </select></div>
                </td>
                <td>
                    <div>
                        <label>
                            Description</label><textarea rows="4" cols="50"></textarea></div>
                </td>
            </tr>
        </table>
    </fieldset>
</div>
