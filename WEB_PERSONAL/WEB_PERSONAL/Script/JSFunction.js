﻿function allowOnlyNumber(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function maxBuy(max, evt) {
    var m = parseInt(max);
    var input = parseInt(evt.value);

    if (input > max) {
        alert("ไม่สามารถระบุจำนวนมากกว่า : " + max);
        evt.value = max;
    }

}