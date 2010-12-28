<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

    <link href="../../../../Content/context-menu.css" rel="stylesheet" type="text/css" />
    <link href="../../../../Content/drag-drop-folder-tree.css" rel="stylesheet" type="text/css" />
    <script src="../../../../Scripts/ajax.js" type="text/javascript"></script>
    <script src="../../../../Scripts/context-menu.js" type="text/javascript"></script>
    <script src="../../../../Scripts/drag-drop-folder-tree.js" type="text/javascript"></script>
    <style type="text/css">
	/* CSS for the demo */
	img{
		border:0px;
	}
	</style>
    <script type="text/javascript">
        //--------------------------------
        // Save functions
        //--------------------------------
        var ajaxObjects = new Array();
        // Use something like this if you want to save data by Ajax.
        function saveMyTree() {
            saveString = treeObj.getNodeOrders();
            var ajaxIndex = ajaxObjects.length;
            ajaxObjects[ajaxIndex] = new sack();
            var url = 'saveNodes.php?saveString=' + saveString;
            ajaxObjects[ajaxIndex].requestFile = url; // Specifying which file to get
            ajaxObjects[ajaxIndex].onCompletion = function () { saveComplete(ajaxIndex); }; // Specify function that will be executed after file has been found
            ajaxObjects[ajaxIndex].runAJAX(); 	// Execute AJAX function			
        }
        function saveComplete(index) {
            alert(ajaxObjects[index].response);
        }
        // Call this function if you want to save it by a form.
        function saveMyTree_byForm() {
            document.myForm.elements['saveString'].value = treeObj.getNodeOrders();
            document.myForm.submit();
        }
	</script>
                        <div class="DHTMLSuite_contextMenu">
                            <ul id="dhtmlgoodies_tree2" class="dhtmlgoodies_tree">
                            <li id="node0" noDrag="true" noSiblings="true" noDelete="true" noRename="true"><a href="#">Root node</a>
                                <ul>
                                    <li id="node1"><a href="#">Happy New Year</a></li>
                                    <li id="node2"><a href="#">Happy Birth Day</a></li>
                                    <li id="node3"><a href="#">Love</a></li>
                                    <li id="node4"><a href="#">TooMy</a></li>
                                    <li id="node5"><a href="#">Jibjawg</a></li>
                                    <li id="node6"><a href="#">Mour</a></li>
                                </ul>
                            </li>

                        </ul>
                        </div>
                        	<script type="text/javascript">
                        	    var treeDlgLoaded = false;
                        	    $(function () {
                        	        if (treeDlgLoaded == false) {
                        	            treeObj = new JSDragDropTree();
                        	            treeObj.setTreeId('dhtmlgoodies_tree2');
                        	            treeObj.setMaximumDepth(7);
                        	            treeObj.setMessageMaximumDepthReached('Maximum depth reached'); // If you want to show a message when maximum depth is reached, i.e. on drop.
                        	            treeObj.initTree();
                        	            treeObj.expandAll();
                        	            treeDlgLoaded = true;
                        	        }
                        	    });
	                        </script>