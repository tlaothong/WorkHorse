<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<script type="text/javascript">
    $(function () {
        $("#Option_Video").dialog({
            bgiframe: true,
            autoOpen: false,
            modal: true,
            width: 500,
            title: "Option",
            buttons: {
                "Save": function () {
                    $(this).dialog("close");
                },
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
        $("#Option_Click").click(function () {
            $("#Option_Video").dialog("open");
        });
        $(function () {
            $("#tabs").tabs();
        });
        $(function () {
            $(".slider").slider();
        });
        $(function () {
            $(".datepicker").datepicker();
        });
    });
</script>
<div id="Option_Video">
    <div>
        <label>
            Default Page</label><select><option>Most Views</option>
                <option>low Views</option>
                <option>Most Views</option>
            </select>
    </div>
    <div>
        <label>
            Sorting Order</label><select><option>Most Views</option>
                <option>low Views</option>
            </select>
    </div>
    <div>
        <label>
            Default Advance Search</label><select><option>All</option>
                <option>Most Views</option>
            </select>
    </div>
    <div>
        <div id="tabs">
            <ul>
                <li><a href="#tabs-1">1</a></li>
                <li><a href="#tabs-2">2</a></li>
                <li><a href="#tabs-3">3</a></li>
            </ul>
            <div id="tabs-1">
                <div>
                    <label>
                        Name</label><input type="text" value="Some search text here" />
                    <input type="checkbox" /><label>within result</label>
                </div>
                <div>
                    Tags</div>
                <div>
                    <label>
                        Author</label><input type="text" value="authors" /></div>
                <div>
                    <input type="checkbox" /><label>approved content</label></div>
                <div class="demo">
                    <div>
                        <label>
                            View</label><div class="slider">
                            </div>
                        <label>
                            Rating</label><div class="slider">
                            </div>
                        <label>
                            Discussed</label><div class="slider">
                            </div>
                    </div>
                </div>
                <div>
                    <label>
                        Time Posted</label><input type="text" class="datepicker" />-<input type="text" class="datepicker" />
                </div>
                <div>
                    <label>
                        Type</label><select><option>All</option>
                            <option>someone</option>
                        </select>
                </div>
                <div>
                    <label>
                        Length</label><select><option>All</option>
                            <option>someone</option>
                        </select>
                </div>
            </div>
            <div id="tabs-2">
            </div>
            <div id="tabs-3">
            </div>
        </div>
    </div>
</div>
