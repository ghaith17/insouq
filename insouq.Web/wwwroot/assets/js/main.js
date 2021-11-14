(function($) {
  
  "use strict";  

  $(window).on('load', function() {

  /* Page Loader active
    ========================================================*/
    $('#preloader').fadeOut();

  /* Sticky Nav
    ========================================================*/
    $(window).on('scroll', function() {
        if ($(window).scrollTop() > 100) {
            $('.scrolling-navbar').addClass('top-nav-collapse');
        } else {
            $('.scrolling-navbar').removeClass('top-nav-collapse');
        }
    });

  /* slicknav mobile menu active 
    ========================================================*/
    $('.mobile-menu').slicknav({
        prependTo: '.navbar-header',
        parentTag: 'liner',
        allowParentLinks: true,
        duplicate: true,
        label: '',
        closedSymbol: '<i class="lni-chevron-right"></i>',
        openedSymbol: '<i class="lni-chevron-down"></i>',
      });

  /* WOW Scroll Spy
    ========================================================*/
    var wow = new WOW({
      //disabled for mobile
        mobile: false
    });
    wow.init();
    


  /* Counter
  ========================================================*/
    $('.counterUp').counterUp({
     delay: 10,
     time: 1000
    });

  /* Testimonials Carousel 
  ========================================================*/
    var owl = $("#testimonials");
      owl.owlCarousel({
        navigation: false,
        pagination: true,
        slideSpeed: 1000,
        stopOnHover: true,
        autoPlay: true,
        items: 2,
        itemsDesktop : [1199,2],
        itemsDesktopSmall : [980,2],
        itemsTablet: [768,1],
        itemsTablet: [767,1],
        itemsTabletSmall: [480,1],
        itemsMobile : [479,1],
      });        

  /* New Products Owl Carousel
  ========================================================*/
    $("#new-products").owlCarousel({
        navigation: false,
        pagination: true,
        slideSpeed: 1000,
        stopOnHover: true,
        autoPlay: false,
        items: 4,
        itemsDesktop : [1199,3],
        itemsDesktopSmall : [980,2],
        itemsTablet: [768,1],
        itemsTablet: [767,1],
        itemsTabletSmall: [480,1],
        itemsMobile : [479,1],
    });

    var newProducts = $('.new-products');
    newProducts.find('.owl-prev').html('<i class="lniChevron-left"></i>');
    newProducts.find('.owl-next').html('<i class="lniChevron-right"></i>');

    var testiCarousel = $('.testimonials-carousel');
    testiCarousel.find('.owl-prev').html('<i class="lniChevron-left"></i>');
    testiCarousel.find('.owl-next').html('<i class="lniChevron-right"></i>');

    $('#new-products').find('.owl-prev').html('<i class="lniChevron-left"></i>');
    $('#new-products').find('.owl-next').html('<i class="lniChevron-right"></i>');

  /* owl Carousel active
  ========================================================*/   
     var owl;
    $(document).ready(function () {
        owl = $("#owl-demo");
        owl.owlCarousel({
            navigation: false, // Show next and prev buttons
            slideSpeed: 300,
            paginationSpeed: 400,
            singleItem: true,
            afterInit: afterOWLinit, // do some work after OWL init
            afterUpdate : afterOWLinit
        });

        function afterOWLinit() {
            // adding A to div.owl-page
            $('.owl-controls .owl-page').append('<a class="item-link" />');
            var pafinatorsLink = $('.owl-controls .item-link');
            /**
             * this.owl.userItems - it's your HTML <div class="item"><img src="http://www.ow...t of us"></div>
             */
            $.each(this.owl.userItems, function (i) {

                $(pafinatorsLink[i])
                    // i - counter
                    // Give some styles and set background image for pagination item
                    .css({
                        'background': 'url(' + $(this).find('img').attr('src') + ') center center no-repeat',
                        '-webkit-background-size': 'cover',
                        '-moz-background-size': 'cover',
                        '-o-background-size': 'cover',
                        'background-size': 'cover'
                    })
                    // set Custom Event for pagination item
                    .click(function () {
                        owl.trigger('owl.goTo', i);
                    });

            });
             // add Custom PREV NEXT controls
            $('.owl-pagination').prepend('<a href="#prev" class="prev-owl"/>');
            $('.owl-pagination').append('<a href="#next" class="next-owl"/>');
            // set Custom event for NEXT custom control
            $(".next-owl").click(function () {
                owl.trigger('owl.next');
            });
            // set Custom event for PREV custom control
            $(".prev-owl").click(function () {
                owl.trigger('owl.prev');
            });
          }
        });


    /* Back Top Link active
    ========================================================*/
      var offset = 200;
      var duration = 500;
      $(window).scroll(function() {
        if ($(this).scrollTop() > offset) {
          $('.back-to-top').fadeIn(400);
        } else {
          $('.back-to-top').fadeOut(400);
        }
      });

      $('.back-to-top').on('click',function(event) {
        event.preventDefault();
        $('html, body').animate({
          scrollTop: 0
        }, 600);
        return false;
      });

      /* Product Grids active
      ========================================================*/
      var itemList = $('.item-list');
      var gridStyle = $('.grid');
      var listStyle = $('.list');

      $('.list,switchToGrid').on('click',function(e) {
        e.preventDefault();
        itemList.addClass("make-list");
        itemList.removeClass("make-grid");
        itemList.removeClass("make-compact"); 
        gridStyle.removeClass("active");
        listStyle.addClass("active");
      });

      gridStyle.on('click',function(e) {
        e.preventDefault();
        listStyle.removeClass("active");
        $(this).addClass("active");
        itemList.addClass("make-grid");
        itemList.removeClass("make-list");
        itemList.removeClass("make-compact");
      });

  });      

}(jQuery));



function GetLocation() {
    $("#lng").val("35.8825038");
    $("#lat").val("31.9684967");
    $("#detectLocationError").css("display", "none");
    $("#detectLocationErrorMessage").text("");
}

function setReportAdId(adId) {
    $("#hiddenReportAdId").val(adId);
}

function ReportAd() {
    const data = {
        Reason: $('#reportReason').val(),
        Description: $("#reportDescription").val(),
        AdId: $("#hiddenReportAdId").val(),
    };

    $.ajax({
        url: "/Ads/ReportAd",
        method: "POST",
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: "application/json",
        success: function (response) {
            if (!response.isSuccess) {
                $("#reportAdError").css("display", "block");
                $("#reportAdErrorMessage").text(response.message);
            } else {
              //  $("#reportAdModal").modal("hide");
                var button = document.getElementById("closeReportAdModal");
                button.click();
            }
        },
        error: function (error) {
            alert(error.message);
            console.log(error);
        }
    });
}



function DetailsAddToFavorite(adId) {

    const data = {
        AdId: adId,
    };

    $.ajax({
        url: "/Ads/AddToFavorite",
        method: "POST",
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: "application/json",
        success: function (response) {
            if (!response.isSuccess) {
                alert(response.message);
            } else {
                window.location.reload();
            }
        },
        error: function (error) {
            alert(error.message);
        }
    });
}

function DetailsRemoveFromFavorite(adId) {

    const data = {
        AdId: adId,
    };

    $.ajax({
        url: "/Ads/RemoveFromFavorite",
        method: "POST",
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: "application/json",
        success: function (response) {
            if (!response.isSuccess) {
                alert(response.message);
            } else {
                window.location.reload();
            }
        },
        error: function (error) {
            alert(error.message);
        }
    });
}

function AddToFavorite(adId) {

    const data = {
        AdId: adId,
    };

    $.ajax({
        url: "/Ads/AddToFavorite",
        method: "POST",
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: "application/json",
        success: function (response) {
            if (!response.isSuccess) {
                alert(response.message);
            } else {
                var iconId = "favorite-" + adId;

                $(`#${iconId}`).attr("onclick", `RemoveFromFavorite(${adId})`);
                $(`#${iconId}`).attr("class", `fas fa-heart`);
                $(`#${iconId}`).css("color", `red`);
            }
        },
        error: function (error) {
            alert(error.message);
        }
    });
}

function RemoveFromFavorite(adId) {

    const data = {
        AdId: adId,
    };

    $.ajax({
        url: "/Ads/RemoveFromFavorite",
        method: "POST",
        data: JSON.stringify(data),
        dataType: 'json',
        contentType: "application/json",
        success: function (response) {
            if (!response.isSuccess) {
                alert(response.message);
            } else {
                var iconId = "favorite-" + adId;
                console.log(iconId);

                $(`#${iconId}`).attr("onclick", `AddToFavorite(${adId})`);
                $(`#${iconId}`).attr("class", `far fa-heart`);
                $(`#${iconId}`).removeAttr("style");
            }
        },
        error: function (error) {
            alert(error.message);
        }
    });
}



//Types


const Motors_ID = 1;
const Properties_ID = 2;
const Jobs_ID = 3;
const Services_ID = 4;
const Business_ID = 5;
const Classifieds_ID = 6;
const Numbers_ID = 7;
const Electronics_ID = 8;


// Motors

const UsedCars_ID = 2;
const Boats_ID = 5;
const Machinery_ID = 6;
const Parts_ID = 7;
const Export_Car = 8;
const Bike_ID = 9;

///////////////////////////////

// Jobs

const JobOpening_ID = 3;
const JobWanted_ID = 4;

///////////////////////////////

// Properities

const CommercialForSale_ID = 10;
const CommercialForRent_ID = 14;
const ResidentialForSale_ID = 15;
const ResidentialForRent_ID = 16;

///////////////////////////////
///

// Numbers

const PlateNumbers_ID = 17;
const MobileNumbers_ID = 18;

function getColorByTypeId(typeId) {
    if (typeId == Motors_ID) {
        return "#FF0073";
    }
    if (typeId == Properties_ID) {
        return "#FFC456";
    }
    if (typeId == Jobs_ID) {
        return "#FF665B";
    }
    if (typeId == Services_ID) {
        return "#00D4F9";
    }
    if (typeId == Business_ID) {
        return "#6DD400";
    }
    if (typeId == Classifieds_ID) {
        return "#0091FF";
    }
    if (typeId == Numbers_ID) {
        return "#7255F1";
    }
    if (typeId == Electronics_ID) {
        return "#FFD300";
    }
}


$('#LoginEmailOrPhone').on('blur', function () {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if ($('#LoginEmailOrPhone').val().match(mailformat)) {
        if ($("#successLoginIcon").length == 0) {
            if ($("#errorLoginIcon").length != 0) {
                $("#errorLoginIcon").remove();
            }
            $("#LoginEmailOrPhone").after('<i id="successLoginIcon" class="fa fa-check check-icon" aria-hidden="true"></i>');
        }
    } else {
        if ($("#errorLoginIcon").length == 0) {
            if ($("#successLoginIcon").length != 0) {
                $("#successLoginIcon").remove();
            }
            $("#LoginEmailOrPhone").after('<i id="errorLoginIcon" class="fa fa-times check-icons" aria-hidden="true"></i>');

        }
    }

});

$('#Email').on('blur', function () {
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if ($('#Email').val().match(mailformat)) {
        if ($("#successRegisterIcon").length == 0) {
            if ($("#errorRegisterIcon").length != 0) {
                $("#errorRegisterIcon").remove();
            }
            $("#Email").after('<i id="successRegisterIcon" class="fa fa-check check-icon" aria-hidden="true"></i>');
        }
    } else {
        if ($("#errorRegisterIcon").length == 0) {
            if ($("#successRegisterIcon").length != 0) {
                $("#successRegisterIcon").remove();
            }
            $("#Email").after('<i id="errorRegisterIcon" class="fa fa-times check-icons" aria-hidden="true"></i>');

        }
    }
});

    $('#forgotPasswordEmail').on('blur', function () {
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if ($('#forgotPasswordEmail').val().match(mailformat)) {
            if ($("#successforgotPasswordEmailIcon").length == 0) {
                if ($("#errorforgotPasswordEmailIcon").length != 0) {
                    $("#errorforgotPasswordEmailIcon").remove();
                }
                $("#forgotPasswordEmail").after('<i id="successforgotPasswordEmailIcon" class="fa fa-check check-icon" aria-hidden="true"></i>');
            }
        } else {
            if ($("#errorforgotPasswordEmailIcon").length == 0) {
                if ($("#successforgotPasswordEmailIcon").length != 0) {
                    $("#successforgotPasswordEmailIcon").remove();
                }
                $("#forgotPasswordEmail").after('<i id="errorforgotPasswordEmailIcon" class="fa fa-times check-icons" aria-hidden="true"></i>');

            }
        }

});


function imageSlider(x, images, sliderId) {
    // startSlider();
    if (x < images.length) {
        i = x
    } else {
        i = 0;
    }
    slider.setAttribute("src", images[i]);
}


function ShowLogin() {
    $("#myModal1").modal('show');
}




function GoToSearch(ADTypeId, catId, location,url) {

    window.location.href =url+"?typeId=" + ADTypeId + "&categoryId=" + catId + "&location="+location;

}


function ShowPageItems(pageId) {
    $(".pageAds").css("display", "none");
    $(`#pageItems${pageId}`).css("display", "block");

    window.scrollTo({ top: 0, behavior: 'smooth' });
}


function deleteAdPhoto(id) {
    var imagesToDelete = $("#imagesToDelete").val();

    imagesToDelete += id + ",";

    $("#imagesToDelete").val(imagesToDelete);
}

function onFormSubmit() {

   
    var lng = $("#lng").val();
    var lat = $("#lat").val();

    if (lat == "" || lng == "") {
        $("#detectLocationError").css("display", "block");
        $("#detectLocationErrorMessage").text("No location detected");
       
    } else {
        $("#addForm").submit();
    }
   
    
}
