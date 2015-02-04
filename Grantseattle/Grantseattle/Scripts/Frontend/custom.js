/* Your JS codes here */
$(document).ready(function () {

    $(document).on("click", ".favouriteProperty", function () {
        //alert("Clicked");
        var pId = $(this).attr('data-propertId');
        //alert(pId);
        $.ajax({
            url: "AddTo-Favourite",
            type: "POST",
            data: { pId: pId },
            success: function (data) {
                //console.log(data);
            },
            complete: function () {
            },
            error: function (data) {
            }
        });
    });

    $(document).on("click", "#contactUs", function () {
        $.ajax({
            url: "ContactUs",
            type: "Get",
            success: function (data) {
                $('#MainContentFromServer').html(data);
            },
            complete: function () {
            },
            error: function (data) {
            }
        });
    });
    $(document).on("click", "#aboutUs", function () {
        $.ajax({
            url: "AboutUs",
            type: "Get",
            success: function (data) {
                $('#MainContentFromServer').html(data);
            },
            complete: function () {
            },
            error: function (data) {
            }
        });
    });
    $(document).on("click", "#news", function () {
        $.ajax({
            url: "News",
            type: "Get",
            success: function (data) {
                $('#MainContentFromServer').html(data);
            },
            complete: function () {
            },
            error: function (data) {
            }
        });
    });
    $(document).on("click", "#blog", function () {
        $.ajax({
            url: "Blogging",
            type: "Get",
            success: function (data) {
                $('#MainContentFromServer').html(data);
            },
            complete: function () {
            },
            error: function (data) {
            }
        });
    });
    $(document).on("click", "#ourServices", function () {
        $.ajax({
            url: "ourServices",
            type: "Get",
            success: function (data) {
                $('#MainContentFromServer').html(data);
            },
            complete: function () {
            },
            error: function (data) {
            }
        });
    });
    $(document).on("click", "#myFavourite", function () {
        $.ajax({
            url: "MyFavourite",
            type: "Get",
            success: function (data) {
                $('#MainContentFromServer').html(data);
            },
            complete: function () {
            },
            error: function (data) {
            }
        });
    });
  
    $(document).on("click", "#RentSearch", function() {
        var cityName = $("#cityName").val();
        var location = $("#location").val();
        var propType = $("#propType").val();
        var bed = $("#bed").val();
        var minPrice = $("#minPrice").val();
        var maxPrice = $("#maxPrice").val();
        var generalSearch = $("#generalSearch").val();

        $.ajax({
            url: "RentProperty-Search",
            type: "Get",
            data: { cityName: cityName, location: location, propType: propType, bed: bed, minPrice: minPrice, maxPrice: maxPrice, generalSearch: generalSearch },
            success: function(data) {
                console.log(data);
                $('#searchResult').html(data);
            },
            complete: function() {
            },
            error: function(data) {
            }
        });

        $(document).on("click", "#saleSearch", function () {
            var cityName = $("#cityNameS").val();
            var location = $("#locationS").val();
            var propType = $("#propTypeS").val();
            var bed = $("#bedS").val();
            var minPrice = $("#minPriceS").val();
            var maxPrice = $("#maxPriceS").val();
            var generalSearch = $("#generalSearchS").val();

            $.ajax({
                url: "RentProperty-Search",
                type: "Get",
                data: { cityName: cityName, location: location, propType: propType, bed: bed, minPrice: minPrice, maxPrice: maxPrice, generalSearch: generalSearch },
                success: function(data) {
                    console.log(data);
                    //alert(data);
                    $('#searchResult').html(data);
                },
                complete: function() {
                },
                error: function(data) {
                }
            });
        });
        

        $(document).on("click", "#agentSearch", function () {
            var cityName = $("#cityNameA").val();
            var location = $("#locationA").val();
            var propType = $("#propTypeA").val();
            var agentName = $("#agentNameA").val();
            var generalSearch = $("#generalSearchS").val();

            $.ajax({
                url: "Property-Search",
                type: "Get",
                data: { cityName: cityName, location: location, propType: propType, agentName: agentName, generalSearch: generalSearch },
                success: function (data) {
                    console.log(data);
                    //alert(data);
                    $('#searchResult').html(data);
                },
                complete: function () {
                },
                error: function (data) {
                }
            });
        });
        

       
    });

});
