define(['requester'], function (httpRequester) {
    var Controller = (function () {
        function Controller(url) {
            this.sourceUrl = url;
        }

        Controller.prototype.register = function (email, password) {
            var data = JSON.stringify({
                grant_type: 'password',
                username: email,
                password: password
            });

            return httpRequester.post(this.sourceUrl, data)
                .then(function(result) {
                    console.log("registered!");
            });
        }

        return Controller;
    }());

    return Controller
})