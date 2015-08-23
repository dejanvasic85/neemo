(function ($) {
    $('[data-provider-summary-rating]').each(function () {
        var $me = $(this);
        var rating = parseFloat($me.data().providerSummaryRating);
        $me.raty({
            score : rating,
            readOnly: true,
            path: $me.data().path,
            hints: ['Poor', 'Not Good', 'Average', 'Good', 'Excellent']
        });
    });

})(jQuery);