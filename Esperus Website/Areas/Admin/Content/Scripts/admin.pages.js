const _pageType = { Page: 'Page', Section: 'Section' }
const _contentType = { Text: 'Text', Image: 'Image', Link: 'Link', Slide: 'Slide' }

$(window).on("beforeunload", function () {
    if (checkEditor()) {
        return "There are unsaved changes on this page. Would you like to save your progress before leaving?";
    }
});

$(document).ready(function () {
    // Initialize text editors, if applicable:
    if (_model.currentType == _pageType.Section) {
        for (var _index = 0; _index < _model.contentModels.length; _index++) {
            var _currentModel = _model.contentModels[_index];

            if (_currentModel.Type == _contentType.Text || _currentModel.Type == _contentType.Slide) {
                var nameField = $(".content-editor[data-content-id='" + _currentModel.Key + "'] .name-field");
                var textEditor = $(".content-editor[data-content-id='" + _currentModel.Key + "'] .text-editor");

                $(textEditor).trumbowyg({
                    removeformatPasted: true,
                    tagsToRemove: ['script', 'link'],
                    tagsToKeep: ['i', 'script[src]', 'video'],
                    autogrow: true,
                    autogrowOnEnter: true,
                    urlProtocol: true,
                    btns: [
                        ['historyUndo', 'historyRedo'],
                        ['formatting', 'removeformat'],
                        ['strong', 'em', 'del'],
                        ['superscript', 'subscript'],
                        ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
                        ['unorderedList', 'orderedList'],
                        ['link', 'specialChars'],
                        ['viewHTML', 'fullscreen']
                    ]
                });

                $(textEditor).trumbowyg('html', _currentModel.Body);
                $(textEditor).attr('spellcheck', 'true');

                $(nameField).val(_currentModel.Name);
                $(nameField).attr('spellcheck', 'true');
            }
        }
    }

    // Initialize image editors, if applicable:
    if (_model.currentType == _pageType.Section) {
        for (var _index = 0; _index < _model.contentModels.length; _index++) {
            var _currentModel = _model.contentModels[_index];

            if (_currentModel.Type == _contentType.Image || _currentModel.Type == _contentType.Slide) {
                var _currentEditor = (_index + 1)
                var _currentPath = $("#editor-content #list-" + _currentEditor + " #_contentImage_" + _currentEditor).val();

                if (_currentPath != '') {
                    $("#editor-content #list-" + _currentEditor + " .image-gallery .card").each(function (i, obj) {
                        var _imagePath = $(obj).find("#_imagePath").val();

                        if (_currentPath == _imagePath) {
                            $(this).addClass("selected");
                        }
                    });
                }
            }
        }
    }

    $(".hierarchy").treeview({
        data: _model.displayString,
        enableLinks: true,
        showTags: true
    });

    $(".hierarchy .node-page .link-page").click(function (args) {
        args.preventDefault();

        var _selectedPageKey = $(this).attr("id");
        $("#_selectedPageKey").val(_selectedPageKey);

        var _selectedSectionKey = null;
        $("#_selectedSectionKey").val(_selectedSectionKey);

        var _selectedEditorType = $(this).parent().find(".node-type:first").text();
        $("#_selectedEditorType").val(_selectedEditorType);

        checkEditor();
    });

    $(".hierarchy .node-page .link-section").click(function (args) {
        args.preventDefault();

        var _selectedPageKey = $(".node-page.node-selected .link-page").attr('id');
        $("#_selectedPageKey").val(_selectedPageKey);

        var _selectedSectionKey = $(this).attr('id');
        $("#_selectedSectionKey").val(_selectedSectionKey);

        var _selectedEditorType = $(this).parent().find(".node-type:first").text();
        $("#_selectedEditorType").val(_selectedEditorType);

        checkEditor();
    });

    $(".editor-submit").click(function (args) {
        args.preventDefault();
        saveEditor();

        $("#save-modal").modal("hide");
        $("#_saveChanges").val(true);
        $(".editor-form").submit();
    });

    $(".editor-discard").click(function (args) {
        args.preventDefault();

        $("#save-modal").modal("hide");
        $("#_saveChanges").val(false);
        $(".editor-form").submit();
    });

    $(".select-image").click(function (args) {
        args.preventDefault();

        $(".image-gallery .card").each(function (index) {
            if ($(this).hasClass("selected")) {
                $(this).removeClass("selected");
            }
        });

        $(this).parent().parent().parent().addClass("selected");
    });
});

function saveText(currentModel, currentEditor) {
    var element = ".content-editor[data-content-id='" + currentModel.Key + "'] .text-editor";
    var body = $(element).trumbowyg("html");

    if (body != null) {
        $("#editor-content #list-" + currentEditor + " #_contentBody_" + currentEditor).val(body);
    }
}

function saveLink(currentModel, currentEditor) {
    var element = ".content-editor[data-content-id='" + currentModel.Key + "'] .link-editor";
    var link_url = $(element + " #link-url").val();
    var link_name = $(element + " #link-name").val();

    if (link_url != null) {
        $("#editor-content #list-" + currentEditor + " #_contentName_" + currentEditor).val(link_name);
        $("#editor-content #list-" + currentEditor + " #_contentBody_" + currentEditor).val(link_url);
    }
}

function saveImage(currentModel, currentEditor) {
    var element = ".content-editor[data-content-id='" + currentModel.Key + "'] .image-gallery";
    var image = $(element + " .selected #_imagePath").val();

    if (image != null) {
        $("#editor-content #list-" + currentEditor + " #_contentImage_" + currentEditor).val(image);
    }
}

function saveHeader(currentModel, currentEditor) {
    var element = ".content-editor[data-content-id='" + currentModel.Key + "'] .name-field";
    var name = $(element).val();

    if (name != null) {
        $("#editor-content #list-" + currentEditor + " #_contentName_" + currentEditor).val(name);
    }
}

function saveEditor() {
    if (_model.currentType === _pageType.Page) {
        // TODO: (this)
    }
    else if (_model.currentType === _pageType.Section) {
        for (var _index = 0; _index < _model.contentModels.length; _index++) {
            var _currentModel = _model.contentModels[_index];
            var _currentEditor = (_index + 1)

            if (_currentModel.Type === _contentType.Text) {
                saveHeader(_currentModel, _currentEditor);
                saveText(_currentModel, _currentEditor);
            }
            else if (_currentModel.Type === _contentType.Image) {
                saveImage(_currentModel, _currentEditor);
            }
            else if (_currentModel.Type === _contentType.Link) {
                saveLink(_currentModel, _currentEditor);
            }
            else if (_currentModel.Type === _contentType.Slide) {
                saveHeader(_currentModel, _currentEditor);
                saveText(_currentModel, _currentEditor);
                saveImage(_currentModel, _currentEditor);
            }

            _model.contentModels[_index] = _currentModel;
        }
    }
}

function checkEditor() {
    var _changesFound = false;

    if (_model.currentType == _pageType.Page) {
        // TODO: (this)
    }
    else if (_model.currentType == _pageType.Section) {
        for (var _index = 0; _index < _model.contentModels.length; _index++) {
            var _currentModel = _model.contentModels[_index];
            var _currentEditor = (_index + 1)

            if (_currentModel.Type == _contentType.Text || _currentModel.Type == _contentType.Slide) {
                var element = $(".content-editor[data-content-id='" + _currentModel.Key + "'] .text-editor");

                var _currentValue = $("#editor-content #list-" + _currentEditor + " #_contentBody_" + _currentEditor).val();
                var _newValue = $(element).trumbowyg('html');

                if (_currentValue != _newValue) {
                    $("#save-modal").modal("show");
                    _changesFound = true;
                }
            }
        }
    }

    if (!_changesFound) {
        $("#_saveChanges").val(false);
        $(".editor-form").submit();
    }

    return _changesFound;
}
