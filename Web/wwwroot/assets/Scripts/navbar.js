document.addEventListener("DOMContentLoaded", () => {
    // Get all "navbar-burger" elements
    const $navbarBurgers = Array.prototype.slice.call(
        document.querySelectorAll(".navbar-burger"),
        0
    );

    // Check if there are any navbar burgers
    if ($navbarBurgers.length > 0) {
        // Add a click event on each of them
        $navbarBurgers.forEach((el) => {
            el.addEventListener("click", () => {
                // Get the target from the "data-target" attribute
                const target = el.dataset.target;
                const $target = document.getElementById(target);

                // Toggle the "is-active" class on both the "navbar-burger" and the "navbar-menu"
                el.classList.toggle("is-active");
                $target.classList.toggle("is-active");
            });
        });
    }
});


$(document).ready(function () {
    $(".has-dropdown").click(function () {
        var id = $(this).data("id");
        $(`.navbar-dropdown[id=${id}]`).toggle(200);
    });

    $(".footer-title").click(function () {
        var id = $(this).data("id");
        $(`.collapsed-items[id=${id}]`).toggle(300);
        $(this).toggleClass('show');
        return false;
    });
});

var $scrollingDiv = $("#to-top-btn");
var header = $("#header")
var navbar = $("#navbars")

$(window).scroll(function () {
    if ($(window).scrollTop() > 220) {
        $scrollingDiv
            .css("position", "fixed")
            .css("bottom", "10px")
            .css("right", "10px");
        header.addClass("scrolled")


    } else {
        $scrollingDiv.css("position", "fixed").css("right", "-1000px");
        header.removeClass("scrolled")
    }
});

//setTimeout(() => {
//    $(".loader-main").fadeOut(350);
//}, 3000);


$(".loader-main").hide();






$(document).ready(function () {
    $(".has-dropdown").click(function () {
        var id = $(this).data("id");
        $(`.navbar-dropdown[id=${id}]`).toggle(200);
    });
    $(".footer-title").click(function () {
        var id = $(this).data("id");
        $(`.collapsed-items[id=${id}]`).toggle(300);
        $(this).toggleClass('show');
        return false;
    });
});



$(document).ready(function () {
    $("#search-input").keypress(function () {
        //$(this).css("border", "1.5px solid orangered")
        var addResult = $("#search-result")
        addResult.show(300)
        $("body").click(function () {
            addResult.hide(300)
        })
        var name = $("#search-input").val()
        $.ajax({
            method: "GET",
            url: "product/filterbyname",
            data: {
                name: name
            },
            success: function (result) {
                addResult.html('')
                addResult.css("height", "300px")
                addResult.append(result)
                console.log(result)
                if (result == false) {
                    addResult.css("height", "100px")
                    addResult.append(`
                  <div class="no-result">
                     <span>No results</span>
                  </div>`)
                }
            }
        })
    });
});








