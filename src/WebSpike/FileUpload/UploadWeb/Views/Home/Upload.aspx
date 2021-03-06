﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Upload
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../NeatUpload/SWFUpload.js" type="text/javascript"></script>
    <script src="../../NeatUpload/NeatUpload.js" type="text/javascript"></script>

    <h2>Upload</h2>
    <%--<x action='<%: Url.Content("~/NeatUpload/StaticUploadHandler.ashx")%>' />--%>
    <form id="formID" action='<%: Url.Action("Upload", "Home") %>' method="post" enctype="multipart/form-data">
	    InputFile: 
	    <!-- The HTML for an InputFile control is a normal <input type="file"> control with a name
	         field that has the form "NeatUpload_" + any alphanumeric numeric string + "-" + a name
	         that you can use to access the uploaded file from your handler using  
	         UploadModule.Files.   In this example, you would use UploadModule.Files["fileField"] -->
	    <input id="fileID" type="file" name="NeatUpload_replacedByScript-fileField" /><br />
	
	    MultiFile:<br />
	    <!-- The HTML for a MultiFile control is the same as for an InputFile control, but is
	         *immediately* followed (no blank space) by a <div style='position: relative; display: none;'> 
	         containing the replacement HTML to display for the MultiFile control.  NeatUpload will
	         make it visible but the content won't actually receive any user clicks because it will be
	         covered with a transparent element that will open the file dialog when the user clicks on it. -->
	    <input id="multiFileID" type="file" name="NeatUpload_replacedByScript-multiFileField" /><div id='NeatUploadDiv_multiFileID' style='position: relative; display: none;'>
		    <input type="button" name="multiFileButton" value="Add Files..." id="multiFileButton" />
	    </div><br />
	    <!-- NeatUpload will automatically start the progress display when the browser starts submitting
	         the form to the server in response to a user clicking on a trigger.  The array of trigger IDs
	         is passed to the NeatUploadPB constructor below.  If the array is empty, anything that causes
	         the form to be submitted would start the progress bar. If the array is not empty and the form 
	         is submitted in response to a non-trigger (e.g. cancelButtonID below), NeatUpload will clear
	         all InputFile and MultiFile controls before the form is submitted, so that no files are 
	         uploaded. -->  
	    <input id="uploadButtonID" type="submit" name="upload" value="Upload with type='submit' Button" />
	    <input id="uploadButtonID2" type="button" onclick="document.getElementById('formID').submit()" name="upload2" value="Upload by calling form.submit()" />
	    <input id="cancelButtonID" type="submit" name="cancel" value="Cancel" /><br />
	
	    <!-- The static HTML associated with the ProgressBar control can be any element that has an ID and is
	         within the form.  It is only needed so that NeatUpload can find the containing form.  It could even
	         be an empty placeholder element.  This page uses an hidden div that will we will display when 
	         the upload starts.  -->
	    <div id="progressDiv" style="display: none;">
		    Here is a simple progress display:<br />
		    <table id="progressDisplayCenterer"><tr><td>
			    <table id="progressDisplay" class="ProgressDisplay"><tr>
				    <td id="barTd" >
					    <div id="statusDiv" class="StatusMessage"><span id="statusSpan">&nbsp;</span>	
						    <div id="barDetailsDiv" style="width: 0%" class="ProgressBar"></div>
					    </div>
				    </td>
				    <td>
					    <input id="stopButton" type="button" onclick="StopUpload()" value="Stop Upload" style="display: none;"/>
				    </td>
			    </tr></table>
		    </td></tr></table>
		    And here is the raw JSON representing the upload state:<br />
		    <div id="rawJsonDiv">
		    </div>
	    </div>

    <script type="text/javascript">
        // Generate long random string so uploads don't interfere with each other.
        var initialPostBackID = Math.round(Math.random() * 1000000000);

        // The application path is the path to the top-level directory of the app.
        // In our case it is the path to this page with the last 3 elements removed.
        var appPath = '<%: Url.Content("~/") %>'; //document.location.pathname.split('/').slice(0, -3).join('/');
        if (appPath == "/") {
            appPath = "";
        }

        // Change the element with an id of "multiFileID" into a NeatUpload MultiFile control.
        NeatUploadMultiFileCreate(
        // The id of the <input type="file"> element
		    "multiFileID",
		    initialPostBackID,
		    appPath,
        // Needed for Flash-based multi-file uploads
		    appPath + '/NeatUpload/MultiRequestUploadHandler.ashx',
        // The default postback id query param
		    'NeatUpload_PostBackID',
		    {
		        NeatUpload_PostBackID: initialPostBackID,
		        // The id of the <input type="file"> element
		        NeatUpload_MultiRequestControlID: 'multiFileID',
		        // This page doesn't use it, so it needs to be null
		        NeatUpload_ArmoredCookies: null
		    },
        // Whether to use Flash if it is available
		    true,
        // The id of the FileQueueControlID, see
        // http://www.brettle.com/NeatUpload-1.3/dotnet/docs/Manual.html#5.5.Customizing%20MultiFile%27s%20Handling%20of%20Queued%20Files|outline
		    '',
        // The FlashFilterExtensions and FlashFilterDescription properties, see
        // http://www.brettle.com/NeatUpload-1.3/dotnet/docs/Manual.html#3.4.Allowing%20Users%20with%20Flash%20to%20Select%20Multiple%20Files%20from%20One%20File%20Selection%20Dialog|outline
		    '*.*', '',
        // An id that is just used to construct a unique id for the flash element
		    'NeatUploadDiv_multiFileID',
        // Any id that doesn't exist in the form.
		    'NeatUploadConfig_multiFileID'
	    );

        // Change the element with an id of "fileID" into a NeatUpload InputFile control.
        NeatUploadInputFileCreate("fileID", initialPostBackID);

        // Create a NeatUploadPB object associated with the element with id "progressDiv".
        var pb = new NeatUploadPB(
        // The id of the element in the form.  Also use to identify this object.
		    "progressDiv",
        // The initial postBackID
		    initialPostBackID,
        // We are going to override pb.Display(), so these 3 arguments will not be used.
        // If we didn't override pb.Display(), they would control the URL and size of a
        // popup window used to display progress by default.
		    appPath + "/NeatUpload/Progress.aspx?barID=progressDiv", "500px", "100px",
        // The array of trigger IDs.
		    ["uploadButtonID", "uploadButtonID2"],
        // The function to eval() that determines whether to start the progress display.
        // IsFilesToUpload() is already defined in NeatUpload.js.
		    "IsFilesToUpload()");

        // These two lines are only necessary if you are using Progress.aspx/Progress.js.
        // We aren't but we leave them here as a reminder.
        NeatUploadPB.prototype.Bars["progressDiv"] = pb;
        pb.EvalOnClose = null;

        // Override pb.Display() to start refreshing out progress display every 1000ms.
        pb.Display = function () {
            RefreshProgress(pb.UploadForm.GetPostBackID(), pb.ClientID, pb.CanCancel, 1000);
        };

        // If the upload succeeds, StaticUploadHandler.ashx will redirecte the browser back to this page but
        // the postBackID of the upload will be passed in the query string.
        // If we find the postBackID in the query string we use it to display the status of the
        // completed upload.
        var queryParams = (document.location.search || '?').substring(1).split('&');
        var queryObj = { postBackID: null, numFilesReceived: 0 };
        for (var i = 0; i < queryParams.length; i++) {
            var qp = queryParams[i].split('=');
            queryObj[qp[0]] = qp[1];
        }
        if (queryObj.postBackID) {
            window.onload = function () {
                RefreshProgress(queryObj.postBackID, pb.ClientID, pb.CanCancel, 0); // 0 means only refresh once
            };
        };

        // Useful vars for updating our progress bar HTML.
        var progressDiv = document.getElementById("progressDiv");
        var stopButton = document.getElementById("stopButton");
        var barDetailsDiv = document.getElementById("barDetailsDiv");
        var statusSpan = document.getElementById("statusSpan");
        var rawJsonDiv = document.getElementById("rawJsonDiv");

        /**** FUNCTIONS ****/

        // Refreshes our progress display using the upload state associated with a postBackID and controlID
        // every updateDelayMs.
        // The progress display will only be refreshed once if updateDelayMs == 0 and it will stop
        // refreshing once the upload is completed, cancelled, rejected, or fails.
        function RefreshProgress(postBackID, controlID, canCancel, updateDelayMs) {
            // The real work is done by RefreshWithAjax().  We just need to tell it where to get the
            // up upload state JSON and what function (UpdateHtml) to call with that state.
            RefreshWithAjax(appPath + "/NeatUpload/ProgressJsonHandler.ashx", postBackID, controlID, UpdateHtml, canCancel, updateDelayMs);
        }

        // Updates the progress bar HTML to reflect the uploadState.
        // uploadStopper is a function that can be called to cancel the upload.
        // uploadStateJson is the uploadState as a JSON string which can be useful for debugging.
        // Note: the exact data available for the files in uploadState.Files may vary
        // depending on the UploadStorageProvider being used.  For the default provider,
        // ControlUniqueID, FileName and ContentType are available during the upload and after it
        // completes until it is stale.  However ContentLength may be -1 after the entire upload
        // completes if MoveTo() hasn't been called.
        function UpdateHtml(uploadState, uploadStopper, uploadStateJson) {
            stopButton.onclick = uploadStopper;
            barDetailsDiv.style.width = uploadState.PercentComplete + "%";
            statusSpan.innerHTML = uploadState.BytesRead + "/" + uploadState.BytesTotal + " bytes";
            progressDiv.style.display = "block";
            switch (uploadState.Status) {
                case "NormalInProgress":
                    statusSpan.innerHTML = uploadState.BytesRead + "/" + uploadState.BytesTotal + " bytes";
                    stopButton.style.display = "block";
                    break;
                case "ChunkedInProgress":
                    statusSpan.innerHTML = uploadState.BytesRead + " bytes";
                    stopButton.style.display = "block";
                    break;
                case "ProcessingInProgress":
                    if (uploadState.ProcessingState) {
                        var ps = uploadState.ProcessingState;
                        statusSpan.innerHTML
						    = "Processing " + ps.Value + "/" + ps.Maximum + " " + EncodeHtml(ps.Units);
                    }
                    stopButton.style.display = "block";
                    break;
                case "Completed":
                    statusSpan.innerHTML = "<b>Upload Complete!</b>";
                    stopButton.style.display = "none";
                    break;
                case "ProcessingCompleted":
                    statusSpan.innerHTML = "<b>Processing Complete!</b>";
                    stopButton.style.display = "none";
                    break;
                case "Cancelled":
                    statusSpan.innerHTML = "<b>Upload Cancelled!</b>";
                    stopButton.style.display = "none";
                    break;
                case "Rejected":
                    statusSpan.innerHTML = "<b>Upload Rejected: " + EncodeHtml(uploadState.Message) + "</b>";
                    stopButton.style.display = "none";
                    break;
                case "Failed":
                    statusSpan.innerHTML = "<b>Upload Failed: " + EncodeHtml(uploadState.Message) + "</b>";
                    stopButton.style.display = "none";
                    break;
                case "Unknown":
                    progressDiv.style.display = "none";
                default:
                    statusSpan.innerHTML = "Unrecognized status: " + EncodeHtml(uploadState.Status);
            }
            if (!uploadStopper)
                stopButton.style.display = "none";
            rawJsonDiv.innerHTML = "<pre>" + EncodeHtml(uploadStateJson) + "</pre>";
        }

        function EncodeHtml(s) {
            return s.replace("&", "&amp;", "gm").replace("<", "&lt;", "gm");
        }


        // Every updateDelayMs (or once if updateDelayMs == 0), retrieves from progressHandlerPath
        // the upload state associated with postBackID and controlID, and passes it to updateFunc, 
        // stopping once the upload is completed, cancelled, rejected, or fails.
        // This function is independent of this page and something like it might be included
        // in a future version of NeatUpload.js.
        function RefreshWithAjax(progressHandlerPath, postBackID, controlID, updateFunc, canCancel, updateDelayMs) {
            var uploadStopper = canCancel ? StopUpload : null;

            // See GetHiddenIframeWindow() for why we need a hidden iframe.
            var hiddenIframeWindow = GetHiddenIframeWindow();
            hiddenIframeWindow.setTimeout(function () {
                hiddenIframeWindow.XHRPoll(progressHandlerPath + "?postBackID=" + postBackID + "&controlID=" + controlID, function (req, startTime) {
                    if (typeof (req) == 'undefined' || req == null || req.readyState != 4 || req.status != 200)
                        return 0;
                    var responseText = req.responseText;
                    var uploadState = eval("(" + responseText + ")");
                    updateFunc(uploadState, uploadStopper, responseText);
                    if (!updateDelayMs) return 0;
                    if (uploadState.Status == 'NormalInProgress' || uploadState.Status == 'ChunkedInProgress' || uploadState.Status == 'ProcessingInProgress' || uploadState.Status == 'Unknown') {
                        var curTime = (new Date()).getTime();
                        var delay = Math.max(updateDelayMs - (curTime - startTime), 1);
                        return delay;
                    } else {
                        if (uploadState.Status == 'Cancelled' || uploadState.Status == 'Rejected' || uploadState.Status == 'Failed') {
                            try {
                                setTimeout(function () { NeatUploadForm.prototype.StopUpload(uploadState.Status); }, 1);
                            } catch (ex) {
                                // Nothing we can do.
                            }
                        }
                        return 0;
                    }
                });
            }, 1);

            // For non-IE browsers we can't update a submitting window from an event that occurs
            // in that window, so we make the event occur on a hidden iframe.  Opera will only let
            // the send() method be called on an XMLHttpRequest object that was created in that window,
            // so we need to inject the code that actually uses XMLHttpRequest to poll the server into
            // that iframe.
            function GetHiddenIframeWindow() {
                var hiddenIframe = document.getElementById("NeatUpload_HiddenIframe");
                if (hiddenIframe) {
                    return hiddenIframe.contentWindow || frames["NeatUpload_HiddenIframe"];
                }
                hiddenIframe = document.createElement("iframe");
                hiddenIframe.setAttribute("id", "NeatUpload_HiddenIframe");
                hiddenIframe.style.display = "none";
                document.body.appendChild(hiddenIframe);
                var hiddenIframeWindow = hiddenIframe.contentWindow || frames["NeatUpload_HiddenIframe"];
                hiddenIframeWindow.document.open();
                hiddenIframeWindow.document.write('<script type="text/javascript">\n\
	    // This function can be reused as is.\n\
	    function XHRPoll(url, callback) {\n\
		    SendRequest();\n\
		    function SendRequest() {\n\
			    var req = null;\n\
			    var startTime = (new Date()).getTime();\n\
			    if (typeof (XMLHttpRequest) != "undefined") {\n\
				    req = new XMLHttpRequest();\n\
			    } else {\n\
				    req = new ActiveXObject("MSXML2.XMLHTTP.3.0");\n\
			    }\n\
			    req.onreadystatechange = HandleResponse;\n\
			    req.open("GET", url);\n\
			    req.send(null);\n\
			    function HandleResponse() {\n\
				    var delay = callback(req, startTime);\n\
				    if (!delay) return;\n\
				    setTimeout(SendRequest, delay);\n\
			    }\n\
		    }\n\
	    }\n\
    </s' + 'cript>');
                hiddenIframeWindow.document.close();
                return hiddenIframeWindow;
            }

            function StopUpload() {
                var req = null;
                if (typeof (XMLHttpRequest) != 'undefined') {
                    req = new XMLHttpRequest();
                } else {
                    req = new ActiveXObject('MSXML2.XMLHTTP.3.0');
                }
                req.open('GET', progressHandlerPath + "?postBackID=" + postBackID + "&cancel=true");
                req.send(null);
            }
        }
	
    </script>
    </form>

</asp:Content>
