<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
    <script type="text/javascript">
        $(function () {
            // Dialog			
            $("#tabInbox").dialog({
                bgiframe: true,
                autoOpen: false,
                modal: true,
                width: 560,
                height: 400,
                buttons: {
                    "Cancel": function () {
                        $(this).dialog("close");
                    },
                    "Ok": function () {
                        $(this).dialog("close");
                    }
                }
            });
            // Dialog Link
            $("#Message").click(function () {
                $("#tabInbox").dialog("open");
                return false;
            });
        });
        $(function () {
            $("#tabInbox").tabs();
        });
</script>
 <%-- inbox--%>
  <script type="text/javascript">
      $(document).ready(function () {
          //slides the element with class "menu_body" when paragraph with class "menu_head" is clicked 
          $("#inboxpane p.menu_head").click(function () {
              $(this).css({ backgroundImage: "url(/Content/images/down.png)" }).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
              $(this).siblings().css({ backgroundImage: "url(/Content/images/left.png)" });
          });
      });
</script>
<%--outbox--%>
<script type="text/javascript">
    $(document).ready(function () {
        //slides the element with class "menu_body" when paragraph with class "menu_head" is clicked 
        $("#outboxpane p.menu_head").click(function () {
            $(this).css({ backgroundImage: "url(/Content/images/down.png)" }).next("div.menu_body").slideToggle(300).siblings("div.menu_body").slideUp("slow");
            $(this).siblings().css({ backgroundImage: "url(/Content/images/left.png)" });
        });
    });
</script>
<style type="text/css">
.menu_list {	
	width: 450px;
}
.menu_head {
	padding: 5px 0px;
	margin-left:5px;
	cursor: pointer;
	position: relative;
	margin:1px;
    font-weight:bold;
    background:#DBDCDD url(/Content/images/left.png) center right no-repeat;
}
.menu_body {
	display:none;
}
.menu_body a{
  display:block;
  color:#006699;
  background-color:#EFEFEF;
  padding-left:10px;
  text-decoration:inherit;
}
.menu_body a:hover{
  color: #000000;
  }
</style>

<div class="demo" style="display: none">
    <div id="tabInbox" title="Message InBox" style="padding-top: 5px;">
        <div>
            <ul>
                    <li><a href="#fragment-inbox"><span>Inbox</span></a></li>
                    <li><a href="#fragment-outbox"><span>Outbox</span></a></li>
                    <li><a href="#fragment-compose"><span>Compose</span></a></li>
                    <li><a href="#fragment-option"><span>Option</span></a></li>
            </ul>
        </div>
        <div id="fragment-inbox">
            <div id="Inbox">
                <div style="float:left" > <!--This is the first division of left-->
                  <div id="inboxpane" class="menu_list"> <!--Code for menu starts here-->
		                <p class="menu_head">Panuwat</p>
		                <div class="menu_body">
                        <a href="#">สนับสนุนโดย เลย์ใหม่ ใช้น้ำมันรำข้าวบริสุทธิ์ กับประโยชน์ดีๆ ถึง 3 ประการ
1. ลดไขมันอิ่มตัวลงถึง 50% ให้คุณอร่อยได้เต็มที่ 
2. มีสารโอรีซานอล ช่วยต่อต้านสารอนุมูลอิสระ และดีต่อผิวพรรณ
3. มีวิตามินอีสูง ช่วยรักษาสมดุลของระบบประสาทและสมอง </a>
		                </div>
		                <p class="menu_head">Wanida</p>
		                <div class="menu_body">
                        <a href="#">สนับสนุนโดย เลย์ใหม่ ใช้น้ำมันรำข้าวบริสุทธิ์ กับประโยชน์ดีๆ ถึง 3 ประการ
1. ลดไขมันอิ่มตัวลงถึง 50% ให้คุณอร่อยได้เต็มที่ 
2. มีสารโอรีซานอล ช่วยต่อต้านสารอนุมูลอิสระ และดีต่อผิวพรรณ
3. มีวิตามินอีสูง ช่วยรักษาสมดุลของระบบประสาทและสมอง </a>
		                </div>
		                <p class="menu_head">จิ๊บจัง</p>
		                <div class="menu_body">
                        <a href="#">สนับสนุนโดย เลย์ใหม่ ใช้น้ำมันรำข้าวบริสุทธิ์ กับประโยชน์ดีๆ ถึง 3 ประการ
1. ลดไขมันอิ่มตัวลงถึง 50% ให้คุณอร่อยได้เต็มที่ 
2. มีสารโอรีซานอล ช่วยต่อต้านสารอนุมูลอิสระ และดีต่อผิวพรรณ
3. มีวิตามินอีสูง ช่วยรักษาสมดุลของระบบประสาทและสมอง </a>
                       </div>
                       	<p class="menu_head">คภิตา</p>
		                <div class="menu_body">
                        <a href="#">สนับสนุนโดย เลย์ใหม่ ใช้น้ำมันรำข้าวบริสุทธิ์ กับประโยชน์ดีๆ ถึง 3 ประการ
1. ลดไขมันอิ่มตัวลงถึง 50% ให้คุณอร่อยได้เต็มที่ 
2. มีสารโอรีซานอล ช่วยต่อต้านสารอนุมูลอิสระ และดีต่อผิวพรรณ
3. มีวิตามินอีสูง ช่วยรักษาสมดุลของระบบประสาทและสมอง </a>
                       </div>

                  </div>  <!--Code for menu ends here-->
                </div>
            </div>
        </div>
        <div id="fragment-outbox">
            <div id="Outbox">
                 <div style="float:left" > <!--This is the first division of left-->
                  <div id="outboxpane" class="menu_list"> <!--Code for menu starts here-->
		                <p class="menu_head">Wanida</p>
		                <div class="menu_body">
                        <a href="#">aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa </a>
		                </div>
		                <p class="menu_head">Panuwat</p>
		                <div class="menu_body">
                        <a href="#">bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb </a>
		                </div>
		                <p class="menu_head">คภิตา</p>
		                <div class="menu_body">
                        <a href="#">ccccccccccccccccccccccccccccccccccccccccccccccccccccccc </a>
                       </div>
                       	<p class="menu_head">จิ๊บจัง</p>
		                <div class="menu_body">
                        <a href="#">dddddddddddddddddddddddddddddddddddddddddddddddddddddddd </a>
                       </div>

                  </div>  <!--Code for menu ends here-->
                </div>
            </div>
        </div>
        <div id="fragment-compose">
            <div id="Compose">
                <div><select><option>สุดหล่อ</option><option>สุดสวย</option><option>สุดน่ารัก</option></select></div>
                <div>Topic : <input type="text" style="width:380px;"/></div>
                <div><textarea rows="9" cols="76" style="margin-left:42px; overflow:hidden;"></textarea></div>
                <div><input type="checkbox" />save to outbox</div>
            </div>
        </div>
        <div id="fragment-option">
            <div id="OptionInbox">
                            <div>Who can access :</div>
                            <div><input type="radio" />All users</div>
                            <div><input type="radio" />My friend only</div>
                            <div><input type="radio" />Me only</div>

                            <div>Comment :</div>
                            <div><input type="radio" />All users read only</div>
                            <div><input type="radio" />All users can read & write</div>
                            <div><input type="radio" />My friend read only</div>
                            <div><input type="radio" />My friend can read & write</div>
                            <div><input type="radio" />Only me can write</div>

                            <div>Notification :</div>
                            <div><input type="radio" />All</div>
                            <div><input type="radio" />Only self related</div>
            </div>
        </div>
    </div>
</div>
