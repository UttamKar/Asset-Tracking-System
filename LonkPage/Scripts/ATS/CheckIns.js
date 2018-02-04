
//To pull all assets against an Employee
$(document.body).on("change", "#EmployeeId", function () {

    var employeeId = $("#EmployeeId").val();
    if (employeeId != undefined && employeeId != "") {
        var json = { id: employeeId }

        $("#CheckInTable > tr").remove();

        $.ajax({
            type: "POST",
            url: "/CheckIns/SearchAssetForCheckIn",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(json),
            success: function (data) {
                $.each(data, function (key, value) {
                    $("#CheckInTable").append(
                        "<tr>"
                        + "<td>" + '<input id='+value.AssetEntryId+' type="checkbox"  onclick= SelectedAssetEntryId(this) />' + "</td>"
                        + "<td>" + value.AssetNo + "</td>"
                        + "<td>" + value.Name + "</td>"
                        + "<td>" + new Date(parseInt(value.DueDate.substr(6))).toLocaleDateString() + "</td>"
                        + "<td>" + value.EmployeeName + "</td>"
                        + "<td style='display:none'>" + value.AssetEntryId + "</td>"
                        + "</tr>");
                });
            }
        });
    }
});

var employeeIdArr = [];
function SelectedAssetEntryId(selectedElement) {
    if ($(selectedElement).is(':checked')) {
        var idss = $(selectedElement).attr('id');
        employeeIdArr.push(idss);
    } else {
        employeeIdArr.pop($(selectedElement).attr('id'));
    }
    $('#assetIDArr').val(employeeIdArr.join(','));

}

//To select all checkboxs together
//$('#ckbCheckAll').change(function () {
//    $('tbody tr td input[type="checkbox"]').prop('checked', $(this).prop('checked'));
//});

$("#ckbCheckAll").click(function () {
    //To select all checkboxs together
    $('tbody tr td input[type="checkbox"]').prop('checked', $(this).prop('checked'));

    SelectAllId();
});

function SelectAllId() {
    if ($("#ckbCheckAll").is(':checked')) {
    $("#CheckInTable input:checked").each(function () {
        var idss = $(this).attr('id');
        employeeIdArr.push(idss);
        $('#assetIDArr').val(employeeIdArr.join(','));
    });
    } else {
        employeeIdArr.pop($(this).attr('id'));
    }
};


