(function ($, neemo, cookieMgr) {
    var hints = ['Poor', 'Not Good', 'Average', 'Good', 'Excellent'],
        cookieName = 'provider-reviews';

    $('[data-provider-summary-rating]').each(function () {
        var $me = $(this);
        var rating = parseFloat($me.data().providerSummaryRating);
        $me.raty({
            score: rating,
            readOnly: true,
            path: $me.data().path,
            hints: hints
        });
    });

    neemo.providerReview = function (providerId, ratingElement, nameElement, commentElement, submitElement, endpoint, done, invalid) {

        // Unfortunately, the ko applybindings is all about shopping and it's site wide!
        // So we have to fallback to using plain jQuery crap
        var cookie = cookieMgr.get(cookieName);
        if (cookie !== undefined && cookie !== null) {
            var posts = cookie.split(',');
            for (var i = 0; i < posts.length; i++) {
                if (posts[i] === providerId) {
                    done();
                    return;
                }
            }
        }

        var rating = {
            providerId: providerId,
            score: 0
        };

        ratingElement.raty({
            path: ratingElement.data().path,
            hints: hints,
            click: function (score) {
                rating.score = score;
            }
        });

        submitElement.on('click', function () {
            rating.comment = commentElement.val();
            rating.reviewerName = nameElement.val();

            if (rating.comment === '' || rating.reviewerName === '') {
                invalid();
                return;
            }

            submitElement.button('loading');
            $.ajax({
                url: endpoint,
                type: 'POST',
                data: rating,
                complete: function () {
                    debugger;
                    var cookieValue = cookieMgr.get(cookieName) || '';
                    if (cookieValue != '') {
                        cookieValue += ',';
                    }
                    cookieValue += providerId;
                    cookieMgr.set(cookieName, cookieValue);
                    done();
                },
            });
        });
    }


})(jQuery, neemo, Mage.Cookies);