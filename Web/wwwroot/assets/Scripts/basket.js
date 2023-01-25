

$(document).ready(function () {
    $("#close-basket-btn").click(function () {
        $(".mini-cart").hide(300);
    });
});


$(document).ready(function () {
    $(".add-basket-btn").click(function () {

        var id = $(this).data('id')
        var basketCount = $('#basketCount')
        var basketCurrentCount = $('#basketCount').html()
        $.ajax({
            method: "POST",
            url: "/basket/add",
            data: {
                id: id
            },
            success: function (result) {
                basketCurrentCount++;
                basketCount.html("")
                basketCount.append(basketCurrentCount)
                $(".notification-success").fadeIn(1000);
                setTimeout(() => {
                    $(".notification-success").fadeOut(3000);
                }, 2000);
            }
        })
    });
});


$(document).ready(function () {
    $(".wish-delete").click(function () {
        var id = $(this).data("id")

        $.ajax({
            method: "POST",
            url: "favourite/delete",
            data: {
                id: id
            },
            success: function (result) {
                $(`.wish-item[id=${id}]`).remove()
                $(".notification-remove").fadeIn(1000);
                setTimeout(() => {
                    $(".notification-remove").fadeOut(3000);
                }, 2000);
            }
        })
    })
})



$(document).on("click", "#basket", function () {
    $(".mini-cart").toggle(300);
    $.ajax({
        method: "GET",
        url: "/basket/minibasket",
        success: function (result) {
            $('#cartItemList').html("");
            $('#cartItemList').append(result);
        }
    })
})

$(document).on("click", '.basket-delete', function () {
    var id = $(this).data('id')
    var basketCountContainer = $("#basket-count")
    var basketCount = $('#basketCount')
    var basketCurrentCount = $('#basketCount').html()
    var quantity = $(this).data('quantity')
    var count = $(`#form-${id}`).val()
    var sum = basketCurrentCount - quantity
    var itemTotalCount = $('#item-count')
    var price = $(this).data('price')
    var sumPrice = $('#sum-price').html()
    var sumPriceLast = $('#sum-price')

    $.ajax({
        method: "POST",
        url: "/basket/delete",
        data: {
            id: id
        },
        success: function (result) {
            if (sum == 0) {
                basketCountContainer.hide()
            }
            $(`.basket-products[id=${id}]`).remove();
            basketCount.html("")
            itemTotalCount.html("")
            itemTotalCount.append(sum + " items")
            basketCount.append(sum)
            sumPriceLast.html("")
            sumPriceLast.append(sumPrice - price * count)
            $(".notification-remove").fadeIn(1000);
            setTimeout(() => {
                $(".notification-remove").fadeOut(3000);
            }, 2000);
        }
    })
})


$(document).on("click", '.mini-basket-delete', function () {
    var id = $(this).data('id')
    var basketCountContainer = $("#basket-count")
    var basketCount = $('#basketCount')
    var basketCurrentCount = $('#basketCount').html()
    var quantity = $(this).data('quantity')
    var sum = basketCurrentCount - quantity
    var itemTotalCount = $('#mini-basket-item-count')
    var price = $(this).data('price')
    var sumPrice = $('#mini-basket-sum-price').html()
    var sumPriceLast = $('#mini-basket-sum-price')

    $.ajax({
        method: "POST",
        url: "/basket/delete",
        data: {
            id: id
        },
        success: function (result) {
            if (sum == 0) {
                basketCountContainer.hide()
            }
            $(`.basket-products[id=${id}]`).remove();
            basketCount.html("")
            basketCount.append(sum)
            sumPriceLast.html("")
            sumPriceLast.append(sumPrice - price * quantity)
            $(".notification-remove").fadeIn(1000);
            setTimeout(() => {
                $(".notification-remove").fadeOut(3000);
            }, 2000);
        }
    })
})


$(document).on("click", '.decrease', function () {
    var id = $(this).data('id')
    var basketCount = $('#basketCount')
    var basketCurrentCount = $('#basketCount').html()
    var price = $(this).data('price')
    var itemTotalCount = $('#item-count')
    var total = $(`#total-price-${id}`)
    var count = $(`#form-${id}`).val()
    var sumPrice = $('#sum-price').html()
    var sumPriceLast = $('#sum-price')
    var sum = count * price

    sumPrice = parseFloat(sumPrice)
    $(".loader-2").show();
    $(".card-container").css("filter", "blur(1px)")
    $.ajax({
        method: "POST",
        url: "/basket/decreasecount",
        data: {
            id: id
        },
        success: function (result) {
            basketCurrentCount--;
            if (basketCurrentCount >= 1) {
                basketCount.html("")
                itemTotalCount.html("")
                itemTotalCount.append(basketCurrentCount + " items")
                basketCount.append(basketCurrentCount)
            }
            if (sum > 0) {
                total.html('')
                total.append(sum + "$")
                sumPriceLast.html("")
                sumPriceLast.append(sumPrice - price)
            }
            $(".notification-remove").fadeIn(1000);
            setTimeout(() => {
                $(".notification-remove").fadeOut(3000);
                $(".loader-2").hide();
                $(".card-container").css("filter", "none")
            }, 2000);




        }
    })
})


$(document).on("click", '.increase', function () {
    var id = $(this).data('id')
    var basketCount = $('#basketCount')
    var price = $(this).data('price')
    price = parseInt(price)
    var itemTotalCount = $('#item-count')
    var total = $(`#total-price-${id}`)
    var count = $(`#form-${id}`).val()
    var sum = count * price
    var basketCurrentCount = $('#basketCount').html()
    var sumPrice = $('#sum-price').html()
    var sumPriceLast = $('#sum-price')
    sumPrice = parseFloat(sumPrice)
    $(".loader-2").show();
    $(".card-container").css("filter", "blur(1px)")
    $.ajax({
        method: "POST",
        url: "/basket/increasecount",
        data: {
            id: id
        },
        success: function (result) {
            basketCurrentCount++;
            basketCount.html("")
            sumPriceLast.html('')
            itemTotalCount.html("")
            total.html('')
            basketCount.append(basketCurrentCount)
            sumPriceLast.append(sumPrice + price)
            itemTotalCount.append(basketCurrentCount + " items")
            total.append(sum + "$")
            $(".notification-success").fadeIn(1000);
            setTimeout(() => {
                $(".notification-success").fadeOut(3000);
                $(".loader-2").hide();
                $(".card-container").css("filter", "none")
            }, 2000);
        }
    })
})


$(document).on('click', '.product-heart', function () {
    var id = $(this).data('id');
    //$(this).removeClass("product-heart")
    $(this).addClass("active")
   
    $.ajax({
        method: "POST",
        url: "https://localhost:44386/favourite/add",
        data: {
            id: id
        },
        success: function (result) {
            $(".notification-success").fadeIn(1000);
            setTimeout(() => {
                $(".notification-success").fadeOut(3000);
            }, 2000);
        },
        error: function () {
            $(".notification-error").fadeIn(1000);
            setTimeout(() => {
                $(".notification-error").fadeOut(3000);
            }, 2000);
        }
    })
})


