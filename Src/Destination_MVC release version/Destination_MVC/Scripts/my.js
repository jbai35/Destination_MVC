jQuery(function () {
    // ʱ������
    jQuery('#birthday').datetimepicker();

    jQuery('#departureDate').datetimepicker();

    jQuery('#returnDate').datetimepicker();

});

$(document).ready(function () {
    $('#data').dataTable({
        "sDom": '<"nav"lf>t<"nav"i>'
    });
});
