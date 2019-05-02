$(function () {
    $(document).on("submit", "form", function () {
        if ($(this).valid()) {
            $(":submit").prop("disabled", true);
        }
        else {
            $(":submit").prop("disabled", false);
        }
    });
});