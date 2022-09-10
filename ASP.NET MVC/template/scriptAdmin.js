button = document.getElementById("hamburger-btn");
console.log(button);
let flag = 0;
function dropdown_slide() {
    if (flag == 0) {
        gsap.to(".dropdown-menu", .8, { x: `0%` });
        flag = 1;
    }
    else {
        gsap.to(".dropdown-menu", .8, { x: `101%` });
        flag = 0;
    }

}
button.addEventListener("click", dropdown_slide);
function onFileSelected(event) {
    var selectedFile = event.target.files[0];
    var reader = new FileReader();

    var imgtag = document.getElementById("pr-img");
    imgtag.title = selectedFile.name;

    reader.onload = function (event) {
        imgtag.src = event.target.result;
    };

    reader.readAsDataURL(selectedFile);
}