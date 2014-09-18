/// <reference path="scripts/_references.js" />
(function () {
    require.config({
                       paths: {
            jquery: 'libs/jquery-2.1.1.min',
            handlebars: 'libs/handlebars-v2.0.0',
            q: 'libs/q',
            sammy: 'libs/sammy-latest.min',
            underscore: 'libs/underscore-min',

            requester: 'models/http-requester',
            controller: 'models/controller',
            registerUi: 'models/register',
            register: 'models/register',
            login: 'models/login',
            photoAlbum: 'models/photoAlbum',
            photoes: 'models/photoes'
        }
                   });
    var CONTAINER_NAME = '#wrapper';

    require(['jquery', 'register', 'login', 'photoAlbum', 'sammy', 'underscore', 'handlebars'], function ($, registerUi, loginUi, photoAlbum, Sammy) {
        $(CONTAINER_NAME).on('click', '#register-init-button', function () {
            window.location.href = '#/register'
        });
        
        $(CONTAINER_NAME).on('click', '#login-init-button', function () {
            window.location.href = '#/login'
        });

        var app = Sammy(CONTAINER_NAME, function () {
            this.get('#/home', function () {
                $(CONTAINER_NAME).load('views/home.html');
            });

            this.get("#/register", function () {
                register.show(CONTAINER_NAME, 'views/register.html');
                register.setEvent(CONTAINER_NAME);
            });

            this.get("#/login", function () {
                login.show(CONTAINER_NAME, 'views/login.html');
                login.setEvent(CONTAINER_NAME);
            });
        });
        app.run('#/home');
    })()
})()