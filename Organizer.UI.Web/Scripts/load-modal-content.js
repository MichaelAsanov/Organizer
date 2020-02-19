function loadContentToModal(url, modalWindowSelector, contentElementSelector) {
    $.ajaxSetup({ cache: false });
    $(contentElementSelector).load(url, function () {
        $(modalWindowSelector).modal({
            backdrop: 'static',
            keyboard: true
        }, 'show');
    });
};


function submitFormData(url, formSelector, modalSelector) {
    var formData = $(formSelector).serialize();
    var content2Replace = $('#content2Replace');
    $.ajax({
        cache: false,
        url: url,
        data: formData,
        type: 'post'
    }).success(function (result) {
        if (result.success === false) {
            content2Replace.html(result.htmlresponse);
            $.validator.unobtrusive.parse(content2Replace);
        }
        else {
            $(modalSelector).modal("hide");
        }
    });
};