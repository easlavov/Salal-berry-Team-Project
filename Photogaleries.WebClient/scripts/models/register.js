define(['controller'], function (Controller) {
    var registerUi = (function () {
        var controller = new Controller('http://localhost:7097/api/Account/Register');

        function setEvent(containerName) {
            $(containerName).on('click', '#register', function () {
                var email = $('#email').val(),
                    password = $('#password').val(),
                    confirmPassword = $('#confirmed-password').val();

                // TODO: check confirmed password
                controller.register(email, password, confirmPassword);
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

    return registerUi
})