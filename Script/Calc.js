

function onlyDecimal(element, decimals) {
    $(element).keypress(function (event) {
        num = $(this).val();
        num = isNaN(num) || num === '' || num === null ? 0.00 : num;
        if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
            event.preventDefault();

        }
        if ($(this).val() == parseFloat(num).toFixed(decimals)) {
            event.preventDefault();
        }
    });
}

function calculateSum(element, totElement) {
    $(element).each(function () {
        $(element).keyup(function () {
            var sum = 0;
            //iterate through each textboxes and add the values
            $(element).each(function () {

                //add only if the value is number
                if (!isNaN(this.value) && this.value.length != 0) {
                    sum += parseFloat(this.value);
                }

            });
            //.toFixed() method will roundoff the final sum to 2 decimal places
            $(totElement).val(sum.toFixed(2));
        });
    });
}
