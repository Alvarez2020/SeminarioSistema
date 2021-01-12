//Funcion para quitar clases de menu-open y active
function quitarClases() {
    var has = document.getElementsByClassName("nav-link");
    for (var i = 0; i < has.length; i++) {
        has[i].classList.remove("active-page");
    }

    var a = document.getElementsByClassName("dropdown-toggle");
    for (var i = 0; i < a.length; i++) {
        a[i].classList.remove("active-page");
    }
}