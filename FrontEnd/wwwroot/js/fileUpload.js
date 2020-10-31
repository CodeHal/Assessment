var apiURL = "https://localhost:44301/";

function submitUpload(that) {
    var files = that[0].files;

    $('#selectFileToUpload').hide();
    $('#errorOccurred').hide();
    $('#success').hide();

    if (files.length == 0) {
        $('#selectFileToUpload').show();
    } else {
        var formData = new FormData();
        formData.append('file', files[0]);
        $.ajax({
            url: apiURL + "api/Employee/FileUpload",
            data: formData,
            type: 'post',
            contentType: false,
            processData: false,
            dataType: 'text',
            success: function () {
                $('#success').show();
            },
            error: function () {
                $('#errorOccurred').show();
            }
        })
    }
}