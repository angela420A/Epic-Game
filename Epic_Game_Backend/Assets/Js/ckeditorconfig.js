CKEDITOR.editorConfig = function (config) {

    config.enterMode = CKEDITOR.ENTER_DIV;
    config.width = 500;
    config.height = 500;
    config.toolbar = [
        ['Templates', 'Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'],
        ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
        ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
        ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
        ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
        ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
        ['Link', 'Unlink', 'Anchor'],
        ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'],
        ['Styles', 'Format', 'Font', 'FontSize'],
        ['TextColor', 'BGColor']
    ];
};