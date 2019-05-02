$(function () {

    $('.increase-cartLine-quantity').submit(function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        $.ajax({
            url: '/Cart/IncreaseCartLineQuantity',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                if (typeof result == "object") {
                    $(`#cartLine-quantity-${id}`).html(result.quantity);
                    $(`#cartLine-sum-${id}`).html(result.sum + " zł");
                    $(`#total-amount`).html(result.totalAmount + " zł");
                    $('.text-danger strong').empty();
                }
                else {
                    $('.text-danger strong').html(result);
                }
            }
        });
    });

    $('.decrease-cartLine-quantity').submit(function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        $.ajax({
            url: '/Cart/DecreaseCartLineQuantity',
            type: 'POST',
            dataType: 'json',
            data: $(this).serialize(),
            success: function (result) {
                $(`#cartLine-quantity-${id}`).html(result.quantity);
                $(`#cartLine-sum-${id}`).html(result.sum + " zł");
                $(`#total-amount`).html(result.totalAmount + " zł");
                $('.text-danger strong').empty();
            }
        });
    });

});