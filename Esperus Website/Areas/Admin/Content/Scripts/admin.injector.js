const _contentType = { Text: 'Text', Image: 'Image', Slide: 'Slide', Link: 'Link' }

$(document).ready(function () {
    $("*[data-admin-page]").find("*[data-admin-content]").each(function () {
        var content = model.pageContent;
        for (var index = 0; index < content.length; index++) {
            var contentKey = $(this).data("admin-content");

            if (content[index].Key == contentKey) {
                if (content[index].Type == _contentType.Text) {
                    var contentName = $(this).find("*[data-admin-content-header]");
                    var contentBody = $(this).find("*[data-admin-content-body]");

                    $(contentName).text(content[index].Name);

                    var body = $.parseHTML(content[index].Body);
                    $(contentBody).append(body);
                }
                else if (content[index].Type == _contentType.Image) {
                    var contentImage = $(this).find("*[data-admin-content-image]");
                    $(contentImage).attr('src', content[index].Image); // TODO: Replace this with 'content[index].Image' eventually.
                }
                else if (content[index].Type == _contentType.Slide) {
                    var contentName = $(this).find("*[data-admin-content-header]");
                    var contentBody = $(this).find("*[data-admin-content-body]");
                    var contentImage = $(this).find("*[data-admin-content-background]");

                    $(contentName).text(content[index].Name);

                    var body = $.parseHTML(content[index].Body);
                    $(contentBody).append(body);

                    $(contentImage).css('background-image', 'url(' + content[index].Image + ')');
                }
                else if (content[index].Type == _contentType.Link) {
                    var contentLink = $(this).find("*[data-admin-content-link]");

                    $(contentLink).append(content[index].Name);
                    $(contentLink).attr('href', content[index].Body);
                }
            }
        }
    });
});
