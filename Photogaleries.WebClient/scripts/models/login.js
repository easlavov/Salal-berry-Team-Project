define(['controller'], function (Controller) {
    var loginUi = (function () {
        var controller = new Controller('http://localhost:7097/Token');

        function setEvent(containerName) {
            $(containerName).on('click', '#login', function () {
                var email = $('#email').val(),
                    password = $('#password').val();

                controller.login(email, password);
            });
        }

        function showView(loadIn, sourceUri) {
            $(loadIn).load(sourceUri);
        }

        return {
            setEvent: setEvent,
            show: showView,
        }
    }());

    return loginUi;
})