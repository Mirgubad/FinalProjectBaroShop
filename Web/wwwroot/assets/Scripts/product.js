$(document).ready(function () {
  var check=true;
  $(".category-title").click(function () {
    var id = $(this).data("id");
    $(`.sub-categories[id=${id}]`).toggle(300);
    if(check){
      rotate(".arrow",id,180)
    
      check=false;
    }else if(!check){
      rotate(".arrow",id,0)
      check=true;
    }
  });
});

$(".sub-categories").css("display","none")

function rotate(element,id,degree) {
  $(`${element}[id=${id}]`).animate({
      transform: degree
  }, {
   
      step: function(now, fx) {
          $(this).css({
              '-webkit-transform': 'rotate(' + now + 'deg)',
              '-moz-transform': 'rotate(' + now + 'deg)',
              'transform': 'rotate(' + now + 'deg)',
              'color':'orangered'
          });
      }
  });
}




$(".head-right").css("display", "none");

$(document).on("mouseover", ".product-item", function () {
  var id = $(this).data("id");
  $(`.head-right[id=${id}]`).fadeIn(300);
});

$(document).on("mouseleave", ".product-item", function () {
  var id = $(this).data("id");
  $(`.head-right[id=${id}]`).fadeOut(300);
});



