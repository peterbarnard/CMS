var countryCodeInitialValue = $('#CountryCode').attr('TheOriginalValue');

PopulateCountry(countryCodeInitialValue, GetCityData);

function GetCityData() {
    var cityCodeInitialValue = $('#CityCode').attr('TheOriginalValue');
    $('#CityCode').val(cityCodeInitialValue);
}

function PopulateCountry(countryCode, doneCallback) {
    $.ajax(
        {
            url: '/Home/CountryList/',
            type: 'POST',
            dataType: 'json',
            error: function (jqXHR, textStatus) { alert(textStatus) },
            success: function (data) {
                var options = $('#CountryCode');
                $.each(data, function () {
                    options.append($('<option />').val(this.CountryCode).text(this.CountryName));
                });
                if (countryCode != "") {
                    $(options).val(countryCode);
                }
                else {
                    countryCode = $(options).val();
                }
                PopulateFromCountry(countryCode, doneCallback);
            }
        }
    )
}
