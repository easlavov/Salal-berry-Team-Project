define(['requester'], function (httpRequester) {
    var Controller = (function () {
        function Controller(url) {
            this.sourceUrl = url;
        }

        Controller.prototype.getMsg = function () {
            return httpRequester.get(this.sourceUrl);
        }

        Controller.prototype.sendMsg = function (data) {
            return httpRequester.post(this.sourceUrl, data);
        }

        return Controller;
    }());

    return Controller
})