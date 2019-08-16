function InitUploadPicture() {

    $(".input-file-post").off("click").on("click", function (e) {
        e.preventDefault();
        console.log("post image click");
        var parent = $(this).parent();
        var file = parent.find('input:file');
        if (file.length) {
            file.click();
        }
    });

    $(".btn-change-image").off("click").on("click", function (e) {
        e.preventDefault();
        console.log("change image click");
        var uniqueId = $(this).data("id");
        var container = $(`#upload-image-${uniqueId}`);
        var file = container.find('input:file');
        if (file.length) {
            file.click();
        }
    });

    $(".btn-delete-image").off("click").on("click", function (e) {
        e.preventDefault();
        console.log("delete image click");
        var uniqueId = $(this).data("id");
        var container = $(`#upload-image-${uniqueId}`);
        var file = container.find('input:file');
        file.val("");
        var hiddens = container.find('input[type=hidden]');//id and old-url
        hiddens.each(function () {
            console.log("before:" + $(this).val());
            $(this).val("");
            console.log("after:" + $(this).val());
        });

        var img = $(`#img-prev-${uniqueId}`);
        img.attr("src", "");
        img.addClass("hidden");
        $(`#btn-file-post-${uniqueId}`).removeClass("hidden");
        $(`#btns-commands-${uniqueId}`).addClass("hidden");
    });
}

InitUploadPicture();