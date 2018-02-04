
//DatePicker & Live-search option
$(document).ready(function () {
    $("#DueDate").datepicker({
        dateFormat: 'm/dd/yy'
    });

    //To enable Live-search option
    $("#empIdCheckOut, #CheckOutFor, #assetName").prop('class', 'selectpicker show-tick form-control').attr('data-live-search', true).attr('data-live-search-style', startsWith);
});


//////////////////////////////////////////////////////////////////////////////////////////////

$(document.body).on("click", "#addBtn", function () {
    if ($("#assetName").val() != undefined && $("#assetName").val() != "") {
        addRowForAsset();
    }
});


function addRowForAsset() {
    var index = $("#assetTable").children("tr").length;
    var selectedAsset = GetSelectedAsset();

    var indexCell = "<td style='display:none'><input name='Index_" + index + "' type='hidden' value='" + index + "' /></td>";
    var serialCell = "<td><label id='Asset_" + index + "_Serial'  value='" + (index + 1) + "' />" + (index + 1) + "</td>";
    var assetNoCell = "<td><input type='hidden' id='CheckOutAssetLists" + index + "Name' name='CheckOutAssetLists[" + index + "].AssetNo' value='" + selectedAsset.AssetNo + "' />" + selectedAsset.AssetNo + "</td>";
    var nameCell = "<td><input type='hidden' id='CheckOutAssetLists" + index + "Name' name='CheckOutAssetLists[" + index + "].Name' value='" + selectedAsset.AssetName + "' />" + selectedAsset.AssetName + "</td>";
    var assetIdCell = "<td style='display:none'><input type='hidden' id='CheckOutAssetLists" + index + "Name' name='CheckOutAssetLists[" + index + "].AssetEntryId' value='" + selectedAsset.AssetId + "' />" + selectedAsset.AssetId + "</td>";
    

    var newRow = "<tr id='row_" + index + "'>" + indexCell + serialCell + assetNoCell + nameCell + assetIdCell+ "</tr>";

    $("#assetTable").append(newRow);
}


function GetSelectedAsset() {
    var assetId = $("#assetName option:selected").val();
    var assetName = $("#assetName option:selected").text();

    var assetNo = $("#AssetNo").val();

    var assetObj = {
        "AssetId": assetId,
        "AssetName": assetName,
        "AssetNo": assetNo
    }
    return assetObj;
}


/////////////////////////////////////////////////////////////////////////////////////////////////////

//Using to pull asset No  
$(document.body).on("change", "#assetName", function () {
    var assetId = $("#assetName option:selected").val();
    $.ajax({
        type: "POST",
        url: "/CascadingDropdowns/GetAssetNoById",
        data: { id: assetId },
        success: function (data) {
            $("#AssetNo").val(data);
        }
    });
});

    


//Employee code pull
$(document.body).on("change", "#empIdCheckOut", function () {

    var empIdCheckOut = $("#empIdCheckOut").val();
    if (empIdCheckOut != undefined && empIdCheckOut != "") {

        $.ajax({
            type: "GET",
            url: "/CascadingDropdowns/GetEmployeeCodeById",
            data: { id: empIdCheckOut },
            success: function(data) {
                $("#empNumberCheckOut").val(data);
                $("#empNumberCheckOut").prop('readonly', true);
            }
        });
    } else {
        $("#empNumberCheckOut").val("");
    }
});




///////////////////////////////////////////////////////////////////////////////////////
//For Location field and Location partial

$(document).ready(function () {
    $("#LocationId").append($('<option/>', { value: "-1", text: 'Others' }));
});



$(document.body).on("change", "#LocationId", function () {
    var locationId = $("#LocationId").val();
    
    if (locationId == "-1") {

        //Partial calling
        var url = "/CheckOuts/LocationAddPartial";
        $.get(url, function(responseData) {
            $("#locationDiv").html(responseData).show();
        });
    } else {
        $("#locationDiv").hide();
    }
});



$(document.body).on("change", "#LocationName", function () {
    $("#LocationId").html("");
    var selectedLocation = $.trim($("#LocationName").val());
    if (selectedLocation != '' && selectedLocation != undefined) {
        $("#LocationId").append($('<option/>', { value: "-2", text: selectedLocation }));
    }
});

////////////////////////////////////////////////////////////////////////////////////////////////////////////