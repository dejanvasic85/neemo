var neemo = neemo || {};

/*
 * Navigator
 */
neemo.navigator = (function (window, url) {

    return {
        searchProducts: function (keyword) {
            searchWithKeyWord(url.product.search, keyword);
        },
        searchProviders: function (keyword, providerType) {
            var target = url.providers.search.replace('placeholder', providerType);
            searchWithKeyWord(target, keyword);
        },
        getCurrentSearchKeyword : function() {
            // default to parts
            var searchType = 'Parts',
                keyword = '';

            // Find the keyword value
            var query = trimStart('?', window.location.search).split('&');
            for (var i = 0; i < query.length; i++) {
                if (query[i].startsWith('keyword') === true) {
                    var pair = query[i].split('=');
                    if (pair.length > 1) {
                        keyword = decodeURIComponent(pair[1]);
                    }
                    break;
                }
            }

            // Find the search type value
            if (window.location.pathname.indexOf("providers") !== -1) {
                searchType = window.location.pathname.substring(window.location.pathname.indexOf('find/') + 5);
            }

            return {
                searchType: searchType,
                keyword : keyword
            }
        }
    }

    function searchWithKeyWord(target, keyword) {
        console.log(keyword);
        if (keyword === '') {
            window.location = target;
        }
        window.location = target + '?keyword=' + encodeURIComponent(keyword);
    }

    function trimStart(character, string) {
        var startIndex = 0;

        while (string[startIndex] === character) {
            startIndex++;
        }

        return string.substr(startIndex);
    }

})(window, neemo.endpoints);



/*
 * Search UI
 */
(function ($, navigator) {

    // Search
    $('#searchTypeOptions > ul > li').on('click', function () {
        var $me = $(this);
        var searchType = $me.text();
        $me.closest('.btn-group').find('.selected').text(searchType);
    });

    $('#searchBtn').on('click', startSearch);
    $('#keyword').on('keypress', function(e) {
        if (e.which === 13) {
            e.preventDefault();
            startSearch();
        }
    });

    $('[data-search-provider]').on('click', function() {
        var $me = $(this);
        var keySearchResult = navigator.getCurrentSearchKeyword();
        navigator.searchProviders(keySearchResult.keyword, $me.text());
    });

    function startSearch() {
        var searchType = $('#searchTypeOptions .selected').text(),
            searchKeyword = $('#keyword').val();

        $('#searchBtn').button('loading');

        if (searchType === 'Parts') {
            navigator.searchProducts(searchKeyword);
            return;
        }
        // Go to a provider search result
        navigator.searchProviders(searchKeyword, searchType);
    }

    (function () {

        // Initialise the current search
        var keySearchResult = navigator.getCurrentSearchKeyword();
        $('#keyword').val(keySearchResult.keyword);
        $('#searchTypeOptions .selected').text(keySearchResult.searchType);

    })();

})(jQuery, neemo.navigator);