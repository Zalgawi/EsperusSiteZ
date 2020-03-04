$(document).ready(function () {
    $(".gallery-clear").click(function (args) {
        args.preventDefault();

        $(".image-gallery .card").each(function (index) {
            if ($(this).hasClass("selected")) {
                $(this).removeClass("selected");
            }
        });
    });

    $(".gallery-upload").click(function (args) {
        args.preventDefault();

        if ($("#imageName").val() == "" || $('#imagePath').get(0).files.length === 0) {
            $("#gallery-save-modal").modal("show");
        }
        else {
            $(".upload-form").submit();
        }
    });

    $(".upload-dialog").click(function (args) {
        args.preventDefault();
        $("#gallery-upload-modal").modal("show");
    });

    $(function () {
        $("#imagePath:file").change(function () {
            var filePath = $(this).val();
            var fileName = filePath.replace(/^.*[\\\/]/, '');

            $("#imageName").val(fileName);
            $("#imageDir").val(filePath);
        });
    });
});
