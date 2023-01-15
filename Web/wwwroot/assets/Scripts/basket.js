$(document).ready(function () {
  $("#basket").click(function () {
    $(".mini-cart").toggle(300);
  });
});

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
      $(this).css("color","red")
      $(this).css("background","white")
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
    $(".notification-success").fadeIn(1000);
    setTimeout(() => {
      $(".notification-success").fadeOut(3000);
    }, 2000);
  });
});


$(document).ready(function(){
  $(".wish-delete").click(function(){
    var id=$(this).data("id")
  $(`.wish-item[id=${id}]`).hide()
  $(".notification-remove").fadeIn(1000);
  setTimeout(() => {
    $(".notification-remove").fadeOut(3000);
  }, 2000);
  })
})


