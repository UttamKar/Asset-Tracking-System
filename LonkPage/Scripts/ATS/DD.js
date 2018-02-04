
//For Asset Entry Page
$(document.body).on("change", "#BranchAssetEntry", function () {

    var branchAssetEntry = $("#BranchAssetEntry").val();
    if (branchAssetEntry != undefined && branchAssetEntry != "") {
        var json = { id: branchAssetEntry }

        $("#LocationAssetEntry").empty();

        $.ajax({
            type: "POST",
            url: "/CascadingDropdowns/GetLocations",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(json),
            success: function (data) {
                $("#LocationAssetEntry").append($('<option/>', { value: "", text: 'Select Location' }));
                $.each(data, function (key, value) {
                    $("#LocationAssetEntry").append("<option value=" + value.Id + ">" + value.Name + "</option>");
                });
            }
        });
    }
});


//For Asset Entry Page
$(document.body).on("change", "#AssetTypeAssetEntry", function () {

    var assetTypeAssetEntry = $("#AssetTypeAssetEntry").val();
    if (assetTypeAssetEntry != undefined && assetTypeAssetEntry != "") {
        var json = { id: assetTypeAssetEntry }

        $("#AssetGroupAssetEntry").empty();
        $("#ManufacturerAssetEntry").empty();
        $("#ModelAssetEntry").empty();

        $.ajax({
            type: "POST",
            url: "/CascadingDropdowns/GetAssetGroups",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(json),
            success: function (data) {
                $("#AssetGroupAssetEntry").append($('<option/>', { value: "", text: 'Select Asset Group' }));
                $.each(data, function (key, value) {
                    $("#AssetGroupAssetEntry").append("<option value=" + value.Id + ">" + value.Name + "</option>");
                });
            }
        });
    }
});

//For Asset Entry Page
$(document.body).on("change", "#ManufacturerAssetEntry", function () {

    var manufacturerAssetEntry = $("#ManufacturerAssetEntry").val();
    if (manufacturerAssetEntry != undefined && manufacturerAssetEntry != "") {
        var json = { id: manufacturerAssetEntry }

        $("#ModelAssetEntry").empty();

        $.ajax({
            type: "POST",
            url: "/CascadingDropdowns/GetAssetModels",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(json),
            success: function (data) {
                $("#ModelAssetEntry").append($('<option/>', { value: "", text: 'Select Model' }));
                $.each(data, function (key, value) {
                    $("#ModelAssetEntry").append("<option value=" + value.Id + ">" + value.Name + "</option>");
                });
            }
        });
    }

});


//For Asset Model and Asset Entry Page
$("#AssetGroupAssetEntry").change(function () {
    var assetGroupAssetEntry = $("#AssetGroupAssetEntry").val();
    $("#ManufacturerAssetEntry").empty();

    var json = { id: assetGroupAssetEntry };
    $.ajax({
        type: "POST",
        url: "/CascadingDropdowns/GetManufacturers",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(json),
        success: function (data) {
            $("#ManufacturerAssetEntry").append($('<option/>', { value: "", text: 'Select Manufacturer' }));
            $.each(data, function (key, value) {
                $("#ManufacturerAssetEntry").append('<option value=' + value.Id + '>' + value.Name + '</option>');
            });
        }
    });
});


//For Employee, Location, Branch and Asset Entry Page
$(document.body).on("change", "#OrganizationAssetEntry", function () {

    var organizationAssetEntry = $("#OrganizationAssetEntry").val();
    if (organizationAssetEntry != undefined && organizationAssetEntry != "") {
        var json = { id: organizationAssetEntry }

        $("#BranchAssetEntry").empty();
        $("#LocationAssetEntry").empty();

        $.ajax({
            type: "POST",
            url: "/CascadingDropdowns/GetBranches",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(json),
            success: function (data) {
                $("#BranchAssetEntry").append($('<option/>', { value: "", text: 'Select Branch' }));
                $.each(data, function (key, value) {
                    $("#BranchAssetEntry").append("<option value=" + value.Id + ">" + value.Name + "</option>");
                });
            }
        });
    }
});



//////////////////////////////////////////////////////////////////////
//To enable Live-search option
$(document).ready(function () {
    $("#branchOrganization, #OrganizationAssetEntry, #AssetTypeAssetEntry, #assetTypeAssetGroup, #assetGroupManufacturer").prop('class', 'selectpicker show-tick form-control').attr('data-live-search', true).attr('data-live-search-style', startsWith);
   });
//////////////////////////////////////////////////////////////////////





