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
            register: 'models/register',
            photoAlbum: 'models/photoAlbum',
            photoes: 'models/photoes'
        }
    });

    require(['underscore', 'handlebars', 'sammy'], function () {
        console.log('Successful setup!');
    });
})()