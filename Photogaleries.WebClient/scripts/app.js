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
            photoAlbum: 'models/photoAlbum',
            photoes: 'models/photoes'
        }
    });

    require(['jquery', 'registerUi', 'sammy', 'photoAlbum', 'underscore', 'handlebars'], function ($, registerUi, Sammy,photoAlbumUi) {
        var app = Sammy('#register-form', function () {
            this.get("#/register", function () {
            });
        });
        app.run('#/register');
    });
})()