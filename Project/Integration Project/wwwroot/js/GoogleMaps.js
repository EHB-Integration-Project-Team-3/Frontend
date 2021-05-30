

function RetrieveMapsResponse(Street, Number, City, PostalCode) {
    var url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
    url += (PostalCode + "+" + Street + "+" + Number + "+" + City + "&key=AIzaSyA_xd5aGMAAZ5E8ykJ3gyonm-s5XDgrBx4");
    $.get(url, function (data, status) {
        console.log(
            data["results"]
            );
    });
}

$("#GenMapsResponse").click(function () {
    RetrieveMapsResponse(
        $("#inptStreet").val(),
        $("#inptNumber").val(),
        $("#inptCity").val(),
        $("#inptPostalCode").val()
    );
})