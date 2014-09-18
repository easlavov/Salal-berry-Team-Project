define(function () {
    var httpRequester = (function () {
        var makeHttpRequest = function (url, type, data) {
            var deferred = $.Deferred();

            $.ajax({
                url: url,
                type: type,
                data: data,
                success: function (resultData) {
                    deferred.resolve(resultData);
                },
                error: function (errorMsg) {
                    deferred.reject(errorMsg);
                }
            })

            return deferred.promise();
        }

        var getJSON = function (url) {
            return makeHttpRequest(url, 'GET');
        };
        var postJSON = function (url, data) {
            return makeHttpRequest(url, 'POST', data);
        };

        return {
            get: getJSON,
            post: postJSON
        }
    }());

    return httpRequester;
})