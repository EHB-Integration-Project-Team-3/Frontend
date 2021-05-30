
$(document).ready(function () {
    initMap();
});

function RetrieveMapsResponse(Street, Number, City, PostalCode) {
    var url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
    url += (PostalCode + "+" + Street + "+" + Number + "+" + City + "&key=AIzaSyA_xd5aGMAAZ5E8ykJ3gyonm-s5XDgrBx4");
    $.get(url, function (data, status) {
        console.log(
            data["results"][0]["formatted_address"]
        );
        initMapWithStreet(data["results"][0]["formatted_address"]);
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

// This example requires the Places library. Include the libraries=places
// parameter when you first load the API. For example:
// <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">
let map;
let service;
let infowindow;

function initMapWithStreet(queryString) {
    map = new google.maps.Map(document.getElementById("map"), {
        //center: sydney,
        zoom: 15,
    });
    const request = {
        query: queryString,
        fields: ["name", "geometry"],
    };
     service = new google.maps.places.PlacesService(map);
    service.findPlaceFromQuery(request, (results, status) => {
        if (status === google.maps.places.PlacesServiceStatus.OK && results) {
            for (let i = 0; i < results.length; i++) {
                createMarker(results[i]);
            }
            map.setCenter(results[0].geometry.location);
        }
    });
}

function initMap() {
    //const sydney = new google.maps.LatLng(-33.867, 151.195);
    infowindow = new google.maps.InfoWindow();
    map = new google.maps.Map(document.getElementById("map"), {
        //center: sydney,
        zoom: 15,
    });

    const request = {
        query: "Erasmus hogeschool brussel nijverheidskaai",
        fields: ["name", "geometry"],
    };

    service = new google.maps.places.PlacesService(map);
    service.findPlaceFromQuery(request, (results, status) => {
        if (status === google.maps.places.PlacesServiceStatus.OK && results) {
            for (let i = 0; i < results.length; i++) {
                createMarker(results[i]);
            }
            map.setCenter(results[0].geometry.location);
        }
    });
}

function createMarker(place) {
    if (!place.geometry || !place.geometry.location) return;
    const marker = new google.maps.Marker({
        map,
        position: place.geometry.location,
    });
    google.maps.event.addListener(marker, "click", () => {
        infowindow.setContent(place.name || "");
        infowindow.open(map);
    });
}
