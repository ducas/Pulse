(function ($) {
    $(document).ready(function () {

        var animationEndEventNames = {
            'WebkitAnimation': 'webkitAnimationEnd',
            'MozAnimation': 'animationend',
            'OAnimation': 'oAnimationEnd',
            'msAnimation': 'MSAnimationEnd',
            'animation': 'animationend'
        };
        $.fn.animationComplete = function (callback) {
            return $(this).one(animationEndEventNames[Modernizr.prefixed('animation')], callback);
        };

        var currentPage = $('.page.active');
        if (currentPage.length == 0) {
            currentPage = $('.page').first();
            currentPage.addClass('active');
        }
        setTimeout(function() { $('.main-content').css('height', currentPage.height()); });

        var navigate = function (url) {
            var dataUrl = 'data-url="' + url + '"';
            $.ajax({
                url: url,
                success: function (data) {
                    $(document).find('div.page[' + dataUrl + ']').remove();
                    var to = $(data).appendTo($('.main-content')),
                        from = currentPage;
                    to.animationComplete(function () {
                        from.removeClass('active slide out');
                        to.removeClass('slide in');
                        currentPage = to;
                        $('.main-content').css('height', currentPage.height());
                    });
                    $('.main-content').addClass('viewport-transitioning');
                    from.addClass('slide out');
                    to.addClass('active slide in');
                    setTimeout(function() {
                        $.validator.unobtrusive.parse(to.find('form'));
                    });
                },
                error: function (data) {

                }
            });
        };

        $(document).on('click', 'a.transition', function (e) {
            e.preventDefault();
            navigate($(e.currentTarget).attr('href'));
        });

        $(document).on('submit', 'form.ajax', function (e) {
            e.preventDefault();

            var form = $(e.currentTarget),
                url = form.attr('action'),
                validator = form.validate();
            
            if (!validator.valid()) return;
            $.ajax({
                url: url,
                type: 'post',
                data: form.serialize(),
                success: function (data) {
                    if (data && data.success && data.redirect) {
                        navigate(data.redirect);
                    } else if (data && data.errors) {
                        var errors = { };
                        for (var i in data.errors) {
                            for (var j = 0; j < data.errors[i].length; j++) {
                                errors[i] = data.errors[i][j];
                            }
                        }
                        validator.showErrors(errors);
                    }
                },
                error: function (data) { }
            });
        });

    });
})(jQuery);