/////////////////////////////////////////////////////////////////
//For loading partial page and for cancel button
$(document.body).on("click", "#financeTab, #cancelButtonFinance", function () {

    var url = "/AssetEntries/AssetEditFinancePartial";
    $.get(url, function (responseData) {
        $("#assetEditPartialDiv").html(responseData);
    });

});

$(document.body).on("click", "#serviceTab, #cancelButtonService", function () {

    var url = "/AssetEntries/AssetEditServicePartial";
    var param = { id: $("#Id").val() }
    $.get(url, param, function (responseData) {
        $("#assetEditPartialDiv").html(responseData);
    });

});

$(document.body).on("click", "#attachmentTab", function () {

    var url = "/Home/AssetEditAttachmentPartial";
    $.get(url, function (responseData) {
        $("#assetEditPartialDiv").html(responseData);
    });

});


$(document.body).on("click", "#historyTab", function () {

    var url = "/AssetEntries/AssetEditHistoryPartial";
    var param = {id:$("#Id").val()}
    $.get(url, param, function (responseData) {
        $("#assetEditPartialDiv").html(responseData);
    });
});

$(document.body).on("click", "#notesTab, #cancelButtonNotes", function () {

    var url = "/AssetEntries/AssetEditNotesPartial";
    $.get(url, function (responseData) {
        $("#assetEditPartialDiv").html(responseData);
    });

});




///////////////////////////////////////////////////////////////////////////

////For Attachment Partial
//$(document.body).on("change", "#fileUpload", function () {
//    $('#saveButtonAttachment').attr('disabled', false);
//});

//$('#saveButtonAttachment').click(function () {
//    $("#successMessageAttachment").html("Saved successfully!!").css({ "background": "greenyellow" }).fadeIn(2000).fadeOut(2000);

//    $(":file").val('');
//    $('#saveButtonAttachment').attr('disabled', true);
//    return false;
//});



//For Attachment Partial
$(document.body).on("change", "#fileUpload", function () {
    $('#saveButtonAttachment').attr('disabled', false);
});

$('#saveButtonAttachment').click(function () {
    var id = $("#Id").val();
    var formData = new FormData();
    var totalFiles = document.getElementById("fileUpload").files.length;
    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("fileUpload").files[i];

        formData.append("fileUpload", file);
    }

    var jsonData = { AssetEntryId: id, File: formData };

    $.ajax({
        type: "POST",
        url: '/AssetEntries/Upload',
        data: JSON.stringify(jsonData),
        processData: false,
        contentType: "multipart/mixed",
        success: function (response) {
            alert('succes!!');
        },
        error: function (error) {
            alert("errror");
        }
    });
});




//For Finance Partial
$(document.body).on("click", "#saveButtonFinance", function () {

    var vendorId = $("#VendorId option:selected").val();
    var purchasePrice = $("#PurchasePrice").val();
    var pONo = $("#PONo").val();
    var purchaseDate = $("#PurchaseDate").val();
    var id = $("#Id").val();
    var jsonData = { AssetEntryId: id, vendorId: vendorId, purchasePrice: purchasePrice, pONo: pONo, purchaseDate: purchaseDate };

    if (vendorId != '' && purchasePrice != '' && pONo != '' && purchaseDate != '') {
        $.ajax({
            type: "POST",
            url: "/AssetEntries/AddFinance",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            success: function (data) {
                if (data != null) {
                    $("#successMessageFinance").html("Saved successfully!!").css({ "background": "greenyellow", "color": "black" }).show('fade');
                    
                    setTimeout(function () {
                        $("#successMessageFinance").hide('fade');
                    }, 3000);
                    
                } else {
                    $("#successMessageFinance").html("Save Failed. Please try again!!").css({ "background": "red" }).fadeIn(2000);
                }
            }
        });

    } else {
        $("#successMessageFinance").html("Please fill all fields properly!!").css({ "background": "yellow", "color": "red" }).show();
    }
});




//For Datepicker for service and finance partial
$(document).ready(function () {
    $("#ServiceDate, #PurchaseDate").datepicker({
        dateFormat: 'm/dd/yy'
    });
});


//For Service Partial
$(document.body).on("click", "#saveButtonService", function () {
    var description = $("#Description").val();
    var serviceingCost = $("#ServiceingCost").val();
    var serviceDate = $("#ServiceDate").val();
    var partsCost = $("#PartsCost").val();
    var serviceBy = $("#ServiceBy").val();
    var tax = $("#Tax").val();
    var id = $("#Id").val();
    var jsonData = { AssetEntryId: id, description: description, serviceingCost: serviceingCost, serviceDate: serviceDate, partsCost: partsCost, serviceBy: serviceBy, tax: tax };


    if ($("#Description").val() != '' && $("#ServiceingCost").val() != '' && $("#ServiceDate").val() != '' && $("#PartsCost").val() != '' && $("#ServiceBy").val() != '' && $("#Tax").val() != '') {

        $.ajax({
            type: "POST",
            url: "/AssetEntries/AddServices",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            success: function (data) {
                if (data != null) {
                    $("#successMessageService").html("Saved successfully!!").css({ "background": "greenyellow", "color": "black" }).show('fade');

                    setTimeout(function () {
                        $("#successMessageService").hide('fade');
                    }, 3000);

                    //To show current saved row in table
                    //document.location.reload(true);
                    $('.nav').find('#serviceTab').trigger('click');

                } else {
                    $("#successMessageService").html("Save Failed. Please try again!!").css({ "background": "red" }).fadeIn(2000);
                }
            }
        });

    } else {
        $("#successMessageService").html("Please fill all fields properly!!").css({ "background": "yellow", "color": "red" }).show();
    }
    
});




//For Notes Partial
$(document.body).on("click", "#saveButtonNotes", function () {
    var assetEntryNotes = $("#AssetEntryNotes").val();
    var id = $("#Id").val();
    var jsonData = { AssetEntryId: id, assetEntryNotes: assetEntryNotes };

    if (assetEntryNotes != "" && assetEntryNotes != undefined) {

        $.ajax({
            type: "POST",
            url: "/AssetEntries/AddNotes",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            success: function (data) {
                if (data.AssetEntryNotes != null) {
                    $("#successMessageNotes").html("Saved successfully!!").css({ "background": "greenyellow", "color": "black" }).show('fade');
                    $("#AssetEntryNotes").val("");

                    setTimeout(function() {
                        $("#successMessageNotes").hide('fade');
                    },3000);
                } else {
                    $("#successMessageNotes").html("Save Failed. Please try again!!").css({ "background": "red" }).fadeIn(2000);
                }
            }
        });
    } else {
        $("#successMessageNotes").html("Notes field is empty!!").css({ "background": "yellow", "color": "red" }).show();
    }

});





