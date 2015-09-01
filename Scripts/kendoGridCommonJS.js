var selectedArray = [];

function selectMe(id) {
    var cb = $("#cb_" + jqSelector(id));
    var row = cb.parents('tr[role="row"]').first();
    if (cb.is(':checked')) {
        row.addClass('k-state-selected');
        var position = $.inArray(id.toString(), selectedArray);
        if (!~position) selectedArray.push(id.toString());
    } else {
        row.removeClass('k-state-selected');
        var position = $.inArray(id.toString(), selectedArray);
        if (~position) selectedArray.splice(position, 1);
    }

    synchSelectAll();
}

function synchSelectAll() {
    if ($("div[data-role=grid]").length == 0)
        return;

    var grid_id = $("div[data-role=grid]").attr('id');

    if ($('#' + grid_id + ' .kendo-selected-text').length == 0) {
        $("<span></span>").addClass("kendo-selected-text").insertAfter($('#' + grid_id + ' .k-pager-info.k-label'));
    }
    var selectedCountText = $("#" + grid_id + " .kendo-selected-text");

    if (selectedArray == null)
        selectedArray = [];

    var count = selectedArray.length; // do not modify variable name,because 'count' is in resource file
    if (count > 0) {
        selectedCountText.html("已選取 <label class='kendo-selected-count'>" + count + "</label> 筆");
    } else {
        selectedCountText.html("");
    }

    // 檢查單頁的check box 是否全部都勾選了
    if ($('#' + grid_id + " input[id^='cb_']").length > 0 && $('#' + grid_id + " input[id^='cb_']:not(:checked)").length == 0)
        $('#selectAll').prop("checked", true);
    else
        $('#selectAll').prop("checked", false);

}

function jqSelector(str) {
    return str.replace(/([;&,\.\+\*\~':"\!\^#$%@\[\]\(\)=>\|])/g, '\\$1'); ExportDataTable
}

function getKendoFilterData(grid_id) {
    var dataSource = $("#" + grid_id).data("kendoGrid").dataSource;
    var filters = dataSource.filter();
    var allData = dataSource.data();
    var query = new kendo.data.Query(allData);
    return query.filter(filters).data;
}

function kendoGridDataBound() {
    $('input[id^="cb_"]').each(function () {
        var cb = $(this);
        if ($.inArray(cb.val(), selectedArray) >= 0) { // inArray傳回的是index，若沒有找到回傳-1
            $(this).attr("checked", true);
            var row = cb.parents('tr[role="row"]').first();
            row.addClass('k-state-selected');
        }
    });

    kendoImageDataBound();
    synchSelectAll();
    kendoColumnMenu();
}

function kendoImageDataBound() {
    $("tbody").find("tr").hover(function () {
        $(this).find("i[class*=img_]").css("visibility", "visible");
    }, function () {
        $(this).find("i[class*=img_]").css("visibility", "hidden");
    });
}
function kendoColumnMenu() {
    $('.k-header-column-menu').removeClass('menu-show');
    $('.k-header-column-menu :last').addClass('menu-show');
}
var chagnedArray = []; //最後的狀態

function ChangeMe(id) {
    //alert(id);
    var cb = $("#cbEnable_" + id);
    //alert(cb);
    var reverseCb = cb.val();
    if (cb.val() == "true")
        reverseCb = "false";
    else
        reverseCb = "true";
    var position = $.inArray("cbEnable_" + id + "_" + cb.val(), chagnedArray);
    var pos2 = $.inArray("cbEnable_" + id + "_" + reverseCb, chagnedArray);
    if (pos2 > -1) {
        chagnedArray.splice(pos2, 1);
    }
    if (position > -1) {
        chagnedArray.splice(position, 1);
    }
    chagnedArray.push("cbEnable_" + id + "_" + cb.val());

}

function kendoChangeGridDataBound() {
    $('input[id^="cbEnable_SW_"]').each(function () {
        var cb = $(this);


        //alert(chagnedArray[$.inArray( cb.attr("id") + "_" + "true", chagnedArray)]);
        //alert(chagnedArray[$.inArray( cb.attr("id") + "_" + "false", chagnedArray)]);
        if ($.inArray(cb.attr("id") + "_true", chagnedArray) >= 0) { // inArray傳回的是index，若沒有找到回傳-1
            cb.val() == "true"
            cb.parent().find("div").addClass("on");
        } else if ($.inArray(cb.attr("id") + "_false", chagnedArray) >= 0) { // inArray傳回的是index，若沒有找到回傳-1
            cb.val() == "false"
            cb.parent().find("div").addClass("off");
        } else {
            if (cb.val() == "true")
                cb.parent().find("div").addClass("on");
            else
                cb.parent().find("div").addClass("off");
        }

    });

    kendoImageDataBound();
    kendoColumnMenu();
}

function selectAll() {
    if ($("div[data-role=grid]").length == 0) {
        alert("頁面上找不到表格");
        return;
    }

    var grid_id = $("div[data-role=grid]").attr('id');
    var checked = $('#selectAll').is(':checked');
    SetCheckedAll(grid_id, checked);
}

function SetCheckedAll(grid_id, checked) {
    // set all checkbox
    $.each($("#" + grid_id + " input[type=checkbox]"), function () {
        $(this).prop('checked', checked);
        var row = $(this).closest('tr');
        row.removeClass('k-state-selected');
        if (checked)
            row.addClass('k-state-selected');
    });

    var data = $("#" + grid_id).data("kendoGrid").dataSource.data();

    $.each(data, function () {
        var found = jQuery.inArray(this.id.toString(), selectedArray);
        if (checked) {
            if (found < 0) {
                selectedArray.push(this.id.toString());
            }
        }
        else {
            if (found >= 0) {
                selectedArray.splice(found, 1);
            }
        }
    });


    synchSelectAll();
}

function unselectAll() {
    // 清除所有已經選擇的資料
    selectedArray = [];

    // 取消所有input box按鈕狀態
    $('input:checkbox[id^="cb"]').prop('checked', false);

    // 取消顯示文字
    $(".kendo-selected-text").html("");
}

function ConvertEnumToDisplayName(enumStrings, labelPrefix, beginIndex) {
    var arrs = enumStrings.split(',');
    var types = $("label[id*=" + labelPrefix + "]");
    $.each(types, function (index, value) {
        var txt = $(value).text();
        if (txt != "null") {

            var idx = parseInt(txt);
            $(value).text(arrs[idx - beginIndex]);
        } else {
            $(value).text("");
        }
    });
}
function ConvertEnumToDisplayName(enumStrings, labelPrefix) {
    var arrs = enumStrings.split(',');

    var data = new Object();
    $.each(arrs, function (index, value) {
        //arrs.value : key|value|description
        data[value.split('|')[1]] = value.split('|');
    });

    var types = $("label[id*=" + labelPrefix + "]");
    $.each(types, function (index, value) {
        var txt = $(value).text();
        if (txt != "null") {
            if (data[txt] != null) {
                $(value).text(data[txt][2]);
            }
        }
        else {
            $(value).text("");
        }
    });
}

function ConvertEnumToDisplayNameByClass(enumStrings, className, beginIndex) {
    var arrs = enumStrings.split(',');
    var types = $("." + className);
    $.each(types, function (index, value) {
        var txt = $(value).text();
        if (txt != "null") {

            var idx = parseInt(txt);
            $(value).text(arrs[idx - beginIndex]);
        } else {
            $(value).text("");
        }
    });
}

function ConvertCheckBoxEnumToDisplayNameByClass(enumStrings, className, beginIndex) {
    var arrs = enumStrings.split(',');
    var types = $("." + className);
    $.each(types, function (index, value) {
        var txt = $(value).text();
        if (txt == "null") {
            $(value).text("");
            return;
        }
        if ($.isNumeric(txt)) {
            var dbValue = parseInt(txt);
            if (dbValue == 0) {   // 0代表沒選任何值
                $(value).text("");
                return;
            }
            var displayNames = [];
            for (var i = 0; i < arrs.length; i++) {
                if (Math.pow(2, parseInt(i)) & dbValue) {
                    displayNames.push(arrs[i]);
                }
            }
            $(value).text(displayNames.join(","));
        }
    });
}

function ConvertEnumToDisplayNameByJson(enumStrings, labelPrefix) {
    var objs = jQuery.parseJSON(enumStrings);

    var types = $("label[id*=" + labelPrefix + "]");
    $.each(types, function (index, value) {
        var txt = $(value).text();
        $.each(objs, function (index2, value2) {
            if (objs[index2].value == parseInt(txt)) {
                $(value).text(objs[index2].txt);
                return false;
            }
        });
    });
}

function ConvertBoolToDisplayName(labelPrefix, trueString, falseString) {
    var types = $("label[id*=" + labelPrefix + "]");
    $.each(types, function (index, value) {
        var txt = $(value).text();
        if (txt != "null") {
            if (txt.toLowerCase() == "true") {
                $(value).text(trueString);
            } else if (txt.toLowerCase() == "false") {
                $(value).text(falseString);
            }
        } else {
            $(value).text("");
        }
    });
}

function ConvertBoolToDisplayNameByClass(className, trueString, falseString) {
    var types = $("." + className);
    $.each(types, function (index, value) {
        var txt = $(value).text();
        if (txt.length == 0) {
            // do nothing
        } else if (txt == "true") {
            $(value).text(trueString);
        } else if (txt == "false") {
            $(value).text(falseString);
        } else if (txt == "null") {
            $(value).text("");
        }
    });
}

function ConvertDictionaryToDisplayName(dictionary, labelPrefix) {
    var types = $("label[id*=" + labelPrefix + "]");
    $.each(types, function (index, value) {
        var txt = $(value).text();
        if (txt != "null") {
            $(value).text(dictionary[txt]);
        } else {
            $(value).text("");
        }
    });
}

//計算GRID初始化的高度及最大高度
function resizeGrid(grid_id) {
    var grid_id = $("div[data-role=grid]").attr('id');
    var targetheight = $('#ActionTarget').height();
    var gridElement = $("#" + grid_id + "");
    dataArea = gridElement.find(".k-grid-content");    
    otherElements = gridElement.children().not(".k-grid-content");
        otherElementsHeight = 50;
    otherElements.each(function () {
        otherElementsHeight += $(this).outerHeight();
    });
    var rows = gridElement.find("tr[role=row]");
    
    var gridHeight = 320;//如果空資料的話,預設就是320
    if (rows != null && rows.last().height() != null && rows.last().height() > 0) {
        //小於十列的話，就留十列的空間
        if (rows.length > 10) {
            gridHeight = rows.last().height() * rows.length;
        } else {
            gridHeight = rows.last().height() * 10;
        }        
    }
    //如果Grid的內容會超過ActionTarget高度，最高就設為ActionTarget的高度
    if (gridHeight + otherElementsHeight > targetheight) {
        dataArea.height(targetheight - otherElementsHeight);
    } else {
        dataArea.height(gridHeight+1);//不能留剛剛好，剛剛好的話即使用不到scrollbar還是會enable
    }    
}

function onReadError(e)
{
    if (e.status > 400) {
        alert("read data error !");
        alert(e.errorThrown);
    }
}

function RowUp(e, grid_id, seqField) {
    var grid = $("#" + grid_id).data("kendoGrid");
    var myVar = grid.dataItem($(e).closest("tr"));
    var preVar = grid.dataItem($(e).closest("tr").prev("tr"));

    if (preVar === undefined) return;

    var tmp = myVar[seqField];
    myVar[seqField] = preVar[seqField];
    preVar[seqField] = tmp;

    grid.dataSource.sort({ field: seqField, dir: "asc" });
}

function RowDown(e, grid_id, seqField) {
    var grid = $("#" + grid_id).data("kendoGrid");
    var myVar = grid.dataItem($(e).closest("tr"));
    var nextVar = grid.dataItem($(e).closest("tr").next("tr"));

    if (nextVar === undefined) return;

    var tmp = myVar[seqField];
    myVar[seqField] = nextVar[seqField];
    nextVar[seqField] = tmp;

    grid.dataSource.sort({ field: seqField, dir: "asc" });
}
function detailLoad() {
    //因為tab header預設會套用k-header屬性，所以一但grid有reorderable，就會讓有套用k-header的區塊可以拖拉，
    //這邊要remove掉這個class
    $(".k-tabstrip").removeClass("k-header");
}