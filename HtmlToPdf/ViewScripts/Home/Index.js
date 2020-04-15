
function PostHtml() {
    var Html = {};
    Html.Code = tinymce.activeEditor.getContent();

    $.ajax(
    {
        type: "POST",
        url: '/Home/PostHtml',
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(Html),
        success: function (response) {
            $('#pdf-holder').attr('src', '/Home/GetPdf');
        }
    });
}

$(function () {

    tinymce.init({
        selector: '#html-holder',
        plugins: 'print preview fullpage searchreplace autolink directionality visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount imagetools contextmenu colorpicker textpattern help'               
    });

    $("#html-to-pdf").tabs();

    $('#ui-id-2').click(function () {
        PostHtml();
    });
});