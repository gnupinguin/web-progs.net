/*$(function () {

    $("#dataForm").submit(function (evt) {
        evt.preventDefault();
        var form = $(this);

        var cityId = $("#Cities").val();
        var locationData = $(`#Cities option[value=${cityId}]`).attr("selected", "true").text().split(", ");
        var cityName = locationData[0];
        var cityLocation = locationData[1];
        
        var $data = `"CityId":${cityId},"Name":${cityName},"Location":${cityLocation}`;
        $data = encodeURIComponent($data);
        $.ajax({
            type: form.prop('method'),
            url: form.prop('action'),
            data:{"CityId" : cityId, "Name" : cityName, "Location" : cityLocation},
            traditional: true,

            success: function (html) {
                $("#tableBody").html(html);
                $('td').each(function () {
                    if ($(this).html().trim() == '') {
                        $(this).remove();
                    }
                });
                $("#weatherDataTable").css("visibility", "visible");
                
            },
            error: function (err) {
                alert('oops, something bad happened');
            }
        });
    });
});*/
$(document).ready(function () {
    $("#currentWeather").click(function () {
        getWeatherData("CurrentWeather")
    });
    $("#last5DaysWeather").click(function () {
        getWeatherData("ast5DaysWeather")
    });
})

function getWeatherData(method) {
    var cityId = $("#Cities").val();
    var form = $("#dataForm");
    var locationData = $(`#Cities option[value=${cityId}]`).attr("selected", "true").text().split(", ");
    var cityName = locationData[0];
    var cityLocation = locationData[1];
        
    var $data = `"CityId":${cityId},"Name":${cityName},"Location":${cityLocation}`;
    $data = encodeURIComponent($data);
    $.ajax({
        type: form.prop('method'),
        url: form.prop('action'),
        data:{"CityId" : cityId, "Name" : cityName, "Location" : cityLocation},
        traditional: true,

        success: function (html) {
            $("#tableBody").html(html);
            $('td').each(function () {
                if ($(this).html().trim() == '') {
                    $(this).remove();
                }
            });
            $("#weatherDataTable").css("visibility", "visible");
                
        },
        error: function (err) {
            alert('oops, something bad happened');
        }
    });
};
