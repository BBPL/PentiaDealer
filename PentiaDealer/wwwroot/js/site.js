// Write your JavaScript code.

$(document).ready(function () {
    $(".advSearch").hide();
    $("#advSearch").click(function () {
        $(".advSearch").toggle();
    })


    var customers = $("#SearchByCustomer");
    var cars = $("#SearchByCar");
    var sp = $("#SearchBySP");
    customers.hide();
    cars.hide();
    sp.hide();

    $("#SearchBy").change(function () {
        var val = $("#SearchBy").val();
        $("#SearchBy").each(function () {
            switch (val) {
                case "Customer":
                    customers.show();
                    cars.hide();
                    sp.hide();
                    break;
                case "Cars":
                    customers.hide();
                    cars.show();
                    sp.hide();
                    break;
                case "SalesPerson":
                    customers.hide();
                    cars.hide();
                    sp.show();
                    break;
                default:
                    customers.show();
                    cars.hide();
                    sp.hide();
                    break;
                
            }
        })
    }).trigger("change");


})


$(document).ready(function () {
    $("#SearchBtn").click(function () {
        var SearchBy = $("#SearchBy").val();
        var SearchByCustomer = $("#SearchByCustomer").val();
        var SearchByCar = $("#SearchByCar").val();
        var SearchBySP = $("#SearchBySP").val();
        var SearchValue = $("#Search").val();
        
        console.log(SearchBy);
        switch (SearchBy) {
            case "Customer":
                searchCustomers(SearchByCustomer, SearchValue);
                break;
            case "Cars":
                searchCars(SearchByCar, SearchValue);
                break;
            case "SalesPerson":
                searchSalesPeople(SearchBySP, SearchValue);
                break;
        }

       

    })
})


function searchCustomers(spec, val) {
    var SetData = $("#DataSearching");
    SetData.html("");
    $.ajax({
        type: "POST",
        url: "/Search/SearchCustomers?SearchSpec=" + spec + "&SearchValue=" + val,
        contentType: "html",
        success: function (result) {
            console.log(result)
            if (result.length == 0) {
                SetData.append("No data");
            } else {
                $.each(result, function (index, value) {

                    SetData.append(printResult(value));
                })
            }
        }
    })
}

function searchCars(spec, val) {
    var SetData = $("#DataSearching");
    SetData.html("");
    $.ajax({
        type: "POST",
        url: "/Search/SearchCars?SearchSpec=" + spec + "&SearchValue=" + val,
        contentType: "html",
        success: function (result) {
            if (result.length == 0) {
                SetData.append("No data");
            } else {
                $.each(result, function (index, value) {

                    SetData.append(printResult(value));
                })
            }
        }
    })
}

function searchSalesPeople(spec, val) {
    var SetData = $("#DataSearching");
    SetData.html("");
    $.ajax({
        type: "POST",
        url: "/Search/SearchSP?SearchSpec=" + spec + "&SearchValue=" + val,
        contentType: "html",
        success: function (result) {
            if (result.length == 0) {
                SetData.append("No data");
            } else {
                $.each(result, function (index, value) {

                    SetData.append(printResult(value));
                })
            }
        }
    })
}

function printResult(value) {
    var data =
        '<div class="col-sm-6 col-md-4">' +
        '<div class="thumbnail">' +
        '<h3>' + value.customers.name + " " + value.customers.surname + '</h3>' +
        '<p>' +
        '<br>Address: ' + value.customers.address +
        '<br>Car: ' + value.cars.make + ' ' + value.cars.model +
        '<br>Color: ' + value.cars.color +
        '<br>Sold by: ' + value.salesPerson.name +
        '<br>Sold on: ' + value.buyDate +
        '<br>Sold for: ' + value.price +
        '</p>' +
        '</div>' +
        '</div>';
    return data;
}