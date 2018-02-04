

//To pull all assigned assets on a location
$(document.body).on("change", "#LocationId", function () {

    var locationId = $("#LocationId").val();
    if (locationId != undefined && locationId != "") {
        var json = { id: locationId }

        $("#AuditTable > tr").remove();
        var serialNo = 1;

        $.ajax({
            type: "POST",
            url: "/Audits/SearchAssetByLocationId",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(json),
            success: function (data) {
            $.each(data, function (key, value) {
                $("#AuditTable").append(
                    "<tr>"
                    + "<td>" + serialNo++ + "</td>"
                    + "<td>" + value.AssetNo + "</td>"
                    + "<td>" + value.Name + "</td>"
                    + "<td>" + value.EmployeeName + "</td>"
                    + "<td>" + '<button id=' + value.AssetEntryId + ' data-target="#auditModal" data-toggle="modal" type="button" class="" title="" onclick= SelectedAssetEntryId(this)><span class="glyphicon glyphicon-list"></span></button>' + "</td>"
                    + "<td style='display:none'>" + value.AssetEntryId + "</td>"
                    + "</tr>");
                });
             }
        });
    }
});

function SelectedAssetEntryId(selectedElement) {
    var requiredId = $(selectedElement).attr('id');
    $("#AssetEntryId").val(requiredId);
    $(selectedElement).attr('class', 'listBtn');
    $(selectedElement).attr('title', 'Already Done');
    //alert(requiredId);
}


$(document.body).on("click", "#Save", function () {
    var assetOk;
    var assetOnLocation;
    var assetUnderCustodian;
    if ($("#AssetOk").is(':checked')) {
        assetOk = true;
    } else {
        assetOk = false;
    }
    if ($("#AssetOnLocation").is(':checked')) {
        assetOnLocation = true;
    } else {
        assetOnLocation = false;
    }
    if ($("#AssetUnderCustodian").is(':checked')) {
        assetUnderCustodian = true;
    } else {
        assetUnderCustodian = false;
    }
    var comment = $("#Comment").val();
    var auditDate = $("#AuditDate").val();
    var locationId = $("#LocationId").val();
    var assetEntryId = $("#AssetEntryId").val();

    var jsonData = { AssetEntryId: assetEntryId, locationId: locationId, auditDate: auditDate, comment: comment, assetUnderCustodian: assetUnderCustodian, assetOnLocation: assetOnLocation, assetOk: assetOk };


    $.ajax({
        type: "POST",
        url: "/Audits/AuditDataSave",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(jsonData),
        success: function (data) {
            if (data != null) {
                $("#successMessage").html("Saved successfully!!").css({ "background": "greenyellow", "color": "black" }).show('fade');
                $("#Save").attr("disabled", true);
                $("#modalForm").trigger("reset");
                
                //Sweet Alert
                swal({
                    position: 'top-right',
                    type: 'success',
                    title: 'Saved successfully!!',
                    showConfirmButton: false,
                    timer: 2000
                });

                $(".listBtn").find(".glyphicon").remove();
                $(".listBtn").prop("disabled", true)
                             .prepend('<span class="glyphicon glyphicon-ok" style="color:red"></span>');

                //$(".listBtn").find(".glyphicon").removeClass("glyphicon-ok");
                //$(".listBtn").prop("disabled", true)
                //             .prepend('<span class="glyphicon glyphicon-ok" style="color:red"></span>');
            }
        }
    });
});

//To enable save button and hide Success Message
$(document.body).on("click", "#Close", function () {
    $("#Save").attr("disabled", false);
    $("#successMessage").hide();
});

