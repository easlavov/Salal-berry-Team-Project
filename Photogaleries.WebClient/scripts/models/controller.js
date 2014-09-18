define(['requester'], function (httpRequester) {
    var Controller = (function () {
        function Controller(url) {
            this.sourceUrl = url;
        }

        Controller.prototype.register = function (email, password, confirmPassword) {
            var data = JSON.stringify({
                Username: email,
                Password: password,
                ConfirmPassword: confirmPassword
            });

            return httpRequester.post(this.sourceUrl, data)
                .then(function(result) {
                    console.log("registered!");
                }, function (error) {
                    console.log("error!");
                });
        }

        return Controller;
    }());

    return Controller
})