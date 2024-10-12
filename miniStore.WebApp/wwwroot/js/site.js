var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        loadCart();
    }
    function loadCart() {
        const culture = $('#idCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListItems',
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
            }
        });
    }
    function regsiterEvents() {
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            const culture = $('#idCulture').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture + '/Cart/AddToCart',
                data: {
                    id: id,
                    languageId: culture
                },
                success: function (res) {
                    $('#lbl_number_items_header').text(res.length);
                },
                error: function (err) {
                    console.log(err);
                }
            });
        });
    }
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}