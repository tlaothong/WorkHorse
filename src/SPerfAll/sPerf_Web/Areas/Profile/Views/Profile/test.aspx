<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	test
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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
                        <ul id="dhtmlgoodies_tree2" class="dhtmlgoodies_tree">
                            <li id="node0" noDrag="true" noSiblings="true" noDelete="true" noRename="true"><a href="#">Root node</a>
                                <ul>
                                    <li id="node1"><a href="#">Europe</a>
                                            <ul>
						                        <li id="node2" noDelete="true"><a href="#">Norway</a>
							                        <ul>
								                        <li id="node3" noRename="true"><a href="#">Stavanger</a></li>
								                        <li id="node6"><a href="#">Bergen</a></li>
								                        <li id="node7"><a href="#">Oslo</a></li>
							                        </ul>
						                        </li>
						                        <li id="node8"><a href="#">United Kingdom</a>
							                        <ul>
								                        <li id="node9"><a href="#">London</a></li>
								                        <li id="node10"><a href="#">Manchester</a></li>
							                        </ul>				
						                        </li>
						                        <li id="node12"><a href="#">Sweden</a></li>
						                        <li id="node13"><a href="#">Denmark</a></li>
						                        <li id="node14"><a href="#">Germany</a>
							                        <ul>
								                        <li id="node141"><a href="#">Berlin</a>	
								                        <li id="node142"><a href="#">Munich</a>	
								                        <li id="node143"><a href="#">Stuttgart</a>	
							                        </ul>
						                        </li>
					                        </ul>
                                    </li>
                                </ul>
                            </li>

                        </ul>
                        <form>
	<input type="button" onclick="saveMyTree()" value="Save"/>
</form>

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
                            <a href="#" onclick="treeObj.collapseAll()">Collapse all</a> | 
	<a href="#" onclick="treeObj.expandAll()">Expand all</a>
	<!-- Form - if you want to save it by form submission and not Ajax -->
<form name="myForm" method="post" action="/saveNodes.php">
		<input type="hidden" name="saveString">
</form>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SubMenu" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="SideBar" runat="server">
</asp:Content>
