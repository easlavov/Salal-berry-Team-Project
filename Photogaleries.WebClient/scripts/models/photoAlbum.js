define(['controller'], function (Controller) {
    var photoAlbumUi = (function () {
        $(document).ready(function () {
            var controller = new Controller('http://localhost:7097/api/PhotoAlbums/All');
            controller.getAlbums();

        });
    }());

    return photoAlbumUi
})