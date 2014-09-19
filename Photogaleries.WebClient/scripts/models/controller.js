define(['requester'], function (httpRequester) {
    var Controller = (function () {
        function Controller(url) {
            this.sourceUrl = url;
        }

        function pausecomp(millis) {
            var date = new Date();
            var curDate = null;

            do {
                curDate = new Date();
            } while (curDate - date < millis);
        }

        function renderAlbums(data) {
            var albums = data;
           
            for (var i = 0; i < albums.length-1; i++) {
                $('#wrapper')
                    .append($('<div/>')
                        .append($('<span/>').text(albums[i].Name))
                        .append($('<button/>')
                            .text('Album')
                            .attr('id', albums[i].id)
                            .on('click', function () {
                                $('#wrapper').empty();
                                
                                var album = albums[i];
                                if (album !== 'undefined') {
                                    var photos = album.Photos;
                                    renderPhotos(photos);
                                }
                            }))
                        .append($('<br/>')));
            }
        }

        function renderPhotos(data) {
            var photos = data;

            for (var i = 0; i < photos.length; i++) {
                pausecomp(120);
                getPhoto('http://localhost:7097/api/Photos/GetById/' + photos[i]);
            }
            $('#wrapper').append($('<div/>'.text('Go back').on('click', function () {
                $('#wrapper').empty();
                httpRequester.get('http://localhost:7097/api/PhotoAlbums/All')
                    .then(function (result) {
                        renderAlbums(result);
                    });
            })))
        }

        function getPhoto(sourceUrl) {
            httpRequester.get(sourceUrl)
                .then(function (result) {
                    renderPhoto(result);
                });
        };

        function renderPhoto(photo) {
            $('#wrapper')              
                .append($('<img>', { id: photo.Id, src: photo.Url, width: '300px', heigth: '200px' })
                    .addClass('album-photo')
                    .attr('margin', '10px'));
            //To DO: add event for enlarging and showing the comments...
        }

        Controller.prototype.getAlbums = function () {
            httpRequester.get(this.sourceUrl)
                .then(function (result) {
                    renderAlbums(result);
                });
        }

        Controller.prototype.register = function (email, password) {
            var data = {
                Email: email,
                Password: password,
                ConfirmPassword: password
            };

            return httpRequester.post(this.sourceUrl, data)
                .then(function(result) {
                    console.log("registered!");
                });
        }
        
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