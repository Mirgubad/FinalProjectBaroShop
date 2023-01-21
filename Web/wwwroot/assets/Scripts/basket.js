

$(document).ready(function () {
    $("#close-basket-btn").click(function () {
        $(".mini-cart").hide(300);
    });
});


var favourite = [];

$(document).ready(function () {
    $(".product-heart").click(function () {
        var id = $(this).data("id");
        var isExist = favourite.includes(id);

        if (isExist) {

            $(".notification-error").fadeIn(1000);
            setTimeout(() => {
                $(".notification-error").fadeOut(3000);
            }, 2000);
            return;
        } else {
            favourite.push(id);
            $(this).css("color", "red")
            $(this).css("background", "white")
            localStorage.setItem("favouritesId", JSON.stringify(favourite));
            $(".notification-success").fadeIn(1000);
            setTimeout(() => {
                $(".notification-success").fadeOut(3000);
            }, 2000);
        }
    });
});

var wishList = document.getElementById("wish-inner");
var favouriteBtn = document.getElementById("favourites-btn");


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
        $(`.wish-item[id=${id}]`).hide()
        $(".notification-remove").fadeIn(1000);
        setTimeout(() => {
            $(".notification-remove").fadeOut(3000);
        }, 2000);
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
    var sum = basketCurrentCount - quantity
    var itemTotalCount = $('#item-count')
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
        }
    })
})




