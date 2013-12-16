
var geocoder;
var map;
var MarkerArray = [];
var infoWindow = null;
var location;

//Function for returning latitude and longitude, remember to use await
function GetLocation(address) {
    var ReturnValue;
    //Call the geocode function
    GetGeocode(address, function (LocationData) {
        ReturnValue = LocationData;
    });
    return ReturnValue;
}

//Function for adding markers
function InsertMarker(address, name, infostring) {

    //Call the geocode function
    GetGeocode(address, function (LocationData) {

        //We use an if and else statement, because we can call the function with only the address when we only want to show one marker, or if we want more than one.
        if (name == undefined) {
            CreateSingleMarker(LocationData);
        }
        else {
            AddMarkers(LocationData, name, infostring)
        }
    });

}

//Initialize function, sets up the map
function initialize() {

    var mapOptions = {
        //We set the default center to "Aalborg"
        center: new google.maps.LatLng(57.043733, 9.9485388),
        zoom: 13
    };

    map = new google.maps.Map(document.getElementById("map-canvas"),
        mapOptions);
}

//Geocode function takes an address and returns latitude and longitude.
function GetGeocode(address, callback) {
    geocoder = new google.maps.Geocoder();

    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            callback(results[0].geometry.location);
        }
    })
}



//Function for creating a single marker.
function CreateSingleMarker(location, name) {
    var marker = new google.maps.Marker({
        position: location,
        map: map,
        title: name
    })

    map.setCenter(location);

    MarkerArray.push(marker);
}

//Function for creating more than one marker.
function AddMarkers(location, name, infostring) {

    infoWindow = new google.maps.InfoWindow({
        content: "Loading..."
    });

    var marker = new google.maps.Marker({
        position: location,
        map: map,
        title: name,
        info: infostring
    })

    var bounds = new google.maps.LatLngBounds();
    for (i = 0; i < MarkerArray.length; i++) {
        bounds.extend(MarkerArray[i].getPosition());
    }

    map.fitBounds(bounds);

    google.maps.event.addListener(marker, "click", function () {
        infoWindow.setContent(this.info);
        infoWindow.open(map, this);
    })

    google.maps.event.addListener(map, "click", function () {
        infoWindow.close();

        MarkerArray.push(marker)
    })
}

google.maps.event.addDomListener(window, 'load', initialize);