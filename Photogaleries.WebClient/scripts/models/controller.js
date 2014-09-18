define(['requester'], function (httpRequester) {
    var Controller = (function () {
        function Controller(url) {
            this.sourceUrl = url;
        }

        Controller.prototype.register = function (email, password) {
            var data = {
                Email: email,
                Password: password,
                ConfirmPassword: password
            };

            return httpRequester.post(this.sourceUrl, data)
                .then(function (result) {
                    console.log("registered!");
                    window.location.href = '#/home';
                });
        };

        Controller.prototype.login = function (email, password) {
            var data = {
                grant_type: 'password',
                Email: email,
                Password: password
            };

            return httpRequester.post(this.sourceUrl, data)
                .then(function (result) {
                    console.log('logged');
                    console.log(result);
                });
        };

        return Controller;
    }());

    return Controller
})