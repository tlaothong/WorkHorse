<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<link href="../../../../Content/drag-drop-folder-tree.css" rel="stylesheet" type="text/css" />
<link href="../../../../Content/context-menu.css" rel="stylesheet" type="text/css" />
<script src="../../../../Scripts/ajax.js" type="text/javascript"></script>
<script src="../../../../Scripts/drag-drop-folder-tree.js" type="text/javascript"></script>
<script src="../../../../Scripts/context-menu.js" type="text/javascript"></script>

<style type="text/css">
	img{
		border:0px;
	}
	</style>


<style type="text/css">
	
	#ajaxMessage{
		margin-top:10px;
		font-size:0.9em;
		color:red;
	
	}
	#expandCollapse{
		font-size:0.9em;
	}
	#dhtmlgoodies_tree{
		margin:0px;
		padding:0px;
		margin-left:10px;
	}
	#dhtmlgoodies_tree ul{	/* Sub menu groups */
		margin-left:20px;	/* Left spacing */
		padding-left:0px;
		display:none;	/* Initially hide sub nodes */
	}
	#dhtmlgoodies_tree li{	/* Nodes */
		list-style-type:none;
		vertical-align:middle;
		
	}
	#dhtmlgoodies_tree li a{	/* Node links */
		color:#000;
		text-decoration:none;
		font-family:arial;
		font-size:0.8em;
		padding-left:2px;
	}
	#dhtmlgoodies_tree input{
		font-size:0.9em;
		font-family:arial;
	}
	</style>

    
	<script type="text/javascript">
	    var dhtmlgoodies_tree;
	    var imageFolder = '/images/'; // Path to images
	    var folderImage = 'folder.gif';
	    var plusImage = 'plus.gif';
	    var minusImage = 'minus.gif';
	    var initExpandedNodes = ''; // Cookie - initially expanded nodes;
	    var fileName = 'updateNode.php'; // External file called by AJAX	
	    var timeoutEdit = 20; // Lower value = shorter delay from mouse is pressed down to textbox appears.
	    var ajax = new sack();

	    function Get_Cookie(name) {
	        var start = document.cookie.indexOf(name + "=");
	        var len = start + name.length + 1;
	        if ((!start) && (name != document.cookie.substring(0, name.length))) return null;
	        if (start == -1) return null;
	        var end = document.cookie.indexOf(";", len);
	        if (end == -1) end = document.cookie.length;
	        return unescape(document.cookie.substring(len, end));
	    }
	    // This function has been slightly modified
	    function Set_Cookie(name, value, expires, path, domain, secure) {
	        expires = expires * 60 * 60 * 24 * 1000;
	        var today = new Date();
	        var expires_date = new Date(today.getTime() + (expires));
	        var cookieString = name + "=" + escape(value) +
	       ((expires) ? ";expires=" + expires_date.toGMTString() : "") +
	       ((path) ? ";path=" + path : "") +
	       ((domain) ? ";domain=" + domain : "") +
	       ((secure) ? ";secure" : "");
	        document.cookie = cookieString;
	    }

	    function expandAll() {
	        var menuItems = dhtmlgoodies_tree.getElementsByTagName('LI');
	        for (var no = 0; no < menuItems.length; no++) {
	            var subItems = menuItems[no].getElementsByTagName('UL');
	            if (subItems.length > 0 && subItems[0].style.display != 'block') {
	                showHideNode(false, menuItems[no].id.replace(/[^0-9]/g, ''));
	            }
	        }
	    }

	    function collapseAll() {
	        var menuItems = dhtmlgoodies_tree.getElementsByTagName('LI');
	        for (var no = 0; no < menuItems.length; no++) {
	            var subItems = menuItems[no].getElementsByTagName('UL');
	            if (subItems.length > 0 && subItems[0].style.display == 'block') {
	                showHideNode(false, menuItems[no].id.replace(/[^0-9]/g, ''));
	            }
	        }
	    }

	    function showHideNode(e, inputId) {
	        if (inputId) {
	            if (!document.getElementById('dhtmlgoodies_treeNode' + inputId)) return;
	            thisNode = document.getElementById('dhtmlgoodies_treeNode' + inputId).getElementsByTagName('IMG')[0];
	        } else {
	            thisNode = this;
	        }
	        if (thisNode.style.visibility == 'hidden') return;
	        var parentNode = thisNode.parentNode;
	        inputId = parentNode.id.replace(/[^0-9]/g, '');
	        if (thisNode.src.indexOf('plus') >= 0) {
	            thisNode.src = thisNode.src.replace('plus', 'minus');
	            parentNode.getElementsByTagName('UL')[0].style.display = 'block';
	            if (!initExpandedNodes) initExpandedNodes = ',';
	            if (initExpandedNodes.indexOf(',' + inputId + ',') < 0) initExpandedNodes = initExpandedNodes + inputId + ',';

	        } else {
	            thisNode.src = thisNode.src.replace('minus', 'plus');
	            parentNode.getElementsByTagName('UL')[0].style.display = 'none';
	            initExpandedNodes = initExpandedNodes.replace(',' + inputId, '');
	        }
	        Set_Cookie('dhtmlgoodies_expandedNodes', initExpandedNodes, 500);
	    }

	    function okToNavigate() {
	        if (editCounter < 10) return true;
	        return false;
	    }

	    var editCounter = -1;
	    var editEl = false;

	    function initEditLabel() {
	        if (editEl) hideEdit();
	        editCounter = 0;
	        editEl = this; // Referenc to a Tag
	        startEditLabel();
	    }

	    function startEditLabel() {
	        if (editCounter >= 0 && editCounter < 10) {
	            editCounter = editCounter + 1;
	            setTimeout('startEditLabel()', timeoutEdit);
	            return;
	        }
	        if (editCounter == 10) {
	            var el = editEl.previousSibling;
	            el.value = editEl.innerHTML;
	            editEl.style.display = 'none';
	            el.style.display = 'inline';
	            el.select();
	            return;
	        }
	    }

	    function showUpdate() {
	        document.getElementById('ajaxMessage').innerHTML = ajax.response;
	    }

	    function hideEdit() {
	        var editObj = editEl.previousSibling;
	        if (editObj.value.length > 0) {
	            editEl.innerHTML = editObj.value;
	            ajax.requestFile = fileName + '?updateNode=' + editObj.id.replace(/[^0-9]/g, '') + '&newValue=' + editObj.value; // Specifying which file to get
	            ajax.onCompletion = showUpdate; // Specify function that will be executed after file has been found
	            ajax.runAJAX(); 	// Execute AJAX function

	        }
	        editEl.style.display = 'inline';
	        editObj.style.display = 'none';
	        editEl = false;
	        editCounter = -1;
	    }

	    function mouseUpEvent() {
	        editCounter = -1;
	    }

	    function initTree() {
	        dhtmlgoodies_tree = document.getElementById('dhtmlgoodies_tree');
	        var menuItems = dhtmlgoodies_tree.getElementsByTagName('LI'); // Get an array of all menu items
	        for (var no = 0; no < menuItems.length; no++) {
	            var subItems = menuItems[no].getElementsByTagName('UL');
	            var img = document.createElement('IMG');
	            img.src = imageFolder + plusImage;
	            img.onclick = showHideNode;
	            if (subItems.length == 0) img.style.visibility = 'hidden';
	            var aTag = menuItems[no].getElementsByTagName('A')[0];

	            if (aTag.id) numericId = aTag.id.replace(/[^0-9]/g, ''); else numericId = (no + 1);

	            aTag.id = 'dhtmlgoodies_treeNodeLink' + numericId;

	            var input = document.createElement('INPUT');
	            input.style.width = '200px';
	            input.style.display = 'none';
	            menuItems[no].insertBefore(input, aTag);
	            input.id = 'dhtmlgoodies_treeNodeInput' + numericId;
	            input.onblur = hideEdit;

	            menuItems[no].insertBefore(img, input);
	            menuItems[no].id = 'dhtmlgoodies_treeNode' + numericId;
	            aTag.onclick = okToNavigate;
	            aTag.onmousedown = initEditLabel;
	            var folderImg = document.createElement('IMG');
	            if (menuItems[no].className) {
	                folderImg.src = imageFolder + menuItems[no].className;
	            } else {
	                folderImg.src = imageFolder + folderImage;
	            }
	            menuItems[no].insertBefore(folderImg, input);
	        }

	        initExpandedNodes = Get_Cookie('dhtmlgoodies_expandedNodes');
	        if (initExpandedNodes) {
	            var nodes = initExpandedNodes.split(',');
	            for (var no = 0; no < nodes.length; no++) {
	                if (nodes[no]) showHideNode(false, nodes[no]);
	            }
	        }

	        document.documentElement.onmouseup = mouseUpEvent;
	    }

	    window.onload = initTree;	
	</script>

    <ul id="dhtmlgoodies_tree">
		 
              <li class="sheet.gif"><a href="colum1.php" target="_blank" id="node19">ข่าวปกโลกวันนี้</a></li>
			  <li class="sheet.gif"><a href="columblank3.php?colum_name=คำต่อคำ..ทักษิณ" target="_blank" id="node19">คำต่อคำ..ทักษิณ</a></li>
			  <li id="node19"><a href="colum2.php" target="_blank">ทรรศนะ</a>
			  <ul>
			    <li class="sheet.gif"><a href="columblank3.php?colum_name=บทบรรณาธิการ" target="_blank">บทบรรณาธิการ</a>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=สำนัก(ข่าว)พระพยอม" target="_blank">สำนัก(ข่าว)พระพยอม</a>	
				<li class="sheet.gif"><a href="columblank3.php?colum_name=คิดเหนือข่าว" target="_blank">คิดเหนือข่าว</a>
                <li class="sheet.gif"><a href="columblank3.php?colum_name=เป็นประชารัฐ" target="_blank">เป็นประชารัฐ</a>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ฉุก(ละหุก)คิด" target="_blank">ฉุก(ละหุก)คิด</a>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=โต๊ะกลมระดมความคิด" target="_blank">โต๊ะกลมระดมความคิด</a>
                <li class="sheet.gif"><a href="columblank3.php?colum_name=ทรรศนะการเมือง" target="_blank">ทรรศนะการเมือง</a>
                <li class="sheet.gif"><a href="columblank3.php?colum_name=ยิ่งเกายิ่งคัน" target="_blank">ยิ่งเกายิ่งคัน</a>
			    </ul>
				</li>
				<li id="node19"><a href="colum3.php" target="_blank">ในประเทศ</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าว(ในประเทศ)" target="_blank">ข่าวในประเทศ</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=คำต่อคำ" target="_blank">คำต่อคำ</a></li>
				</ul>
				</li>
				<li id="node19"><a href="colum4.php" target="_blank">ต่างประเทศ</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าว(ต่างประเทศ)" target="_blank">ข่าวต่างประเทศ</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=หมุนทันโลก" target="_blank">หมุนทันโลก</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=คิดทันโลก" target="_blank">คิดทันโลก</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=โลกไม่หยุดนิ่ง" target="_blank">โลกไม่หยุดนิ่ง</a></li>
				</ul>		
				</li>	
                <li id="node19"><a href="colum5.php" target="_blank">กีฬา</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าว(กีฬา)" target="_blank">ข่าวกีฬา</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าวล่ากีฬาโลก" target="_blank">ข่าวล่ากีฬาโลก</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=Sport Focus" target="_blank">Sport Focus</a></li>
				</ul>		
				</li>	
                <li id="node19"><a href="colum6.php" target="_blank">ธุรกิจ-ลงทุน</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าว(ธุรกิจ)" target="_blank">ข่าวธุรกิจ-ลงทุน</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=รายงาน" target="_blank">รายงาน</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=กรองข่าว" target="_blank">กรองข่าว</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=คลุกวงใน" target="_blank">คลุกวงใน</a></li>
                <li class="sheet.gif"><a href="columblank3.php?colum_name=Hotline Business" target="_blank">Hotline Business</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=จับกระแสธุรกิจ" target="_blank">จับกระแสธุรกิจ</a></li>
				</ul>		
				</li>	
                <li id="node19"><a href="colum7.php" target="_blank">หลักทรัพย์-การเงิน</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าว(การเงิน-ลงทุน)" target="_blank">ข่าวหลักทรัพย์-การเงิน</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ส่องหุ้น" target="_blank">ส่องหุ้น</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ฟันธงหุ้น" target="_blank">ฟันธงหุ้น</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=รอบรู้หุ้น-การเงิน" target="_blank">รอบรู้หุ้น-การเงิน</a></li>
                <li class="sheet.gif"><a href="columblank3.php?colum_name=กระแสทุน" target="_blank">กระแสทุน</a></li>
				</ul>		
				</li>	
                <li id="node19"><a href="colum8.php" target="_blank">เศรษฐกิจโลก</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าว(เศรษฐกิจโลก)" target="_blank">ข่าวเศรษฐกิจโลก</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ย่อโลกเศรฐกิจ" target="_blank">ย่อโลกเศรฐกิจ</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=Business World" target="_blank">Business World</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=China Today" target="_blank">China Today</a></li>
				</ul>		
				</li>
                <li id="node19"><a href="colum9.php" target="_blank">โลกนวัตกรรม</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าว(โลกนวัตกรรม)" target="_blank">ข่าวโลกนวัตกรรม</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ย่อโลก" target="_blank">ย่อโลก</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=IT Update" target="_blank">IT Update</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ล็อกอิน" target="_blank">ล็อกอิน</a></li>
                <li class="sheet.gif"><a href="columblank3.php?colum_name=เปิดโลกสื่อสารไอที" target="_blank">เปิดโลกสื่อสารไอที</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=โลกเทคโนโลยี" target="_blank">โลกเทคโนโลยี</a></li>
				</ul>		
				</li>	
                <li id="node19"><a href="colum10.php" target="_blank">อสังหาริมทรัพย์</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าว(อสังหาริมทรัพย์)" target="_blank">ข่าวอสังหาริมทรัพย์</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=Open Condo" target="_blank">Open Condo</a></li>
				</ul>		
				</li>	
                <li id="node19"><a href="colum11.php" target="_blank">รถยนต์</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าวรถในประเทศ" target="_blank">ข่าวรถในประเทศ</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ข่าวรถต่างประเทศ" target="_blank">ข่าวรถต่างประเทศ</a></li>
				</ul>		
				</li>
                <li id="node19"><a href="colum12.php" target="_blank">ท่องเที่ยว</a>
				<ul>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ท่องเที่ยวในประเทศ" target="_blank">ท่องเที่ยวในประเทศ</a></li>
				<li class="sheet.gif"><a href="columblank3.php?colum_name=ท่องเที่ยวต่างประเทศ" target="_blank">ท่องเที่ยวต่างประเทศ</a></li>
				</ul>		
				</li>
</ul>
 
<script type="text/javascript">
    treeObj = new JSDragDropTree();
    treeObj.setTreeId('dhtmlgoodies_tree2');
    treeObj.setMaximumDepth(7);
    treeObj.setMessageMaximumDepthReached('Maximum depth reached');
</script>