var neemo = neemo || {};
neemo.navigator = (function (window, url) {

    return {
        searchProducts: function (keyword) {
            searchWithKeyWord(url.product.search, keyword);
        },
        searchProviders: function (keyword, providerType) {
            searchWithKeyWord(url.providers.search, keyword);
        }
    }

    function searchWithKeyWord(target, keyword) {
        if (keyword === '') {
            window.location = target;
        }
        window.location = target + '?keyword=' + encodeURIComponent(keyword);
    }

})(window, neemo.endpoints);

(function ($, navigator) {

    // Search
    $('.keyword-search .btn-group > ul > li').on('click', function () {
        var $me = $(this);
        var searchType = $me.text();
        $me.closest('.btn-group').find('.selected').text(searchType);
        $('#searchType').val(searchType);
    });

    $('#searchBtn').on('click', startSeach);
    $('#keyword').on('keypress', function(e) {
        if (e.which === 13) {
            e.preventDefault();
            startSeach();
        }
    });

    function startSeach() {
        var searchType = $('#searchType').val(),
            searchKeyword = $('#keyword').val();


        if (searchType === 'Parts') {
            navigator.searchProducts(searchKeyword);
            return;
        }

        // Go to a provider search result
        navigator.searchProviders(searchKeyword, searchType);
    }

    (function () {

        // Initialise the current search


    })();

})(jQuery, neemo.navigator);