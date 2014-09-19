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

            for (var i = 0; i < albums.length; i++) {
                $('#wrapper')
                    .append($('<div/>').addClass("menu")
                        .append($('<span/>').text(albums[i].Name))
                        .append($('<button/>')
                            .text('Album')
                            .attr('id', i)
                            .on('click', function () {
                                $('#wrapper').empty();
                                $this = $(this);
                                index = $this.attr('id');
                                var album = albums[index];
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
                getPhoto('http://localhost:7097/api/Photos/GetById/' + photos[i]);
                pausecomp(150);
            }
            //$('#wrapper').append($('<button/>').text('Go back').on('click', function () {
            //    $('#wrapper').empty();
            //    httpRequester.get('http://localhost:7097/api/PhotoAlbums/All')
            //        .then(function (result) {
            //            renderAlbums(result);
            //        });
            //}));
        }

        function renderPhoto(photo) {
            $('#wrapper')
                .append($('<img>', { id: photo.Id, src: photo.Url, width: '300px', heigth: '200px' })
                    .addClass('album-photo')
                    .attr('margin', '10px')).on('click', function () {
                        $('#wrapper').empty();

                        $('#wrapper').append($('<img>', { src: photo.Url, width: '500px', heigth: '400px' }));
                        var comments = photo.Comments;
                        for (var i = 0; i < comments.length; i++) {
                            $('#wrapper').append($('<div>').text(comments.text));
                        }

                        $('#wrapper').append(comment.Input);
                        $('#wrapper').append($('<button>').text('Post comment').on('click', function myfunction() {
                            createComment(photo.Id, '#comment-input', photo);
                        }));
                    });
        }

        function createComment(id, input, photo) {
            var data = {
                Text: input.val(),
                Date: new Date(),
                PhotoId: id
            };

            httpRequester.createComment('http://localhost:7097/api/Comments/Create', data, token);
            renderPhoto(photo);
        }

        function getPhoto(sourceUrl) {
            httpRequester.get(sourceUrl)
                .then(function (result) {
                    renderPhoto(result);
                });
        };

        //function renderPhoto(photo) {
        //    $('#wrapper')              
        //        .append($('<img>', { id: photo.Id, src: photo.Url, width: '300px', heigth: '200px' })
        //            .addClass('album-photo')
        //            .attr('margin', '10px'));
        //    //To DO: add event for enlarging and showing the comments...
        //}

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
                .then(function (result) {
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