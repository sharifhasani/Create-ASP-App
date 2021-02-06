function readURL(input, dist) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $(dist).attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]); // convert to base64 string
    }
}


// for Use This option place this code under the page
$("#imgInput").change(function () {
    readURL(this, "#imgShow");
});
