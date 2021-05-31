

function RetrieveMapsResponse(Street, Number, City, PostalCode) {
    var url = "https://maps.googleapis.com/maps/api/geocode/json?address=";
    url += (PostalCode + "+" + Street + "+" + Number + "+" + City + "&key=AIzaSyA_xd5aGMAAZ5E8ykJ3gyonm-s5XDgrBx4");
    $.get(url, function (data, status) {
        // set the hidden fields 
        $("#txtLong").val(data["results"][0]["geometry"]["location"]["lng"]);
        $("#txtLat").val(data["results"][0]["geometry"]["location"]["lat"]);
        // initialize the map marker
        initMapWithStreet(data["results"][0]["formatted_address"]);
    });
}

$(".inptMaps").keyup(function () {
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


function initMapWithStreet(queryString) {
    let map;
    let service;
    let infowindow;
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
    let map;
    let service;
    let infowindow;
    //const sydney = new google.maps.LatLng(-33.867, 151.195);
    infowindow = new google.maps.InfoWindow();
    if (document.getElementById("map") !== null) {
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
}



$(document).ready(function () {
    initMap();
    $(".event-overview-detail-wrapper").each(function () {
        loadEmbeddedMap($(this));
    })
})

function loadEmbeddedMap(element) {
    infowindow = new google.maps.InfoWindow();

    var uniqueEnum = element.find(".uniqueEnum").val();
    const request = {
        query: element.find("#queryLocation").val(),
        fields: ["name", "geometry"]
    };

    var sel = "map-" + uniqueEnum;
    console.log(document.getElementById(sel));

    var localMap = new google.maps.Map(document.getElementById(sel), {
        zoom: 15
    });

    service = new google.maps.places.PlacesService(localMap);
    service.findPlaceFromQuery(request, (results, status) => {
        if (status === google.maps.places.PlacesServiceStatus.OK && results) {
            for (let i = 0; i < results.length; i++) {
                createMarker(results[i], localMap);
            }
            localMap.setCenter(results[0].geometry.location);
        }
    });


}

function createMarker(place, map) {
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
