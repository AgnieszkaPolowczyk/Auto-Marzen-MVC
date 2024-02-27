$(function () {
    LoadFeatures()

    $("#createFeatureModal form").on("submit",function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Poprawnie dodano wyposa¿enie")
                LoadFeatures();
            },
            error: function (data) {
                toastr["error"]("Coœ posz³o nie tak!")
            }
        })
    });
});