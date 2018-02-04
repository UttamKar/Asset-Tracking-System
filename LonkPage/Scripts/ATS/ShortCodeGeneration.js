
//Branch Setup page auto code
$(document.body).on("change", "#branchOrganization, #branchBranch", function () {
    if ($("#branchOrganization") != "" && $("#branchBranch") != "") {
        var orgName = $("#branchOrganization option:selected").text();
        var branchName = $("#branchBranch").val();
        var shortName = (orgName + '_' + branchName).replace(/\s/g, "") ;
        $("#shortName").val(shortName);
        $("#shortName").prop('readonly', true);
    }
});


//Employee Setup page auto code
$(document.body).on("change", "#firstNameEmployee, #lastNameEmployee", function () {
    if ($("#firstNameEmployee") != "" && $("#lastNameEmployee") != "") {
        var firstName = ($("#firstNameEmployee").val()).replace(/\s/g, "");
        var lastName = ($("#lastNameEmployee").val()).replace(/\s/g, "");
        var combinetName = (firstName.substring(0, 3) + lastName.substring(0, 2)).toUpperCase() + '_0' + Math.floor(Math.random() * 100000 + 1);
        $("#codeEmployee").val(combinetName);
        $("#codeEmployee").prop('readonly', true);
    }
});


//Location Setup page auto code
$(document.body).on("change", "#OrganizationAssetEntry", function () {
    $("#shortNameLocation").val("");

    $(document.body).on("change", "#BranchAssetEntry", function () {
        var orgName = $("#OrganizationAssetEntry option:selected").text();
        var branchName = $("#BranchAssetEntry option:selected").text();
        var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var selectedCharacter = possible.charAt(Math.floor(Math.random() * possible.length));
        var serialNumber = ((orgName + '_' + branchName).toUpperCase() + '_' + selectedCharacter + Math.floor(Math.random() * 1000 + 1)).replace(/\s/g, "");
        $("#shortNameLocation").val(serialNumber);
        $("#shortNameLocation").prop('readonly', true);
    });
});


//Asset Type Setup page auto code
$(document.body).on("change", "#assetTypeShortName", function () {
    if ($("#assetTypeName") != "" && $("#assetTypeShortName") != "") {
        var assetTypeShortName = $.trim($("#assetTypeShortName").val());
        var shortName = (assetTypeShortName + '_0' + Math.floor(Math.random() * 100000 + 1)).replace(/\s/g, "");
        $("#assetTypeAutoCode").val(shortName);
        $("#assetTypeAutoCode").prop('readonly', true);
    }
});


//Asset Group Setup page auto code
$(document.body).on("change", "#assetTypeAssetGroup, #nameAssetGroup", function () {

    $("#shortNameAssetGroup").val("");
    $("#codeAssetGroup").val("");

    var assetTypeAssetGroup = $("#assetTypeAssetGroup option:selected").text();
    var nameAssetGroup = $("#nameAssetGroup").val();
    if (assetTypeAssetGroup != undefined && assetTypeAssetGroup != "" && nameAssetGroup != undefined && nameAssetGroup != "") {
        var shortName = (assetTypeAssetGroup + "_" + nameAssetGroup).toUpperCase().replace(/\s/g, "");
        $("#shortNameAssetGroup").val(shortName);
        $("#shortNameAssetGroup").prop('readonly', true);

        //for Code
        var code = shortName + '_0' + Math.floor(Math.random() * 100000 + 1);
        $("#codeAssetGroup").val(code);
        $("#codeAssetGroup").prop('readonly', true);
    }
});



//Asset Manufacturer Setup page auto code
$(document.body).on("change", "#assetGroupManufacturer, #nameManufacturer", function () {

    $("#shortNameManufacturer").val("");
    $("#codeManufacturer").val("");

    var assetGroupManufacturer = $("#assetGroupManufacturer option:selected").text();
    var nameManufacturer = $("#nameManufacturer").val();
    if (assetGroupManufacturer != undefined && assetGroupManufacturer != "" && nameManufacturer != undefined && nameManufacturer != "") {
        var shortName = (assetGroupManufacturer + "_" + nameManufacturer).toUpperCase().replace(/\s/g, "");
        $("#shortNameManufacturer").val(shortName);
        $("#shortNameManufacturer").prop('readonly', true);

        //For Code
        var code = shortName + '_0' + Math.floor(Math.random() * 100000 + 1);
        $("#codeManufacturer").val(code);
        $("#codeManufacturer").prop('readonly', true);

    }
});


//Asset Model Setup page (auto code)
$(document.body).on("change", "#ManufacturerAssetEntry, #modelName", function () {

    $("#shortNameAssetModel").val("");
    $("#codeAssetModel").val("");

    var assetGroupAssetEntry = $("#AssetGroupAssetEntry option:selected").text();
    var manufacturerAssetEntry = $("#ManufacturerAssetEntry option:selected").text();
    var modelName = $("#modelName").val();
    if (modelName != undefined && modelName != "" && manufacturerAssetEntry != undefined && manufacturerAssetEntry != "") {
        var shortName = (assetGroupAssetEntry + "_" + manufacturerAssetEntry + "_" + modelName.substring(0, 3)).toUpperCase().replace(/\s/g, "");
        $("#shortNameAssetModel").val(shortName);
        $("#shortNameAssetModel").prop('readonly', true);

        var code = shortName + '_0' + Math.floor(Math.random() * 100000 + 1);
        $("#codeAssetModel").val(code);
        $("#codeAssetModel").prop('readonly', true);
    }
});
