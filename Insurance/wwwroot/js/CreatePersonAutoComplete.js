
$("#LicensePlate").change(function () {

    if ($('#IdentificationNumber').val() !== undefined && $('#IdentificationNumber').val() !== "" &&
        $("#LicensePlate").val() !== undefined && $("#LicensePlate").val() !== "") {

        var data = {
            IdentificationNumber: $("#IdentificationNumber").val(),
            LicensePlate: $("#LicensePlate").val(),
            LicenseSerialCode: "",
            LicenseSerialNumber: ""
        };

        debugger;
        $.ajax({
            url: '/Person/CreatePerson',
            dataType: 'json',
            data: data,
            ContentType: 'application/json',
            type: 'post',
            success: function (data, status) {
                console.log(data);
                debugger;
                if (data && data.message === "200" && data.name.length > 0) {
                    var licenseSerialCode = data.name[0].licenseSerialCode;
                    var licenseSerialNumber = data.name[0].licenseSerialNumber;

                    $('#LicenseSerialCode').val(licenseSerialCode);
                    $('#LicenseSerialNumber').val(licenseSerialNumber);
                }
                else if (data && data.message === "201") {
                    $('#LicenseSerialCode').val("");
                    $('#LicenseSerialNumber').val("");
                }

            },
            error: function (html, status, error) {
                console.log('the request is ' + error);
            }
        });
    }
});

