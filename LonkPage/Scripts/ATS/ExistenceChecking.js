
//vendor name existence checking
$(document.body).on("change", "#vendorName", function () {
    var url = "/CascadingDropdowns/IsVendorNameExist";
    var name = $('#vendorName').val();
    $.get(url, { input: name }, function (data) {
        if (data == "Available") {
            $("#vendorNameExistenceCheck").html(name + "<span> is already Enlisted.</span>");
            $('#vendorName').val("");
        }
    });
});

//Organization name existence checking
$(document.body).on("change", "#organizationName", function () {
    var url = "/CascadingDropdowns/IsOrganizationNameExist";
    var name = $('#organizationName').val();
    $.get(url, { input: name }, function (data) {
        if (data == "Available") {
            $("#organizationNameExistenceCheck").html(name + "<span> is already Enlisted.</span>");
            $('#organizationName').val("");
        }
    });
});


//Branch name existence checking
$(document.body).on("change", "#branchBranch", function () {

    
    var url = "/CascadingDropdowns/IsBranchNameExist";
    var orgName = $("#branchOrganization option:selected").text();
    var orgId = $("#branchOrganization option:selected").val();
    var branchName = $('#branchBranch').val();
    if (branchName != "" && branchName != undefined) {
        $.get(url, { name: branchName, orgId: orgId }, function (data) {
            if (data == "Available") {
                $("#branchNameExistenceCheck").html(branchName + "<span> is already Enlisted under </span>" + orgName);
                $('#branchBranch').val("");
            }
        });
    }
});



//Asset Type name existence checking
$(document.body).on("change", "#assetTypeName", function() {
    var url = "/CascadingDropdowns/IsAssetTypeNameExist";
    var name = $('#assetTypeName').val();
    $.get(url, { input: name }, function(data) {
        if (data == "Available") {
            $("#assetTypeNameExistenceCheck").html(name + "<span> is already Enlisted.</span>");
            $('#assetTypeName').val("");
        }
    });
});


//Asset Group name existence checking
$(document.body).on("change", "#nameAssetGroup", function () {
    var url = "/CascadingDropdowns/IsAssetGroupNameExist";
    var name = $('#nameAssetGroup').val();
    $.get(url, { input: name }, function(data) {
        if (data == "Available") {
            $("#assetGroupNameExistenceCheck").html(name + "<span> is already Enlisted.</span>");
            $('#nameAssetGroup').val("");
        }
    });
});


//Asset Manufacturer name existence checking
$(document.body).on("change", "#nameManufacturer", function () {
    var url = "/CascadingDropdowns/IsManufacturerNameExist";
    var name = $('#nameManufacturer').val();
    $.get(url, { input: name }, function (data) {
        if (data == "Available") {
            $("#assetManufacturerNameExistenceCheck").html(name + "<span> is already Enlisted.</span>");
            $('#nameManufacturer').val("");
        }
    });
});


//Contact number existence checking for Employee Setup
$(document.body).on("change", "#contactNoEmployee", function () {
    var url = "/CascadingDropdowns/IsContactNumberExist";
    var contactNo = $('#contactNoEmployee').val();
    $.get(url, { input: contactNo }, function (data) {
        if (data == "Available") {
            $("#contactNoEmployeeExistenceCheck").html(contactNo + "<span> is already Enlisted.</span>");
            $('#contactNoEmployee').val("");
        }
    });
});